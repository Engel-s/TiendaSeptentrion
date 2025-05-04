using formstienda.Datos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace formstienda.capa_de_negocios
{
    public class ProductoServicio
    {
        // Listar todos los productos con información relacionada
        public List<Producto> ListarProductos()
        {
            try
            {
                using (var _context = new DbTiendaSeptentrionContext())
                {
                    return _context.Productos
                        .Include(p => p.IdCategoriaNavigation)
                        .Include(p => p.IdMarcaNavigation)
                        .AsNoTracking()
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Error al listar productos: " + ex.Message);
                return new List<Producto>();
            }
        }

        // Agregar un nuevo producto
        public bool AgregarProducto(Producto producto)
        {
            if (producto == null)
            {
                MessageBox.Show("Rellenar los campos correctamente.");
                return false;
            }

            try
            {
                using (var _context = new DbTiendaSeptentrionContext())
                {
                    // Verificar si ya existe un producto con el mismo ID
                    var existeId = _context.Productos.Any(p => p.IdProducto == producto.IdProducto);
                    if (existeId)
                    {
                        MessageBox.Show("Ya existe un producto con este ID. Por favor, use un ID diferente.");
                        return false;
                    }

                    // Verificar si ya existe un producto con el mismo código
                    if (!string.IsNullOrEmpty(producto.CodigoProducto))
                    {
                        var existeCodigo = _context.Productos.Any(p => p.CodigoProducto == producto.CodigoProducto);
                        if (existeCodigo)
                        {
                            MessageBox.Show("Ya existe un producto con este código.");
                            return false;
                        }
                    }

                    // Verificar si ya existe un producto con el mismo nombre
                    var existeNombre = _context.Productos.Any(p => p.ModeloProducto == producto.ModeloProducto);
                    if (existeNombre)
                    {
                        MessageBox.Show("Ya existe un producto con este nombre.");
                        return false;
                    }

                    // Validar stock mínimo
                    if (producto.StockActual < 0 || producto.StockMinimo < 0)
                    {
                        MessageBox.Show("Los valores de stock no pueden ser negativos.");
                        return false;
                    }

                    // Agregar producto
                    _context.Productos.Add(producto);
                    _context.SaveChanges();

                    return true;
                }
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message.Contains("PRIMARY KEY"))
                {
                    MessageBox.Show("El ID de producto ya existe. Por favor, use un ID diferente.");
                }
                else
                {
                    MessageBox.Show("Error al agregar producto: " + ex.Message);
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Error al agregar producto: " + ex.Message);
                return false;
            }
        }

        // Eliminar un producto
        public bool EliminarProducto(int idProducto)
        {
            try
            {
                using (var _context = new DbTiendaSeptentrionContext())
                {
                    var producto = _context.Productos.Find(idProducto);

                    if (producto == null)
                    {
                        MessageBox.Show("Producto no encontrado");
                        return false;
                    }

                    // Verificar si hay stock antes de eliminar
                    if (producto.StockActual > 0)
                    {
                        MessageBox.Show("No se puede eliminar un producto con existencias en stock");
                        return false;
                    }

                    _context.Productos.Remove(producto);
                    _context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Error al eliminar producto: " + ex.Message);
                return false;
            }
        }

        // Actualizar un producto
        public bool ActualizarProducto(Producto producto)
        {
            if (producto == null)
            {
                MessageBox.Show("Datos del producto inválidos");
                return false;
            }

            try
            {
                using (var _context = new DbTiendaSeptentrionContext())
                {
                    var productoExistente = _context.Productos.Find(producto.IdProducto);
                    if (productoExistente == null)
                    {
                        MessageBox.Show("Producto no encontrado");
                        return false;
                    }

                    // Actualizar propiedades
                    productoExistente.ModeloProducto = producto.ModeloProducto;
                    productoExistente.IdCategoria = producto.IdCategoria;
                    productoExistente.IdMarca = producto.IdMarca;
                    productoExistente.PrecioVenta = producto.PrecioVenta;
                    productoExistente.EstadoProducto = producto.EstadoProducto;
                    productoExistente.StockActual = producto.StockActual;
                    productoExistente.StockMinimo = producto.StockMinimo;
                    productoExistente.CodigoProducto = producto.CodigoProducto;

                    _context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Error al actualizar producto: " + ex.Message);
                return false;
            }
        }

        // Buscar productos por criterios
        public List<Producto> BuscarProductos(string nombre, string marca, string categoria)
        {
            try
            {
                using (var _context = new DbTiendaSeptentrionContext())
                {
                    var query = _context.Productos
                        .Include(p => p.IdCategoriaNavigation)
                        .Include(p => p.IdMarcaNavigation)
                        .AsQueryable();

                    if (!string.IsNullOrEmpty(nombre))
                    {
                        query = query.Where(p => p.ModeloProducto.Contains(nombre));
                    }

                    if (!string.IsNullOrEmpty(marca))
                    {
                        query = query.Where(p => p.IdMarcaNavigation.Marca1.Contains(marca));
                    }

                    if (!string.IsNullOrEmpty(categoria))
                    {
                        query = query.Where(p => p.IdCategoriaNavigation.Categoria.Contains(categoria));
                    }

                    return query.AsNoTracking().ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Error al buscar productos: " + ex.Message);
                return new List<Producto>();
            }
        }

        
    }
}