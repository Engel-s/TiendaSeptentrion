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

        private void CalcularClientesCredito()
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void Facturacion_de_crédito_Load(object sender, EventArgs e)
        {

            if (Tabla_Credito.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una factura.");
                return;
            }

            string numeroFactura = Tabla_Credito.CurrentRow.Cells["NumeroFactura"].Value.ToString();
            decimal abono = 0;
            decimal.TryParse(txtTotalAbonado.Text, out abono);

            using (var context = new DbTiendaSeptentrionContext())
            {
                var factura = context.Venta.FirstOrDefault(f => f.IdVenta == int.Parse(numeroFactura));
                var credito = context.DetalleCreditos.FirstOrDefault(d => d.IdDetalleCredito == int.Parse(numeroFactura));
                if (factura == null)
                {
                    MessageBox.Show("Factura no encontrada.");
                    return;
                }

                // Si hay atraso, incrementar interés
                if (DateTime.Now > credito.FechaPago)
                {
                    // Convertir float a decimal para la operación precisa
                    decimal interesDecimal = Convert.ToDecimal(credito.InteresPagado);

                    // Incrementar el interés en 0.03 (3%)
                    interesDecimal += 0.03m;

                    // Convertir de nuevo a float para asignar a la propiedad
                    credito.InteresPagado = (float)interesDecimal;
                }
                decimal abonoCapital = Convert.ToDecimal(credito.AbonoCapital);
                abonoCapital += abono;
                credito.AbonoCapital = (float)abonoCapital;

                credito.ValorCuota = credito.InteresPagado - credito.AbonoCapital;
                if (credito.ValorCuota < 0)
                    credito.ValorCuota = 0;

                context.SaveChanges();

                MessageBox.Show($"Saldo restante a pagar: {credito.ValorCuota:C2}");
                pictureBox1_Click(null, null); // Refresca la grilla
            }

        }

        public void CargarProducto()
        {

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

            string criterio = txtBusqueda.Text.Trim();

            using (var context = new DbTiendaSeptentrionContext())
            {
                var creditos = context.DetalleCreditos
                    .Where(f => f.IdDetalleCredito.Contains(criterio) && f.ValorCuota > 0)
                    .Select(f => new
                    {
                        f.NumeroFactura,
                        Fecha = f.FechaRegistro,
                        f.Saldo,
                        f.Abono,
                        NuevoSaldo = f.Saldo - f.Abono,
                        f.TasaInteres,
                        f.NumeroPlazo
                    })
                    .ToList();

                Tabla_Credito.DataSource = creditos;
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

            if (!chkPagoDolares.Checked)
            {
                decimal abono = 0;
                decimal.TryParse(txtCordobas.Text, out abono);
                txtTotalAbonado.Text = abono.ToString("N2");
                txtCambio.Text = ""; // Puedes calcular el cambio si el abono es mayor al saldo
            }
        }

        private void txtDolares_TextChanged(object sender, EventArgs e)
        {
            if (txtDolares.Text)
            {
                decimal abonoDolares = 0;
                decimal tasaCambio = 36.5m; // Usa la tasa actual de tu sistema
                decimal.TryParse(txtDolares.Text, out abonoDolares);
                decimal abonoCordobas = abonoDolares * tasaCambio;
                txtTotalAbonado.Text = abonoCordobas.ToString("N2");
                txtCambio.Text = ""; // Calcula el cambio si es necesario
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
        }
            private void btnPagar_Click(object sender, EventArgs e)
        {
            int facturaId = FacturaCredito); // Implementa este método según tu lógica
            decimal abono = decimal.Parse(txtTotalAbonado.Text);

            using (var context = new DbTiendaSeptentrionContext())
            {
                var factura = context.DetalleDeVenta.Find(facturaId);
                var credito = context.DetalleCreditos.Find(facturaId);

                if (credito == null)
                {
                    MessageBox.Show("Factura no encontrada.");
                    return;
                }

                // Verificar atraso y actualizar interés si es necesario
                if (DateTime.Now > credito.FechaPago)
                {
                    //decimal abonoCapital = Convert.ToDecimal(credito.AbonoCapital);
                    //abonoCapital += abono;
                    //credito.AbonoCapital = (float)abonoCapital;
                    decimal interes = Convert.ToDecimal(credito.FechaPago);
                    interes += 0.03m;
                   credito.InteresPagado = (float) interes; // Incrementa el 3%
                }

                // Actualizar abono y saldo
                decimal abonoCapital = Convert.ToDecimal(credito.AbonoCapital);
                abonoCapital += abono;
                credito.AbonoCapital = (float)abonoCapital;
                credito.ValorCuota = credito.ValorCuota - credito.AbonoCapital;

                // Si ya pagó todo, poner saldo en 0
                if (credito.ValorCuota <= 0)
                {
                    credito.ValorCuota = 0;
                    MessageBox.Show("¡Crédito saldado!");
                }
                else
                {
                    MessageBox.Show($"Saldo restante a pagar: {credito.ValorCuota:C2}");
                }

                context.SaveChanges();
                lblSaldoRestante.Text = credito.ValorCuota.ToString("C2");
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

        private void Tabla_Credito_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            using (var context = new DbTiendaSeptentrionContext())
            {
                var clientesConCredito = context.FacturaCreditos
                    .Where(f => f.DetalleCreditos = "credito" && f.MontoCredito > 0)
                    .Select(f => new
                    {
                        f.NumeroFactura,
                        f.FechaRegistro,
                        f.FechaFinalizacion,
                        f.Saldo,
                        f.Abono,
                        f.NuevoSaldo,
                        f.NumeroPlazo,
                        f.TasaInteres,
                        f.ClienteId,
                        ClienteNombre = f.Cliente.Nombre
                    })
                    .ToList();

                // Aquí puedes enlazar los datos a tu DataGridView o controles.
            }

        }
    }
}
