using formstienda.Datos;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using System;
using System.Collections.Generic;
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
    public partial class ReporteOtrasSalidas : Form
    {
        private readonly DateTime _fechaInicial;
        private readonly DateTime _fechaFinal;
        private readonly string _motivoSeleccionado;
        private readonly CultureInfo _nicaraguaCulture = new CultureInfo("es-NI");
        private DbTiendaSeptentrionContext _context;

        public ReporteOtrasSalidas(DateTime fechaInicial, DateTime fechaFinal, string motivoSeleccionado)
        {
            InitializeComponent();
            _fechaInicial = fechaInicial;
            _fechaFinal = fechaFinal;
            _motivoSeleccionado = motivoSeleccionado;
            _context = new DbTiendaSeptentrionContext();
        }

        public void MostrarPDF(string rutaPDF)
        {
            webViewOtrasSalidas.Source = new Uri(rutaPDF);
        }

        public void GenerarPDF(string filePath)
        {
            try
            {
                // Convertir las fechas DateTime a DateOnly para la comparación
                DateOnly fechaInicialDateOnly = DateOnly.FromDateTime(_fechaInicial);
                DateOnly fechaFinalDateOnly = DateOnly.FromDateTime(_fechaFinal);

                // Primero obtener los datos como lista y luego filtrar en memoria
                var listaSalidas = _context.VistaSalidasInventarioPorPeriodoMotivos
                    .AsEnumerable()
                    .Where(s => s.FechaSalida >= fechaInicialDateOnly &&
                               s.FechaSalida <= fechaFinalDateOnly)
                    .ToList();

                if (!string.IsNullOrEmpty(_motivoSeleccionado))
                {
                    listaSalidas = listaSalidas
                        .Where(s => s.MotivoSalida == _motivoSeleccionado)
                        .ToList();
                }

                // Ordenar por fecha
                listaSalidas = listaSalidas.OrderBy(s => s.FechaSalida).ToList();

                // Calcular totales
                decimal totalCantidad = listaSalidas.Sum(s => s.CantidadSalir);

                // Crear PDF
                PdfWriter writer = new PdfWriter(filePath);
                PdfDocument pdf = new PdfDocument(writer);
                Document document = new Document(pdf, PageSize.A4.Rotate());
                document.SetMargins(30, 20, 50, 30);

                PdfFont font = PdfFontFactory.CreateFont(iText.IO.Font.Constants.StandardFonts.HELVETICA);
                PdfFont boldFont = PdfFontFactory.CreateFont(iText.IO.Font.Constants.StandardFonts.HELVETICA_BOLD);

                // Agregar logo
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
                    Console.WriteLine("Error al cargar el logo: " + ex.Message);
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

                headerDiv.Add(new Paragraph("Reporte de Otras Salidas de Inventario")
                    .SetFont(boldFont)
                    .SetFontSize(16)
                    .SetMarginBottom(5));

                headerDiv.Add(new Paragraph($"Fecha: {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}")
                    .SetFont(font)
                    .SetFontSize(10));

                headerDiv.Add(new Paragraph($"Periodo: {_fechaInicial.ToString("dd/MM/yyyy")} - {_fechaFinal.ToString("dd/MM/yyyy")}")
                    .SetFont(font)
                    .SetFontSize(10));

                if (!string.IsNullOrEmpty(_motivoSeleccionado))
                {
                    headerDiv.Add(new Paragraph($"Motivo: {_motivoSeleccionado}")
                        .SetFont(font)
                        .SetFontSize(10));
                }

                document.Add(headerDiv);

                // Crear tabla con 7 columnas
                Table table = new Table(7);
                table.UseAllAvailableWidth();
                table.SetBorder(new SolidBorder(1));
                table.SetMarginBottom(20);

                // Encabezados de tabla
                string[] headers = {
                    "FECHA",
                    "CÓDIGO",
                    "PRODUCTO",
                    "MARCA",
                    "CATEGORÍA",
                    "MOTIVO",
                    "CANTIDAD",
                };

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

                foreach (var item in listaSalidas)
                {
                    // 1. FECHA
                    table.AddCell(new Cell()
                       .Add(new Paragraph(item.FechaSalida.ToString("dd/MM/yyyy") ?? string.Empty)
                       .SetFont(font)
                       .SetFontSize(9))
                       .SetTextAlignment(TextAlignment.CENTER)
                       .SetPadding(5)
                       .SetBorder(new SolidBorder(1)));

                    // 2. CÓDIGO
                    table.AddCell(new Cell()
                        .Add(new Paragraph(item.CodigoProducto)
                        .SetFont(font)
                        .SetFontSize(9))
                        .SetTextAlignment(TextAlignment.CENTER)
                        .SetPadding(5)
                        .SetBorder(new SolidBorder(1)));

                    // 3. PRODUCTO
                    table.AddCell(new Cell()
                        .Add(new Paragraph(item.Producto)
                        .SetFont(font)
                        .SetFontSize(9))
                        .SetTextAlignment(TextAlignment.LEFT)
                        .SetPadding(5)
                        .SetBorder(new SolidBorder(1)));

                    // 4. MARCA
                    table.AddCell(new Cell()
                        .Add(new Paragraph(item.Marca)
                        .SetFont(font)
                        .SetFontSize(9))
                        .SetTextAlignment(TextAlignment.LEFT)
                        .SetPadding(5)
                        .SetBorder(new SolidBorder(1)));

                    // 5. CATEGORÍA
                    table.AddCell(new Cell()
                        .Add(new Paragraph(item.Categoria)
                        .SetFont(font)
                        .SetFontSize(9))
                        .SetTextAlignment(TextAlignment.LEFT)
                        .SetPadding(5)
                        .SetBorder(new SolidBorder(1)));

                    // 6. MOTIVO
                    table.AddCell(new Cell()
                        .Add(new Paragraph(item.MotivoSalida)
                        .SetFont(font)
                        .SetFontSize(9))
                        .SetTextAlignment(TextAlignment.LEFT)
                        .SetPadding(5)
                        .SetBorder(new SolidBorder(1)));

                    // 7. CANTIDAD
                    table.AddCell(new Cell()
                        .Add(new Paragraph(item.CantidadSalir.ToString())
                        .SetFont(font)
                        .SetFontSize(9))
                        .SetTextAlignment(TextAlignment.RIGHT)
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
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el PDF: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private void webViewOtrasSalidas_Click(object sender, EventArgs e)
        {
           
        }

        private void btnSalirOtrasSalidas_Click(object sender, EventArgs e)
        {

            // Cerrar el formulario actual y abrir el formulario Informes en el panel del menú principal :)
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

        private void ReporteOtrasSalidas_Load(object sender, EventArgs e)
        {
            try
            {
                string filePath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "ReporteOtrasSalidas.pdf");
                GenerarPDF(filePath);
                MostrarPDF(filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el reporte: {ex.Message}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}