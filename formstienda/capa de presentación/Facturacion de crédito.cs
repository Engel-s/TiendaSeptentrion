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

namespace formstienda.capa_de_presentación
{
    public partial class Facturacion_de_crédito : Form
    {
        public Facturacion_de_crédito()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();

            this.Close();
        }

        private void Facturacion_de_crédito_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Validar que el teléfono sea un número válido (si es int)
            if (!int.TryParse(txtBusqueda.Text.Trim(), out int facturtabuscada))
            {
                MessageBox.Show("Por favor, ingresa un número válido en el campo.");
                return;
            }

            using (var context = new DbTiendaSeptentrionContext())
            {
                var credito = context.PagoDeCreditos.FirstOrDefault(cr => cr.IdVenta == facturtabuscada);
                if (credito != null)
                {
                    // Rellenar campos con datos de la venta encontrado
                    txtCambio.Text = credito.Cambio.ToString();
                    txtCordobas.Text = credito.PagoCordobas.ToString();
                    float? v = credito.PagoCordobas * 37;
                    txtDolares.Text = v.ToString();
                    txtTotalAbonado.Text = credito.TotalAbonado.ToString();
                }
                else
                {
                    MessageBox.Show("No se encontró ningún proveedor con ese teléfono. Puedes ingresar un nuevo proveedor.");
                    // Opcional: limpiar otros campos para que el usuario ingrese datos nuevos
                    txtTotalAbonado.Clear();
                    txtDolares.Clear();
                    txtCordobas.Clear();
                    txtCambio.Clear();
                    txtBusqueda.Clear();
                }
            }

        }

    }
}
