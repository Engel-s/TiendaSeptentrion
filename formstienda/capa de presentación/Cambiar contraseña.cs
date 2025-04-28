using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

       /* private void btnCambiar_Contraseña_Click(object sender, EventArgs e)
        {
            string tokenRecupeacion = txtCambiarContraseña.Text.Trim();
            string NuevaContraseña = txtContraseñaNueva.Text.Trim();

            var usermanager = new UserManager();
            bool exitoso = usermanager.cambiarcontraseña(_correo, tokenRecupeacion, NuevaContraseña);

                if (exitoso)
            {
                MessageBox.Show("Se ha cambiado la contraseña");
                Login login = new Login();
                this.Hide();
                login.Show();
            }
            else 
            {
                MessageBox.Show("Hubo un error no se puede cambiar la contraseña");
            }
        }*/
    }
}
