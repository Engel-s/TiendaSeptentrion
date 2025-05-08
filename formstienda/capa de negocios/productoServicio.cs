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

        public bool ActualizarProducto(Producto producto)
        {
            using (var contexto = new DbTiendaSeptentrionContext())
            {
                var prod = contexto.Productos.FirstOrDefault(p => p.IdProducto == producto.IdProducto);
                if (prod == null)
                {
                    return false;
                }

                // Asignar propiedades individuales
                prod.ModeloProducto = producto.ModeloProducto;
                prod.PrecioVenta = producto.PrecioVenta;
                prod.StockActual = producto.StockActual;
                prod.StockMinimo = producto.StockMinimo;
                //prod.IdMarca = producto.IdMarca;           // <- Aquí estás usando IdMarca (int), no el nombre
                //prod.IdCategoria = producto.IdCategoria;
                prod.EstadoProducto = producto.EstadoProducto;

                try
                {
                    contexto.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    // Opcional: loggear error si lo necesitas
                    Console.WriteLine("Error al actualizar producto: " + ex.Message);
                    return false;
                }
            }
        }


        public Producto ObtenerProductoPorCodigo(string codigo)
        {
            using (var contexto = new DbTiendaSeptentrionContext())
            {
                return contexto.Productos
                    .Include(p => p.IdCategoriaNavigation)
                    .Include(p => p.IdMarcaNavigation)
                    .FirstOrDefault(p => p.CodigoProducto == codigo);
            }
        }

        public int ObtenerIdPorNombreProducto(string nombre) 
        {
            using (var context = new DbTiendaSeptentrionContext())
            {
                var producto = context.Productos
                    .FirstOrDefault(p => p.ModeloProducto == nombre);
                return producto != null ? producto.IdProducto : 0;
            }
        }
    }
}