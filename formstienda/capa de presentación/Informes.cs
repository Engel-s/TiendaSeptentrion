using formstienda.capa_de_presentación;
using formstienda.Datos;
using formstienda.capa_de_presentación;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace formstienda
{
    public partial class Informes : Form
    {
        public Informes()
        {
            InitializeComponent();
            dateTimePickerFechaInicial.Value = DateTime.Today.AddDays(-7); // Establecer fecha inicial 7 días atrás
            dateTimePickerFechaFinal.Value = DateTime.Today;
            dateTimePickerFechaInicialMotivo.Value = DateTime.Today.AddDays(-7); // Establecer fecha inicial 7 días atrás
            dateTimePickerFechaFinalMotivo.Value = DateTime.Today;
            CargarUsuariosEnComboBox();
            CargarMotivosEnComboBox();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Informes_Load(object sender, EventArgs e)
        {
            CargarUsuariosEnComboBox();
        }

        private void CargarUsuariosEnComboBox()
        {
            try
            {
                // Obtener todos los usuarios activos desde la base de datos
                using (var context = new DbTiendaSeptentrionContext())
                {
                    var usuarios = context.Usuarios
                        .Where(u => u.EstadoUsuario)
                        .OrderBy(u => u.NombreUsuario)
                        .ToList();


                    cmbUsuarioReporte.Items.Clear();
                    cmbUsuarioReporte.Items.Add("");

                    // Añadir los nombres completos de los usuarios
                    foreach (var usuario in usuarios)
                    {
                        cmbUsuarioReporte.Items.Add($"{usuario.NombreUsuario} {usuario.ApellidoUsuario}");
                    }

                    cmbUsuarioReporte.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los usuarios: {ex.Message}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGenerarReporteInventario_Click(object sender, EventArgs e)
        {
            try
            {

                string tempFilePath = Path.Combine(
                    Path.GetTempPath(),
                    $"Reporte_Inventario_{DateTime.Now:yyyyMMddHHmmss}.pdf"
                );

                ReporteDeInventario reporte = new ReporteDeInventario();
                reporte.GenerarPDF(tempFilePath);

                reporte.MostrarPDF(tempFilePath);
                reporte.Show();

                MessageBox.Show("Reporte generado", "Éxito",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGenerarReporteStock_Click(object sender, EventArgs e)
        {
            try
            {
                string tempFilePath = Path.Combine(
                    Path.GetTempPath(),
                    $"Reporte_Stock_Proximo_Agotarse_{DateTime.Now:yyyyMMddHHmmss}.pdf"
                );

                // Crear instancia del formulario de reporte
                ReporteStocks reporte = new ReporteStocks();

                // Generar y mostrar el reporte
                reporte.GenerarPDFStock(tempFilePath);
                reporte.MostrarPDF(tempFilePath);
                reporte.Show();

                MessageBox.Show("Reporte de productos próximos a agotarse generado con éxito",
                              "Éxito",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el reporte: {ex.Message}",
                              "Error",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }
        }

        private void btnGenerarArqueo_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar fechas
                if (dateTimePickerFechaInicial.Value > dateTimePickerFechaFinal.Value)
                {
                    MessageBox.Show("La fecha inicial no puede ser mayor que la fecha final", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (dateTimePickerFechaInicial.Value < DateTime.Today.AddYears(-1) ||
                    dateTimePickerFechaFinal.Value > DateTime.Today)
                {
                    MessageBox.Show("Las fechas deben estar dentro del último año y no pueden ser futuras", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string tempFilePath = Path.Combine(
                    Path.GetTempPath(),
                    $"Reporte_Arqueo_{DateTime.Now:yyyyMMddHHmmss}.pdf"
                );

                // Crear instancia del formulario de reporte con los parámetros
                ReporteArqueo reporte = new ReporteArqueo(
                    dateTimePickerFechaInicial.Value,
                    dateTimePickerFechaFinal.Value,
                    cmbUsuarioReporte.Text.Trim()
                );

                // Generar y mostrar el reporte
                reporte.GenerarPDF(tempFilePath);
                reporte.MostrarPDF(tempFilePath);
                reporte.Show();

                MessageBox.Show("Reporte de arqueo generado con éxito", "Éxito",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el reporte: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        }

        private void btngenerarinformeventas_Click(object sender, EventArgs e)
        {
            DateTime fechaInicio = dtpickerventasinicio.Value.Date;
            DateTime fechaFin = dtpickerventasfinal.Value.Date;

        private void btnMotivo_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar fechas
                if (dateTimePickerFechaInicialMotivo.Value > dateTimePickerFechaFinalMotivo.Value)
                {
                    MessageBox.Show("La fecha inicial no puede ser mayor que la fecha final", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string tempFilePath = Path.Combine(
                    Path.GetTempPath(),
                    $"Reporte_Otras_Salidas_{DateTime.Now:yyyyMMddHHmmss}.pdf"
                );

                // Crear instancia del formulario de reporte con los parámetros
                ReporteOtrasSalidas reporte = new ReporteOtrasSalidas(
                    dateTimePickerFechaInicialMotivo.Value,
                    dateTimePickerFechaFinalMotivo.Value,
                    cmbMotivo.Text.Trim()
                );

                // Generar y mostrar el reporte
                reporte.GenerarPDF(tempFilePath);
                reporte.MostrarPDF(tempFilePath);
                reporte.Show();

                MessageBox.Show("Reporte de otras salidas generado con éxito", "Éxito",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el reporte: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Cargar motivos en el ComboBox
        private void CargarMotivosEnComboBox()
        {
            try
            {
                using (var context = new DbTiendaSeptentrionContext())
                {
                    var motivos = context.VistaSalidasInventarioPorPeriodoMotivos
                        .Select(s => s.MotivoSalida)
                        .Distinct()
                        .OrderBy(m => m)
                        .ToList();

                    cmbMotivo.Items.Clear();
                    cmbMotivo.Items.Add("");

                    foreach (var motivo in motivos)
                    {
                        cmbMotivo.Items.Add(motivo);
                    }

                    cmbMotivo.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los motivos: {ex.Message}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // 2️⃣ Generar ruta PDF en el escritorio
            string rutaEscritorio = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string nombreArchivo = $"ReporteVentas_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";
            string rutaPdf = Path.Combine(rutaEscritorio, nombreArchivo);

            // 3️⃣ Crear y mostrar el formulario del visor con WebView
            var visor = new reporteventas(fechaInicio, fechaFin, rutaPdf);
            visor.Show();
        }
    }
}
