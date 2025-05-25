using formstienda.capa_de_negocios;
using formstienda.Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace formstienda
{
    public partial class Devoluciones : Form
    {
        public Devoluciones()
        {
            InitializeComponent();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {


            this.Close();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (DGDETALLESDEVENTA.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una fila del detalle para devolver.");
                return;
            }

            var fila = DGDETALLESDEVENTA.SelectedRows[0];

            string codigoProducto = fila.Cells["CodigoProducto"].Value?.ToString();
            int cantidadVendida = Convert.ToInt32(fila.Cells["Cantidad"].Value);
            int cantidadDevuelta = Convert.ToInt32(fila.Cells["CantidadDevuelta"].Value);
            float precio = Convert.ToSingle(fila.Cells["Precio"].Value);
            int idVenta = int.Parse(txtbusquedafactura.Text); // o donde tengas el ID

            if (cantidadDevuelta <= 0 || cantidadDevuelta > cantidadVendida)
            {
                MessageBox.Show("La cantidad devuelta no es válida.");
                return;
            }

            float montoDevolucion = cantidadDevuelta * precio;

            using (var contexto = new DbTiendaSeptentrionContext())
            {
                var producto = contexto.Productos.FirstOrDefault(p => p.CodigoProducto == codigoProducto);
                var detalle = contexto.DetalleDeVenta
                    .FirstOrDefault(d => d.IdVenta == idVenta && d.CodigoProducto == codigoProducto);

                if (producto == null || detalle == null)
                {
                    MessageBox.Show("Producto o detalle de venta no encontrado.");
                    return;
                }

                // 1️⃣ ACTUALIZAR STOCK
                string motivo = CBMOTIVO.SelectedItem?.ToString() ?? "";
                if (motivo != "Producto dañado") // Solo regresa a stock si NO está dañado
                {
                    producto.StockActual += cantidadDevuelta;
                }

                // 2️⃣ ACTUALIZAR DETALLE DE VENTA
                detalle.Cantidad -= cantidadDevuelta;

                // 3️⃣ GUARDAR DEVOLUCIÓN
                var devolucion = new Devolucion
                {
                    IdVenta = idVenta,
                    CedulaCliente = "4411605051000W", // o el campo correspondiente
                    MotivoDevolucion = motivo,
                    DescripcionDevolucion = txtdescripcion.Text,
                    MontoDevolucion = montoDevolucion,
                    CantidadDevuelta = cantidadDevuelta
                };

                contexto.Devolucions.Add(devolucion);
                contexto.SaveChanges();
            }

            MessageBox.Show($"Devolución registrada. Se regresan C${montoDevolucion:N2} al cliente.");
            //CargarVentaPorId(idVenta); // Vuelve a cargar la venta con los nuevos valores
        }
        

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            int idVenta;

            if (!int.TryParse(txtbusquedafactura.Text, out idVenta))
            {
                MessageBox.Show("Ingrese un ID de factura válido.");
                return;
            }

            // Llama al servicio
            var servicio = new DevolucionServicio(); // Asegúrate que este sea tu servicio donde están los métodos

            var venta = servicio.ObtenerVentaContadoPorId(idVenta);
            if (venta == null)
            {
                MessageBox.Show("No se encontró la factura o no es de tipo 'Contado'.");
                return;
            }

            // Cargar datos del cliente
            if (venta.CedulaClienteNavigation != null)
            {
                txtnombrecliente.Text = venta.CedulaClienteNavigation.NombreCliente; // Ajusta según tu propiedad real
                txttelefonodelcliente.Text = venta.CedulaClienteNavigation.TelefonoCliente;
            }

            // Cargar detalles al DataGridView
            DGDETALLESDEVENTA.Rows.Clear(); // Asegúrate de tener columnas definidas o usa AutoGenerateColumns

            foreach (var detalle in venta.DetalleDeVenta)
            {
                // Obtener el precio como float
                float precio = float.TryParse(detalle.Precio, out float p) ? p : 0f;
                int cantidad = detalle.Cantidad;
                float subtotal = precio * cantidad;

                DGDETALLESDEVENTA.Rows.Add(
                    detalle.CodigoProductoNavigation?.CodigoProducto,
                    detalle.CodigoProductoNavigation?.ModeloProducto,
                    

                    precio.ToString("N2"), // Formato de precio
                    cantidad,
                    subtotal.ToString("N2"),
                    0 // Cantidad devuelta inicial en 0, editable por el usuario después
                );
            }

        }
    }
}
