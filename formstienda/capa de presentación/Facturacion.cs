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
using Microsoft.Identity.Client;
using formstienda.capa_de_negocios;
using formstienda.Datos;

namespace formstienda
{

    public partial class Factura : Form
    {
        private ProductoServicio productoServicio;
        private UsuarioServicio usuarioServicio;
        private ClienteServicio clienteServicio;
        private AperturaServicio aperturaServicio;
        private BindingList<Producto>Listaproducto;

        public Factura()
        {
            InitializeComponent();
            productoServicio = new ProductoServicio();
            usuarioServicio = new UsuarioServicio();
            clienteServicio = new ClienteServicio();
            aperturaServicio = new AperturaServicio();
         
        }
        private void CargarCombos(List<Producto> productos)
        {
            CBproductos.SelectedIndexChanged -= ComboBox_Changed;
            CBcategorias.SelectedIndexChanged -= ComboBox_Changed;
            CBmarcas.SelectedIndexChanged -= ComboBox_Changed;

            CBproductos.DataSource = productos
                .Select(p => p.ModeloProducto)
                .Distinct()
                .OrderBy(m => m)
                .ToList();

            CBcategorias.DataSource = productos
                .Select(p => p.IdCategoriaNavigation.Categoria)
                .Distinct()
                .OrderBy(c => c)
                .ToList();

            CBmarcas.DataSource = productos
                .Select(p => p.IdMarcaNavigation.Marca1)
                .Distinct()
                .OrderBy(m => m)
                .ToList();

            // <- Aquí lo importante: seleccionar ninguno
            CBproductos.SelectedIndex = -1;
            CBcategorias.SelectedIndex = -1;
            CBmarcas.SelectedIndex = -1;

            CBproductos.SelectedIndexChanged += ComboBox_Changed;
            CBcategorias.SelectedIndexChanged += ComboBox_Changed;
            CBmarcas.SelectedIndexChanged += ComboBox_Changed;
        }


        private void ComboBox_Changed(object sender, EventArgs e)
        {
            string modelo = CBproductos.SelectedItem?.ToString();
            string categoria = CBcategorias.SelectedItem?.ToString();
            string marca = CBmarcas.SelectedItem?.ToString();

            var filtrado = Listaproducto.Where(p =>
                (string.IsNullOrEmpty(modelo) || p.ModeloProducto == modelo) &&
                (string.IsNullOrEmpty(categoria) || p.IdCategoriaNavigation.Categoria == categoria) &&
                (string.IsNullOrEmpty(marca) || p.IdMarcaNavigation.Marca1 == marca)
            ).ToList();

            // Evitar loops de eventos
            CBproductos.SelectedIndexChanged -= ComboBox_Changed;
            CBcategorias.SelectedIndexChanged -= ComboBox_Changed;
            CBmarcas.SelectedIndexChanged -= ComboBox_Changed;

            // Solo actualizar combos si no fue el que disparó el cambio
            if (sender != CBproductos)
                ActualizarCombo(CBproductos, filtrado.Select(p => p.ModeloProducto).Distinct().OrderBy(x => x).ToList(), modelo);
            if (sender != CBcategorias)
                ActualizarCombo(CBcategorias, filtrado.Select(p => p.IdCategoriaNavigation.Categoria).Distinct().OrderBy(x => x).ToList(), categoria);
            if (sender != CBmarcas)
                ActualizarCombo(CBmarcas, filtrado.Select(p => p.IdMarcaNavigation.Marca1).Distinct().OrderBy(x => x).ToList(), marca);

            // Reconectar eventos
            CBproductos.SelectedIndexChanged += ComboBox_Changed;
            CBcategorias.SelectedIndexChanged += ComboBox_Changed;
            CBmarcas.SelectedIndexChanged += ComboBox_Changed;

            // Mostrar solo si el modelo está seleccionado y hay coincidencia clara
            if (!string.IsNullOrEmpty(modelo) && filtrado.Count == 1)
            {
                var prod = filtrado.First();
                txtprecio.Text = prod.PrecioVenta.ToString("N2");
                txtcantidad.Text = "1";
                txtmarca.Text = prod.IdMarcaNavigation.Marca1;
                txtcategoria.Text = prod.IdCategoriaNavigation.Categoria;
                txtproducto.Text = prod.ModeloProducto;
            }
            else
            {
                txtprecio.Clear();
                txtcantidad.Clear();
                txtmarca.Clear();
                txtcategoria.Clear();
                txtproducto.Clear();
                txtstock.Clear();
            }
        }


        private void ActualizarCombo(System.Windows.Forms.ComboBox combo, List<string> nuevosDatos, string valorSeleccionado)
        {
            var actuales = combo.Items.Cast<string>().ToList();

            if (!nuevosDatos.SequenceEqual(actuales))
            {
                combo.DataSource = null;
                combo.DataSource = nuevosDatos;
            }

            // Asegurar que el valor sigue estando en la lista
            if (!string.IsNullOrEmpty(valorSeleccionado) && nuevosDatos.Contains(valorSeleccionado))
            {
                combo.SelectedItem = valorSeleccionado;
            }
            else
            {
                combo.SelectedIndex = -1;
            }
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

            txttotal.Enabled = false;
        }
        public void ActivarControles()
        {
            txtnombrecliente.Enabled = true;

            txtcantidad.Enabled = true;
            txtprecio.Enabled = true;
            btnagregar.Enabled = true;
            btncancelar.Enabled = true;

            txttotal.Enabled = true;
            txtcambio.Enabled = true;

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
            productoServicio = new ProductoServicio(); // ya lo haces

            var productos = productoServicio.ListarProductos();
            Listaproducto = new BindingList<Producto>(productos);

            if (Listaproducto.Count > 0)
            {
                CargarCombos(productos);
            }
           
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
            this.Close();
        }

        private void btneditar_Click(object sender, EventArgs e)
        {

            LimpiarControles();

        }

        private void btnguardar_Click(object sender, EventArgs e)
        {

        }

        private void dgmostrar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {


        }

      
    }

}
