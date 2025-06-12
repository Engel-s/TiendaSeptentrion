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
using formstienda.Acceso_Datos.Email_Servicios;
using iText.IO.Image;

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
            try
            {
                // Generar el PDF al cargar el formulario
               string filePath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "ReporteInventario.pdf");
                GenerarPDF(filePath);
                // Mostrar el PDF en el WebView
                MostrarPDF(filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el reporte: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void MostrarPDF(string rutaPDF)
        {
            webViewInventario.Source = new Uri(rutaPDF);
        }


        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            var menuForm = this.MdiParent as menu;
            if (menuForm == null)
            {
                menuForm = Application.OpenForms.OfType<menu>().FirstOrDefault();
            }
            if (menuForm != null)
            {
                menuForm.AbrirformInPanel(new Informes());
            }
        }

        public void GenerarPDF(string filePath)
        {
            // Obtener datos directamente de la base de datos
            var inventario = _context.VistaInventarioActuals.ToList();
            int totalProductos = inventario.Count;
            decimal totalInventario = (decimal)inventario.Sum(item => item.ValorTotalInventario);

            PdfWriter writer = new PdfWriter(filePath);
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf, PageSize.A4.Rotate());
            document.SetMargins(30, 20, 50, 30);

            PdfFont font = PdfFontFactory.CreateFont(iText.IO.Font.Constants.StandardFonts.HELVETICA);
            PdfFont boldFont = PdfFontFactory.CreateFont(iText.IO.Font.Constants.StandardFonts.HELVETICA_BOLD);

            // Agregar el logo SOLO en la primera página
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
                    .SetFixedPosition(1, pdf.GetDefaultPageSize().GetWidth() - 200, pdf.GetDefaultPageSize().GetTop() - 150)
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

            headerDiv.Add(new Paragraph("Reporte de Inventario")
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

            Table table = new Table(7);
            table.UseAllAvailableWidth();
            table.SetBorder(new SolidBorder(1));
            table.SetMarginBottom(10);

            // Encabezados de tabla
            string[] headers = { "CÓDIGO", "PRODUCTO", "CATEGORÍA", "MARCA", "PRECIO VENTA", "STOCK ACTUAL", "VALOR TOTAL" };
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
            foreach (var item in inventario)
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

                // Precio Venta
                table.AddCell(new Cell()
                    .Add(new Paragraph(item.PrecioVenta.ToString("C", _nicaraguaCulture))
                        .SetFont(font)
                        .SetFontSize(9))
                    .SetTextAlignment(TextAlignment.RIGHT)
                    .SetPadding(5)
                    .SetBorder(new SolidBorder(1)));

                // Stock Actual
                table.AddCell(new Cell()
                    .Add(new Paragraph(item.StockActual.ToString())
                        .SetFont(font)
                        .SetFontSize(9))
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetPadding(5)
                    .SetBorder(new SolidBorder(1)));

                // Valor Total
                table.AddCell(new Cell()
                    .Add(new Paragraph(string.Format(_nicaraguaCulture, "{0:C}", item.ValorTotalInventario))
                        .SetFont(font)
                        .SetFontSize(9))
                    .SetTextAlignment(TextAlignment.RIGHT)
                    .SetPadding(5)
                    .SetBorder(new SolidBorder(1)));
            }

            document.Add(table);

            // Total de inversión
            float pageWidth = pdf.GetDefaultPageSize().GetWidth();
            document.Add(new Paragraph($"Inversión Total: {totalInventario.ToString("C", _nicaraguaCulture)}")
                .SetFont(boldFont)
                .SetFontSize(12)
                .SetFixedPosition(pageWidth - 230, 30, 200)
                .SetPadding(5)
                .SetBorder(new SolidBorder(1))
                .SetTextAlignment(TextAlignment.LEFT));

            document.Close();
        }

        private void webViewInventario_Click(object sender, EventArgs e)
        {

        }
    }
}