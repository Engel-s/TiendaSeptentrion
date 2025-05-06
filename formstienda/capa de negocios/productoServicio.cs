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
                var existeId = _context.Productos.Any(p => p.IdProducto == producto.IdProducto);
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

                if (producto.StockActual < 0 || producto.StockMinimo < 0)
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
            var prod = _context.Productos.FirstOrDefault(p => p.IdProducto == producto.IdProducto);
            if (prod == null)
                return false;

            prod.ModeloProducto = producto.ModeloProducto;
            prod.PrecioVenta = producto.PrecioVenta;
            prod.StockActual = producto.StockActual;
            prod.StockMinimo = producto.StockMinimo;
            prod.EstadoProducto = producto.EstadoProducto;

            try
            {
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar producto: " + ex.Message);
                return false;
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
            return _context.Productos.Any(p => p.CodigoProducto == codigo);
        }

        // Método para liberar recursos del contexto cuando se termine de usar
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
