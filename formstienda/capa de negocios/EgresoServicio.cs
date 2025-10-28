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
                
                var arqueo = ObtenerOCrearArqueoCaja(idApertura, idUsuario.Value);
                                
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
         
        private ArqueoCaja ObtenerOCrearArqueoCaja(int idApertura, int idUsuario)
        {
           
            var arqueo = _contexto.ArqueoCajas
                .FirstOrDefault(a => a.IdApertura == idApertura && a.IdUsuario == idUsuario);

            if (arqueo == null)
            {
                
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

                
                if (arqueo.IdArqueoCaja == 0)
                    throw new Exception("No se pudo crear el arqueo de caja para el usuario");
            }

            return arqueo;
        }

        public decimal ObtenerTotalCajaCordobas(DateOnly fecha)
        {
            // Ventas contado del día (activas) en C$
            var ventasDiaCordobas = ListarTotalVenta(fecha)
                .Where(v => v.PagoCordobas.HasValue);

            decimal totalVentasCordobas = ventasDiaCordobas.Sum(v =>
                (decimal)v.PagoCordobas!.Value - (decimal)(v.CambioVenta ?? 0));

            // Abonos de crédito (tu lógica actual)
            var (totalCordobasCredito, _) = ObtenerTotalesCreditoPorFechaDesdeObservaciones(fecha);

            decimal totalDevolucionesCordobas =
                (from d in _contexto.DetalleDevolucions
                 join dv in _contexto.DevolucionVentas on d.IdDevolucion equals dv.IdDevolucion
                 join v in _contexto.Venta on dv.IdVenta equals v.IdVenta
                 where d.FechaDevolucion == fecha
                       && string.IsNullOrEmpty(d.CambiosDevolucion)  
                       && string.IsNullOrEmpty(v.CambiosFactura)    
                 select (decimal?)d.MontoDevuelto
                ).Sum() ?? 0m;

            // Monto de apertura del día (apertura no cerrada del mismo día)
            decimal montoApertura =
                _contexto.AperturaCajas
                    .Where(a => a.FechaApertura == fecha && a.EstadoApertura != "Cerrada")
                    .OrderByDescending(a => a.IdApertura)
                    .Select(a => (decimal)a.MontoApertura)
                    .FirstOrDefault();

            return montoApertura + totalVentasCordobas + totalCordobasCredito - totalDevolucionesCordobas;
        }


        public decimal ObtenerTotalCajaDolares(DateOnly fecha)
        {
            decimal totalVentasDolares = ListarTotalVenta(fecha)
                .Where(v => v.PagoDolares.HasValue)
                .Sum(v => (decimal)v.PagoDolares!.Value);

            var (_, totalDolaresCredito) = ObtenerTotalesCreditoPorFechaDesdeObservaciones(fecha);

            return totalVentasDolares + totalDolaresCredito;
        }


        public decimal ObtenerTotalBrutoCordobas(DateOnly fecha)
        {
            // Ventas contado del día (activas) en C$
            var ventasDiaCordobas = ListarTotalVenta(fecha)
                .Where(v => v.PagoCordobas.HasValue);

            decimal totalVentasCordobas = ventasDiaCordobas.Sum(v =>
                (decimal)v.PagoCordobas!.Value - (decimal)(v.CambioVenta ?? 0));

            // Abonos de crédito
            var (totalCordobasCredito, _) = ObtenerTotalesCreditoPorFechaDesdeObservaciones(fecha);

            decimal totalDevolucionesCordobas =
                (from d in _contexto.DetalleDevolucions
                 join dv in _contexto.DevolucionVentas on d.IdDevolucion equals dv.IdDevolucion
                 join v in _contexto.Venta on dv.IdVenta equals v.IdVenta
                 where d.FechaDevolucion == fecha
                       && string.IsNullOrEmpty(d.CambiosDevolucion)
                       && string.IsNullOrEmpty(v.CambiosFactura)
                 select (decimal?)d.MontoDevuelto
                ).Sum() ?? 0m;

            // Monto de apertura del día 
            decimal montoApertura =
                _contexto.AperturaCajas
                    .Where(a => a.FechaApertura == fecha && a.EstadoApertura != "Cerrada")
                    .OrderByDescending(a => a.IdApertura)
                    .Select(a => (decimal)a.MontoApertura)
                    .FirstOrDefault();

            return montoApertura + totalVentasCordobas + totalCordobasCredito - totalDevolucionesCordobas;
        }


        public decimal ObtenerTotalBrutoDolares(DateOnly fecha)
        {
            decimal totalVentasDolares = ListarTotalVenta(fecha)
                .Where(v => v.PagoDolares.HasValue)
                .Sum(v => (decimal)v.PagoDolares!.Value);

            var (_, totalDolaresCredito) = ObtenerTotalesCreditoPorFechaDesdeObservaciones(fecha);

            return totalVentasDolares + totalDolaresCredito;
        }



        public (decimal totalCordobas, decimal totalDolares) ObtenerTotalesCreditoPorFechaDesdeObservaciones(DateOnly fecha)
        {
            string fechaFormateada = fecha.ToDateTime(TimeOnly.MinValue).ToString("dd/MM/yyyy");

            var pagosFiltrados = _contexto.DetalleCreditos
                .Where(dc => dc.Observaciones != null &&
                             dc.Observaciones.Contains($"Pago realizado el {fechaFormateada}") &&
                             dc.Observaciones.Contains("Sin tomar en arqueo"))
                .ToList();

            decimal totalCordobasCredito = pagosFiltrados.Sum(dc => (decimal)dc.TotalCordobas);
            decimal totalDolaresCredito = pagosFiltrados.Sum(dc => (decimal)dc.TotalDolares);
            decimal totalCambioCordobas = pagosFiltrados.Sum(dc => (decimal?)(dc.CambioDevuelto) ?? 0m);
        

            totalCordobasCredito -= totalCambioCordobas;
            

            return (totalCordobasCredito, totalDolaresCredito);
        }

        public decimal ObtenerTotalAbonosCordobas(DateOnly fecha)
        {
            var (totalCordobasCredito, _) = ObtenerTotalesCreditoPorFechaDesdeObservaciones(fecha);
            return totalCordobasCredito;
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
            var fechaHoy = DateOnly.FromDateTime(DateTime.Now);

            return _contexto.AperturaCajas
                .Where(a => a.FechaApertura == fechaHoy && a.EstadoApertura == "Abierta")
                .AsNoTracking()
                .ToList();
        }

        public List<Ventum> ListarTotalVenta(DateOnly fechaActual)
        {
            return _contexto.Venta
                .Where(v =>
                    v.FechaVenta == fechaActual &&
                    v.TipoPago == "Contado" &&
                    string.IsNullOrEmpty(v.CambiosFactura)   // no tomada / no afectada
                )
                .AsNoTracking()
                .ToList();
        }


        public float ObtenerCambioVentas(DateOnly fecha)
        {
            var ventas = ListarTotalVenta(fecha);
            float totalCambioDevuelto = ventas.Sum(v => v.CambioVenta ?? 0);

            return totalCambioDevuelto;
        }


        public List<DetalleDevolucion> Listardetallesdevolucion(DateOnly fechaActual)
        {
            return _contexto.DetalleDevolucions
                .Where(d => d.FechaDevolucion == fechaActual
                            && (d.CambiosDevolucion == null || d.CambiosDevolucion.Trim() == ""))
                .AsNoTracking()
                .ToList();
        }

    }
}