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
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Informes_Load(object sender, EventArgs e)
        {

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
    }
}
