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
using Path = System.IO.Path;

namespace formstienda.capa_de_presentación
{
    public partial class ReporteStocks : Form
    {
        private DbTiendaSeptentrionContext _context;
        private bool _isMaximized = false;
        private readonly CultureInfo _nicaraguaCulture = new CultureInfo("es-NI");

        public ReporteStocks()
        {
            InitializeComponent();
            _context = new DbTiendaSeptentrionContext();
        }

        private void ReporteStocks_Load(object sender, EventArgs e)
        {
            // Generar el reporte al cargar el formulario
            string tempFilePath = Path.Combine(Path.GetTempPath(), "ReporteStockProximoAgotarse.pdf");
            GenerarPDFStock(tempFilePath);
            MostrarPDF(tempFilePath);
        }

        public void MostrarPDF(string rutaPDF)
        {
            webViewStock.Source = new Uri(rutaPDF);
        }

        private void btnSalirStock_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void GenerarPDFStock(string filePath)
        {
            // Obtener datos directamente de la base de datos
            var productosProximosAgotarse = _context.VistaStockProximoAgotarses.ToList();
            int totalProductos = productosProximosAgotarse.Count;

            PdfWriter writer = new PdfWriter(filePath);
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf, PageSize.A4.Rotate());
            document.SetMargins(30, 20, 50, 30);

            PdfFont font = PdfFontFactory.CreateFont(iText.IO.Font.Constants.StandardFonts.HELVETICA);
            PdfFont boldFont = PdfFontFactory.CreateFont(iText.IO.Font.Constants.StandardFonts.HELVETICA_BOLD);

            // Agregar el logo
            try
            {
                System.Drawing.Image img = formstienda.Properties.Resources.logo_actualizado_removebg_preview;
                byte[] imgBytes;
                using (MemoryStream ms = new MemoryStream())
                {
                    img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    imgBytes = ms.ToArray();
                }

                iText.Layout.Element.Image logo = new iText.Layout.Element.Image(iText.IO.Image.ImageDataFactory.Create(imgBytes))
                    .SetWidth(215)
                    .SetFixedPosition(pdf.GetDefaultPageSize().GetWidth() - 200, pdf.GetDefaultPageSize().GetTop() - 150)
                    .SetMarginTop(0);

                document.Add(logo);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el logo: " + ex.Message,
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Encabezado del documento
            Div headerDiv = new Div()
                .SetTextAlignment(TextAlignment.LEFT)
                .SetMarginTop(10)
                .SetMarginBottom(15);

            headerDiv.Add(new Paragraph("Tienda El Septentrión")
                .SetFont(boldFont)
                .SetFontSize(18)
                .SetMarginBottom(5));

            headerDiv.Add(new Paragraph("Reporte de Productos Próximos a Agotarse")
                .SetFont(boldFont)
                .SetFontSize(16)
                .SetMarginBottom(5));

            headerDiv.Add(new Paragraph($"Fecha: {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}")
                .SetFont(font)
                .SetFontSize(10));

            headerDiv.Add(new Paragraph($"Total de productos: {totalProductos}")
                .SetFont(font)
                .SetFontSize(10)
                .SetMarginBottom(10));

            document.Add(headerDiv);

            // Tabla con 5 columnas
            Table table = new Table(5);
            table.UseAllAvailableWidth();
            table.SetBorder(new SolidBorder(1));
            table.SetMarginBottom(10);

            // Encabezados de tabla
            string[] headers = { "CÓDIGO", "PRODUCTO", "CATEGORÍA", "MARCA", "STOCK ACTUAL" };
            foreach (string header in headers)
            {
                table.AddHeaderCell(new Cell()
                    .Add(new Paragraph(header)
                        .SetFont(boldFont)
                        .SetFontSize(10))
                    .SetBackgroundColor(new DeviceRgb(3, 171, 229))
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetVerticalAlignment(VerticalAlignment.MIDDLE)
                    .SetPadding(5)
                    .SetBorder(new SolidBorder(1)));
            }

            // Datos de la tabla
            foreach (var item in productosProximosAgotarse)
            {
                // Código
                table.AddCell(new Cell()
                    .Add(new Paragraph(item.CodigoProducto)
                        .SetFont(font)
                        .SetFontSize(9))
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetPadding(5)
                    .SetBorder(new SolidBorder(1)));

                // Producto
                table.AddCell(new Cell()
                    .Add(new Paragraph(item.Producto)
                        .SetFont(font)
                        .SetFontSize(9))
                    .SetTextAlignment(TextAlignment.LEFT)
                    .SetPadding(5)
                    .SetBorder(new SolidBorder(1)));

                // Categoría
                table.AddCell(new Cell()
                    .Add(new Paragraph(item.Categoria)
                        .SetFont(font)
                        .SetFontSize(9))
                    .SetTextAlignment(TextAlignment.LEFT)
                    .SetPadding(5)
                    .SetBorder(new SolidBorder(1)));

                // Marca
                table.AddCell(new Cell()
                    .Add(new Paragraph(item.Marca)
                        .SetFont(font)
                        .SetFontSize(9))
                    .SetTextAlignment(TextAlignment.LEFT)
                    .SetPadding(5)
                    .SetBorder(new SolidBorder(1)));

                // Stock Actual
                table.AddCell(new Cell()
                    .Add(new Paragraph(item.StockActual?.ToString() ?? "0")
                        .SetFont(font)
                        .SetFontSize(9))
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetPadding(5)
                    .SetBorder(new SolidBorder(1)));
            }

            document.Add(table);

            // Marca de agua
            try
            {
                byte[] watermarkImgBytes;
                using (MemoryStream ms = new MemoryStream())
                {
                    formstienda.Properties.Resources.logo_actualizado_removebg_preview.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    watermarkImgBytes = ms.ToArray();
                }

                float baseSize = 350;
                float widthScale = 1.8f;
                float watermarkWidth = baseSize * widthScale;
                float watermarkHeight = baseSize;

                iText.Layout.Element.Image watermark = new iText.Layout.Element.Image(iText.IO.Image.ImageDataFactory.Create(watermarkImgBytes))
                    .SetOpacity(0.1f)
                    .SetWidth(watermarkWidth)
                    .SetHeight(watermarkHeight)
                    .SetFixedPosition(
                        pdf.GetDefaultPageSize().GetWidth() / 2 - (watermarkWidth / 2),
                        pdf.GetDefaultPageSize().GetHeight() / 2 - (watermarkHeight / 2),
                        watermarkWidth);

                for (int i = 1; i <= pdf.GetNumberOfPages(); i++)
                {
                    PdfPage page = pdf.GetPage(i);
                    PdfCanvas canvas = new PdfCanvas(page.NewContentStreamBefore(), page.GetResources(), pdf);
                    new Canvas(canvas, page.GetPageSize())
                        .Add(watermark)
                        .Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al crear marca de agua: " + ex.Message);
            }

            document.Close();
        }
    }
}