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
        private UsuarioServicio? usuarioServicio;
        private BindingList<Usuario>? Listausuarios;
        public Usuarioadmin()
        {
            InitializeComponent();
           

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
                UsuarioLogueo = cbrolusuario.Text + txtnombreusuario.Text,
                TelefonoUsuario = txttelefonousuario.Text,
                EstadoUsuario = cbestadousuario.Text == "Activo" ? true : false,
            };
            var usuarioExistente = usuarioServicio?.Listausuarios()
                                                  .FirstOrDefault(p => p.CorreoUsuario == usuario.CorreoUsuario);
            if (usuarioExistente != null)
            {
                MessageBox.Show("Este usuario ya existe, agregue otro correo");
                return;
            }
            usuarioServicio?.AgregarUsuario(usuario);
            Listausuarios?.Add(usuario);
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
                    var usuarioSeleccionado = (Usuario)DGUSUARIOS.SelectedRows[0].DataBoundItem;
                    if (usuarioSeleccionado == null)
                    {
                        MessageBox.Show("No hay mas usuarios seleccionados");
                    }
                    else
                    {
                        var confirmacion = MessageBox.Show("Esta seguro_?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (confirmacion == DialogResult.Yes)
                        {
                            usuarioServicio?.Eliminarusuario(usuarioSeleccionado.IdUsuario);
                            Listausuarios?.Remove(usuarioSeleccionado);

                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void DGUSUARIOS_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int IdUsuario = (int)DGUSUARIOS.Rows[e.RowIndex].Cells["IdUsuario"].Value;
            //validacion 
            if (string.IsNullOrEmpty(DGUSUARIOS.Rows[e.RowIndex].Cells["NombreUsuario"].Value?.ToString()))
            {
                MessageBox.Show("El nombre no puede estar vacio o ser nulo");
                    return; 
            }
            var usuarioEditado = new Usuario
            {
                IdUsuario = IdUsuario,
                NombreUsuario = DGUSUARIOS.Rows[e.RowIndex].Cells["NombreUsuario"].Value?.ToString() ?? "",
                CorreoUsuario = DGUSUARIOS.Rows[e.RowIndex].Cells["CorreoUsuario"].Value?.ToString() ?? "",
                ApellidoUsuario = DGUSUARIOS.Rows[e.RowIndex].Cells["ApellidoUsuario"].Value?.ToString() ?? "",
                ContraseñaUsuario = DGUSUARIOS.Rows[e.RowIndex].Cells["ContraseñaUsuario"].Value?.ToString() ?? "",
                TelefonoUsuario = DGUSUARIOS.Rows[e.RowIndex].Cells["TelefonoUsuario"].Value?.ToString() ?? "",
                RolUsuario = DGUSUARIOS.Rows[e.RowIndex].Cells["RolUsuario"].Value?.ToString() ?? "",
                EstadoUsuario = Convert.ToBoolean(DGUSUARIOS.Rows[e.RowIndex].Cells["EstadoUsuario"].Value),


            };
            if (usuarioServicio.Actualizarusuario(usuarioEditado))
                MessageBox.Show("Usuario actualizado correctamente");
            else
                MessageBox.Show("No se pudo actualizar el usuario");
        }
    }

}
