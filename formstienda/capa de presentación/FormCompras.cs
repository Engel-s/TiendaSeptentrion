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
using formstienda.Datos;
using Microsoft.EntityFrameworkCore.Migrations;

namespace formstienda
{
    public partial class FormCompras : Form
    {
        private MarcaServicio? marcaServicio;
        private BindingList<MarcaServicio> listamarcas;

        private CategoriaServicio? categoriaServicio;
        private BindingList<CategoriaServicio> listacategoria;

        private ProductoServicio? productoServicio;
        private BindingList<ProductoServicio> listaproductos;

        private CompraServicio? compraServicio;

        public FormCompras()
        {
            InitializeComponent();
        }

        private void cargarmarcas()
        {
            try
            {
                MarcaServicio servicio = new MarcaServicio();
                var marcas = servicio.ListarMarcas();

                cmbmarcas.DataSource = marcas;
                cmbmarcas.DisplayMember = "Marca"; // Solo muestra el nombre de la marca
                cmbmarcas.ValueMember = "IdMarcas"; // Este valor se usa internamente si necesitas el ID
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar combos: " + ex.Message);
            }

        }

        private void cargarcategorias()
        {
            try
            {
                CategoriaServicio serviciocategoria = new CategoriaServicio();
                var categoria = serviciocategoria.ListarCategorias();

                cmbcategoria.DataSource = categoria;
                cmbcategoria.DisplayMember = "Categoria";
                cmbcategoria.ValueMember = "IdCategoria";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar combos: " + ex.Message);
            }
        }
        private void cargarproductos()
        {
            productoServicio = new ProductoServicio();

            foreach (var item in productoServicio.ListarProductos())
            {
                cmbproducto.Items.Add(item);
            }
        }

        /*private void cargarprecio()
        {
            productoServicio = new ProductoServicio();
            foreach (var item in productoServicio.ListarProductos())
            {
               txtprecioventa.Text = item.PrecioVenta.ToString();
            }
        }*/
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private BindingList<Compra>? listacompras;

        private void CargarCompras()
        {
            //Instanciar el servicio
            compraServicio = new CompraServicio();

            //listar para almacenar las compras
            listacompras = new BindingList<Compra>(compraServicio.ListarCompra());

            //Vincular datagrid con el servicio
            dtgcompras.DataSource = listacompras;

        }
        private void FormCompras_Load(object sender, EventArgs e)
        {
            cargarcategorias();
            cargarmarcas();
            cargarproductos();


            CargarCompras();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void cmbproducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbproducto.SelectedItem is Producto productoSeleccionado)
            {
                txtprecioventa.Text = productoSeleccionado.PrecioVenta.ToString("C");
                txtcodigoproducto.Text = productoSeleccionado.CodigoProducto.ToString();
            }

        }
    }
}
