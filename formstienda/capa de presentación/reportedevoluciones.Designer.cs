namespace formstienda.capa_de_presentación
{
    partial class reportedevoluciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(reportedevoluciones));
            btnsalir = new FontAwesome.Sharp.IconButton();
            label1 = new Label();
            webviewdevoluciones = new Microsoft.Web.WebView2.WinForms.WebView2();
            panel1 = new Panel();
            pictureBox6 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)webviewdevoluciones).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            SuspendLayout();
            // 
            // btnsalir
            // 
            btnsalir.Anchor = AnchorStyles.Right;
            btnsalir.BackColor = Color.FromArgb(3, 171, 229);
            btnsalir.Font = new Font("Century Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnsalir.ForeColor = Color.Black;
            btnsalir.IconChar = FontAwesome.Sharp.IconChar.None;
            btnsalir.IconColor = Color.Black;
            btnsalir.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnsalir.Location = new Point(943, 25);
            btnsalir.Name = "btnsalir";
            btnsalir.Size = new Size(145, 58);
            btnsalir.TabIndex = 3;
            btnsalir.Text = "Salir";
            btnsalir.UseVisualStyleBackColor = false;
            btnsalir.Click += btnsalir_Click_1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(34, 25);
            label1.Name = "label1";
            label1.Size = new Size(758, 70);
            label1.TabIndex = 4;
            label1.Text = "Reporte de devoluciones";
            // 
            // webviewdevoluciones
            // 
            webviewdevoluciones.AllowExternalDrop = true;
            webviewdevoluciones.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            webviewdevoluciones.CreationProperties = null;
            webviewdevoluciones.DefaultBackgroundColor = Color.White;
            webviewdevoluciones.ForeColor = Color.Black;
            webviewdevoluciones.Location = new Point(76, 128);
            webviewdevoluciones.Name = "webviewdevoluciones";
            webviewdevoluciones.Size = new Size(943, 405);
            webviewdevoluciones.TabIndex = 5;
            webviewdevoluciones.ZoomFactor = 1D;
            // 
            // panel1
            // 
            panel1.Controls.Add(pictureBox6);
            panel1.Controls.Add(btnsalir);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 554);
            panel1.Name = "panel1";
            panel1.Size = new Size(1100, 105);
            panel1.TabIndex = 6;
            // 
            // pictureBox6
            // 
            pictureBox6.Anchor = AnchorStyles.Right;
            pictureBox6.Image = (Image)resources.GetObject("pictureBox6.Image");
            pictureBox6.Location = new Point(866, 25);
            pictureBox6.Margin = new Padding(2);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(61, 58);
            pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox6.TabIndex = 140;
            pictureBox6.TabStop = false;
            // 
            // reportedevoluciones
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 659);
            Controls.Add(panel1);
            Controls.Add(label1);
            Controls.Add(webviewdevoluciones);
            FormBorderStyle = FormBorderStyle.None;
            Name = "reportedevoluciones";
            Text = "reportedevoluciones";
            Load += reportedevoluciones_Load_1;
            ((System.ComponentModel.ISupportInitialize)webviewdevoluciones).EndInit();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FontAwesome.Sharp.IconButton btnsalir;
        private Label label1;
        private Microsoft.Web.WebView2.WinForms.WebView2 webviewdevoluciones;
        private Panel panel1;
        private PictureBox pictureBox6;
    }
}