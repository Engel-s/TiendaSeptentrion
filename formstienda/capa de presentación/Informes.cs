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
            ReporteDeInventario reporte = new ReporteDeInventario();
            reporte.Show();
        }
    }
}
