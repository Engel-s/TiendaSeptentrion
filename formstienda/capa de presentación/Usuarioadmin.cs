using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using formstienda;

namespace formstienda
{
    public partial class Usuarioadmin : Form
    {
        private UserManager userManager;
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
            
            usuarios nuevoUsuario = new usuarios
            {

                Id = (userManager.Usuarios.Count + 1).ToString("D2"),
                Username = txtusername.Text,
                
                Rol = comboBox2.Text,
                Password = txtpassword.Text,
            };
            userManager.AgregarUsuario(nuevoUsuario);
            DGUSUARIOS.DataSource = null;
            DGUSUARIOS.DataSource = userManager.Usuarios;
            DGUSUARIOS.Columns["Password"].Visible = false;
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            DGUSUARIOS.DataSource = userManager.Usuarios;
            DGUSUARIOS.Columns["Password"].Visible = false;
            
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
    }
    
}
