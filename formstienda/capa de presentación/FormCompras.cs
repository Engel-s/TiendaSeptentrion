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
        private BindingList<Compra> listacompra;

        private ProveedorServicio? proveedorServicio;


        //Variables auxiliares
        string nombreProveedor = string.Empty;
        string nombreProducto = string.Empty;
        string nombreMarca = string.Empty;
        string nombreCategoria = string.Empty;




        bool newcompra = false;

        public FormCompras()
        {
            InitializeComponent();
            proveedorServicio = new ProveedorServicio();
            marcaServicio = new MarcaServicio();
            categoriaServicio = new CategoriaServicio(); // Agregado
            productoServicio = new ProductoServicio();   // Agregado
            compraServicio = new CompraServicio();
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


        private void CargarCompras()
        {
            //Instanciar el servicio
            compraServicio = new CompraServicio();

            //listar para almacenar las compras
            listacompra = new BindingList<Compra>(compraServicio.ListarCompra());

            //Vincular datagrid con el servicio
            dtgcompras.DataSource = listacompra;

        }
        private void FormCompras_Load(object sender, EventArgs e)
        {
            cargarcategorias();
            cargarmarcas();
            cargarproductos();
            CargarCompras();

            //Se usa para no mostrar una columna en el datagrid
            //dtgcompras.Columns["Id"].Visible = false;

            //Se usa para cambiar el nombre de la columna
            //dtgcompras.Columns["CompraId"].HeaderText = "Producto";

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


        private void btnnuevo_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var fechacompra = datefecha.Value;

            nombreProveedor = txtnombreproveedor.Text;
            int idProveedor = proveedorServicio.ObtenerIdPorNombre(nombreProveedor);

            nombreCategoria = cmbcategoria.SelectedItem.ToString();
            int idCategoria = categoriaServicio.ObtenerIdPorNombreCategoria(nombreCategoria);

            nombreProducto = cmbproducto.SelectedItem.ToString();
            int idProducto = productoServicio.ObtenerIdPorNombreProducto(nombreProducto);

            nombreMarca = cmbmarcas.SelectedItem.ToString();
            int idMarca = marcaServicio.ObtenerIdPorNombreMarca(nombreMarca);

            int cantidad = int.Parse(txtcantidadproducto.Text);
            double precio = double.Parse(txtpreciocompra.Text);

            Compra compra = new Compra
            {
                FechaCompra = fechacompra,
                IdProveedor = idProveedor,
                IdProducto = idProducto,
                IdMarca = idMarca,
                CantidadCompra = cantidad,
                PrecioCompra = precio,

            };

            var agregarCompra = compraServicio.AgregarCompra(compra);
            listacompra.Add(compra);


        }



        private void pictureBox2_Click_1(object sender, EventArgs e)
        {

            string numero = txtbuscartelefono.Text.Trim();
            var proveedor = proveedorServicio.buscarProvee(numero);

            if (proveedor != null)
            {
                txtnombreproveedor.Text = proveedor.NombreProveedor + " " + proveedor.ApellidoProveedor;
                /*lblcliente.Text = proveedor.IdCliente.ToString(); // solo si lo muestras
                idClienteActual = proveedor.IdCliente; //  GUARDAMOS EL ID*/
            }
            else
            {
                MessageBox.Show("Proveedor no encontrado.");
            }
        }

        private void cmbcategoria_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
