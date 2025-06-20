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

namespace formstienda.capa_de_presentación
{
    public partial class Cambiar_contraseña : Form
    {
        private string _correo;
        public Cambiar_contraseña(string correo)
        {
            InitializeComponent();
            _correo = correo;
        }

        private void btnCambiar_Contraseña_Click(object sender, EventArgs e)

        {
            string tokenRecupeacion = txtCambiarContraseña.Text.Trim();
            string nuevaContraseña = txtContraseñaNueva.Text.Trim();
            string confirmarContraseña = txtconfirmarcontraseña.Text.Trim();

            // Validar que ambas contraseñas coincidan
            if (nuevaContraseña != confirmarContraseña)
            {
                MessageBox.Show("Las contraseñas no coinciden. Por favor, verifíquelas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var clienteServicio = new ClienteRecuperacion();
            bool exitoso = clienteServicio.cambiarcontraseña(_correo, tokenRecupeacion, nuevaContraseña);

            if (exitoso)
            {
                MessageBox.Show("Se ha cambiado la contraseña exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Login login = new Login();
                this.Hide();
                login.Show();
            }
            else
            {
                MessageBox.Show("Hubo un error. No se pudo cambiar la contraseña.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Cambiar_contraseña_Load(object sender, EventArgs e)
        {

        }
    }
}
