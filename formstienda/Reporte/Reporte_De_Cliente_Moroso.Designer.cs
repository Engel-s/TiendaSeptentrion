namespace formstienda.Reporte
{
    partial class Reporte_De_Cliente_Moroso
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tableLayoutPanel1 = new TableLayoutPanel();
            webView21 = new Microsoft.Web.WebView2.WinForms.WebView2();
            btnSalirReporteCredito = new Button();
            label1 = new Label();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)webView21).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(webView21, 0, 1);
            tableLayoutPanel1.Controls.Add(btnSalirReporteCredito, 0, 2);
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 80F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.Size = new Size(800, 450);
            tableLayoutPanel1.TabIndex = 2;
            // 
            // webView21
            // 
            webView21.AllowExternalDrop = true;
            webView21.CreationProperties = null;
            webView21.DefaultBackgroundColor = Color.White;
            webView21.Dock = DockStyle.Fill;
            webView21.Location = new Point(3, 48);
            webView21.Name = "webView21";
            webView21.Size = new Size(794, 354);
            webView21.TabIndex = 0;
            webView21.ZoomFactor = 1D;
            // 
            // btnSalirReporteCredito
            // 
            btnSalirReporteCredito.Location = new Point(3, 408);
            btnSalirReporteCredito.Name = "btnSalirReporteCredito";
            btnSalirReporteCredito.Size = new Size(106, 39);
            btnSalirReporteCredito.TabIndex = 1;
            btnSalirReporteCredito.Text = "Salir ";
            btnSalirReporteCredito.UseVisualStyleBackColor = true;
            btnSalirReporteCredito.Click += btnSalirReporteCredito_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(136, 20);
            label1.TabIndex = 2;
            label1.Text = "Reporte de Crédito";
            // 
            // Reporte_De_Cliente_Moroso
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tableLayoutPanel1);
            Name = "Reporte_De_Cliente_Moroso";
            Text = "Reporte_De_Cliente_Moroso";
            Load += Reporte_De_Cliente_Moroso_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)webView21).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView21;
        private Button btnSalirReporteCredito;
        private Label label1;
    }
}