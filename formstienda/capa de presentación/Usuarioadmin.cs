using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using formstienda;
using formstienda.capa_de_negocios;
using formstienda.Datos;

namespace formstienda
{
    public partial class Usuarioadmin : Form
    {
        private UserManager userManager;
        private UsuarioServicio? usuarioServicio;
        private BindingList<Usuario>? Listausuarios;
        public Usuarioadmin()
        {
            InitializeComponent();
            userManager = UserManager.Instance;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {


            this.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnnuevo_Click(object sender, EventArgs e)
        {
            // validar si ya existe el usuario
            var usuario = new Usuario
            {
                NombreUsuario = txtnombreusuario.Text,
                ApellidoUsuario = txtapellidousuario.Text,
                CorreoUsuario = txtcorreousuario.Text,
                ContraseñaUsuario = txtpassword.Text,
                RolUsuario = cbrolusuario.Text,
                //usuariologueo = cbrolusuario.text + txtnombreusuario.text,
                TelefonoUsuario = txttelefonousuario.Text
            };
            var usuarioExistente = usuarioServicio.Listausuarios()
                                                  .FirstOrDefault(p => p.CorreoUsuario == usuario.CorreoUsuario);
            if (usuarioExistente != null)
            {
                MessageBox.Show("Este usuario ya existe, agregue otro correo");
                return;
            }
            usuarioServicio.AgregarUsuario(usuario);
            Listausuarios.Add(usuario);
            MessageBox.Show("Usuario agregado correctamente");
        }

        private void cargarusuarios()
        {
            // instanciar usuario servicio
            usuarioServicio = new UsuarioServicio();
            //listar
            Listausuarios = new BindingList<Usuario>(usuarioServicio.Listausuarios());
            DGUSUARIOS.DataSource = Listausuarios;
        }
        private void Form9_Load(object sender, EventArgs e)
        {


            cargarusuarios();

        }

        private void DGUSUARIOS_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtrol_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnactualizar_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGUSUARIOS.SelectedRows.Count == 0)
                {
                    MessageBox.Show("No es posible eliminar usuarios");
                    return;
                }
                else if (DGUSUARIOS.SelectedRows.Count == 1)
                {
                    var usuarioSeleccionado = (Usuario)DGUSUARIOS.SelectedRows[0] .DataBoundItem;
                    if (usuarioSeleccionado==null )
                    {
                        MessageBox.Show("No hay mas usuarios seleccionados");
                    }
                    else
                    {
                        var confirmacion = MessageBox.Show("Esta seguro_?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (confirmacion == DialogResult.Yes) 
                        {
                            usuarioServicio.Eliminarusuario(usuarioSeleccionado.IdUsuario);
                            Listausuarios.Remove(usuarioSeleccionado);

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                
            }
        }
    }
}
