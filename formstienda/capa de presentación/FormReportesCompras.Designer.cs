namespace formstienda.capa_de_presentación
{
    partial class FormReportesCompras
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
            btnvolver = new Button();
            label8 = new Label();
            webView21 = new Microsoft.Web.WebView2.WinForms.WebView2();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)webView21).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 95F));
            tableLayoutPanel1.Controls.Add(btnvolver, 0, 0);
            tableLayoutPanel1.Controls.Add(label8, 1, 0);
            tableLayoutPanel1.Controls.Add(webView21, 1, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 83.3333359F));
            tableLayoutPanel1.Size = new Size(800, 450);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // btnvolver
            // 
            btnvolver.BackColor = Color.FromArgb(3, 171, 229);
            btnvolver.Dock = DockStyle.Bottom;
            btnvolver.FlatStyle = FlatStyle.Popup;
            btnvolver.Font = new Font("Microsoft Sans Serif", 8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnvolver.ForeColor = Color.Black;
            btnvolver.Location = new Point(3, 30);
            btnvolver.Margin = new Padding(3, 2, 3, 2);
            btnvolver.Name = "btnvolver";
            btnvolver.Size = new Size(34, 42);
            btnvolver.TabIndex = 52;
            btnvolver.Text = "Ir";
            btnvolver.UseVisualStyleBackColor = false;
            btnvolver.Click += btnvolver_Click;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label8.AutoSize = true;
            label8.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold);
            label8.ForeColor = Color.Black;
            label8.Location = new Point(42, 22);
            label8.Margin = new Padding(2, 0, 2, 0);
            label8.Name = "label8";
            label8.Size = new Size(756, 29);
            label8.TabIndex = 90;
            label8.Text = "Listado de compras";
            // 
            // webView21
            // 
            webView21.AllowExternalDrop = true;
            webView21.CreationProperties = null;
            webView21.DefaultBackgroundColor = Color.White;
            webView21.Dock = DockStyle.Fill;
            webView21.Location = new Point(43, 77);
            webView21.Name = "webView21";
            webView21.Size = new Size(754, 370);
            webView21.TabIndex = 91;
            webView21.ZoomFactor = 1D;
            // 
            // FormReportesCompras
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tableLayoutPanel1);
            Name = "FormReportesCompras";
            Text = "FormReportesCompras";
            Load += FormReportesCompras_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)webView21).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Button btnvolver;
        private Label label8;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView21;
    }
}