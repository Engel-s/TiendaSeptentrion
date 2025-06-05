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
using iText.Kernel.Geom;
using iText.Kernel.Colors;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.IO.Font.Constants;
using iText.IO.Font;
using Microsoft.Web.WebView2.WinForms;
using formstienda.capa_de_negocios;
using iText.Kernel.Font;
using Microsoft.EntityFrameworkCore.Storage.Json;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using formstienda.Datos;
using System.Drawing.Text;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Diagnostics;
using iText.Layout.Borders;
using System.Globalization;

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
                    string rutaImagen = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Resources\logo_actualizado-removebg-preview.png");

                    // Verifica que la imagen exista
                    if (File.Exists(rutaImagen))
                    {
                        // Cargar imagen
                        var imgData = iText.IO.Image.ImageDataFactory.Create(rutaImagen);
                        var imagen = new iText.Layout.Element.Image(imgData)
                                        .SetWidth(300)
                                        .SetHeight(200)
                                        .SetFixedPosition(pdfDoc.GetDefaultPageSize().GetWidth() - 250, // X desde la derecha
                                      pdfDoc.GetDefaultPageSize().GetHeight() - 200); // Y desde arriba

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
                    float[] anchos = { 1f, 0.8f, 1f, 1.8f, 0.8f, 0.8f, 1.5f , 0.8f, 1f, 1.2f };
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
                    tabla.AddHeaderCell(new Cell().Add(new Paragraph("Subtotal").SetFont(boldFont).SetFontSize(10)
                        .SetBackgroundColor(colorEncabezado).SetBorder(new SolidBorder(colorEncabezado, 0f))));
                    tabla.AddHeaderCell(new Cell().Add(new Paragraph("Total factura").SetFont(boldFont).SetFontSize(10)
                        .SetBackgroundColor(colorEncabezado).SetBorder(new SolidBorder(colorEncabezado, 0f))));

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
                        tabla.AddCell(Celda(compra.TotalCompra.ToString("C", monedaNic)));
                    }


                    document.Add(tabla);
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
                if (!File.Exists(rutaPdf)) // Para no generar si ya existe
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
    }
}
