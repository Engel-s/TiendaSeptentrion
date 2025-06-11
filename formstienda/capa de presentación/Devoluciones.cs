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

            // 🚫 Validación: impedir devolución si el cliente es 'Generico'
            if (venta.CedulaCliente?.Trim().Equals("Generico", StringComparison.OrdinalIgnoreCase) == true)
            {
                MessageBox.Show("No se pueden procesar devoluciones de facturas al contado con cliente 'Genérico'.", "Devolución no permitida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            txtnombrecliente.Text = venta.CedulaClienteNavigation?.NombreCliente ?? "N/A";
            txttelefonodelcliente.Text = venta.CedulaClienteNavigation?.TelefonoCliente ?? "N/A";

            // Limpiar y configurar el DataGridView
            DGDETALLESDEVENTA.Rows.Clear();
            DGDETALLESDEVENTA.Columns.Clear();
            ConfigurarColumnasDevolucion();

            foreach (var detalle in venta.DetalleDeVenta)
            {
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
                    0
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

                // Acumulador para evitar devoluciones duplicadas
                Dictionary<int, int> acumuladorPorDetalle = new();

                foreach (DataGridViewRow fila in DGDETALLESDEVENTA.Rows)
                {
                    int idDetalle = Convert.ToInt32(fila.Cells["IdDetalleVenta"].Value);
                    int cantidadVendida = Convert.ToInt32(fila.Cells["CantidadVendida"].Value);
                    int cantidadDevuelta = Convert.ToInt32(fila.Cells["CantidadDevuelta"].Value);

                    if (cantidadDevuelta <= 0) continue;

                    if (!acumuladorPorDetalle.ContainsKey(idDetalle))
                        acumuladorPorDetalle[idDetalle] = 0;

                    acumuladorPorDetalle[idDetalle] += cantidadDevuelta;

                    if (acumuladorPorDetalle[idDetalle] > cantidadVendida)
                    {
                        MessageBox.Show("La cantidad devuelta total de un producto excede la cantidad vendida.");
                        return;
                    }
                }

                // En caso de facturación errónea, preguntamos si se desea reembolsar o cambiar producto
                bool hacerReembolso = true;
                if (motivo == "Facturación errónea")
                {
                    var resultado = MessageBox.Show("¿El cliente desea reembolso de dinero?\nPresione 'Sí' para reembolso o 'No' para cambio de producto.",
                                                    "Opciones de devolución",
                                                    MessageBoxButtons.YesNoCancel,
                                                    MessageBoxIcon.Question);

                    if (resultado == DialogResult.Cancel)
                        return;

                    hacerReembolso = (resultado == DialogResult.Yes);
                }

                foreach (DataGridViewRow fila in DGDETALLESDEVENTA.Rows)
                {
                    int idDetalle = Convert.ToInt32(fila.Cells["IdDetalleVenta"].Value);
                    int cantidadVendida = Convert.ToInt32(fila.Cells["CantidadVendida"].Value);
                    int cantidadDevuelta = Convert.ToInt32(fila.Cells["CantidadDevuelta"].Value);
                    float precio = Convert.ToSingle(fila.Cells["Precio"].Value);

                    if (cantidadDevuelta <= 0) continue;

                    var detalle = venta.DetalleDeVenta.FirstOrDefault(d => d.IdDetalleVenta == idDetalle);
                    if (detalle == null) continue;

                    float montoDevolucion = cantidadDevuelta * precio;
                    totalMontoDevolucion += montoDevolucion;

                    detalle.Cantidad -= cantidadDevuelta;
                    if (detalle.Cantidad < 0) detalle.Cantidad = 0;

                    var producto = detalle.CodigoProductoNavigation;

                    if (motivo == "Facturación errónea")
                    {
                        if (hacerReembolso)
                        {
                            producto.StockActual += cantidadDevuelta; // reembolsa y regresa stock
                        }
                        else
                        {
                            MessageBox.Show("Producto devuelto para cambio. Genere nueva venta con el producto de cambio.", "Cambio pendiente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            // Aquí podrías abrir un formulario de cambio de producto si decides implementarlo
                        }
                    }
                    else if (motivo == "Defecto de fábrica" || motivo == "Garantía")
                    {
                        if (producto.StockActual < cantidadDevuelta)
                        {
                            MessageBox.Show($"Stock insuficiente para registrar salida del producto '{producto.ModeloProducto}'.\nStock actual: {producto.StockActual}, intentado devolver: {cantidadDevuelta}");
                            return;
                        }

                        producto.StockActual -= cantidadDevuelta;
                        if (producto.StockActual < 0) producto.StockActual = 0;

                        var salida = new OtrasSalidasDeInventario
                        {
                            CodigoProducto = detalle.CodigoProducto,
                            CantidadSalir = cantidadDevuelta,
                            MotivoSalida = motivo,
                            DescripcionSalida = descripcion,
                            FechaSalida = DateOnly.FromDateTime(DateTime.Now)
                        };
                        contexto.OtrasSalidasDeInventarios.Add(salida);
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
                    contexto.SaveChanges(); // Necesario para obtener el ID generado

                    var detalleDevolucion = new DetalleDevolucion
                    {
                        IdDevolucion = devolucion.IdDevolucion,
                        InformacionProducto = detalle.CodigoProducto,
                        CantidadDevuelta = cantidadDevuelta,
                        MontoDevuelto = Convert.ToDecimal(montoDevolucion),
                        FechaDevolucion = DateOnly.FromDateTime(DateTime.Now)
                    };
                    contexto.DetalleDevolucions.Add(detalleDevolucion);
                }

                // Egreso en caja si aplica
                // Egreso en caja si aplica
                if (totalMontoDevolucion < 2000 && (motivo == "Facturación errónea" && hacerReembolso || motivo == "Garantía" || motivo == "Defecto de fábrica"))
                {
                    var fechaHoy = DateOnly.FromDateTime(DateTime.Now);
                    var aperturaHoy = contexto.AperturaCajas.FirstOrDefault(a => a.FechaApertura == fechaHoy);
                    if (aperturaHoy == null)
                    {
                        MessageBox.Show("No se encontró una apertura de caja para hoy.");
                        return;
                    }

                    var arqueoHoy = contexto.ArqueoCajas.FirstOrDefault(a => a.IdApertura == aperturaHoy.IdApertura &&
                                                                             DateOnly.FromDateTime(a.FechaArqueo) == fechaHoy);
                    if (arqueoHoy == null)
                    {
                        MessageBox.Show("No se encontró un arqueo de caja para hoy.");
                        return;
                    }

                    // ✅ Verificar si hay suficiente efectivo en caja
                    if (arqueoHoy.TotalEfectivoCordoba < (double)totalMontoDevolucion)
                    {
                        var respuesta = MessageBox.Show(
                            "No hay suficiente efectivo en caja para realizar el reembolso.\n" +
                            $"Total en caja: C${arqueoHoy.TotalEfectivoCordoba:N2}, requerido: C${totalMontoDevolucion:N2}.\n\n" +
                            "¿Desea respaldar el reembolso con inventario en lugar de efectivo?",
                            "Caja insuficiente", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (respuesta == DialogResult.No)
                        {
                            MessageBox.Show("Proceso cancelado. No se realizó la devolución.", "Cancelado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        // 🔄 Respaldo con inventario
                        foreach (DataGridViewRow fila in DGDETALLESDEVENTA.Rows)
                        {
                            int cantidadDevuelta = Convert.ToInt32(fila.Cells["CantidadDevuelta"].Value);
                            if (cantidadDevuelta <= 0) continue;

                            int idDetalle = Convert.ToInt32(fila.Cells["IdDetalleVenta"].Value);
                            var detalle = venta.DetalleDeVenta.FirstOrDefault(d => d.IdDetalleVenta == idDetalle);
                            if (detalle == null) continue;

                            var producto = detalle.CodigoProductoNavigation;

                            producto.StockActual += cantidadDevuelta;

                            var ingresoInventario = new OtrasSalidasDeInventario
                            {
                                CodigoProducto = producto.CodigoProducto,
                                CantidadSalir = cantidadDevuelta,
                                FechaSalida = DateOnly.FromDateTime(DateTime.Now),
                                MotivoSalida = "Respaldo de reembolso sin efectivo disponible",
                               
                            };

                            contexto.OtrasSalidasDeInventarios.Add(ingresoInventario);
                        }

                        MessageBox.Show("Reembolso respaldado con ingreso a inventario.", "Respaldo aplicado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        // 💵 Hacer egreso normal
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


                // Ajustar total venta
                venta.TotalVenta -= totalMontoDevolucion;
                if (venta.TotalVenta < 0) venta.TotalVenta = 0;
                venta.CambiosFactura = "Venta afectada por devoluciones";

                contexto.SaveChanges();
            }

            txtmontodevolucion.Text = totalMontoDevolucion.ToString("N2");
            MessageBox.Show($"Devolución procesada con éxito.\nTotal devuelto: C${totalMontoDevolucion:N2}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
