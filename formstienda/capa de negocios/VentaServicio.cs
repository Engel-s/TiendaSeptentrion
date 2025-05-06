using formstienda.Datos;
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
                    }

                    context.SaveChanges(); // Guardar detalles
                    MessageBox.Show("Factura registrada correctamente.");
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar la factura: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }

}
