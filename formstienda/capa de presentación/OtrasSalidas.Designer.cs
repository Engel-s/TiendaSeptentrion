namespace formstienda.capa_de_presentación
{
    partial class OtrasSalidas
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
            button9 = new Button();
            label21 = new Label();
            textBox13 = new TextBox();
            label20 = new Label();
            label19 = new Label();
            textBox11 = new TextBox();
            label18 = new Label();
            label17 = new Label();
            cmbNombreProducto = new ComboBox();
            DGOTRASSALIDAS = new DataGridView();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            Column11 = new DataGridViewTextBoxColumn();
            Column12 = new DataGridViewTextBoxColumn();
            Column13 = new DataGridViewTextBoxColumn();
            descripcion = new DataGridViewTextBoxColumn();
            btnCancelar = new Button();
            btnGuardar = new Button();
            cmbMotivo = new ComboBox();
            label22 = new Label();
            txtCantidadSalir = new TextBox();
            label1 = new Label();
            txtStockDisponible = new TextBox();
            label2 = new Label();
            label3 = new Label();
            txtCodigo = new TextBox();
            label4 = new Label();
            label5 = new Label();
            button1 = new Button();
            label6 = new Label();
            txtDescripcion = new RichTextBox();
            ((System.ComponentModel.ISupportInitialize)DGOTRASSALIDAS).BeginInit();
            SuspendLayout();
            // 
            // button9
            // 
            button9.BackColor = Color.FromArgb(3, 171, 229);
            button9.FlatStyle = FlatStyle.Popup;
            button9.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button9.Location = new Point(-238, 640);
            button9.Margin = new Padding(2);
            button9.Name = "button9";
            button9.Size = new Size(74, 35);
            button9.TabIndex = 53;
            button9.Text = "Salir";
            button9.UseVisualStyleBackColor = false;
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label21.Location = new Point(-242, 26);
            label21.Margin = new Padding(2, 0, 2, 0);
            label21.Name = "label21";
            label21.Size = new Size(150, 20);
            label21.TabIndex = 46;
            label21.Text = "Cantidad a Salir:";
            // 
            // textBox13
            // 
            textBox13.Location = new Point(610, -50);
            textBox13.Margin = new Padding(2);
            textBox13.Name = "textBox13";
            textBox13.Size = new Size(118, 27);
            textBox13.TabIndex = 45;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label20.Location = new Point(458, -48);
            label20.Margin = new Padding(2, 0, 2, 0);
            label20.Name = "label20";
            label20.Size = new Size(167, 20);
            label20.TabIndex = 44;
            label20.Text = "Stock Disponibles:";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label19.Location = new Point(-242, -48);
            label19.Margin = new Padding(2, 0, 2, 0);
            label19.Name = "label19";
            label19.Size = new Size(192, 20);
            label19.TabIndex = 43;
            label19.Text = "Nombre del Producto:";
            // 
            // textBox11
            // 
            textBox11.Location = new Point(306, -50);
            textBox11.Margin = new Padding(2);
            textBox11.Name = "textBox11";
            textBox11.Size = new Size(118, 27);
            textBox11.TabIndex = 42;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label18.Location = new Point(214, -48);
            label18.Margin = new Padding(2, 0, 2, 0);
            label18.Name = "label18";
            label18.Size = new Size(73, 20);
            label18.TabIndex = 41;
            label18.Text = "Código:";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label17.Location = new Point(-242, -112);
            label17.Margin = new Padding(2, 0, 2, 0);
            label17.Name = "label17";
            label17.Size = new Size(150, 25);
            label17.TabIndex = 40;
            label17.Text = "Otras Salidas:";
            // 
            // cmbNombreProducto
            // 
            cmbNombreProducto.ForeColor = Color.Black;
            cmbNombreProducto.FormattingEnabled = true;
            cmbNombreProducto.Location = new Point(224, 73);
            cmbNombreProducto.Margin = new Padding(2);
            cmbNombreProducto.Name = "cmbNombreProducto";
            cmbNombreProducto.Size = new Size(180, 28);
            cmbNombreProducto.TabIndex = 68;
            cmbNombreProducto.SelectedIndexChanged += ComboBoxProductos_SelectedIndexChanged;
            // 
            // DGOTRASSALIDAS
            // 
            DGOTRASSALIDAS.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DGOTRASSALIDAS.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DGOTRASSALIDAS.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGOTRASSALIDAS.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn3, Column11, Column12, Column13, descripcion });
            DGOTRASSALIDAS.Location = new Point(26, 342);
            DGOTRASSALIDAS.Margin = new Padding(2);
            DGOTRASSALIDAS.Name = "DGOTRASSALIDAS";
            DGOTRASSALIDAS.RowHeadersWidth = 51;
            DGOTRASSALIDAS.RowTemplate.Height = 24;
            DGOTRASSALIDAS.Size = new Size(1230, 352);
            DGOTRASSALIDAS.TabIndex = 66;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.HeaderText = "Código";
            dataGridViewTextBoxColumn3.MinimumWidth = 6;
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // Column11
            // 
            Column11.HeaderText = "Nombre del Producto";
            Column11.MinimumWidth = 6;
            Column11.Name = "Column11";
            // 
            // Column12
            // 
            Column12.HeaderText = "Cantidad";
            Column12.MinimumWidth = 6;
            Column12.Name = "Column12";
            // 
            // Column13
            // 
            Column13.HeaderText = "Motivo";
            Column13.MinimumWidth = 6;
            Column13.Name = "Column13";
            // 
            // descripcion
            // 
            descripcion.HeaderText = "Descripción";
            descripcion.MinimumWidth = 6;
            descripcion.Name = "descripcion";
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.FromArgb(3, 171, 229);
            btnCancelar.Font = new Font("Calisto MT", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancelar.ForeColor = Color.Black;
            btnCancelar.Location = new Point(975, 203);
            btnCancelar.Margin = new Padding(2);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(134, 54);
            btnCancelar.TabIndex = 65;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.FromArgb(3, 171, 229);
            btnGuardar.Font = new Font("Calisto MT", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGuardar.ForeColor = Color.Black;
            btnGuardar.Location = new Point(807, 203);
            btnGuardar.Margin = new Padding(2);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(134, 54);
            btnGuardar.TabIndex = 64;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // cmbMotivo
            // 
            cmbMotivo.FormattingEnabled = true;
            cmbMotivo.Items.AddRange(new object[] { "Defecto de fabrica", "Facturacion erronea", "Producto dañado", "Uso personal", "Patrocinio" });
            cmbMotivo.Location = new Point(393, 134);
            cmbMotivo.Margin = new Padding(2);
            cmbMotivo.Name = "cmbMotivo";
            cmbMotivo.Size = new Size(246, 28);
            cmbMotivo.TabIndex = 63;
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label22.ForeColor = Color.Black;
            label22.Location = new Point(319, 137);
            label22.Margin = new Padding(2, 0, 2, 0);
            label22.Name = "label22";
            label22.Size = new Size(70, 20);
            label22.TabIndex = 62;
            label22.Text = "Motivo:";
            // 
            // txtCantidadSalir
            // 
            txtCantidadSalir.Location = new Point(176, 134);
            txtCantidadSalir.Margin = new Padding(2);
            txtCantidadSalir.Name = "txtCantidadSalir";
            txtCantidadSalir.Size = new Size(70, 27);
            txtCantidadSalir.TabIndex = 61;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(27, 137);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(150, 20);
            label1.TabIndex = 60;
            label1.Text = "Cantidad a Salir:";
            // 
            // txtStockDisponible
            // 
            txtStockDisponible.Location = new Point(875, 77);
            txtStockDisponible.Margin = new Padding(2);
            txtStockDisponible.Name = "txtStockDisponible";
            txtStockDisponible.ReadOnly = true;
            txtStockDisponible.Size = new Size(66, 27);
            txtStockDisponible.TabIndex = 59;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(712, 80);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(157, 20);
            label2.TabIndex = 58;
            label2.Text = "Stock Disponible:";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(22, 76);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(192, 20);
            label3.TabIndex = 57;
            label3.Text = "Nombre del Producto:";
            // 
            // txtCodigo
            // 
            txtCodigo.Location = new Point(534, 73);
            txtCodigo.Margin = new Padding(2);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.ReadOnly = true;
            txtCodigo.Size = new Size(134, 27);
            txtCodigo.TabIndex = 56;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(450, 76);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(73, 20);
            label4.TabIndex = 55;
            label4.Text = "Código:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.Black;
            label5.Location = new Point(22, 10);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(150, 25);
            label5.TabIndex = 54;
            label5.Text = "Otras Salidas:";
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button1.BackColor = Color.FromArgb(3, 171, 229);
            button1.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.Black;
            button1.Location = new Point(1126, 713);
            button1.Margin = new Padding(2);
            button1.Name = "button1";
            button1.Size = new Size(130, 50);
            button1.TabIndex = 69;
            button1.Text = "Salir";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.Black;
            label6.Location = new Point(22, 203);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new Size(116, 20);
            label6.TabIndex = 70;
            label6.Text = "Descripción:";
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(198, 205);
            txtDescripcion.Margin = new Padding(2, 3, 2, 3);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(446, 72);
            txtDescripcion.TabIndex = 71;
            txtDescripcion.Text = "";
            // 
            // OtrasSalidas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1278, 774);
            Controls.Add(txtDescripcion);
            Controls.Add(label6);
            Controls.Add(button1);
            Controls.Add(cmbNombreProducto);
            Controls.Add(DGOTRASSALIDAS);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(cmbMotivo);
            Controls.Add(label22);
            Controls.Add(txtCantidadSalir);
            Controls.Add(label1);
            Controls.Add(txtStockDisponible);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(txtCodigo);
            Controls.Add(label4);
            Controls.Add(label5);
            Controls.Add(button9);
            Controls.Add(label21);
            Controls.Add(textBox13);
            Controls.Add(label20);
            Controls.Add(label19);
            Controls.Add(textBox11);
            Controls.Add(label18);
            Controls.Add(label17);
            ForeColor = Color.Black;
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(2, 3, 2, 3);
            Name = "OtrasSalidas";
            Text = "OtrasSalidas";
            Load += OtrasSalidas_Load;
            ((System.ComponentModel.ISupportInitialize)DGOTRASSALIDAS).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox textBox13;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox cmbNombreProducto;
        private System.Windows.Forms.DataGridView DGOTRASSALIDAS;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.ComboBox cmbMotivo;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txtCantidadSalir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtStockDisponible;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox txtDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
    }
}