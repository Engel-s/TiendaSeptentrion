namespace formstienda
{
    partial class Devoluciones
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
            label1 = new Label();
            label2 = new Label();
            txtbusquedafactura = new TextBox();
            DGDETALLESDEVENTA = new DataGridView();
            CodigoProducto = new DataGridViewTextBoxColumn();
            ModeloProducto = new DataGridViewTextBoxColumn();
            Precio = new DataGridViewTextBoxColumn();
            Cantidad = new DataGridViewTextBoxColumn();
            Subtotal = new DataGridViewTextBoxColumn();
            cantidadDevuelta = new DataGridViewTextBoxColumn();
            label4 = new Label();
            CBMOTIVO = new ComboBox();
            label7 = new Label();
            txtmontodevolucion = new TextBox();
            btnconfirmarcambio = new Button();
            btnsalir = new Button();
            btncancelar = new Button();
            btnbuscar = new PictureBox();
            txttelefonodelcliente = new TextBox();
            label8 = new Label();
            txtnombrecliente = new TextBox();
            label5 = new Label();
            txtdescripcion = new TextBox();
            label3 = new Label();
            btnanularfactura = new Button();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)DGDETALLESDEVENTA).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnbuscar).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Calisto MT", 14F, FontStyle.Bold);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(317, 0);
            label1.Name = "label1";
            label1.Size = new Size(411, 28);
            label1.TabIndex = 0;
            label1.Text = "Proceso de solicitud de devoluciones ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Calisto MT", 10F, FontStyle.Bold);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(71, 73);
            label2.Name = "label2";
            label2.Size = new Size(125, 20);
            label2.TabIndex = 1;
            label2.Text = "Buscar Factura:";
            label2.Click += label2_Click;
            // 
            // txtbusquedafactura
            // 
            txtbusquedafactura.Font = new Font("Calisto MT", 10F, FontStyle.Bold);
            txtbusquedafactura.Location = new Point(202, 70);
            txtbusquedafactura.Margin = new Padding(3, 5, 3, 5);
            txtbusquedafactura.Name = "txtbusquedafactura";
            txtbusquedafactura.Size = new Size(295, 27);
            txtbusquedafactura.TabIndex = 3;
            // 
            // DGDETALLESDEVENTA
            // 
            DGDETALLESDEVENTA.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DGDETALLESDEVENTA.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DGDETALLESDEVENTA.BackgroundColor = Color.FromArgb(238, 238, 238);
            DGDETALLESDEVENTA.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGDETALLESDEVENTA.Columns.AddRange(new DataGridViewColumn[] { CodigoProducto, ModeloProducto, Precio, Cantidad, Subtotal, cantidadDevuelta });
            DGDETALLESDEVENTA.Location = new Point(17, 171);
            DGDETALLESDEVENTA.Margin = new Padding(3, 5, 3, 5);
            DGDETALLESDEVENTA.Name = "DGDETALLESDEVENTA";
            DGDETALLESDEVENTA.RowHeadersWidth = 51;
            DGDETALLESDEVENTA.RowTemplate.Height = 24;
            DGDETALLESDEVENTA.Size = new Size(1051, 276);
            DGDETALLESDEVENTA.TabIndex = 5;
            // 
            // CodigoProducto
            // 
            CodigoProducto.HeaderText = "Código";
            CodigoProducto.MinimumWidth = 6;
            CodigoProducto.Name = "CodigoProducto";
            // 
            // ModeloProducto
            // 
            ModeloProducto.HeaderText = "Producto";
            ModeloProducto.MinimumWidth = 6;
            ModeloProducto.Name = "ModeloProducto";
            // 
            // Precio
            // 
            Precio.HeaderText = "Precio";
            Precio.MinimumWidth = 6;
            Precio.Name = "Precio";
            // 
            // Cantidad
            // 
            Cantidad.HeaderText = "Cantidad";
            Cantidad.MinimumWidth = 6;
            Cantidad.Name = "Cantidad";
            // 
            // Subtotal
            // 
            Subtotal.HeaderText = "Subtotal";
            Subtotal.MinimumWidth = 6;
            Subtotal.Name = "Subtotal";
            // 
            // cantidadDevuelta
            // 
            cantidadDevuelta.HeaderText = "Cantidad devuelta";
            cantidadDevuelta.MinimumWidth = 8;
            cantidadDevuelta.Name = "cantidadDevuelta";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label4.AutoSize = true;
            label4.Font = new Font("Calisto MT", 10F, FontStyle.Bold);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(34, 507);
            label4.Name = "label4";
            label4.Size = new Size(174, 20);
            label4.TabIndex = 6;
            label4.Text = "Motivo de devolución:";
            label4.Click += label4_Click;
            // 
            // CBMOTIVO
            // 
            CBMOTIVO.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            CBMOTIVO.DropDownStyle = ComboBoxStyle.DropDownList;
            CBMOTIVO.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CBMOTIVO.FormattingEnabled = true;
            CBMOTIVO.Items.AddRange(new object[] { "Defecto de fabrica", "Error de facturación", "Garantía" });
            CBMOTIVO.Location = new Point(251, 507);
            CBMOTIVO.Margin = new Padding(3, 5, 3, 5);
            CBMOTIVO.Name = "CBMOTIVO";
            CBMOTIVO.Size = new Size(276, 28);
            CBMOTIVO.TabIndex = 7;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label7.AutoSize = true;
            label7.Font = new Font("Calisto MT", 10F, FontStyle.Bold);
            label7.ForeColor = Color.Black;
            label7.Location = new Point(38, 603);
            label7.Name = "label7";
            label7.Size = new Size(170, 20);
            label7.TabIndex = 12;
            label7.Text = "Monto de devolución:";
            label7.Click += label7_Click;
            // 
            // txtmontodevolucion
            // 
            txtmontodevolucion.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            txtmontodevolucion.Location = new Point(251, 600);
            txtmontodevolucion.Margin = new Padding(3, 5, 3, 5);
            txtmontodevolucion.Name = "txtmontodevolucion";
            txtmontodevolucion.ReadOnly = true;
            txtmontodevolucion.Size = new Size(275, 27);
            txtmontodevolucion.TabIndex = 13;
            txtmontodevolucion.TextChanged += textBox4_TextChanged;
            // 
            // btnconfirmarcambio
            // 
            btnconfirmarcambio.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnconfirmarcambio.BackColor = Color.FromArgb(3, 171, 229);
            btnconfirmarcambio.Cursor = Cursors.Hand;
            btnconfirmarcambio.FlatStyle = FlatStyle.Popup;
            btnconfirmarcambio.Font = new Font("Calisto MT", 10F, FontStyle.Bold);
            btnconfirmarcambio.ForeColor = Color.Black;
            btnconfirmarcambio.Location = new Point(806, 698);
            btnconfirmarcambio.Margin = new Padding(3, 5, 3, 5);
            btnconfirmarcambio.Name = "btnconfirmarcambio";
            btnconfirmarcambio.Size = new Size(129, 42);
            btnconfirmarcambio.TabIndex = 14;
            btnconfirmarcambio.Text = "Confirmar";
            btnconfirmarcambio.UseVisualStyleBackColor = false;
            btnconfirmarcambio.Click += button1_Click;
            // 
            // btnsalir
            // 
            btnsalir.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnsalir.BackColor = Color.FromArgb(3, 171, 229);
            btnsalir.Cursor = Cursors.Hand;
            btnsalir.FlatStyle = FlatStyle.Popup;
            btnsalir.Font = new Font("Calisto MT", 10F, FontStyle.Bold);
            btnsalir.ForeColor = Color.Black;
            btnsalir.Location = new Point(950, 698);
            btnsalir.Margin = new Padding(3, 5, 3, 5);
            btnsalir.Name = "btnsalir";
            btnsalir.Size = new Size(119, 42);
            btnsalir.TabIndex = 15;
            btnsalir.Text = "Salir";
            btnsalir.UseVisualStyleBackColor = false;
            btnsalir.Click += button2_Click;
            // 
            // btncancelar
            // 
            btncancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btncancelar.BackColor = Color.FromArgb(3, 171, 229);
            btncancelar.Cursor = Cursors.Hand;
            btncancelar.FlatStyle = FlatStyle.Popup;
            btncancelar.Font = new Font("Calisto MT", 10F, FontStyle.Bold);
            btncancelar.ForeColor = Color.Black;
            btncancelar.Location = new Point(657, 697);
            btncancelar.Margin = new Padding(3, 5, 3, 5);
            btncancelar.MinimumSize = new Size(103, 42);
            btncancelar.Name = "btncancelar";
            btncancelar.Size = new Size(134, 42);
            btncancelar.TabIndex = 16;
            btncancelar.Text = "Cancelar ";
            btncancelar.UseVisualStyleBackColor = false;
            btncancelar.Click += button3_Click;
            // 
            // btnbuscar
            // 
            btnbuscar.Image = Properties.Resources.busque_un_simbolo_de_interfaz_de_persona_de_una_lupa_en_forma_de_hombre;
            btnbuscar.Location = new Point(512, 64);
            btnbuscar.Margin = new Padding(3, 2, 3, 2);
            btnbuscar.Name = "btnbuscar";
            btnbuscar.Size = new Size(49, 41);
            btnbuscar.SizeMode = PictureBoxSizeMode.StretchImage;
            btnbuscar.TabIndex = 40;
            btnbuscar.TabStop = false;
            btnbuscar.Click += btnbuscar_Click;
            // 
            // txttelefonodelcliente
            // 
            txttelefonodelcliente.Font = new Font("Calisto MT", 10F, FontStyle.Bold);
            txttelefonodelcliente.Location = new Point(675, 120);
            txttelefonodelcliente.Margin = new Padding(3, 5, 3, 5);
            txttelefonodelcliente.Name = "txttelefonodelcliente";
            txttelefonodelcliente.ReadOnly = true;
            txttelefonodelcliente.Size = new Size(139, 27);
            txttelefonodelcliente.TabIndex = 41;
            txttelefonodelcliente.TextChanged += textBox5_TextChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Calisto MT", 10F, FontStyle.Bold);
            label8.ForeColor = Color.Black;
            label8.Location = new Point(71, 123);
            label8.Name = "label8";
            label8.Size = new Size(67, 20);
            label8.TabIndex = 42;
            label8.Text = "Cliente:";
            label8.Click += label8_Click;
            // 
            // txtnombrecliente
            // 
            txtnombrecliente.Font = new Font("Calisto MT", 10F, FontStyle.Bold);
            txtnombrecliente.Location = new Point(144, 120);
            txtnombrecliente.Margin = new Padding(3, 5, 3, 5);
            txtnombrecliente.Name = "txtnombrecliente";
            txtnombrecliente.ReadOnly = true;
            txtnombrecliente.Size = new Size(317, 27);
            txtnombrecliente.TabIndex = 43;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label5.AutoSize = true;
            label5.Font = new Font("Calisto MT", 10F, FontStyle.Bold);
            label5.ForeColor = Color.Black;
            label5.Location = new Point(34, 556);
            label5.Name = "label5";
            label5.Size = new Size(209, 20);
            label5.TabIndex = 44;
            label5.Text = "Descripción de devolución:";
            // 
            // txtdescripcion
            // 
            txtdescripcion.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            txtdescripcion.Location = new Point(251, 556);
            txtdescripcion.Margin = new Padding(3, 5, 3, 5);
            txtdescripcion.Name = "txtdescripcion";
            txtdescripcion.Size = new Size(275, 27);
            txtdescripcion.TabIndex = 45;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Calisto MT", 10F, FontStyle.Bold);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(566, 123);
            label3.Name = "label3";
            label3.Size = new Size(80, 20);
            label3.TabIndex = 46;
            label3.Text = "Teléfono:";
            // 
            // btnanularfactura
            // 
            btnanularfactura.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnanularfactura.BackColor = Color.FromArgb(3, 171, 229);
            btnanularfactura.Cursor = Cursors.Hand;
            btnanularfactura.FlatStyle = FlatStyle.Popup;
            btnanularfactura.Font = new Font("Calisto MT", 10F, FontStyle.Bold);
            btnanularfactura.ForeColor = Color.Black;
            btnanularfactura.Location = new Point(731, 646);
            btnanularfactura.Margin = new Padding(3, 5, 3, 5);
            btnanularfactura.Name = "btnanularfactura";
            btnanularfactura.Size = new Size(264, 42);
            btnanularfactura.TabIndex = 47;
            btnanularfactura.Text = "Anular Factura";
            btnanularfactura.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(btnbuscar);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(txtbusquedafactura);
            panel1.Controls.Add(txtnombrecliente);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(btnanularfactura);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(txtdescripcion);
            panel1.Controls.Add(DGDETALLESDEVENTA);
            panel1.Controls.Add(btncancelar);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(btnconfirmarcambio);
            panel1.Controls.Add(btnsalir);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(txttelefonodelcliente);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(CBMOTIVO);
            panel1.Controls.Add(txtmontodevolucion);
            panel1.Dock = DockStyle.Fill;
            panel1.ForeColor = Color.Black;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1105, 762);
            panel1.TabIndex = 48;
            // 
            // Devoluciones
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 122, 204);
            ClientSize = new Size(1105, 762);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 5, 3, 5);
            Name = "Devoluciones";
            Text = "Devoluciones";
            Load += Form4_Load;
            ((System.ComponentModel.ISupportInitialize)DGDETALLESDEVENTA).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnbuscar).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtbusquedafactura;
        private System.Windows.Forms.DataGridView DGDETALLESDEVENTA;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox CBMOTIVO;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtmontodevolucion;
        private System.Windows.Forms.Button btnconfirmarcambio;
        private System.Windows.Forms.Button btnsalir;
        private System.Windows.Forms.Button btncancelar;
        private System.Windows.Forms.PictureBox btnbuscar;
        private System.Windows.Forms.TextBox txttelefonodelcliente;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtnombrecliente;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtdescripcion;
        private Label label3;
        private Button btnanularfactura;
        private Panel panel1;
        private DataGridViewTextBoxColumn CodigoProducto;
        private DataGridViewTextBoxColumn ModeloProducto;
        private DataGridViewTextBoxColumn Precio;
        private DataGridViewTextBoxColumn Cantidad;
        private DataGridViewTextBoxColumn Subtotal;
        private DataGridViewTextBoxColumn cantidadDevuelta;
    }
}