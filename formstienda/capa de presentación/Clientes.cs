using formstienda.capa_de_negocios;
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
            // Crear cliente con valores limpios
            var cliente = new Cliente
            {
                NombreCliente = txtnombrecliente.Text.Trim(),
                ApellidoCliente = txtapellidocliente.Text.Trim(),
                DireccionCliente = txtdireccion.Text.Trim(),
                CedulaCliente = txtcedula.Text.Trim(),
                ColillaInssCliente = txtcolillainss.Text.Trim(),
                SujetoCredito = rbsi.Checked ? (bool?)true : (bool?)false,
                TelefonoCliente = new string(txttelefonocliente.Text.Trim().Where(char.IsDigit).ToArray())
            };

            // Validar campos obligatorios
            if (string.IsNullOrWhiteSpace(cliente.NombreCliente) ||
                string.IsNullOrWhiteSpace(cliente.ApellidoCliente) ||
                string.IsNullOrWhiteSpace(cliente.DireccionCliente) ||
                string.IsNullOrWhiteSpace(cliente.CedulaCliente) ||

                string.IsNullOrWhiteSpace(cliente.TelefonoCliente))
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios.");
                return;
            }

            // Validar teléfono (solo números y entre 10 y 15 dígitos)
            //if (cliente.TelefonoCliente.Length < 10 || cliente.TelefonoCliente.Length > 15)
            //{
            //    MessageBox.Show("Ingrese un número de teléfono válido (entre 10 y 15 dígitos).");
            //    return;
            //}

            // Validar si ya existe cliente con ese teléfono
            var clienteExistente = clienteServicio?.Listaclientes()
                                                  .FirstOrDefault(p => p.TelefonoCliente == cliente.TelefonoCliente);
            if (clienteExistente != null)
            {
                MessageBox.Show("Este cliente ya existe, agregue otro teléfono.");
                return;
            }

            // Agregar cliente
            clienteServicio?.Agregarcliente(cliente);
            Listacliente?.Add(cliente);
            MessageBox.Show("Cliente agregado correctamente");

            // Limpiar campos después de guardar
            txtnombrecliente.Text = "";
            txtapellidocliente.Text = "";
            txtdireccion.Text = "";
            txtcedula.Text = "";
            txtcolillainss.Text = "";
            txttelefonocliente.Text = "";
            rbsi.Checked = false;
            rbno.Checked = true;
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
