using formstienda.Datos;
using iText.IO.Font.Constants;
using iText.IO.Image;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using Microsoft.EntityFrameworkCore;
using System;
using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.IO;
using System.Linq;
using System.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms;


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

            using (var context = new DbTiendaSeptentrionContext())
            {
                DateOnly fi = DateOnly.FromDateTime(fechaInicio.Date);
                DateOnly ff = DateOnly.FromDateTime(fechaFin.Date);

                // 1) Traer devoluciones + cabecera + venta + cliente
                var devolucionesBase =
                    (from d in context.DetalleDevolucions.AsNoTracking()
                     join dev in context.DevolucionVentas.AsNoTracking() on d.IdDevolucion equals dev.IdDevolucion
                     join v in context.Venta.AsNoTracking() on dev.IdVenta equals v.IdVenta
                     join c in context.Clientes.AsNoTracking() on v.CedulaCliente equals c.CedulaCliente into cj
                     from c in cj.DefaultIfEmpty()
                     where d.FechaDevolucion >= fi && d.FechaDevolucion <= ff
                     select new
                     {
                         Detalle = d,
                         Devolucion = dev,
                         Venta = v,
                         Cliente = c
                     })
                    .ToList();

                // 2) Prefetch de DetalleDeVenta
                var idsVenta = devolucionesBase.Select(t => t.Venta.IdVenta).Distinct().ToList();

                var detallesVenta = context.DetalleDeVenta
                    .Where(dv => idsVenta.Contains(dv.IdVenta))
                    .AsNoTracking()
                    .ToList();

                // 3) Prefetch de Productos y cat/marca
                var codigos = detallesVenta.Select(dv => dv.CodigoProducto).Distinct().ToList();

                var productos = context.Productos
                    .Where(p => codigos.Contains(p.CodigoProducto))
                    .AsNoTracking()
                    .ToList();

                var idsCat = productos.Select(p => p.IdCategoria).Distinct().ToList();
                var idsMarca = productos.Select(p => p.IdMarca).Distinct().ToList();

                var categorias = context.Categoria
                    .Where(c => idsCat.Contains(c.IdCategoria))
                    .AsNoTracking()
                    .ToDictionary(c => c.IdCategoria, c => c.Categoria);

                var marcas = context.Marcas
                    .Where(m => idsMarca.Contains(m.IdMarca))
                    .AsNoTracking()
                    .ToDictionary(m => m.IdMarca, m => m.Marca1);

                var detallesPorVenta = detallesVenta
                    .GroupBy(dv => dv.IdVenta)
                    .ToDictionary(g => g.Key, g => g.ToList());

                var productoPorCodigo = productos
                    .GroupBy(p => p.CodigoProducto)
                    .ToDictionary(g => g.Key, g => g.First());

                // ======= Crear PDF =======
                using (var writer = new PdfWriter(rutaPdf))
                using (var pdf = new PdfDocument(writer))
                using (var doc = new Document(pdf, PageSize.A4.Rotate()))
                {
                    var fontBold = PdfFontFactory.CreateFont(iText.IO.Font.Constants.StandardFonts.HELVETICA_BOLD);
                    var fontNormal = PdfFontFactory.CreateFont(iText.IO.Font.Constants.StandardFonts.HELVETICA);

                    // Encabezado/logo (igual que tenías) ...
                    string rutaImagen = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Resources\LOGOVERSIONCORREGIDAJUDC.png");
                    if (File.Exists(rutaImagen))
                    {
                        var imgData = ImageDataFactory.Create(rutaImagen);
                        var imagen = new iText.Layout.Element.Image(imgData)
                            .SetWidth(215)
                            .SetHeight(200)
                            .SetFixedPosition(pdf.GetDefaultPageSize().GetWidth() - 200,
                                              pdf.GetDefaultPageSize().GetHeight() - 180);

                        var titulo = new Paragraph("Tienda El Septentrión")
                            .SetFont(fontBold).SetFontSize(20).SetTextAlignment(TextAlignment.LEFT);

                        var encabezadoTabla = new Table(new float[] { 4, 1 }).UseAllAvailableWidth();
                        encabezadoTabla.SetMarginBottom(10);
                        encabezadoTabla.AddCell(new Cell().Add(titulo).SetBorder(Border.NO_BORDER));
                        encabezadoTabla.AddCell(new Cell().Add(imagen).SetTextAlignment(TextAlignment.RIGHT).SetBorder(Border.NO_BORDER));
                        doc.Add(encabezadoTabla);
                    }
                    else
                    {
                        doc.Add(new Paragraph("Tienda El Septentrión").SetFont(fontBold).SetFontSize(20));
                    }

                    doc.Add(new Paragraph("Reporte de Devoluciones").SetFont(fontBold).SetFontSize(18));
                    doc.Add(new Paragraph($"Fecha: {DateTime.Now:dd/MM/yyyy HH:mm}"));
                    doc.Add(new Paragraph($"Desde: {fechaInicio:dd/MM/yyyy} - Hasta: {fechaFin:dd/MM/yyyy}"));
                    doc.Add(new Paragraph($"Registros: {devolucionesBase.Count}"));
                    doc.Add(new Paragraph("\n"));

                    var columnas = new float[] { 1.2f, 1.2f, 2f, 2.5f, 1.5f, 1.5f, 2f, 2f, 1.5f, 1.2f, 1.5f };
                    var tabla = new Table(columnas).UseAllAvailableWidth();

                    string[] headers = { "Fecha", "Factura", "Cliente", "Producto", "Categoría", "Marca", "Motivo", "Descripción", "Precio", "Cantidad", "Subtotal" };
                    foreach (var h in headers)
                    {
                        tabla.AddHeaderCell(new Cell()
                            .Add(new Paragraph(h).SetFont(fontBold).SetFontSize(9))
                            .SetBackgroundColor(new DeviceRgb(3, 171, 229))
                            .SetTextAlignment(TextAlignment.CENTER));
                    }

                    foreach (var t in devolucionesBase)
                    {
                        var d = t.Detalle;
                        var dev = t.Devolucion;
                        var v = t.Venta;
                        var cliNombre = t.Cliente?.NombreCliente ?? "Genérico";

                        // Match del detalle por código dentro de InformacionProducto
                        DetalleDeVentum? detalleMatch = null;
                        if (detallesPorVenta.TryGetValue(v.IdVenta, out var listaDetalles))
                        {
                            detalleMatch = listaDetalles.FirstOrDefault(x =>
                                !string.IsNullOrEmpty(x.CodigoProducto) &&
                                (d.InformacionProducto?.Contains(x.CodigoProducto) ?? false));
                        }

                        string productoTexto = d.InformacionProducto;
                        string categoriaTexto = "";
                        string marcaTexto = "";
                        decimal precioVenta = 0m;

                        if (detalleMatch != null && productoPorCodigo.TryGetValue(detalleMatch.CodigoProducto, out var prod))
                        {
                            productoTexto = $"{prod.ModeloProducto} ({prod.CodigoProducto})";
                            if (categorias.TryGetValue(prod.IdCategoria, out var catName)) categoriaTexto = catName;
                            if (marcas.TryGetValue(prod.IdMarca, out var marcaName)) marcaTexto = marcaName;

                            // DetalleDeVentum.Precio es string(10)
                            decimal.TryParse(detalleMatch.Precio ?? "0", NumberStyles.Any, CultureInfo.InvariantCulture, out precioVenta);
                        }

                        var subtotal = precioVenta * d.CantidadDevuelta;

                        // Celda(...) es tu helper existente
                        tabla.AddCell(Celda(dev.FechaDevolucion.ToString("dd/MM/yyyy")));
                        tabla.AddCell(Celda(v.IdVenta.ToString()));
                        tabla.AddCell(Celda(cliNombre));
                        tabla.AddCell(Celda(productoTexto));
                        tabla.AddCell(Celda(categoriaTexto));
                        tabla.AddCell(Celda(marcaTexto));
                        tabla.AddCell(Celda(dev.MotivoDevolucion));
                        tabla.AddCell(Celda(dev.DescripcionDevolucion));
                        tabla.AddCell(Celda(precioVenta.ToString("C", cultura)));
                        tabla.AddCell(Celda(d.CantidadDevuelta.ToString()));
                        tabla.AddCell(Celda(subtotal.ToString("C", cultura)));
                    }

                    doc.Add(tabla);

                    decimal totalGeneral = devolucionesBase.Sum(x => x.Detalle.MontoDevuelto);
                    doc.Add(new Paragraph("\n"));
                    doc.Add(new Paragraph($"Total general de devoluciones: {totalGeneral.ToString("C", cultura)}")
                        .SetFont(fontBold).SetFontSize(12).SetTextAlignment(TextAlignment.RIGHT));

                    // Marca de agua (igual que tenías)
                    try
                    {
                        byte[] watermarkImgBytes;
                        using (var ms = new MemoryStream())
                        {
                            formstienda.Properties.Resources.LOGOVERSIONCORREGIDAJUDC.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                            watermarkImgBytes = ms.ToArray();
                        }

                        float baseSize = 350f, widthScale = 1.8f;
                        float watermarkWidth = baseSize * widthScale, watermarkHeight = baseSize;

                        var watermark = new iText.Layout.Element.Image(ImageDataFactory.Create(watermarkImgBytes))
                            .SetOpacity(0.1f)
                            .SetWidth(watermarkWidth)
                            .SetHeight(watermarkHeight)
                            .SetFixedPosition(
                                pdf.GetDefaultPageSize().GetWidth() / 2 - (watermarkWidth / 2),
                                pdf.GetDefaultPageSize().GetHeight() / 2 - (watermarkHeight / 2),
                                watermarkWidth);

                        for (int i = 1; i <= pdf.GetNumberOfPages(); i++)
                        {
                            var page = pdf.GetPage(i);
                            var canvas = new PdfCanvas(page.NewContentStreamBefore(), page.GetResources(), pdf);
                            new iText.Layout.Canvas(canvas, page.GetPageSize()).Add(watermark).Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al crear marca de agua: " + ex.Message);
                    }
                } // using doc
            } // using context
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

        private void btnsalir_Click_1(object sender, EventArgs e)
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
    }
}

