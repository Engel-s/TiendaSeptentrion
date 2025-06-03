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
            cargarproveedores();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DateTime fechaInicio = dptInicio.Value.Date;
            DateTime fechaFin = dtpFin.Value.Date;

            string proveedorSeleccionado = (cmbproveedor.SelectedValue as string)?.Trim();

            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "PDF files (*.pdf)|*.pdf";
                saveDialog.Title = "Guardar reporte de compras";
                saveDialog.FileName = $"ReporteCompras_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    string rutaPDF = saveDialog.FileName;

                    
                    FormReportesCompras generador = new FormReportesCompras(fechaInicio, fechaFin, rutaPDF);
                    string rutaGenerada = generador.GenerarReporte(fechaInicio, fechaFin, rutaPDF, proveedorSeleccionado);

                    if (!string.IsNullOrEmpty(rutaGenerada))
                    {

                        FormReportesCompras visor = new FormReportesCompras(fechaInicio, fechaFin, rutaGenerada, proveedorSeleccionado);
                        visor.Show();
                    }
                }
            }
        }
    }
}
