using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using formstienda.Datos;
using static formstienda.Login;

namespace formstienda.Servicios
{
    public class EgresoServicio
    {
        // Contexto de base de datos
        private readonly DbTiendaSeptentrionContext _contexto;

        // Constructor que recibe el contexto de base de datos
        public EgresoServicio(DbTiendaSeptentrionContext contexto)
        {
            _contexto = contexto ?? throw new ArgumentNullException(nameof(contexto));
        }

        // Método principal para crear un egreso
        public bool CrearEgreso(int idApertura, DateOnly fechaEgreso, decimal? cantidadCordobas, decimal? cantidadDolares, string motivo)
        {
            //VALIDACIONES

            // Validar que haya un usuario logueado
            if (!UsuarioActivo.HayUsuarioLogueado())
            {
                throw new InvalidOperationException("No hay un usuario logueado para registrar el egreso");
            }

            // Obtener ID del usuario logueado
            var idUsuario = UsuarioActivo.ObtenerIdUsuario();
            if (!idUsuario.HasValue)
            {
                throw new InvalidOperationException("El usuario logueado no tiene un ID válido");
            }

            // Validar ID de apertura
            if (idApertura < 0)
            {
                throw new ArgumentException("El ID de apertura no es válido");
            }

            // Validar motivo del egreso
            if (string.IsNullOrWhiteSpace(motivo))
            {
                throw new ArgumentException("El motivo del egreso no puede estar vacío");
            }

            if (motivo.Length > 255)
            {
                throw new ArgumentException("El motivo no puede exceder los 255 caracteres");
            }

            // Validar montos
            if (!cantidadCordobas.HasValue && !cantidadDolares.HasValue)
            {
                throw new ArgumentException("Debe especificar al menos un monto en córdobas o dólares");
            }

            // Validar que los montos no sean negativos
            if ((cantidadCordobas ?? 0) < 0 || (cantidadDolares ?? 0) < 0)
            {
                throw new ArgumentException("Los montos no pueden ser negativos");
            }

            // Validar que al menos un monto sea mayor que cero
            if ((cantidadCordobas ?? 0) == 0 && (cantidadDolares ?? 0) == 0)
            {
                throw new ArgumentException("Al menos un monto debe ser mayor que cero");
            }

            // Validar existencia de la apertura
            if (!_contexto.AperturaCajas.Any(a => a.IdApertura == idApertura))
            {
                throw new ArgumentException("La apertura de caja especificada no existe");
            }

            // Validar que la fecha de egreso no sea futura
            if (fechaEgreso > DateOnly.FromDateTime(DateTime.Now))
            {
                throw new ArgumentException("La fecha de egreso no puede ser futura");
            }

            // Validar que la fecha de egreso no sea anterior a la apertura
            var apertura = _contexto.AperturaCajas
                .AsNoTracking()
                .FirstOrDefault(a => a.IdApertura == idApertura);

            if (apertura == null)
            {
                throw new ArgumentException("La apertura de caja especificada no existe");
            }

            if (fechaEgreso < apertura.FechaApertura)
            {
                throw new ArgumentException("La fecha de egreso no puede ser anterior a la fecha de apertura");
            }

            

            //CREACIÓN DEL EGRESO

            // Iniciar transacción para asegurar la atomicidad
            using var transaction = _contexto.Database.BeginTransaction();

            try
            {
                // 1. Obtener o crear el arqueo de caja
                var arqueo = _contexto.ArqueoCajas
                    .FirstOrDefault(a => a.IdApertura == idApertura);

                if (arqueo == null)
                {
                    // Crear nuevo arqueo si no existe
                    arqueo = new ArqueoCaja
                    {
                        IdApertura = idApertura,
                        IdUsuario = idUsuario.Value,
                        TotalEfectivoCordoba = 0,
                        TotalEfectivoDolar = 0,
                        FaltanteCordoba = null,
                        FaltanteDolar = null,
                        SobranteCordoba = null,
                        SobranteDolar = null
                    };
                    _contexto.ArqueoCajas.Add(arqueo);
                    _contexto.SaveChanges(); // Guardar el arqueo
                }

                // 2. Crear el registro de egreso
                var egreso = new Egreso
                {
                    IdArqueoCaja = arqueo.IdArqueoCaja,
                    IdApertura = idApertura,
                    IdUsuario = idUsuario.Value,
                    FechaEgreso = fechaEgreso,
                    CantidadEgresadaCordoba = cantidadCordobas ?? 0,
                    CantidadEgresadaDolar = cantidadDolares ?? 0,
                    MotivoEgreso = motivo.Trim()
                };

                _contexto.Egresos.Add(egreso);


                // 3. Guardar todos los cambios y confirmar transacción
                var result = _contexto.SaveChanges() > 0;
                transaction.Commit();

                return result;
            }
            catch (DbUpdateException dbEx)
            {
                // En caso de error, hacer rollback y propagar la excepción
                transaction.Rollback();
                throw new ApplicationException("Error de base de datos al crear el egreso: " + dbEx.InnerException?.Message, dbEx);
            }
            catch (Exception ex)
            {
                // En caso de error, hacer rollback y propagar la excepción
                transaction.Rollback();
                throw new ApplicationException("Error al crear el egreso: " + ex.Message, ex);
            }
        }

        // --- MÉTODOS PARA OBTENER TOTALES ---

        // Obtener total en córdobas considerando varios factores
        public decimal ObtenerTotalCajaCordobas(DateOnly fecha)
        {
            // Obtener apertura de caja
            var apertura = ListarAperturaCaja(fecha).FirstOrDefault();
            decimal montoApertura = (decimal)(apertura?.MontoApertura ?? 0);

            // Sumar ventas en córdobas
            decimal totalVentas = (Decimal)ListarTotalVenta(fecha)
                .Where(v => v.PagoCordobas.HasValue)
                .Sum(v => v.PagoCordobas.Value);

            // Sumar pagos de crédito en córdobas
            decimal totalCreditos = (Decimal)ListarPagosCredito(fecha)
                .Where(p => p.CordobasAbonados.HasValue)
                .Sum(p => p.CordobasAbonados.Value);

            // Restar devoluciones
            decimal totalDevoluciones = (Decimal)ListarDevolucion(fecha)
                .Sum(d => d.MontoDevolucion);

            // Restar egresos del día
            decimal totalEgresos = _contexto.Egresos
                .Where(e => e.FechaEgreso == fecha)
                .Sum(e => e.CantidadEgresadaCordoba);

            // Cálculo del total final
            return montoApertura + totalVentas + totalCreditos - totalDevoluciones - totalEgresos;
        }

        // Obtener total en dólares considerando varios factores
        public decimal ObtenerTotalCajaDolares(DateOnly fecha)
        {
            // Sumar ventas en dólares
            decimal totalVentas = (Decimal)ListarTotalVenta(fecha)
                .Where(v => v.PagoDolares.HasValue)
                .Sum(v => v.PagoDolares.Value);

            // Sumar pagos de crédito en dólares
            decimal totalCreditos = (decimal)ListarPagosCredito(fecha)
                .Where(p => p.DolaresAbonados.HasValue)
                .Sum(p => p.DolaresAbonados.Value);

            // Restar egresos del día
            decimal totalEgresos = _contexto.Egresos
                .Where(e => e.FechaEgreso == fecha)
                .Sum(e => e.CantidadEgresadaDolar);

            // Cálculo del total final
            return totalVentas + totalCreditos - totalEgresos;
        }

        // Obtener total de egresos en córdobas para una fecha
        public decimal ObtenerTotalEgresosCordobas(DateOnly fecha)
        {
            return _contexto.Egresos
                .Where(e => e.FechaEgreso == fecha)
                .Sum(e => e.CantidadEgresadaCordoba);
        }

        // Obtener total de egresos en dólares para una fecha
        public decimal ObtenerTotalEgresosDolares(DateOnly fecha)
        {
            return _contexto.Egresos
                .Where(e => e.FechaEgreso == fecha)
                .Sum(e => e.CantidadEgresadaDolar);
        }

        // Listar aperturas de caja para una fecha específica
        public List<AperturaCaja> ListarAperturaCaja(DateOnly fechaActual)
        {
            return _contexto.AperturaCajas
                .Where(a => a.FechaApertura == fechaActual)
                .AsNoTracking()  
                .ToList();
        }

        // Listar ventas para una fecha específica
        public List<Ventum> ListarTotalVenta(DateOnly fechaActual)
        {
            return _contexto.Venta
                .Where(a => a.FechaVenta == fechaActual)
                .AsNoTracking()  
                .ToList();
        }

        // Listar devoluciones para una fecha específica
        public List<Devolucion> ListarDevolucion(DateOnly fechaActual)
        {
            return _contexto.Devolucions
                .Where(a => a.FechaDevolucion == fechaActual)
                .AsNoTracking() 
                .ToList();
        }

        // Listar pagos de crédito para una fecha específica
        public List<PagoDeCredito> ListarPagosCredito(DateOnly fechaActual)
        {
            return _contexto.PagoDeCreditos
                .Where(a => a.FechaPago == fechaActual)
                .AsNoTracking() 
                .ToList();
        }
    }
}