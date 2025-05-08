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
    }
}
