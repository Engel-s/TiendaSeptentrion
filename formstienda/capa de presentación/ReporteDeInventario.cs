using formstienda.Datos;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using iText.Kernel.Geom;

namespace formstienda.capa_de_presentación
{
    public partial class ReporteDeInventario : Form
    {
        private DbTiendaSeptentrionContext _context;
        private bool _isMaximized = false;
        private readonly CultureInfo _nicaraguaCulture = new CultureInfo("es-NI");

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

            AgregarColumna("CodigoProducto", "CÓDIGO", "colCodigo", 100, DataGridViewContentAlignment.MiddleCenter, 0.08f);
            AgregarColumna("Producto", "PRODUCTO", "colProducto", 150, DataGridViewContentAlignment.MiddleLeft, 0.20f);
            AgregarColumna("Categoria", "CATEGORÍA", "colCategoria", 120, DataGridViewContentAlignment.MiddleLeft, 0.15f);
            AgregarColumna("Marca", "MARCA", "colMarca", 100, DataGridViewContentAlignment.MiddleLeft, 0.12f);
            AgregarColumnaMonetaria("PrecioVenta", "PRECIO VENTA", "colPrecio", 100, 0.12f);
            AgregarColumna("StockActual", "STOCK ACTUAL", "colStockActual", 150, DataGridViewContentAlignment.MiddleCenter, 0.08f);
            AgregarColumna("StockMinimo", "STOCK MÍNIMO", "colStockMinimo", 150, DataGridViewContentAlignment.MiddleCenter, 0.08f);
            AgregarColumna("EstadoStock", "ESTADO", "colEstado", 300, DataGridViewContentAlignment.MiddleCenter, 0.08f);
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

            columna.DefaultCellStyle = new DataGridViewCellStyle
            {
                Format = "C",
                FormatProvider = _nicaraguaCulture,
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
                    row.DefaultCellStyle.BackColor = System.Drawing.Color.LightSalmon;
                    row.DefaultCellStyle.ForeColor = System.Drawing.Color.DarkRed;
                }
                else if (row.Cells["colEstado"].Value?.ToString() == "CRÍTICO")
                {
                    row.DefaultCellStyle.BackColor = System.Drawing.Color.Red;
                    row.DefaultCellStyle.ForeColor = System.Drawing.Color.White;
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

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGenerarPDF_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "PDF files (*.pdf)|*.pdf",
                    Title = "Guardar reporte de inventario",
                    FileName = $"Reporte_Inventario_{DateTime.Now:yyyyMMddHHmmss}.pdf"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    GenerarPDF(saveFileDialog.FileName);
                    MessageBox.Show("Reporte generado exitosamente", "Éxito",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el PDF: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GenerarPDF(string filePath)
        {
            PdfWriter writer = new PdfWriter(filePath);
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf, PageSize.A4.Rotate());
            document.SetMargins(20, 20, 30, 30);

            PdfFont font = PdfFontFactory.CreateFont(iText.IO.Font.Constants.StandardFonts.HELVETICA);
            PdfFont boldFont = PdfFontFactory.CreateFont(iText.IO.Font.Constants.StandardFonts.HELVETICA_BOLD);

            Paragraph title = new Paragraph("REPORTE DE INVENTARIO ACTUAL")
                .SetFont(boldFont)
                .SetFontSize(18)
                .SetTextAlignment(TextAlignment.CENTER)
                .SetMarginBottom(20);
            document.Add(title);

            Paragraph fecha = new Paragraph($"Generado el: {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}")
                .SetFont(font)
                .SetFontSize(9)
                .SetTextAlignment(TextAlignment.RIGHT)
                .SetMarginBottom(15);
            document.Add(fecha);

            Table table = new Table(DGREPORTEINVENTARIO.Columns.Count, true);
            table.SetWidth(UnitValue.CreatePercentValue(100));

            foreach (DataGridViewColumn column in DGREPORTEINVENTARIO.Columns)
            {
                Cell cell = new Cell()
                    .Add(new Paragraph(column.HeaderText)
                        .SetFont(boldFont)
                        .SetFontSize(10))
                    .SetBackgroundColor(new DeviceRgb(0, 120, 215))
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetVerticalAlignment(VerticalAlignment.MIDDLE)
                    .SetPadding(5);
                table.AddHeaderCell(cell);
            }

            foreach (DataGridViewRow row in DGREPORTEINVENTARIO.Rows)
            {
                if (row.IsNewRow) continue;

                foreach (DataGridViewCell cell in row.Cells)
                {
                    string cellValue = cell.Value?.ToString() ?? string.Empty;

                    if (cell.OwningColumn.Name == "colPrecio" || cell.OwningColumn.Name == "colValorTotal")
                    {
                        if (decimal.TryParse(cellValue.Replace("C$", "").Trim(), out decimal valor))
                        {
                            cellValue = valor.ToString("C", _nicaraguaCulture);
                        }
                    }

                    Paragraph cellParagraph = new Paragraph(cellValue)
                        .SetFont(font)
                        .SetFontSize(9);

                    if (row.Cells["colEstado"].Value?.ToString() == "CRÍTICO")
                    {
                        cellParagraph.SetFont(boldFont).SetFontColor(DeviceRgb.WHITE);
                    }

                    Cell pdfCell = new Cell()
                        .Add(cellParagraph)
                        .SetTextAlignment(GetPdfAlignment(cell.OwningColumn.DefaultCellStyle.Alignment))
                        .SetVerticalAlignment(VerticalAlignment.MIDDLE)
                        .SetPadding(5);

                    if (row.Cells["colEstado"].Value?.ToString() == "BAJO")
                    {
                        pdfCell.SetBackgroundColor(new DeviceRgb(255, 160, 122));
                    }
                    else if (row.Cells["colEstado"].Value?.ToString() == "CRÍTICO")
                    {
                        pdfCell.SetBackgroundColor(new DeviceRgb(255, 0, 0));
                    }

                    table.AddCell(pdfCell);
                }
            }

            document.Add(table);

            Paragraph totalProductos = new Paragraph($"Total de productos: {DGREPORTEINVENTARIO.Rows.Count - 1}")
                .SetFont(font)
                .SetFontSize(9)
                .SetMarginTop(15);
            document.Add(totalProductos);

            document.Close();
        }

        private float[] GetColumnWidths()
        {
            float[] widths = new float[DGREPORTEINVENTARIO.Columns.Count];
            for (int i = 0; i < DGREPORTEINVENTARIO.Columns.Count; i++)
            {
                if (DGREPORTEINVENTARIO.Columns[i].Tag is float porcentaje)
                {
                    widths[i] = porcentaje;
                }
                else
                {
                    widths[i] = 1f / DGREPORTEINVENTARIO.Columns.Count;
                }
            }
            return widths;
        }

        private TextAlignment GetPdfAlignment(DataGridViewContentAlignment alignment)
        {
            switch (alignment)
            {
                case DataGridViewContentAlignment.TopLeft:
                case DataGridViewContentAlignment.MiddleLeft:
                case DataGridViewContentAlignment.BottomLeft:
                    return TextAlignment.LEFT;

                case DataGridViewContentAlignment.TopCenter:
                case DataGridViewContentAlignment.MiddleCenter:
                case DataGridViewContentAlignment.BottomCenter:
                    return TextAlignment.CENTER;

                case DataGridViewContentAlignment.TopRight:
                case DataGridViewContentAlignment.MiddleRight:
                case DataGridViewContentAlignment.BottomRight:
                    return TextAlignment.RIGHT;

                default:
                    return TextAlignment.LEFT;
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