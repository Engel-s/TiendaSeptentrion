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

namespace formstienda.capa_de_presentación
{
    public partial class Egresos : Form
    {
        private readonly EgresoServicio _egresoservicio;
        private readonly DbTiendaSeptentrionContext _contexto;

        public Egresos()
        {
            InitializeComponent();

            // Inicializar el contexto y el servicio
            _contexto = new DbTiendaSeptentrionContext();
            _egresoservicio = new EgresoServicio(_contexto);

            CargarEgresos();
        }

        private void CargarEgresos()
        {
            try
            {
                // Obtener la lista de aperturas de caja
                var aperturas = _egresoservicio.ListarAperturaCaja();

                // Calcular el total sumando todos los montos de apertura
                decimal? v = aperturas.Sum(a => a.MontoApertura);
                decimal total = (decimal)v;

                // Crear formato cultural para Nicaragua
                CultureInfo nicaragua = new CultureInfo("es-NI");

                // Mostrar el total en el TextBox con formato de moneda
                txtTotalCaja.Text = total.ToString("C2", nicaragua);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los egresos: {ex.Message}", "Error",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTotalCaja.Text = "C$0.00";
            }
        }
        


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {


            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void Egresos_Load(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

        }

        private void txtTotalCaja_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMotivoEgreso_TextChanged(object sender, EventArgs e)
        {

        }
    }
}