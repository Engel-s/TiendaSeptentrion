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
        public List<Marca> ListarMarcas()
        {
            try
            {
                using (var _context = new DbTiendaSeptentrionContext())
                {
                    return _context.Marcas
                        .AsNoTracking()
                        .OrderBy(m => m.IdMarca)
                        .ToList(); // Devuelve entidades reales Marca
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Error al listar marcas: " + ex.Message);
                return new List<Marca>();
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

        public bool ActualizarMarca(int id, string nuevoNombre)
        {
            using (var contexto = new DbTiendaSeptentrionContext())
            {
                var marca = contexto.Marcas.FirstOrDefault(m => m.IdMarca == id);
                if (marca != null)
                {
                    marca.Marca1 = nuevoNombre;
                    contexto.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public Marca ObtenerMarcaPorNombre(string nombre)
        {
            using (var context = new DbTiendaSeptentrionContext())
            {
                return context.Marcas.FirstOrDefault(m => m.Marca1 == nombre);
            }
        }                
    }
}