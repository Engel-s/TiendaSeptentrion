namespace formstienda.capa_de_presentación
{
    partial class ReporteDeInventario
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
            label1 = new Label();
            webViewInventario = new Microsoft.Web.WebView2.WinForms.WebView2();
            panel1 = new Panel();
            btnSalir = new Button();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)webViewInventario).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(webViewInventario, 0, 1);
            tableLayoutPanel1.Controls.Add(panel1, 0, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 85F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 5F));
            tableLayoutPanel1.Size = new Size(897, 455);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(891, 45);
            label1.TabIndex = 2;
            label1.Text = "Inventario Actual";
            // 
            // webViewInventario
            // 
            webViewInventario.AllowExternalDrop = true;
            webViewInventario.CreationProperties = null;
            webViewInventario.DefaultBackgroundColor = Color.White;
            webViewInventario.Dock = DockStyle.Fill;
            webViewInventario.Location = new Point(3, 48);
            webViewInventario.Name = "webViewInventario";
            webViewInventario.Size = new Size(891, 380);
            webViewInventario.TabIndex = 3;
            webViewInventario.ZoomFactor = 1D;
            webViewInventario.Click += webViewInventario_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnSalir);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 434);
            panel1.Name = "panel1";
            panel1.Size = new Size(891, 18);
            panel1.TabIndex = 4;
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.DeepSkyBlue;
            btnSalir.Dock = DockStyle.Right;
            btnSalir.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSalir.ForeColor = Color.Black;
            btnSalir.Location = new Point(802, 0);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(89, 18);
            btnSalir.TabIndex = 1;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // ReporteDeInventario
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(897, 455);
            Controls.Add(tableLayoutPanel1);
            Name = "ReporteDeInventario";
            Text = "ReporteDeInventario";
            Load += ReporteDeInventario_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)webViewInventario).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private Microsoft.Web.WebView2.WinForms.WebView2 webViewInventario;
        private Panel panel1;
        private Button btnSalir;
    }
}