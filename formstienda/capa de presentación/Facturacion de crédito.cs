using formstienda.Capa_negocios;
using formstienda.Datos;
using formstienda.Reporte;
using iText.Commons.Actions.Contexts;
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
            btnRegistrarPago_Click();
            ProcesarPago();

            if (Tabla_Credito.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una cuota para pagar.");
                return;
            }

            var idDetalleCredito = Convert.ToInt32(Tabla_Credito.CurrentRow.Cells["Id_DetalleCredito"].Value);
            var abonoTexto = txtTotalAbonado.Text;

            if (!decimal.TryParse(abonoTexto, out decimal abono) || abono <= 0)
            {
                MessageBox.Show("Ingrese un monto válido.");
                return;
            }

            try
            {
                using (var context2 = new DbTiendaSeptentrionContext())
                {
                    var cuota = context2.DetalleCreditos.Find(idDetalleCredito);
                    if (cuota == null)
                    {
                        MessageBox.Show("Cuota no encontrada.");
                        return;
                    }

                    // Aplicar interés por mora si pasó la fecha
                    if (cuota.FechaPago.Date < DateTime.Now.Date)
                    {
                        cuota.InteresPagado = (float)((decimal)cuota.ValorCuota * 0.03m);
                        cuota.TotalCordobas += (float)cuota.InteresPagado;
                    }

                    // Registrar abono
                    cuota.AbonoCapital += (float)abono;
                    cuota.ValorCuota -= (float)abono;

                    // Actualizar la factura de crédito
                    var facturaCredito = cuota.IdCreditoNavigation;
                    facturaCredito.TotalAbonado += (float)abono;
                    facturaCredito.NuevoSaldo = facturaCredito.MontoCredito - facturaCredito.TotalAbonado;

                    // Cambiar estado de crédito si está pagado
                    if (facturaCredito.TotalAbonado >= facturaCredito.MontoCredito)
                    {
                        //facturaCredito.TotalAbonado = "pagado";
                    }

                    // Guardar cambios
                    context2.SaveChanges();

                    // Generar nueva cuota si aún hay saldo
                    if (cuota.ValorCuota > 0)
                    {
                        GenerarNuevaCuota(context2, cuota);
                    }
                    else
                    {
                        // Si la cuota está completamente pagada, ajustar la fecha de pago para la próxima cuota
                        cuota.FechaPago = cuota.FechaPago.AddMonths(1);
                    }

                    MessageBox.Show("Pago procesado correctamente.");
                    CargarCreditosPendientes(); // Recargar tabla
                    LimpiarCamposPago();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al procesar el pago: {ex.Message}");
            }

            using var context = new DbTiendaSeptentrionContext();

            // Obtener el registro que deseas actualizar (ajusta la consulta según tu estructura)
            var registro = context.DetalleCreditos.Include(dc => dc.IdCreditoNavigation).FirstOrDefault(r => r.AbonoCapital == 0);

            if (registro != null)
            {
                MessageBox.Show("PAGADO", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                registro.Observaciones = "Finalizado";

                // Guardar cambios en la base de datos
                context.SaveChanges();
            }

        }

        public void btnRegistrarPago_Click()
        {

        }

        public void GenerarNuevaCuota(DbTiendaSeptentrionContext context, FacturaCredito facturaCredito, DetalleCredito ultimaCuota, object detalleCredito)
        {
            var cuota = context.DetalleCreditos.Find(detalleCredito);
            var valorCuota = facturaCredito.MontoCredito / facturaCredito.PlazosMeses;
            var facturacredito = cuota.IdCreditoNavigation;
            var nuevaCuota = new DetalleCredito
            {
                IdCredito = cuota.IdCredito,
                NumeroCuota = cuota.NumeroCuota + 1,
                FechaPago = cuota.FechaPago.AddMonths(1),
                ValorCuota = facturaCredito.NuevoSaldo / facturaCredito.PlazosMeses,
                TotalCordobas = cuota.TotalCordobas,
                TotalDolares = cuota.TotalDolares,
                Observaciones = "Pendiente",
                AbonoCapital = 0,
                InteresPagado = 0
            };

            context.DetalleCreditos.Add(nuevaCuota);
                context.SaveChanges();
            }
        



        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCamposPago();
        }


        private void checkBoxMoneda_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void btnRegistrarPago_Click(object sender, EventArgs e)
        {
            if (Tabla_Credito.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una cuota para pagar.");
                return;
            }

            var idDetalleCredito = Convert.ToInt32(Tabla_Credito.CurrentRow.Cells["IdDetalleCredito"].Value);
            var abonoTexto = txtTotalAbonado.Text;

            if (!decimal.TryParse(abonoTexto, out decimal abono) || abono <= 0)
            {
                MessageBox.Show("Ingrese un monto válido.");
                return;
            }

            try
            {
                using (var context = new DbTiendaSeptentrionContext())
                {
                    var cuota = context.DetalleCreditos.Find(idDetalleCredito);

                    if (cuota == null)
                    {
                        MessageBox.Show("Cuota no encontrada.");
                        return;
                    }

                    if (cuota.FechaPago.Date < DateTime.Now.Date)
                    {
                        // Aplicar interés por mora si pasó la fecha
                        cuota.InteresPagado = (float)((decimal)cuota.ValorCuota * 0.03m);
                        cuota.ValorCuota += cuota.InteresPagado;
                        cuota.TotalCordobas += cuota.InteresPagado;
                    }

                    // Registrar abono
                    cuota.AbonoCapital += (float)abono;
                    cuota.ValorCuota -= (float)abono;

                    // Calcular nuevo saldo
                    cuota.IdCreditoNavigation.NuevoSaldo = cuota.ValorCuota;

                    // Guardar cambios
                    context.SaveChanges();

                    // Generar nueva cuota si aún hay saldo
                    GenerarNuevaCuota(context, cuota);
                }

                MessageBox.Show("Pago procesado correctamente.");
                CargarCreditosPendientes(); // Recargar tabla
                LimpiarCamposPago();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al procesar el pago: {ex.Message}");
            }
        }

        private void GenerarNuevaCuota(DbTiendaSeptentrionContext context, DetalleCredito cuota)
        {
            throw new NotImplementedException();
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
                    .Where(f => f.IdCreditoNavigation.IdVentaNavigation.IdVenta.ToString().Contains(criterio) && f.ValorCuota > 0)
                    .Select(f => new
                    {

                        //DetalleCredito,
                        //NFactura = f.IdCreditoNavigation.IdVenta,
                        //f.NumeroCuota,
                        //f.FechaPago,
                        //f.ValorCuota,
                        //Saldo = f.AbonoCapital, // Mostrar AbonoCapital en lugar de NuevoSaldo
                        //Observaciones = f.Observaciones,
                        //Total = f.TotalCordobas + f.TotalDolares
                    })
                    .ToList();

                Tabla_Credito.AutoGenerateColumns = true;
                Tabla_Credito.DataSource = creditos;
                Tabla_Credito.Columns[0].Visible = false;
            }
        }

        private void ProcesarPago()
        {
            if (!ValidarSeleccionCuota()) return;
            if (!ValidarMontoAbono()) return;

            int idDetalleCredito;
            try
            {
                idDetalleCredito = Convert.ToInt32(Tabla_Credito.CurrentRow.Cells["Id_DetalleCredito"].Value);
            }
            catch
            {
                MessageBox.Show("No se pudo obtener el ID de la cuota seleccionada.");
                return;
            }

            decimal abono;
            if (!decimal.TryParse(txtTotalAbonado.Text, out abono))
            {
                MessageBox.Show("Monto abonado inválido.");
                return;
            }

            try
            {
                using (var context = new DbTiendaSeptentrionContext())
                {
                    var cuota = context.DetalleCreditos.Find(idDetalleCredito);

                    if (cuota == null)
                    {
                        MessageBox.Show("Cuota no encontrada.");
                        return;
                    }

                    if (cuota.FechaPago.Date < DateTime.Now.Date)
                    {
                        // Aplicar interés por mora si pasó la fecha
                        cuota.InteresPagado = (float)((decimal)cuota.ValorCuota * 0.03m);
                        cuota.TotalCordobas += (float)cuota.InteresPagado;
                    }

                    // Registrar abono
                    cuota.AbonoCapital += (float)abono;
                    cuota.ValorCuota -= (float)abono;

                    // Calcular nuevo saldo
                    cuota.IdCreditoNavigation.NuevoSaldo = cuota.ValorCuota;

                    // Guardar cambios
                    context.SaveChanges();

                    // Generar nueva cuota si aún hay saldo
                    GenerarNuevaCuota(context, cuota);
                }

                MessageBox.Show("Pago procesado correctamente.");
                LimpiarCamposPago();
                BuscarCreditos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al procesar el pago: {ex.Message}");
            }
        }

        private void CargarCreditosPendientes()
        {
            txtDolares.Enabled = true;
            using (var context = new DbTiendaSeptentrionContext())
            {
                var creditos = context.DetalleCreditos
                    .Where(d => d.ValorCuota > 0)
                    .ToList();

                Tabla_Credito.DataSource = creditos;
                Tabla_Credito.Columns[0].Visible = false;
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

        private void button1_Click(object sender, EventArgs e)
        {
            ReporteDeCredito reporteCredito = new ReporteDeCredito();
            reporteCredito.Show();

            try
            {
                // Validar fechas  
                if (dateTimePickerFechaInicialMotivo.Value > dateTimePickerFechaFinalMotivo.Value)
                {
                    MessageBox.Show("La fecha inicial no puede ser mayor que la fecha final", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var fechaInicio = dateTimePickerFechaInicialMotivo.Value;
                var fechaFin = dateTimePickerFechaFinalMotivo.Value;

                var menuForm = this.MdiParent as menu ?? Application.OpenForms.OfType<menu>().FirstOrDefault();

                if (menuForm != null)
                {
                    menuForm.AbrirformInPanel(new ReporteDeCredito(fechaInicio, fechaFin));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Reporte_de_Cliente_Moroso reporte_De_Cliente_Moroso = new Reporte_de_Cliente_Moroso();
            reporte_De_Cliente_Moroso.Show();
        }
    }
}