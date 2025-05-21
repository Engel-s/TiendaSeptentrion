using formstienda.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using formstienda.Capa_negocios;
using System.Text;
using System.Threading.Tasks;

namespace formstienda.Capa_negocios
{
  internal class CreditoServicio
       {
        public bool AñadirCredito(PagoDeCredito credito)
        {

            using (var contexto = new DbTiendaSeptentrionContext())
            {
                var resultado = contexto.PagoDeCreditos.Add(credito);
                contexto.SaveChanges();
                return resultado == null ? false : true;
            }
        }

        public List<PagoDeCredito> ListarCredito()
        {
            using (var contexto = new DbTiendaSeptentrionContext())
            {
                return contexto.PagoDeCreditos.ToList();
            }
        }

        public int ObtenerIDFActura(int nombreArticulo)
        {
            using (var contexto = new DbTiendaSeptentrionContext())
            {
                var factura = contexto.Venta.FirstOrDefault(a => a.IdVenta == nombreArticulo);
                return factura != null ? factura.IdVenta : 0;
            }
        }

        public bool AgregarPagoCredito(PagoDeCredito articulo)
        {
            using (var contexto = new DbTiendaSeptentrionContext())
            {
                var resultado = contexto.PagoDeCreditos.Add(articulo);
                contexto.SaveChanges();
                return resultado == null ? false : true;
            }
        }
    }
}
       