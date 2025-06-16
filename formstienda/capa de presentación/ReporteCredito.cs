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
    public partial class ReporteCredito : Form
    {
        private readonly DateTime _fechaInicial;
        private readonly DateTime _fechaFinal;
        private readonly string _clienteSeleccionado;
        private readonly CultureInfo _nicaraguaCulture = new CultureInfo("es-NI");
        private DbTiendaSeptentrionContext _context;

        public ReporteCredito(DateTime fechaInicial, DateTime fechaFinal, string clienteSeleccionado)
        {
            InitializeComponent();
            _fechaInicial = fechaInicial.Date;
            _fechaFinal = fechaFinal.Date;
            _clienteSeleccionado = clienteSeleccionado;
            _context = new DbTiendaSeptentrionContext();
        }

        public void MostrarPDF(string rutaPDF)
        {
            webViewCredito.Source = new Uri(rutaPDF);
        }

        public void GenerarPDF(string filePath)
        {
            try
            {
                // Verificar conexión a la base de datos
                if (!_context.Database.CanConnect())
                {
                    MessageBox.Show("No se pudo conectar a la base de datos", "Error",
                                 MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Filtrar por FechaDeVenta
                var query = _context.VistaDetalleCreditoClientes.AsQueryable()
                    .Where(c => c.FechaDeVenta >= DateOnly.FromDateTime(_fechaInicial) &&
                                c.FechaDeVenta <= DateOnly.FromDateTime(_fechaFinal));

                if (!string.IsNullOrEmpty(_clienteSeleccionado))
                {
                    query = query.Where(c => c.NombreDelCliente.Contains(_clienteSeleccionado));
                }

                var listaCreditos = query.OrderBy(c => c.NombreDelCliente)
                                       .ThenBy(c => c.FechaDeVenta)
                                       .ToList();

                // Calcular totales
                decimal totalCredito = listaCreditos.Sum(c => (decimal)c.TotalCrédito);
                decimal totalPagado = listaCreditos.Sum(c => c.Total ?? 0);
                decimal saldoPendiente = totalCredito - totalPagado;

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

                headerDiv.Add(new Paragraph("Reporte de Créditos por Fecha de Venta")
                    .SetFont(boldFont)
                    .SetFontSize(16)
                    .SetMarginBottom(5));

                headerDiv.Add(new Paragraph($"Fecha de generación: {DateTime.Now:dd/MM/yyyy HH:mm:ss}")
                    .SetFont(font)
                    .SetFontSize(10));

                headerDiv.Add(new Paragraph($"Periodo de ventas: {_fechaInicial:dd/MM/yyyy} - {_fechaFinal:dd/MM/yyyy}")
                    .SetFont(font)
                    .SetFontSize(10));

                if (!string.IsNullOrEmpty(_clienteSeleccionado))
                {
                    headerDiv.Add(new Paragraph($"Cliente: {_clienteSeleccionado}")
                        .SetFont(font)
                        .SetFontSize(10));
                    headerDiv.Add(new Paragraph($"Teléfono: {listaCreditos.FirstOrDefault()?.TeléfonoCliente ?? "N/A"}")
                        .SetFont(font)
                        .SetFontSize(10));
                    headerDiv.Add(new Paragraph($"Dirección: {listaCreditos.FirstOrDefault()?.Dirección ?? "N/A"}")
                        .SetFont(font)
                        .SetFontSize(10));
                }

                document.Add(headerDiv);

                // Crear tabla (reducida en 1 columna al eliminar Subtotal)
                int columnCount = string.IsNullOrEmpty(_clienteSeleccionado) ? 10 : 9;
                Table table = new Table(columnCount);
                table.UseAllAvailableWidth();
                table.SetBorder(new SolidBorder(1));
                table.SetMarginBottom(20);

                // Encabezados de tabla (sin Subtotal)
                List<string> headers = new List<string> {
                    "No. Factura",
                    "Fecha Venta",
                    "Producto",
                    "Categoría",
                    "Marca",
                    "Precio Unit.",
                    "Cantidad",
                    "Total Pagado",
                    "Fecha Pago"
                };

                if (string.IsNullOrEmpty(_clienteSeleccionado))
                {
                    headers.Insert(2, "Cliente");
                }

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

                // Datos de la tabla (sin Subtotal)
                foreach (var item in listaCreditos)
                {
                    // Factura
                    table.AddCell(new Cell()
                        .Add(new Paragraph(item.Factura.ToString())
                        .SetFont(font)
                        .SetFontSize(9))
                        .SetTextAlignment(TextAlignment.CENTER)
                        .SetPadding(5)
                        .SetBorder(new SolidBorder(1)));

                    // Fecha de Venta
                    table.AddCell(new Cell()
                        .Add(new Paragraph(item.FechaDeVenta.ToString("dd/MM/yyyy"))
                        .SetFont(font)
                        .SetFontSize(9))
                        .SetTextAlignment(TextAlignment.CENTER)
                        .SetPadding(5)
                        .SetBorder(new SolidBorder(1)));

                    // Cliente
                    if (string.IsNullOrEmpty(_clienteSeleccionado))
                    {
                        table.AddCell(new Cell()
                            .Add(new Paragraph(item.NombreDelCliente)
                            .SetFont(font)
                            .SetFontSize(9))
                            .SetTextAlignment(TextAlignment.LEFT)
                            .SetPadding(5)
                            .SetBorder(new SolidBorder(1)));
                    }

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
                        .Add(new Paragraph(item.Categoría)
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

                    // Precio Unitario
                    table.AddCell(new Cell()
                        .Add(new Paragraph(item.PrecioDeVenta?.ToString("C", _nicaraguaCulture) ?? "-")
                        .SetFont(font)
                        .SetFontSize(9))
                        .SetTextAlignment(TextAlignment.RIGHT)
                        .SetPadding(5)
                        .SetBorder(new SolidBorder(1)));

                    // Cantidad
                    table.AddCell(new Cell()
                        .Add(new Paragraph(item.Cantidad.ToString())
                        .SetFont(font)
                        .SetFontSize(9))
                        .SetTextAlignment(TextAlignment.CENTER)
                        .SetPadding(5)
                        .SetBorder(new SolidBorder(1)));

                    // Total Pagado
                    table.AddCell(new Cell()
                        .Add(new Paragraph(item.Total?.ToString("C", _nicaraguaCulture) ?? "-")
                        .SetFont(font)
                        .SetFontSize(9))
                        .SetTextAlignment(TextAlignment.RIGHT)
                        .SetPadding(5)
                        .SetBorder(new SolidBorder(1)));

                    // Fecha de Pago
                    table.AddCell(new Cell()
                        .Add(new Paragraph(item.FechaDePago?.ToString("dd/MM/yyyy") ?? "PENDIENTE")
                        .SetFont(font)
                        .SetFontSize(9))
                        .SetTextAlignment(TextAlignment.CENTER)
                        .SetPadding(5)
                        .SetBorder(new SolidBorder(1)));

                }

                // Fila de TOTALES
                int colspan = string.IsNullOrEmpty(_clienteSeleccionado) ? 9 : 8;
                table.AddCell(new Cell(1, 1)
                    .Add(new Paragraph("TOTALES")
                        .SetFont(boldFont)
                        .SetFontSize(10))
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetBackgroundColor(new DeviceRgb(221, 221, 221))
                    .SetPadding(5)
                    .SetBorder(new SolidBorder(1)));

                // Celdas vacías intermedias
                for (int i = 1; i < colspan - 1; i++)
                {
                    table.AddCell(new Cell()
                        .Add(new Paragraph(""))
                        .SetBackgroundColor(new DeviceRgb(221, 221, 221))
                        .SetPadding(5)
                        .SetBorder(new SolidBorder(1)));
                }

                // Total Pagado
                table.AddCell(new Cell()
                    .Add(new Paragraph(totalPagado.ToString("C", _nicaraguaCulture))
                    .SetFont(boldFont)
                    .SetFontSize(10))
                    .SetTextAlignment(TextAlignment.RIGHT)
                    .SetBackgroundColor(new DeviceRgb(221, 221, 221))
                    .SetPadding(5)
                    .SetBorder(new SolidBorder(1)));

                //Celda Vacía para Fecha de Pago
                table.AddCell(new Cell()
                    .Add(new Paragraph(""))
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
                  
                }

                document.Close();
            }
            catch (Exception ex)
            {
               
            }
        }

        private void webViewCredito_Click(object sender, EventArgs e)
        {
          
        }

        private void ReporteCredito_Load(object sender, EventArgs e)
        {
            try
            {
                string filePath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), $"ReporteCredito_{DateTime.Now:yyyyMMdd_HHmmss}.pdf");
                GenerarPDF(filePath);
                MostrarPDF(filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el reporte: {ex.Message}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalirArqueo_Click(object sender, EventArgs e)
        {
            // Cerrar el formulario actual y abrir el formulario Informes en el panel del menú principal
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
    }
}