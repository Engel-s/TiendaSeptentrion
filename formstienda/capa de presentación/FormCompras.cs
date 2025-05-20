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
using formstienda.capa_de_negocios;
using formstienda.capa_de_presentación;
using formstienda.Datos;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Globalization;

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

        private DetalleCompraServicio? detalleCompraServicio;
        private BindingList<DetalleCompra> listadetallecompra;

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
            dtgcompras.AllowUserToAddRows = false;
            proveedorServicio = new ProveedorServicio();
            marcaServicio = new MarcaServicio();
            categoriaServicio = new CategoriaServicio(); // Agregado
            productoServicio = new ProductoServicio();   // Agregado
            compraServicio = new CompraServicio();
            listacompra = new BindingList<Compra>();

        }

        private void Desactivarcampos()
        {
            datefecha.Enabled = false;
            cmbcategoria.Enabled = false;
            cmbmarcas.Enabled = false;
            cmbproducto.Enabled = false;
            txtpreciocompra.Enabled = false;
            txtcantidadproducto.Enabled = false;
            btnagregar.Enabled = false;
            dtgcompras.Enabled = false;
            txtprecioventa.Enabled = false;
            txtcodigoproducto.Enabled = false;
            txtsubtotalcompra.Enabled = false;
            btncancelar.Enabled = false;
        }

        private void Activarcampos()
        {
            datefecha.Enabled = true;
            cmbcategoria.Enabled = true;
            cmbmarcas.Enabled = true;
            cmbproducto.Enabled = true;
            txtpreciocompra.Enabled = true;
            txtcantidadproducto.Enabled = true;
            btnagregar.Enabled = true;
            dtgcompras.Enabled = true;
            txtprecioventa.Enabled = true;
            txtcodigoproducto.Enabled = true;
            txtsubtotalcompra.Enabled = true;
            btncancelar.Enabled = true;
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
            try
            {
                productoServicio = new ProductoServicio();
                var productos = productoServicio.ListarProductos();

                cmbproducto.DataSource = productos;
                cmbproducto.DisplayMember = "ModeloProducto"; // Solo muestra el nombre del producto
                //cmbproducto.ValueMember = "CodigoRuc"; // Este valor se usa internamente si necesitas el codigo ruc
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar combos: " + ex.Message);
            }

        }

        private void GenerarNuevoNumeroFactura()
        {
            int ultimoId = compraServicio.ObtenerUltimoIdCompra();
            int nuevoNumeroFactura = ultimoId + 1;

            txtnumerofactura.Text = nuevoNumeroFactura.ToString();
        }

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

        private void ColumnasPersonalizadas()
        {
            dtgcompras.Columns["IdDetalleCompra"].Visible = false;
            dtgcompras.Columns["IdCompra"].HeaderText = "Numero de factura";
            dtgcompras.Columns["CodigoProducto"].HeaderText = "Modelo producto";
            dtgcompras.Columns["CantidadCompra"].HeaderText = "Cantidad";
            dtgcompras.Columns["PrecioCompra"].HeaderText = "Precio de compra";
            dtgcompras.Columns["SubtotalCompra"].HeaderText = "Subtotal";
            dtgcompras.Columns["CodigoProductoNavigation"].Visible = false;
            dtgcompras.Columns["IdCompraNavigation"].Visible = false;
        }

        private void FormCompras_Load(object sender, EventArgs e)
        {
            newcompra = true;
            btnregistrar.Enabled = false;
            txtprecioventa.ReadOnly = true;
            Desactivarcampos();
            txtpreciocompra.KeyPress += txtpreciocompra_KeyPress;
            txtcantidadproducto.KeyPress += txtcantidadproducto_KeyPress;
            txtprecioventa.KeyPress += txtprecioventa_KeyPress;


            dtgcompras.DefaultCellStyle.ForeColor = Color.Black;

            cargarcategorias();
            cargarmarcas();
            cargarproductos();
            GenerarNuevoNumeroFactura();

            detalleCompraServicio = new DetalleCompraServicio();
            compraServicio = new CompraServicio();

            listacompra = new BindingList<Compra>(compraServicio.ListarCompra());
            listadetallecompra = new BindingList<DetalleCompra>();

            dtgcompras.DataSource = listadetallecompra;
            ColumnasPersonalizadas();

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
                txtprecioventa.Text = productoSeleccionado.PrecioVenta.ToString("C", new CultureInfo ("es-NI"));
                txtcodigoproducto.Text = productoSeleccionado.CodigoProducto.ToString();
            }

        }
        private void limpiarcampos()
        {
            txtpreciocompra.Clear();
            txtcantidadproducto.Clear();
        }

        private void btnnuevo_Click(object sender, EventArgs e)
        {
            VentanaEmergenteProveedor ventanaEmergenteProveedor = new VentanaEmergenteProveedor();
            ventanaEmergenteProveedor.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string textoVenta = txtprecioventa.Text.Replace("$", "").Replace("S/.", "").Replace(",", "").Trim();
            float precioVenta = float.Parse(textoVenta);

            if (string.IsNullOrEmpty(txtpreciocompra.Text.Trim()) || string.IsNullOrEmpty(txtcantidadproducto.Text.Trim()))
            {
                MessageBox.Show("Los campos precio de compra y cantidad son obligatorios.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                /*string patronPrecio = @"^\d+(\.\d{1,2})?$";
                if (!Regex.IsMatch(txtprecioventa.Text, patronPrecio))
                {
                    MessageBox.Show("El formato del precio de venta es incorrecto.",
                        "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }*/

                if (!float.TryParse(txtpreciocompra.Text, out float precioCompra) || precioCompra <= 0)
                {
                    MessageBox.Show("El precio de compra debe ser un número válido y positivo.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!int.TryParse(txtcantidadproducto.Text, out int cantidad) || cantidad <= 0)
                {
                    MessageBox.Show("La cantidad debe ser un número entero positivo.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //float preciocompra = float.Parse(txtpreciocompra.Text);
                if (precioVenta <= precioCompra)
                {
                    MessageBox.Show("El precio de compra no puede ser mayor o igual al precio de venta",
                        "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtprecioventa.ReadOnly = false;
                    txtprecioventa.Enabled = true;
                    txtprecioventa.Focus();
                    string patronPrecio = @"^\d+(\.\d{1,2})?$";
                    if (!Regex.IsMatch(txtprecioventa.Text, patronPrecio))
                    {
                        MessageBox.Show("El formato del precio de venta es incorrecto.",
                            "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                else
                {
                    if (newcompra)
                    {
                        //Compra
                        var fechaCompra = datefecha.Value;
                        var numeroFactura = int.Parse(txtnumerofactura.Text);

                        nombreProveedor = txtnombreproveedor.Text;
                        string codigoRuc = proveedorServicio.ObtenerCodigoRucPorNombre(nombreProveedor);

                        Compra compra = new Compra
                        {
                            FechaCompra = fechaCompra,
                            IdCompra = numeroFactura,
                            CodigoRuc = codigoRuc,
                        };

                        var agregarCompra = compraServicio.AgregarCompra(compra);
                        listacompra.Add(compra);
                    }


                    //DetalleCompra
                    if (cmbproducto.SelectedItem is Producto productoSeleccionado)
                    {
                        string codigoProducto = productoSeleccionado.CodigoProducto;
                        cantidad = int.Parse(txtcantidadproducto.Text);
                        precioCompra = float.Parse(txtpreciocompra.Text);

                        // Validar si el precio de venta fue modificado y actualizarlo en la base de datos
                        float nuevoPrecioVenta;
                        if (float.TryParse(txtprecioventa.Text.Replace("S/.", "").Replace("$", "").Trim(), out nuevoPrecioVenta))
                        {
                            if (nuevoPrecioVenta != productoSeleccionado.PrecioVenta)
                            {
                                productoServicio.ActualizarPrecioVenta(productoSeleccionado.CodigoProducto, nuevoPrecioVenta);
                            }
                        }


                        DetalleCompra detallecompra = new DetalleCompra
                        {
                            IdCompra = listacompra.Last().IdCompra,
                            CodigoProducto = codigoProducto,
                            CantidadCompra = cantidad,
                            PrecioCompra = precioCompra,
                            SubtotalCompra = cantidad * precioCompra,
                        };

                        txtprecioventa.ReadOnly = true;

                        var registroCompra = detalleCompraServicio.AgregarDetalleCompra(detallecompra);
                        listadetallecompra.Add(detallecompra);

                        txtsubtotalcompra.Text = listadetallecompra
                                                                    .Where(x => x.IdCompra == listacompra.Last().IdCompra)
                                                                    .Sum(x => x.SubtotalCompra ?? 0).ToString("C");
                        productoServicio.AumentarStock(codigoProducto, cantidad);
                    }
                    else
                    {
                        MessageBox.Show("Selecciona un producto válido.");
                    }
                    limpiarcampos();
                    btnregistrar.Enabled = true;
                    newcompra = false;
                }
            }


        }



        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            txtbuscartelefono.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            string numero = txtbuscartelefono.Text.Trim();
            string patronTelefono = @"^\d{8}$";

            if (!Regex.IsMatch(numero, patronTelefono))
            {
                MessageBox.Show("El formato del telefono es incorrecto.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                var proveedor = proveedorServicio.buscarProvee(numero);

                if (proveedor != null)
                {
                    txtnombreproveedor.Text = proveedor.NombreProveedor + " " + proveedor.ApellidoProveedor;
                    txtbuscartelefono.Clear();
                    Activarcampos();
                }
                else
                {
                    MessageBox.Show("Proveedor no encontrado.");
                }
            }
        }

        private void cmbcategoria_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listacompra.Count > 0)
            {
                var compraActual = listacompra.Last();

                // Intenta convertir el texto del subtotal a float
                if (float.TryParse(txtsubtotalcompra.Text, System.Globalization.NumberStyles.Currency, null, out float totalCompra))
                {
                    compraActual.TotalCompra = totalCompra;

                    // Llamar al método para actualizar en BD
                    compraServicio.ActualizarTotalCompra(compraActual.IdCompra, totalCompra);

                    MessageBox.Show("Compra finalizada.");
                }
                else
                {
                    MessageBox.Show("Error al obtener el total de la compra. Revisa el formato.");
                }
            }
            listadetallecompra.Clear();  // Limpiar detalles mostrados en el grid
            listadetallecompra.ResetBindings();
            dtgcompras.DataSource = null; // Limpiar el DataGridView
            dtgcompras.DataSource = listadetallecompra; // Reasignar la lista vacía
            ColumnasPersonalizadas();
            txtsubtotalcompra.Clear();
            txtnombreproveedor.Clear();
            txtcantidadproducto.Clear();
            newcompra = true;
            Desactivarcampos();
            GenerarNuevoNumeroFactura();
        }

        private void txtbuscartelefono_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            var confirmacion = MessageBox.Show("¿Estás seguro de que deseas cancelar esta compra?\nSe eliminarán todos los datos ingresados.",
                                      "Confirmar cancelación",
                                      MessageBoxButtons.YesNo,
                                      MessageBoxIcon.Warning);

            if (confirmacion != DialogResult.Yes)
            {
                return;
            }

            if (listacompra.Count > 0)
            {
                var compraActual = listacompra.Last();

                // Buscar detalles asociados a esta compra
                var detalles = detalleCompraServicio.ListarDetalleCompra()
                                .Where(d => d.IdCompra == compraActual.IdCompra)
                                .ToList();

                // Revertir stock
                foreach (var detalle in detalles)
                {
                    productoServicio.DisminuirStock(detalle.CodigoProducto, detalle.CantidadCompra);
                }


                //Sirve para eliminar  el detalle de compra
                detalleCompraServicio.EliminarDetallesPorIdCompra(compraActual.IdCompra);

                // Eliminar compra
                compraServicio.EliminarCompra(compraActual.IdCompra);




                // Quitamos la compra de la lista local también
                listacompra.Remove(compraActual);
            }

            listadetallecompra.Clear();  // Limpiar detalles mostrados en el grid
            listadetallecompra.ResetBindings();
            dtgcompras.DataSource = null; // Limpiar el DataGridView
            dtgcompras.DataSource = listadetallecompra; // Reasignar la lista vacía
            ColumnasPersonalizadas();
            txtsubtotalcompra.Clear();
            txtnombreproveedor.Clear();
            txtpreciocompra.Clear();
            txtcantidadproducto.Clear();

            newcompra = true;
            int nuevoNumeroFactura = compraServicio.ObtenerUltimoIdCompra();
            txtnumerofactura.Text = (nuevoNumeroFactura + 1).ToString();

            Desactivarcampos();
        }

        private void FormCompras_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtpreciocompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // Solo permitir un punto decimal
            if (e.KeyChar == '.' && (sender as TextBox).Text.Contains("."))
            {
                e.Handled = true;
            }
        }

        private void txtcantidadproducto_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtcantidadproducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtprecioventa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // Solo permitir un punto decimal
            if (e.KeyChar == '.' && (sender as TextBox).Text.Contains("."))
            {
                e.Handled = true;
            }
        }
    }
}
