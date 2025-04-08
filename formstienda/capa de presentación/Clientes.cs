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
            var cliente = new Cliente();
            {
               ////no esta en uso la tabla/verificar si esta en uso 
               // NombreCliente = txtnombrecliente.Text;
               // Apellid = txtapellidocliente.Text;
               // DireccionCliente = txtdireccion.Text;
               // ColillaInssCliente = txtcolillainss;
               // TelefonoCliente = txttelefonocliente.Text;
            }
            ;
            var clienteExistente = clienteServicio.Listaclientes().FirstOrDefault(p => p.TelefonoCliente == cliente.TelefonoCliente);
            if (clienteExistente == null)
            {
                MessageBox.Show("Este cliente ya esta registrado, agregue otro numero");
                return;
            }
            clienteServicio.Agregarcliente(clienteExistente);
            Listacliente.Add(cliente);
            MessageBox.Show("Cliente registrado correctamente");
        }

        private void Clientes_Load_1(object sender, EventArgs e)
        {
            cargarclientes();
        }
    }
}
