using formstienda.Datos;
using formstienda.Capa_negocios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace formstienda.capa_de_presentación
{
    public partial class Facturacion_de_crédito : Form
    {
        private readonly CreditoServicio _creditoServicio;
        private const decimal TasaCambioDolar = 36.5m;
        //camio minimo

        public Facturacion_de_crédito()
        {
            InitializeComponent();
            _creditoServicio = new CreditoServicio();
        }

        #region Eventos de UI

        private void Facturacion_de_crédito_Load(object sender, EventArgs e)
        {
            CargarCreditosPendientes();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarCreditos();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            ProcesarPago();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCamposPago();
        }

       
        private void checkBoxMoneda_CheckedChanged(object sender, EventArgs e)
        {
            txtDolares.Enabled = checkBox1.Checked;
            txtCordobas.Enabled = !checkBox1.Checked;
        }

        private void txtCordobas_TextChanged(object sender, EventArgs e)
        {
            ProcesarMontoCordobas();
        }

        private void txtDolares_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDolares.Text))
            {
                LimpiarCamposMonto();
                return;
            }

            if (decimal.TryParse(txtDolares.Text, out decimal abonoDolares))
            {
                using (var context = new DbTiendaSeptentrionContext())
                {
                    var tasaCambio = context.TasaDeCambios
                        .OrderByDescending(t => t.FechaCambio)
                        .FirstOrDefault(t => t.FechaCambio == DateOnly.FromDateTime(DateTime.Now));

                    if (tasaCambio == null)
                    {
                        MessageBox.Show("No se encontró tasa de cambio para hoy", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    decimal abonoCordobas = abonoDolares * (decimal)tasaCambio.ValorCambio;
                    txtTotalAbonado.Text = abonoCordobas.ToString("N2");
                    txtCambio.Text = string.Empty;
                }
            }
            else
            {
                MostrarErrorValidacion("Ingrese un valor válido en dólares.", txtDolares);
            }

        }

        #endregion

        #region Métodos de negocio

        private void BuscarCreditos()
        {
            string criterio = txtBusqueda.Text.Trim();

            using (var context = new DbTiendaSeptentrionContext())
            {
                var creditos = context.DetalleCreditos
                    .Include(f => f.IdCreditoNavigation)
                    .Where(f => f.IdDetalleCredito.ToString().Contains(criterio) && f.ValorCuota > 0)
                    .Select(f => new
                    {
                        f.IdDetalleCredito,
                        NFactura = f.IdCreditoNavigation.IdVenta,
                        f.FechaPago,
                        Saldo = f.ValorCuota,
                        f.AbonoCapital,
                        NuevoSaldo = f.ValorCuota - f.AbonoCapital,
                        f.InteresPagado,
                        f.NumeroCuota
                    })
                    .ToList();

                Tabla_Credito.AutoGenerateColumns = true;
                Tabla_Credito.DataSource = creditos;
            }
        }

        private void ProcesarPago()
        {
            if (!ValidarSeleccionCuota()) return;
            if (!ValidarMontoAbono()) return;

            int idDetalleCredito = Convert.ToInt32(Tabla_Credito.CurrentRow.Cells["IdDetalleCredito"].Value);
            decimal abono = decimal.Parse(txtTotalAbonado.Text);

            bool resultado = _creditoServicio.ProcesarPagoCredito(
                idDetalleCredito,
                abono,
                checkBox1.Checked);

            if (resultado)
            {
                MessageBox.Show("Pago procesado correctamente");
                LimpiarCamposPago();
                BuscarCreditos();
            }
            else
            {
                MessageBox.Show("Error al procesar el pago");
            }
        }

        private void CargarCreditosPendientes()
        {
            using (var context = new DbTiendaSeptentrionContext())
            {
                var creditos = context.DetalleCreditos
                    .Where(d => d.ValorCuota > 0)
                    .ToList();

                Tabla_Credito.DataSource = creditos;
            }
        }

        #endregion

        #region Métodos auxiliares

        private bool ValidarSeleccionCuota()
        {
            if (Tabla_Credito.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una cuota.");
                return false;
            }
            return true;
        }

        private bool ValidarMontoAbono()
        {
            if (string.IsNullOrWhiteSpace(txtTotalAbonado.Text))
            {
                MessageBox.Show("Ingrese un monto válido para el abono.");
                return false;
            }

            if (!decimal.TryParse(txtTotalAbonado.Text, out decimal abono) || abono <= 0)
            {
                MessageBox.Show("El monto ingresado no es válido.");
                return false;
            }

            return true;
        }

        private void ProcesarMontoCordobas()
        {
            if (string.IsNullOrWhiteSpace(txtCordobas.Text))
            {
                LimpiarCamposMonto();
                return;
            }

            if (decimal.TryParse(txtCordobas.Text, out decimal abono))
            {
                txtTotalAbonado.Text = abono.ToString("N2");
                txtCambio.Text = string.Empty;
            }
            else
            {
                MostrarErrorValidacion("Ingrese un valor válido en córdobas.", txtCordobas);
            }
        }

        

        private void LimpiarCamposPago()
        {
            txtCordobas.Clear();
            txtDolares.Clear();
            txtTotalAbonado.Clear();
            txtCambio.Clear();
        }

        private void LimpiarCamposMonto()
        {
            txtTotalAbonado.Text = string.Empty;
            txtCambio.Text = string.Empty;
        }

        private void MostrarErrorValidacion(string mensaje, Control control)
        {
            MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            control.Focus();
        }

        #endregion

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}