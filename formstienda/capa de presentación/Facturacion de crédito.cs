using formstienda.capa_de_negocios;
using formstienda.Capa_negocios;
using formstienda.Datos;
using iText.Commons.Actions.Contexts;
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

namespace formstienda.capa_de_presentación
{
    public partial class Facturacion_de_crédito : Form
    {
        public Facturacion_de_crédito()
        {
            InitializeComponent();
            txtCordobas.KeyUp += (s, e) => RecalcularPagos();
            txtDolares.KeyUp += (s, e) => RecalcularPagos();
        }
        private CreditoServicio creditoServicio = new CreditoServicio();
        private FacturaCredito? creditoActual;
        private TasaServicio TasaServicio = new TasaServicio();
        private ArqueoCaja arqueoCaja = new ArqueoCaja();


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void CalcularClientesCredito()
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Facturacion_de_crédito_Load(object sender, EventArgs e)
        {
            txtDolares.ReadOnly = false;
        }

        public void CargarProducto()
        {

        }
        private void txtCordobas_TextChanged(object sender, EventArgs e)
        {
            RecalcularPagos();

        }



        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (creditoActual == null)
            {
                MessageBox.Show("No hay un crédito cargado para pagar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var proximaCuota = creditoServicio.ObtenerProximaCuota(creditoActual, out int diasMora, out float mora);

            if (proximaCuota == null)
            {
                MessageBox.Show("No hay cuotas pendientes para pagar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!float.TryParse(txtCordobas.Text, out float pagoCordobas)) pagoCordobas = 0;
            if (!float.TryParse(txtDolares.Text, out float pagoDolares)) pagoDolares = 0;

            if (pagoCordobas <= 0 && pagoDolares <= 0)
            {
                MessageBox.Show("Ingrese un monto a pagar en córdobas o dólares.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            float tasaCambio = TasaServicio.ObtenerTasaDeHoy().ValorCambio;
            float pagoTotalCordobas = pagoCordobas + (pagoDolares * tasaCambio);
            float totalCuota = proximaCuota.ValorCuota + mora;

            float cambio = 0;
            if (pagoTotalCordobas > totalCuota)
            {
                cambio = pagoTotalCordobas - totalCuota;
                pagoTotalCordobas = totalCuota; // Solo se abona lo necesario
            }

            using (var context = new DbTiendaSeptentrionContext())
            {
                var cuotaDb = context.DetalleCreditos.FirstOrDefault(dc => dc.IdDetalleCredito == proximaCuota.IdDetalleCredito);
                if (cuotaDb == null)
                {
                    MessageBox.Show("No se encontró la cuota para actualizar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                cuotaDb.TotalCordobas = pagoCordobas;
                cuotaDb.TotalDolares = pagoDolares;
                cuotaDb.CambioDevuelto = cambio;
                cuotaDb.Observaciones = $"Pago realizado el {DateTime.Now:dd/MM/yyyy HH:mm}. Mora: C${mora:N2}. Cambio: C${cambio:N2}. Sin tomar en arqueo.";
                cuotaDb.UsuarioRegistro = UsuarioActivo.ObtenerUsuarioLogueo();
                context.SaveChanges();

                var facturaDb = context.FacturaCreditos.Include(fc => fc.DetalleCreditos)
                                    .FirstOrDefault(fc => fc.IdCredito == creditoActual.IdCredito);

                if (facturaDb != null)
                {
                    facturaDb.TotalAbonado += pagoTotalCordobas;
                    facturaDb.NuevoSaldo -= pagoTotalCordobas;

                    // ⚠️ Cuando se salda todo, desactivar el crédito
                    if (facturaDb.NuevoSaldo <= 0.01f)
                    {
                        facturaDb.EstadoCredito = "Inactivo";
                        facturaDb.NuevoSaldo = 0; // fuerza a cero exacto
                        MessageBox.Show("Crédito completamente saldado. Estado: Inactivo.", "Crédito Finalizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }





                    context.SaveChanges();

                    // Actualizar objeto en memoria
                    creditoActual.TotalAbonado = facturaDb.TotalAbonado;
                    creditoActual.NuevoSaldo = facturaDb.NuevoSaldo;
                    creditoActual.EstadoCredito = facturaDb.EstadoCredito;
                }
            }



            string mensaje = "Pago registrado correctamente.";

            if (cambio > 0)
            {
                mensaje += $"\nCambio a entregar: C${cambio:N2}";
            }

            MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Refrescar
            LimpiarFormularioCredito();
            try
            {
                using (var context = new DbTiendaSeptentrionContext())
                {
                    var servicioArqueo = new ArqueoDeCajaServicio(context);
                    servicioArqueo.SumarAbonoCreditoAEfectivo(pagoCordobas, pagoDolares);
                }
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show("⚠️ " + ex.Message);
            }






        }




        private void LimpiarFormularioCredito()
        {
            // Limpiar cajas de texto del cliente
            txtcliente.Clear();
            txtcedula.Clear();
            txtcolilla.Clear();
            txtdiasenmoras.Text = "0";
            txtpagomora.Text = "0.00";
            txtTotalAbonado.Text = "0.00";
            txtCordobas.Text = "0.00";
            txtDolares.Text = "0.00";

            // Habilitar edición nuevamente si habías bloqueado campos
            txtcliente.ReadOnly = false;
            txtcedula.ReadOnly = false;
            txtcolilla.ReadOnly = false;
            txtdiasenmoras.ReadOnly = false;
            txtpagomora.ReadOnly = false;

            // Limpiar DataGridView
            Tabla_Credito.Rows.Clear();
            Tabla_Credito.Columns.Clear();

            // Resetear objetos
            creditoActual = null;
            CBBUSQUEDADETALLE.SelectedIndex = -1;
            txtBusqueda.Clear();
            DesactivarCreditosSaldados();
            txtcambio.Text = "0.00";
        }


        private void Tabla_Credito_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }



        private void pcbusqueda_Click(object sender, EventArgs e)
        {
            FacturaCredito? credito = null;

            string tipoBusqueda = CBBUSQUEDADETALLE.SelectedItem?.ToString();
            string textoBusqueda = txtBusqueda.Text.Trim();

            if (string.IsNullOrWhiteSpace(textoBusqueda))
            {
                MessageBox.Show("Por favor, ingrese un valor de búsqueda.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (tipoBusqueda == "Cliente")
            {
                credito = creditoServicio.BuscarCreditoPorCliente(textoBusqueda);
            }
            else if (tipoBusqueda == "Factura")
            {
                if (int.TryParse(textoBusqueda, out int idFactura))
                {
                    credito = creditoServicio.BuscarCreditoPorFactura(idFactura);
                }
                else
                {
                    MessageBox.Show("El ID de factura debe ser un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Seleccione el tipo de búsqueda: Cliente o Factura.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (credito == null)
            {
                MessageBox.Show("Crédito no encontrado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            creditoActual = credito;

            txtcliente.Text = credito.IdVentaNavigation.CedulaClienteNavigation.NombreCliente;
            txtcedula.Text = credito.IdVentaNavigation.CedulaClienteNavigation.CedulaCliente;
            txtcolilla.Text = credito.IdVentaNavigation.CedulaClienteNavigation.ColillaInssCliente;

            txtcliente.ReadOnly = true;
            txtcedula.ReadOnly = true;
            txtcolilla.ReadOnly = true;
            txtdiasenmoras.ReadOnly = true;
            txtpagomora.ReadOnly = true;

            CargarCuotasEnTabla(credito.DetalleCreditos.ToList());

            var proxima = creditoServicio.ObtenerProximaCuota(credito, out int diasMora, out float mora);

            if (proxima == null)
            {
                MessageBox.Show("Este crédito ya ha sido pagado en su totalidad.", "Crédito pagado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtdiasenmoras.Text = "0";
                txtpagomora.Text = "0.00";
                txtTotalAbonado.Text = "0.00";
            }
            else
            {
                txtdiasenmoras.Text = diasMora.ToString();
                txtpagomora.Text = mora.ToString("N2");
                float totalabonar = proxima.ValorCuota + mora;
                txtTotalAbonado.Text = totalabonar.ToString("N2");
                txtTotalAbonado.Text = $"C$ {totalabonar:N2}";
                txtcambio.Text = $"C$ {"0.00":N2}";

            }

        }
        public void DesactivarCreditosSaldados()
        {
            using (var context = new DbTiendaSeptentrionContext())
            {
                var creditos = context.FacturaCreditos
                     .Where(c => c.EstadoCredito == "Activo" && c.NuevoSaldo <= 0.01)
                             .ToList();

                foreach (var credito in creditos)
                {
                    credito.EstadoCredito = "Inactivo";
                    credito.NuevoSaldo = 0; // Por seguridad
                }

                if (creditos.Any())
                {
                    context.SaveChanges();
                    Console.WriteLine($"{creditos.Count} crédito(s) se desactivaron por estar completamente pagados.",
                                    "Actualización de Créditos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void CargarCuotasEnTabla(List<DetalleCredito> cuotas)
        {
            Tabla_Credito.Rows.Clear();
            Tabla_Credito.Columns.Clear();

            Tabla_Credito.Columns.Add("Cuota", "No.");
            Tabla_Credito.Columns.Add("Fecha", "Fecha Pago");
            Tabla_Credito.Columns.Add("CuotaValor", "Valor Cuota");
            Tabla_Credito.Columns.Add("Abono", "Abono Capital");
            Tabla_Credito.Columns.Add("Interes", "Interés");
            Tabla_Credito.Columns.Add("TotalCordoba", "Total C$");
            Tabla_Credito.Columns.Add("TotalDolar", "Total $");

            var hoy = DateTime.Today;
            DetalleCredito? proximaCuota = cuotas
                .Where(c => c.TotalCordobas == 0 && c.TotalDolares == 0 && c.FechaPago >= hoy)
                .OrderBy(c => c.FechaPago)
                .FirstOrDefault();

            foreach (var cuota in cuotas)
            {
                int rowIndex = Tabla_Credito.Rows.Add(
                    cuota.NumeroCuota,
                    cuota.FechaPago.ToShortDateString(),
                    cuota.ValorCuota,
                    cuota.AbonoCapital,
                    cuota.InteresPagado,
                    cuota.TotalCordobas,
                    cuota.TotalDolares
                );

                var row = Tabla_Credito.Rows[rowIndex];

                bool pagada = cuota.TotalCordobas > 0 || cuota.TotalDolares > 0;
                bool enMora = !pagada && cuota.FechaPago < hoy;
                bool esProxima = !pagada && proximaCuota != null && cuota.IdDetalleCredito == proximaCuota.IdDetalleCredito;

                if (pagada)
                {
                    row.DefaultCellStyle.BackColor = Color.LightGreen; // Pagada
                }
                else if (enMora)
                {
                    row.DefaultCellStyle.BackColor = Color.Red; // En mora
                }
                else if (esProxima)
                {
                    row.DefaultCellStyle.BackColor = Color.Gold; // Próxima a pagar
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.LightYellow; // Pendiente pero no en mora ni próxima
                }
            }
        }
        private void RecalcularPagos()
        {
            float cordobas = 0;
            float dolares = 0;
            float.TryParse(txtCordobas.Text, out cordobas);
            float.TryParse(txtDolares.Text, out dolares);

            if (creditoActual == null)
            {
                txtcambio.Text = "";
                txtcambio.BackColor = SystemColors.Window;
                return;
            }

            var proxima = creditoServicio.ObtenerProximaCuota(creditoActual, out int diasMora, out float mora);
            if (proxima == null)
            {
                txtcambio.Text = "";
                txtcambio.BackColor = SystemColors.Window;
                return;
            }

            float tasa = TasaServicio.ObtenerTasaDeHoy().ValorCambio;
            float totalAPagar = proxima.ValorCuota + mora;
            float totalIngresado = cordobas + (dolares * tasa);
            float cambio = totalIngresado - totalAPagar;

            // Mostrar el cambio en el textbox
            txtcambio.Text = cambio.ToString("N2");

            // Cambiar color de fondo según el valor
            if (cambio < 0)
            {
                txtcambio.BackColor = Color.MistyRose; // rojo claro
                txtcambio.ForeColor = Color.DarkRed;
            }
            else
            {
                txtcambio.BackColor = Color.Honeydew; // verde claro
                txtcambio.ForeColor = Color.DarkGreen;
            }

            // Actualizar visualmente la tabla
            foreach (DataGridViewRow row in Tabla_Credito.Rows)
            {
                if (row.Cells[0].Value?.ToString() == proxima.NumeroCuota.ToString())
                {
                    row.Cells["TotalCordoba"].Value = cordobas.ToString("N2");
                    row.Cells["TotalDolar"].Value = dolares.ToString("N2");
                    break;
                }
            }
            txtTotalAbonado.Text = $"C$ {totalAPagar:N2}";
            txtcambio.Text = $"C$ {cambio:N2}";

        }


        private void txtDolares_TextChanged(object sender, EventArgs e)
        {
            RecalcularPagos();
        }

        private void txtCordobas_KeyUp(object sender, KeyEventArgs e)
        {
            RecalcularPagos();
        }

        private void txtDolares_TextChanged_1(object sender, EventArgs e)
        {
            RecalcularPagos();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarFormularioCredito();
        }

        private void txtCordobas_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = sender as TextBox;

            // Permitir tecla de borrado
            if (char.IsControl(e.KeyChar))
                return;

            // Solo permitir dígitos y un punto decimal
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
                return;
            }

            // Permitir solo un punto decimal
            if (e.KeyChar == '.' && txt.Text.Contains("."))
            {
                e.Handled = true;
                return;
            }

            // Validar que no se escriban más de 2 decimales
            if (txt.Text.Contains("."))
            {
                int index = txt.Text.IndexOf(".");
                string decimales = txt.Text.Substring(index + 1);
                if (txt.SelectionStart > index && decimales.Length >= 2)
                {
                    e.Handled = true;
                }
            }
        }

        private void txtDolares_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = sender as TextBox;

            // Permitir tecla de borrado
            if (char.IsControl(e.KeyChar))
                return;

            // Solo permitir dígitos y un punto decimal
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
                return;
            }

            // Permitir solo un punto decimal
            if (e.KeyChar == '.' && txt.Text.Contains("."))
            {
                e.Handled = true;
                return;
            }

            // Validar que no se escriban más de 2 decimales
            if (txt.Text.Contains("."))
            {
                int index = txt.Text.IndexOf(".");
                string decimales = txt.Text.Substring(index + 1);
                if (txt.SelectionStart > index && decimales.Length >= 2)
                {
                    e.Handled = true;
                }
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Tabla_Credito_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (Tabla_Credito.Columns[e.ColumnIndex].Name == "TotalCordoba" && e.Value is float valorCordobas)
            {
                e.Value = $"C$ {valorCordobas:N2}";
                e.FormattingApplied = true;
            }

            if (Tabla_Credito.Columns[e.ColumnIndex].Name == "TotalDolar" && e.Value is float valorDolares)
            {
                e.Value = $"${valorDolares:N2}";
                e.FormattingApplied = true;
            }

            if (Tabla_Credito.Columns[e.ColumnIndex].Name == "CuotaValor" && e.Value is float valorCuota)
            {
                e.Value = $"C$ {valorCuota:N2}";
                e.FormattingApplied = true;
            }
        }
    }


}

