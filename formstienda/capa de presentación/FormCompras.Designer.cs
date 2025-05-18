namespace formstienda
{
    partial class FormCompras
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
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCompras));
            label9 = new Label();
            btnregistrar = new Button();
            txtsubtotalcompra = new TextBox();
            button3 = new Button();
            dtgcompras = new DataGridView();
            btncancelar = new Button();
            datefecha = new DateTimePicker();
            label18 = new Label();
            txtprecioventa = new TextBox();
            pictureBox2 = new PictureBox();
            txtpreciocompra = new TextBox();
            label16 = new Label();
            label15 = new Label();
            label1 = new Label();
            label14 = new Label();
            label3 = new Label();
            txtnombreproveedor = new TextBox();
            label13 = new Label();
            label2 = new Label();
            txtcodigoproducto = new TextBox();
            label10 = new Label();
            label7 = new Label();
            label12 = new Label();
            txtcantidadproducto = new TextBox();
            txtnumerofactura = new TextBox();
            label11 = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            cmbmarcas = new ComboBox();
            cmbcategoria = new ComboBox();
            pictureBox6 = new PictureBox();
            pictureBox5 = new PictureBox();
            pictureBox4 = new PictureBox();
            cmbproducto = new ComboBox();
            label8 = new Label();
            btnagregar = new Button();
            btnnuevo = new Button();
            txtbuscartelefono = new MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)dtgcompras).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            SuspendLayout();
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label9.AutoSize = true;
            label9.Font = new Font("Microsoft Sans Serif", 11.2F, FontStyle.Bold);
            label9.ForeColor = Color.Black;
            label9.Location = new Point(1196, 562);
            label9.Margin = new Padding(2, 0, 2, 0);
            label9.Name = "label9";
            label9.Padding = new Padding(10, 0, 10, 0);
            label9.Size = new Size(153, 24);
            label9.TabIndex = 71;
            label9.Text = "Total a Pagar";
            // 
            // btnregistrar
            // 
            btnregistrar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnregistrar.BackColor = Color.FromArgb(3, 171, 229);
            btnregistrar.Cursor = Cursors.Hand;
            btnregistrar.FlatStyle = FlatStyle.Popup;
            btnregistrar.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnregistrar.ForeColor = Color.Black;
            btnregistrar.Location = new Point(1217, 702);
            btnregistrar.Margin = new Padding(2);
            btnregistrar.Name = "btnregistrar";
            btnregistrar.Size = new Size(118, 42);
            btnregistrar.TabIndex = 74;
            btnregistrar.Text = "Registrar";
            btnregistrar.UseVisualStyleBackColor = false;
            btnregistrar.Click += button4_Click;
            // 
            // txtsubtotalcompra
            // 
            txtsubtotalcompra.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            txtsubtotalcompra.Location = new Point(1202, 610);
            txtsubtotalcompra.Margin = new Padding(2);
            txtsubtotalcompra.Name = "txtsubtotalcompra";
            txtsubtotalcompra.ReadOnly = true;
            txtsubtotalcompra.Size = new Size(134, 27);
            txtsubtotalcompra.TabIndex = 72;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button3.BackColor = Color.FromArgb(3, 171, 229);
            button3.Cursor = Cursors.Hand;
            button3.FlatStyle = FlatStyle.Popup;
            button3.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.ForeColor = Color.Black;
            button3.Location = new Point(1217, 813);
            button3.Margin = new Padding(2);
            button3.Name = "button3";
            button3.Size = new Size(118, 42);
            button3.TabIndex = 73;
            button3.Text = "Salir";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click_1;
            // 
            // dtgcompras
            // 
            dtgcompras.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dtgcompras.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgcompras.BackgroundColor = Color.FromArgb(238, 238, 238);
            dtgcompras.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dtgcompras.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dtgcompras.ColumnHeadersHeight = 29;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.Transparent;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = Color.White;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dtgcompras.DefaultCellStyle = dataGridViewCellStyle2;
            dtgcompras.Location = new Point(12, 432);
            dtgcompras.Margin = new Padding(2);
            dtgcompras.Name = "dtgcompras";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = Color.Black;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dtgcompras.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dtgcompras.RowHeadersWidth = 62;
            dtgcompras.RowTemplate.Height = 28;
            dtgcompras.Size = new Size(1138, 337);
            dtgcompras.TabIndex = 69;
            // 
            // btncancelar
            // 
            btncancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btncancelar.BackColor = Color.FromArgb(3, 171, 229);
            btncancelar.Cursor = Cursors.Hand;
            btncancelar.FlatStyle = FlatStyle.Popup;
            btncancelar.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btncancelar.ForeColor = Color.Black;
            btncancelar.Location = new Point(1217, 756);
            btncancelar.Margin = new Padding(2);
            btncancelar.Name = "btncancelar";
            btncancelar.Size = new Size(118, 42);
            btncancelar.TabIndex = 70;
            btncancelar.Text = "Cancelar";
            btncancelar.UseVisualStyleBackColor = false;
            btncancelar.Click += button2_Click_1;
            // 
            // datefecha
            // 
            datefecha.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            datefecha.Location = new Point(1074, 112);
            datefecha.Margin = new Padding(2, 5, 2, 5);
            datefecha.Name = "datefecha";
            datefecha.Size = new Size(262, 27);
            datefecha.TabIndex = 97;
            // 
            // label18
            // 
            label18.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label18.AutoSize = true;
            label18.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label18.ForeColor = Color.Black;
            label18.Location = new Point(880, 114);
            label18.Margin = new Padding(2, 0, 2, 0);
            label18.Name = "label18";
            label18.Padding = new Padding(10, 0, 10, 0);
            label18.Size = new Size(190, 22);
            label18.TabIndex = 96;
            label18.Text = "Fecha de compra:";
            label18.Click += label18_Click;
            // 
            // txtprecioventa
            // 
            txtprecioventa.Location = new Point(731, 346);
            txtprecioventa.Margin = new Padding(2);
            txtprecioventa.Name = "txtprecioventa";
            txtprecioventa.Size = new Size(138, 27);
            txtprecioventa.TabIndex = 88;
            txtprecioventa.TextChanged += textBox12_TextChanged_1;
            txtprecioventa.KeyPress += txtprecioventa_KeyPress;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.busque_un_simbolo_de_interfaz_de_persona_de_una_lupa_en_forma_de_hombre;
            pictureBox2.Location = new Point(245, 112);
            pictureBox2.Margin = new Padding(2);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(36, 37);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 95;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click_1;
            // 
            // txtpreciocompra
            // 
            txtpreciocompra.Location = new Point(425, 350);
            txtpreciocompra.Margin = new Padding(2);
            txtpreciocompra.Name = "txtpreciocompra";
            txtpreciocompra.Size = new Size(138, 27);
            txtpreciocompra.TabIndex = 87;
            txtpreciocompra.KeyPress += txtpreciocompra_KeyPress;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label16.ForeColor = Color.Black;
            label16.Location = new Point(282, 350);
            label16.Margin = new Padding(2, 0, 2, 0);
            label16.Name = "label16";
            label16.Size = new Size(144, 22);
            label16.TabIndex = 86;
            label16.Text = "Precio compra:";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label15.ForeColor = Color.Black;
            label15.Location = new Point(587, 348);
            label15.Margin = new Padding(2, 0, 2, 0);
            label15.Name = "label15";
            label15.Size = new Size(128, 22);
            label15.TabIndex = 85;
            label15.Text = "Precio venta:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(22, 118);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(95, 22);
            label1.TabIndex = 77;
            label1.Text = "Teléfono:";
            label1.Click += label1_Click;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label14.ForeColor = Color.Black;
            label14.Location = new Point(346, 288);
            label14.Margin = new Padding(2, 0, 2, 0);
            label14.Name = "label14";
            label14.Size = new Size(70, 22);
            label14.TabIndex = 83;
            label14.Text = "Marca:";
            label14.Click += label14_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(371, 118);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(85, 22);
            label3.TabIndex = 63;
            label3.Text = "Nombre:";
            // 
            // txtnombreproveedor
            // 
            txtnombreproveedor.Location = new Point(471, 118);
            txtnombreproveedor.Margin = new Padding(2);
            txtnombreproveedor.Name = "txtnombreproveedor";
            txtnombreproveedor.ReadOnly = true;
            txtnombreproveedor.Size = new Size(234, 27);
            txtnombreproveedor.TabIndex = 64;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label13.ForeColor = Color.Black;
            label13.Location = new Point(26, 288);
            label13.Margin = new Padding(2, 0, 2, 0);
            label13.Name = "label13";
            label13.Size = new Size(103, 22);
            label13.TabIndex = 81;
            label13.Text = "Categoría:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 14F, FontStyle.Bold);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(22, 173);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(107, 26);
            label2.TabIndex = 61;
            label2.Text = "Producto";
            // 
            // txtcodigoproducto
            // 
            txtcodigoproducto.Location = new Point(124, 350);
            txtcodigoproducto.Margin = new Padding(2);
            txtcodigoproducto.Name = "txtcodigoproducto";
            txtcodigoproducto.ReadOnly = true;
            txtcodigoproducto.Size = new Size(142, 27);
            txtcodigoproducto.TabIndex = 62;
            txtcodigoproducto.TextChanged += textBox3_TextChanged_1;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.ForeColor = Color.Black;
            label10.Location = new Point(587, 292);
            label10.Margin = new Padding(2, 0, 2, 0);
            label10.Name = "label10";
            label10.Size = new Size(80, 22);
            label10.TabIndex = 79;
            label10.Text = "Modelo:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.Black;
            label7.Location = new Point(888, 348);
            label7.Margin = new Padding(2, 0, 2, 0);
            label7.Name = "label7";
            label7.Size = new Size(96, 22);
            label7.TabIndex = 67;
            label7.Text = "Cantidad:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.ForeColor = Color.Black;
            label12.Location = new Point(26, 350);
            label12.Margin = new Padding(2, 0, 2, 0);
            label12.Name = "label12";
            label12.Size = new Size(79, 22);
            label12.TabIndex = 78;
            label12.Text = "Código:";
            // 
            // txtcantidadproducto
            // 
            txtcantidadproducto.Location = new Point(989, 343);
            txtcantidadproducto.Margin = new Padding(2);
            txtcantidadproducto.Name = "txtcantidadproducto";
            txtcantidadproducto.Size = new Size(78, 27);
            txtcantidadproducto.TabIndex = 68;
            txtcantidadproducto.TextChanged += txtcantidadproducto_TextChanged;
            txtcantidadproducto.KeyPress += txtcantidadproducto_KeyPress;
            // 
            // txtnumerofactura
            // 
            txtnumerofactura.Location = new Point(130, 230);
            txtnumerofactura.Margin = new Padding(2);
            txtnumerofactura.Name = "txtnumerofactura";
            txtnumerofactura.ReadOnly = true;
            txtnumerofactura.Size = new Size(81, 27);
            txtnumerofactura.TabIndex = 76;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.ForeColor = Color.Black;
            label11.Location = new Point(26, 230);
            label11.Margin = new Padding(2, 0, 2, 0);
            label11.Name = "label11";
            label11.Size = new Size(106, 22);
            label11.TabIndex = 75;
            label11.Text = "N° factura:";
            // 
            // cmbmarcas
            // 
            cmbmarcas.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbmarcas.FormattingEnabled = true;
            cmbmarcas.Items.AddRange(new object[] { "ID Producto", "Nombre del producto" });
            cmbmarcas.Location = new Point(421, 286);
            cmbmarcas.Margin = new Padding(2, 5, 2, 5);
            cmbmarcas.Name = "cmbmarcas";
            cmbmarcas.Size = new Size(142, 28);
            cmbmarcas.TabIndex = 98;
            // 
            // cmbcategoria
            // 
            cmbcategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbcategoria.FormattingEnabled = true;
            cmbcategoria.Location = new Point(127, 286);
            cmbcategoria.Margin = new Padding(2, 5, 2, 5);
            cmbcategoria.Name = "cmbcategoria";
            cmbcategoria.Size = new Size(200, 28);
            cmbcategoria.TabIndex = 99;
            cmbcategoria.SelectedIndexChanged += cmbcategoria_SelectedIndexChanged;
            // 
            // pictureBox6
            // 
            pictureBox6.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            pictureBox6.Image = (Image)resources.GetObject("pictureBox6.Image");
            pictureBox6.Location = new Point(1183, 813);
            pictureBox6.Margin = new Padding(2);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(30, 42);
            pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox6.TabIndex = 136;
            pictureBox6.TabStop = false;
            // 
            // pictureBox5
            // 
            pictureBox5.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            pictureBox5.Image = (Image)resources.GetObject("pictureBox5.Image");
            pictureBox5.Location = new Point(1183, 756);
            pictureBox5.Margin = new Padding(2);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(30, 42);
            pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox5.TabIndex = 135;
            pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(1183, 702);
            pictureBox4.Margin = new Padding(2);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(30, 42);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 134;
            pictureBox4.TabStop = false;
            // 
            // cmbproducto
            // 
            cmbproducto.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbproducto.FormattingEnabled = true;
            cmbproducto.Location = new Point(677, 288);
            cmbproducto.Margin = new Padding(2, 5, 2, 5);
            cmbproducto.Name = "cmbproducto";
            cmbproducto.Size = new Size(193, 28);
            cmbproducto.TabIndex = 137;
            cmbproducto.SelectedIndexChanged += cmbproducto_SelectedIndexChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold);
            label8.ForeColor = Color.Black;
            label8.Location = new Point(22, 68);
            label8.Margin = new Padding(2, 0, 2, 0);
            label8.Name = "label8";
            label8.Size = new Size(220, 29);
            label8.TabIndex = 89;
            label8.Text = "Buscar proveedor";
            label8.Click += label8_Click_1;
            // 
            // btnagregar
            // 
            btnagregar.BackColor = Color.FromArgb(3, 171, 229);
            btnagregar.Cursor = Cursors.Hand;
            btnagregar.FlatStyle = FlatStyle.Popup;
            btnagregar.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnagregar.ForeColor = Color.Black;
            btnagregar.Location = new Point(1084, 341);
            btnagregar.Margin = new Padding(2);
            btnagregar.Name = "btnagregar";
            btnagregar.Size = new Size(90, 29);
            btnagregar.TabIndex = 138;
            btnagregar.Text = "Agregar";
            btnagregar.UseVisualStyleBackColor = false;
            btnagregar.Click += button1_Click_1;
            // 
            // btnnuevo
            // 
            btnnuevo.BackColor = Color.FromArgb(3, 171, 229);
            btnnuevo.Cursor = Cursors.Hand;
            btnnuevo.FlatStyle = FlatStyle.Popup;
            btnnuevo.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnnuevo.ForeColor = Color.Black;
            btnnuevo.Location = new Point(731, 118);
            btnnuevo.Margin = new Padding(2);
            btnnuevo.Name = "btnnuevo";
            btnnuevo.Size = new Size(90, 29);
            btnnuevo.TabIndex = 139;
            btnnuevo.Text = "Nuevo";
            btnnuevo.UseVisualStyleBackColor = false;
            btnnuevo.Click += btnnuevo_Click;
            // 
            // txtbuscartelefono
            // 
            txtbuscartelefono.Location = new Point(127, 118);
            txtbuscartelefono.Mask = "0000-0000";
            txtbuscartelefono.Name = "txtbuscartelefono";
            txtbuscartelefono.Size = new Size(103, 27);
            txtbuscartelefono.TabIndex = 140;
            txtbuscartelefono.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            txtbuscartelefono.MaskInputRejected += txtbuscartelefono_MaskInputRejected;
            // 
            // FormCompras
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(238, 238, 238);
            ClientSize = new Size(1362, 882);
            Controls.Add(txtbuscartelefono);
            Controls.Add(btnnuevo);
            Controls.Add(btnagregar);
            Controls.Add(cmbproducto);
            Controls.Add(pictureBox6);
            Controls.Add(pictureBox5);
            Controls.Add(pictureBox4);
            Controls.Add(cmbcategoria);
            Controls.Add(cmbmarcas);
            Controls.Add(label9);
            Controls.Add(btnregistrar);
            Controls.Add(txtsubtotalcompra);
            Controls.Add(button3);
            Controls.Add(dtgcompras);
            Controls.Add(btncancelar);
            Controls.Add(label8);
            Controls.Add(datefecha);
            Controls.Add(label18);
            Controls.Add(txtprecioventa);
            Controls.Add(pictureBox2);
            Controls.Add(txtpreciocompra);
            Controls.Add(label16);
            Controls.Add(label15);
            Controls.Add(label1);
            Controls.Add(label14);
            Controls.Add(label3);
            Controls.Add(txtnombreproveedor);
            Controls.Add(label13);
            Controls.Add(label2);
            Controls.Add(txtcodigoproducto);
            Controls.Add(label10);
            Controls.Add(label7);
            Controls.Add(label12);
            Controls.Add(txtcantidadproducto);
            Controls.Add(txtnumerofactura);
            Controls.Add(label11);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(2);
            Name = "FormCompras";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Compras";
            WindowState = FormWindowState.Maximized;
            Load += FormCompras_Load;
            KeyPress += FormCompras_KeyPress;
            ((System.ComponentModel.ISupportInitialize)dtgcompras).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnregistrar;
        private System.Windows.Forms.TextBox txtsubtotalcompra;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridView dtgcompras;
        private System.Windows.Forms.Button btncancelar;
        private System.Windows.Forms.DateTimePicker datefecha;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtprecioventa;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox txtpreciocompra;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtnombreproveedor;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtcodigoproducto;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtcantidadproducto;
        private System.Windows.Forms.TextBox txtnumerofactura;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ComboBox cmbmarcas;
        private System.Windows.Forms.ComboBox cmbcategoria;
        private PictureBox pictureBox6;
        private PictureBox pictureBox5;
        private PictureBox pictureBox4;
        private ComboBox cmbproducto;
        private Label label8;
        private Button btnagregar;
        private Button btnnuevo;
        private MaskedTextBox txtbuscartelefono;
    }
}