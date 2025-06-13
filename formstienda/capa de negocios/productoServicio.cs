using formstienda.Datos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace formstienda.capa_de_negocios
{
    public class ProductoServicio : IDisposable
    {
        private readonly DbTiendaSeptentrionContext _context;

        public ProductoServicio()
        {
            _context = new DbTiendaSeptentrionContext();
        }

        // Listar todos los productos con información relacionada
        public List<Producto> ListarProductos()
        {
            try
            {
                return _context.Productos
                    .Include(p => p.IdCategoriaNavigation)
                    .Include(p => p.IdMarcaNavigation)
                    .AsNoTracking()
                    .ToList();
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
                var existeId = _context.Productos.Any(p => p.CodigoProducto == producto.CodigoProducto);
                if (existeId)
                {
                    MessageBox.Show("Ya existe un producto con este ID. Por favor, use un ID diferente.");
                    return false;
                }

                if (!string.IsNullOrEmpty(producto.CodigoProducto))
                {
                    var existeCodigo = _context.Productos.Any(p => p.CodigoProducto == producto.CodigoProducto);
                    if (existeCodigo)
                    {
                        MessageBox.Show("Ya existe un producto con este código.");
                        return false;
                    }
                }

                var existeNombre = _context.Productos.Any(p => p.ModeloProducto == producto.ModeloProducto);
                if (existeNombre)
                {
                    MessageBox.Show("Ya existe un producto con este nombre.");
                    return false;
                }

                if (producto.StockMinimo < 0)
                {
                    MessageBox.Show("Los valores de stock no pueden ser negativos.");
                    return false;
                }

                _context.Productos.Add(producto);
                _context.SaveChanges();

                return true;
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Error al agregar producto: " + ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Error al agregar producto: " + ex.Message);
                return false;
            }
        }

        public bool ActualizarProducto(Producto producto)
        {
            using (var contexto = new DbTiendaSeptentrionContext())
            {
                var productoExistente = contexto.Productos.FirstOrDefault(p => p.CodigoProducto == producto.CodigoProducto);
                if (productoExistente == null)
                    return false;

                productoExistente.CodigoProducto = producto.CodigoProducto;
                productoExistente.ModeloProducto = producto.ModeloProducto;
                productoExistente.PrecioVenta = producto.PrecioVenta;
                productoExistente.StockActual = producto.StockActual;
                productoExistente.StockMinimo = producto.StockMinimo;
                productoExistente.EstadoProducto = producto.EstadoProducto;
                productoExistente.IdMarca = producto.IdMarca;
                productoExistente.IdCategoria = producto.IdCategoria;

                contexto.SaveChanges();
                return true;
            }
        }

        public Producto ObtenerProductoPorCodigo(string codigo)
        {
            return _context.Productos
                .Include(p => p.IdCategoriaNavigation)
                .Include(p => p.IdMarcaNavigation)
                .FirstOrDefault(p => p.CodigoProducto == codigo);
        }

        public bool ExisteCodigoProducto(string codigo)
        {
            using (var contexto = new DbTiendaSeptentrionContext())
            {
                return contexto.Productos.Any(p => p.CodigoProducto == codigo);
            }
        }
        public void AumentarStock(string codigoProducto, int cantidad)
        {
            using (var context = new DbTiendaSeptentrionContext())
            {
                try
                {
                    Console.WriteLine($"Buscando producto con código: {codigoProducto}");
                    var producto = context.Productos.FirstOrDefault(p => p.CodigoProducto == codigoProducto);

                    if (producto != null)
                    {
                        Console.WriteLine($"Stock actual antes: {producto.StockActual}");
                        producto.StockActual = (producto.StockActual ?? 0) + cantidad;
                        context.SaveChanges();
                        Console.WriteLine($"Stock actualizado. Nuevo stock: {producto.StockActual}");
                    }
                    else
                    {
                        Console.WriteLine("Producto no encontrado.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al actualizar el stock: {ex.Message}");
                }
            }
        }

        public bool DisminuirStock(string codigoProducto, int cantidad)
        {
            try
            {
                var producto = _context.Productos.FirstOrDefault(p => p.CodigoProducto == codigoProducto);
                if (producto != null)
                {
                    MessageBox.Show($"Disminuyendo stock de {producto.ModeloProducto} - Actual: {producto.StockActual}, Cantidad: {cantidad}");
                    producto.StockActual -= cantidad;
                    if (producto.StockActual < 0)
                        producto.StockActual = 0;

                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en DisminuirStock: " + ex.Message);
                return false;
            }
            /*using (var context = new DbTiendaSeptentrionContext())
            {
                var producto = context.Productos.FirstOrDefault(p => p.CodigoProducto == codigoProducto);
                if (producto != null)
                {
                    producto.StockActual -= cantidad;
                    context.SaveChanges();
                }
            }*/
        }

        public void ActualizarPrecioVenta(string codigoProducto, float nuevoPrecio)
        {
            using (var context = new DbTiendaSeptentrionContext())
            {
                var producto = context.Productos.FirstOrDefault(p => p.CodigoProducto == codigoProducto);
                if (producto != null)
                {
                    producto.PrecioVenta = nuevoPrecio;
                    context.SaveChanges();
                }
            }
        }


        // Método para liberar recursos del contexto cuando se termine de usar
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
