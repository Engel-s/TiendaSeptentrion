using formstienda.Capa_negocios;
using formstienda.Datos;
using iText;
using iText.IO.Font.Constants;
using iText.IO.Image; // Para agregar imágenes (marca de agua)
using iText.Kernel.Colors;
using iText.Kernel.Font; // Para estilos de texto
using iText.Kernel.Geom;
using iText.Kernel.Pdf; // Para generar PDF
using iText.Kernel.Pdf.Canvas;
using iText.Layout; // Para formatear contenido en PDF
using iText.Layout.Borders;
using iText.Layout.Element;
// PDF - iText7
using System.Drawing;
using Image = iText.Layout.Element.Image; // Alias para iText.Layout.Element.Image
using iText.Layout.Properties;
using Microsoft.EntityFrameworkCore;
// Excel - EPPlus
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas;
using iText.Kernel.Pdf.Function;
using PathIO = System.IO.Path; // Renombra System.IO.Path a PathIO
using iText.Layout;
using iText.Layout.Element;

// WebView2
using Microsoft.Web.WebView2.WinForms;
using OfficeOpenXml; // Para generar Excel
using OfficeOpenXml.Style;
using System;
// Sistemas
using System;
using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms;
using System.Windows.Forms;
using Path = System.IO.Path;

namespace formstienda.Reporte
{
    public partial class Reporte_de_Cliente_Moroso : Form
    {

        private string _outputPath = System.IO.Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
        "ReportesCreditos");


        private readonly CreditoServicio _creditoServicio;

        private const decimal TasaCambioDolar = 36.5m;

        private PdfDocument pdf;
        public Reporte_de_Cliente_Moroso()
        {
            InitializeComponent();
            _creditoServicio = new CreditoServicio();
            ExcelPackage.License.SetNonCommercialPersonal("zetadev");
        }
        private List<ClienteMorosoData> ObtenerClientesMorosos()
        {
            using (var context = new DbTiendaSeptentrionContext())
            {
                var hoy = DateTime.Now.Date;

                return context.DetalleCreditos
                    .Include(dc => dc.IdCreditoNavigation)
                    .ThenInclude(cc => cc.IdVentaNavigation)
                    .ThenInclude(v => v.CedulaClienteNavigation)
                    .Where(dc => dc.FechaPago < hoy && dc.ValorCuota > 0) // Solo clientes con pagos vencidos y saldo pendiente
                    .Select(dc => new ClienteMorosoData
                    {
                        Nombre = dc.IdCreditoNavigation.IdVentaNavigation.CedulaClienteNavigation.NombreCliente,
                        Telefono = dc.IdCreditoNavigation.IdVentaNavigation.CedulaClienteNavigation.TelefonoCliente,
                        Direccion = dc.IdCreditoNavigation.IdVentaNavigation.CedulaClienteNavigation.DireccionCliente,
                        FechaPago = dc.FechaPago,
                        DiasEnMora = (hoy - dc.FechaPago).Days,
                        SaldoPendiente = (decimal)(float)dc.ValorCuota
                    })
                    .ToList();
            }
        }

        public void GenerarExcel(List<ClienteMorosoData> clientesMorosos, string excelPath)
        {
            using (var package = new ExcelPackage(new FileInfo(excelPath)))
            {
                var worksheet = package.Workbook.Worksheets.Add("Reporte de Clientes Morosos");

                // Encabezados
                worksheet.Cells[1, 1].Value = "Cliente";
                worksheet.Cells[1, 2].Value = "Teléfono";
                worksheet.Cells[1, 3].Value = "Dirección";
                worksheet.Cells[1, 4].Value = "Fecha de Pago";
                worksheet.Cells[1, 5].Value = "Días en Mora";
                worksheet.Cells[1, 6].Value = "Saldo Pendiente";

                // Datos
                for (int i = 0; i < clientesMorosos.Count; i++)
                {
                    var cliente = clientesMorosos[i];
                    worksheet.Cells[i + 2, 1].Value = cliente.Nombre;
                    worksheet.Cells[i + 2, 2].Value = cliente.Telefono;
                    worksheet.Cells[i + 2, 3].Value = cliente.Direccion;
                    worksheet.Cells[i + 2, 4].Value = cliente.FechaPago.ToShortDateString();
                    worksheet.Cells[i + 2, 5].Value = cliente.DiasEnMora;
                    worksheet.Cells[i + 2, 6].Value = cliente.SaldoPendiente.ToString("N2");
                }

                // Formato de columnas
                worksheet.Column(1).AutoFit();
                worksheet.Column(2).AutoFit();
                worksheet.Column(3).AutoFit();
                worksheet.Column(4).Style.Numberformat.Format = "dd/MM/yyyy";
                worksheet.Column(5).Style.Numberformat.Format = "0";
                worksheet.Column(6).Style.Numberformat.Format = "#,##0.00";

                // Guardar archivo
                package.Save();
            }
        }

        public void ConvertirExcelAPdf(string excelPath, string pdfPath)
        {
            using var package = new ExcelPackage(new FileInfo(excelPath));
            var worksheet = package.Workbook.Worksheets[0];

            // Crear PDF
            using var writer = new PdfWriter(pdfPath);
            using var pdf = new PdfDocument(writer);
            using var document = new Document(pdf, PageSize.A4.Rotate());

            // Agregar encabezado
            AddHeader(document);

            // Crear tabla en PDF
            Table table = new Table(worksheet.Dimension.End.Column);

            // Agregar encabezados
            for (int col = 1; col <= worksheet.Dimension.End.Column; col++)
            {
                var cellValue = worksheet.Cells[1, col].Text;
                table.AddHeaderCell(cellValue);
            }

            // Agregar filas
            for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
            {
                for (int col = 1; col <= worksheet.Dimension.End.Column; col++)
                {
                    var cellValue = worksheet.Cells[row, col].Text;
                    table.AddCell(cellValue);
                }
            }

            // Añadir tabla al documento
            document.Add(table);
            AgregarMarcaDeAgua(pdf);

            document.Close();

        }


        private string GetHtmlFromExcel(string excelPath)
        {
            using (var package = new ExcelPackage(new FileInfo(excelPath)))
            {
                var worksheet = package.Workbook.Worksheets[0];
                StringBuilder sb = new StringBuilder();

                // Iniciar tabla HTML
                sb.Append("<table border='1'>");

                // Agregar encabezados
                for (int col = 1; col <= worksheet.Dimension.End.Column; col++)
                {
                    sb.AppendFormat("<th>{0}</th>", worksheet.Cells[1, col].Text);
                }

                // Agregar filas de datos
                for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
                {
                    sb.Append("<tr>");
                    for (int col = 1; col <= worksheet.Dimension.End.Column; col++)
                    {
                        sb.AppendFormat("<td>{0}</td>", worksheet.Cells[row, col].Text);
                    }
                    sb.Append("</tr>");
                }

                // Cerrar tabla HTML
                sb.Append("</table>");

                return sb.ToString();
            }
        }
        public  void AddHeader(Document document)
        {

            try
            {
                byte[] imgBytes;
                using (MemoryStream ms = new MemoryStream())
                {
                    formstienda.Properties.Resources.logo_actualizado_removebg_preview.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    imgBytes = ms.ToArray();
                }

                // Agregar logo
                var logo = new Image(iText.IO.Image.ImageDataFactory.Create(imgBytes))
                    .SetWidth(100)
                    .SetFixedPosition(pdf.GetDefaultPageSize().GetWidth() - 120, pdf.GetDefaultPageSize().GetTop() - 80);

                document.Add(logo);


                // Encabezado
                Paragraph header = new Paragraph()
                    .SetTextAlignment(TextAlignment.CENTER)
                    .Add(new Text("Empresa XYZ")
                        .SetFont(PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD))
                        .SetFontSize(14))
                    .Add(new Text("Dirección: Calle Principal #123")
                        .SetFont(PdfFontFactory.CreateFont(StandardFonts.HELVETICA))
                        .SetFontSize(10))
                    .Add(new Text("Teléfono: 123-456-7890")
                        .SetFont(PdfFontFactory.CreateFont(StandardFonts.HELVETICA))
                        .SetFontSize(10))
                    .Add(new Text("REPORTE DE CLIENTES MOROSOS")
                        .SetFont(PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD))
                        .SetFontSize(12))
                    .Add(new Text($"Fecha de generación: {DateTime.Now.ToShortDateString()}")
                        .SetFont(PdfFontFactory.CreateFont(StandardFonts.HELVETICA))
                        .SetFontSize(10));
                document.Add(header);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el logo: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void AgregarMarcaDeAgua(PdfDocument pdf)
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

                    // Crear marca de agua
                    var imageData = iText.IO.Image.ImageDataFactory.Create(watermarkImgBytes); // Datos de la imagen
                    var watermark = new Image(imageData) // Elemento de layout para la imagen
                        .SetOpacity(0.1f)
                        .SetWidth(watermarkWidth)
                        .SetHeight(watermarkHeight);

                    // Agregar marca de agua al canvas
                    canvas.AddImageAt(imageData,
                                     page.GetPageSize().GetWidth() / 2 - (watermarkWidth / 2),
                                     page.GetPageSize().GetHeight() / 2 - (watermarkHeight / 2),
                                     false); // asinline = false

                    // No necesitas SetPageContent aquí, ya que NewContentStreamBefore maneja el contenido automáticamente
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error al crear la marca de agua: " + ex.Message);
            }
        }

        public void btnGenerarReporte_Click(object sender, EventArgs e)
        {

            try
            {
                var clientesMorosos = ObtenerClientesMorosos();

                if (!Directory.Exists(_outputPath))
                    Directory.CreateDirectory(_outputPath);

                string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                string excelPath = Path.Combine(_outputPath, $"ReporteClientesMorosos_{timestamp}.xlsx");
                string pdfPath = Path.Combine(_outputPath, $"ReporteClientesMorosos_{timestamp}.pdf");

                GenerarExcel(clientesMorosos, excelPath);
                ConvertirExcelAPdf(excelPath, pdfPath);
                BloquearEdicionExcel(excelPath);

                MessageBox.Show($"El reporte ha sido generado exitosamente.\nArchivos guardados en:\n{_outputPath}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                webView21.Source = new Uri(pdfPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Se produjo un error al generar el reporte: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BloquearEdicionExcel(string filePath)
        {
            using var package = new ExcelPackage(new FileInfo(filePath));
            var worksheet = package.Workbook.Worksheets[0];

            worksheet.Protection.IsProtected = true;
            worksheet.Protection.AllowSelectLockedCells = false;
            worksheet.Protection.AllowEditObject = false;
            worksheet.Protection.AllowSort = false;
            worksheet.Protection.AllowInsertRows = false;

            package.Save();
        }


        }
        public class ClienteMorosoData
        {
            public string Nombre { get; set; }
            public string Telefono { get; set; }
            public string Direccion { get; set; }
            public DateTime FechaPago { get; set; }
            public int DiasEnMora { get; set; }
            public decimal SaldoPendiente { get; set; }
        }
}
