using formstienda.capa_de_presentación;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace formstienda
{
    public partial class Arqueo_Caja : Form
    {
        public Arqueo_Caja()
        {
            InitializeComponent();
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void textBox20_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Apertura_Caja apertura = new Apertura_Caja();
            apertura.Show();

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Egresos egresos = new Egresos();
            egresos.Show();

           
        }

        private void Arqueo_Caja_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
