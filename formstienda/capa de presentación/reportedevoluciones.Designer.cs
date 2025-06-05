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
            tableLayoutPanel1 = new TableLayoutPanel();
            iconButton1 = new FontAwesome.Sharp.IconButton();
            label1 = new Label();
            webviewdevoluciones = new Microsoft.Web.WebView2.WinForms.WebView2();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)webviewdevoluciones).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.181818F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 83.8181839F));
            tableLayoutPanel1.Controls.Add(iconButton1, 0, 0);
            tableLayoutPanel1.Controls.Add(label1, 1, 0);
            tableLayoutPanel1.Controls.Add(webviewdevoluciones, 1, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 12.29135F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 87.70865F));
            tableLayoutPanel1.Size = new Size(1100, 659);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // iconButton1
            // 
            iconButton1.BackColor = Color.FromArgb(3, 171, 229);
            iconButton1.Font = new Font("Century Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            iconButton1.ForeColor = Color.Black;
            iconButton1.IconChar = FontAwesome.Sharp.IconChar.None;
            iconButton1.IconColor = Color.Black;
            iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton1.Location = new Point(3, 3);
            iconButton1.Name = "iconButton1";
            iconButton1.Size = new Size(167, 64);
            iconButton1.TabIndex = 0;
            iconButton1.Text = "Salir";
            iconButton1.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(181, 0);
            label1.Name = "label1";
            label1.Size = new Size(758, 70);
            label1.TabIndex = 1;
            label1.Text = "Reporte de devoluciones";
            // 
            // webviewdevoluciones
            // 
            webviewdevoluciones.AllowExternalDrop = true;
            webviewdevoluciones.CreationProperties = null;
            webviewdevoluciones.DefaultBackgroundColor = Color.White;
            webviewdevoluciones.Dock = DockStyle.Fill;
            webviewdevoluciones.ForeColor = Color.Black;
            webviewdevoluciones.Location = new Point(181, 84);
            webviewdevoluciones.Name = "webviewdevoluciones";
            webviewdevoluciones.Size = new Size(916, 572);
            webviewdevoluciones.TabIndex = 2;
            webviewdevoluciones.ZoomFactor = 1D;
            // 
            // reportedevoluciones
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 659);
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "reportedevoluciones";
            Text = "reportedevoluciones";
            Load += reportedevoluciones_Load_1;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)webviewdevoluciones).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private FontAwesome.Sharp.IconButton iconButton1;
        private Label label1;
        private Microsoft.Web.WebView2.WinForms.WebView2 webviewdevoluciones;
    }
}