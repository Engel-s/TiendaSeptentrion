namespace formstienda.capa_de_presentación
{
    partial class ReporteArqueo
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
            btnSalirArqueo = new Button();
            label1 = new Label();
            webViewArqueo = new Microsoft.Web.WebView2.WinForms.WebView2();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)webViewArqueo).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10.5969906F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 89.40301F));
            tableLayoutPanel1.Controls.Add(btnSalirArqueo, 0, 0);
            tableLayoutPanel1.Controls.Add(label1, 1, 0);
            tableLayoutPanel1.Controls.Add(webViewArqueo, 1, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 12.8919888F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 87.10802F));
            tableLayoutPanel1.Size = new Size(800, 450);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // btnSalirArqueo
            // 
            btnSalirArqueo.BackColor = Color.DeepSkyBlue;
            btnSalirArqueo.Dock = DockStyle.Top;
            btnSalirArqueo.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSalirArqueo.Location = new Point(3, 3);
            btnSalirArqueo.Name = "btnSalirArqueo";
            btnSalirArqueo.Size = new Size(78, 52);
            btnSalirArqueo.TabIndex = 0;
            btnSalirArqueo.Text = "Salir";
            btnSalirArqueo.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(87, 0);
            label1.Name = "label1";
            label1.Size = new Size(710, 58);
            label1.TabIndex = 2;
            label1.Text = "Arqueo De Caja";
            // 
            // webViewArqueo
            // 
            webViewArqueo.AllowExternalDrop = true;
            webViewArqueo.CreationProperties = null;
            webViewArqueo.DefaultBackgroundColor = Color.White;
            webViewArqueo.Dock = DockStyle.Fill;
            webViewArqueo.Location = new Point(87, 61);
            webViewArqueo.Name = "webViewArqueo";
            webViewArqueo.Size = new Size(710, 386);
            webViewArqueo.TabIndex = 3;
            webViewArqueo.ZoomFactor = 1D;
            webViewArqueo.Click += webViewArqueo_Click;
            // 
            // ReporteArqueo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tableLayoutPanel1);
            Name = "ReporteArqueo";
            Text = "ReporteArqueo";
            Load += ReporteArqueo_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)webViewArqueo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Button btnSalirArqueo;
        private Label label1;
        private Microsoft.Web.WebView2.WinForms.WebView2 webViewArqueo;
    }
}