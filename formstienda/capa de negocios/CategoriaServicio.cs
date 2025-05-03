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
        public bool ActualizarCategoria(int id, string nuevoNombre)
        {
            using (var contexto = new DbTiendaSeptentrionContext())
            {
                var categoria = contexto.Categoria.FirstOrDefault(c => c.IdCategoria == id);
                if (categoria != null)
                {
                    categoria.Categoria = nuevoNombre;
                    contexto.SaveChanges();
                    return true;
                }
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

        // En CategoriaServicio
        public Categorium ObtenerCategoriaPorNombre(string nombre)
        {
            using (var context = new DbTiendaSeptentrionContext())
            {
                return context.Categoria.FirstOrDefault(c => c.Categoria == nombre);
            }
        }

    }
}