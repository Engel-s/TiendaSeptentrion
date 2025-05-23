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
            // VALIDACIONES INICIALES
            ValidarUsuarioLogueado();
            var idUsuario = ObtenerYValidarIdUsuario();
            ValidarParametrosEgreso(idApertura, fechaEgreso, cantidadCordobas, cantidadDolares, motivo);
            ValidarAperturaExistente(idApertura, fechaEgreso);

            // CREACIÓN DEL EGRESO
            using var transaction = _contexto.Database.BeginTransaction();

            try
            {
                // 1. Obtener o crear el arqueo de caja específico para este usuario
                var arqueo = ObtenerOCrearArqueoCaja(idApertura, idUsuario.Value);

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
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new ApplicationException("Error al crear el egreso: " + ex.Message, ex);
            }
        }

        #region Métodos Privados de Validación

        private void ValidarUsuarioLogueado()
        {
            if (!UsuarioActivo.HayUsuarioLogueado())
            {
                throw new InvalidOperationException("No hay un usuario logueado para registrar el egreso");
            }
        }

        private int? ObtenerYValidarIdUsuario()
        {
            var idUsuario = UsuarioActivo.ObtenerIdUsuario();
            if (!idUsuario.HasValue)
            {
                throw new InvalidOperationException("El usuario logueado no tiene un ID válido");
            }
            return idUsuario;
        }

        private void ValidarParametrosEgreso(int idApertura, DateOnly fechaEgreso, decimal? cantidadCordobas, decimal? cantidadDolares, string motivo)
        {
            if (idApertura < 0)
                throw new ArgumentException("El ID de apertura no es válido");

            if (string.IsNullOrWhiteSpace(motivo))
                throw new ArgumentException("El motivo del egreso no puede estar vacío");

            if (motivo.Length > 255)
                throw new ArgumentException("El motivo no puede exceder los 255 caracteres");

            if (!cantidadCordobas.HasValue && !cantidadDolares.HasValue)
                throw new ArgumentException("Debe especificar al menos un monto en córdobas o dólares");

            if ((cantidadCordobas ?? 0) < 0 || (cantidadDolares ?? 0) < 0)
                throw new ArgumentException("Los montos no pueden ser negativos");

            if ((cantidadCordobas ?? 0) == 0 && (cantidadDolares ?? 0) == 0)
                throw new ArgumentException("Al menos un monto debe ser mayor que cero");

            if (fechaEgreso > DateOnly.FromDateTime(DateTime.Now))
                throw new ArgumentException("La fecha de egreso no puede ser futura");
        }

        private void ValidarAperturaExistente(int idApertura, DateOnly fechaEgreso)
        {
            var apertura = _contexto.AperturaCajas
                .AsNoTracking()
                .FirstOrDefault(a => a.IdApertura == idApertura);

            if (apertura == null)
                throw new ArgumentException("La apertura de caja especificada no existe");

            if (fechaEgreso < apertura.FechaApertura)
                throw new ArgumentException("La fecha de egreso no puede ser anterior a la fecha de apertura");
        }

        #endregion

        #region Métodos Privados de Operación

        private ArqueoCaja ObtenerOCrearArqueoCaja(int idApertura, int idUsuario)
        {
            // Buscar un arqueo existente para esta apertura y este usuario específico
            var arqueo = _contexto.ArqueoCajas
                .FirstOrDefault(a => a.IdApertura == idApertura && a.IdUsuario == idUsuario);

            if (arqueo == null)
            {
                // Si no existe, crear uno nuevo
                arqueo = new ArqueoCaja
                {
                    IdApertura = idApertura,
                    IdUsuario = idUsuario,
                    TotalEfectivoCordoba = 0,
                    TotalEfectivoDolar = 0,
                    FaltanteCordoba = null,
                    FaltanteDolar = null,
                    SobranteCordoba = null,
                    SobranteDolar = null,
                    FechaArqueo = DateTime.Now
                };

                _contexto.ArqueoCajas.Add(arqueo);
                _contexto.SaveChanges();

                // Verificación crítica - asegurar que se creó correctamente
                if (arqueo.IdArqueoCaja == 0)
                    throw new Exception("No se pudo crear el arqueo de caja para el usuario");
            }

            return arqueo;
        }

        #endregion

        #region Métodos de Consulta (se mantienen igual)

        public decimal ObtenerTotalCajaCordobas(DateOnly fecha)
        {
            var apertura = ListarAperturaCaja(fecha).FirstOrDefault();
            decimal montoApertura = (decimal)(apertura?.MontoApertura ?? 0);

            decimal totalVentas = (decimal)ListarTotalVenta(fecha)
                .Where(v => v.PagoCordobas.HasValue)
                .Sum(v => v.PagoCordobas.Value);

            decimal totalCreditos = (decimal)ListarPagosCredito(fecha)
                .Where(p => p.TotalCordobas > 0)
                .Sum(p => p.TotalCordobas);

            decimal totalDevoluciones = (decimal)ListarDevolucion(fecha)
                .Sum(d => d.MontoDevolucion);

            decimal totalEgresos = (decimal)_contexto.Egresos
                .Where(e => e.FechaEgreso == fecha)
                .Sum(e => e.CantidadEgresadaCordoba);

            return montoApertura + totalVentas + totalCreditos - totalDevoluciones - totalEgresos;
        }

        public decimal ObtenerTotalCajaDolares(DateOnly fecha)
        {
            decimal totalVentas = (decimal)ListarTotalVenta(fecha)
                .Where(v => v.PagoDolares.HasValue)
                .Sum(v => v.PagoDolares.Value);

            decimal totalCreditos = (decimal)ListarPagosCredito(fecha)
                .Where(p => p.TotalDolares > 0)
                .Sum(p => p.TotalDolares);

            decimal totalEgresos = (decimal)_contexto.Egresos
                .Where(e => e.FechaEgreso == fecha)
                .Sum(e => e.CantidadEgresadaDolar);

            return totalVentas + totalCreditos - totalEgresos;
        }

        public decimal ObtenerTotalEgresosCordobas(DateOnly fecha)
        {
            return (decimal)_contexto.Egresos
                .Where(e => e.FechaEgreso == fecha)
                .Sum(e => e.CantidadEgresadaCordoba);
        }

        public decimal ObtenerTotalEgresosDolares(DateOnly fecha)
        {
            return (decimal)_contexto.Egresos
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

        public List<DetalleCredito> ListarPagosCredito(DateOnly fechaActual)
        {
            var fechaDateTime = fechaActual.ToDateTime(TimeOnly.MinValue);
            return _contexto.DetalleCreditos
                .Where(a => a.FechaPago.Date == fechaDateTime.Date)
                .AsNoTracking()
                .ToList();
        }

        #endregion
    }
}