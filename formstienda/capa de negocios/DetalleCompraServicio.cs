using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using formstienda.Datos;
using Microsoft.EntityFrameworkCore;

namespace formstienda.capa_de_negocios
{
    internal class DetalleCompraServicio
    {
        public List<DetalleCompra> ListarDetalleCompra()
        {
            try
            {
                using (var context = new DbTiendaSeptentrionContext())
                {
                    return context.DetalleCompras.ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<DetalleCompra>();
            }
        }


        public bool AgregarDetalleCompra(DetalleCompra detallecompra)
        {
            using (var context = new DbTiendaSeptentrionContext())
            {
                var detalle = context.DetalleCompras.Add(detallecompra);
                context.SaveChanges();

                return detalle != null ? false : true; 
            }


        }

        public void EliminarDetallesPorIdCompra(int idCompra)
        {
            using (var context = new DbTiendaSeptentrionContext())
            {
                var detalles = context.DetalleCompras.Where(dc => dc.IdCompra == idCompra).ToList();
                context.DetalleCompras.RemoveRange(detalles);
                context.SaveChanges();
            }
        }


    }
}
