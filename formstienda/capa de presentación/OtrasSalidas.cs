using formstienda.Datos;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace formstienda.capa_de_presentación
{
    public partial class OtrasSalidas : Form
    {
        private readonly DbTiendaSeptentrionContext _contexto;
        private BindingList<SalidaViewModel> _salidasList;

        public OtrasSalidas()
        {
            InitializeComponent();
            _contexto = new DbTiendaSeptentrionContext();
            _salidasList = new BindingList<SalidaViewModel>();
            DGOTRASSALIDAS.DataSource = _salidasList;

            ConfigurarDataGridView();
            CargarNombreProducto();
            CargarMotivos();
        }

        private void ConfigurarDataGridView()
        {
            // Configurar las columnas del DataGridView
            DGOTRASSALIDAS.AutoGenerateColumns = false;
            DGOTRASSALIDAS.Columns.Clear();

            // Columnas en el orden especificado
            DGOTRASSALIDAS.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Codigo",
                HeaderText = "Código",
                Name = "colCodigo",
                Width = 100
            });

            DGOTRASSALIDAS.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "NombreProducto",
                HeaderText = "Nombre del Producto",
                Name = "colNombreProducto",
                Width = 200
            });

            DGOTRASSALIDAS.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Cantidad",
                HeaderText = "Cantidad",
                Name = "colCantidad",
                Width = 80
            });

            DGOTRASSALIDAS.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Motivo",
                HeaderText = "Motivo",
                Name = "colMotivo",
                Width = 150
            });

            DGOTRASSALIDAS.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Descripcion",
                HeaderText = "Descripción",
                Name = "colDescripcion",
                Width = 250
            });
        }

        private void CargarMotivos()
        {
            var motivos = new List<string>
            {
                "Defecto de fábrica",
                "Facturación errónea",
                "Producto dañado",
                "Uso personal",
                "Patrocinio"
            };

            cmbMotivo.DataSource = motivos;
            cmbMotivo.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void CargarNombreProducto()
        {
            try
            {
                cmbNombreProducto.Items.Clear();

                var productos = _contexto.Productos
                    .Where(p => p.EstadoProducto == true)
                    .ToList();

                cmbNombreProducto.DisplayMember = "ModeloProducto";
                cmbNombreProducto.ValueMember = "CodigoProducto";
                cmbNombreProducto.DataSource = productos;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar productos: {ex.Message}", "Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ComboBoxProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbNombreProducto.SelectedItem is Producto productoSeleccionado)
            {
                txtCodigo.Text = productoSeleccionado.CodigoProducto;
                txtStockDisponible.Text = productoSeleccionado.StockActual?.ToString() ?? "0";
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            using (var transaction = _contexto.Database.BeginTransaction())
            {
                try
                {
                    // Validaciones básicas
                    if (cmbNombreProducto.SelectedItem == null)
                    {
                        MessageBox.Show("Debe seleccionar un producto", "Validación",
                                      MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (!int.TryParse(txtCantidadSalir.Text, out int cantidad) || cantidad <= 0)
                    {
                        MessageBox.Show("Cantidad debe ser un número válido mayor que 0", "Validación",
                                      MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
                    {
                        MessageBox.Show("Descripción no puede estar vacía", "Validación",
                                      MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (cmbMotivo.SelectedItem == null)
                    {
                        MessageBox.Show("Debe seleccionar un motivo", "Validación",
                                      MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var producto = (Producto)cmbNombreProducto.SelectedItem;

                    // Verificar stock
                    if (producto.StockActual < cantidad)
                    {
                        MessageBox.Show($"No hay suficiente stock. Disponible: {producto.StockActual}",
                                      "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Crear registro de salida
                    var salida = new OtrasSalidasDeInventario
                    {
                        CodigoProducto = producto.CodigoProducto,
                        CantidadSalir = cantidad,
                        MotivoSalida = cmbMotivo.SelectedItem.ToString(),
                        DescripcionSalida = txtDescripcion.Text,
                    };

                    // Actualizar stock
                    producto.StockActual -= cantidad;
                    _contexto.Entry(producto).State = EntityState.Modified;

                    // Guardar cambios
                    _contexto.OtrasSalidasDeInventarios.Add(salida);
                    _contexto.SaveChanges();

                    // Agregar a la lista para mostrar en el DataGridView
                    _salidasList.Add(new SalidaViewModel
                    {
                        Codigo = producto.CodigoProducto,
                        NombreProducto = producto.ModeloProducto,
                        Cantidad = cantidad,
                        Motivo = salida.MotivoSalida,
                        Descripcion = salida.DescripcionSalida
                    });

                    transaction.Commit();

                    MessageBox.Show("Salida registrada correctamente", "Éxito",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LimpiarCampos();
                    txtStockDisponible.Text = producto.StockActual.ToString();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show($"Error: {ex.Message}", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LimpiarCampos()
        {
            txtCantidadSalir.Clear();
            txtStockDisponible.Clear();
            txtDescripcion.Clear();
            cmbMotivo.SelectedIndex = 0;
        }

        
        private void OtrasSalidas_Load(object sender, EventArgs e)
        {
            // Cargar datos existentes si es necesario
            CargarSalidasExistentes();
        }

        private void CargarSalidasExistentes()
        {
            try
            {
                var salidas = _contexto.OtrasSalidasDeInventarios
                    .Include(s => s.CodigoProductoNavigation)
                    .Take(50) // Limitar a las últimas 50 salidas
                    .ToList();

                foreach (var salida in salidas)
                {
                    _salidasList.Add(new SalidaViewModel
                    {
                        Codigo = salida.CodigoProducto,
                        NombreProducto = salida.CodigoProductoNavigation?.ModeloProducto ?? "N/A",
                        Cantidad = salida.CantidadSalir,
                        Motivo = salida.MotivoSalida,
                        Descripcion = salida.DescripcionSalida
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar salidas existentes: {ex.Message}", "Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
        private void label2_Click(object sender, EventArgs e)
        {

        }
    }

    // Clase para representar los datos en el DataGridView
    public class SalidaViewModel
    {
        public string Codigo { get; set; }
        public string NombreProducto { get; set; }
        public int Cantidad { get; set; }
        public string Motivo { get; set; }
        public string Descripcion { get; set; }
    }
}