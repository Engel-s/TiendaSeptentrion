using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using formstienda.Datos;

namespace formstienda.Servicios
{
    public class EgresoServicio
    {
        private readonly DbTiendaSeptentrionContext _contexto;

        public EgresoServicio(DbTiendaSeptentrionContext contexto)
        {
            _contexto = contexto ?? throw new ArgumentNullException(nameof(contexto));
        }

        public bool CrearEgreso(int idApertura, int idUsuario, DateOnly fechaEgreso,decimal? cantidadCordobas, decimal? cantidadDolares, string motivo)
        {
            try
            {
                // Validaciones básicas
                if (idApertura <= 0)
                    throw new ArgumentException("El ID de apertura no es válido");
                               

                if (idUsuario <= 0)
                    throw new ArgumentException("El ID de usuario no es válido");

                if (string.IsNullOrWhiteSpace(motivo))
                    throw new ArgumentException("El motivo del egreso no puede estar vacío");

                if (motivo.Length > 255)
                    throw new ArgumentException("El motivo no puede exceder los 255 caracteres");

                // Validar montos
                if (!cantidadCordobas.HasValue && !cantidadDolares.HasValue)
                    throw new ArgumentException("Debe especificar al menos un monto en córdobas o dólares");

                if ((cantidadCordobas ?? 0) < 0 || (cantidadDolares ?? 0) < 0)
                    throw new ArgumentException("Los montos no pueden ser negativos");

                if ((cantidadCordobas ?? 0) == 0 && (cantidadDolares ?? 0) == 0)
                    throw new ArgumentException("Al menos un monto debe ser mayor que cero");

                // Validar existencia de referencias
                if (!_contexto.AperturaCajas.Any(a => a.IdApertura == idApertura))
                    throw new ArgumentException("La apertura de caja especificada no existe");
                                
                if (!_contexto.Usuarios.Any(u => u.IdUsuario == idUsuario))
                    throw new ArgumentException("El usuario especificado no existe");

                // Crear el egreso
                var egreso = new Egreso
                {
                    IdApertura = idApertura,
                    IdUsuario = idUsuario,
                    FechaEgreso = fechaEgreso,
                    CantidadEgresadaCordoba = cantidadCordobas ?? 0,
                    CantidadEgresadaDolar = cantidadDolares ?? 0,
                    MotivoEgreso = motivo
                };

                _contexto.Egresos.Add(egreso);
                return _contexto.SaveChanges() > 0;
            }
            catch (DbUpdateException ex)
            {
                throw new ApplicationException("Error de base de datos al crear el egreso. Detalles: " + ex.InnerException?.Message, ex);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error al crear el egreso: " + ex.Message, ex);
            }
        }

        public int ObtenerIdUsuarioLogueado(string nombreUsuario)
        {
            // Validación básica del parámetro de entrada
            if (string.IsNullOrWhiteSpace(nombreUsuario))
            {
                throw new ArgumentException("El nombre de usuario no puede estar vacío", nameof(nombreUsuario));
            }

            try
            {
                // Usa los nombres correctos de las propiedades
                var usuario = _contexto.Usuarios
                    .FirstOrDefault(u => u.UsuarioLogueo == nombreUsuario.Trim() && u.EstadoUsuario);

                if (usuario == null)
                {
                    // Mensaje más descriptivo para ayudar en la depuración
                    var usuariosExistentes = _contexto.Usuarios
                        .Where(u => u.EstadoUsuario)
                        .Select(u => u.UsuarioLogueo)
                        .ToList();

                    throw new Exception($"No se encontró un usuario activo con el nombre '{nombreUsuario}'. " +
                                      $"Usuarios activos disponibles: {string.Join(", ", usuariosExistentes)}");
                }

                return usuario.IdUsuario; // Usar IdUsuario en lugar de Id_usuario
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al buscar el usuario en la base de datos: {ex.Message}", ex);
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

        // Métodos adicionales del servicio que ya tenías
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

        public Usuario ObtenerIdUsuarioLogueado(int idUsuario)
        {
            return _contexto.Usuarios
                .FirstOrDefault(u => u.IdUsuario == idUsuario);
        }
                
    }
}