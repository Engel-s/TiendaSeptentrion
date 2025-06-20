using formstienda;
using formstienda.capa_de_negocios;
using formstienda.Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace formstienda
{
    public partial class Usuarioadmin : Form
    {
        //private UserManager userManager;
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
            // Crear el objeto usuario
            var usuario = new Usuario
            {
                NombreUsuario = txtnombreusuario.Text.Trim(),
                ApellidoUsuario = txtapellidousuario.Text.Trim(),
                CorreoUsuario = txtcorreousuario.Text.Trim(),
                ContraseñaUsuario = txtpassword.Text,
                RolUsuario = cbrolusuario.Text,
                UsuarioLogueo = cbrolusuario.Text + txtnombreusuario.Text,
                TelefonoUsuario = txttelefonousuario.Text.Trim().Replace("-", ""),
                EstadoUsuario = cbestadousuario.Text == "Activo"
            };

            // Validaciones de campos vacíos
            if (string.IsNullOrWhiteSpace(usuario.NombreUsuario) ||
                string.IsNullOrWhiteSpace(usuario.ApellidoUsuario) ||
                string.IsNullOrWhiteSpace(usuario.CorreoUsuario) ||
                string.IsNullOrWhiteSpace(usuario.ContraseñaUsuario) ||
                string.IsNullOrWhiteSpace(usuario.RolUsuario) ||
                string.IsNullOrWhiteSpace(usuario.TelefonoUsuario))
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios.");
                return;
            }

            // Validar formato de correo electrónico
            if (!System.Text.RegularExpressions.Regex.IsMatch(usuario.CorreoUsuario, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Ingrese un correo electrónico válido.");
                return;
            }

            // Validar longitud de contraseña
            if (usuario.ContraseñaUsuario.Length < 9)
            {
                MessageBox.Show("La contraseña debe tener al menos 9 caracteres.");
                return;
            }

            // Validar que teléfono contenga solo números y tenga una longitud adecuada (ej: 10 dígitos)
            //if (!System.Text.RegularExpressions.Regex.IsMatch(usuario.TelefonoUsuario, @"^\d{8}$"))
            //{
            //    MessageBox.Show("Ingrese un número de teléfono válido (8 dígitos).");
            //    return;
            //}

            // Validar si el correo ya existe
            var usuarioExistente = usuarioServicio?.Listausuarios()
                                                  .FirstOrDefault(p => p.CorreoUsuario.Equals(usuario.CorreoUsuario, StringComparison.OrdinalIgnoreCase));
            if (usuarioExistente != null)
            {
                MessageBox.Show("Este usuario ya existe, agregue otro correo.");
                return;
            }

            // Agregar usuario
            usuarioServicio?.AgregarUsuario(usuario);
            Listausuarios?.Add(usuario);
            MessageBox.Show("Usuario agregado correctamente");

            // Limpiar los campos después de agregar
            txtnombreusuario.Text = "";
            txtapellidousuario.Text = "";
            txtcorreousuario.Text = "";
            txtpassword.Text = "";
            txttelefonousuario.Text = "";
            cbrolusuario.SelectedIndex = -1;
            cbestadousuario.SelectedIndex = -1;
        }

        private void cargarusuarios()
        {
            usuarioServicio = new UsuarioServicio();
            Listausuarios = new BindingList<Usuario>(usuarioServicio.Listausuarios());

            DGUSUARIOS.DataSource = null;
            DGUSUARIOS.Columns.Clear();
            DGUSUARIOS.AutoGenerateColumns = false;
            DGUSUARIOS.DataSource = Listausuarios;

            // Ocultar IdUsuario pero necesario
            DGUSUARIOS.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "IdUsuario",
                Name = "IdUsuario",
                Visible = false
            });

            // Columnas con nombres claros y consistentes
            DGUSUARIOS.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NombreUsuario",
                HeaderText = "Nombre",
                Name = "NombreUsuario"
            });
            DGUSUARIOS.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ApellidoUsuario",
                HeaderText = "Apellido",
                Name = "ApellidoUsuario"
            });
            DGUSUARIOS.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "CorreoUsuario",
                HeaderText = "Correo",
                Name = "CorreoUsuario"
            });
            DGUSUARIOS.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TelefonoUsuario",
                HeaderText = "Teléfono",
                Name = "TelefonoUsuario"
            });
            DGUSUARIOS.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "RolUsuario",
                HeaderText = "Rol",
                Name = "RolUsuario"
            });
            DGUSUARIOS.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "UsuarioLogueo",
                HeaderText = "Usuario",
                Name = "UsuarioLogueo"
            });

            // ComboBox para Estado con texto y mapeo bool <-> texto
            var estadoCombo = new DataGridViewComboBoxColumn
            {
                DataPropertyName = "EstadoUsuario",
                HeaderText = "Estado",
                Name = "EstadoUsuario",
                DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton,
                DataSource = new[]
                {
                    new { Texto = "Activo", Valor = true },
                    new { Texto = "Inactivo", Valor = false }
                },
                DisplayMember = "Texto",
                ValueMember = "Valor",
                FlatStyle = FlatStyle.Flat
            };
            DGUSUARIOS.Columns.Add(estadoCombo);

            // Estilo encabezados
            var headerStyle = DGUSUARIOS.ColumnHeadersDefaultCellStyle;
            headerStyle.Font = new Font(DGUSUARIOS.Font, FontStyle.Bold);
            headerStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            headerStyle.BackColor = Color.SteelBlue;
            headerStyle.ForeColor = Color.White;
            DGUSUARIOS.EnableHeadersVisualStyles = false;
        }

        private void Form9_Load(object sender, EventArgs e)
        {


            cargarusuarios();
          
            cbtipobusqueda.Items.Add("Usuario");
            cbtipobusqueda.Items.Add("Teléfono");
            cbtipobusqueda.SelectedIndex = 0; // Opcional: selecciona por defecto "Usuario"


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
            try
            {
                var fila = DGUSUARIOS.Rows[e.RowIndex];
                int IdUsuario = (int)fila.Cells["IdUsuario"].Value;

                string nombre = fila.Cells["NombreUsuario"].Value?.ToString()?.Trim() ?? "";
                string apellido = fila.Cells["ApellidoUsuario"].Value?.ToString()?.Trim() ?? "";
                string correo = fila.Cells["CorreoUsuario"].Value?.ToString()?.Trim() ?? "";
                string telefono = fila.Cells["TelefonoUsuario"].Value?.ToString()?.Trim() ?? "";
                string rol = fila.Cells["RolUsuario"].Value?.ToString()?.Trim() ?? "";
                string usuarioLogueo = fila.Cells["UsuarioLogueo"].Value?.ToString()?.Trim() ?? "";

                // Para ComboBox Estado obtenemos el valor booleano directo
                bool estado = false;
                var cellEstado = fila.Cells["EstadoUsuario"];
                if (cellEstado is DataGridViewComboBoxCell comboCell && comboCell.Value != null)
                {
                    estado = (bool)comboCell.Value;
                }
                else
                {
                    // Fallback en caso de problema
                    var estadoTexto = cellEstado.Value?.ToString() ?? "Inactivo";
                    estado = estadoTexto == "Activo";
                }

                // Validaciones
                if (string.IsNullOrWhiteSpace(nombre) ||
                    string.IsNullOrWhiteSpace(apellido) ||
                    string.IsNullOrWhiteSpace(correo) ||
                    string.IsNullOrWhiteSpace(telefono) ||
                    string.IsNullOrWhiteSpace(rol))
                {
                    MessageBox.Show("Todos los campos deben estar completos.");
                    // Opcional: cancelar edición o revertir
                    return;
                }

                if (!Regex.IsMatch(correo, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                {
                    MessageBox.Show("Correo electrónico inválido.");
                    return;
                }

                if (!Regex.IsMatch(telefono, @"^\d{8}$"))
                {
                    MessageBox.Show("El teléfono debe tener 8 dígitos numéricos.");
                    return;
                }

                var usuarioEditado = new Usuario
                {
                    IdUsuario = IdUsuario,
                    NombreUsuario = nombre,
                    ApellidoUsuario = apellido,
                    CorreoUsuario = correo,
                    TelefonoUsuario = telefono,
                    RolUsuario = rol,
                    UsuarioLogueo = usuarioLogueo,
                    EstadoUsuario = estado
                };

                if (usuarioServicio == null)
                {
                    MessageBox.Show("Servicio de usuarios no disponible.");
                    return;
                }

                if (usuarioServicio.Actualizarusuario(usuarioEditado))
                    MessageBox.Show("Usuario actualizado correctamente");
                else
                    MessageBox.Show("No se pudo actualizar el usuario");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar usuario: " + ex.Message);
            }

        }

        private void mensajes_Popup(object sender, PopupEventArgs e)
        {

        }

        private void pcbusqueda_Click(object sender, EventArgs e)
        {
            string criterio = cbtipobusqueda.Text;
            string dato = txtbusqueda.Text.Trim();

            if (string.IsNullOrWhiteSpace(criterio) || string.IsNullOrWhiteSpace(dato))
            {
                MessageBox.Show("Seleccione un criterio y escriba un dato para buscar.");
                return;
            }

            List<Usuario> resultados = new List<Usuario>();

            if (criterio == "Usuario")
            {
                resultados = Listausuarios
                    .Where(u => u.UsuarioLogueo.Contains(dato, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }
            else if (criterio == "Teléfono")
            {
                string datoLimpio = dato.Replace("-", "").Trim();
                resultados = Listausuarios
                    .Where(u => u.TelefonoUsuario.Replace("-", "").Contains(datoLimpio))
                    .ToList();
            }
            else
            {
                MessageBox.Show("Criterio inválido.");
                return;
            }

            // Mostrar los resultados en el DataGridView
            DGUSUARIOS.DataSource = null;
            DGUSUARIOS.DataSource = resultados;
        }
    }
}
