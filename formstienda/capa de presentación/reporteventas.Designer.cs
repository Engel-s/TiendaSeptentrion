namespace formstienda.capa_de_presentación
{
    partial class reporteventas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(reporteventas));
            lblreport = new Label();
            btnsalir = new FontAwesome.Sharp.IconButton();
            webview = new Microsoft.Web.WebView2.WinForms.WebView2();
            pictureBox6 = new PictureBox();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)webview).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // lblreport
            // 
            lblreport.AutoSize = true;
            lblreport.Font = new Font("Century Gothic", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblreport.ForeColor = Color.Black;
            lblreport.Location = new Point(65, 19);
            lblreport.Name = "lblreport";
            lblreport.Size = new Size(560, 70);
            lblreport.TabIndex = 3;
            lblreport.Text = "Reporte de ventas";
            // 
            // btnsalir
            // 
            btnsalir.Anchor = AnchorStyles.Right;
            btnsalir.BackColor = Color.FromArgb(3, 171, 229);
            btnsalir.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnsalir.ForeColor = Color.Black;
            btnsalir.IconChar = FontAwesome.Sharp.IconChar.None;
            btnsalir.IconColor = Color.Black;
            btnsalir.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnsalir.Location = new Point(1004, 6);
            btnsalir.Name = "btnsalir";
            btnsalir.Size = new Size(149, 58);
            btnsalir.TabIndex = 4;
            btnsalir.Text = "Salir";
            btnsalir.UseVisualStyleBackColor = false;
            btnsalir.Click += btnsalir_Click_1;
            // 
            // webview
            // 
            webview.AllowExternalDrop = true;
            webview.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            webview.CreationProperties = null;
            webview.DefaultBackgroundColor = Color.White;
            webview.ForeColor = Color.Black;
            webview.Location = new Point(65, 131);
            webview.Name = "webview";
            webview.Size = new Size(1057, 496);
            webview.TabIndex = 5;
            webview.ZoomFactor = 1D;
            // 
            // pictureBox6
            // 
            pictureBox6.Anchor = AnchorStyles.Right;
            pictureBox6.Image = (Image)resources.GetObject("pictureBox6.Image");
            pictureBox6.Location = new Point(915, 6);
            pictureBox6.Margin = new Padding(2);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(61, 58);
            pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox6.TabIndex = 139;
            pictureBox6.TabStop = false;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnsalir);
            panel1.Controls.Add(pictureBox6);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 663);
            panel1.Name = "panel1";
            panel1.Size = new Size(1202, 76);
            panel1.TabIndex = 140;
            // 
            // reporteventas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1202, 739);
            Controls.Add(panel1);
            Controls.Add(lblreport);
            Controls.Add(webview);
            FormBorderStyle = FormBorderStyle.None;
            Name = "reporteventas";
            Text = "reporteventas";
            Load += reporteventas_Load;
            ((System.ComponentModel.ISupportInitialize)webview).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblreport;
        private FontAwesome.Sharp.IconButton btnsalir;
        private Microsoft.Web.WebView2.WinForms.WebView2 webview;
        private PictureBox pictureBox6;
        private Panel panel1;
    }
}