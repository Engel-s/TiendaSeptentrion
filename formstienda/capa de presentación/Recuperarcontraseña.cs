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
    public partial class Recuperarcontraseña : Form
    {
        private string correo;
        public Recuperarcontraseña()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login form = new Login();
            form.Show();
            this.Close();
        }

        private void Recuperarcontraseña_Load(object sender, EventArgs e)
        {

        }

        private void txtCorreoRecuperacion_TextChanged(object sender, EventArgs e)
        {
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Cambiar_contraseña cambiar_Contraseña = new Cambiar_contraseña(correo);
            cambiar_Contraseña.Show();
        }

        private void btnIniciarSesion_Click_1(object sender, EventArgs e)
        {

            correo = txtCorreoRecuperacion.Text.Trim();
            var usuariovariable = new ClienteServicio();
            bool existoso = usuariovariable.EnviarCodigoRecuperacion(correo);

            if (existoso)
            {
                MessageBox.Show("Se ha enviado el correo exitosamente");
            }
            else
            {
                MessageBox.Show("No se ha enviado el correo debido a un error");

                Login form1 = new Login();
                form1.Show();
                this.Close();
            }
        }
    }
    
}
