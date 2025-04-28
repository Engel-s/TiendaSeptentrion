using formstienda.Datos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace formstienda.capa_de_negocios
{
    public class CategoriaServicio
    {
        // Listar todas las categorías
        // Listar todas las categorías (proyectando sólo lo necesario)
        public List<object> ListarCategorias()
        {
            try
            {
                using (var _context = new DbTiendaSeptentrionContext())
                {
                    return _context.Categoria
                        .AsNoTracking()
                        .OrderBy(c => c.IdCategoria)  // Orden ASC por ID
                        .Select(c => new
                        {
                            IdCategoria = c.IdCategoria,
                            Categoria = c.Categoria
                        })
                        .ToList<object>(); // Lista de objetos anónimos
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Error al listar categorías: " + ex.Message);
                return new List<object>();
            }
        }

        // Actualizar categoría
        public bool ActualizarCategoria(int idCategoria, string nuevoNombre)
        {
            if (string.IsNullOrWhiteSpace(nuevoNombre))
            {
                MessageBox.Show("El nombre de la categoría no puede estar vacío");
                return false;
            }

            try
            {
                using (var _context = new DbTiendaSeptentrionContext())
                {
                    var categoria = _context.Categoria.Find(idCategoria);
                    if (categoria == null)
                    {
                        MessageBox.Show("Categoría no encontrada");
                        return false;
                    }

                    // Verificar si ya existe otra categoría con el mismo nombre
                    var existe = _context.Categoria
                        .Any(c => c.IdCategoria != idCategoria && c.Categoria.ToLower() == nuevoNombre.ToLower());
                    if (existe)
                    {
                        MessageBox.Show("Ya existe otra categoría con este nombre");
                        return false;
                    }

                    categoria.Categoria = nuevoNombre;
                    _context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Error al actualizar categoría: " + ex.Message);
                return false;
            }
        }


        // Agregar nueva categoría
        public bool AgregarCategoria(string nombreCategoria)
        {
            if (string.IsNullOrWhiteSpace(nombreCategoria))
            {
                MessageBox.Show("El nombre de la categoría no puede estar vacío");
                return false;
            }

            try
            {
                using (var _context = new DbTiendaSeptentrionContext())
                {
                    // Verificar si ya existe
                    var existe = _context.Categoria.Any(c => c.Categoria.ToLower() == nombreCategoria.ToLower());
                    if (existe)
                    {
                        MessageBox.Show("Ya existe una categoría con este nombre");
                        return false;
                    }

                    var nuevaCategoria = new Categorium
                    {
                        Categoria = nombreCategoria
                    };

                    _context.Categoria.Add(nuevaCategoria);
                    _context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Error al agregar categoría: " + ex.Message);
                return false;
            }
        }
    }
}