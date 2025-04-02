using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using formstienda;

namespace formstienda
{
    
    public partial class Factura : Form
    {
        List<factura> listafactura = new List<factura>();
        List<persona> listapersona = new List<persona>();

        string nombre, producto;
        double  precio,total = 0;
        int cantidad, indice;
        string codigo;
        Claseinventario claseinventario;
        List<(string IDPRODUCTO, int Cantidad)> productosExtraidos = new List<(string, int)>();



        public Factura()
        {
            InitializeComponent();
            claseinventario=Claseinventario.Instance;

        }
        
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        public void DesactivarControles()
        {
            txtnombrecliente.Enabled = false;

            txtcantidad.Enabled = false;
            txtprecio.Enabled = false;
            btnagregar.Enabled = false;
            btncancelar.Enabled = false;
            
            btnguardar.Enabled = false;
            txtcambio.Enabled = false;
            txtsaldo.Enabled = false;
            txttotal.Enabled = false;
        }
        public void ActivarControles()
        {
            txtnombrecliente.Enabled = true;

            txtcantidad.Enabled = true;
            txtprecio.Enabled = true;
            btnagregar.Enabled = true;
            btncancelar .Enabled = true;
            
            txttotal .Enabled = true;
            txtcambio .Enabled = true;
            txtsaldo .Enabled = true;
        }
        public void ActivarDatosFactura()
        {
            txtnombrecliente.Enabled = true;

            txtcantidad.Enabled = true;
            txtprecio.Enabled = true;
        }
        public void LimpiarFactura()
        {
            txtnombrecliente.Clear();
 
            txtcantidad.Clear();
            txtprecio.Clear();
           
            txtpago.Clear();
            txtfaltante.Clear();
            txttotal.Clear();
            txtsaldo .Clear();
            txtcambio.Clear();
            dgmostrar.Rows.Clear();
          
        }  
        public void LimpiarControles()
        {
            txtcantidad.Text = "";
            txtprecio.Text = "";
        }

        public void MostrarDatosListaObjetos()
        {
            
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {// Restaurar el stock de los productos extraídos
            foreach (var item in productosExtraidos)
            {
                claseinventario.RestaurarStock(item.IDPRODUCTO, item.Cantidad);
            }

            // Limpiar los datos de la factura y la lista de productos extraídos
            LimpiarFactura();
            listafactura.Clear();
            productosExtraidos.Clear();

            MessageBox.Show("Factura cancelada y productos devueltos al inventario.");

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void txtfecha_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void lblfecha_Click(object sender, EventArgs e)
        {
            
        }

        private void Factura_Load(object sender, EventArgs e)
        {
            

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void txtfaltante_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtpago_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtpago_Leave(object sender, EventArgs e)
        {

 
        }

        private void radCordoba_CheckedChanged(object sender, EventArgs e)
        {
            txtfaltante.Enabled = false;
            txtfaltante.Clear();
        }

        private void radDolar_CheckedChanged(object sender, EventArgs e)
        {
            txtfaltante.Enabled = false;
            txtfaltante.Clear();
        }
        private void radMixto_CheckedChanged(object sender, EventArgs e)
        {
            txtpago.Clear();
            txtfaltante.Enabled = true;
        }

        private void cbmetodopago_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void dgmostrar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void txtsaldo_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click_1(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click_1(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtmarca_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void facturafecha_Tick(object sender, EventArgs e)
        {
            
        }

        private void label14_Click_2(object sender, EventArgs e)
        {

        }

        private void textBox21_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            this.Close() ;
        }

        private void btneditar_Click(object sender, EventArgs e)
        {
  
            listafactura[indice] = new factura(precio, cantidad);
            listapersona[indice] = new persona(nombre, producto);
            LimpiarControles();

        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            
        }

        private void dgmostrar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            indice = dgmostrar.CurrentRow.Index;

            if (dgmostrar.Columns[e.ColumnIndex].Name == "editar")
            {
                txtnombrecliente.Text = listapersona[indice].NombreCliente;

                txtcantidad.Text = listafactura[indice].Cantidad.ToString();
                txtprecio.Text = listafactura[indice].Precio.ToString();
                ActivarControles();
            }
            if (dgmostrar.Columns[e.ColumnIndex].Name == "eliminar")
            {
                DialogResult respeeliminar;
                respeeliminar = MessageBox.Show("Esta seguro que desea eliminar el producto", "eliminar producto",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if(respeeliminar == DialogResult.OK)
                {
                    listapersona.RemoveAt(indice);
                    listafactura.RemoveAt(indice);
                    dgmostrar.Rows.Clear();
                }
            }
        }
    }    

}
