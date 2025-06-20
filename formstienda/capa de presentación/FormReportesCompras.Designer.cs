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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormReportesCompras));
            tableLayoutPanel1 = new TableLayoutPanel();
            label1 = new Label();
            webView21 = new Microsoft.Web.WebView2.WinForms.WebView2();
            panel1 = new Panel();
            pictureBox6 = new PictureBox();
            button3 = new Button();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)webView21).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 90F));
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(webView21, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 90F));
            tableLayoutPanel1.Size = new Size(867, 521);
            tableLayoutPanel1.TabIndex = 0;
            tableLayoutPanel1.Paint += tableLayoutPanel1_Paint;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(861, 52);
            label1.TabIndex = 0;
            label1.Text = "Listado de compras";
            label1.Click += label1_Click;
            // 
            // webView21
            // 
            webView21.AllowExternalDrop = true;
            webView21.CreationProperties = null;
            webView21.DefaultBackgroundColor = Color.White;
            webView21.Dock = DockStyle.Fill;
            webView21.Location = new Point(3, 55);
            webView21.Name = "webView21";
            webView21.Size = new Size(861, 463);
            webView21.TabIndex = 1;
            webView21.ZoomFactor = 1D;
            // 
            // panel1
            // 
            panel1.Controls.Add(pictureBox6);
            panel1.Controls.Add(button3);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 453);
            panel1.Name = "panel1";
            panel1.Size = new Size(867, 68);
            panel1.TabIndex = 0;
            // 
            // pictureBox6
            // 
            pictureBox6.Anchor = AnchorStyles.Right;
            pictureBox6.Image = (Image)resources.GetObject("pictureBox6.Image");
            pictureBox6.Location = new Point(736, 15);
            pictureBox6.Margin = new Padding(2);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(30, 42);
            pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox6.TabIndex = 138;
            pictureBox6.TabStop = false;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Right;
            button3.BackColor = Color.FromArgb(3, 171, 229);
            button3.Cursor = Cursors.Hand;
            button3.FlatStyle = FlatStyle.Popup;
            button3.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.ForeColor = Color.Black;
            button3.Location = new Point(770, 15);
            button3.Margin = new Padding(2);
            button3.Name = "button3";
            button3.Size = new Size(75, 42);
            button3.TabIndex = 137;
            button3.Text = "Salir";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // FormReportesCompras
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(867, 521);
            Controls.Add(panel1);
            Controls.Add(tableLayoutPanel1);
            Name = "FormReportesCompras";
            Text = "FormReportesCompras";
            Load += FormReportesCompras_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)webView21).EndInit();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private Panel panel1;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView21;
        private PictureBox pictureBox6;
        private Button button3;
    }
}