using formstienda.capa_de_negocios;
using formstienda.Datos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace formstienda
{
    public partial class FormProductos : Form
    {
        //
        private CategoriaServicio _categoriaServicio;
    
        private List<Producto> ListaProductos = new List<Producto>();

        //
        private readonly MarcaServicio _marcaServicio;
        private ProductoServicio productoServicio = new ProductoServicio();


        public FormProductos()
        {
            InitializeComponent();
            _categoriaServicio = new CategoriaServicio();
            _marcaServicio = new MarcaServicio();
            productoServicio = new ProductoServicio();
            CargarMarcas();
            CargarCategorias();
            CargarMarcas();
            CargarComboMarca();
            CargarComboCategoria();
            CargarProductos(); // Refrescar el DataGridView
        }
        //
        private void CargarComboCategoria()
        {
            try
            {
                CategoriaServicio _categoriaServicio = new CategoriaServicio();
                var categorias = _categoriaServicio.ListarCategorias();

                cmbCategoriaProduc.DataSource = categorias;
                cmbCategoriaProduc.DisplayMember = "Categoria"; // el nombre de la categoría
                cmbCategoriaProduc.ValueMember = "IdCategoria"; // opcional, por si luego necesitás el ID
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar categorías: " + ex.Message);
            }
        }
        //cargar combos marcas
        private void CargarComboMarca()
        {
            try
            {
                MarcaServicio servicio = new MarcaServicio();
                var marcas = servicio.ListarMarcas();

                cmbMarcProduct.DataSource = marcas;
                cmbMarcProduct.DisplayMember = "Marca"; // Solo muestra el nombre de la marca
                cmbMarcProduct.ValueMember = "IdMarcas"; // Este valor se usa internamente si necesitas el ID
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar combos: " + ex.Message);
            }
        }

        //marcas
        //private void CargarMarcas()
        //{
        //    var listaMarcas = _marcaServicio.ListarMarcas();

        //    DGMARCAS.DataSource = null;
        //    DGMARCAS.DataSource = listaMarcas;

        //    // Configurar nombres de columnas
        //    if (DGMARCAS.Columns.Count > 0)
        //    {
        //        DGMARCAS.Columns["IdMarcas"].HeaderText = "ID";
        //        DGMARCAS.Columns["Marca"].HeaderText = "Nombre de Marca";
        //        DGMARCAS.Columns["IdMarcas"].ReadOnly = true; // ID no editable
        //    }
        //}

        //cargar las marcas
        private void CargarMarcas()
        {
            var listaMarcas = _marcaServicio.ListarMarcas();

            DGMARCAS.DataSource = null;
            DGMARCAS.DataSource = listaMarcas;

            // Configurar nombres de columnas
            if (DGMARCAS.Columns.Count > 0)
            {
                DGMARCAS.Columns["IdMarcas"].HeaderText = "ID";
                DGMARCAS.Columns["Marca"].HeaderText = "Nombre de Marca";
                DGMARCAS.Columns["IdMarcas"].ReadOnly = true; // ID no editable

                // Verificar si ya existe la columna botón para no agregarla dos veces
                if (!DGMARCAS.Columns.Contains("Editar"))
                {
                    DataGridViewButtonColumn btnEditar = new DataGridViewButtonColumn();
                    btnEditar.HeaderText = "Acciones";
                    btnEditar.Name = "Editar";
                    btnEditar.Text = "Editar";
                    btnEditar.UseColumnTextForButtonValue = true;
                    DGMARCAS.Columns.Add(btnEditar);
                }
            }
        }

        //Cargar categorias
        private void CargarCategorias()
        {
            var listaCategorias = _categoriaServicio.ListarCategorias();

            DGCATEGORIAS.DataSource = null;
            DGCATEGORIAS.DataSource = listaCategorias;

            // Configurar nombres de columnas
            if (DGCATEGORIAS.Columns.Count > 0)
            {
                DGCATEGORIAS.Columns["IdCategoria"].HeaderText = "ID";
                DGCATEGORIAS.Columns["Categoria"].HeaderText = "Nombre de Categoría";
                DGCATEGORIAS.Columns["IdCategoria"].ReadOnly = true; // ID no editable

                // Verificar si ya existe la columna botón para no agregarla dos veces
                if (!DGCATEGORIAS.Columns.Contains("Editar"))
                {
                    DataGridViewButtonColumn btnEditar = new DataGridViewButtonColumn();
                    btnEditar.HeaderText = "Acciones";
                    btnEditar.Name = "Editar";
                    btnEditar.Text = "Editar";
                    btnEditar.UseColumnTextForButtonValue = true;
                    DGCATEGORIAS.Columns.Add(btnEditar);
                }
            }
        }


        private void button12_Click(object sender, EventArgs e)
        {


            this.Close();
        }

        private void button11_Click(object sender, EventArgs e)
        {


            this.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {


            this.Close();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        //boton guardar Marcass
        private void button6_Click(object sender, EventArgs e)
        {
            string nombreMarca = txtNuevaMarca.Text.Trim();

            if (_marcaServicio.AgregarMarca(nombreMarca))
            {
                txtNuevaMarca.Clear();
                CargarMarcas();
                CargarComboMarca();
                MessageBox.Show("Marca agregada correctamente");
            }
        }
        //
        private void DGMARCAS_EditarCeldas(object sender, DataGridViewCellEventArgs e)
        {
            // Obtener datos editados
            var row = DGMARCAS.Rows[e.RowIndex];
            int idMarca = Convert.ToInt32(row.Cells["IdMarcas"].Value);
            string nuevoNombre = row.Cells["Marca"].Value.ToString();

            // Actualizar en la base de datos
            if (!_marcaServicio.ActualizarMarca(idMarca, nuevoNombre))
            {
                // Si falla la actualización, recargar los datos originales
                CargarMarcas();
            }
        }

        //private void DGMARCAS_BorrarCeldas(object sender, DataGridViewRowCancelEventArgs e)
        //{
        //    // Confirmar eliminación
        //    var result = MessageBox.Show("¿Está seguro que desea eliminar esta marca?",
        //                               "Confirmar eliminación",
        //                               MessageBoxButtons.YesNo,
        //                               MessageBoxIcon.Question);

        //    if (result == DialogResult.No)
        //    {
        //        e.Cancel = true;
        //        return;
        //    }

        //    // Obtener ID de la marca a eliminar
        //    int idMarca = Convert.ToInt32(e.Row.Cells["IdMarcas"].Value);

        //    // Intentar eliminar
        //    if (!_marcaServicio.EliminarMarca(idMarca))
        //    {
        //        e.Cancel = true; // Cancelar eliminación si falla
        //        CargarMarcas(); // Refrescar datos
        //    }
        //}

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            CargarMarcas();
        }


        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
        //boton agregar productos
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Validación de campos obligatorios
                if (string.IsNullOrWhiteSpace(txtNombreProduct.Text) ||
                    string.IsNullOrWhiteSpace(cmbCategoriaProduc.Text) ||
                    string.IsNullOrWhiteSpace(cmbMarcProduct.Text) ||
                    string.IsNullOrWhiteSpace(txtPrecioVenta.Text) ||
                    string.IsNullOrWhiteSpace(cmbEstado.Text))
                {
                    MessageBox.Show("Por favor, complete todos los campos obligatorios.");
                    return;
                }

                // Validación del precio de venta
                if (!decimal.TryParse(txtPrecioVenta.Text, out decimal precioVenta) || precioVenta <= 0)
                {
                    MessageBox.Show("Por favor, ingrese un precio de venta válido (número positivo).");
                    return;
                }

                // Validación del stock
                if (!int.TryParse(txtStockActual.Text, out int stockActual) || stockActual < 0)
                {
                    MessageBox.Show("Por favor, ingrese un stock actual válido (número entero no negativo).");
                    return;
                }

                if (!int.TryParse(txtStockMinimo.Text, out int stockMinimo) || stockMinimo < 0)
                {
                    MessageBox.Show("Por favor, ingrese un stock mínimo válido (número entero no negativo).");
                    return;
                }

                var producto = new Producto
                {
                    // Id_Producto no se incluye porque es autoincremental
                    ModeloProducto = txtNombreProduct.Text.Trim(),
                    CodigoProducto = txtCodigoProduct.Text.Trim(), // Asumiendo que es opcional
                    IdCategoria = Convert.ToInt32(cmbCategoriaProduc.SelectedValue),
                    IdMarca = Convert.ToInt32(cmbMarcProduct.SelectedValue),
                    PrecioVenta = Convert.ToInt32(precioVenta),
                    EstadoProducto = cmbEstado.Text == "Activo" ? true : false,
                    StockActual = stockActual,
                    StockMinimo = stockMinimo
                };

                bool exito = productoServicio.AgregarProducto(producto);

                if (exito)
                {
                    MessageBox.Show("Producto agregado correctamente");
                    LimpiarCampos();
                    ActualizarListaProductos();
                    CargarProductos(); // Refrescar el DataGridView

                }
            }
            catch (DbUpdateException dbEx)
            {
                string errorDetails = GetFullErrorDetails(dbEx);
                MessageBox.Show($"Error al guardar el producto:\n{errorDetails}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}");
            }
        }

        // Método para obtener detalles completos del error
        private string GetFullErrorDetails(DbUpdateException dbEx)
        {
            var sb = new StringBuilder();
            sb.AppendLine(dbEx.Message);

            if (dbEx.InnerException != null)
            {
                sb.AppendLine("\nInner Exception:");
                sb.AppendLine(dbEx.InnerException.Message);

                if (dbEx.InnerException.InnerException != null)
                {
                    sb.AppendLine("\nInner Exception 2:");
                    sb.AppendLine(dbEx.InnerException.InnerException.Message);
                }
            }

            return sb.ToString();
        }
        // Método para limpiar los campos (ejemplo)
        private void LimpiarCampos()
        {
            txtNombreProduct.Text = "";
            txtCodigoProduct.Text = "";
            txtPrecioVenta.Text = "";
            txtStockActual.Text = "0";
            txtStockMinimo.Text = "0";
            cmbCategoriaProduc.SelectedIndex = -1;
            cmbMarcProduct.SelectedIndex = -1;
            cmbEstado.SelectedIndex = -1;
            txtNombreProduct.Focus();
        }

        // Método para actualizar la lista de productos (ejemplo)
        private void ActualizarListaProductos()
        {
            ListaProductos = productoServicio.ListarProductos();
            DGPRODUCTOS.DataSource = ListaProductos;
        }

        //boton agregar categoria
        private void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
            string nombreCategoria = txtNuevaCategoria.Text.Trim();

            if (string.IsNullOrWhiteSpace(nombreCategoria))
            {
                MessageBox.Show("Ingrese un nombre válido para la categoría.");
                return;
            }

            if (_categoriaServicio.AgregarCategoria(nombreCategoria))
            {
                txtNuevaCategoria.Clear();
                CargarCategorias();       // Refrescar el DataGrid
                CargarComboCategoria();   // Refrescar el ComboBox también
                MessageBox.Show("Categoría agregada correctamente");
            }
            else
            {
                MessageBox.Show("No se pudo agregar la categoría.");
            }
        }
        //
        private void CargarProductos()
        {
            try
            {
                // Obtener lista de productos con información relacionada
                var listaProductos = productoServicio.ListarProductos()
                    .Select(p => new
                    {
                        p.CodigoProducto,
                        p.ModeloProducto,
                        p.PrecioVenta,
                        p.StockActual,
                        p.StockMinimo,
                        Marca = p.IdMarcaNavigation?.Marca1 ?? "N/A",
                        Categoria = p.IdCategoriaNavigation?.Categoria ?? "N/A",
                        p.EstadoProducto,
                    }).ToList();

                // Configurar el DataGridView
                DGPRODUCTOS.DataSource = null;
                DGPRODUCTOS.DataSource = listaProductos;

                // Configurar columnas
                if (DGPRODUCTOS.Columns.Count > 0)
                {
                    // Orden y configuración de columnas
                    var columnSettings = new List<(string Name, string Header, string Format, DataGridViewAutoSizeColumnMode SizeMode)>
                    {
                        ("CodigoProducto", "Código Producto", null, DataGridViewAutoSizeColumnMode.Fill),
                        ("ModeloProducto", "Nombre Producto", null, DataGridViewAutoSizeColumnMode.Fill),
                        ("PrecioVenta", "Precio Venta", "C2", DataGridViewAutoSizeColumnMode.Fill),
                        ("Marca", "Marca", null, DataGridViewAutoSizeColumnMode.Fill),
                        ("Categoria", "Categoría", null, DataGridViewAutoSizeColumnMode.Fill),
                        ("StockActual", "Stock Actual", null, DataGridViewAutoSizeColumnMode.Fill),
                        ("StockMinimo", "Stock Mínimo", null, DataGridViewAutoSizeColumnMode.Fill),
                        ("EstadoProducto", "Estado", null, DataGridViewAutoSizeColumnMode.Fill),
                    };

                    for (int i = 0; i < columnSettings.Count; i++)
                    {
                        var setting = columnSettings[i];
                        if (DGPRODUCTOS.Columns.Contains(setting.Name))
                        {
                            var col = DGPRODUCTOS.Columns[setting.Name];
                            col.HeaderText = setting.Header;
                            col.DisplayIndex = i;
                            if (setting.Format != null) col.DefaultCellStyle.Format = setting.Format;
                            col.AutoSizeMode = setting.SizeMode; // Esto se asegura de que todas las columnas ocupen todo el espacio disponible
                            col.Visible = true;
                        }
                    }

                    // Ocultar columnas no deseadas
                    foreach (DataGridViewColumn col in DGPRODUCTOS.Columns)
                    {
                        if (!columnSettings.Any(c => c.Name == col.Name))
                        {
                            col.Visible = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar productos: {ex.Message}", "Error",
                                 MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //metodo marcas editar
        private void DGMARCAS_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (DGMARCAS.Columns[e.ColumnIndex].Name == "Editar")
                {
                    int idMarca = (int)DGMARCAS.Rows[e.RowIndex].Cells["IdMarcas"].Value;
                    string nombreActual = DGMARCAS.Rows[e.RowIndex].Cells["Marca"].Value.ToString();

                    string nuevoNombre = Microsoft.VisualBasic.Interaction.InputBox(
                        "Editar nombre de la marca:",
                        "Editar Marca",
                        nombreActual
                    );

                    if (!string.IsNullOrWhiteSpace(nuevoNombre) && nuevoNombre != nombreActual)
                    {
                        if (_marcaServicio.ActualizarMarca(idMarca, nuevoNombre))
                        {
                            MessageBox.Show("Marca actualizada correctamente");
                            CargarMarcas();
                            CargarComboMarca();
                        }
                    }
                }
            }
        }

        //metodo editar categoria
        private void DGCATEGORIAS_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (DGCATEGORIAS.Columns[e.ColumnIndex].Name == "Editar")
                {
                    int idCategoria = (int)DGCATEGORIAS.Rows[e.RowIndex].Cells["IdCategoria"].Value;
                    string nombreActual = DGCATEGORIAS.Rows[e.RowIndex].Cells["Categoria"].Value.ToString();

                    string nuevoNombre = Microsoft.VisualBasic.Interaction.InputBox(
                        "Editar nombre de la categoría:",
                        "Editar Categoría",
                        nombreActual
                    );

                    if (!string.IsNullOrWhiteSpace(nuevoNombre) && nuevoNombre != nombreActual)
                    {
                        if (_categoriaServicio.ActualizarCategoria(idCategoria, nuevoNombre))
                        {
                            MessageBox.Show("Categoría actualizada correctamente");
                            CargarCategorias();
                            CargarComboCategoria();
                        }
                    }
                }
            }
        }

        private void DGPRODUCTOS_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void FormProductos_Load(object sender, EventArgs e)
        {

        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
