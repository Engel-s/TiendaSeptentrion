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
using iText.Layout.Borders;
using iText.Kernel.Pdf.Canvas;

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
            document.SetMargins(30, 20, 50, 30);

            PdfFont font = PdfFontFactory.CreateFont(iText.IO.Font.Constants.StandardFonts.HELVETICA);
            PdfFont boldFont = PdfFontFactory.CreateFont(iText.IO.Font.Constants.StandardFonts.HELVETICA_BOLD);

            //Agregar el logo desde los recursos del proyecto
            try
            {
                System.Drawing.Image img = formstienda.Properties.Resources.logo_actualizado_removebg_preview;
                byte[] imgBytes;
                using (MemoryStream ms = new MemoryStream())
                {
                    img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    imgBytes = ms.ToArray();
                }

                // Posicionamiento mejorado del logo
                iText.Layout.Element.Image logo = new iText.Layout.Element.Image(iText.IO.Image.ImageDataFactory.Create(imgBytes))
                    .SetWidth(200)
                    .SetFixedPosition(30, pdf.GetDefaultPageSize().GetTop() - 110)
                    .SetMarginTop(0);

                document.Add(logo);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el logo: " + ex.Message,
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Título del reporte
            Paragraph title = new Paragraph("REPORTE DE INVENTARIO ACTUAL")
                .SetFont(boldFont)
                .SetFontSize(18)
                .SetTextAlignment(TextAlignment.CENTER)
                .SetMarginTop(10)
                .SetMarginBottom(15);
            document.Add(title);

            // Fecha de generación
            Paragraph fecha = new Paragraph($"Generado el: {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}")
                .SetFont(font)
                .SetFontSize(10)
                .SetTextAlignment(TextAlignment.RIGHT)
                .SetMarginBottom(15);
            document.Add(fecha);

            // Creación de la tabla con bordes completos
            Table table = new Table(DGREPORTEINVENTARIO.Columns.Count);
            table.UseAllAvailableWidth();

            // Configuración explícita de todos los bordes
            table.SetBorder(new SolidBorder(1));

            table.SetMarginBottom(10); // Espacio después de la tabla

            // Encabezados de la tabla
            foreach (DataGridViewColumn column in DGREPORTEINVENTARIO.Columns)
            {
                Cell cell = new Cell()
                    .Add(new Paragraph(column.HeaderText)
                        .SetFont(boldFont)
                        .SetFontSize(10))
                    .SetBackgroundColor(new DeviceRgb(3, 171, 229))
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetVerticalAlignment(VerticalAlignment.MIDDLE)
                    .SetPadding(5)
                    .SetBorder(new SolidBorder(1)); // Borde para cada celda de encabezado
                table.AddHeaderCell(cell);
            }

            // Datos de la tabla
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

                    if (cell.OwningColumn.Name == "colEstado")
                    {
                        cellValue = cellValue.ToUpper();

                        // Personalización del texto según el estado
                        if (cellValue.Contains("PRONTO"))
                        {
                            cellValue = "REQUIERE\nREABASTECIMIENTO\nPRONTO";
                        }
                        else if (cellValue.Contains("URGENTE"))
                        {
                            cellValue = "REQUIERE\nREABASTECIMIENTO\nURGENTE";
                        }
                    }

                    Paragraph cellParagraph = new Paragraph(cellValue)
                        .SetFont(font)
                        .SetFontSize(9)
                        .SetMultipliedLeading(1.4f)
                        .SetTextAlignment(TextAlignment.CENTER);


                    Cell pdfCell = new Cell()
                        .Add(cellParagraph)
                        .SetTextAlignment(GetPdfAlignment(cell.OwningColumn.DefaultCellStyle.Alignment))
                        .SetVerticalAlignment(VerticalAlignment.MIDDLE)
                        .SetPadding(5)
                        .SetBorder(new SolidBorder(1));

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

            // Total de productos
            Paragraph totalProductos = new Paragraph($"Total de productos: {DGREPORTEINVENTARIO.Rows.Count - 0}")
                .SetFont(font)
                .SetFontSize(9)
                .SetMarginTop(5);
            document.Add(totalProductos);
            
            // Cargar imagen para marca de agua
            byte[] watermarkImgBytes;
            using (MemoryStream ms = new MemoryStream())
            {
                formstienda.Properties.Resources.logo_actualizado_removebg_preview.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                watermarkImgBytes = ms.ToArray();
            }

            // Configuración de marca de agua más ancha
            float baseSize = 350; // Tamaño base
            float widthScale = 1.8f; // 1.8 veces más ancho que alto (ajusta este valor)
            float watermarkWidth = baseSize * widthScale;
            float watermarkHeight = baseSize;

            iText.Layout.Element.Image watermark = new iText.Layout.Element.Image(iText.IO.Image.ImageDataFactory.Create(watermarkImgBytes))
                .SetOpacity(0.1f) // Opacidad reducida
                .SetWidth(watermarkWidth)
                .SetHeight(watermarkHeight)
                .SetFixedPosition(
                    pdf.GetDefaultPageSize().GetWidth() / 2 - (watermarkWidth / 2),
                    pdf.GetDefaultPageSize().GetHeight() / 2 - (watermarkHeight / 2),
                    watermarkWidth);

            // Agregar a todas las páginas
            for (int i = 1; i <= pdf.GetNumberOfPages(); i++)
            {
                PdfPage page = pdf.GetPage(i);
                PdfCanvas canvas = new PdfCanvas(page.NewContentStreamBefore(), page.GetResources(), pdf);
                new Canvas(canvas, page.GetPageSize())
                    .Add(watermark)
                    .Close();
            }
            
            document.Close();
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