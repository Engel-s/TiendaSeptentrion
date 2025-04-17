using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using formstienda;
using formstienda.capa_de_presentación;

namespace formstienda
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            
        }

        private bool showpassword = false;

        [DllImport("user32.Dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.Dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg,
            int wparam, int lparam);

        private void sendlogin_Click(object sender, EventArgs e)
        {

        }
          

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtcontraseña_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            UserManager usermanager = UserManager.Instance; // Instancia de UserManager
            string username = txtusername.Text; // capturan datos
            string password = txtpassword.Text; // capturan datos

            if (txtusername.Text != "")
            {
                if (txtpassword.Text != "")
                {
                    using (var context = new DBTiendaSeptentrionContext())
                    {
                        var usuarioValido = context.Usuarios
                            .FirstOrDefault(u => u.UsuarioLogueo == usuario && u.ContraseñaUsuario == contraseña);

            if (userLog != null)
            {
                menu form = new menu();
                form.Show();
                Apertura_Caja apertura = new Apertura_Caja();
                apertura.Show();

                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario inexistente o incorrecto");// esas alertas seguro las cambio
            }

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Recuperarcontraseña form5 = new Recuperarcontraseña();
            form5.Show();
            this.Hide();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtusuario_Enter(object sender, EventArgs e)
        {
            if(txtusername.Text=="Usuario:")
            {
                txtusername.Text = "";
            }    
        }

        private void txtusuario_Leave(object sender, EventArgs e)
        {

        }

        private void txtusuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtcontraseña_Enter(object sender, EventArgs e)
        {

         

        }

        private void txtcontraseña_Leave(object sender, EventArgs e)
        {

        }

        private void btnminimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void txtpassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void pb_Password_Click(object sender, EventArgs e)
        {
            showpassword = !showpassword;
            if (showpassword)
            {
                txtpassword.UseSystemPasswordChar = false;
                pb_Password.Image = formstienda.Properties.Resources.Ocultar_Contraseña;
            }
            else
            {
                txtpassword.UseSystemPasswordChar = true;
                pb_Password.Image = formstienda.Properties.Resources.Mostrar_Contraseña;
            }
        }
    }
}
