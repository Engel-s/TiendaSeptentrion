using formstienda.capa_de_presentación;
using formstienda.Reporte;
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

        private void panel63_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void Cliente_Moroso_Click(object sender, EventArgs e)
        {
            DateTime fechaInicio = dtfechainiciodevoluciones.Value.Date;
            DateTime fechaFin = dtfechafinaldevoluciones.Value.Date;

            if (fechaFin > DateTime.Today)
            {
                MessageBox.Show("La fecha final no puede ser mayor a la fecha actual.", "Fecha no válida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Ruta única para guardar el PDF temporalmente
            string carpetaDestino = @"C:\ReportesTienda";
            if (!Directory.Exists(carpetaDestino))
            {
                Directory.CreateDirectory(carpetaDestino);
            }

            string fileName = $"ReporteDevoluciones_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";
            string filePath = Path.Combine(carpetaDestino, fileName);

            // Buscar instancia del menú principal
            var menuForm = this.MdiParent as capa_de_presentación.menu ?? Application.OpenForms.OfType<menu>().FirstOrDefault();

            if (menuForm != null)
            {
                // Abrir el reporte dentro del panel del menú principal
                menuForm.AbrirformInPanel(new Reporte_De_Cliente_Moroso(fechaInicio, fechaFin, filePath));
            }

            this.Close(); // Cerrar formulario actual
        }
    }
}
