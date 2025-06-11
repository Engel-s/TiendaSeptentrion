using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.IO.Font.Constants;
using iText.Layout.Borders;
using formstienda.Datos;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace formstienda.capa_de_presentación
{
    public partial class reporteventas : Form
    {
        private readonly DateTime _fechaInicio;
        private readonly DateTime _fechaFin;
        private readonly string _rutaPdf;
        public reporteventas()
        {
            InitializeComponent();

        }
        public reporteventas(DateTime fechaInicio, DateTime fechaFin, string rutaPdf)
        {
            InitializeComponent();
            _fechaInicio = fechaInicio;
            _fechaFin = fechaFin;
            _rutaPdf = rutaPdf;
        }




        private void FormReporteVentas_Load(object sender, EventArgs e)
        {
            if (!File.Exists(_rutaPdf))
                GenerarReporte(_fechaInicio, _fechaFin, _rutaPdf);

            if (File.Exists(_rutaPdf))
                webview.Source = new Uri(_rutaPdf);
        }

        private void GenerarReporte(DateTime fechaInicio, DateTime fechaFin, string rutaPdf)
        {
            var cultura = CultureInfo.GetCultureInfo("es-NI");
            var ventas = new List<DetalleDeVentum>();

            List<DetalleDeVentum> venta;

            using (var context = new DbTiendaSeptentrionContext())
            {
                DateOnly fechaInicioOnly = DateOnly.FromDateTime(fechaInicio);
                DateOnly fechaFinOnly = DateOnly.FromDateTime(fechaFin);

                ventas = context.DetalleDeVenta
                    .Include(d => d.CodigoProductoNavigation)
                        .ThenInclude(p => p.IdCategoriaNavigation)
                    .Include(d => d.CodigoProductoNavigation.IdMarcaNavigation)
                    .Include(d => d.IdVentaNavigation)
                        .ThenInclude(v => v.CedulaClienteNavigation)
                    .Where(d =>
                        d.IdVentaNavigation.FechaVenta >= fechaInicioOnly &&
                        d.IdVentaNavigation.FechaVenta <= fechaFinOnly &&
                        d.IdVentaNavigation.TipoPago == "Contado" &&
                        d.IdVentaNavigation.CambiosFactura == null // Aquí se excluyen ventas con devolución
                    )
                    .ToList();
            }


            using (var writer = new PdfWriter(rutaPdf))
            {
                var pdf = new PdfDocument(writer);
                var doc = new Document(pdf, iText.Kernel.Geom.PageSize.A4.Rotate());

                var font = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
                var normalFont = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);

                // ===== ENCABEZADO CON LOGO =====
                string rutaImagen = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Resources\logo_actualizado-removebg-preview.png");

                if (File.Exists(rutaImagen))
                {
                    var imgData = iText.IO.Image.ImageDataFactory.Create(rutaImagen);
                    var imagen = new iText.Layout.Element.Image(imgData)
                      .SetWidth(300)
                        .SetHeight(200)
                          .SetFixedPosition(pdf.GetDefaultPageSize().GetWidth() - 250, // X desde la derecha
                  pdf.GetDefaultPageSize().GetHeight() - 200); // Y desde arriba

                    var titulo = new Paragraph("Tienda El Septentrión")
                        .SetFont(font)
                        .SetFontSize(20)
                        .SetTextAlignment(TextAlignment.LEFT);

                    Table encabezadoTabla = new Table(new float[] { 4, 1 }).UseAllAvailableWidth();
                    encabezadoTabla.SetMarginBottom(10);

                    encabezadoTabla.AddCell(new Cell().Add(titulo)
                        .SetVerticalAlignment(VerticalAlignment.MIDDLE)
                        .SetBorder(Border.NO_BORDER));

                    encabezadoTabla.AddCell(new Cell().Add(imagen)
                        .SetTextAlignment(TextAlignment.RIGHT)
                        .SetBorder(Border.NO_BORDER));

                    doc.Add(encabezadoTabla);
                }
                else
                {
                    var titulo = new Paragraph("Tienda El Septentrión")
                        .SetFont(font)
                        .SetFontSize(20);
                    doc.Add(titulo);
                }

                // ===== TÍTULO DEL REPORTE =====
                var encabezado = new Paragraph("Reporte de Ventas")
                    .SetFont(font).SetFontSize(18);
                doc.Add(encabezado);

                doc.Add(new Paragraph($"Fecha: {DateTime.Now:dd/MM/yyyy HH:mm}"));
                doc.Add(new Paragraph($"Desde: {fechaInicio:dd/MM/yyyy} - Hasta: {fechaFin:dd/MM/yyyy}"));
                doc.Add(new Paragraph($"Registros: {ventas.Count}"));
                doc.Add(new Paragraph("\n"));

                // ===== TABLA DE VENTAS =====
                // ===== TABLA DE VENTAS =====
                // Quitamos la columna "Total venta" (de 10 → 9 columnas)
                var columnas = new float[] { 1.2f, 1.2f, 1.8f, 2.5f, 1.5f, 1.5f, 1.5f, 1.2f, 1.5f };
                var tabla = new Table(columnas).UseAllAvailableWidth();

                // Eliminamos "Total venta" del encabezado
                string[] headers = {
    "Fecha", "Factura", "Cliente", "Producto", "Categoría",
    "Marca", "Precio", "Cantidad", "Subtotal"
};

                foreach (var h in headers)
                {
                    tabla.AddHeaderCell(new Cell().Add(new Paragraph(h).SetFont(font).SetFontSize(9)
                        .SetBackgroundColor(new DeviceRgb(3, 171, 229))
                        .SetTextAlignment(TextAlignment.CENTER)));
                }

                foreach (var item in ventas)
                {
                    var ventum = item.IdVentaNavigation;
                    var producto = item.CodigoProductoNavigation;

                    tabla.AddCell(Celda(ventum.FechaVenta.ToString("dd/MM/yyyy")));
                    tabla.AddCell(Celda(ventum.IdVenta.ToString()));
                    tabla.AddCell(Celda(ventum.CedulaClienteNavigation?.NombreCliente ?? "Genérico"));
                    tabla.AddCell(Celda($"{producto.ModeloProducto} ({producto.CodigoProducto})"));
                    tabla.AddCell(Celda(producto.IdCategoriaNavigation?.Categoria ?? ""));
                    tabla.AddCell(Celda(producto.IdMarcaNavigation?.Marca1 ?? ""));
                    tabla.AddCell(Celda(decimal.Parse(item.Precio ?? "0").ToString("C", cultura)));
                    tabla.AddCell(Celda(item.Cantidad.ToString()));
                    tabla.AddCell(Celda(item.SubTotal?.ToString("C", cultura) ?? "C$0.00"));

                    // Eliminado: tabla.AddCell(Celda(ventum.TotalVenta.ToString("C", cultura)));
                }

                doc.Add(tabla);

                // ===== TOTAL VENTAS FINAL =====
                double totalGeneral = ventas.Sum(v => v.SubTotal ?? 0);
                var totalParagraph = new Paragraph($"\nTotal en ventas: {totalGeneral.ToString("C", cultura)}")
                    .SetFont(font)
                    .SetFontSize(12)
                    .SetTextAlignment(TextAlignment.RIGHT);

                doc.Add(totalParagraph);
                doc.Close();

            }

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private Cell Celda(string contenido)
        {
            return new Cell().Add(new Paragraph(contenido).SetFontSize(9))
                             .SetTextAlignment(TextAlignment.CENTER)
                             .SetVerticalAlignment(VerticalAlignment.MIDDLE);
        }

        private void btnvolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void reporteventas_Load(object sender, EventArgs e)
        {
            if (!File.Exists(_rutaPdf))
                GenerarReporte(_fechaInicio, _fechaFin, _rutaPdf);

            if (File.Exists(_rutaPdf))
                webview.Source = new Uri(_rutaPdf);
        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
