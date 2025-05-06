namespace formstienda
{
    partial class Factura
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Factura));
            label10 = new Label();
            fechafactura = new ErrorProvider(components);
            facturafecha = new System.Windows.Forms.Timer(components);
            txtfaltante = new TextBox();
            dateTimePicker1 = new DateTimePicker();
            label18 = new Label();
            txtstock = new TextBox();
            txtpago = new TextBox();
            label14 = new Label();
            label16 = new Label();
            label17 = new Label();
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            textBox22 = new TextBox();
            label45 = new Label();
            checkBox1 = new CheckBox();
            txtbuscarcliente = new TextBox();
            txtcategoria = new TextBox();
            txtmarca = new TextBox();
            txtcodigoproducto = new TextBox();
            txtcambio = new TextBox();
            txtnombrecliente = new TextBox();
            txttotal = new TextBox();
            txtnumero = new TextBox();
            txtprecio = new TextBox();
            txtcantidad = new TextBox();
            label9 = new Label();
            comboBox5 = new ComboBox();
            pictureBox6 = new PictureBox();
            pictureBox5 = new PictureBox();
            pictureBox4 = new PictureBox();
            label13 = new Label();
            label12 = new Label();
            label11 = new Label();
            pictureBox3 = new PictureBox();
            label2 = new Label();
            button4 = new Button();
            btnnuevo = new Button();
            btnguardar = new Button();
            Busquedacliente = new PictureBox();
            label1 = new Label();
            label6 = new Label();
            label3 = new Label();
            dgmostrar = new DataGridView();
            CodigoProducto = new DataGridViewTextBoxColumn();
            Modelo = new DataGridViewTextBoxColumn();
            Categoria = new DataGridViewTextBoxColumn();
            Marca = new DataGridViewTextBoxColumn();
            Precio = new DataGridViewTextBoxColumn();
            Cantidad = new DataGridViewTextBoxColumn();
            Subtotal = new DataGridViewTextBoxColumn();
            eliminar = new DataGridViewTextBoxColumn();
            label5 = new Label();
            label15 = new Label();
            btncancelar = new Button();
            label7 = new Label();
            btnagregar = new Button();
            label8 = new Label();
            CBproductos = new ComboBox();
            CBmarcas = new ComboBox();
            CBcategorias = new ComboBox();
            txtproducto = new TextBox();
            label19 = new Label();
            label20 = new Label();
            label21 = new Label();
            label22 = new Label();
            lbltelefonocliente = new Label();
            lblcliente = new TextBox();
            ((System.ComponentModel.ISupportInitialize)fechafactura).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Busquedacliente).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgmostrar).BeginInit();
            SuspendLayout();
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(581, 309);
            label10.Margin = new Padding(2, 0, 2, 0);
            label10.Name = "label10";
            label10.Size = new Size(0, 20);
            label10.TabIndex = 9;
            // 
            // fechafactura
            // 
            fechafactura.ContainerControl = this;
            // 
            // facturafecha
            // 
            facturafecha.Tick += facturafecha_Tick;
            // 
            // txtfaltante
            // 
            txtfaltante.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            txtfaltante.Location = new Point(1169, 570);
            txtfaltante.Margin = new Padding(2, 5, 2, 5);
            txtfaltante.Name = "txtfaltante";
            txtfaltante.Size = new Size(134, 27);
            txtfaltante.TabIndex = 124;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dateTimePicker1.Location = new Point(992, 70);
            dateTimePicker1.Margin = new Padding(2, 5, 2, 5);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(296, 27);
            dateTimePicker1.TabIndex = 148;
            // 
            // label18
            // 
            label18.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label18.AutoSize = true;
            label18.Font = new Font("Calisto MT", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label18.ForeColor = Color.Black;
            label18.Location = new Point(1169, 545);
            label18.Margin = new Padding(2, 0, 2, 0);
            label18.Name = "label18";
            label18.Size = new Size(58, 20);
            label18.TabIndex = 122;
            label18.Text = "Dólar:";
            // 
            // txtstock
            // 
            txtstock.Location = new Point(697, 327);
            txtstock.Margin = new Padding(2, 5, 2, 5);
            txtstock.Name = "txtstock";
            txtstock.ReadOnly = true;
            txtstock.Size = new Size(120, 27);
            txtstock.TabIndex = 147;
            // 
            // txtpago
            // 
            txtpago.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            txtpago.Location = new Point(1169, 513);
            txtpago.Margin = new Padding(2, 5, 2, 5);
            txtpago.Name = "txtpago";
            txtpago.Size = new Size(134, 27);
            txtpago.TabIndex = 115;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Calisto MT", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label14.ForeColor = Color.Black;
            label14.Location = new Point(565, 330);
            label14.Margin = new Padding(2, 0, 2, 0);
            label14.Name = "label14";
            label14.Size = new Size(104, 20);
            label14.TabIndex = 146;
            label14.Text = "Stock actual:";
            // 
            // label16
            // 
            label16.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label16.AutoSize = true;
            label16.Font = new Font("Calisto MT", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label16.ForeColor = Color.Black;
            label16.Location = new Point(1167, 488);
            label16.Margin = new Padding(2, 0, 2, 0);
            label16.Name = "label16";
            label16.Size = new Size(81, 20);
            label16.TabIndex = 114;
            label16.Text = "Córdoba:";
            // 
            // label17
            // 
            label17.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label17.AutoSize = true;
            label17.Font = new Font("Calisto MT", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label17.ForeColor = Color.Black;
            label17.Location = new Point(872, 297);
            label17.Margin = new Padding(2, 0, 2, 0);
            label17.Name = "label17";
            label17.Size = new Size(125, 20);
            label17.TabIndex = 119;
            label17.Text = "Forma de pago:";
            // 
            // radioButton2
            // 
            radioButton2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            radioButton2.AutoSize = true;
            radioButton2.Font = new Font("Calisto MT", 10F, FontStyle.Bold);
            radioButton2.ForeColor = Color.Black;
            radioButton2.Location = new Point(992, 330);
            radioButton2.Margin = new Padding(2, 3, 2, 3);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(86, 24);
            radioButton2.TabIndex = 145;
            radioButton2.TabStop = true;
            radioButton2.Text = "Crédito";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            radioButton1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            radioButton1.AutoSize = true;
            radioButton1.Font = new Font("Calisto MT", 10F, FontStyle.Bold);
            radioButton1.ForeColor = Color.Black;
            radioButton1.Location = new Point(874, 330);
            radioButton1.Margin = new Padding(2, 3, 2, 3);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(95, 24);
            radioButton1.TabIndex = 144;
            radioButton1.TabStop = true;
            radioButton1.Text = "Contado";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // textBox22
            // 
            textBox22.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            textBox22.Location = new Point(992, 365);
            textBox22.Margin = new Padding(2, 5, 2, 5);
            textBox22.Name = "textBox22";
            textBox22.Size = new Size(226, 27);
            textBox22.TabIndex = 143;
            // 
            // label45
            // 
            label45.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label45.AutoSize = true;
            label45.Font = new Font("Calisto MT", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label45.ForeColor = Color.Black;
            label45.Location = new Point(872, 368);
            label45.Margin = new Padding(2, 0, 2, 0);
            label45.Name = "label45";
            label45.Size = new Size(112, 20);
            label45.TabIndex = 142;
            label45.Text = "Colillas INSS:";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.ForeColor = Color.Black;
            checkBox1.Location = new Point(122, 74);
            checkBox1.Margin = new Padding(2);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(94, 24);
            checkBox1.TabIndex = 139;
            checkBox1.Text = "Genérico ";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // txtbuscarcliente
            // 
            txtbuscarcliente.Location = new Point(495, 65);
            txtbuscarcliente.Margin = new Padding(2, 5, 2, 5);
            txtbuscarcliente.Name = "txtbuscarcliente";
            txtbuscarcliente.Size = new Size(322, 27);
            txtbuscarcliente.TabIndex = 136;
            // 
            // txtcategoria
            // 
            txtcategoria.Location = new Point(697, 276);
            txtcategoria.Margin = new Padding(2, 5, 2, 5);
            txtcategoria.Name = "txtcategoria";
            txtcategoria.ReadOnly = true;
            txtcategoria.Size = new Size(120, 27);
            txtcategoria.TabIndex = 130;
            // 
            // txtmarca
            // 
            txtmarca.Location = new Point(433, 276);
            txtmarca.Margin = new Padding(2, 5, 2, 5);
            txtmarca.Name = "txtmarca";
            txtmarca.ReadOnly = true;
            txtmarca.Size = new Size(120, 27);
            txtmarca.TabIndex = 128;
            // 
            // txtcodigoproducto
            // 
            txtcodigoproducto.Location = new Point(121, 322);
            txtcodigoproducto.Margin = new Padding(2, 5, 2, 5);
            txtcodigoproducto.Name = "txtcodigoproducto";
            txtcodigoproducto.ReadOnly = true;
            txtcodigoproducto.Size = new Size(172, 27);
            txtcodigoproducto.TabIndex = 125;
            // 
            // txtcambio
            // 
            txtcambio.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            txtcambio.Location = new Point(1169, 637);
            txtcambio.Margin = new Padding(2, 5, 2, 5);
            txtcambio.Name = "txtcambio";
            txtcambio.ReadOnly = true;
            txtcambio.Size = new Size(134, 27);
            txtcambio.TabIndex = 111;
            // 
            // txtnombrecliente
            // 
            txtnombrecliente.Location = new Point(324, 108);
            txtnombrecliente.Margin = new Padding(2, 5, 2, 5);
            txtnombrecliente.Name = "txtnombrecliente";
            txtnombrecliente.ReadOnly = true;
            txtnombrecliente.Size = new Size(430, 27);
            txtnombrecliente.TabIndex = 102;
            // 
            // txttotal
            // 
            txttotal.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            txttotal.Location = new Point(1167, 456);
            txttotal.Margin = new Padding(2, 5, 2, 5);
            txttotal.Name = "txttotal";
            txttotal.ReadOnly = true;
            txttotal.Size = new Size(134, 27);
            txttotal.TabIndex = 109;
            // 
            // txtnumero
            // 
            txtnumero.Location = new Point(168, 155);
            txtnumero.Margin = new Padding(2, 5, 2, 5);
            txtnumero.Name = "txtnumero";
            txtnumero.ReadOnly = true;
            txtnumero.Size = new Size(130, 27);
            txtnumero.TabIndex = 103;
            // 
            // txtprecio
            // 
            txtprecio.Location = new Point(433, 326);
            txtprecio.Margin = new Padding(2, 5, 2, 5);
            txtprecio.Name = "txtprecio";
            txtprecio.ReadOnly = true;
            txtprecio.Size = new Size(120, 27);
            txtprecio.TabIndex = 113;
            // 
            // txtcantidad
            // 
            txtcantidad.Location = new Point(697, 368);
            txtcantidad.Margin = new Padding(2, 5, 2, 5);
            txtcantidad.Name = "txtcantidad";
            txtcantidad.Size = new Size(120, 27);
            txtcantidad.TabIndex = 104;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Calisto MT", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.Black;
            label9.Location = new Point(298, 34);
            label9.Margin = new Padding(2, 0, 2, 0);
            label9.Name = "label9";
            label9.Size = new Size(94, 20);
            label9.TabIndex = 135;
            label9.Text = "Buscar por:";
            // 
            // comboBox5
            // 
            comboBox5.FormattingEnabled = true;
            comboBox5.Items.AddRange(new object[] { "Teléfono", "Nombre del cliente" });
            comboBox5.Location = new Point(326, 65);
            comboBox5.Margin = new Padding(2, 5, 2, 5);
            comboBox5.Name = "comboBox5";
            comboBox5.Size = new Size(156, 28);
            comboBox5.TabIndex = 134;
            // 
            // pictureBox6
            // 
            pictureBox6.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            pictureBox6.Image = (Image)resources.GetObject("pictureBox6.Image");
            pictureBox6.Location = new Point(1168, 826);
            pictureBox6.Margin = new Padding(2);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(30, 42);
            pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox6.TabIndex = 133;
            pictureBox6.TabStop = false;
            // 
            // pictureBox5
            // 
            pictureBox5.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            pictureBox5.Image = (Image)resources.GetObject("pictureBox5.Image");
            pictureBox5.Location = new Point(1168, 781);
            pictureBox5.Margin = new Padding(2);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(30, 42);
            pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox5.TabIndex = 132;
            pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(1168, 733);
            pictureBox4.Margin = new Padding(2);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(30, 42);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 131;
            pictureBox4.TabStop = false;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Calisto MT", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label13.ForeColor = Color.Black;
            label13.Location = new Point(569, 276);
            label13.Margin = new Padding(2, 0, 2, 0);
            label13.Name = "label13";
            label13.Size = new Size(88, 20);
            label13.TabIndex = 129;
            label13.Text = "Categoría:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Calisto MT", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.ForeColor = Color.Black;
            label12.Location = new Point(349, 276);
            label12.Margin = new Padding(2, 0, 2, 0);
            label12.Name = "label12";
            label12.Size = new Size(63, 20);
            label12.TabIndex = 127;
            label12.Text = "Marca:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Calisto MT", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.ForeColor = Color.Black;
            label11.Location = new Point(11, 322);
            label11.Margin = new Padding(2, 0, 2, 0);
            label11.Name = "label11";
            label11.Size = new Size(70, 20);
            label11.TabIndex = 126;
            label11.Text = "Código:";
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(16, 40);
            pictureBox3.Margin = new Padding(2);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(90, 98);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 123;
            pictureBox3.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Calisto MT", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(118, 108);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(155, 20);
            label2.TabIndex = 96;
            label2.Text = "Nombre del cliente: ";
            // 
            // button4
            // 
            button4.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button4.BackColor = Color.FromArgb(3, 171, 229);
            button4.Cursor = Cursors.Hand;
            button4.FlatStyle = FlatStyle.Popup;
            button4.Font = new Font("Calisto MT", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button4.ForeColor = Color.Black;
            button4.Location = new Point(1198, 826);
            button4.Margin = new Padding(2, 5, 2, 5);
            button4.Name = "button4";
            button4.Size = new Size(104, 40);
            button4.TabIndex = 108;
            button4.Text = "Salir ";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click_1;
            // 
            // btnnuevo
            // 
            btnnuevo.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnnuevo.BackColor = Color.FromArgb(3, 171, 229);
            btnnuevo.Cursor = Cursors.Hand;
            btnnuevo.FlatStyle = FlatStyle.Popup;
            btnnuevo.Font = new Font("Calisto MT", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnnuevo.ForeColor = Color.Black;
            btnnuevo.Location = new Point(1198, 781);
            btnnuevo.Margin = new Padding(2, 5, 2, 5);
            btnnuevo.Name = "btnnuevo";
            btnnuevo.Size = new Size(104, 42);
            btnnuevo.TabIndex = 118;
            btnnuevo.Text = "Nuevo";
            btnnuevo.UseVisualStyleBackColor = false;
            // 
            // btnguardar
            // 
            btnguardar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnguardar.BackColor = Color.FromArgb(3, 171, 229);
            btnguardar.Cursor = Cursors.Hand;
            btnguardar.FlatStyle = FlatStyle.Popup;
            btnguardar.Font = new Font("Calisto MT", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnguardar.ForeColor = Color.Black;
            btnguardar.Location = new Point(1198, 733);
            btnguardar.Margin = new Padding(2, 5, 2, 5);
            btnguardar.Name = "btnguardar";
            btnguardar.Size = new Size(104, 42);
            btnguardar.TabIndex = 120;
            btnguardar.Text = "Guardar";
            btnguardar.UseVisualStyleBackColor = false;
            btnguardar.Click += btnguardar_Click_1;
            // 
            // Busquedacliente
            // 
            Busquedacliente.Image = Properties.Resources.busque_un_simbolo_de_interfaz_de_persona_de_una_lupa_en_forma_de_hombre;
            Busquedacliente.Location = new Point(843, 42);
            Busquedacliente.Margin = new Padding(2);
            Busquedacliente.Name = "Busquedacliente";
            Busquedacliente.Size = new Size(42, 50);
            Busquedacliente.SizeMode = PictureBoxSizeMode.StretchImage;
            Busquedacliente.TabIndex = 121;
            Busquedacliente.TabStop = false;
            Busquedacliente.Click += Busquedacliente_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Calisto MT", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(14, 157);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(116, 20);
            label1.TabIndex = 95;
            label1.Text = "N° de Factura:";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Font = new Font("Calisto MT", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.Black;
            label6.Location = new Point(1163, 611);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new Size(85, 22);
            label6.TabIndex = 99;
            label6.Text = "Cambio:";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Calisto MT", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(901, 70);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(68, 22);
            label3.TabIndex = 117;
            label3.Text = "Fecha:";
            // 
            // dgmostrar
            // 
            dgmostrar.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgmostrar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgmostrar.BackgroundColor = Color.FromArgb(238, 238, 238);
            dgmostrar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgmostrar.Columns.AddRange(new DataGridViewColumn[] { CodigoProducto, Modelo, Categoria, Marca, Precio, Cantidad, Subtotal, eliminar });
            dgmostrar.GridColor = Color.Black;
            dgmostrar.Location = new Point(12, 425);
            dgmostrar.Margin = new Padding(2, 5, 2, 5);
            dgmostrar.Name = "dgmostrar";
            dgmostrar.RowHeadersWidth = 51;
            dgmostrar.RowTemplate.Height = 24;
            dgmostrar.Size = new Size(1122, 442);
            dgmostrar.TabIndex = 105;
            // 
            // CodigoProducto
            // 
            CodigoProducto.FillWeight = 72.30135F;
            CodigoProducto.HeaderText = "Código";
            CodigoProducto.MinimumWidth = 8;
            CodigoProducto.Name = "CodigoProducto";
            // 
            // Modelo
            // 
            Modelo.HeaderText = "Producto";
            Modelo.MinimumWidth = 8;
            Modelo.Name = "Modelo";
            // 
            // Categoria
            // 
            Categoria.HeaderText = "Categoría";
            Categoria.MinimumWidth = 6;
            Categoria.Name = "Categoria";
            // 
            // Marca
            // 
            Marca.HeaderText = "Marca";
            Marca.MinimumWidth = 6;
            Marca.Name = "Marca";
            // 
            // Precio
            // 
            Precio.HeaderText = "Precio";
            Precio.MinimumWidth = 8;
            Precio.Name = "Precio";
            // 
            // Cantidad
            // 
            Cantidad.HeaderText = "Cantidad";
            Cantidad.MinimumWidth = 8;
            Cantidad.Name = "Cantidad";
            // 
            // Subtotal
            // 
            Subtotal.HeaderText = "Subtotal";
            Subtotal.MinimumWidth = 8;
            Subtotal.Name = "Subtotal";
            // 
            // eliminar
            // 
            eliminar.HeaderText = "Eliminar";
            eliminar.MinimumWidth = 8;
            eliminar.Name = "eliminar";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Font = new Font("Calisto MT", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.Black;
            label5.Location = new Point(1163, 425);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(135, 22);
            label5.TabIndex = 98;
            label5.Text = "Total a pagar:";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Calisto MT", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label15.ForeColor = Color.Black;
            label15.Location = new Point(349, 327);
            label15.Margin = new Padding(2, 0, 2, 0);
            label15.Name = "label15";
            label15.Size = new Size(63, 20);
            label15.TabIndex = 112;
            label15.Text = "Precio:";
            // 
            // btncancelar
            // 
            btncancelar.BackColor = Color.FromArgb(3, 171, 229);
            btncancelar.Cursor = Cursors.Hand;
            btncancelar.FlatAppearance.BorderColor = Color.Black;
            btncancelar.FlatAppearance.BorderSize = 2;
            btncancelar.FlatStyle = FlatStyle.Popup;
            btncancelar.Font = new Font("Calisto MT", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btncancelar.ForeColor = Color.Black;
            btncancelar.Location = new Point(446, 366);
            btncancelar.Margin = new Padding(2, 5, 2, 5);
            btncancelar.Name = "btncancelar";
            btncancelar.Size = new Size(106, 42);
            btncancelar.TabIndex = 107;
            btncancelar.Text = "Cancelar";
            btncancelar.UseVisualStyleBackColor = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Calisto MT", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.Black;
            label7.Location = new Point(11, 276);
            label7.Margin = new Padding(2, 0, 2, 0);
            label7.Name = "label7";
            label7.Size = new Size(83, 20);
            label7.TabIndex = 100;
            label7.Text = "Producto:";
            // 
            // btnagregar
            // 
            btnagregar.BackColor = Color.FromArgb(3, 171, 229);
            btnagregar.Cursor = Cursors.Hand;
            btnagregar.FlatAppearance.BorderColor = Color.Black;
            btnagregar.FlatAppearance.BorderSize = 2;
            btnagregar.FlatStyle = FlatStyle.Popup;
            btnagregar.Font = new Font("Calisto MT", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnagregar.ForeColor = Color.Black;
            btnagregar.Location = new Point(337, 366);
            btnagregar.Margin = new Padding(2, 5, 2, 5);
            btnagregar.Name = "btnagregar";
            btnagregar.Size = new Size(106, 42);
            btnagregar.TabIndex = 106;
            btnagregar.Text = "Agregar ";
            btnagregar.TextImageRelation = TextImageRelation.TextAboveImage;
            btnagregar.UseVisualStyleBackColor = false;
            btnagregar.Click += btnagregar_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Calisto MT", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.Black;
            label8.Location = new Point(568, 368);
            label8.Margin = new Padding(2, 0, 2, 0);
            label8.Name = "label8";
            label8.Size = new Size(83, 20);
            label8.TabIndex = 101;
            label8.Text = "Cantidad:";
            // 
            // CBproductos
            // 
            CBproductos.FormattingEnabled = true;
            CBproductos.Location = new Point(730, 225);
            CBproductos.Margin = new Padding(2, 3, 2, 3);
            CBproductos.Name = "CBproductos";
            CBproductos.Size = new Size(172, 28);
            CBproductos.TabIndex = 150;
            // 
            // CBmarcas
            // 
            CBmarcas.FormattingEnabled = true;
            CBmarcas.Location = new Point(425, 225);
            CBmarcas.Margin = new Padding(2, 3, 2, 3);
            CBmarcas.Name = "CBmarcas";
            CBmarcas.Size = new Size(172, 28);
            CBmarcas.TabIndex = 151;
            // 
            // CBcategorias
            // 
            CBcategorias.FormattingEnabled = true;
            CBcategorias.Location = new Point(118, 225);
            CBcategorias.Margin = new Padding(2, 3, 2, 3);
            CBcategorias.Name = "CBcategorias";
            CBcategorias.Size = new Size(172, 28);
            CBcategorias.TabIndex = 152;
            // 
            // txtproducto
            // 
            txtproducto.Location = new Point(121, 273);
            txtproducto.Margin = new Padding(2, 5, 2, 5);
            txtproducto.Name = "txtproducto";
            txtproducto.ReadOnly = true;
            txtproducto.Size = new Size(172, 27);
            txtproducto.TabIndex = 153;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("Calisto MT", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label19.ForeColor = Color.Black;
            label19.Location = new Point(625, 228);
            label19.Margin = new Padding(2, 0, 2, 0);
            label19.Name = "label19";
            label19.Size = new Size(83, 20);
            label19.TabIndex = 154;
            label19.Text = "Producto:";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Font = new Font("Calisto MT", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label20.ForeColor = Color.Black;
            label20.Location = new Point(348, 228);
            label20.Margin = new Padding(2, 0, 2, 0);
            label20.Name = "label20";
            label20.Size = new Size(63, 20);
            label20.TabIndex = 155;
            label20.Text = "Marca:";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Font = new Font("Calisto MT", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label21.ForeColor = Color.Black;
            label21.Location = new Point(17, 228);
            label21.Margin = new Padding(2, 0, 2, 0);
            label21.Name = "label21";
            label21.Size = new Size(88, 20);
            label21.TabIndex = 156;
            label21.Text = "Categoría:";
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Font = new Font("Calisto MT", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label22.ForeColor = Color.Black;
            label22.Location = new Point(11, 190);
            label22.Margin = new Padding(2, 0, 2, 0);
            label22.Name = "label22";
            label22.Size = new Size(135, 20);
            label22.TabIndex = 158;
            label22.Text = "Buscar producto:";
            // 
            // lbltelefonocliente
            // 
            lbltelefonocliente.AutoSize = true;
            lbltelefonocliente.Font = new Font("Calisto MT", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbltelefonocliente.ForeColor = Color.Black;
            lbltelefonocliente.Location = new Point(782, 111);
            lbltelefonocliente.Margin = new Padding(2, 0, 2, 0);
            lbltelefonocliente.Name = "lbltelefonocliente";
            lbltelefonocliente.Size = new Size(84, 20);
            lbltelefonocliente.TabIndex = 159;
            lbltelefonocliente.Text = "Telefono: ";
            // 
            // lblcliente
            // 
            lblcliente.Location = new Point(870, 108);
            lblcliente.Margin = new Padding(2, 5, 2, 5);
            lblcliente.Name = "lblcliente";
            lblcliente.ReadOnly = true;
            lblcliente.Size = new Size(121, 27);
            lblcliente.TabIndex = 160;
            // 
            // Factura
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(238, 238, 238);
            ClientSize = new Size(1314, 882);
            Controls.Add(lblcliente);
            Controls.Add(lbltelefonocliente);
            Controls.Add(label22);
            Controls.Add(label21);
            Controls.Add(label20);
            Controls.Add(label19);
            Controls.Add(txtproducto);
            Controls.Add(CBcategorias);
            Controls.Add(CBmarcas);
            Controls.Add(CBproductos);
            Controls.Add(txtfaltante);
            Controls.Add(dateTimePicker1);
            Controls.Add(label18);
            Controls.Add(txtstock);
            Controls.Add(txtpago);
            Controls.Add(label14);
            Controls.Add(label16);
            Controls.Add(label17);
            Controls.Add(radioButton2);
            Controls.Add(radioButton1);
            Controls.Add(textBox22);
            Controls.Add(label45);
            Controls.Add(checkBox1);
            Controls.Add(txtbuscarcliente);
            Controls.Add(txtcategoria);
            Controls.Add(txtmarca);
            Controls.Add(txtcodigoproducto);
            Controls.Add(txtcambio);
            Controls.Add(txtnombrecliente);
            Controls.Add(txttotal);
            Controls.Add(txtnumero);
            Controls.Add(txtprecio);
            Controls.Add(txtcantidad);
            Controls.Add(label9);
            Controls.Add(comboBox5);
            Controls.Add(pictureBox6);
            Controls.Add(pictureBox5);
            Controls.Add(pictureBox4);
            Controls.Add(label13);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(pictureBox3);
            Controls.Add(label2);
            Controls.Add(button4);
            Controls.Add(btnnuevo);
            Controls.Add(btnguardar);
            Controls.Add(Busquedacliente);
            Controls.Add(label1);
            Controls.Add(label6);
            Controls.Add(label3);
            Controls.Add(dgmostrar);
            Controls.Add(label5);
            Controls.Add(label15);
            Controls.Add(btncancelar);
            Controls.Add(label7);
            Controls.Add(btnagregar);
            Controls.Add(label8);
            Controls.Add(label10);
            ForeColor = Color.Black;
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(2, 5, 2, 5);
            Name = "Factura";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Factura";
            Load += Factura_Load;
            ((System.ComponentModel.ISupportInitialize)fechafactura).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)Busquedacliente).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgmostrar).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ErrorProvider fechafactura;
        
        private System.Windows.Forms.Timer facturafecha;
        private System.Windows.Forms.TextBox txtfaltante;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtstock;
        private System.Windows.Forms.TextBox txtpago;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.TextBox textBox22;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox txtbuscarcliente;
        private System.Windows.Forms.TextBox txtcategoria;
        private System.Windows.Forms.TextBox txtmarca;
        private System.Windows.Forms.TextBox txtcodigoproducto;
        private System.Windows.Forms.TextBox txtcambio;
        private System.Windows.Forms.TextBox txtnombrecliente;
        private System.Windows.Forms.TextBox txttotal;
        private System.Windows.Forms.TextBox txtnumero;
        private System.Windows.Forms.TextBox txtprecio;
        private System.Windows.Forms.TextBox txtcantidad;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBox5;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btnnuevo;
        private System.Windows.Forms.Button btnguardar;
        private System.Windows.Forms.PictureBox Busquedacliente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgmostrar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btncancelar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnagregar;
        private System.Windows.Forms.Label label8;
        private Label label21;
        private Label label20;
        private Label label19;
        private TextBox txtproducto;
        private ComboBox CBcategorias;
        private ComboBox CBmarcas;
        private ComboBox CBproductos;
        private Label label22;
        private TextBox lblcliente;
        private Label lbltelefonocliente;
        private DataGridViewTextBoxColumn CodigoProducto;
        private DataGridViewTextBoxColumn Modelo;
        private DataGridViewTextBoxColumn Categoria;
        private DataGridViewTextBoxColumn Marca;
        private DataGridViewTextBoxColumn Precio;
        private DataGridViewTextBoxColumn Cantidad;
        private DataGridViewTextBoxColumn Subtotal;
        private DataGridViewTextBoxColumn eliminar;
    }
}