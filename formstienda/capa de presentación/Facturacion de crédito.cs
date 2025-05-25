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

            string numeroFacturaStr = Tabla_Credito.CurrentRow.Cells["NumeroFactura"].Value.ToString();

            if (!int.TryParse(numeroFacturaStr, out int numeroFactura))
            {
                MessageBox.Show("Número de factura inválido.");
                return;
            }

            if (!decimal.TryParse(txtTotalAbonado.Text, out decimal abono) || abono <= 0)
            {
                MessageBox.Show("Ingrese un monto válido para el abono.");
                return;
            }

            using (var context = new DbTiendaSeptentrionContext())
            {
                // Buscar la venta por IdVenta 
                var factura = context.Venta.FirstOrDefault(f => f.IdVenta == numeroFactura);
                if (factura == null)
                {
                    MessageBox.Show("Factura no encontrada.");
                    return;
                }

                // Buscar el detalle de crédito 
                var credito = context.DetalleCreditos.FirstOrDefault(d => d.IdDetalleCredito == numeroFactura);
                if (credito == null)
                {
                    MessageBox.Show("Detalle de crédito no encontrado.");
                    return;
                }

                // Si hay atraso, incrementar interés
                if (DateTime.Now > credito.FechaPago)
                {
                    decimal interesDecimal = Convert.ToDecimal(credito.InteresPagado);
                    interesDecimal += 0.03m; // Incrementar 3%
                    credito.InteresPagado = (float)interesDecimal;
                }

                // Actualizar abono capital sumando el nuevo abono
                decimal abonoCapital = Convert.ToDecimal(credito.AbonoCapital);
                abonoCapital += abono;
                credito.AbonoCapital = (float)abonoCapital;

                // Calcular nuevo saldo pendiente restando el total abonado al saldo original
                decimal saldoOriginal = Convert.ToDecimal(credito.ValorCuota); 
                decimal nuevoSaldo = saldoOriginal - abonoCapital;
                if (nuevoSaldo < 0)
                    nuevoSaldo = 0;

                credito.ValorCuota = (float)nuevoSaldo;

                context.SaveChanges();

                MessageBox.Show($"Saldo restante a pagar: {credito.ValorCuota:C2}");

               
                Tabla_Credito_CellContentClick(null, null);
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
                    .Include(f => f.IdCreditoNavigation) // Propiedad de navegación a FacturaCredito o Venta
                    .Where(f => f.IdDetalleCredito.ToString().Contains(criterio) && f.ValorCuota > 0)
                    .Select(f => new
                    {
                        NumeroFactura = f.IdCreditoNavigation.IdVenta,
                        Fecha = f.FechaPago,
                        Saldo = f.ValorCuota,
                        Abono = f.AbonoCapital,
                        NuevoSaldo = f.ValorCuota - f.AbonoCapital,
                        TasaInteres = f.InteresPagado,
                        NumeroPlazo = f.NumeroCuota
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
            if (!string.IsNullOrWhiteSpace(txtCordobas.Text))
            {
                if (decimal.TryParse(txtCordobas.Text, out decimal abono))
                {
                    txtTotalAbonado.Text = abono.ToString("N2");
                    txtCambio.Text = string.Empty; // Aquí puedes calcular el cambio si el abono es mayor al saldo
                }
                else
                {
                    MessageBox.Show("Ingrese un valor válido en córdobas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCordobas.Focus();
                }
            }
            else
            {
                txtTotalAbonado.Text = string.Empty;
                txtCambio.Text = string.Empty;
            }

        }

        private void txtDolares_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtDolares.Text))
            {
                if (decimal.TryParse(txtDolares.Text, out decimal abonoDolares))
                {
                    decimal tasaCambio = 36.5m;
                    decimal abonoCordobas = abonoDolares * tasaCambio;
                    txtTotalAbonado.Text = abonoCordobas.ToString("N2");
                    txtCambio.Text = string.Empty; // Aquí puedes calcular el cambio si es necesario
                }
                else
                {
                    MessageBox.Show("Ingrese un valor válido en dólares.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDolares.Focus();
                }
            }
            else
            {
                txtTotalAbonado.Text = string.Empty;
                txtCambio.Text = string.Empty;
            }

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
        }
        private void btnPagar_Click(object sender, EventArgs e)
        {

            if (Tabla_Credito.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un crédito.");
                return;
            }

            int idDetalleCredito = Convert.ToInt32(Tabla_Credito.CurrentRow.Cells["IdDetalleCredito"].Value);
            decimal abono = decimal.Parse(txtTotalAbonado.Text);

            using (var context = new DbTiendaSeptentrionContext())
            {
                var credito = context.DetalleCreditos
                    .Include(c => c.IdCreditoNavigation)
                    .FirstOrDefault(c => c.IdDetalleCredito == idDetalleCredito);

                if (credito == null)
                {
                    MessageBox.Show("Crédito no encontrado.");
                    return;
                }

                // Si hay atraso, incrementar interés
                if (DateTime.Now > credito.FechaPago)
                {
                    decimal interesDecimal = Convert.ToDecimal(credito.InteresPagado);
                    interesDecimal += 0.03m;
                    credito.InteresPagado = (float)interesDecimal;
                }

                decimal saldoAnterior = Convert.ToDecimal(credito.ValorCuota);
                decimal cambio = 0;

                // Si el abono es mayor que el saldo, calcular cambio
                if (abono >= saldoAnterior)
                {
                    cambio = abono - saldoAnterior;
                    credito.AbonoCapital += (float)saldoAnterior;
                    credito.ValorCuota = 0;
                    MessageBox.Show("¡Crédito saldado!");
                }
                else
                {
                    credito.AbonoCapital += (float)abono;
                    credito.ValorCuota -= (float)abono;
                    MessageBox.Show($"Saldo restante a pagar: {credito.ValorCuota:C2}");
                }

                credito.CambioDevuelto = (float?)cambio;

                context.SaveChanges();

                txtCambio.Text = cambio > 0 ? cambio.ToString("C2") : "0.00";

                Tabla_Credito_CellContentClick(null, null);
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
                var resultado = context.FacturaCreditos
             .Where(f => f.IdCredito > 0)
             .Select(f => new 
             {
                 f.IdVenta,
                 f.FechaInicio,
                 f.FechaFinal,
                 f.TotalAbonado,
                 f.NuevoSaldo,
                 f.PlazosMeses,

                 FacturaCredito = f.IdVentaNavigation.FechaVenta
             })
             .ToList();
            }
        }

    }
    }

