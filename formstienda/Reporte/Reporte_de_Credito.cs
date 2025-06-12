using formstienda.Datos;
using iText.Commons.Actions.Contexts;
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
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Document = iTextSharp.text.Document;
using Image = iText.Layout.Element.Image;
using Path = System.IO.Path;
using PdfPage = iText.Kernel.Pdf.PdfPage;


namespace formstienda.Reporte
{
    public partial class Reporte_de_Credito : Form
    {

        private DateTimePicker dateTimePicker1; // Fecha inicial (hace un mes)
        private DateTimePicker dateTimePicker2; // Fecha final (actual)
        private readonly DateTime _fechaInicio;
        private readonly DateTime _fechaFin;
        private readonly string _rutaPdf;
        private string _outputPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "ReportesCreditos");
        private object pdf;
        private byte[] imgBytes;
        private DbTiendaSeptentrionContext _context;
        public Reporte_de_Credito()
        {
            InitializeComponent();

            ExcelPackage.License.SetNonCommercialPersonal("zetadev");

            _context = new DbTiendaSeptentrionContext();

            // Crear el primer DateTimePicker (Fecha inicial: hace un mes)
            dateTimePicker1 = new DateTimePicker
            {
                Name = "dateTimePicker1",
                Format = DateTimePickerFormat.Short,
                Location = new System.Drawing.Point(50, 50), // Posición en el formulario
                Size = new Size(150, 20),
                Value = DateTime.Now.AddMonths(-1) // Fecha de hace un mes
            };

            // Crear el segundo DateTimePicker (Fecha final: actual)
            dateTimePicker2 = new DateTimePicker
            {
                Name = "dateTimePicker2",
                Format = DateTimePickerFormat.Short,
                Location = new System.Drawing.Point(250, 50), // Posición en el formulario
                Size = new Size(150, 20),
                Value = DateTime.Now // Fecha actual
            };

            // Agregar los DateTimePicker al formulario
            this.Controls.Add(dateTimePicker1);
            this.Controls.Add(dateTimePicker2);

            // Enviar los controles al fondo del diseño visual
            dateTimePicker1.SendToBack();
            dateTimePicker2.SendToBack();

        }

        public void ReporteOtrasSalidas_Load(object sender, EventArgs e)
        {
            try
            {
                string filePath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "ReportesOtrasSalidas.pdf");
                GenerarPDF(filePath);
                MostrarPDF(filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el reporte: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void MostrarPDF(string filePath)
        {
            throw new NotImplementedException();
        }

        public void GenerarPDF(string filePath)
        {
            // Generar el PDF al cargar el formulario
            GenerarPDF(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "ReporteInventario.pdf"));
            // Mostrar el PDF en el WebView
            MostrarPDF(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "ReporteInventario.pdf"));
        }

        private void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            DateTime fechaInicio = dateTimePicker1.Value.Date;
            DateTime fechaFin = dateTimePicker2.Value.Date;
            if (fechaInicio > fechaFin)
            {
                MessageBox.Show("La fecha inicial no puede ser mayor que la fecha final.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                var creditos = ObtenerDetallesDeCredito(fechaInicio, fechaFin);
                if (creditos == null || !creditos.Any())
                {
                    MessageBox.Show("No se encontraron cuotas de crédito en el rango de fechas seleccionado.", "Sin Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                string excelPath = System.IO.Path.Combine(_outputPath, $"ReporteCreditos_{timestamp}.xlsx");
                string pdfPath = System.IO.Path.Combine(_outputPath, $"ReporteCreditos_{timestamp}.pdf");
                GenerarExcel(creditos, excelPath);
                ConvertirExcelAPdf(excelPath, pdfPath);
                BloquearEdicionExcel(excelPath);
                BloquearEdicionPDF(pdfPath);
                MessageBox.Show($"El reporte ha sido generado exitosamente.\nArchivos guardados en:\n{_outputPath}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Se produjo un error al generar el reporte: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<DetalleCreditoData> ObtenerDetallesDeCredito(DateTime inicio, DateTime fin)
        {
            using (var context = new DbTiendaSeptentrionContext()) // Asegúrate que este contexto exista
            {
                return context.DetalleCreditos
                    .Where(dc => dc.FechaPago >= inicio && dc.FechaPago <= fin)
                    .Select(dc => new DetalleCreditoData
                    {
                        Id_DetalleCredito = dc.IdDetalleCredito,
                        Numero_Cuota = dc.NumeroCuota,
                        Fecha_Pago = dc.FechaPago,
                        Valor_Cuota = dc.ValorCuota,
                        Abono_Capital = dc.AbonoCapital,
                        Interes_Pagado = dc.InteresPagado,
                        Total_Cordobas = dc.TotalCordobas,
                        Total_Dolares = dc.TotalDolares,
                        Observaciones = dc.Observaciones
                    })
                    .ToList();
            }
        }

        private void GenerarExcel(List<DetalleCreditoData> datos, string rutaArchivo)
        {
            using (var package = new ExcelPackage(new FileInfo(rutaArchivo)))
            {
                var worksheet = package.Workbook.Worksheets.Add("Cuotas de Crédito");
                string[] encabezados = {
                    "#", "Número de Cuota", "Fecha de Pago", "Valor de la Cuota",
                    "Abono al Capital", "Interés Pagado", "Total en Córdobas",
                    "Total en Dólares", "Observaciones"
                };
                for (int c = 0; c < encabezados.Length; c++)
                {
                    worksheet.Cells[1, c + 1].Value = encabezados[c];
                }
                worksheet.Row(1).Style.Font.Bold = true;
                worksheet.Cells["A1:I1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheet.Cells["A1:I1"].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightBlue);
                int fila = 2;
                int contador = 1;
                foreach (var detalle in datos)
                {
                    worksheet.Cells[fila, 1].Value = contador++;
                    worksheet.Cells[fila, 2].Value = detalle.Numero_Cuota;
                    worksheet.Cells[fila, 3].Value = detalle.Fecha_Pago.ToString("dd/MM/yyyy");
                    worksheet.Cells[fila, 4].Value = detalle.Valor_Cuota;
                    worksheet.Cells[fila, 5].Value = detalle.Abono_Capital;
                    worksheet.Cells[fila, 6].Value = detalle.Interes_Pagado;
                    worksheet.Cells[fila, 7].Value = detalle.Total_Cordobas;
                    worksheet.Cells[fila, 8].Value = detalle.Total_Dolares;
                    worksheet.Cells[fila, 9].Value = detalle.Observaciones;
                    fila++;
                }
                for (int col = 1; col <= encabezados.Length; col++)
                {
                    worksheet.Column(col).AutoFit();
                }
                package.Save();
            }
        }

        private void ConvertirExcelAPdf(string excelPath, string pdfPath)
        {
            Document document = new Document(iTextSharp.text.PageSize.A4.Rotate());
            iTextSharp.text.pdf.PdfWriter writer = iTextSharp.text.pdf.PdfWriter.GetInstance(document, new FileStream(pdfPath, FileMode.Create));
            document.Open();
            AddHeader(document);
            var html = GetHtmlFromExcel(excelPath);
            var parsedList = HTMLWorker.ParseToList(new StringReader(html), null);
            foreach (var element in parsedList)
            {
                document.Add((iTextSharp.text.IElement)element);
            }
            document.Close();
        }

        private void AddHeader(Document document)
        {
            try
            {
                System.Drawing.Image img = formstienda.Properties.Resources.logo_actualizado_removebg_preview;
                byte[] imgBytes;
                using (MemoryStream ms = new MemoryStream())
                {
                    img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    imgBytes = ms.ToArray();
                }
                iText.Kernel.Pdf.PdfDocument pdf = new iText.Kernel.Pdf.PdfDocument(new iText.Kernel.Pdf.PdfWriter("output.pdf"));
                byte[] logoBytes = File.ReadAllBytes(@"C:\ruta\all\logo.png");
                iText.Layout.Element.Image logo = new iText.Layout.Element.Image(iText.IO.Image.ImageDataFactory.Create(imgBytes))
                                   .SetWidth(215)
                                   .SetFixedPosition(pdf.GetDefaultPageSize().GetWidth() - 200, pdf.GetDefaultPageSize().GetTop() - 150)
                                   .SetMarginTop(0);
                document.Add((iTextSharp.text.IElement)logo);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el logo: " + ex.Message,
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            iTextSharp.text.Paragraph header = new iTextSharp.text.Paragraph();
            header.Alignment = Element.ALIGN_CENTER;
            header.Add(new Phrase("Tienda el Setentrion\n", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14)));
            header.Add(new Phrase("Dirección: Calle Principal #123\n", FontFactory.GetFont(FontFactory.HELVETICA, 10)));
            header.Add(new Phrase("Teléfono: 123-456-7890\n", FontFactory.GetFont(FontFactory.HELVETICA, 10)));
            header.Add(new Phrase("REPORTE DE CUOTAS DE CRÉDITO\n", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12)));
            header.Add(new Phrase($"Período: {dateTimePicker1.Value.ToShortDateString()} - {dateTimePicker2.Value.ToShortDateString()}\n", FontFactory.GetFont(FontFactory.HELVETICA, 10)));
            header.Add(new Phrase($"Fecha de Generación: {DateTime.Now.ToShortDateString()}\n", FontFactory.GetFont(FontFactory.HELVETICA, 10)));
            document.Add(header);
        }

        private void AgregarMarcaDeAgua(iText.Kernel.Pdf.PdfDocument pdf)
        {
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
                for (int pageNumber = 1; pageNumber <= pdf.GetNumberOfPages(); pageNumber++)
                {
                    PdfPage page = pdf.GetPage(pageNumber);
                    PdfCanvas canvas = new PdfCanvas(page.NewContentStreamBefore(), page.GetResources(), pdf);
                    Image watermark = new Image(ImageDataFactory.Create(watermarkImgBytes))
                        .SetOpacity(0.1f)
                        .SetWidth(watermarkWidth)
                        .SetHeight(watermarkHeight)
                        .SetFixedPosition(
                            page.GetPageSize().GetWidth() / 2 - (watermarkWidth / 2),
                            page.GetPageSize().GetHeight() / 2 - (watermarkHeight / 2),
                            watermarkWidth
                        );
                    Document document = new Document();
                    iTextSharp.text.pdf.PdfWriter writer = iTextSharp.text.pdf.PdfWriter.GetInstance(document, new FileStream("output.pdf", FileMode.Create));
                    document.Open();
                    document.Add((iTextSharp.text.IElement)watermark);
                    document.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear la marca de agua: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                catch (Exception error)
                {
                    Console.WriteLine(error);
                }
            }
        }

        private string GetHtmlFromExcel(string filePath)
        {
            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var worksheet = package.Workbook.Worksheets[0];
                StringBuilder sb = new StringBuilder();
                sb.Append("<table border='1'>");
                for (int row = 1; row <= worksheet.Dimension.End.Row; row++)
                {
                    sb.Append("<tr>");
                    for (int col = 1; col <= worksheet.Dimension.End.Column; col++)
                    {
                        var cellValue = worksheet.Cells[row, col].Text;
                        sb.AppendFormat("<td>{0}</td>", cellValue);
                    }
                    sb.Append("</tr>");
                }
                sb.Append("</table>");
                return sb.ToString();
            }
        }

        private void BloquearEdicionExcel(string filePath)
        {
            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var worksheet = package.Workbook.Worksheets[0];
                worksheet.Protection.IsProtected = true;
                worksheet.Protection.AllowSelectLockedCells = false;
                worksheet.Protection.AllowEditObject = false;
                worksheet.Protection.AllowSort = false;
                worksheet.Protection.AllowInsertRows = false;
                package.Save();
            }
        }

        private void BloquearEdicionPDF(string filePath)
        {
            using (var reader = new iTextSharp.text.pdf.PdfReader(filePath))
            {
                using (var fs = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    using (var stamper = new PdfStamper(reader, fs))
                    {
                        stamper.MoreInfo = new Dictionary<string, string>
                        {
                            { "ModDate", DateTime.Now.ToString() },
                            { "CreationDate", DateTime.Now.ToString() },
                            { "Producer", "Sistema de Reportes" }
                        };
                        stamper.SetFullCompression();
                    }
                }
            }
        }

        // Clase interna para mapear los datos del reporte
        private class DetalleCreditoData
        {
            public int Id_DetalleCredito { get; set; }
            public int Numero_Cuota { get; set; }
            public DateTime Fecha_Pago { get; set; }
            public float Valor_Cuota { get; set; }
            public float Abono_Capital { get; set; }
            public float Interes_Pagado { get; set; }
            public float Total_Cordobas { get; set; }
            public float Total_Dolares { get; set; }
            public string Observaciones { get; set; }
        }

        private void webView21_Click(object sender, EventArgs e)
        {

        }

    }
}
