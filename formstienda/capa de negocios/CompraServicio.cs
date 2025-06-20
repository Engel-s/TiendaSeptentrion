using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using formstienda.Datos;
using Microsoft.EntityFrameworkCore;

namespace formstienda.capa_de_negocios
{
    internal class CompraServicio
    {
        public List <Compra> ListarCompra()
        {
            try
            {
                using (var context = new DbTiendaSeptentrionContext())
                {
                    return context.Compras.ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Compra>();
            }
        }

       public bool AgregarCompra(Compra compras)
        {
            if (compras == null) 
            {
                Console.WriteLine("La compra no puede ser nula");
                return false;
            }

            try
            {
                using (var context = new DbTiendaSeptentrionContext())
                {
                    context.Compras.Add(compras);
                    context.SaveChanges();
                    return true;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public void ActualizarTotalCompra(int idCompra, float total)
        {
            using (var context = new DbTiendaSeptentrionContext())
            {
                var compra = context.Compras.FirstOrDefault(c => c.IdCompra == idCompra);
                if (compra != null)
                {
                    compra.TotalCompra = total;
                    context.SaveChanges();
                }
            }
        }

        public int ObtenerUltimoIdCompra()
        {
            using (var context = new DbTiendaSeptentrionContext())
            {
                if (context.Compras.Any())
                {
                    return context.Compras.Max(c => c.IdCompra);
                }
                else
                {
                    return 0;
                }
            }
        }

        public void EliminarCompra(int idCompra)
        {
            using (var context = new DbTiendaSeptentrionContext())
            {
                var compra = context.Compras.FirstOrDefault(c => c.IdCompra == idCompra);
                if (compra != null)
                {
                    context.Compras.Remove(compra);
                    context.SaveChanges();
                }
            }
        }


    }
}
