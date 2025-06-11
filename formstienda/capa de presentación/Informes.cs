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
using formstienda.capa_de_negocios;
using formstienda.capa_de_presentación;
using formstienda.Datos;

namespace formstienda
{
    public partial class Informes : Form
    {
        private ProveedorServicio _proveedorServicio;
        private BindingList<Proveedor> _proveedores;
        public Informes()
        {
            InitializeComponent();
            dateTimePickerFechaInicial.Value = DateTime.Today.AddDays(-7); // Establecer fecha inicial 7 días atrás
            dateTimePickerFechaFinal.Value = DateTime.Today;
            dateTimePickerFechaInicialMotivo.Value = DateTime.Today.AddDays(-7); // Establecer fecha inicial 7 días atrás
            dateTimePickerFechaFinalMotivo.Value = DateTime.Today;
            dptInicio.Value = DateTime.Today.AddDays(-7); 
            dtpFin.Value = DateTime.Today;                
            CargarUsuariosEnComboBox();
            CargarMotivosEnComboBox();

            _proveedores = new BindingList<Proveedor>();
        }

        private void cargarproveedores()
        {
            try
            {
                ProveedorServicio proveedorservicio = new ProveedorServicio();
                var proveedor = proveedorservicio.ListarProveedores();

                cmbproveedor.DataSource = proveedor;
                cmbproveedor.DisplayMember = "NombreProveedor";
                cmbproveedor.ValueMember = "CodigoRuc";
                cmbproveedor.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar proveedores: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Informes_Load(object sender, EventArgs e)
        {
            CargarUsuariosEnComboBox();
            cargarproveedores();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DateTime fechaInicio = dptInicio.Value.Date;
            DateTime fechaFin = dtpFin.Value.Date;

            if (fechaFin > DateTime.Today)
            {
                MessageBox.Show("La fecha final no puede ser mayor a la fecha actual.", "Fecha no válida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string proveedorSeleccionado = (cmbproveedor.SelectedValue as string)?.Trim();

            // Generar ruta temporal para el PDF
            string rutaTemporal = Path.Combine(
                Path.GetTempPath(),
                $"ReporteCompras_{DateTime.Now:yyyyMMdd_HHmmss}_{Guid.NewGuid()}.pdf"
            );

            //Aqui se busca la instancia del formulario de menu
            var menuForm = this.MdiParent as menu;
            if (menuForm == null)
            {
                menuForm = Application.OpenForms.OfType<menu>().FirstOrDefault();
            }

            if (menuForm != null)
            {
                // con esto se abre el reporte dentro del panel del formulario de menu
                menuForm.AbrirformInPanel(new FormReportesCompras(fechaInicio, fechaFin, rutaTemporal, proveedorSeleccionado));
            }

            // para cerrar el formulario de informes
            this.Close();
       

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

                var menuForm = this.MdiParent as menu;
                if (menuForm == null)
                {
                    menuForm = Application.OpenForms.OfType<menu>().FirstOrDefault();
                }
                if (menuForm != null) 
                {
                    menuForm.AbrirformInPanel(new ReporteArqueo(
                        dateTimePickerFechaInicial.Value,
                        dateTimePickerFechaFinal.Value,
                        cmbUsuarioReporte.Text.Trim()
                    ));
                }

                // Generar y mostrar el reporte
                reporte.GenerarPDF(tempFilePath);
                reporte.MostrarPDF(tempFilePath);
                reporte.Show();

                MessageBox.Show("Reporte de arqueo generado con éxito", "Éxito",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close(); // Cerrar el formulario de informes después de generar el reporte
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el reporte: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btngenerarinformeventas_Click(object sender, EventArgs e)
        {
            DateTime fechaInicio = dtpickerventasinicio.Value.Date;
            DateTime fechaFin = dtpickerventasfinal.Value.Date;

            if (fechaFin > DateTime.Today)
            {
                MessageBox.Show("La fecha final no puede ser mayor a la fecha actual.", "Fecha no válida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Generar ruta temporal para el PDF
            string rutaTemporal = Path.Combine(
                Path.GetTempPath(),
                $"ReporteVentas_{DateTime.Now:yyyyMMdd_HHmmss}_{Guid.NewGuid()}.pdf"
            );

            // Buscar la instancia del formulario de menu
            var menuForm = this.MdiParent as menu;
            if (menuForm == null)
            {
                menuForm = Application.OpenForms.OfType<menu>().FirstOrDefault();
            }

            if (menuForm != null)
            {
                // Abrir el reporte dentro del panel del formulario de menu
                menuForm.AbrirformInPanel(new reporteventas(fechaInicio, fechaFin, rutaTemporal));
            }

            // Cerrar el formulario actual de informes
            this.Close();
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
              
            }
        }

        private void btnreportdevoluciones_Click(object sender, EventArgs e)
        {
            DateTime fechainicio = dtfechainiciodevoluciones.Value.Date;
            DateTime fechafin = dtfechafinaldevoluciones.Value.Date;

            if (fechafin > DateTime.Today)
            {
                MessageBox.Show("La fecha final no puede ser mayor a la fecha actual.", "Fecha no válida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Generar ruta temporal para el PDF
            string rutaTemporal = Path.Combine(
                Path.GetTempPath(),
                $"ReporteDevoluciones_{DateTime.Now:yyyyMMdd_HHmmss}_{Guid.NewGuid()}.pdf"
            );

            // Buscar la instancia del formulario de menu
            var menuForm = this.MdiParent as menu;
            if (menuForm == null)
            {
                menuForm = Application.OpenForms.OfType<menu>().FirstOrDefault();
            }

            if (menuForm != null)
            {
                // Abrir el reporte dentro del panel del formulario de menu
                menuForm.AbrirformInPanel(new reportedevoluciones(fechainicio, fechafin, rutaTemporal));
            }

            // Cerrar el formulario actual
            this.Close();


        }

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
    }

}
