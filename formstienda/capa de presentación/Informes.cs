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

        private void btngenerarinformeventas_Click(object sender, EventArgs e)
        {
            DateTime fechaInicio = dtpickerventasinicio.Value.Date;
            DateTime fechaFin = dtpickerventasfinal.Value.Date;

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
