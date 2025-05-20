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
        private readonly DbTiendaSeptentrionContext _contexto;

        public EgresoServicio(DbTiendaSeptentrionContext contexto)
        {
            _contexto = contexto ?? throw new ArgumentNullException(nameof(contexto));
        }

        public bool CrearEgreso(int idApertura, DateOnly fechaEgreso, decimal? cantidadCordobas, decimal? cantidadDolares, string motivo)
        {
            // Validación inicial de usuario
            if (!UsuarioActivo.HayUsuarioLogueado())
            {
                throw new InvalidOperationException("No hay un usuario logueado para registrar el egreso");
            }

            var idUsuario = UsuarioActivo.ObtenerIdUsuario();
            if (!idUsuario.HasValue)
            {
                throw new InvalidOperationException("El usuario logueado no tiene un ID válido");
            }

            // Validaciones básicas de parámetros
            if (idApertura <= 0)
            {
                throw new ArgumentException("El ID de apertura no es válido");
            }

            if (string.IsNullOrWhiteSpace(motivo))
            {
                throw new ArgumentException("El motivo del egreso no puede estar vacío");
            }

            if (motivo.Length > 255)
            {
                throw new ArgumentException("El motivo no puede exceder los 255 caracteres");
            }

            // Validación de montos
            if (!cantidadCordobas.HasValue && !cantidadDolares.HasValue)
            {
                throw new ArgumentException("Debe especificar al menos un monto en córdobas o dólares");
            }

            if ((cantidadCordobas ?? 0) < 0 || (cantidadDolares ?? 0) < 0)
            {
                throw new ArgumentException("Los montos no pueden ser negativos");
            }

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

            if (!_contexto.AperturaCajas.Any(a => a.IdApertura == idApertura))
            {
                throw new Exception("La apertura de caja especificada no existe");
            }

            if (UsuarioActivo.ObtenerIdUsuario() == null)
            {
                throw new Exception("No hay un usuario válido logueado");
            }

            using var transaction = _contexto.Database.BeginTransaction();

            try
            {
                // 1. Obtener o crear el arqueo de caja
                var arqueo = _contexto.ArqueoCajas
                    .FirstOrDefault(a => a.IdApertura == idApertura);

                if (arqueo == null)
                {
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

                // 2. Crear el egreso vinculado al arqueo
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

                // 3. Actualizar los totales del arqueo
                if (cantidadCordobas.HasValue && cantidadCordobas > 0)
                {
                    arqueo.TotalEfectivoCordoba -= (float)cantidadCordobas.Value;
                }

                if (cantidadDolares.HasValue && cantidadDolares > 0)
                {
                    arqueo.TotalEfectivoDolar -= (float)cantidadDolares.Value;
                }


                // 4. Guardar todos los cambios
                var result = _contexto.SaveChanges() > 0;
                transaction.Commit();

                return result;
            }
            catch (DbUpdateException dbEx)
            {
                transaction.Rollback();
                throw new ApplicationException("Error de base de datos al crear el egreso: " + dbEx.InnerException?.Message, dbEx);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new ApplicationException("Error al crear el egreso: " + ex.Message, ex);
            }
        }



        public decimal ObtenerTotalCajaCordobas(DateOnly fecha)
        {
            // Obtener apertura
            var apertura = ListarAperturaCaja(fecha).FirstOrDefault();
            decimal montoApertura = (decimal)(apertura?.MontoApertura ?? 0);

            // Sumar ventas en córdobas
            decimal totalVentas = (Decimal)ListarTotalVenta(fecha)
                .Where(v => v.PagoCordobas.HasValue)
                .Sum(v => v.PagoCordobas.Value);

            // Sumar pagos crédito en córdobas
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

            return montoApertura + totalVentas + totalCreditos - totalDevoluciones - totalEgresos;
        }

        public decimal ObtenerTotalCajaDolares(DateOnly fecha)
        {
            // Similar al método anterior pero para dólares
            decimal totalVentas = (Decimal)ListarTotalVenta(fecha)
                .Where(v => v.PagoDolares.HasValue)
                .Sum(v => v.PagoDolares.Value);

            decimal totalCreditos = (decimal)ListarPagosCredito(fecha)
                .Where(p => p.DolaresAbonados.HasValue)
                .Sum(p => p.DolaresAbonados.Value);

            decimal totalEgresos = _contexto.Egresos
                .Where(e => e.FechaEgreso == fecha)
                .Sum(e => e.CantidadEgresadaDolar);

            return totalVentas + totalCreditos - totalEgresos;
        }

        public List<Egreso> ListarEgresosPorFecha(DateOnly fecha)
        {
            return _contexto.Egresos
                .Where(e => e.FechaEgreso == fecha)
                .AsNoTracking()
                .ToList();
        }

        public List<Egreso> ListarEgresosPorApertura(int idApertura)
        {
            return _contexto.Egresos
                .Where(e => e.IdApertura == idApertura)
                .AsNoTracking()
                .ToList();
        }

        public decimal ObtenerTotalEgresosCordobas(DateOnly fecha)
        {
            return _contexto.Egresos
                .Where(e => e.FechaEgreso == fecha)
                .Sum(e => e.CantidadEgresadaCordoba);
        }

        public decimal ObtenerTotalEgresosDolares(DateOnly fecha)
        {
            return _contexto.Egresos
                .Where(e => e.FechaEgreso == fecha)
                .Sum(e => e.CantidadEgresadaDolar);
        }

        public List<AperturaCaja> ListarAperturaCaja(DateOnly fechaActual)
        {
            return _contexto.AperturaCajas
                .Where(a => a.FechaApertura == fechaActual)
                .AsNoTracking()
                .ToList();
        }

        public List<Ventum> ListarTotalVenta(DateOnly fechaActual)
        {
            return _contexto.Venta
                .Where(a => a.FechaVenta == fechaActual)
                .AsNoTracking()
                .ToList();
        }

        public List<Devolucion> ListarDevolucion(DateOnly fechaActual)
        {
            return _contexto.Devolucions
                .Where(a => a.FechaDevolucion == fechaActual)
                .AsNoTracking()
                .ToList();
        }

        public List<PagoDeCredito> ListarPagosCredito(DateOnly fechaActual)
        {
            return _contexto.PagoDeCreditos
                .Where(a => a.FechaPago == fechaActual)
                .AsNoTracking()
                .ToList();
        }
                
    }
}