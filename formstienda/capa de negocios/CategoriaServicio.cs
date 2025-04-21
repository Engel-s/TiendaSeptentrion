using formstienda.Datos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace formstienda.capa_de_negocios
{
    public class CategoriaServicio
    {
        public List<Categorium> Listacategorias()
        {
            try
            {
                using (var _context = new DbTiendaSeptentrionContext())
                {
                    return _context.Categoria.AsNoTracking().ToList();
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Categorium>();
            }
        }

        //agregar marca
        public bool Agregarcategoria(Categorium categorium)
        {
            if (categorium == null)
            {
                MessageBox.Show("Rellenar los campos correctamente.");
                return false;
            }

            try
            {
                using (var _context = new DbTiendaSeptentrionContext())
                {
                    // Check if the user already exists based on some unique identifier (e.g., CorreoUsuario or NombreUsuario)
                    var categoriaExistente = _context.Categoria.FirstOrDefault(u => u.IdCategoria == categorium.IdCategoria);

                    if (categoriaExistente != null)
                    {
                        MessageBox.Show("La categoria ya existe.");
                        return false;
                    }

                    // If not, add the new user
                    _context.Categoria.Add(categorium);
                    _context.SaveChanges();
                    MessageBox.Show("Categoria agregado correctamente.");
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

                MessageBox.Show(errorMessage, "Error al guardar categoria", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }
        public bool Actualizarcategoria(Categorium categorium)
        {
            try
            {
                using (var _contexto = new DbTiendaSeptentrionContext())
                {
                    var categoriaExistente = _contexto.Categoria.Find(categorium.IdCategoria);
                    if (categoriaExistente == null)
                    {
                        Console.WriteLine($"Error:No se encontro la categoria con ID(categorium.IdCategoria).");
                        return false;

                    }
                    categoriaExistente.Categoria = categorium.Categoria;

                    _contexto.Categoria.Update(categoriaExistente);
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
