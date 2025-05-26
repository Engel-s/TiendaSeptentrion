using formstienda.capa_de_negocios;
using formstienda.Datos;
using formstienda.Servicios;
using System.Globalization;
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
    public partial class Egresos : Form
    {
        
        private decimal _totalCordobas = 0;
        private decimal _totalDolares = 0;
        private DateOnly _fechaActual;
        private readonly EgresoServicio _egresoservicio;
        private readonly DbTiendaSeptentrionContext _contexto;

        public Egresos()
        {
            InitializeComponent();
            try
            {
               _contexto = new DbTiendaSeptentrionContext();
                               
                if (!_contexto.Database.CanConnect())
                {
                    MessageBox.Show("No se pudo establecer conexión con la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }
                            
                _egresoservicio = new EgresoServicio(_contexto);

                _fechaActual = DateOnly.FromDateTime(DateTime.Now);

                CargarTotalesIniciales();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al inicializar el formulario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
                
        private void CargarTotalesIniciales()
        {
            try
            {
                _totalCordobas = _egresoservicio.ObtenerTotalCajaCordobas(_fechaActual);
                _totalDolares = _egresoservicio.ObtenerTotalCajaDolares(_fechaActual);

                ActualizarTextBoxSegunMoneda();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar totales iniciales: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Egresos_Load(object sender, EventArgs e)
        {
            
            cmbMoneda.Items.Add("Dólar");
            cmbMoneda.Items.Add("Córdoba");
            cmbMoneda.SelectedIndex = 0;

            CargarTotalDolar();
        }

        private void cmbMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMoneda.SelectedItem == null) return;

            ActualizarTextBoxSegunMoneda();
            string monedaSeleccionada = cmbMoneda.SelectedItem.ToString();

            if (monedaSeleccionada.Equals("Córdoba", StringComparison.OrdinalIgnoreCase))
            {
                CargarTotalCajaCordoba();
            }
            else if (monedaSeleccionada.Equals("Dólar", StringComparison.OrdinalIgnoreCase))
            {
                CargarTotalDolar();
            }
        }

        private void CargarTotalCajaCordoba()
        {
            try
            {
                DateOnly fechaActual = DateOnly.FromDateTime(DateTime.Now);

                var apertura = _egresoservicio.ListarAperturaCaja(fechaActual).FirstOrDefault();
                decimal montoApertura = apertura?.MontoApertura != null ? (decimal)apertura.MontoApertura : 0m;

                var ventas = _egresoservicio.ListarTotalVenta(fechaActual);
                decimal totalVentasCordobas = ventas?
                    .Where(v => v?.PagoCordobas != null)
                    .Sum(v => (decimal)v.PagoCordobas.Value) ?? 0m;

                var devoluciones = _egresoservicio.ListarDevolucion(fechaActual);
                decimal totalDevoluciones = devoluciones?
                    .Where(d => d?.MontoDevolucion != null)
                    .Sum(d => (decimal)d.MontoDevolucion) ?? 0m;

                var pagosCredito = _egresoservicio.ListarPagosCredito(fechaActual);
                decimal totalCordobasAbonados = pagosCredito?
                    .Where(p => p?.TotalCordobas > 0)
                    .Sum(p => (decimal)p.TotalCordobas) ?? 0m;

                decimal totalEgresos = _egresoservicio.ObtenerTotalEgresosCordobas(fechaActual);
                decimal total = Math.Round(montoApertura + totalVentasCordobas + totalCordobasAbonados - totalDevoluciones - totalEgresos);

                ActualizarTextBox(total, "Córdoba");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al calcular caja: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ActualizarTextBox(0m, "Córdoba");
            }
        }

        private void CargarTotalDolar()
        {
            try
            {
                DateOnly fechaActual = DateOnly.FromDateTime(DateTime.Now);

                var ventas = _egresoservicio.ListarTotalVenta(fechaActual);
                decimal totalVentasDolares = ventas?
                    .Where(v => v?.PagoDolares != null)
                    .Sum(v => (decimal)v.PagoDolares.Value) ?? 0m;

                var pagosCredito = _egresoservicio.ListarPagosCredito(fechaActual);
                decimal totalDolaresAbonados = pagosCredito?
                    .Where(p => p?.TotalDolares > 0)
                    .Sum(p => (decimal)p.TotalDolares) ?? 0m;

                decimal totalEgresos = _egresoservicio.ObtenerTotalEgresosDolares(fechaActual);
                decimal total = Math.Round(totalVentasDolares + totalDolaresAbonados - totalEgresos);
                                
                ActualizarTextBox(total, "Dólar");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al calcular caja: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ActualizarTextBox(0m, "Dólar");
            }
        }

        
        private void ActualizarTextBox(decimal valor, string moneda)
        {
           
            CultureInfo cultura = moneda.Equals("Dólar", StringComparison.OrdinalIgnoreCase) ?
                CultureInfo.CreateSpecificCulture("en-US") :
                CultureInfo.CreateSpecificCulture("es-NI");

           
            if (txtTotalCaja.InvokeRequired)
            {
                txtTotalCaja.Invoke((MethodInvoker)(() =>
                {
                    txtTotalCaja.Text = valor.ToString("C2", cultura);
                }));
            }
            else
            {
                txtTotalCaja.Text = valor.ToString("C2", cultura);
            }
        }

        
        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!UsuarioActivo.HayUsuarioLogueado())
                {
                    MessageBox.Show("No hay un usuario logueado para registrar el egreso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtMotivoEgreso.Text))
                {
                    MessageBox.Show("Debe ingresar un motivo para el egreso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMotivoEgreso.Focus();
                    return;
                }
                                
                if (!decimal.TryParse(txtCantidadEgresada.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal cantidad) || cantidad <= 0)
                {
                    MessageBox.Show("La cantidad debe ser un número positivo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCantidadEgresada.SelectAll();
                    txtCantidadEgresada.Focus();
                    return;
                }
                                
                if (cmbMoneda.SelectedItem == null)
                {
                    MessageBox.Show("Debe seleccionar un tipo de moneda", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string monedaSeleccionada = cmbMoneda.SelectedItem.ToString();

                if ((monedaSeleccionada == "Córdoba" && cantidad > _totalCordobas) ||
                    (monedaSeleccionada == "Dólar" && cantidad > _totalDolares))
                {
                    MessageBox.Show("No hay suficiente saldo disponible", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                                
                bool resultado = GuardarEgresoEnBD(cantidad, monedaSeleccionada);

                if (resultado)
                {
                    if (monedaSeleccionada == "Córdoba")
                    {
                        _totalCordobas -= cantidad;
                    }
                    else
                    {
                        _totalDolares -= cantidad;
                    }

                    ActualizarTextBoxSegunMoneda();
                    MessageBox.Show("Egreso registrado exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        
                    LimpiarCamposEgreso();
                }
                else
                {
                    MessageBox.Show("No se pudo guardar el egreso en la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar egreso: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool GuardarEgresoEnBD(decimal cantidad, string moneda)
        {
            try
            {
                DateOnly fechaActual = DateOnly.FromDateTime(DateTime.Now);

                var apertura = _egresoservicio.ListarAperturaCaja(fechaActual).FirstOrDefault();

                if (apertura == null)
                {
                    MessageBox.Show("No hay una apertura de caja activa para hoy", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                bool resultado = _egresoservicio.CrearEgreso(
                    idApertura: apertura.IdApertura,
                    fechaEgreso: fechaActual,
                    cantidadCordobas: moneda == "Córdoba" ? cantidad : (decimal?)null,
                    cantidadDolares: moneda == "Dólar" ? cantidad : (decimal?)null,
                    motivo: txtMotivoEgreso.Text.Trim()
                );

                return resultado;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar en base de datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
               
        private void LimpiarCamposEgreso()
        {
            txtCantidadEgresada.Text = string.Empty;
            txtMotivoEgreso.Text = string.Empty;
            cmbMoneda.SelectedIndex = 0;
            txtCantidadEgresada.Focus();
        }

        private void ActualizarTextBoxSegunMoneda()
        {
            if (cmbMoneda.SelectedItem == null) return;

            string monedaSeleccionada = cmbMoneda.SelectedItem.ToString();

            decimal valorMostrar = monedaSeleccionada == "Córdoba" ? _totalCordobas : _totalDolares;
                        
            CultureInfo cultura = monedaSeleccionada == "Córdoba" ?
                CultureInfo.CreateSpecificCulture("es-NI") :
                CultureInfo.CreateSpecificCulture("en-US");

             txtTotalCaja.Text = valorMostrar.ToString("C2", cultura);
        }

        private void btnCancelarCordobas_Click(object sender, EventArgs e)
        {
            LimpiarCamposEgreso();
        }
    }
}