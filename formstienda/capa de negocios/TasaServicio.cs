using formstienda.Datos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace formstienda.capa_de_negocios
{
    public class TasaServicio
    {
       
            //listar usuarios
            public List<TasaDeCambio> Listatasacambios()
            {
                try
                {
                    using (var _context = new DbTiendaSeptentrionContext())
                    {
                        // select from * usuarios
                        return _context.TasaDeCambios.AsNoTracking().ToList();
                    }
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return new List<TasaDeCambio>();
                }
            }
        public bool AgregarTasa(TasaDeCambio tasadecambio)
        {
            if (tasadecambio == null)
            {
                MessageBox.Show("Rellenar los campos correctamente.");
                return false;
            }

            try
            {
                using (var _context = new DbTiendaSeptentrionContext())
                {
                
                    _context.TasaDeCambios.Add(tasadecambio);
                    _context.SaveChanges();
                    MessageBox.Show("Tasa de cambio agregada correctamente.");
                    return true;
                }
            }
            catch (Exception ex)
            {
                string errorMessage = ex.Message;

                if (ex.InnerException != null)
                {
                    errorMessage += "\n\nInner Exception:\n" + ex.InnerException.Message;
                }

                MessageBox.Show(errorMessage, "Error al guardar la tasa de cambio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }
        public TasaDeCambio? ObtenerTasaDeHoy()
        {
            try
            {
                using (var _context = new DbTiendaSeptentrionContext())
                {
                    var hoy = DateOnly.FromDateTime(DateTime.Today);
                    return _context.TasaDeCambios
                                   .AsNoTracking()
                                   .FirstOrDefault(t => t.FechaCambio == hoy);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener tasa del día: " + ex.Message);
                return null;
            }
        }

    }
}

