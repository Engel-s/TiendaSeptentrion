using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.ApplicationServices;
using formstienda.Acceso_Datos.Sqlserver;

namespace formstienda
{
    public partial class Recuperarcontraseña : Form
    {
        public Recuperarcontraseña()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            string correoUsuario = txtrecuperar.Text; // Capturamos el correo ingresado por el usuario

            // Validamos que el campo no esté vacío
            if (string.IsNullOrEmpty(correoUsuario))
            {
                MessageBox.Show("Por favor, ingresa tu correo electrónico.");
                return;
            }

            // Llamamos al método para recuperar la contraseña
            Datosusuario datosUsuario = new Datosusuario();
            string mensaje = datosUsuario.recoverpassword(correoUsuario);

            // Mostramos el resultado al usuario
            MessageBox.Show(mensaje);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login form = new Login();
            form.Show();
            this.Close ();
        }
    }
}
