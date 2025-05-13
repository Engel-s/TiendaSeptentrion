using formstienda.Datos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace formstienda.capa_de_negocios
{
    public class VentaServicio
    {
        public bool AgregarVentaConDetalles(Ventum venta, List<DetalleDeVentum> detalles)
        {
            try
            {
                using (var context = new DbTiendaSeptentrionContext())
                {
                    // Agregar la venta
                    context.Venta.Add(venta);
                    context.SaveChanges(); // Para obtener el IdVenta generado

                    // Asignar IdVenta a los detalles y agregarlos
                    foreach (var detalle in detalles)
                    {
                        detalle.IdVenta = venta.IdVenta;
                        context.DetalleDeVenta.Add(detalle);

                        // Buscar producto y restar stock
                        var producto = context.Productos.FirstOrDefault(p => p.CodigoProducto == detalle.CodigoProducto);
                        if (producto != null)
                        {
                            if (producto.StockActual >= detalle.Cantidad)
                            {
                                producto.StockActual -= detalle.Cantidad;
                            }
                            else
                            {
                                // Cancelar operación si el stock es insuficiente
                                MessageBox.Show($"Stock insuficiente para el producto {producto.ModeloProducto}.", "Error de stock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return false;
                            }
                        }
                    }

                    context.SaveChanges(); // Guardar detalles y actualizar stock
                    MessageBox.Show("Factura registrada correctamente.");
                    return true;
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    MessageBox.Show($"Error interno: {ex.InnerException.Message}", "Error Interno", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show($"Error general: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return false;
            }
        }

        public int ObtenerUltimoIdVenta()
        {
            using (var _context = new DbTiendaSeptentrionContext())
            {
                if (_context.Venta.Any())
                {
                    return _context.Venta.Max(v => v.IdVenta);
                }
                else
                {
                    return 0; // si no hay ventas aún
                }
            }
        }


    }

}
