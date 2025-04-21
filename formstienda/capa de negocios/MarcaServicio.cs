using formstienda.Datos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace formstienda.capa_de_negocios
{
    public class MarcaServicio
    {
        public List<Marca> Listamarcas()
        {
            try
            {
                using (var _context = new DbTiendaSeptentrionContext())
                {
                    return _context.Marcas.AsNoTracking().ToList();
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Marca>();
            }
        }

        //agregar marca
        public bool Agregarmarca(Marca marca)
        {
            if ( marca == null)
            {
                MessageBox.Show("Rellenar los campos correctamente.");
                return false;
            }

            try
            {
                using (var _context = new DbTiendaSeptentrionContext())
                {
                    // Check if the user already exists based on some unique identifier (e.g., CorreoUsuario or NombreUsuario)
                    var marcaExistente = _context.Marcas.FirstOrDefault(u => u.IdMarca == marca.IdMarca);

                    if (marcaExistente != null)
                    {
                        MessageBox.Show("La marca ya existe.");
                        return false;
                    }

                    // If not, add the new user
                    _context.Marcas.Add(marca);
                    _context.SaveChanges();
                    MessageBox.Show("marca agregado correctamente.");
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

                MessageBox.Show(errorMessage, "Error al guardar marca", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }
        public bool Actualizarmarca(Marca marca)
        {
            try
            {
                using (var _contexto = new DbTiendaSeptentrionContext())
                {
                    var marcaExistente = _contexto.Marcas.Find(marca.IdMarca);
                    if (marcaExistente == null)
                    {
                        Console.WriteLine($"Error:No se encontro la marca con ID(marca.IdMarca).");
                        return false;

                    }
                    marcaExistente.Marca1 = marca.Marca1;
                    
                    _contexto.Marcas.Update(marcaExistente);
                    _contexto.SaveChanges();
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
