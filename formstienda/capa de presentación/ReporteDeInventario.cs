using formstienda.Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization; // Necesario para el formato de moneda
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;

namespace formstienda.capa_de_presentación
{
    public partial class ReporteDeInventario : Form
    {
        private DbTiendaSeptentrionContext _context;
        private bool _isMaximized = false;
        private readonly CultureInfo _nicaraguaCulture = new CultureInfo("es-NI"); // Cultura para Nicaragua

        public ReporteDeInventario()
        {
            InitializeComponent();
            _context = new DbTiendaSeptentrionContext();
        }

        private void ReporteDeInventario_Load(object sender, EventArgs e)
        {
            ConfigurarDataGridView();
            CargarDatosInventario();
            this.Resize += ReporteDeInventario_Resize;
            this.SizeChanged += ReporteDeInventario_SizeChanged;
        }

        private void ConfigurarDataGridView()
        {
            DGREPORTEINVENTARIO.AutoGenerateColumns = false;
            DGREPORTEINVENTARIO.AllowUserToAddRows = false;
            DGREPORTEINVENTARIO.AllowUserToDeleteRows = false;
            DGREPORTEINVENTARIO.ReadOnly = true;
            DGREPORTEINVENTARIO.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGREPORTEINVENTARIO.MultiSelect = false;
            DGREPORTEINVENTARIO.AllowUserToResizeColumns = true;
            DGREPORTEINVENTARIO.AllowUserToResizeRows = false;
            DGREPORTEINVENTARIO.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            DGREPORTEINVENTARIO.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            DGREPORTEINVENTARIO.Columns.Clear();

            // Configurar columnas con formato de córdobas para los campos monetarios
            AgregarColumna("CodigoProducto", "CÓDIGO", "colCodigo", 80, DataGridViewContentAlignment.MiddleCenter, 0.08f);
            AgregarColumna("Producto", "PRODUCTO", "colProducto", 150, DataGridViewContentAlignment.MiddleLeft, 0.20f);
            AgregarColumna("Categoria", "CATEGORÍA", "colCategoria", 120, DataGridViewContentAlignment.MiddleLeft, 0.15f);
            AgregarColumna("Marca", "MARCA", "colMarca", 150, DataGridViewContentAlignment.MiddleLeft, 0.12f);

            // Columna de precio con formato de córdobas
            AgregarColumnaMonetaria("PrecioVenta", "PRECIO VENTA", "colPrecio", 100, 0.12f);

            AgregarColumna("StockActual", "STOCK ACTUAL", "colStockActual", 150, DataGridViewContentAlignment.MiddleCenter, 0.08f);
            AgregarColumna("StockMinimo", "STOCK MÍNIMO", "colStockMinimo", 150, DataGridViewContentAlignment.MiddleCenter, 0.08f);
            AgregarColumna("EstadoStock", "ESTADO", "colEstado", 300, DataGridViewContentAlignment.MiddleCenter, 0.08f);

            // Columna de valor total con formato de córdobas
            AgregarColumnaMonetaria("ValorTotalInventario", "VALOR TOTAL", "colValorTotal", 100, 0.12f);

            AjustarAnchoColumnas();
        }

        private void AgregarColumna(string dataProperty, string headerText, string name,
                                   int minWidth, DataGridViewContentAlignment alignment, float porcentaje)
        {
            DGREPORTEINVENTARIO.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = dataProperty,
                HeaderText = headerText,
                Name = name,
                MinimumWidth = minWidth,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = alignment },
                Tag = porcentaje
            });
        }

        private void AgregarColumnaMonetaria(string dataProperty, string headerText, string name,
                                            int minWidth, float porcentaje)
        {
            var columna = new DataGridViewTextBoxColumn()
            {
                DataPropertyName = dataProperty,
                HeaderText = headerText,
                Name = name,
                MinimumWidth = minWidth,
                Tag = porcentaje
            };

            // Estilo para formato de córdobas
            columna.DefaultCellStyle = new DataGridViewCellStyle
            {
                Format = "C", // Formato de moneda
                FormatProvider = _nicaraguaCulture, // Usar cultura de Nicaragua
                Alignment = DataGridViewContentAlignment.MiddleRight,
            };

            DGREPORTEINVENTARIO.Columns.Add(columna);
        }

        private void CargarDatosInventario()
        {
            try
            {
                var inventario = _context.VistaInventarioActuals.ToList();
                DGREPORTEINVENTARIO.DataSource = inventario;
                AplicarFormatoCondicional();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el inventario: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AplicarFormatoCondicional()
        {
            foreach (DataGridViewRow row in DGREPORTEINVENTARIO.Rows)
            {
                if (row.Cells["colEstado"].Value?.ToString() == "BAJO")
                {
                    row.DefaultCellStyle.BackColor = Color.LightSalmon;
                    row.DefaultCellStyle.ForeColor = Color.DarkRed;
                }
                else if (row.Cells["colEstado"].Value?.ToString() == "CRÍTICO")
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                    row.DefaultCellStyle.ForeColor = Color.White;
                }
            }
        }

        private void ReporteDeInventario_SizeChanged(object sender, EventArgs e)
        {
            _isMaximized = this.WindowState == FormWindowState.Maximized;

            if (_isMaximized)
            {
                DGREPORTEINVENTARIO.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            else
            {
                DGREPORTEINVENTARIO.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                AjustarAnchoColumnas();
            }
        }

        private void ReporteDeInventario_Resize(object sender, EventArgs e)
        {
            if (!_isMaximized && DGREPORTEINVENTARIO.Columns.Count > 0)
            {
                AjustarAnchoColumnas();
            }
        }

        private void AjustarAnchoColumnas()
        {
            if (DGREPORTEINVENTARIO.Columns.Count == 0) return;

            int totalWidth = DGREPORTEINVENTARIO.ClientSize.Width;

            if (DGREPORTEINVENTARIO.ScrollBars == ScrollBars.Vertical ||
                DGREPORTEINVENTARIO.ScrollBars == ScrollBars.Both)
            {
                totalWidth -= SystemInformation.VerticalScrollBarWidth;
            }

            foreach (DataGridViewColumn col in DGREPORTEINVENTARIO.Columns)
            {
                if (col.Tag != null && col.Tag is float porcentaje)
                {
                    col.Width = (int)(totalWidth * porcentaje);
                }
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            this.Resize -= ReporteDeInventario_Resize;
            this.SizeChanged -= ReporteDeInventario_SizeChanged;
            base.OnFormClosing(e);
            _context?.Dispose();
        }
    }
}