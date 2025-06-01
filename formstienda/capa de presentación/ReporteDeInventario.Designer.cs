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
            btnSalir = new Button();
            DGREPORTEINVENTARIO = new DataGridView();
            label1 = new Label();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DGREPORTEINVENTARIO).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10.5969906F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 89.40301F));
            tableLayoutPanel1.Controls.Add(btnSalir, 0, 0);
            tableLayoutPanel1.Controls.Add(DGREPORTEINVENTARIO, 1, 1);
            tableLayoutPanel1.Controls.Add(label1, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 12.8919888F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 87.10802F));
            tableLayoutPanel1.Size = new Size(897, 455);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.DeepSkyBlue;
            btnSalir.Dock = DockStyle.Fill;
            btnSalir.Location = new Point(3, 3);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(89, 52);
            btnSalir.TabIndex = 0;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = false;
            // 
            // DGREPORTEINVENTARIO
            // 
            DGREPORTEINVENTARIO.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DGREPORTEINVENTARIO.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGREPORTEINVENTARIO.Location = new Point(98, 61);
            DGREPORTEINVENTARIO.Name = "DGREPORTEINVENTARIO";
            DGREPORTEINVENTARIO.RowHeadersWidth = 51;
            DGREPORTEINVENTARIO.Size = new Size(796, 391);
            DGREPORTEINVENTARIO.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(98, 0);
            label1.Name = "label1";
            label1.Size = new Size(796, 58);
            label1.TabIndex = 2;
            label1.Text = "Inventario Actual";
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
            ((System.ComponentModel.ISupportInitialize)DGREPORTEINVENTARIO).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Button btnSalir;
        private DataGridView DGREPORTEINVENTARIO;
        private Label label1;
    }
}