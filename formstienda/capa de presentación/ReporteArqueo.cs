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
    public partial class ReporteArqueo : Form
    {
        private readonly DateTime _fechaInicial;
        private readonly DateTime _fechaFinal;
        private readonly string _usuarioSeleccionado;
        private readonly CultureInfo _nicaraguaCulture = new CultureInfo("es-NI");
        private DbTiendaSeptentrionContext _context;

        public ReporteArqueo(DateTime fechaInicial, DateTime fechaFinal, string usuarioSeleccionado)
        {
            InitializeComponent();
            _fechaInicial = fechaInicial;
            _fechaFinal = fechaFinal;
            _usuarioSeleccionado = usuarioSeleccionado;
            _context = new DbTiendaSeptentrionContext();
        }

        public void MostrarPDF(string rutaPDF)
        {
            webViewArqueo.Source = new Uri(rutaPDF);
        }

        public void GenerarPDF(string filePath)
        {
            try
            {
                var arqueos = _context.VistaArqueoCajaPorPeriodoCajeros.AsQueryable()
                    .Where(a => a.FechaArqueo >= _fechaInicial && a.FechaArqueo <= _fechaFinal);

                if (!string.IsNullOrEmpty(_usuarioSeleccionado))
                {
                    arqueos = arqueos.Where(a => a.Cajero.Contains(_usuarioSeleccionado));
                }

                var listaArqueos = arqueos.OrderBy(a => a.FechaArqueo).ToList();

                // Calcular totales
                decimal totalVendidoCordoba = (decimal)listaArqueos.Sum(a => a.TotalEfectivoCordoba);
                decimal totalVendidoDolar = (decimal)listaArqueos.Sum(a => a.TotalEfectivoDolar);
                decimal totalCajaCordoba = (decimal)listaArqueos.Sum(a => a.TotalEfectivoCordoba);
                decimal totalCajaDolar = (decimal)listaArqueos.Sum(a => a.TotalEfectivoDolar);
                decimal totalSobranteCordoba = (decimal)listaArqueos.Sum(a => a.SobranteCordoba ?? 0);
                decimal totalSobranteDolar = (decimal)listaArqueos.Sum(a => a.SobranteDolar ?? 0);
                decimal totalFaltanteCordoba = (decimal)listaArqueos.Sum(a => a.FaltanteCordoba ?? 0);
                decimal totalFaltanteDolar = (decimal)listaArqueos.Sum(a => a.FaltanteDolar ?? 0);

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

                headerDiv.Add(new Paragraph("Reporte de Arqueos de Caja")
                    .SetFont(boldFont)
                    .SetFontSize(16)
                    .SetMarginBottom(5));

                headerDiv.Add(new Paragraph($"Fecha: {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}")
                    .SetFont(font)
                    .SetFontSize(10));

                headerDiv.Add(new Paragraph($"Periodo: {_fechaInicial.ToString("dd/MM/yyyy")} - {_fechaFinal.ToString("dd/MM/yyyy")}")
                    .SetFont(font)
                    .SetFontSize(10));

                if (!string.IsNullOrEmpty(_usuarioSeleccionado))
                {
                    headerDiv.Add(new Paragraph($"Cajero: {_usuarioSeleccionado}")
                        .SetFont(font)
                        .SetFontSize(10));
                }

                document.Add(headerDiv);

                // Crear tabla con 10 columnas
                Table table = new Table(10);
                table.UseAllAvailableWidth();
                table.SetBorder(new SolidBorder(1));
                table.SetMarginBottom(20);

                // Encabezados de tabla
                string[] headers = {
                    "FECHA",
                    "USUARIO",
                    "TOTAL VENDIDO C$",
                    "TOTAL VENDIDO $",
                    "TOTAL EN CAJA C$",
                    "TOTAL EN CAJA $",
                    "SOBRANTE C$",
                    "SOBRANTE $",
                    "FALTANTE C$",
                    "FALTANTE $"
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

                // Datos de la tabla
                foreach (var item in listaArqueos)
                {
                    // Fecha
                    table.AddCell(new Cell()
                        .Add(new Paragraph(item.FechaArqueo.ToString("dd/MM/yyyy"))
                        .SetFont(font)
                        .SetFontSize(9))
                        .SetTextAlignment(TextAlignment.CENTER)
                        .SetPadding(5)
                        .SetBorder(new SolidBorder(1)));

                    // Usuario
                    table.AddCell(new Cell()
                        .Add(new Paragraph(item.Cajero)
                            .SetFont(font)
                            .SetFontSize(9))
                            
                        .SetTextAlignment(TextAlignment.LEFT)
                        .SetPadding(5)
                        .SetBorder(new SolidBorder(1))
                        .SetWidth(80));


                    // Total Vendido Córdoba
                    table.AddCell(new Cell()
                        .Add(new Paragraph(item.TotalEfectivoCordoba.ToString("C", _nicaraguaCulture))
                        .SetFont(font)
                        .SetFontSize(9))
                        .SetTextAlignment(TextAlignment.RIGHT)
                        .SetPadding(5)
                        .SetBorder(new SolidBorder(1)));

                    // Total Vendido Dólar
                    table.AddCell(new Cell()
                        .Add(new Paragraph(item.TotalEfectivoDolar?.ToString("C", CultureInfo.GetCultureInfo("en-US")) ?? "-"))
                        .SetFont(font)
                        .SetFontSize(9))
                        .SetTextAlignment(TextAlignment.RIGHT)
                        .SetPadding(5)
                        .SetBorder(new SolidBorder(1));

                    // Total en Caja Córdoba
                    table.AddCell(new Cell()
                        .Add(new Paragraph(item.TotalEfectivoCordoba.ToString("C", _nicaraguaCulture))
                        .SetFont(font)
                        .SetFontSize(9))
                        .SetTextAlignment(TextAlignment.RIGHT)
                        .SetPadding(5)
                        .SetBorder(new SolidBorder(1)));

                    // Total en Caja Dólar
                    table.AddCell(new Cell()
                        .Add(new Paragraph(item.TotalEfectivoDolar?.ToString("C", CultureInfo.GetCultureInfo("en-US")) ?? "-"))
                        .SetFont(font)
                        .SetFontSize(9))
                        .SetTextAlignment(TextAlignment.RIGHT)
                        .SetPadding(5)
                        .SetBorder(new SolidBorder(1));

                    // Sobrante Córdoba
                    table.AddCell(new Cell()
                        .Add(new Paragraph(item.SobranteCordoba?.ToString("C", _nicaraguaCulture) ?? "-")
                        .SetFont(font)
                        .SetFontSize(9))
                        .SetTextAlignment(TextAlignment.RIGHT)
                        .SetPadding(5)
                        .SetBorder(new SolidBorder(1)));

                    // Sobrante Dólar
                    table.AddCell(new Cell()
                        .Add(new Paragraph(item.SobranteDolar?.ToString("C", CultureInfo.GetCultureInfo("en-US")) ?? "-")
                        .SetFont(font)
                        .SetFontSize(9))
                        .SetTextAlignment(TextAlignment.RIGHT)
                        .SetPadding(5)
                        .SetBorder(new SolidBorder(1)));

                    // Faltante Córdoba
                    table.AddCell(new Cell()
                        .Add(new Paragraph(item.FaltanteCordoba?.ToString("C", _nicaraguaCulture) ?? "-")
                        .SetFont(font)
                        .SetFontSize(9))
                        .SetTextAlignment(TextAlignment.RIGHT)
                        .SetPadding(5)
                        .SetBorder(new SolidBorder(1)));

                    // Faltante Dólar
                    table.AddCell(new Cell()
                        .Add(new Paragraph(item.FaltanteDolar?.ToString("C", CultureInfo.GetCultureInfo("en-US")) ?? "-")
                        .SetFont(font)
                        .SetFontSize(9))
                        .SetTextAlignment(TextAlignment.RIGHT)
                        .SetPadding(5)
                        .SetBorder(new SolidBorder(1)));
                }

                // Agregar fila de TOTALES
                table.AddCell(new Cell(1, 1)
                    .Add(new Paragraph("TOTALES")
                        .SetFont(boldFont)
                        .SetFontSize(10))
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetBackgroundColor(new DeviceRgb(221, 221, 221))
                    .SetPadding(5)
                    .SetBorder(new SolidBorder(1)));

                //Celda Vacia
                table.AddCell(new Cell()
                    .Add(new Paragraph(""))
                    .SetBackgroundColor(new DeviceRgb(221, 221, 221))
                    .SetPadding(5)
                    .SetBorder(new SolidBorder(1)));


                // Total Vendido Córdoba
                table.AddCell(new Cell()
                    .Add(new Paragraph(totalVendidoCordoba.ToString("C", _nicaraguaCulture))
                    .SetFont(boldFont)
                    .SetFontSize(10))
                    .SetTextAlignment(TextAlignment.RIGHT)
                    .SetBackgroundColor(new DeviceRgb(221, 221, 221))
                    .SetPadding(5)
                    .SetBorder(new SolidBorder(1)));

                // Total Vendido Dólar
                table.AddCell(new Cell()
                    .Add(new Paragraph(totalVendidoDolar.ToString("C", CultureInfo.GetCultureInfo("en-US")))
                    .SetFont(boldFont)
                    .SetFontSize(10))
                    .SetTextAlignment(TextAlignment.RIGHT)
                    .SetBackgroundColor(new DeviceRgb(221, 221, 221))
                    .SetPadding(5)
                    .SetBorder(new SolidBorder(1)));

                // Total en Caja Córdoba
                table.AddCell(new Cell()
                    .Add(new Paragraph(totalCajaCordoba.ToString("C", _nicaraguaCulture))
                    .SetFont(boldFont)
                    .SetFontSize(10))
                    .SetTextAlignment(TextAlignment.RIGHT)
                    .SetBackgroundColor(new DeviceRgb(221, 221, 221))
                    .SetPadding(5)
                    .SetBorder(new SolidBorder(1)));

                // Total en Caja Dólar
                table.AddCell(new Cell()
                    .Add(new Paragraph(totalCajaDolar.ToString("C", CultureInfo.GetCultureInfo("en-US")))
                    .SetFont(boldFont)
                    .SetFontSize(10))
                    .SetTextAlignment(TextAlignment.RIGHT)
                    .SetBackgroundColor(new DeviceRgb(221, 221, 221))
                    .SetPadding(5)
                    .SetBorder(new SolidBorder(1)));

                // Sobrante Córdoba
                table.AddCell(new Cell()
                    .Add(new Paragraph(totalSobranteCordoba.ToString("C", _nicaraguaCulture))
                    .SetFont(boldFont)
                    .SetFontSize(10))
                    .SetTextAlignment(TextAlignment.RIGHT)
                    .SetBackgroundColor(new DeviceRgb(221, 221, 221))
                    .SetPadding(5)
                    .SetBorder(new SolidBorder(1)));

                // Sobrante Dólar
                table.AddCell(new Cell()
                    .Add(new Paragraph(totalSobranteDolar.ToString("C", CultureInfo.GetCultureInfo("en-US")))
                    .SetFont(boldFont)
                    .SetFontSize(10))
                    .SetTextAlignment(TextAlignment.RIGHT)
                    .SetBackgroundColor(new DeviceRgb(221, 221, 221))
                    .SetPadding(5)
                    .SetBorder(new SolidBorder(1)));

                // Faltante Córdoba
                table.AddCell(new Cell()
                    .Add(new Paragraph(totalFaltanteCordoba.ToString("C", _nicaraguaCulture))
                    .SetFont(boldFont)
                    .SetFontSize(10))
                    .SetTextAlignment(TextAlignment.RIGHT)
                    .SetBackgroundColor(new DeviceRgb(221, 221, 221))
                    .SetPadding(5)
                    .SetBorder(new SolidBorder(1)));

                // Faltante Dólar
                table.AddCell(new Cell()
                    .Add(new Paragraph(totalFaltanteDolar.ToString("C", CultureInfo.GetCultureInfo("en-US")))
                    .SetFont(boldFont)
                    .SetFontSize(10))
                    .SetTextAlignment(TextAlignment.RIGHT)
                    .SetBackgroundColor(new DeviceRgb(221, 221, 221))
                    .SetPadding(5)
                    .SetBorder(new SolidBorder(1)));

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

        private void webViewArqueo_Click(object sender, EventArgs e)
        {
          
        }

        private void ReporteArqueo_Load(object sender, EventArgs e)
        {
           
        }

        private void btnSalirArqueo_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}