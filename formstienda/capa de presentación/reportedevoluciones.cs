using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using iText.IO.Font.Constants;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using formstienda.Datos;
using Microsoft.EntityFrameworkCore;

namespace formstienda.capa_de_presentación
{
    public partial class reportedevoluciones : Form
    {
        private readonly DateTime _fechainicio;
        private readonly DateTime _fechafin;
        private readonly string _rutaPdf;
        public reportedevoluciones()
        {
            InitializeComponent();
        }
        public reportedevoluciones(DateTime fechaInicio, DateTime fechaFin, string rutaPdf)
        {
            InitializeComponent();
            _fechainicio = fechaInicio;
            _fechafin = fechaFin;
            _rutaPdf = rutaPdf;
        }


        private void GenerarReporte(DateTime fechaInicio, DateTime fechaFin, string rutaPdf)
        {
            var cultura = CultureInfo.GetCultureInfo("es-NI");
            var devoluciones = new List<DetalleDevolucion>();

            using (var context = new DbTiendaSeptentrionContext())
            {
                DateOnly fechaInicioOnly = DateOnly.FromDateTime(fechaInicio);
                DateOnly fechaFinOnly = DateOnly.FromDateTime(fechaFin);

                devoluciones = context.DetalleDevolucions
                    .Include(d => d.IdDevolucionNavigation)
                        .ThenInclude(dev => dev.IdVentaNavigation)
                            .ThenInclude(ven => ven.CedulaClienteNavigation)
                    .Include(d => d.IdDevolucionNavigation.IdVentaNavigation.DetalleDeVenta)
                        .ThenInclude(v => v.CodigoProductoNavigation)
                            .ThenInclude(p => p.IdCategoriaNavigation)
                    .Include(d => d.IdDevolucionNavigation.IdVentaNavigation.DetalleDeVenta)
                        .ThenInclude(v => v.CodigoProductoNavigation.IdMarcaNavigation)
                    .Where(d => d.FechaDevolucion >= fechaInicioOnly && d.FechaDevolucion <= fechaFinOnly)
                    .ToList();
            }

            using (var writer = new PdfWriter(rutaPdf))
            {
                var pdf = new PdfDocument(writer);
                var doc = new Document(pdf, iText.Kernel.Geom.PageSize.A4.Rotate());

                var fontBold = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
                var fontNormal = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);

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
                        .SetFont(fontBold)
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
                        .SetFont(fontBold)
                        .SetFontSize(20);
                    doc.Add(titulo);
                }

                // ===== TITULO Y FILTROS DE REPORTE =====
                doc.Add(new Paragraph("Reporte de Devoluciones")
                    .SetFont(fontBold)
                    .SetFontSize(18));

                doc.Add(new Paragraph($"Fecha: {DateTime.Now:dd/MM/yyyy HH:mm}"));
                doc.Add(new Paragraph($"Desde: {fechaInicio:dd/MM/yyyy} - Hasta: {fechaFin:dd/MM/yyyy}"));
                doc.Add(new Paragraph($"Registros: {devoluciones.Count}"));
                doc.Add(new Paragraph("\n"));

                // ===== TABLA DE DATOS =====
                // ===== TABLA DE DATOS =====
                var columnas = new float[] { 1.2f, 1.2f, 2f, 2.5f, 1.5f, 1.5f, 2f, 2f, 1.5f, 1.2f, 1.5f }; // 👈 11 columnas
                var tabla = new Table(columnas).UseAllAvailableWidth();

                string[] headers = {
    "Fecha", "Factura", "Cliente", "Producto", "Categoría", "Marca",
    "Motivo", "Descripción", "Precio", "Cantidad", "Subtotal" // 👈 sin "Total devolución"
};

                foreach (var h in headers)
                {
                    tabla.AddHeaderCell(new Cell().Add(new Paragraph(h).SetFont(fontBold).SetFontSize(9)
                        .SetBackgroundColor(new DeviceRgb(3, 171, 229))
                        .SetTextAlignment(TextAlignment.CENTER)));
                }

                foreach (var item in devoluciones)
                {
                    var devolucion = item.IdDevolucionNavigation;
                    var venta = devolucion.IdVentaNavigation;
                    var cliente = venta.CedulaClienteNavigation?.NombreCliente ?? "Genérico";

                    var detalleVenta = venta.DetalleDeVenta
                        .FirstOrDefault(d => item.InformacionProducto.Contains(d.CodigoProductoNavigation.CodigoProducto));

                    var producto = detalleVenta?.CodigoProductoNavigation;
                    var precioVenta = decimal.Parse(detalleVenta?.Precio ?? "0");
                    var subtotal = precioVenta * item.CantidadDevuelta;

                    tabla.AddCell(Celda(devolucion.FechaDevolucion.ToString("dd/MM/yyyy")));
                    tabla.AddCell(Celda(venta.IdVenta.ToString()));
                    tabla.AddCell(Celda(cliente));
                    tabla.AddCell(Celda(producto != null ? $"{producto.ModeloProducto} ({producto.CodigoProducto})" : item.InformacionProducto));
                    tabla.AddCell(Celda(producto?.IdCategoriaNavigation?.Categoria ?? ""));
                    tabla.AddCell(Celda(producto?.IdMarcaNavigation?.Marca1 ?? ""));
                    tabla.AddCell(Celda(devolucion.MotivoDevolucion));
                    tabla.AddCell(Celda(devolucion.DescripcionDevolucion));
                    tabla.AddCell(Celda(precioVenta.ToString("C", cultura)));
                    tabla.AddCell(Celda(item.CantidadDevuelta.ToString()));
                    tabla.AddCell(Celda(subtotal.ToString("C", cultura)));
                }

                doc.Add(tabla);

                // ===== TOTAL GENERAL DE DEVOLUCIONES =====
                decimal totalGeneral = devoluciones.Sum(d => d.MontoDevuelto);

                doc.Add(new Paragraph("\n"));
                doc.Add(new Paragraph($"Total general de devoluciones: {totalGeneral.ToString("C", cultura)}")
                    .SetFont(fontBold)
                    .SetFontSize(12)
                    .SetTextAlignment(TextAlignment.RIGHT)); // 👈 alineado a la derecha

                doc.Close();

            }

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

        private void reportedevoluciones_Load(object sender, EventArgs e)
        {
            if (!File.Exists(_rutaPdf))
                GenerarReporte(_fechainicio, _fechafin, _rutaPdf);

            if (File.Exists(_rutaPdf))
                webviewdevoluciones.Source = new Uri(_rutaPdf);
        }

        private void reportedevoluciones_Load_1(object sender, EventArgs e)
        {
            if (!File.Exists(_rutaPdf))
                GenerarReporte(_fechainicio, _fechafin, _rutaPdf);

            if (File.Exists(_rutaPdf))
                webviewdevoluciones.Source = new Uri(_rutaPdf);
        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

