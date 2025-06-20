using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using formstienda.capa_de_negocios;
using iText.Layout.Element;
using iText.Kernel.Font;
using iText.Layout.Properties;
using iText.Kernel.Pdf;
using iText.Kernel.Geom;
using iText.Kernel.Colors;
using iText.Layout;
using iText.Layout.Borders;
using iText.IO.Font.Constants;
using iText.Kernel.Font;
using System.Globalization;
using formstienda.Datos;

namespace formstienda.capa_de_presentación
{
    public partial class FormClientesMorosos : Form
    {
        private readonly ReporteClientesMorosos _reporteClientesMorosos;
        private readonly string rutaPdf;
        public FormClientesMorosos(string rutapdf)
        {
            InitializeComponent();
            _reporteClientesMorosos = new ReporteClientesMorosos();
            rutaPdf = rutapdf;
        }
        private Cell Celda(object valor)
        {
            return new Cell()
                    .Add(new Paragraph(valor?.ToString() ?? "").SetFontSize(9))
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetVerticalAlignment(VerticalAlignment.MIDDLE);
        }

        public string GenerarReporteClientesMorosos(string rutaPdf)
        {
            try
            {
                var clientesMorosos = _reporteClientesMorosos.ListarClientesMorosos();

                var Lista = clientesMorosos;

                using (var stream = new FileStream(rutaPdf, FileMode.Create, FileAccess.Write))
                {
                    //Crear variables
                    var monedaNic = CultureInfo.GetCultureInfo("es-NI");
                    var writer = new PdfWriter(stream);
                    var pdfDoc = new PdfDocument(writer);
                    var document = new Document(pdfDoc, PageSize.A4.Rotate());

                    var boldFont = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
                    var normalFont = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);

                    var parrafo = new Paragraph("Reporte de clientes morosos")
                        .SetFont(boldFont)
                        .SetMarginBottom(15);

                    string rutaImagen = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Resources\logo_actualizado-removebg-preview.png");

                    if (File.Exists(rutaImagen))
                    {
                        // Cargar imagen
                        var imgData = iText.IO.Image.ImageDataFactory.Create(rutaImagen);
                        var imagen = new iText.Layout.Element.Image(imgData)
                                        .SetWidth(350)
                                        .SetHeight(200)
                                        .SetFixedPosition(pdfDoc.GetDefaultPageSize().GetWidth() - 280, // X desde la derecha
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

                    document.Add(parrafo);
                    document.Add(new Paragraph($"Fecha: {DateTime.Now}"));
                    document.Add(new Paragraph($"Registros:{clientesMorosos.Count}"));

                    document.Add(new Paragraph("\n"));

                    float[] anchos = { 1f, 1f, 1f, 1f, 1f, 1f };
                    var tabla = new Table(UnitValue.CreatePercentArray(anchos))
                        .UseAllAvailableWidth();

                    var colorEncabezado = new DeviceRgb(3, 171, 229);

                    tabla.AddHeaderCell(new Cell().Add(new Paragraph("Cliente").SetFont(boldFont).SetFontSize(10)
                       .SetBackgroundColor(colorEncabezado).SetBorder(new SolidBorder(colorEncabezado, 0f))));
                    tabla.AddHeaderCell(new Cell().Add(new Paragraph("Telefono").SetFont(boldFont).SetFontSize(10)
                        .SetBackgroundColor(colorEncabezado).SetBorder(new SolidBorder(colorEncabezado, 0f))));
                    tabla.AddHeaderCell(new Cell().Add(new Paragraph("Direccion").SetFont(boldFont).SetFontSize(10)
                        .SetBackgroundColor(colorEncabezado).SetBorder(new SolidBorder(colorEncabezado, 0f))));
                    tabla.AddHeaderCell(new Cell().Add(new Paragraph("Fecha de pago").SetFont(boldFont).SetFontSize(10)
                        .SetBackgroundColor(colorEncabezado).SetBorder(new SolidBorder(colorEncabezado, 0f))));
                    tabla.AddHeaderCell(new Cell().Add(new Paragraph("Dias de mora").SetFont(boldFont).SetFontSize(10)
                        .SetBackgroundColor(colorEncabezado).SetBorder(new SolidBorder(colorEncabezado, 0f))));
                    tabla.AddHeaderCell(new Cell().Add(new Paragraph("Saldo pendiente").SetFont(boldFont).SetFontSize(10)
                        .SetBackgroundColor(colorEncabezado).SetBorder(new SolidBorder(colorEncabezado, 0f))));

                    Double totalGeneral = 0;
                    foreach (var clientemora in Lista)
                    {
                        var cliente = clientemora.IdCreditoNavigation.IdVentaNavigation.CedulaClienteNavigation;
                        tabla.AddCell(Celda($"{cliente.NombreCliente} {cliente.ApellidoCliente}"));
                        tabla.AddCell(Celda(clientemora.IdCreditoNavigation.IdVentaNavigation.CedulaClienteNavigation.TelefonoCliente));
                        tabla.AddCell(Celda(clientemora.IdCreditoNavigation.IdVentaNavigation.CedulaClienteNavigation.DireccionCliente));
                        tabla.AddCell(Celda(clientemora.FechaPago));

                        var diasMora = (DateTime.Now.Date - clientemora.FechaPago.Date).Days;
                        tabla.AddCell(Celda(diasMora));


                        int mesesMora = diasMora / 30;
                        double montoOriginal = clientemora.IdCreditoNavigation.MontoCredito;
                        double montoConInteres = montoOriginal * Math.Pow(1.03, mesesMora);
                        tabla.AddCell(Celda(montoConInteres.ToString("C", monedaNic)));

                        totalGeneral += montoConInteres;
                    }

                    document.Add(tabla);

                    var totalGeneralParrafo = new Paragraph($"Total general: {totalGeneral.ToString("C", monedaNic)}")
                        .SetFont(boldFont)
                        .SetFontSize(12)
                        .SetTextAlignment(TextAlignment.RIGHT)
                        .SetMarginTop(10);

                    document.Add(totalGeneralParrafo);

                    document.Close();

                    return rutaPdf;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el reporte: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }
        }

        private void FormClientesMorosos_Load(object sender, EventArgs e)
        {
            try
            {
                if (!File.Exists(rutaPdf)) // Para no generar si ya existe
                {
                    GenerarReporteClientesMorosos(rutaPdf);
                }

                if (File.Exists(rutaPdf))
                {
                    webWiebClientesMorosos.Source = new Uri(rutaPdf);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el reporte: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            try
            {
                if (File.Exists(rutaPdf))
                    File.Delete(rutaPdf);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar el archivo temporal: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
