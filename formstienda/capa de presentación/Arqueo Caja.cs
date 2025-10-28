using formstienda.capa_de_negocios;
using formstienda.capa_de_presentación;
using formstienda.Datos;
using formstienda.Servicios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static formstienda.Login;

namespace formstienda
{
    public partial class Arqueo_Caja : Form
    {
        private readonly ArqueoDeCajaServicio _arqueoDeCajaServicio;
        private readonly DbTiendaSeptentrionContext _contexto;
        private TotalesEfectivo totales = new TotalesEfectivo();


        public class TotalesEfectivo
        {
            public decimal TotalCordobas { get; set; }
            public decimal TotalDolares { get; set; }
        }
                
        public Arqueo_Caja()
        {
            InitializeComponent();
            EtiquetarCamposParaLimpieza();   
            ConfigurarEventosTextChanged();
            CargarTotalVentasDelDia();

            this.FormClosing += (s, e) => {
                if (this.Visible) 
                    GuardarEnCache();
            };
    
            this.Shown += (s, e) => {
                if (!CacheArqueo.DatosCargados)
                    CargarDesdeCache();
            };
        }

        public static class CacheArqueo
        {
            private static readonly Dictionary<string, string> _valores = new Dictionary<string, string>();
            private static bool _datosCargados = false;

            public static void Guardar(string clave, string valor)
            {
                _valores[clave] = valor;
            }

            public static string Obtener(string clave)
            {
                return _valores.TryGetValue(clave, out string valor) ? valor : string.Empty;
            }

            public static void Limpiar()
            {
                _valores.Clear();
                _datosCargados = false;
            }

            public static bool DatosCargados => _datosCargados;
        }

        private void CargarTotalVentasDelDia()
        {
            using (var contexto = new DbTiendaSeptentrionContext())
            {
                var servicio = new ArqueoDeCajaServicio(contexto);
                float totalVentas = servicio.ObtenerTotalVentasDelDia();
                txtTotalVentas.Text = totalVentas.ToString("N2"); 
            }
        }

        private void ConfigurarEventosTextChanged()
        {
            // Configurar eventos para córdobas
            txtMilCordobas.TextChanged += (s, e) => CalcularTotal(txtMilCordobas, txtMilCordobasTotal, 1000);
            txtQuinientosCordobas.TextChanged += (s, e) => CalcularTotal(txtQuinientosCordobas, txtQuinientosCordobasTotal, 500);
            txtDocientosCordobas.TextChanged += (s, e) => CalcularTotal(txtDocientosCordobas, txtDocientosCordobasTotal, 200);
            txtCienCordobas.TextChanged += (s, e) => CalcularTotal(txtCienCordobas, txtCienCordobasTotal, 100);
            txtCincuentaCordobas.TextChanged += (s, e) => CalcularTotal(txtCincuentaCordobas, txtCincuentaCordobasTotal, 50);
            txtVeinteCordobas.TextChanged += (s, e) => CalcularTotal(txtVeinteCordobas, txtVeinteCordobasTotal, 20);
            txtDiezCordobas.TextChanged += (s, e) => CalcularTotal(txtDiezCordobas, txtDiezCordobasTotal, 10);
            txtCincoCordobas.TextChanged += (s, e) => CalcularTotal(txtCincoCordobas, txtCincoCordobasTotal, 5);
            txtUnCordobas.TextChanged += (s, e) => CalcularTotal(txtUnCordobas, txtUnCordobasTotal, 1);
            txtCincuentaCentavosCordobas.TextChanged += (s, e) => CalcularTotal(txtCincuentaCentavosCordobas, txtCincuentaCentavosCordobasTotal, 0.5m);
            txtVeinticincoCentavosCordobas.TextChanged += (s, e) => CalcularTotal(txtVeinticincoCentavosCordobas, txtVeinticincoCentavosCordobasTotal, 0.25m);

            // Configurar eventos para dólares
            txtCienDolares.TextChanged += (s, e) => CalcularTotal(txtCienDolares, txtCienDolaresTotal, 100);
            txtCincuentaDolares.TextChanged += (s, e) => CalcularTotal(txtCincuentaDolares, txtCincuentaDolaresTotal, 50);
            txtVeinteDolares.TextChanged += (s, e) => CalcularTotal(txtVeinteDolares, txtVeinteDolaresTotal, 20);
            txtDiezDolares.TextChanged += (s, e) => CalcularTotal(txtDiezDolares, txtDiezDolaresTotal, 10);
            txtCincoDolares.TextChanged += (s, e) => CalcularTotal(txtCincoDolares, txtCincoDolaresTotal, 5);
            txtUnDolar.TextChanged += (s, e) => CalcularTotal(txtUnDolar, txtUnDolarTotal, 1);
            txtCincuentaCentavosDolares.TextChanged += (s, e) => CalcularTotal(txtCincuentaCentavosDolares, txtCincuentaCentavosDolaresTotal, 0.5m);
        }

        private void CalcularTotal(TextBox txtCantidad, TextBox txtTotal, decimal valor)
        {
            if (string.IsNullOrWhiteSpace(txtCantidad.Text))
            {
                txtTotal.Text = "0";
            }
            else
            {
                if (decimal.TryParse(txtCantidad.Text, out decimal cantidad))
                {
                    decimal resultado = cantidad * valor;
                    txtTotal.Text = resultado.ToString("N2");
                }
                else
                {
                    txtTotal.Text = "0";
                }
            }

            CalcularTotales();
        }

        private void CalcularTotales()
        {
            
            decimal totalCordobas = 0;
            decimal totalDolares = 0;

            // Sumar todos los totales de córdobas
            totalCordobas += ObtenerValorTextBox(txtMilCordobasTotal);
            totalCordobas += ObtenerValorTextBox(txtQuinientosCordobasTotal);
            totalCordobas += ObtenerValorTextBox(txtDocientosCordobasTotal);
            totalCordobas += ObtenerValorTextBox(txtCienCordobasTotal);
            totalCordobas += ObtenerValorTextBox(txtCincuentaCordobasTotal);
            totalCordobas += ObtenerValorTextBox(txtVeinteCordobasTotal);
            totalCordobas += ObtenerValorTextBox(txtDiezCordobasTotal);
            totalCordobas += ObtenerValorTextBox(txtCincoCordobasTotal);
            totalCordobas += ObtenerValorTextBox(txtUnCordobasTotal);
            totalCordobas += ObtenerValorTextBox(txtCincuentaCentavosCordobasTotal);
            totalCordobas += ObtenerValorTextBox(txtVeinticincoCentavosCordobasTotal);

            // Sumar todos los totales de dólares
            totalDolares += ObtenerValorTextBox(txtCienDolaresTotal);
            totalDolares += ObtenerValorTextBox(txtCincuentaDolaresTotal);
            totalDolares += ObtenerValorTextBox(txtVeinteDolaresTotal);
            totalDolares += ObtenerValorTextBox(txtDiezDolaresTotal);
            totalDolares += ObtenerValorTextBox(txtCincoDolaresTotal);
            totalDolares += ObtenerValorTextBox(txtUnDolarTotal);
            totalDolares += ObtenerValorTextBox(txtCincuentaCentavosDolaresTotal);
                        
            txtTotalEfectivoCordobas.Text = totalCordobas.ToString("N2");
            txtDolaresTotalEfectivo.Text = totalDolares.ToString("N2");
                        
            decimal totalCalculadoCordobas = ObtenerValorTextBox(txtTotalCajaCordobas);
            decimal totalCalculadoDolares = ObtenerValorTextBox(txtTotalCajaDolares);

            // 3. Calcula las diferencias si falta o sobra
            CalcularDiferencias(totalCordobas, totalCalculadoCordobas,
                               txtFaltanteCordobas, txtSobranteCordobas);

            CalcularDiferencias(totalDolares, totalCalculadoDolares,
                               txtFaltanteDolares, txtSobranteDolares);
                        
            totales.TotalCordobas = totalCordobas;
            totales.TotalDolares = totalDolares;
        }

        private void CalcularDiferencias(decimal efectivoFisico, decimal totalCalculado,
                                       TextBox txtFaltante, TextBox txtSobrante)
        {
            decimal diferencia = efectivoFisico - totalCalculado;

            // Verifica el faltante
            if (diferencia < 0) 
            {
                txtFaltante.Text = Math.Abs(diferencia).ToString("N2");
                txtSobrante.Text = "0.00";
            }

            //Verifica el sobrante
            else if (diferencia > 0)
            {
                txtSobrante.Text = diferencia.ToString("N2");
                txtFaltante.Text = "0.00";
            }
            // Si no hay diferencia
            else
            {
                txtFaltante.Text = "0.00";
                txtSobrante.Text = "0.00";
            }
        }

        private decimal ObtenerValorTextBox(TextBox textBox)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
                return 0;

            if (decimal.TryParse(textBox.Text, out decimal valor))
                return valor;

            return 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var aperturaForm = new Apertura_Caja();
            aperturaForm.OnAperturaCreada += RecargarDatosArqueo;
            aperturaForm.Show();
        }
        
        private void RecargarDatosArqueo()
        {
            
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(RecargarDatosArqueo));
            }
            else
            {
                Arqueo_Caja_Load(null, null);
                CalcularTotales();            
            }
        }

        private void btnCerrarCaja_Click(object sender, EventArgs e)
        {
            try
            {

                decimal totalCordobas = ObtenerValorTextBox(txtTotalEfectivoCordobas);
                decimal totalDolares = ObtenerValorTextBox(txtDolaresTotalEfectivo);

                if (totalCordobas <= 0 && totalDolares <= 0)
                {
                    MessageBox.Show("Debe ingresar al menos un valor en Córdobas o Dólares", "Validación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (var contexto = new DbTiendaSeptentrionContext())
                {
                    // Buscar todas las aperturas que aún no están cerradas
                    var aperturasAbiertas = contexto.AperturaCajas
                        .Where(a => a.EstadoApertura != "Cerrada")
                        .ToList();

                    if (!aperturasAbiertas.Any())
                    {
                        MessageBox.Show("No hay aperturas activas para cerrar.");
                        return;
                    }

                    // Cambiar el estado a "Cerrada"
                    foreach (var apertura in aperturasAbiertas)
                    {
                        apertura.EstadoApertura = "Cerrada";
                    }

                    contexto.SaveChanges();
                   
                    var servicio = new ArqueoDeCajaServicio(contexto);

                    servicio.ActualizarArqueoCaja(
                        totalEfectivoCordoba: float.Parse(txtTotalCajaCordobas.Text), 
                        totalEfectivoDolar: float.Parse(txtTotalCajaDolares.Text),
                        faltanteCordoba: string.IsNullOrEmpty(txtFaltanteCordobas.Text) ? null : float.Parse(txtFaltanteCordobas.Text),
                        faltanteDolar: string.IsNullOrEmpty(txtFaltanteDolares.Text) ? null : float.Parse(txtFaltanteDolares.Text),
                        sobranteCordoba: string.IsNullOrEmpty(txtSobranteCordobas.Text) ? null : float.Parse(txtSobranteCordobas.Text),
                        sobranteDolar: string.IsNullOrEmpty(txtSobranteDolares.Text) ? null : float.Parse(txtSobranteDolares.Text)
                    );

             

                    if (!aperturasAbiertas.Any())
                    {
                        MessageBox.Show("Caja cerrada.");
                        return;
                    }

                    // Cambiar el estado a "Cerrada"
                    foreach (var apertura in aperturasAbiertas)
                    {
                        apertura.EstadoApertura = "Cerrada";
                    }
                    // Cambiar el estado a "Cerrada"
                    foreach (var apertura in aperturasAbiertas)
                    {
                        apertura.EstadoApertura = "Cerrada";
                    }

                    // Marcar ventas del día con EstadoFactura NULL
                    DateOnly hoy = DateOnly.FromDateTime(DateTime.Today);
                    var ventasSinEstado = contexto.Venta
                        .Where(v => v.FechaVenta == hoy && v.CambiosFactura == null)
                        .ToList();

                    foreach (var venta in ventasSinEstado)
                    {
                        venta.CambiosFactura = "Tomada en Arqueo";
                    }

                    try
                    {
                        int afectadas = contexto.Database.ExecuteSqlRaw(@"
                            UPDATE d
                            SET d.CambiosDevolucion = 'Tomada en Arqueo'
                            FROM [dbo].[DetalleDevolucion] d
                            WHERE (d.CambiosDevolucion IS NULL OR LTRIM(RTRIM(d.CambiosDevolucion)) = '')
                              AND CONVERT(date, d.FechaDevolucion) = CONVERT(date, GETDATE());
                        ");
                    }
                    catch (Exception exDevs)
                    {

                    }


                    var abonosParaActualizar = contexto.DetalleCreditos
                             .Where(d => d.Observaciones != null &&
                  d.Observaciones.StartsWith("Pago realizado el") &&
                  d.Observaciones.Contains("Sin tomar en arqueo"))
                            .ToList();

                    

                    foreach (var abono in abonosParaActualizar)
                    {
                        var match = Regex.Match(abono.Observaciones, @"Pago realizado el (\d{2}/\d{2}/\d{4} \d{2}:\d{2})");

                        if (match.Success)
                        {
                            string fechaTexto = match.Groups[1].Value;

                            if (DateTime.TryParseExact(fechaTexto, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fechaPago))
                            {
                                if (DateOnly.FromDateTime(fechaPago.Date) == hoy)
                                {
                                    abono.Observaciones = abono.Observaciones.Replace("Sin tomar en arqueo", "Tomado en arqueo");
                                }
                            }
                        }
                    }

                    Arqueo_Caja_Load(null, null);

                    contexto.SaveChanges();
                }
                MessageBox.Show("Datos guardados correctamente.", "Caja cerrada, no se pueden realizar más operaciones.");
                BloquearBotones();
                RecargarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}");
            }
        }

        private void BloquearBotones()
        {
            btnCerrarCaja.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var menuForm = this.MdiParent as menu;
            if (menuForm == null)
            {
                menuForm = Application.OpenForms.OfType<menu>().FirstOrDefault();
            }
            if (menuForm != null)
            {
                menuForm.AbrirformInPanel(new Egresos());
            }
        }

        public void Arqueo_Caja_Load(object sender, EventArgs e)
        {
            try
            {
                // Cargar fecha actual y usuario
                txtFechaActual.Text = DateTime.Now.ToString("dd/MM/yyyy");
                txtNomreUsuario.Text = Login.UsuarioActivo.ObtenerNombreCompletoUsuario();

                var fechaActual = DateOnly.FromDateTime(DateTime.Now);

                using (var contexto = new DbTiendaSeptentrionContext())
                {
                    var egresoServicio = new EgresoServicio(contexto);

                    // Cargar apertura de caja
                    var aperturas = egresoServicio.ListarAperturaCaja(fechaActual);
                    var aperturaHoy = aperturas.FirstOrDefault();
                    txtAperturaCaja.Text = aperturaHoy?.MontoApertura.ToString("N2") ?? "0.00";

                    // Cargar Total Abonos
                    decimal totalAbonosCordobas = egresoServicio.ObtenerTotalAbonosCordobas(fechaActual);
                    txtTotalAbono.Text = totalAbonosCordobas.ToString("N2");

                    // Cargar totales BRUTOS
                    decimal totalBrutoCordobas = egresoServicio.ObtenerTotalBrutoCordobas(fechaActual);
                    decimal totalBrutoDolares = egresoServicio.ObtenerTotalBrutoDolares(fechaActual);

                   txtTotalCajaCordobas.Text = totalBrutoCordobas.ToString("N2");
                    txtTotalCajaDolares.Text = totalBrutoDolares.ToString("N2");

                    // Cargar total de egresos
                    decimal totalEgresosCordobas = egresoServicio.ObtenerTotalEgresosCordobas(fechaActual);
                    decimal totalEgresosDolares = egresoServicio.ObtenerTotalEgresosDolares(fechaActual);

                    txtTotalEgresosCordobas.Text = totalEgresosCordobas.ToString("N2");
                    txtTotalEgresosDolares.Text = totalEgresosDolares.ToString("N2");
                    if (!ValidarCalculos()) return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool ValidarCalculos()
        {
            try
            {
                decimal totalCalculadoCordobas = decimal.Parse(txtTotalCajaCordobas.Text);
                decimal totalEfectivoCordobas = decimal.Parse(txtTotalEfectivoCordobas.Text);

                decimal diferenciaCordobas = totalEfectivoCordobas - totalCalculadoCordobas;
                decimal faltanteSobranteCordobas = string.IsNullOrEmpty(txtFaltanteCordobas.Text) ? 0 :
                                                  decimal.Parse(txtFaltanteCordobas.Text) -
                                                  (string.IsNullOrEmpty(txtSobranteCordobas.Text) ? 0 :
                                                  decimal.Parse(txtSobranteCordobas.Text));

                if (Math.Abs(diferenciaCordobas - faltanteSobranteCordobas) > 0.01m)
                {

                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        private void GuardarEnCache()
        {
            // Guardar valores de córdobas
            CacheArqueo.Guardar("MilCordobas", txtMilCordobas.Text);
            CacheArqueo.Guardar("QuinientosCordobas", txtQuinientosCordobas.Text);
            CacheArqueo.Guardar("DocientosCordobas", txtDocientosCordobas.Text);
            CacheArqueo.Guardar("CienCordobas", txtCienCordobas.Text);
            CacheArqueo.Guardar("CincuentaCordobas", txtCincuentaCordobas.Text);
            CacheArqueo.Guardar("VeinteCordobas", txtVeinteCordobas.Text);
            CacheArqueo.Guardar("DiezCordobas", txtDiezCordobas.Text);
            CacheArqueo.Guardar("CincoCordobas", txtCincoCordobas.Text);
            CacheArqueo.Guardar("UnCordobas", txtUnCordobas.Text);
            CacheArqueo.Guardar("CincuentaCentavosCordobas", txtCincuentaCentavosCordobas.Text);
            CacheArqueo.Guardar("VeinticincoCentavosCordobas", txtVeinticincoCentavosCordobas.Text);
    

            // Guardar valores de dólares
            CacheArqueo.Guardar("CienDolares", txtCienDolares.Text);
            CacheArqueo.Guardar("CincuentaDolares", txtCincuentaDolares.Text);
            CacheArqueo.Guardar("VeinteDolares", txtVeinteDolares.Text);
            CacheArqueo.Guardar("DiezDolares", txtDiezDolares.Text);
            CacheArqueo.Guardar("CincoDolares", txtCincoDolares.Text);
            CacheArqueo.Guardar("UnDolar", txtUnDolar.Text);
            CacheArqueo.Guardar("CincuentaCentavosDolares", txtCincuentaCentavosDolares.Text);
            
        }

        private void CargarDesdeCache()
        {
            // Cargar córdobas
            txtMilCordobas.Text = CacheArqueo.Obtener("MilCordobas");
            txtQuinientosCordobas.Text = CacheArqueo.Obtener("QuinientosCordobas");
            txtDocientosCordobas.Text = CacheArqueo.Obtener("DocientosCordobas");
            txtCienCordobas.Text = CacheArqueo.Obtener("CienCordobas");
            txtCincuentaCordobas.Text = CacheArqueo.Obtener("CincuentaCordobas");
            txtVeinteCordobas.Text = CacheArqueo.Obtener("VeinteCordobas");
            txtDiezCordobas.Text = CacheArqueo.Obtener("DiezCordobas");
            txtCincoCordobas.Text = CacheArqueo.Obtener("CincoCordobas");
            txtUnCordobas.Text = CacheArqueo.Obtener("UnCordobas");
            txtCincuentaCentavosCordobas.Text = CacheArqueo.Obtener("CincuentaCentavosCordobas");
            txtVeinticincoCentavosCordobas.Text = CacheArqueo.Obtener("VeinticincoCentavosCordobas");
            
            // Cargar dólares
            txtCienDolares.Text = CacheArqueo.Obtener("CienDolares");
            txtCincuentaDolares.Text = CacheArqueo.Obtener("CincuentaDolares");
            txtVeinteDolares.Text = CacheArqueo.Obtener("VeinteDolares");
            txtDiezDolares.Text = CacheArqueo.Obtener("DiezDolares");
            txtCincoDolares.Text = CacheArqueo.Obtener("CincoDolares");
            txtUnDolar.Text = CacheArqueo.Obtener("UnDolar");
            txtCincuentaCentavosDolares.Text = CacheArqueo.Obtener("CincuentaCentavosDolares");

            // Recalcular totales
            CalcularTotales();
        }

        private void ActualizarDatosEgresos()
        {
            try
            {
                var fechaActual = DateOnly.FromDateTime(DateTime.Now);

                using (var contexto = new DbTiendaSeptentrionContext())
                {
                    var egresoServicio = new EgresoServicio(contexto);
                    decimal totalEgresosCordobas = egresoServicio.ObtenerTotalEgresosCordobas(fechaActual);
                    decimal totalEgresosDolares = egresoServicio.ObtenerTotalEgresosDolares(fechaActual);

                    txtTotalEgresosCordobas.Text = totalEgresosCordobas.ToString("N2");
                    txtTotalEgresosDolares.Text = totalEgresosDolares.ToString("N2");

                    decimal totalBrutoCordobas = egresoServicio.ObtenerTotalBrutoCordobas(fechaActual);
                    decimal totalBrutoDolares = egresoServicio.ObtenerTotalBrutoDolares(fechaActual);

                    txtTotalCajaCordobas.Text = totalBrutoCordobas.ToString("N2");
                    txtTotalCajaDolares.Text = totalBrutoDolares.ToString("N2");
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            GuardarEnCache(); 
            this.Hide(); 
            CargarDesdeCache(); 
            ActualizarDatosEgresos();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var menuForm = this.MdiParent as menu;
            if (menuForm == null)
            {
                menuForm = Application.OpenForms.OfType<menu>().FirstOrDefault();
            }
            if (menuForm != null)
            {
                menuForm.AbrirformInPanel(new ControldeEgresos());
            }
        }

        private void RecargarFormulario()
        {
            if (this.IsDisposed) return;

            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action(RecargarFormulario));
                return;
            }

            CacheArqueo.Limpiar();       
            LimpiarCamposVisuales();   

            txtFechaActual.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtNomreUsuario.Text = Login.UsuarioActivo.ObtenerNombreCompletoUsuario();

        }


        private void EtiquetarCamposParaLimpieza()
        {
            // Cantidades y totales en Córdobas
            txtMilCordobas.Tag = "clear";
            txtQuinientosCordobas.Tag = "clear";
            txtDocientosCordobas.Tag = "clear";
            txtCienCordobas.Tag = "clear";
            txtCincuentaCordobas.Tag = "clear";
            txtVeinteCordobas.Tag = "clear";
            txtDiezCordobas.Tag = "clear";
            txtCincoCordobas.Tag = "clear";
            txtUnCordobas.Tag = "clear";
            txtCincuentaCentavosCordobas.Tag = "clear";
            txtVeinticincoCentavosCordobas.Tag = "clear";

            txtMilCordobasTotal.Tag = "total0";
            txtQuinientosCordobasTotal.Tag = "total0";
            txtDocientosCordobasTotal.Tag = "total0";
            txtCienCordobasTotal.Tag = "total0";
            txtCincuentaCordobasTotal.Tag = "total0";
            txtVeinteCordobasTotal.Tag = "total0";
            txtDiezCordobasTotal.Tag = "total0";
            txtCincoCordobasTotal.Tag = "total0";
            txtUnCordobasTotal.Tag = "total0";
            txtCincuentaCentavosCordobasTotal.Tag = "total0";
            txtVeinticincoCentavosCordobasTotal.Tag = "total0";

            // Dólares
            txtCienDolares.Tag = "clear";
            txtCincuentaDolares.Tag = "clear";
            txtVeinteDolares.Tag = "clear";
            txtDiezDolares.Tag = "clear";
            txtCincoDolares.Tag = "clear";
            txtUnDolar.Tag = "clear";
            txtCincuentaCentavosDolares.Tag = "clear";

            txtCienDolaresTotal.Tag = "total0";
            txtCincuentaDolaresTotal.Tag = "total0";
            txtVeinteDolaresTotal.Tag = "total0";
            txtDiezDolaresTotal.Tag = "total0";
            txtCincoDolaresTotal.Tag = "total0";
            txtUnDolarTotal.Tag = "total0";
            txtCincuentaCentavosDolaresTotal.Tag = "total0";

            // Totales y diferencias
            txtTotalEfectivoCordobas.Tag = "total0";
            txtDolaresTotalEfectivo.Tag = "total0";
            txtFaltanteCordobas.Tag = "total0";
            txtSobranteCordobas.Tag = "total0";
            txtFaltanteDolares.Tag = "total0";
            txtSobranteDolares.Tag = "total0";

            // Si quieres también dejar en 0 los "calculados" del panel de detalles:
            txtTotalCajaCordobas.Tag = "total0";
            txtTotalCajaDolares.Tag = "total0";
            txtTotalEgresosCordobas.Tag = "total0";
            txtTotalEgresosDolares.Tag = "total0";
            txtTotalAbono.Tag = "total0";
        }

        private void LimpiarCamposVisuales()
        {
            RecorrerTextBoxes(this, tb =>
            {
                if (tb.Tag as string == "clear")
                    tb.Text = string.Empty;
            });

            RecorrerTextBoxes(this, tb =>
            {
                if (tb.Tag as string == "total0")
                    tb.Text = "0.00";
            });

            CalcularTotales();

            BloquearBotones();

            this.Invalidate(true);
            this.Update();
        }

        private void RecorrerTextBoxes(Control root, Action<TextBox> action)
        {
            foreach (Control c in root.Controls)
            {
                if (c is TextBox tb) action(tb);
                if (c.HasChildren) RecorrerTextBoxes(c, action);
            }
        }



    }


}