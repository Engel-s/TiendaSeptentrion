using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using formstienda.Datos;

namespace formstienda.capa_de_negocios
{
    public class MarcaServicio
    {
        // Listar todas las marcas
        // Listar todas las marcas ordenadas por IdMarca de menor a mayor (ascendente)
        public List<object> ListarMarcas()
        {
            try
            {
                using (var _context = new DbTiendaSeptentrionContext())
                {
                    return _context.Marcas
                        .AsNoTracking()
                        .OrderBy(m => m.IdMarca) // Orden ASCENDENTE (de menor a mayor)
                        .Select(m => new
                        {
                            IdMarcas = m.IdMarca,
                            Marca = m.Marca1
                        })
                        .ToList<object>(); // devolvemos como lista de objetos anónimos
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Error al listar marcas: " + ex.Message);
                return new List<object>();
            }
        }


        // Agregar nueva marca
        public bool AgregarMarca(string nombreMarca)
        {
            if (string.IsNullOrWhiteSpace(nombreMarca))
            {
                MessageBox.Show("El nombre de la marca no puede estar vacío");
                return false;
            }

            try
            {
                using (var _context = new DbTiendaSeptentrionContext())
                {
                    // Verificar si ya existe
                    var existe = _context.Marcas.Any(m => m.Marca1.ToLower() == nombreMarca.ToLower());
                    if (existe)
                    {
                        MessageBox.Show("Ya existe una marca con este nombre");
                        return false;
                    }

                    var nuevaMarca = new Marca
                    {
                        Marca1 = nombreMarca
                    };

                    _context.Marcas.Add(nuevaMarca);
                    _context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Error al agregar marca: " + ex.Message);
                return false;
            }
        }

        // Eliminar marca
        public bool EliminarMarca(int idMarca)
        {
            try
            {
                using (var _context = new DbTiendaSeptentrionContext())
                {
                    var marca = _context.Marcas
                        .Include(m => m.Productos)
                        .FirstOrDefault(m => m.IdMarca == idMarca);

                    if (marca == null)
                    {
                        MessageBox.Show("Marca no encontrada");
                        return false;
                    }

                    // Verificar si hay productos asociados
                    if (marca.Productos.Any())
                    {
                        MessageBox.Show("No se puede eliminar la marca porque tiene productos asociados");
                        return false;
                    }

                    _context.Marcas.Remove(marca);
                    _context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Error al eliminar marca: " + ex.Message);
                return false;
            }
        }

        // Actualizar marca
        public bool ActualizarMarca(int idMarca, string nuevoNombre)
        {
            if (string.IsNullOrWhiteSpace(nuevoNombre))
            {
                MessageBox.Show("El nombre de la marca no puede estar vacío");
                return false;
            }

            try
            {
                using (var _context = new DbTiendaSeptentrionContext())
                {
                    var marca = _context.Marcas.Find(idMarca);
                    if (marca == null)
                    {
                        MessageBox.Show("Marca no encontrada");
                        return false;
                    }

                    // Verificar si el nuevo nombre ya existe
                    var existe = _context.Marcas
                        .Any(m => m.IdMarca != idMarca &&
                                m.Marca1.ToLower() == nuevoNombre.ToLower());
                    if (existe)
                    {
                        MessageBox.Show("Ya existe otra marca con este nombre");
                        return false;
                    }

                    marca.Marca1 = nuevoNombre;
                    _context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Error al actualizar marca: " + ex.Message);
                return false;
            }
        }
    }
}