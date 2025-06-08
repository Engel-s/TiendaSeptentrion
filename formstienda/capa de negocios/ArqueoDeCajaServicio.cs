using formstienda.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static formstienda.Login;

namespace formstienda.capa_de_negocios
{
    internal class ArqueoDeCajaServicio
    {
        
        private readonly DbTiendaSeptentrionContext _contexto;

        public ArqueoDeCajaServicio(DbTiendaSeptentrionContext contexto)
        {
            _contexto = contexto ?? throw new ArgumentNullException(nameof(contexto));
        }

        public float ObtenerTotalVentasDelDia()
        {
            DateOnly fechaActual = DateOnly.FromDateTime(DateTime.Today);

            float totalVentas = _contexto.Venta
                .Where(v => v.FechaVenta == fechaActual && v.TipoPago == "Contado")
                .Sum(v => v.TotalVenta);

            return totalVentas;
        }

        public void ActualizarArqueoCaja(float totalEfectivoCordoba, float totalEfectivoDolar,float? faltanteCordoba, float? faltanteDolar,float? sobranteCordoba, float? sobranteDolar)
        {
            
            int? idUsuarioActivo = Login.UsuarioActivo.ObtenerIdUsuario();
            if (!idUsuarioActivo.HasValue)
                throw new InvalidOperationException("Usuario no autenticado");

            
            if (totalEfectivoCordoba < 0 || totalEfectivoDolar < 0)
                throw new ArgumentException("Los totales no pueden ser negativos");

            var arqueo = _contexto.ArqueoCajas
                .FirstOrDefault(a => a.IdUsuario == idUsuarioActivo &&
                                   a.FechaArqueo.Date == DateTime.Today);

            if (arqueo == null)
            {
                arqueo = new ArqueoCaja
                {
                    IdUsuario = idUsuarioActivo.Value,
                    IdApertura = 1,
                    FechaArqueo = DateTime.Now
                };
                _contexto.ArqueoCajas.Add(arqueo);
            }
            else
            {
                arqueo.FechaArqueo = DateTime.Now;
            }

            arqueo.TotalEfectivoCordoba = totalEfectivoCordoba;
            arqueo.TotalEfectivoDolar = totalEfectivoDolar;
            arqueo.FaltanteCordoba = faltanteCordoba >= 0 ? faltanteCordoba : null;
            arqueo.FaltanteDolar = faltanteDolar >= 0 ? faltanteDolar : null;
            arqueo.SobranteCordoba = sobranteCordoba >= 0 ? sobranteCordoba : null;
            arqueo.SobranteDolar = sobranteDolar >= 0 ? sobranteDolar : null;
                        
            var apertura = _contexto.AperturaCajas.Find(arqueo.IdApertura);
            if (apertura != null)
            {
                apertura.EstadoApertura = "Cerrada";
            }

            _contexto.SaveChanges();
        }

        public string ObtenerNombreUsuario()
        {
            int? idUsuarioActivo = Login.UsuarioActivo.ObtenerIdUsuario();
            if (!idUsuarioActivo.HasValue)
                throw new InvalidOperationException("Usuario no autenticado");

            var usuario = _contexto.Usuarios
                .FirstOrDefault(u => u.IdUsuario == idUsuarioActivo.Value);

            if (usuario == null)
                throw new InvalidOperationException("Usuario no encontrado en la base de datos");

            return $"{usuario.NombreUsuario} {usuario.ApellidoUsuario}";
        }

    }
}
