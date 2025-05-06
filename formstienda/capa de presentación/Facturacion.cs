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
        private BindingList<Producto> Listaproducto;
        private VentaServicio VentaServicio;
        private BindingList<DetalleDeVentum> Listaventa;

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


        //private void ComboBox_Changed(object sender, EventArgs e)
        //{
        //    string modelo = CBproductos.SelectedItem?.ToString();
        //    string categoria = CBcategorias.SelectedItem?.ToString();
        //    string marca = CBmarcas.SelectedItem?.ToString();

        //    var filtrado = Listaproducto.Where(p =>
        //        (string.IsNullOrEmpty(modelo) || p.ModeloProducto == modelo) &&
        //        (string.IsNullOrEmpty(categoria) || p.IdCategoriaNavigation.Categoria == categoria) &&
        //        (string.IsNullOrEmpty(marca) || p.IdMarcaNavigation.Marca1 == marca)
        //    ).ToList();

        //    // Evitar loops de eventos
        //    CBproductos.SelectedIndexChanged -= ComboBox_Changed;
        //    CBcategorias.SelectedIndexChanged -= ComboBox_Changed;
        //    CBmarcas.SelectedIndexChanged -= ComboBox_Changed;

        //    // Solo actualizar combos si no fue el que disparó el cambio
        //    if (sender != CBproductos)
        //        ActualizarCombo(CBproductos, filtrado.Select(p => p.ModeloProducto).Distinct().OrderBy(x => x).ToList(), modelo);
        //    if (sender != CBcategorias)
        //        ActualizarCombo(CBcategorias, filtrado.Select(p => p.IdCategoriaNavigation.Categoria).Distinct().OrderBy(x => x).ToList(), categoria);
        //    if (sender != CBmarcas)
        //        ActualizarCombo(CBmarcas, filtrado.Select(p => p.IdMarcaNavigation.Marca1).Distinct().OrderBy(x => x).ToList(), marca);

        //    // Reconectar eventos
        //    CBproductos.SelectedIndexChanged += ComboBox_Changed;
        //    CBcategorias.SelectedIndexChanged += ComboBox_Changed;
        //    CBmarcas.SelectedIndexChanged += ComboBox_Changed;

        //    // Mostrar solo si el modelo está seleccionado y hay coincidencia clara
        //    if (!string.IsNullOrEmpty(modelo) && filtrado.Count == 1)
        //    {
        //        var prod = filtrado.First();
        //        txtprecio.Text = prod.PrecioVenta.ToString("N2");
        //        txtcantidad.Text = "1";
        //        txtmarca.Text = prod.IdMarcaNavigation.Marca1;
        //        txtcategoria.Text = prod.IdCategoriaNavigation.Categoria;
        //        txtproducto.Text = prod.ModeloProducto;
        //        txtcodigoproducto.Text = prod.CodigoProducto;
        //        txtstock.Text = Convert.ToString(prod.StockActual);
        //    }
        //    else
        //    {
        //        txtprecio.Clear();
        //        txtcantidad.Clear();
        //        txtmarca.Clear();
        //        txtcategoria.Clear();
        //        txtproducto.Clear();
        //        txtstock.Clear();
        //        txtcodigoproducto.Clear();
        //    }
        //}
        public class ProductoSeleccionado
        {
            public string CodigoProducto { get; set; }
            public string ModeloProducto { get; set; }
            public string Marca { get; set; }
            public string Categoria { get; set; }
            public double PrecioVenta { get; set; }
            public int Cantidad { get; set; }
            public double Subtotal => PrecioVenta * Cantidad;  // Calcular el subtotal
        }

        private ProductoSeleccionado productoSeleccionadoTemporal = null;

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
                txtcodigoproducto.Text = prod.CodigoProducto;
                txtstock.Text = Convert.ToString(prod.StockActual);

                // Guardar los datos del producto en una variable temporal
                productoSeleccionadoTemporal = new ProductoSeleccionado
                {
                    CodigoProducto = prod.CodigoProducto,
                    ModeloProducto = prod.ModeloProducto,
                    Marca = prod.IdMarcaNavigation.Marca1,
                    Categoria = prod.IdCategoriaNavigation.Categoria,
                    PrecioVenta = prod.PrecioVenta,
                    Cantidad = int.Parse(txtcantidad.Text) // Establecer cantidad, por defecto 1
                };
            }
            else
            {
                txtprecio.Clear();
                txtcantidad.Clear();
                txtmarca.Clear();
                txtcategoria.Clear();
                txtproducto.Clear();
                txtstock.Clear();
                txtcodigoproducto.Clear();
            }
        }



        private void ActualizarCombo(System.Windows.Forms.ComboBox combo, List<string> datosFiltrados, string valorSeleccionado)
        {
            // Obtener todas las opciones posibles según el ComboBox
            var todos = combo == CBproductos
                ? Listaproducto.Select(p => p.ModeloProducto).Distinct()
                : combo == CBcategorias
                    ? Listaproducto.Select(p => p.IdCategoriaNavigation.Categoria).Distinct()
                    : Listaproducto.Select(p => p.IdMarcaNavigation.Marca1).Distinct();

            // Ordenar: primero los filtrados (en el orden original), luego los restantes (ordenados)
            var noFiltrados = todos.Except(datosFiltrados).OrderBy(x => x);
            var final = datosFiltrados.Concat(noFiltrados).ToList();

            // Evitar refrescos innecesarios
            combo.DataSource = null;
            combo.DataSource = final;

            // Restaurar selección si es válida
            if (!string.IsNullOrEmpty(valorSeleccionado) && final.Contains(valorSeleccionado))
                combo.SelectedItem = valorSeleccionado;
            else
                combo.SelectedIndex = -1;
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
            VentaServicio = new VentaServicio();
            Listaventa = new BindingList<DetalleDeVentum>(); // simplemente iniciar la lista vacía

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

        private void AgregarAlDataGridView(ProductoSeleccionado producto)
        {
            // Agregar producto al DataGridView
            dgmostrar.Rows.Add(producto.CodigoProducto, producto.ModeloProducto, producto.Marca, producto.Categoria, producto.PrecioVenta, producto.Cantidad, producto.Subtotal);

            // Actualizar total
            ActualizarTotal();
        }

        private void ActualizarTotal()
        {
            double total = 0;

            // Sumar los subtotales de todas las filas
            foreach (DataGridViewRow row in dgmostrar.Rows)
            {
                total += Convert.ToDouble(row.Cells["Subtotal"].Value);
            }

            txttotal.Text = total.ToString("C2");
        }

        private void btnagregar_Click(object sender, EventArgs e)
        {
            if (productoSeleccionadoTemporal != null)
            {
                // Agregar el producto seleccionado al DataGridView
                AgregarAlDataGridView(productoSeleccionadoTemporal);

                // Limpiar la selección temporal
                productoSeleccionadoTemporal = null;

                // Limpiar los campos de texto
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un producto antes de agregar.");
            }
        }
        private void LimpiarCampos()
        {
            txtprecio.Clear();
            txtcantidad.Clear();
            txtmarca.Clear();
            txtcategoria.Clear();
            txtproducto.Clear();
            txtstock.Clear();
            txtcodigoproducto.Clear();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }
        private void LimpiarFormulario()
        {
            LimpiarFactura();         // Limpia los controles de factura
            LimpiarCampos();          // Limpia los campos de producto
            productoSeleccionadoTemporal = null; // Quitar selección
            CBproductos.SelectedIndex = -1;
            CBcategorias.SelectedIndex = -1;
            CBmarcas.SelectedIndex = -1;
            txttotal.Clear();
            txtcambio.Clear();
            txtpago.Clear();
            txtfaltante.Clear();
        }


        private void btnguardar_Click_1(object sender, EventArgs e)
        {
            var venta = new Ventum
            {
                FechaVenta = DateOnly.FromDateTime(DateTime.Now),
            };

            var detalles = new List<DetalleDeVentum>();

            foreach (DataGridViewRow row in dgmostrar.Rows)
            {
                if (row.IsNewRow) continue;

                string codProd = row.Cells["CodigoProducto"].Value?.ToString();
                var producto = Listaproducto.FirstOrDefault(p => p.CodigoProducto == codProd);
                if (producto == null) continue;

                var detalle = new DetalleDeVentum
                {
                    IdProducto = producto.IdProducto,
                    IdCategoria = producto.IdCategoria,
                    IdMarca = producto.IdMarca,
                    Cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value),
                    TotalPago = Convert.ToDouble(row.Cells["Subtotal"].Value)
                };

                detalles.Add(detalle);
            }

            var servicio = new VentaServicio();
            if (servicio.AgregarVentaConDetalles(venta, detalles))
            {
                MessageBox.Show("Venta guardada correctamente.");
                LimpiarFormulario();
            }
            else
            {
                MessageBox.Show("Error al guardar la venta.");
            }
        }

    }

}
