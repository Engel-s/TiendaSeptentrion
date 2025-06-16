namespace formstienda.capa_de_presentación
{
    partial class ReporteCredito
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
            webViewCredito = new Microsoft.Web.WebView2.WinForms.WebView2();
            panel1 = new Panel();
            label1 = new Label();
            btnSalirArqueo = new Button();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)webViewCredito).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(webViewCredito, 0, 1);
            tableLayoutPanel1.Controls.Add(panel1, 0, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 85F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 5F));
            tableLayoutPanel1.Size = new Size(800, 450);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // webViewCredito
            // 
            webViewCredito.AllowExternalDrop = true;
            webViewCredito.CreationProperties = null;
            webViewCredito.DefaultBackgroundColor = Color.White;
            webViewCredito.Dock = DockStyle.Fill;
            webViewCredito.Location = new Point(3, 48);
            webViewCredito.Name = "webViewCredito";
            webViewCredito.Size = new Size(794, 376);
            webViewCredito.TabIndex = 0;
            webViewCredito.ZoomFactor = 1D;
            webViewCredito.Click += webViewCredito_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnSalirArqueo);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 430);
            panel1.Name = "panel1";
            panel1.Size = new Size(794, 17);
            panel1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(794, 45);
            label1.TabIndex = 3;
            label1.Text = "Crédito";
            // 
            // btnSalirArqueo
            // 
            btnSalirArqueo.BackColor = Color.FromArgb(3, 171, 229);
            btnSalirArqueo.Dock = DockStyle.Right;
            btnSalirArqueo.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSalirArqueo.ForeColor = Color.Black;
            btnSalirArqueo.Location = new Point(700, 0);
            btnSalirArqueo.Name = "btnSalirArqueo";
            btnSalirArqueo.Size = new Size(94, 17);
            btnSalirArqueo.TabIndex = 6;
            btnSalirArqueo.Text = "Salir";
            btnSalirArqueo.UseVisualStyleBackColor = false;
            btnSalirArqueo.Click += btnSalirArqueo_Click;
            // 
            // ReporteCredito
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tableLayoutPanel1);
            Name = "ReporteCredito";
            Text = "ReporteCredito";
            Load += ReporteCredito_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)webViewCredito).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Microsoft.Web.WebView2.WinForms.WebView2 webViewCredito;
        private Panel panel1;
        private Label label1;
        private Button btnSalirArqueo;
    }
}