using formstienda.capa_de_negocios;
using formstienda.Datos;
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
using formstienda.Datos;

namespace formstienda.capa_de_presentación
{
    public partial class Clientes : Form
    {
        private ClienteServicio? clienteServicio;
        private BindingList<Cliente>? Listacliente;
        
        public Clientes()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Clientes_Load(object sender, EventArgs e)
        {
            cargarclientes();

        }
        private void cargarclientes()
        {
            // instanciar usuario servicio
            clienteServicio = new ClienteServicio();
            Listacliente = new BindingList<Cliente>(clienteServicio.Listaclientes());
            DGCLIENTES.DataSource = Listacliente;

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void btnregistrar_Click(object sender, EventArgs e, string telefonoCliente)
        {
            // validar si ya existe el usuario

        }

        private void Clientes_Load_1(object sender, EventArgs e)
        {
            cargarclientes();
            lblcolilla.Visible = false;
            txtcolillainss.Visible = false;
        }

        private void btnregistrar_Click(object sender, EventArgs e)
        {
            
            var cliente = new Cliente
            {
                NombreCliente = txtnombrecliente.Text,
                ApellidoCliente = txtapellidocliente.Text,
                DireccionCliente = txtdireccion.Text,
                CedulaCliente = txtcedula.Text,
                ColillaInssCliente = txtcolillainss.Text,
                SujetoCredito = rbsi.Checked ? (bool?)true : (bool?)false,
                TelefonoCliente = txttelefonocliente.Text
            };
            var clienteExistente = clienteServicio?.Listaclientes()
                                                  .FirstOrDefault(p => p.TelefonoCliente == cliente.TelefonoCliente);
            if (clienteExistente != null)
            {
                MessageBox.Show("Este cliente ya existe, agregue otro telefono");
                return;
            }
            clienteServicio?.Agregarcliente(cliente);
            Listacliente?.Add(cliente);
            MessageBox.Show("Cliente agregado correctamente");
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            lblcolilla.Visible = true;
            txtcolillainss.Visible = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            lblcolilla.Visible = false;
            txtcolillainss.Visible = false; 
        }
    }
}
