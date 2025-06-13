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
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.Kernel.Font;
using iText.Kernel.Colors;
using iText.Kernel.Geom;
using iText.Layout.Borders;
using formstienda.Datos;
using iText.Kernel.Pdf.Canvas;
using formstienda.capa_de_presentación;

namespace formstienda.Reporte
{
    public partial class ReporteDeCredito : Form
    {
        private readonly DateTime _fechaInicial;
        private readonly DateTime _fechaFinal;
        private DbTiendaSeptentrionContext _context;
        public ReporteDeCredito()
        {

            InitializeComponent();
            _fechaInicial = _fechaInicial;
            _fechaFinal = _fechaFinal;
            _context = new DbTiendaSeptentrionContext();
        }

        public void MostrarPDF(string rutaPDF)
        {
            webView21.Source = new Uri(rutaPDF);
        }

        public void GenerarPDF(string filePath)
        {
            try
            {
                // Convertir las fechas DateTime a DateOnly para la comparación
                DateOnly fechaInicialDateOnly = DateOnly.FromDateTime(_fechaInicial);
                DateOnly fechaFinalDateOnly = DateOnly.FromDateTime(_fechaFinal);

                //Obtener los datos de credito filtrados por fecha
                var listaCreditos = _context.VistaFacturaCreditos
                    .AsEnumerable()
                    .Where(c => c.FechaVenta >= fechaInicialDateOnly &&
                               c.FechaVenta <= fechaFinalDateOnly)
                    .ToList();

                // Ordenar por fecha
                listaCreditos = listaCreditos.OrderBy(c => c.FechaVenta).ToList();

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
                headerDiv.Add(new Paragraph("Reporte de Créditos")
                    .SetFont(boldFont)
                    .SetFontSize(16)
                    .SetMarginBottom(5));
                headerDiv.Add(new Paragraph($"Fecha: {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}")
                    .SetFont(font)
                    .SetFontSize(10));
                headerDiv.Add(new Paragraph($"Periodo: {_fechaInicial.ToString("dd/MM/yyyy")} - {_fechaFinal.ToString("dd/MM/yyyy")}")
                    .SetFont(font)
                    .SetFontSize(10));
                document.Add(headerDiv);

                // Crear tabla con 9 columnas
                Table table = new Table(9);
                table.UseAllAvailableWidth();
                table.SetBorder(new SolidBorder(1));
                table.SetMarginBottom(20);

                // Encabezados de tabla
                string[] headers = {
                    "FECHA DE VENTA",
                    "CEDULA CLIENTE",
                    "CLIENTE",
                    "MONTO DEL CRÉDITO",
                    "TOTAL ABONADO",
                    "NUEVO SALDO",
                    "PLAZOS (MESES)",
                    "INTERÉS MENSUAL",
                    "ESTADO"
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

                foreach (var credito in listaCreditos)
                {
                    table.AddCell(new Cell()
                         .Add(new Paragraph(credito.FechaVenta.ToString("dd/MM/yyyy"))
                             .SetFont(font)
                             .SetFontSize(9))
                         .SetTextAlignment(TextAlignment.CENTER)
                         .SetPadding(5)
                         .SetBorder(new SolidBorder(1)));

                    table.AddCell(new Cell()
                        .Add(new Paragraph(credito.CedulaCliente)
                            .SetFont(font)
                            .SetFontSize(9))
                        .SetTextAlignment(TextAlignment.LEFT)
                        .SetPadding(5)
                        .SetBorder(new SolidBorder(1)));

                    table.AddCell(new Cell()
                        .Add(new Paragraph(credito.Cliente)
                            .SetFont(font)
                            .SetFontSize(9))
                        .SetTextAlignment(TextAlignment.LEFT)
                        .SetPadding(5)
                        .SetBorder(new SolidBorder(1)));

                    table.AddCell(new Cell()
                        .Add(new Paragraph(credito.MontoCredito.ToString("N2"))
                            .SetFont(font)
                            .SetFontSize(9))
                        .SetTextAlignment(TextAlignment.RIGHT)
                        .SetPadding(5)
                        .SetBorder(new SolidBorder(1)));

                    table.AddCell(new Cell()
                        .Add(new Paragraph(credito.TotalAbonado.ToString("N2"))
                            .SetFont(font)
                            .SetFontSize(9))
                        .SetTextAlignment(TextAlignment.RIGHT)
                        .SetPadding(5)
                        .SetBorder(new SolidBorder(1)));

                    table.AddCell(new Cell()
                        .Add(new Paragraph(credito.NuevoSaldo.ToString("N2"))
                            .SetFont(font)
                            .SetFontSize(9))
                        .SetTextAlignment(TextAlignment.RIGHT)
                        .SetPadding(5)
                        .SetBorder(new SolidBorder(1)));

                    table.AddCell(new Cell()
                        .Add(new Paragraph(credito.PlazosMeses.ToString())
                            .SetFont(font)
                            .SetFontSize(9))
                        .SetTextAlignment(TextAlignment.CENTER)
                        .SetPadding(5)
                        .SetBorder(new SolidBorder(1)));

                    table.AddCell(new Cell()
                        .Add(new Paragraph(credito.InteresMensual.ToString("N2"))
                            .SetFont(font)
                            .SetFontSize(9))
                        .SetTextAlignment(TextAlignment.RIGHT)
                        .SetPadding(5)
                        .SetBorder(new SolidBorder(1)));

                    table.AddCell(new Cell()
                        .Add(new Paragraph(credito.EstadoCredito)
                            .SetFont(font)
                            .SetFontSize(9))
                        .SetTextAlignment(TextAlignment.LEFT)
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

        private void btnSalirReporteCredito_Click(object sender, EventArgs e)
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

        private void webView21_Click(object sender, EventArgs e)
        {


            try
            {
                string filePath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "ReporteDeCredito.pdf");
                GenerarPDF(filePath);
                MostrarPDF(filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el reporte: {ex.Message}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                string carpetaDestino = @"C:\ReportesTienda";
                if (!Directory.Exists(carpetaDestino))
                {
                    Directory.CreateDirectory(carpetaDestino);
                }

                string fileName = $"ReporteDeCredito_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";
                string filePath = System.IO.Path.Combine(carpetaDestino, fileName);

                GenerarPDF(filePath);
                MostrarPDF(filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el reporte: {ex.Message}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReporteDeCredito_Load(object sender, EventArgs e)
        {
            try
            {
                // Generar el PDF al cargar el formulario
                string filePath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "ReporteCredito.pdf");
                GenerarPDF(filePath);
                // Mostrar el PDF en el WebView
                MostrarPDF(filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el reporte: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

}
