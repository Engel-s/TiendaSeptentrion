using formstienda.capa_de_negocios;
using formstienda.Datos;
using iText.IO.Font;
using iText.IO.Font.Constants;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.Storage.Json;
using Microsoft.Web.WebView2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace formstienda.capa_de_presentación
{
    public partial class FormReportesCompras : Form
    {
        private readonly DetalleCompraServicio _detalleCompraServicio;
        private readonly DateTime _fechaInicio;
        private readonly DateTime _fechaFin;
        private readonly string rutaPdf;
        private readonly string _rucProveedor;
        public FormReportesCompras(DateTime fechaInicio, DateTime fechaFin, string rutaPDF, string rucProveedor = null)
        {
            InitializeComponent();
            _detalleCompraServicio = new DetalleCompraServicio();
            _fechaInicio = fechaInicio;
            _fechaFin = fechaFin;
            rutaPdf = rutaPDF;
            _rucProveedor = rucProveedor;
        }

        private Cell Celda(object valor)
        {
            return new Cell()
                    .Add(new Paragraph(valor?.ToString() ?? "").SetFontSize(9))
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetVerticalAlignment(VerticalAlignment.MIDDLE);
        }

        public string GenerarReporte(DateTime fechainicio, DateTime fechafin, string rutapdf, string rucProveedor = null)
        {
            try
            {
                var compras = _detalleCompraServicio.ObtenerDetallesParaReportes()
                    .Where(c => c.FechaCompra.Date >= fechainicio.Date && c.FechaCompra.Date <= fechafin.Date)
                    .ToList();


                if (!string.IsNullOrEmpty(rucProveedor))
                {
                    compras = compras.Where(c => !string.IsNullOrEmpty(c.RucProveedor) &&
                    c.RucProveedor.Trim().Equals(rucProveedor.Trim(), StringComparison.OrdinalIgnoreCase)
                    ).ToList();
                }

                var listaFiltrada = compras;

                using (var stream = new FileStream(rutapdf, FileMode.Create, FileAccess.Write))
                {
                    //Crear variables
                    var monedaNic = CultureInfo.GetCultureInfo("es-NI");
                    var writer = new PdfWriter(stream);
                    var pdfDoc = new PdfDocument(writer);
                    var document = new Document(pdfDoc, PageSize.A4.Rotate());


                    // 2. Agregar titulo
                    // crear un font bold
                    var boldFont = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
                    var normalfont = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);

                    //Aplicar esta fuente a un parrafo
                    var parrafo = new Paragraph("Reporte de Compras")
                        .SetFont(boldFont)
                        .SetFontSize(15);


                    //ruta imagen
                    string rutaImagen = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Resources\LOGOVERSIONCORREGIDAJUDC.png");

                    // Verifica que la imagen exista
                    if (File.Exists(rutaImagen))
                    {
                        // Cargar imagen
                        var imgData = iText.IO.Image.ImageDataFactory.Create(rutaImagen);
                        var imagen = new iText.Layout.Element.Image(imgData)
                                        .SetWidth(215)
                                        .SetHeight(200)
                                        .SetFixedPosition(pdfDoc.GetDefaultPageSize().GetWidth() - 200, // X desde la derecha
                                      pdfDoc.GetDefaultPageSize().GetHeight() - 180); // Y desde arriba

                        // Texto del título
                        var titulo = new Paragraph("Tienda El Septentrión")
                                        .SetFont(boldFont)
                                        .SetFontSize(20)
                                        .SetTextAlignment(TextAlignment.LEFT);

                        //Tabla con 2 columnas: imagen y texto
                        Table encabezadoTabla = new Table(new float[] { 4, 1 }).UseAllAvailableWidth();
                        encabezadoTabla.SetMarginBottom(10);

                        encabezadoTabla.AddCell(new Cell().Add(titulo)
                                        .SetVerticalAlignment(VerticalAlignment.MIDDLE)
                                        .SetBorder(Border.NO_BORDER));

                        encabezadoTabla.AddCell(new Cell().Add(imagen)
                                        .SetTextAlignment(TextAlignment.RIGHT)
                                        .SetBorder(Border.NO_BORDER));


                        document.Add(encabezadoTabla);
                    }
                    else
                    {
                        var titulo = new Paragraph("Tienda El Septentrión")
                                        .SetFont(boldFont)
                                        .SetFontSize(20);
                        document.Add(titulo);
                    }


                    //document.Add(titulo);
                    document.Add(parrafo);
                    document.Add(new Paragraph($"Fecha: {DateTime.Now}"));
                    document.Add(new Paragraph($"Registros:{compras.Count}"));
                    document.Add(new Paragraph($"Desde: {fechainicio:dd/MM/yyyy} - Hasta: {fechafin:dd/MM/yyyy}"));

                    if (!string.IsNullOrEmpty(rucProveedor))
                    {
                        document.Add(new Paragraph($"RUC: {rucProveedor}"));
                    }

                    document.Add(new Paragraph("\n"));

                    //crear tabla
                    float[] anchos = { 1f, 1f, 1f, 1.8f, 1f, 1f, 1.5f, 1f, 1.8f };
                    var tabla = new Table(UnitValue.CreatePercentArray(anchos))
                        .UseAllAvailableWidth();

                    var colorEncabezado = new DeviceRgb(3, 171, 229);

                    //encabezados
                    tabla.AddHeaderCell(new Cell().Add(new Paragraph("Fecha").SetFont(boldFont).SetFontSize(10)
                        .SetBackgroundColor(colorEncabezado).SetBorder(new SolidBorder(colorEncabezado, 0f))));
                    tabla.AddHeaderCell(new Cell().Add(new Paragraph("Factura").SetFont(boldFont).SetFontSize(10)
                        .SetBackgroundColor(colorEncabezado).SetBorder(new SolidBorder(colorEncabezado, 0f))));
                    tabla.AddHeaderCell(new Cell().Add(new Paragraph("Proveedor").SetFont(boldFont).SetFontSize(10)
                        .SetBackgroundColor(colorEncabezado).SetBorder(new SolidBorder(colorEncabezado, 0f))));
                    tabla.AddHeaderCell(new Cell().Add(new Paragraph("Producto").SetFont(boldFont).SetFontSize(10)
                        .SetBackgroundColor(colorEncabezado).SetBorder(new SolidBorder(colorEncabezado, 0f))));
                    tabla.AddHeaderCell(new Cell().Add(new Paragraph("Categoria").SetFont(boldFont).SetFontSize(10)
                        .SetBackgroundColor(colorEncabezado).SetBorder(new SolidBorder(colorEncabezado, 0f))));
                    tabla.AddHeaderCell(new Cell().Add(new Paragraph("Marca").SetFont(boldFont).SetFontSize(10)
                        .SetBackgroundColor(colorEncabezado).SetBorder(new SolidBorder(colorEncabezado, 0f))));
                    tabla.AddHeaderCell(new Cell().Add(new Paragraph("Precio compra").SetFont(boldFont).SetFontSize(10)
                        .SetBackgroundColor(colorEncabezado).SetBorder(new SolidBorder(colorEncabezado, 0f))));
                    tabla.AddHeaderCell(new Cell().Add(new Paragraph("Cantidad").SetFont(boldFont)
                        .SetFontSize(10).SetBackgroundColor(colorEncabezado).SetBorder(new SolidBorder(colorEncabezado, 0f))));
                    tabla.AddHeaderCell(new Cell().Add(new Paragraph("Total").SetFont(boldFont).SetFontSize(10)
                        .SetBackgroundColor(colorEncabezado).SetBorder(new SolidBorder(colorEncabezado, 0f))));
                    //tabla.AddHeaderCell(new Cell().Add(new Paragraph("Total factura").SetFont(boldFont).SetFontSize(10)
                    //.SetBackgroundColor(colorEncabezado).SetBorder(new SolidBorder(colorEncabezado, 0f))));

                    //filas 

                    foreach (var compra in listaFiltrada)
                    {
                        tabla.AddCell(Celda(compra.FechaCompra.ToString("dd/MM/yyyy")));
                        tabla.AddCell(Celda(compra.NumeroFactura));
                        tabla.AddCell(Celda($"{compra.NombreProveedor}  {compra.ApellidoProveedor}"));
                        tabla.AddCell(Celda($"{compra.NombreProducto} - {compra.CodigoProducto}"));
                        tabla.AddCell(Celda(compra.NombreCategoria));
                        tabla.AddCell(Celda(compra.NombreMarca));
                        tabla.AddCell(Celda(compra.PrecioCompra.ToString("C", monedaNic)));
                        tabla.AddCell(Celda(compra.CantidadCompra));
                        tabla.AddCell(Celda(compra.SubtotalCompra.ToString("C", monedaNic)));
                        //tabla.AddCell(Celda(compra.TotalCompra.ToString("C", monedaNic)));
                    }

                    double totalGeneral = listaFiltrada.Sum(c => c.SubtotalCompra);

                    document.Add(tabla);
                    // Agregar el total general debajo de la tabla
                    var totalGeneralParrafo = new Paragraph($"Total general: {totalGeneral.ToString("C", monedaNic)}")
                        .SetFont(boldFont)
                        .SetFontSize(12)
                        .SetTextAlignment(TextAlignment.RIGHT)
                        .SetMarginTop(10);


                    // Mostrar logo como marca de agua
                    try
                    {
                        byte[] watermarkImgBytes;
                        using (MemoryStream ms = new MemoryStream())
                        {
                            formstienda.Properties.Resources.LOGOVERSIONCORREGIDAJUDC.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
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
                                pdfDoc.GetDefaultPageSize().GetWidth() / 2 - (watermarkWidth / 2),
                                pdfDoc.GetDefaultPageSize().GetHeight() / 2 - (watermarkHeight / 2),
                                watermarkWidth);

                        for (int i = 1; i <= pdfDoc.GetNumberOfPages(); i++)
                        {
                            PdfPage page = pdfDoc.GetPage(i);
                            PdfCanvas canvas = new PdfCanvas(page.NewContentStreamBefore(), page.GetResources(), pdfDoc);
                            new Canvas(canvas, page.GetPageSize())
                                .Add(watermark)
                                .Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al crear marca de agua: " + ex.Message);
                    }

                    document.Add(totalGeneralParrafo);

                    document.Close();

                    return rutapdf;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el reporte: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }

        }

        private void FormReportesCompras_Load(object sender, EventArgs e)
        {
            try
            {
                if (!File.Exists(rutaPdf)) 
                {
                    GenerarReporte(_fechaInicio, _fechaFin, rutaPdf, _rucProveedor);
                }

                if (File.Exists(rutaPdf))
                {
                    webView21.Source = new Uri(rutaPdf);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el reporte: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        
        private void btnvolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void webView21_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            label1.ForeColor = System.Drawing.Color.Black;

        }
        

        private void button3_Click(object sender, EventArgs e)
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

        // METODO PARA LIMPIAR EL ARCHIVO TEMPORAL AL CERRAR EL FORMULARIO
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            try
            {
                if (File.Exists(rutaPdf))
                    File.Delete(rutaPdf);
            }
            catch(Exception ex) 
            { 
                MessageBox.Show($"Error al eliminar el archivo temporal: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

}
