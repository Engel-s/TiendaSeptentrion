using formstienda.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace formstienda.capa_de_negocios
{
    public class TasaServicio
    {
        public bool IngresarTasa(TasaDeCambio tasaDeCambio)
        {
            if (tasaDeCambio == null)
            {
                MessageBox.Show("Rellenar los campos correctamente.");
                return false;
            }
            try
            {
                using (var _context = new DbTiendaSeptentrionContext())
                {
                    _context.TasaDeCambios.Add(tasaDeCambio);
                    _context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
