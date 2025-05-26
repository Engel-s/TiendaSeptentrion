using formstienda.capa_de_negocios;
using formstienda.Datos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace formstienda
{
    public partial class FormProductos : Form
    {
        private System.Windows.Forms.Timer searchTimer; 
        private CategoriaServicio _categoriaServicio;
        private List<Producto> ListaProductos = new List<Producto>();
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
            CargarComboMarca();
            CargarComboCategoria();
            CargarProductos(); 

            searchTimer = new System.Windows.Forms.Timer();
            searchTimer.Interval = 300; // 300 milisegundos de retraso
            searchTimer.Tick += SearchTimer_Tick;

            txtBuscarProducto.TextChanged += TxtBuscarProducto_TextChanged;
        }

        private void SearchTimer_Tick(object sender, EventArgs e)
        {
            searchTimer.Stop();
            CargarProductos(txtBuscarProducto.Text.Trim());
        }

        private void TxtBuscarProducto_TextChanged(object sender, EventArgs e)
        {
            searchTimer.Stop();
            searchTimer.Start();
        }

        //
        private void CargarProductos(string filtro = "")
        {
            try
            {
                var query = productoServicio.ListarProductos()
                    .Select(p => new
                    {
                        p.CodigoProducto,
                        p.ModeloProducto,
                        PrecioVenta = $"C$ {p.PrecioVenta:N2}", // Formatear con símbolo y 2 decimales
                        p.StockActual,
                        p.StockMinimo,
                        Marca = p.IdMarcaNavigation?.Marca1 ?? "N/A",
                        Categoria = p.IdCategoriaNavigation?.Categoria ?? "N/A",
                        p.EstadoProducto,
                    });

                if (!string.IsNullOrWhiteSpace(filtro))
                {
                    query = query.Where(p =>
                        p.CodigoProducto.ToString().Contains(filtro, StringComparison.OrdinalIgnoreCase) ||
                        p.ModeloProducto.Contains(filtro, StringComparison.OrdinalIgnoreCase) ||
                        p.Marca.Contains(filtro, StringComparison.OrdinalIgnoreCase) ||
                        p.Categoria.Contains(filtro, StringComparison.OrdinalIgnoreCase) ||
                        p.EstadoProducto.ToString().Contains(filtro, StringComparison.OrdinalIgnoreCase)
                    );
                }

                var listaProductos = query.ToList();
                DGPRODUCTOS.DataSource = null;
                DGPRODUCTOS.DataSource = listaProductos;

                // Configurar el nombre de la columna en el DataGridView
                if (DGPRODUCTOS.Columns["CodigoProducto"] != null)
                {
                    DGPRODUCTOS.Columns["CodigoProducto"].HeaderText = "Código";
                }

                if (DGPRODUCTOS.Columns["ModeloProducto"] != null)
                {
                    DGPRODUCTOS.Columns["ModeloProducto"].HeaderText = "Nombre";
                }

                // Configurar la columna de precio para que mantenga el formato
                if (DGPRODUCTOS.Columns["PrecioVenta"] != null)
                {
                    DGPRODUCTOS.Columns["PrecioVenta"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar productos: {ex.Message}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                cmbMarcProduct.DisplayMember = "Marca1"; // Solo muestra el nombre de la marca
                cmbMarcProduct.ValueMember = "IdMarca"; // Este valor se usa internamente si necesitas el ID
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar combos: " + ex.Message);
            }
        }
                
        //cargar las marcas
        private void CargarMarcas()
        {
            var listaMarcas = _marcaServicio.ListarMarcas();

            DGMARCAS.DataSource = null;
            DGMARCAS.DataSource = listaMarcas;

            // Configurar nombres de columnas
            if (DGMARCAS.Columns.Count > 0)
            {
                DGMARCAS.Columns["IdMarca"].HeaderText = "ID";
                DGMARCAS.Columns["Marca1"].HeaderText = "Nombre de Marca";
                DGMARCAS.Columns["IdMarca"].ReadOnly = true; // ID no editable

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
                if (!decimal.TryParse(txtPrecioVenta.Text.Replace("C$", "").Trim(), out decimal precioVenta) || precioVenta <= 0)
                {
                    MessageBox.Show("Por favor, ingrese un precio de venta válido (número positivo).");
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
        


        private void DGMARCAS_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DGCATEGORIAS_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DGPRODUCTOS_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void FormProductos_Load(object sender, EventArgs e)
        {

        }

        //Editar Marca
        private void DGMARCAS_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                int idMarca = Convert.ToInt32(DGMARCAS.Rows[e.RowIndex].Cells["IdMarcas"].Value);
                string nombreActual = DGMARCAS.Rows[e.RowIndex].Cells["Marca"].Value.ToString();

                string nuevoNombre = Microsoft.VisualBasic.Interaction.InputBox(
                    "Ingrese el nuevo nombre de la marca:", "Editar Marca", nombreActual);

                if (!string.IsNullOrWhiteSpace(nuevoNombre) && nuevoNombre != nombreActual)
                {
                    bool actualizado = _marcaServicio.ActualizarMarca(idMarca, nuevoNombre.Trim());

                    if (actualizado)
                    {
                        MessageBox.Show("Marca actualizada correctamente.");
                        CargarMarcas();       // Refresca el grid de marcas
                        CargarComboMarca();   // Refresca el ComboBox
                        CargarProductos();    // Refresca la grilla de productos
                    }
                    else
                    {
                        MessageBox.Show("No se pudo actualizar la marca.");
                    }
                }
            }

        }

        //Editar Categoria
        private void DGCATEGORIAS_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                // Obtener el ID y el nombre actual de la categoría
                int idCategoria = Convert.ToInt32(DGCATEGORIAS.Rows[e.RowIndex].Cells["IdCategoria"].Value);
                string nombreActual = DGCATEGORIAS.Rows[e.RowIndex].Cells["Categoria"].Value.ToString();

                // Pedir nuevo nombre al usuario
                string nuevoNombre = Microsoft.VisualBasic.Interaction.InputBox(
                    "Ingrese el nuevo nombre de la categoría:", "Editar Categoría", nombreActual);

                if (!string.IsNullOrWhiteSpace(nuevoNombre) && nuevoNombre != nombreActual)
                {
                    // Llamar al servicio para actualizar
                    bool actualizado = _categoriaServicio.ActualizarCategoria(idCategoria, nuevoNombre.Trim());

                    if (actualizado)
                    {
                        MessageBox.Show("Categoría actualizada correctamente.");
                        CargarCategorias();       // Refrescar grilla de categorías
                        CargarComboCategoria();   // Refrescar ComboBox
                        CargarProductos();        // Refrescar grilla de productos para reflejar el cambio
                    }
                    else
                    {
                        MessageBox.Show("No se pudo actualizar la categoría.");
                    }
                }
            }

        }

        //Editar producto
        private void DGPRODUCTOS_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Validar que se hizo doble clic en una celda válida (no cabecera ni fuera de rango)
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Obtener el código del producto desde la celda correspondiente
                string codigo = DGPRODUCTOS.Rows[e.RowIndex].Cells["CodigoProducto"].Value?.ToString();

                if (string.IsNullOrWhiteSpace(codigo))
                {
                    MessageBox.Show("No se pudo identificar el producto.");
                    return;
                }

                // Obtener el producto desde el servicio
                var producto = productoServicio.ObtenerProductoPorCodigo(codigo);
                if (producto == null)
                {
                    MessageBox.Show("Producto no encontrado.");
                    return;
                }

                bool cambios = false;

                // Controlar qué columna fue doble clickeada
                switch (e.ColumnIndex)
                {

                    case 1: // Nombre del producto
                        string nuevoNombre = Microsoft.VisualBasic.Interaction.InputBox("Nuevo nombre:", "Editar Producto", producto.ModeloProducto);
                        if (!string.IsNullOrWhiteSpace(nuevoNombre))
                        {
                            if (nuevoNombre.Length > 100)
                            {
                                MessageBox.Show("El nombre del producto es demasiado largo.");
                                return;
                            }
                            producto.ModeloProducto = nuevoNombre.Trim();
                            cambios = true;
                        }
                        else
                        {
                            MessageBox.Show("El nombre no puede estar vacío.");
                        }
                        break;

                    case 2: // Precio de venta
                            // Eliminar el símbolo C$ si está presente para la edición
                        string precioActual = producto.PrecioVenta.ToString("0.00");
                        string nuevoPrecioStr = Microsoft.VisualBasic.Interaction.InputBox("Nuevo precio de venta (C$):", "Editar Producto", precioActual);

                        // Eliminar el símbolo si el usuario lo copió
                        nuevoPrecioStr = nuevoPrecioStr.Replace("C$", "").Trim();

                        if (float.TryParse(nuevoPrecioStr, out float nuevoPrecio))
                        {
                            if (nuevoPrecio < 0)
                            {
                                MessageBox.Show("El precio no puede ser negativo.");
                                return;
                            }
                            producto.PrecioVenta = nuevoPrecio;
                            cambios = true;
                        }
                        else
                        {
                            MessageBox.Show("Ingrese un valor numérico válido para el precio.");
                        }
                        break;

                    case 3: // Stock actual
                        string nuevoStockStr = Microsoft.VisualBasic.Interaction.InputBox("Nuevo stock actual:", "Editar Producto", producto.StockActual.ToString());
                        if (int.TryParse(nuevoStockStr, out int nuevoStock))
                        {
                            if (nuevoStock <= 0)
                            {
                                MessageBox.Show("El stock no puede ser negativo.");
                                return;
                            }
                            producto.StockActual = nuevoStock;
                            cambios = true;
                        }
                        else
                        {
                            MessageBox.Show("Ingrese un número entero válido para el stock.");
                        }
                        break;

                    case 4: // Stock mínimo
                        string nuevoStockMinStr = Microsoft.VisualBasic.Interaction.InputBox("Nuevo stock mínimo:", "Editar Producto", producto.StockMinimo.ToString());
                        if (int.TryParse(nuevoStockMinStr, out int nuevoStockMin))
                        {
                            if (nuevoStockMin <= 0)
                            {
                                MessageBox.Show("El stock mínimo no puede ser negativo.");
                                return;
                            }
                            producto.StockMinimo = nuevoStockMin;
                            cambios = true;
                        }
                        else
                        {
                            MessageBox.Show("Ingrese un número entero válido para el stock mínimo.");
                        }
                        break;

                    case 7: // Estado (checkbox)
                        DialogResult respuesta = MessageBox.Show("¿Desea cambiar el estado del producto?", "Cambiar Estado", MessageBoxButtons.YesNo);
                        if (respuesta == DialogResult.Yes)
                        {
                            producto.EstadoProducto = !producto.EstadoProducto; // Cambiar el valor actual
                            cambios = true;
                        }
                        break;
                }

                // Si se realizaron cambios, intentar guardar
                if (cambios)
                {
                    bool actualizado = productoServicio.ActualizarProducto(producto);
                    if (actualizado)
                    {
                        MessageBox.Show("Producto actualizado correctamente.");
                        CargarProductos(); // Refrescar la grilla
                    }
                    else
                    {
                        MessageBox.Show("No se pudo actualizar el producto. Verifique los datos e intente nuevamente.");
                    }
                }
            }
        }

        // 
        

        private void pbBuscarProducto_Click(object sender, EventArgs e)
        {

        }

        private void txtBuscarProducto_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
