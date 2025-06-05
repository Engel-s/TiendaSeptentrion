using formstienda.capa_de_negocios;
using formstienda.Datos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static formstienda.Login;

namespace formstienda
{
    public partial class Devoluciones : Form
    {
        public Devoluciones()
        {
            InitializeComponent();
            DGDETALLESDEVENTA.CellEndEdit += DGDETALLESDEVENTA_CellEndEdit;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            DGDETALLESDEVENTA.CellEndEdit += DGDETALLESDEVENTA_CellEndEdit;
            ConfigurarColumnasDevolucion();
            btnanularfactura.Visible = false;
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtbusquedafactura.Text, out int idVenta))
            {
                MessageBox.Show("Ingrese un ID de factura válido.");
                return;
            }

            var servicio = new DevolucionServicio();
            var venta = servicio.ObtenerVentaContadoPorId(idVenta);

            if (venta == null)
            {
                MessageBox.Show("No se encontró la factura o no es de tipo 'Contado'.");
                return;
            }

            txtnombrecliente.Text = venta.CedulaClienteNavigation?.NombreCliente ?? "N/A";
            txttelefonodelcliente.Text = venta.CedulaClienteNavigation?.TelefonoCliente ?? "N/A";

            // Limpiar y configurar el DataGridView
            DGDETALLESDEVENTA.Rows.Clear();
            DGDETALLESDEVENTA.Columns.Clear();
            ConfigurarColumnasDevolucion(); // Este método configura las columnas si aún no existen

            foreach (var detalle in venta.DetalleDeVenta)
            {
                // Validar navegación antes de usar
                var modeloProducto = detalle.CodigoProductoNavigation?.ModeloProducto ?? "Desconocido";

                float precio = float.TryParse(detalle.Precio, out float p) ? p : 0f;
                int cantidadVendida = detalle.Cantidad;
                float subtotal = precio * cantidadVendida;

                DGDETALLESDEVENTA.Rows.Add(
                    detalle.IdDetalleVenta,
                    detalle.CodigoProducto,
                    modeloProducto,
                    precio,
                    cantidadVendida,
                    subtotal,
                    0 // CantidadDevuelta (editable por el usuario)
                );
            }
            // Asociar el evento solo una vez
        }

    
        private void label6_Click_1(object sender, EventArgs e)
        {

        }
        private readonly string[] motivosValidos = { "Defecto de fábrica", "Facturación errónea", "Garantía" };
        private void btnconfirmardevolucion_Click_1(object sender, EventArgs e)
        {
            if (DGDETALLESDEVENTA.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para procesar.");
                return;
            }

            if (CBMOTIVO.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un motivo de devolución.");
                return;
            }

            string motivo = CBMOTIVO.SelectedItem.ToString();
            if (!motivosValidos.Contains(motivo))
            {
                MessageBox.Show("Motivo de devolución inválido.");
                return;
            }

            string descripcion = txtdescripcion.Text.Trim();
            if (string.IsNullOrWhiteSpace(descripcion))
            {
                MessageBox.Show("Debe ingresar una descripción para la devolución.");
                return;
            }

            if (!int.TryParse(txtbusquedafactura.Text, out int idVenta))
            {
                MessageBox.Show("ID de factura inválido.");
                return;
            }

            float totalMontoDevolucion = 0;

            using (var contexto = new DbTiendaSeptentrionContext())
            {
                var venta = contexto.Venta
                    .Include(v => v.DetalleDeVenta)
                    .ThenInclude(d => d.CodigoProductoNavigation)
                    .FirstOrDefault(v => v.IdVenta == idVenta);

                if (venta == null)
                {
                    MessageBox.Show("Venta no encontrada.");
                    return;
                }

                string cedulaCliente = venta.CedulaCliente;

                foreach (DataGridViewRow fila in DGDETALLESDEVENTA.Rows)
                {
                    int idDetalle = Convert.ToInt32(fila.Cells["IdDetalleVenta"].Value);
                    int cantidadVendida = Convert.ToInt32(fila.Cells["CantidadVendida"].Value);
                    int cantidadDevuelta = Convert.ToInt32(fila.Cells["CantidadDevuelta"].Value);
                    float precio = Convert.ToSingle(fila.Cells["Precio"].Value);

                    // Validación cantidad a devolver
                    if (cantidadDevuelta <= 0) continue;

                    if (cantidadVendida == 0)
                    {
                        MessageBox.Show("No se puede devolver más, la cantidad vendida es 0.");
                        return;
                    }

                    if (cantidadDevuelta > cantidadVendida)
                    {
                        MessageBox.Show("Una cantidad devuelta es mayor a la vendida. Corrija y vuelva a intentar.");
                        return;
                    }

                    var detalle = venta.DetalleDeVenta.FirstOrDefault(d => d.IdDetalleVenta == idDetalle);
                    if (detalle == null) continue;

                    float montoDevolucion = cantidadDevuelta * precio;
                    totalMontoDevolucion += montoDevolucion;

                    // Actualizar el detalle
                    detalle.Cantidad -= cantidadDevuelta;
                    if (detalle.Cantidad < 0) detalle.Cantidad = 0;

                    if (motivo == "Facturación errónea")
                    {
                        // Regresa la cantidad devuelta al stock porque fue error de facturación
                        detalle.CodigoProductoNavigation.StockActual += cantidadDevuelta;
                    }
                    else if (motivo == "Defecto de fábrica" || motivo == "Garantía")
                    {
                        // Producto dañado: registra salida especial y resta del stock
                        var salida = new OtrasSalidasDeInventario
                        {
                            CodigoProducto = detalle.CodigoProducto,
                            CantidadSalir = cantidadDevuelta,
                            MotivoSalida = motivo,
                            DescripcionSalida = descripcion
                        };
                        contexto.OtrasSalidasDeInventarios.Add(salida);

                        detalle.CodigoProductoNavigation.StockActual -= cantidadDevuelta;
                        if (detalle.CodigoProductoNavigation.StockActual < 0)
                            detalle.CodigoProductoNavigation.StockActual = 0;
                    }

                    // Registrar devolución
                    var devolucion = new DevolucionVenta
                    {
                        IdVenta = idVenta,
                        CedulaCliente = cedulaCliente,
                        MotivoDevolucion = motivo,
                        DescripcionDevolucion = descripcion,
                        FechaDevolucion = DateOnly.FromDateTime(DateTime.Now)

                    };
                    contexto.DevolucionVentas.Add(devolucion);
                    var detalledevolucion = new DetalleDevolucion
                    {
                        IdDetalleDevolucion = idDetalle,
                        InformacionProducto = detalle.CodigoProducto,
                        CantidadDevuelta=cantidadDevuelta,
                        MontoDevuelto=Convert.ToDecimal(montoDevolucion),
                    };
                
                    decimal montoTotalCordoba = (decimal)totalMontoDevolucion;

                    // Registrar egreso por la devolución SOLO si el monto es menor a 2000
                    if (totalMontoDevolucion < 2000)
                    {
                        var fechaHoy = DateOnly.FromDateTime(DateTime.Now);

                        var aperturaHoy = contexto.AperturaCajas
                            .FirstOrDefault(a => a.FechaApertura == fechaHoy);

                        if (aperturaHoy == null)
                        {
                            MessageBox.Show("No se encontró una apertura de caja para hoy.");
                            return;
                        }

                        // Convertimos FechaArqueo (DateTime) a DateOnly para la comparación
                        var arqueoHoy = contexto.ArqueoCajas
                            .FirstOrDefault(a => a.IdApertura == aperturaHoy.IdApertura &&
                                                 DateOnly.FromDateTime(a.FechaArqueo) == fechaHoy);

                        if (arqueoHoy == null)
                        {
                            MessageBox.Show("No se encontró un arqueo de caja para hoy.");
                            return;
                        }


                        var egreso = new Egreso
                        {
                            IdArqueoCaja = arqueoHoy.IdArqueoCaja,
                            IdUsuario = (int)UsuarioActivo.ObtenerIdUsuario(),
                            IdApertura = aperturaHoy.IdApertura,
                            FechaEgreso = fechaHoy,
                            CantidadEgresadaCordoba = (decimal)totalMontoDevolucion,
                            MotivoEgreso = $"Devolución de productos - Venta #{idVenta}",
                            CantidadEgresadaDolar = 0m
                        };
                        contexto.Egresos.Add(egreso);
                    }

                }

                // Ajustar total de la venta
                venta.TotalVenta -= totalMontoDevolucion;
                if (venta.TotalVenta < 0) venta.TotalVenta = 0;

                contexto.SaveChanges();
            }

            txtmontodevolucion.Text = totalMontoDevolucion.ToString("N2");
            MessageBox.Show($"Devolución procesada con éxito. Monto total: C${totalMontoDevolucion:N2}");

            LimpiarFormularioDevolucion();

        }
        public class DevolucionTemporal
        {
            public int IdDetalleVenta { get; set; }
            public string CodigoProducto { get; set; }
            public string NombreProducto { get; set; }
            public float Precio { get; set; }
            public int CantidadVendida { get; set; }
            public int CantidadDevuelta { get; set; }
            public float Subtotal => Precio * CantidadVendida;
            public float MontoDevolucion => Precio * CantidadDevuelta;
        }
        private void ConfigurarColumnasDevolucion()
        {
            DGDETALLESDEVENTA.Columns.Add("IdDetalleVenta", "ID Detalle");
            DGDETALLESDEVENTA.Columns["IdDetalleVenta"].Visible = false;

            DGDETALLESDEVENTA.Columns.Add("CodigoProducto", "Código");
            DGDETALLESDEVENTA.Columns.Add("ModeloProducto", "Producto");

            DGDETALLESDEVENTA.Columns.Add("Precio", "Precio (C$)");
            DGDETALLESDEVENTA.Columns.Add("CantidadVendida", "Cantidad Vendida");
            DGDETALLESDEVENTA.Columns.Add("Subtotal", "Subtotal (C$)");

            var colCantidadDevuelta = new DataGridViewTextBoxColumn
            {
                Name = "CantidadDevuelta",
                HeaderText = "Cantidad a Devolver",
                ValueType = typeof(int)
            };
            DGDETALLESDEVENTA.Columns.Add(colCantidadDevuelta);
        }

        private void LimpiarFormularioDevolucion()
        {
            txtbusquedafactura.Clear();
            txtnombrecliente.Clear();
            txttelefonodelcliente.Clear();
            txtdescripcion.Clear();
            CBMOTIVO.SelectedIndex = -1;
            DGDETALLESDEVENTA.Rows.Clear();
            DGDETALLESDEVENTA.Columns.Clear();
        }

        private void DGDETALLESDEVENTA_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (DGDETALLESDEVENTA.Columns[e.ColumnIndex].Name == "CantidadDevuelta")
            {
                var fila = DGDETALLESDEVENTA.Rows[e.RowIndex];
                int cantidadVendida = Convert.ToInt32(fila.Cells["CantidadVendida"].Value);
                int cantidadDevuelta = 0;

                if (!int.TryParse(fila.Cells["CantidadDevuelta"].Value?.ToString(), out cantidadDevuelta) || cantidadDevuelta < 0)
                {
                    MessageBox.Show("Ingrese un número válido para la cantidad devuelta.");
                    fila.Cells["CantidadDevuelta"].Value = 0;
                    return;
                }

                if (cantidadDevuelta > cantidadVendida)
                {
                    MessageBox.Show("La cantidad devuelta no puede ser mayor a la vendida.");
                    fila.Cells["CantidadDevuelta"].Value = 0;
                }
            }

        }
        private void CargarDetalleVentaEnGrid(Ventum venta)
        {
            DGDETALLESDEVENTA.Rows.Clear();

            foreach (var detalle in venta.DetalleDeVenta)
            {
                float precio = float.TryParse(detalle.Precio, out float p) ? p : 0f;
                int cantidad = detalle.Cantidad;

                DGDETALLESDEVENTA.Rows.Add(
                    detalle.IdDetalleVenta,
                    detalle.CodigoProducto,
                    detalle.CodigoProductoNavigation.ModeloProducto,
                    precio,
                    cantidad,
                    precio * cantidad,
                    0 // 
                );
            }
        }

    }
}
