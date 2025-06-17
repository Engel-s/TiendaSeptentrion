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
            var apertura = ListarAperturaCaja(fecha).FirstOrDefault();
            decimal montoApertura = (decimal)(apertura?.MontoApertura ?? 0);

            decimal totalVentas = (decimal)ListarTotalVenta(fecha)
                .Where(v => v.PagoCordobas.HasValue)
                .Sum(v => v.PagoCordobas.Value);

            var (_, totalCordobasCredito) = ObtenerTotalesCreditoPorFechaDesdeObservaciones(fecha);

            decimal totalDevoluciones = (decimal)Listardetallesdevolucion(fecha)
                .Sum(d => d.MontoDevuelto);

            decimal totalEgresos = (decimal)_contexto.Egresos
                .Where(e => e.FechaEgreso == fecha)
                .Sum(e => e.CantidadEgresadaCordoba);

            return montoApertura + totalVentas + totalCordobasCredito - totalDevoluciones - totalEgresos;
        }

        public decimal ObtenerTotalCajaDolares(DateOnly fecha)
        {
            // 1. Suma de ventas en dólares
            decimal totalVentas = (decimal)ListarTotalVenta(fecha)
                .Where(v => v.PagoDolares.HasValue)
                .Sum(v => v.PagoDolares.Value);

            // 2. Obtener créditos en dólares
            var (_, totalDolaresCredito) = ObtenerTotalesCreditoPorFechaDesdeObservaciones(fecha);

            // 3. Suma de egresos en dólares
            decimal totalEgresos = (decimal)_contexto.Egresos
                .Where(e => e.FechaEgreso == fecha)
                .Sum(e => e.CantidadEgresadaDolar);

            // Cálculo final: Ventas + Créditos - Egresos
            return totalVentas + totalDolaresCredito - totalEgresos;
        }

        public decimal ObtenerTotalBrutoCordobas(DateOnly fecha)
        {
            // Obtener la lista de ventas para la fecha, filtrando las que no han sido tomadas en arqueo y que tengan PagoCordobas
            var ventasDelDia = ListarTotalVenta(fecha)
                .Where(v => v.PagoCordobas.HasValue && v.CambiosFactura == null);

            decimal totalVentas = ventasDelDia.Sum(v =>
    (decimal)v.PagoCordobas.Value - (decimal)(v.CambioVenta ?? 0));


            // Obtener totales de crédito SOLO "Sin tomar en arqueo"
            var (totalCordobasCredito, _) = ObtenerTotalesCreditoPorFechaDesdeObservaciones(fecha);

            // Suma de devoluciones
            decimal totalDevoluciones = (decimal)Listardetallesdevolucion(fecha)
                .Sum(d => d.MontoDevuelto);

            // Obtener la última apertura abierta
            var ultimaAperturaAbierta = _contexto.AperturaCajas
                .Where(a => a.EstadoApertura == "Abierta")
                .OrderByDescending(a => a.FechaApertura)
                .FirstOrDefault();

            decimal montoApertura = 0;

            if (ultimaAperturaAbierta != null)
            {
                montoApertura = (decimal)ultimaAperturaAbierta.MontoApertura;
            }

            // Total final: monto apertura + ventas + créditos - devoluciones
            return montoApertura + totalVentas + totalCordobasCredito - totalDevoluciones;
        }




        public decimal ObtenerTotalBrutoDolares(DateOnly fecha)
        {
            // Suma de ventas en dólares que no han sido tomadas en arqueo
            decimal totalVentas = (decimal)ListarTotalVenta(fecha)
                .Where(v => v.PagoDolares.HasValue && v.CambiosFactura == null)
                .Sum(v => v.PagoDolares.Value);

            // Obtener los totales de crédito que aún no se han tomado en arqueo
            var (_, totalDolaresCredito) = ObtenerTotalesCreditoPorFechaDesdeObservaciones(fecha);

            // Total final en dólares
            return totalVentas + totalDolaresCredito;
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
                .Where(a => a.FechaVenta == fechaActual && a.TipoPago == "Contado" && a.CambiosFactura == null)
                .AsNoTracking()
                .ToList();
        }
        public float ObtenerTotalVentasDelDia(DateOnly fecha)
        {
            var ventas = ListarTotalVenta(fecha);

            float totalVentas = ventas.Sum(v => v.TotalVenta);
            float totalCambioDevuelto = ventas.Sum(v => v.CambioVenta ?? 0);

            return totalVentas - totalCambioDevuelto;
        }


        public List<DetalleDevolucion> ListarDevolucion(DateOnly fechaActual)
        {
            return _contexto.DetalleDevolucions
                .Where(a => a.FechaDevolucion == fechaActual)
                .AsNoTracking()
                .ToList();
        }

        
        public List<DetalleDevolucion> Listardetallesdevolucion(DateOnly fechaActual)
        {
            return _contexto.DetalleDevolucions
                .Where(d => d.FechaDevolucion == fechaActual)
                .AsNoTracking()
                .ToList();
        }
    }
}