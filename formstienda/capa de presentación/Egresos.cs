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
        // Variables para almacenar los totales en ambas monedas
        private decimal _totalCordobas = 0;
        private decimal _totalDolares = 0;
        private DateOnly _fechaActual;

        // Servicios y contexto de base de datos
        private readonly EgresoServicio _egresoservicio;
        private readonly DbTiendaSeptentrionContext _contexto;

        public Egresos()
        {
            InitializeComponent();
            try
            {
                // Inicializar el contexto de base de datos
                _contexto = new DbTiendaSeptentrionContext();

                // Verificar conexión a la base de datos
                if (!_contexto.Database.CanConnect())
                {
                    MessageBox.Show("No se pudo establecer conexión con la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                // Inicializar el servicio de egresos
                _egresoservicio = new EgresoServicio(_contexto);

                // Obtener fecha actual
                _fechaActual = DateOnly.FromDateTime(DateTime.Now);

                // Cargar los totales iniciales de caja
                CargarTotalesIniciales();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al inicializar el formulario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        // Método para cargar los totales iniciales de caja
        private void CargarTotalesIniciales()
        {
            try
            {
                // Obtener totales de caja para ambas monedas
                _totalCordobas = _egresoservicio.ObtenerTotalCajaCordobas(_fechaActual);
                _totalDolares = _egresoservicio.ObtenerTotalCajaDolares(_fechaActual);

                // Actualizar el TextBox según la moneda seleccionada
                ActualizarTextBoxSegunMoneda();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar totales iniciales: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Egresos_Load(object sender, EventArgs e)
        {
            // Configurar el ComboBox de monedas
            cmbMoneda.Items.Add("Dólar");
            cmbMoneda.Items.Add("Córdoba");
            cmbMoneda.SelectedIndex = 0;

            // Cargar el total en dólares inicialmente
            CargarTotalDolar();
        }

        // Evento cuando cambia la selección de moneda
        private void cmbMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMoneda.SelectedItem == null) return;

            // Actualizar el TextBox según la moneda seleccionada
            ActualizarTextBoxSegunMoneda();
            string monedaSeleccionada = cmbMoneda.SelectedItem.ToString();

            // Cargar el total correspondiente a la moneda seleccionada
            if (monedaSeleccionada.Equals("Córdoba", StringComparison.OrdinalIgnoreCase))
            {
                CargarTotalCajaCordoba();
            }
            else if (monedaSeleccionada.Equals("Dólar", StringComparison.OrdinalIgnoreCase))
            {
                CargarTotalDolar();
            }
        }

        // Método para cargar el total en córdobas
        private void CargarTotalCajaCordoba()
        {
            try
            {
                DateOnly fechaActual = DateOnly.FromDateTime(DateTime.Now);

                // Obtener la apertura de caja del día
                var apertura = _egresoservicio.ListarAperturaCaja(fechaActual).FirstOrDefault();
                decimal montoApertura = (decimal)(apertura?.MontoApertura ?? 0f);

                // Obtener total de ventas en córdobas
                var ventas = _egresoservicio.ListarTotalVenta(fechaActual);
                decimal totalVentasCordobas = ventas?
                    .Where(v => v?.PagoCordobas != null)
                    .Sum(v => (decimal)v.PagoCordobas.Value) ?? 0m;

                // Obtener total de devoluciones
                var devoluciones = _egresoservicio.ListarDevolucion(fechaActual);
                decimal totalDevoluciones = devoluciones?
                    .Where(d => d?.MontoDevolucion != null)
                    .Sum(d => (decimal)d.MontoDevolucion) ?? 0m;

                // Obtener total de pagos a crédito en córdobas
                var pagosCredito = _egresoservicio.ListarPagosCredito(fechaActual);
                decimal totalCordobasAbonados = pagosCredito?
                    .Where(p => p?.CordobasAbonados != null)
                    .Sum(p => (decimal)p.CordobasAbonados.Value) ?? 0m;

                // Obtener total de egresos en córdobas
                decimal totalEgresos = _egresoservicio.ObtenerTotalEgresosCordobas(fechaActual);

                // Calcular el total final
                decimal total = Math.Round(montoApertura + totalVentasCordobas + totalCordobasAbonados - totalDevoluciones - totalEgresos);

                // Actualizar el TextBox con el total calculado
                ActualizarTextBox(total, "Córdoba");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al calcular caja: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ActualizarTextBox(0m, "Córdoba");
            }
        }

        // Método para cargar el total en dólares
        private void CargarTotalDolar()
        {
            try
            {
                DateOnly fechaActual = DateOnly.FromDateTime(DateTime.Now);

                // Obtener total de ventas en dólares
                var ventas = _egresoservicio.ListarTotalVenta(fechaActual);
                decimal totalVentasDolares = ventas?
                    .Where(v => v?.PagoDolares != null)
                    .Sum(v => (decimal)v.PagoDolares.Value) ?? 0m;

                // Obtener total de pagos a crédito en dólares
                var pagosCredito = _egresoservicio.ListarPagosCredito(fechaActual);
                decimal totalDolaresAbonados = pagosCredito?
                    .Where(p => p?.DolaresAbonados != null)
                    .Sum(p => (decimal)p.DolaresAbonados.Value) ?? 0m;

                // Obtener total de egresos en dólares
                decimal totalEgresos = _egresoservicio.ObtenerTotalEgresosDolares(fechaActual);

                // Calcular el total final
                decimal total = Math.Round(totalVentasDolares + totalDolaresAbonados - totalEgresos);

                // Actualizar el TextBox con el total calculado
                ActualizarTextBox(total, "Dólar");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al calcular caja: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ActualizarTextBox(0m, "Dólar");
            }
        }

        // Método para actualizar el TextBox con el formato correcto según la moneda
        private void ActualizarTextBox(decimal valor, string moneda)
        {
            // Seleccionar la cultura adecuada según la moneda
            CultureInfo cultura = moneda.Equals("Dólar", StringComparison.OrdinalIgnoreCase) ?
                CultureInfo.CreateSpecificCulture("en-US") :
                CultureInfo.CreateSpecificCulture("es-NI");

            // Actualizar el control de UI de forma segura (incluso desde hilos secundarios)
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

        // Evento del botón Cancelar
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Evento del botón Guardar
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar que hay un usuario logueado
                if (!UsuarioActivo.HayUsuarioLogueado())
                {
                    MessageBox.Show("No hay un usuario logueado para registrar el egreso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Validar que se ingresó un motivo
                if (string.IsNullOrWhiteSpace(txtMotivoEgreso.Text))
                {
                    MessageBox.Show("Debe ingresar un motivo para el egreso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMotivoEgreso.Focus();
                    return;
                }

                // Validar que la cantidad es un número positivo
                if (!decimal.TryParse(txtCantidadEgresada.Text, out decimal cantidad) || cantidad <= 0)
                {
                    MessageBox.Show("La cantidad debe ser un número positivo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCantidadEgresada.SelectAll();
                    txtCantidadEgresada.Focus();
                    return;
                }

                // Validar que se seleccionó una moneda
                if (cmbMoneda.SelectedItem == null)
                {
                    MessageBox.Show("Debe seleccionar un tipo de moneda", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string monedaSeleccionada = cmbMoneda.SelectedItem.ToString();

                // Validar que hay saldo suficiente para el egreso
                if ((monedaSeleccionada == "Córdoba" && cantidad > _totalCordobas) ||
                    (monedaSeleccionada == "Dólar" && cantidad > _totalDolares))
                {
                    MessageBox.Show("No hay suficiente saldo disponible", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Intentar guardar el egreso en la base de datos
                bool resultado = GuardarEgresoEnBD(cantidad, monedaSeleccionada);

                if (resultado)
                {
                    // Actualizar los totales si se guardó correctamente
                    if (monedaSeleccionada == "Córdoba")
                    {
                        _totalCordobas -= cantidad;
                    }
                    else
                    {
                        _totalDolares -= cantidad;
                    }

                    // Actualizar la UI y mostrar mensaje de éxito
                    ActualizarTextBoxSegunMoneda();
                    MessageBox.Show("Egreso registrado exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Limpiar los campos del formulario
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

        // Método para guardar el egreso en la base de datos
        private bool GuardarEgresoEnBD(decimal cantidad, string moneda)
        {
            try
            {
                DateOnly fechaActual = DateOnly.FromDateTime(DateTime.Now);

                // Obtener la apertura de caja del día
                var apertura = _egresoservicio.ListarAperturaCaja(fechaActual).FirstOrDefault();

                if (apertura == null)
                {
                    MessageBox.Show("No hay una apertura de caja activa para hoy", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                // Crear el egreso a través del servicio
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

        // Método para limpiar los campos del formulario
        private void LimpiarCamposEgreso()
        {
            txtCantidadEgresada.Text = string.Empty;
            txtMotivoEgreso.Text = string.Empty;
            cmbMoneda.SelectedIndex = 0;
            txtCantidadEgresada.Focus();
        }

        // Método para actualizar el TextBox según la moneda seleccionada
        private void ActualizarTextBoxSegunMoneda()
        {
            if (cmbMoneda.SelectedItem == null) return;

            string monedaSeleccionada = cmbMoneda.SelectedItem.ToString();

            // Seleccionar el total correspondiente a la moneda
            decimal valorMostrar = monedaSeleccionada == "Córdoba" ? _totalCordobas : _totalDolares;

            // Seleccionar el formato cultural adecuado
            CultureInfo cultura = monedaSeleccionada == "Córdoba" ?
                CultureInfo.CreateSpecificCulture("es-NI") :
                CultureInfo.CreateSpecificCulture("en-US");

            // Actualizar el TextBox con el valor formateado
            txtTotalCaja.Text = valorMostrar.ToString("C2", cultura);
        }

        private void btnCancelarCordobas_Click(object sender, EventArgs e)
        {
            LimpiarCamposEgreso();
        }
    }
}