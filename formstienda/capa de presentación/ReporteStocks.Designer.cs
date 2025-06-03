namespace formstienda.capa_de_presentación
{
    partial class ReporteStocks
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
            btnSalirStock = new Button();
            label1 = new Label();
            webViewStock = new Microsoft.Web.WebView2.WinForms.WebView2();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)webViewStock).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10.5969906F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 89.40301F));
            tableLayoutPanel1.Controls.Add(btnSalirStock, 0, 0);
            tableLayoutPanel1.Controls.Add(label1, 1, 0);
            tableLayoutPanel1.Controls.Add(webViewStock, 1, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 12.8919888F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 87.10802F));
            tableLayoutPanel1.Size = new Size(800, 450);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // btnSalirStock
            // 
            btnSalirStock.BackColor = Color.DeepSkyBlue;
            btnSalirStock.Dock = DockStyle.Top;
            btnSalirStock.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSalirStock.Location = new Point(3, 3);
            btnSalirStock.Name = "btnSalirStock";
            btnSalirStock.Size = new Size(78, 52);
            btnSalirStock.TabIndex = 0;
            btnSalirStock.Text = "Salir";
            btnSalirStock.UseVisualStyleBackColor = false;
            btnSalirStock.Click += btnSalirStock_Click;
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
            label1.Text = "Stock Agotados";
            // 
            // webViewStock
            // 
            webViewStock.AllowExternalDrop = true;
            webViewStock.CreationProperties = null;
            webViewStock.DefaultBackgroundColor = Color.White;
            webViewStock.Dock = DockStyle.Fill;
            webViewStock.Location = new Point(87, 61);
            webViewStock.Name = "webViewStock";
            webViewStock.Size = new Size(710, 386);
            webViewStock.TabIndex = 3;
            webViewStock.ZoomFactor = 1D;
            // 
            // ReporteStocks
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tableLayoutPanel1);
            Name = "ReporteStocks";
            Text = "ReporteStocks";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)webViewStock).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Button btnSalirStock;
        private Label label1;
        private Microsoft.Web.WebView2.WinForms.WebView2 webViewStock;
    }
}