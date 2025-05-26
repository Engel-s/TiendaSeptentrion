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
            lbldolares = new Label();
            txtstock = new TextBox();
            txtpago = new TextBox();
            label14 = new Label();
            lblcordoba = new Label();
            label17 = new Label();
            rbcredito = new RadioButton();
            rbcontado = new RadioButton();
            txtcolillainss = new TextBox();
            lblcolillainss = new Label();
            GENERICOCHECK = new CheckBox();
            txtbuscarcliente = new TextBox();
            txtcategoria = new TextBox();
            txtmarca = new TextBox();
            txtcodigoproducto = new TextBox();
            txtcambio = new TextBox();
            txtnombrecliente = new TextBox();
            txttotal = new TextBox();
            txtnumerofactura = new TextBox();
            txtprecio = new TextBox();
            txtcantidad = new TextBox();
            label9 = new Label();
            CBBUSCARPOR = new ComboBox();
            pictureBox6 = new PictureBox();
            pictureBox5 = new PictureBox();
            pictureBox4 = new PictureBox();
            label13 = new Label();
            label12 = new Label();
            label11 = new Label();
            pictureBox3 = new PictureBox();
            lblnombre = new Label();
            button4 = new Button();
            btnnuevo = new Button();
            btnguardar = new Button();
            Busquedacliente = new PictureBox();
            label1 = new Label();
            lblcambio = new Label();
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
            lblcedula = new Label();
            txtcedula = new TextBox();
            lblinteres = new Label();
            txtinteresparaloscreditos = new TextBox();
            lblnumeroplazos = new Label();
            cbnumerodeplazos = new ComboBox();
            btnagregarnuevocliente = new Button();
            LBLTELEFONODELNUEVOCLIENTE = new Label();
            TXTTELEFONODELNUEVOCLIENTE = new TextBox();
            lbldireccion = new Label();
            txtdireccion = new TextBox();
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
            txtfaltante.Location = new Point(1159, 612);
            txtfaltante.Margin = new Padding(2, 5, 2, 5);
            txtfaltante.Name = "txtfaltante";
            txtfaltante.Size = new Size(134, 27);
            txtfaltante.TabIndex = 124;
            txtfaltante.TextChanged += txtfaltante_TextChanged;
            txtfaltante.KeyDown += txtfaltante_KeyDown;
            txtfaltante.KeyPress += txtfaltante_KeyPress;
            txtfaltante.KeyUp += txtfaltante_KeyUp;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dateTimePicker1.Location = new Point(992, 65);
            dateTimePicker1.Margin = new Padding(2, 5, 2, 5);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(296, 27);
            dateTimePicker1.TabIndex = 148;
            // 
            // lbldolares
            // 
            lbldolares.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lbldolares.AutoSize = true;
            lbldolares.Font = new Font("Calisto MT", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbldolares.ForeColor = Color.Black;
            lbldolares.Location = new Point(1159, 587);
            lbldolares.Margin = new Padding(2, 0, 2, 0);
            lbldolares.Name = "lbldolares";
            lbldolares.Size = new Size(58, 20);
            lbldolares.TabIndex = 122;
            lbldolares.Text = "Dólar:";
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
            txtpago.Location = new Point(1159, 555);
            txtpago.Margin = new Padding(2, 5, 2, 5);
            txtpago.Name = "txtpago";
            txtpago.Size = new Size(134, 27);
            txtpago.TabIndex = 115;
            txtpago.TextChanged += txtpago_TextChanged;
            txtpago.KeyDown += txtpago_KeyDown;
            txtpago.KeyPress += txtpago_KeyPress;
            txtpago.KeyUp += txtpago_KeyUp;
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
            // lblcordoba
            // 
            lblcordoba.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblcordoba.AutoSize = true;
            lblcordoba.Font = new Font("Calisto MT", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblcordoba.ForeColor = Color.Black;
            lblcordoba.Location = new Point(1157, 530);
            lblcordoba.Margin = new Padding(2, 0, 2, 0);
            lblcordoba.Name = "lblcordoba";
            lblcordoba.Size = new Size(81, 20);
            lblcordoba.TabIndex = 114;
            lblcordoba.Text = "Córdoba:";
            // 
            // label17
            // 
            label17.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label17.AutoSize = true;
            label17.Font = new Font("Calisto MT", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label17.ForeColor = Color.Black;
            label17.Location = new Point(970, 225);
            label17.Margin = new Padding(2, 0, 2, 0);
            label17.Name = "label17";
            label17.Size = new Size(125, 20);
            label17.TabIndex = 119;
            label17.Text = "Forma de pago:";
            // 
            // rbcredito
            // 
            rbcredito.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            rbcredito.AutoSize = true;
            rbcredito.Font = new Font("Calisto MT", 10F, FontStyle.Bold);
            rbcredito.ForeColor = Color.Black;
            rbcredito.Location = new Point(1100, 276);
            rbcredito.Margin = new Padding(2, 3, 2, 3);
            rbcredito.Name = "rbcredito";
            rbcredito.Size = new Size(86, 24);
            rbcredito.TabIndex = 145;
            rbcredito.TabStop = true;
            rbcredito.Text = "Crédito";
            rbcredito.UseVisualStyleBackColor = true;
            rbcredito.CheckedChanged += rbcredito_CheckedChanged;
            // 
            // rbcontado
            // 
            rbcontado.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            rbcontado.AutoSize = true;
            rbcontado.Font = new Font("Calisto MT", 10F, FontStyle.Bold);
            rbcontado.ForeColor = Color.Black;
            rbcontado.Location = new Point(970, 276);
            rbcontado.Margin = new Padding(2, 3, 2, 3);
            rbcontado.Name = "rbcontado";
            rbcontado.Size = new Size(95, 24);
            rbcontado.TabIndex = 144;
            rbcontado.TabStop = true;
            rbcontado.Text = "Contado";
            rbcontado.UseVisualStyleBackColor = true;
            rbcontado.CheckedChanged += rbcontado_CheckedChanged;
            // 
            // txtcolillainss
            // 
            txtcolillainss.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtcolillainss.Location = new Point(1030, 310);
            txtcolillainss.Margin = new Padding(2, 5, 2, 5);
            txtcolillainss.Name = "txtcolillainss";
            txtcolillainss.ReadOnly = true;
            txtcolillainss.Size = new Size(188, 27);
            txtcolillainss.TabIndex = 143;
            // 
            // lblcolillainss
            // 
            lblcolillainss.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblcolillainss.AutoSize = true;
            lblcolillainss.Font = new Font("Calisto MT", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblcolillainss.ForeColor = Color.Black;
            lblcolillainss.Location = new Point(901, 313);
            lblcolillainss.Margin = new Padding(2, 0, 2, 0);
            lblcolillainss.Name = "lblcolillainss";
            lblcolillainss.Size = new Size(112, 20);
            lblcolillainss.TabIndex = 142;
            lblcolillainss.Text = "Colillas INSS:";
            // 
            // GENERICOCHECK
            // 
            GENERICOCHECK.AutoSize = true;
            GENERICOCHECK.ForeColor = Color.Black;
            GENERICOCHECK.Location = new Point(122, 74);
            GENERICOCHECK.Margin = new Padding(2);
            GENERICOCHECK.Name = "GENERICOCHECK";
            GENERICOCHECK.Size = new Size(94, 24);
            GENERICOCHECK.TabIndex = 139;
            GENERICOCHECK.Text = "Genérico ";
            GENERICOCHECK.UseVisualStyleBackColor = true;
            GENERICOCHECK.CheckedChanged += GENERICOCHECK_CheckedChanged;
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
            txtcambio.Location = new Point(1158, 680);
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
            txttotal.Location = new Point(1157, 498);
            txttotal.Margin = new Padding(2, 5, 2, 5);
            txttotal.Name = "txttotal";
            txttotal.ReadOnly = true;
            txttotal.Size = new Size(134, 27);
            txttotal.TabIndex = 109;
            // 
            // txtnumerofactura
            // 
            txtnumerofactura.Location = new Point(168, 155);
            txtnumerofactura.Margin = new Padding(2, 5, 2, 5);
            txtnumerofactura.Name = "txtnumerofactura";
            txtnumerofactura.ReadOnly = true;
            txtnumerofactura.Size = new Size(130, 27);
            txtnumerofactura.TabIndex = 103;
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
            // CBBUSCARPOR
            // 
            CBBUSCARPOR.FormattingEnabled = true;
            CBBUSCARPOR.Items.AddRange(new object[] { "Cédula", "Telefono" });
            CBBUSCARPOR.Location = new Point(326, 65);
            CBBUSCARPOR.Margin = new Padding(2, 5, 2, 5);
            CBBUSCARPOR.Name = "CBBUSCARPOR";
            CBBUSCARPOR.Size = new Size(156, 28);
            CBBUSCARPOR.TabIndex = 134;
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
            // lblnombre
            // 
            lblnombre.AutoSize = true;
            lblnombre.Font = new Font("Calisto MT", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblnombre.ForeColor = Color.Black;
            lblnombre.Location = new Point(118, 108);
            lblnombre.Margin = new Padding(2, 0, 2, 0);
            lblnombre.Name = "lblnombre";
            lblnombre.Size = new Size(155, 20);
            lblnombre.TabIndex = 96;
            lblnombre.Text = "Nombre del cliente: ";
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
            btnguardar.Click += btnguardar_Click;
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
            // lblcambio
            // 
            lblcambio.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblcambio.AutoSize = true;
            lblcambio.Font = new Font("Calisto MT", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblcambio.ForeColor = Color.Black;
            lblcambio.Location = new Point(1153, 653);
            lblcambio.Margin = new Padding(2, 0, 2, 0);
            lblcambio.Name = "lblcambio";
            lblcambio.Size = new Size(85, 22);
            lblcambio.TabIndex = 99;
            lblcambio.Text = "Cambio:";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Calisto MT", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(901, 65);
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
            label5.Location = new Point(1153, 467);
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
            // lblcedula
            // 
            lblcedula.AutoSize = true;
            lblcedula.Font = new Font("Calisto MT", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblcedula.ForeColor = Color.Black;
            lblcedula.Location = new Point(782, 111);
            lblcedula.Margin = new Padding(2, 0, 2, 0);
            lblcedula.Name = "lblcedula";
            lblcedula.Size = new Size(65, 20);
            lblcedula.TabIndex = 159;
            lblcedula.Text = "Cédula ";
            // 
            // txtcedula
            // 
            txtcedula.Location = new Point(870, 108);
            txtcedula.Margin = new Padding(2, 5, 2, 5);
            txtcedula.Name = "txtcedula";
            txtcedula.Size = new Size(176, 27);
            txtcedula.TabIndex = 160;
            // 
            // lblinteres
            // 
            lblinteres.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblinteres.AutoSize = true;
            lblinteres.Font = new Font("Calisto MT", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblinteres.ForeColor = Color.Black;
            lblinteres.Location = new Point(861, 347);
            lblinteres.Margin = new Padding(2, 0, 2, 0);
            lblinteres.Name = "lblinteres";
            lblinteres.Size = new Size(156, 20);
            lblinteres.TabIndex = 161;
            lblinteres.Text = "Interés para crédito:";
            // 
            // txtinteresparaloscreditos
            // 
            txtinteresparaloscreditos.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtinteresparaloscreditos.Location = new Point(1030, 347);
            txtinteresparaloscreditos.Margin = new Padding(2, 5, 2, 5);
            txtinteresparaloscreditos.Name = "txtinteresparaloscreditos";
            txtinteresparaloscreditos.Size = new Size(188, 27);
            txtinteresparaloscreditos.TabIndex = 162;
            // 
            // lblnumeroplazos
            // 
            lblnumeroplazos.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblnumeroplazos.AutoSize = true;
            lblnumeroplazos.Font = new Font("Calisto MT", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblnumeroplazos.ForeColor = Color.Black;
            lblnumeroplazos.Location = new Point(870, 384);
            lblnumeroplazos.Margin = new Padding(2, 0, 2, 0);
            lblnumeroplazos.Name = "lblnumeroplazos";
            lblnumeroplazos.Size = new Size(147, 20);
            lblnumeroplazos.TabIndex = 163;
            lblnumeroplazos.Text = "Número de plazos:";
            // 
            // cbnumerodeplazos
            // 
            cbnumerodeplazos.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cbnumerodeplazos.FormattingEnabled = true;
            cbnumerodeplazos.Items.AddRange(new object[] { "1 MES", "2 MESES", "3 MESES" });
            cbnumerodeplazos.Location = new Point(1030, 384);
            cbnumerodeplazos.Margin = new Padding(2, 5, 2, 5);
            cbnumerodeplazos.Name = "cbnumerodeplazos";
            cbnumerodeplazos.Size = new Size(188, 28);
            cbnumerodeplazos.TabIndex = 164;
            // 
            // btnagregarnuevocliente
            // 
            btnagregarnuevocliente.BackColor = Color.FromArgb(3, 171, 229);
            btnagregarnuevocliente.Cursor = Cursors.Hand;
            btnagregarnuevocliente.FlatAppearance.BorderColor = Color.Black;
            btnagregarnuevocliente.FlatAppearance.BorderSize = 2;
            btnagregarnuevocliente.FlatStyle = FlatStyle.Popup;
            btnagregarnuevocliente.Font = new Font("Calisto MT", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnagregarnuevocliente.ForeColor = Color.Black;
            btnagregarnuevocliente.Location = new Point(1063, 100);
            btnagregarnuevocliente.Margin = new Padding(2, 5, 2, 5);
            btnagregarnuevocliente.Name = "btnagregarnuevocliente";
            btnagregarnuevocliente.Size = new Size(106, 42);
            btnagregarnuevocliente.TabIndex = 165;
            btnagregarnuevocliente.Text = "Nuevo";
            btnagregarnuevocliente.TextImageRelation = TextImageRelation.TextAboveImage;
            btnagregarnuevocliente.UseVisualStyleBackColor = false;
            btnagregarnuevocliente.Click += btnagregarnuevocliente_Click;
            // 
            // LBLTELEFONODELNUEVOCLIENTE
            // 
            LBLTELEFONODELNUEVOCLIENTE.AutoSize = true;
            LBLTELEFONODELNUEVOCLIENTE.Font = new Font("Calisto MT", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LBLTELEFONODELNUEVOCLIENTE.ForeColor = Color.Black;
            LBLTELEFONODELNUEVOCLIENTE.Location = new Point(782, 155);
            LBLTELEFONODELNUEVOCLIENTE.Margin = new Padding(2, 0, 2, 0);
            LBLTELEFONODELNUEVOCLIENTE.Name = "LBLTELEFONODELNUEVOCLIENTE";
            LBLTELEFONODELNUEVOCLIENTE.Size = new Size(74, 20);
            LBLTELEFONODELNUEVOCLIENTE.TabIndex = 166;
            LBLTELEFONODELNUEVOCLIENTE.Text = "Teléfono";
            // 
            // TXTTELEFONODELNUEVOCLIENTE
            // 
            TXTTELEFONODELNUEVOCLIENTE.Location = new Point(870, 148);
            TXTTELEFONODELNUEVOCLIENTE.Margin = new Padding(2, 5, 2, 5);
            TXTTELEFONODELNUEVOCLIENTE.Name = "TXTTELEFONODELNUEVOCLIENTE";
            TXTTELEFONODELNUEVOCLIENTE.ReadOnly = true;
            TXTTELEFONODELNUEVOCLIENTE.Size = new Size(176, 27);
            TXTTELEFONODELNUEVOCLIENTE.TabIndex = 167;
            // 
            // lbldireccion
            // 
            lbldireccion.AutoSize = true;
            lbldireccion.Font = new Font("Calisto MT", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbldireccion.ForeColor = Color.Black;
            lbldireccion.Location = new Point(446, 151);
            lbldireccion.Margin = new Padding(2, 0, 2, 0);
            lbldireccion.Name = "lbldireccion";
            lbldireccion.Size = new Size(88, 20);
            lbldireccion.TabIndex = 168;
            lbldireccion.Text = "Dirección:";
            // 
            // txtdireccion
            // 
            txtdireccion.Location = new Point(541, 148);
            txtdireccion.Margin = new Padding(2, 5, 2, 5);
            txtdireccion.Name = "txtdireccion";
            txtdireccion.ReadOnly = true;
            txtdireccion.Size = new Size(213, 27);
            txtdireccion.TabIndex = 169;
            // 
            // Factura
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(238, 238, 238);
            ClientSize = new Size(1314, 882);
            Controls.Add(txtdireccion);
            Controls.Add(lbldireccion);
            Controls.Add(TXTTELEFONODELNUEVOCLIENTE);
            Controls.Add(LBLTELEFONODELNUEVOCLIENTE);
            Controls.Add(btnagregarnuevocliente);
            Controls.Add(cbnumerodeplazos);
            Controls.Add(lblnumeroplazos);
            Controls.Add(txtinteresparaloscreditos);
            Controls.Add(lblinteres);
            Controls.Add(txtcedula);
            Controls.Add(lblcedula);
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
            Controls.Add(lbldolares);
            Controls.Add(txtstock);
            Controls.Add(txtpago);
            Controls.Add(label14);
            Controls.Add(lblcordoba);
            Controls.Add(label17);
            Controls.Add(rbcredito);
            Controls.Add(rbcontado);
            Controls.Add(txtcolillainss);
            Controls.Add(lblcolillainss);
            Controls.Add(GENERICOCHECK);
            Controls.Add(txtbuscarcliente);
            Controls.Add(txtcategoria);
            Controls.Add(txtmarca);
            Controls.Add(txtcodigoproducto);
            Controls.Add(txtcambio);
            Controls.Add(txtnombrecliente);
            Controls.Add(txttotal);
            Controls.Add(txtnumerofactura);
            Controls.Add(txtprecio);
            Controls.Add(txtcantidad);
            Controls.Add(label9);
            Controls.Add(CBBUSCARPOR);
            Controls.Add(pictureBox6);
            Controls.Add(pictureBox5);
            Controls.Add(pictureBox4);
            Controls.Add(label13);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(pictureBox3);
            Controls.Add(lblnombre);
            Controls.Add(button4);
            Controls.Add(btnnuevo);
            Controls.Add(btnguardar);
            Controls.Add(Busquedacliente);
            Controls.Add(label1);
            Controls.Add(lblcambio);
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
        private System.Windows.Forms.Label lbldolares;
        private System.Windows.Forms.TextBox txtstock;
        private System.Windows.Forms.TextBox txtpago;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblcordoba;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.RadioButton rbcredito;
        private System.Windows.Forms.RadioButton rbcontado;
        private System.Windows.Forms.TextBox txtcolillainss;
        private System.Windows.Forms.Label lblcolillainss;
        private System.Windows.Forms.CheckBox GENERICOCHECK;
        private System.Windows.Forms.TextBox txtbuscarcliente;
        private System.Windows.Forms.TextBox txtcategoria;
        private System.Windows.Forms.TextBox txtmarca;
        private System.Windows.Forms.TextBox txtcodigoproducto;
        private System.Windows.Forms.TextBox txtcambio;
        private System.Windows.Forms.TextBox txtnombrecliente;
        private System.Windows.Forms.TextBox txttotal;
        private System.Windows.Forms.TextBox txtnumerofactura;
        private System.Windows.Forms.TextBox txtprecio;
        private System.Windows.Forms.TextBox txtcantidad;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox CBBUSCARPOR;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label lblnombre;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btnnuevo;
        private System.Windows.Forms.Button btnguardar;
        private System.Windows.Forms.PictureBox Busquedacliente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblcambio;
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
        private TextBox txtcedula;
        private Label lblcedula;
        private DataGridViewTextBoxColumn CodigoProducto;
        private DataGridViewTextBoxColumn Modelo;
        private DataGridViewTextBoxColumn Categoria;
        private DataGridViewTextBoxColumn Marca;
        private DataGridViewTextBoxColumn Precio;
        private DataGridViewTextBoxColumn Cantidad;
        private DataGridViewTextBoxColumn Subtotal;
        private DataGridViewTextBoxColumn eliminar;
        private Label lblnumeroplazos;
        private TextBox txtinteresparaloscreditos;
        private Label lblinteres;
        private ComboBox cbnumerodeplazos;
        private Button btnagregarnuevocliente;
        private TextBox TXTTELEFONODELNUEVOCLIENTE;
        private Label LBLTELEFONODELNUEVOCLIENTE;
        private TextBox txtdireccion;
        private Label lbldireccion;
    }
}