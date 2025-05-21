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

        public void CargarProducto()
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

        // Para calcular el ingreso total (la suma de la columna "Total")
        private void btnCalcularIngreso_Click(object sender, EventArgs e)
        {
            decimal ingresoTotal = 0;

            foreach (DataGridViewRow row in Tabla_Credito.Rows)
            {
                if (row.Cells["Total"].Value != null)
                {
                    decimal valor;
                    if (decimal.TryParse(row.Cells["Total"].Value.ToString(), out valor))
                    {
                        ingresoTotal += valor;
                    }
                }
            }

            MessageBox.Show("Ingreso total sobre el crédito: " + ingresoTotal.ToString("C"));
        }

        private void txtCordobas_TextChanged(object sender, EventArgs e)
        {

            if (!string.IsNullOrWhiteSpace(txtCordobas.Text))
            {
                txtDolares.Text = string.Empty;
            }
        }

        private void txtDolares_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtDolares.Text))
            {
                txtCordobas.Text = string.Empty;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            using (var db = new DbTiendaSeptentrionContext())
            {
                // Suponiendo que tienes el Id del crédito seleccionado
                int idCredito = int.Parse(Tabla_Credito.Text); // O como obtengas el Id
                var credito = db.DetalleDeVenta.FirstOrDefault(c => c.IdVenta == idCredito);

                if (Tabla_Credito != null)
                {
                    decimal abono = 0;
                    string moneda = "0";

                    if (!string.IsNullOrWhiteSpace(txtCordobas.Text))
                    {
                        abono = decimal.Parse(txtCordobas.Text);
                        moneda = "Cordoba";
                    }
                    else if (!string.IsNullOrWhiteSpace(txtDolares.Text))
                    {
                        abono = decimal.Parse(txtDolares.Text);
                        moneda = "Dolares";
                    }

                    // Actualiza el saldo
                  //  Tabla_Credito.abono = abono;
                    /// Tabla_Credito.Moneda = moneda; // Opcional, si manejas la moneda

                    db.SaveChanges();

                    MessageBox.Show("Pago registrado y saldo actualizado.");
                }
                else
                {
                    MessageBox.Show("Crédito no encontrado.");
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtDolares.Enabled = true;
                txtCordobas.Enabled = false;
            }
            else
            {
                txtDolares.Enabled = false;
                txtCordobas.Enabled = true;
            }
        }
    }
}
