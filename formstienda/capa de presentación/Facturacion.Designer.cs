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
            textBox1 = new TextBox();
            txtpago = new TextBox();
            label14 = new Label();
            label16 = new Label();
            label17 = new Label();
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            textBox22 = new TextBox();
            label45 = new Label();
            checkBox1 = new CheckBox();
            textBox5 = new TextBox();
            txtcat = new TextBox();
            txtmarca = new TextBox();
            txtcodigo = new TextBox();
            txtcambio = new TextBox();
            txtnombrecliente = new TextBox();
            txtsaldo = new TextBox();
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
            pictureBox1 = new PictureBox();
            label1 = new Label();
            label6 = new Label();
            label4 = new Label();
            label3 = new Label();
            dgmostrar = new DataGridView();
            cliente = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            Column6 = new DataGridViewTextBoxColumn();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            eliminar = new DataGridViewTextBoxColumn();
            label5 = new Label();
            label15 = new Label();
            btncancelar = new Button();
            label7 = new Label();
            btnagregar = new Button();
            label8 = new Label();
            comboBox2 = new ComboBox();
            comboBox3 = new ComboBox();
            comboBox4 = new ComboBox();
            textBox2 = new TextBox();
            label19 = new Label();
            label20 = new Label();
            label21 = new Label();
            button1 = new Button();
            label22 = new Label();
            ((System.ComponentModel.ISupportInitialize)fechafactura).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgmostrar).BeginInit();
            SuspendLayout();
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(735, 302);
            label10.Margin = new Padding(2, 0, 2, 0);
            label10.Name = "label10";
            label10.Size = new Size(0, 25);
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
            txtfaltante.Location = new Point(1461, 648);
            txtfaltante.Margin = new Padding(2, 6, 2, 6);
            txtfaltante.Name = "txtfaltante";
            txtfaltante.Size = new Size(166, 31);
            txtfaltante.TabIndex = 124;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dateTimePicker1.Location = new Point(1298, 88);
            dateTimePicker1.Margin = new Padding(2, 6, 2, 6);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(312, 31);
            dateTimePicker1.TabIndex = 148;
            // 
            // label18
            // 
            label18.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label18.AutoSize = true;
            label18.Font = new Font("Calisto MT", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label18.ForeColor = Color.Black;
            label18.Location = new Point(1461, 609);
            label18.Margin = new Padding(2, 0, 2, 0);
            label18.Name = "label18";
            label18.Size = new Size(72, 22);
            label18.TabIndex = 122;
            label18.Text = "Dólar:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(880, 325);
            textBox1.Margin = new Padding(2, 6, 2, 6);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(149, 31);
            textBox1.TabIndex = 147;
            // 
            // txtpago
            // 
            txtpago.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            txtpago.Location = new Point(1461, 555);
            txtpago.Margin = new Padding(2, 6, 2, 6);
            txtpago.Name = "txtpago";
            txtpago.Size = new Size(166, 31);
            txtpago.TabIndex = 115;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Calisto MT", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label14.ForeColor = Color.Black;
            label14.Location = new Point(715, 329);
            label14.Margin = new Padding(2, 0, 2, 0);
            label14.Name = "label14";
            label14.Size = new Size(127, 22);
            label14.TabIndex = 146;
            label14.Text = "Stock actual:";
            // 
            // label16
            // 
            label16.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label16.AutoSize = true;
            label16.Font = new Font("Calisto MT", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label16.ForeColor = Color.Black;
            label16.Location = new Point(1459, 512);
            label16.Margin = new Padding(2, 0, 2, 0);
            label16.Name = "label16";
            label16.Size = new Size(97, 22);
            label16.TabIndex = 114;
            label16.Text = "Córdoba:";
            // 
            // label17
            // 
            label17.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label17.AutoSize = true;
            label17.Font = new Font("Calisto MT", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label17.ForeColor = Color.Black;
            label17.Location = new Point(1099, 288);
            label17.Margin = new Padding(2, 0, 2, 0);
            label17.Name = "label17";
            label17.Size = new Size(153, 22);
            label17.TabIndex = 119;
            label17.Text = "Forma de pago:";
            // 
            // radioButton2
            // 
            radioButton2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            radioButton2.AutoSize = true;
            radioButton2.Font = new Font("Calisto MT", 10F, FontStyle.Bold);
            radioButton2.ForeColor = Color.Black;
            radioButton2.Location = new Point(1253, 329);
            radioButton2.Margin = new Padding(2, 4, 2, 4);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(104, 26);
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
            radioButton1.Location = new Point(1108, 329);
            radioButton1.Margin = new Padding(2, 4, 2, 4);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(113, 26);
            radioButton1.TabIndex = 144;
            radioButton1.TabStop = true;
            radioButton1.Text = "Contado";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // textBox22
            // 
            textBox22.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            textBox22.Location = new Point(1249, 372);
            textBox22.Margin = new Padding(2, 6, 2, 6);
            textBox22.Name = "textBox22";
            textBox22.Size = new Size(282, 31);
            textBox22.TabIndex = 143;
            // 
            // label45
            // 
            label45.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label45.AutoSize = true;
            label45.Font = new Font("Calisto MT", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label45.ForeColor = Color.Black;
            label45.Location = new Point(1099, 376);
            label45.Margin = new Padding(2, 0, 2, 0);
            label45.Name = "label45";
            label45.Size = new Size(141, 22);
            label45.TabIndex = 142;
            label45.Text = "Colillas INSS:";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.ForeColor = Color.Black;
            checkBox1.Location = new Point(152, 92);
            checkBox1.Margin = new Padding(2);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(112, 29);
            checkBox1.TabIndex = 139;
            checkBox1.Text = "Genérico ";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(538, 81);
            textBox5.Margin = new Padding(2, 6, 2, 6);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(402, 31);
            textBox5.TabIndex = 136;
            // 
            // txtcat
            // 
            txtcat.Location = new Point(880, 261);
            txtcat.Margin = new Padding(2, 6, 2, 6);
            txtcat.Name = "txtcat";
            txtcat.ReadOnly = true;
            txtcat.Size = new Size(149, 31);
            txtcat.TabIndex = 130;
            // 
            // txtmarca
            // 
            txtmarca.Location = new Point(550, 261);
            txtmarca.Margin = new Padding(2, 6, 2, 6);
            txtmarca.Name = "txtmarca";
            txtmarca.ReadOnly = true;
            txtmarca.Size = new Size(149, 31);
            txtmarca.TabIndex = 128;
            // 
            // txtcodigo
            // 
            txtcodigo.Location = new Point(160, 319);
            txtcodigo.Margin = new Padding(2, 6, 2, 6);
            txtcodigo.Name = "txtcodigo";
            txtcodigo.Size = new Size(214, 31);
            txtcodigo.TabIndex = 125;
            // 
            // txtcambio
            // 
            txtcambio.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            txtcambio.Location = new Point(1461, 796);
            txtcambio.Margin = new Padding(2, 6, 2, 6);
            txtcambio.Name = "txtcambio";
            txtcambio.ReadOnly = true;
            txtcambio.Size = new Size(166, 31);
            txtcambio.TabIndex = 111;
            // 
            // txtnombrecliente
            // 
            txtnombrecliente.Location = new Point(405, 135);
            txtnombrecliente.Margin = new Padding(2, 6, 2, 6);
            txtnombrecliente.Name = "txtnombrecliente";
            txtnombrecliente.ReadOnly = true;
            txtnombrecliente.Size = new Size(536, 31);
            txtnombrecliente.TabIndex = 102;
            // 
            // txtsaldo
            // 
            txtsaldo.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            txtsaldo.Location = new Point(1461, 726);
            txtsaldo.Margin = new Padding(2, 6, 2, 6);
            txtsaldo.Name = "txtsaldo";
            txtsaldo.ReadOnly = true;
            txtsaldo.Size = new Size(166, 31);
            txtsaldo.TabIndex = 110;
            // 
            // txttotal
            // 
            txttotal.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            txttotal.Location = new Point(1461, 472);
            txttotal.Margin = new Padding(2, 6, 2, 6);
            txttotal.Name = "txttotal";
            txttotal.ReadOnly = true;
            txttotal.Size = new Size(166, 31);
            txttotal.TabIndex = 109;
            // 
            // txtnumero
            // 
            txtnumero.Location = new Point(210, 194);
            txtnumero.Margin = new Padding(2, 6, 2, 6);
            txtnumero.Name = "txtnumero";
            txtnumero.ReadOnly = true;
            txtnumero.Size = new Size(162, 31);
            txtnumero.TabIndex = 103;
            // 
            // txtprecio
            // 
            txtprecio.Location = new Point(550, 324);
            txtprecio.Margin = new Padding(2, 6, 2, 6);
            txtprecio.Name = "txtprecio";
            txtprecio.ReadOnly = true;
            txtprecio.Size = new Size(149, 31);
            txtprecio.TabIndex = 113;
            // 
            // txtcantidad
            // 
            txtcantidad.Location = new Point(880, 376);
            txtcantidad.Margin = new Padding(2, 6, 2, 6);
            txtcantidad.Name = "txtcantidad";
            txtcantidad.Size = new Size(149, 31);
            txtcantidad.TabIndex = 104;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Calisto MT", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.Black;
            label9.Location = new Point(372, 42);
            label9.Margin = new Padding(2, 0, 2, 0);
            label9.Name = "label9";
            label9.Size = new Size(116, 22);
            label9.TabIndex = 135;
            label9.Text = "Buscar por:";
            // 
            // comboBox5
            // 
            comboBox5.FormattingEnabled = true;
            comboBox5.Items.AddRange(new object[] { "Teléfono", "Nombre del cliente" });
            comboBox5.Location = new Point(408, 81);
            comboBox5.Margin = new Padding(2, 6, 2, 6);
            comboBox5.Name = "comboBox5";
            comboBox5.Size = new Size(112, 33);
            comboBox5.TabIndex = 134;
            // 
            // pictureBox6
            // 
            pictureBox6.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            pictureBox6.Image = (Image)resources.GetObject("pictureBox6.Image");
            pictureBox6.Location = new Point(1460, 1032);
            pictureBox6.Margin = new Padding(2);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(38, 52);
            pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox6.TabIndex = 133;
            pictureBox6.TabStop = false;
            // 
            // pictureBox5
            // 
            pictureBox5.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            pictureBox5.Image = (Image)resources.GetObject("pictureBox5.Image");
            pictureBox5.Location = new Point(1460, 976);
            pictureBox5.Margin = new Padding(2);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(38, 52);
            pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox5.TabIndex = 132;
            pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(1460, 916);
            pictureBox4.Margin = new Padding(2);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(38, 52);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 131;
            pictureBox4.TabStop = false;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Calisto MT", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label13.ForeColor = Color.Black;
            label13.Location = new Point(720, 261);
            label13.Margin = new Padding(2, 0, 2, 0);
            label13.Name = "label13";
            label13.Size = new Size(108, 22);
            label13.TabIndex = 129;
            label13.Text = "Categoría:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Calisto MT", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.ForeColor = Color.Black;
            label12.Location = new Point(445, 261);
            label12.Margin = new Padding(2, 0, 2, 0);
            label12.Name = "label12";
            label12.Size = new Size(76, 22);
            label12.TabIndex = 127;
            label12.Text = "Marca:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Calisto MT", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.ForeColor = Color.Black;
            label11.Location = new Point(22, 319);
            label11.Margin = new Padding(2, 0, 2, 0);
            label11.Name = "label11";
            label11.Size = new Size(83, 22);
            label11.TabIndex = 126;
            label11.Text = "Código:";
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(20, 50);
            pictureBox3.Margin = new Padding(2);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(112, 122);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 123;
            pictureBox3.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Calisto MT", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(148, 135);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(196, 22);
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
            button4.Location = new Point(1498, 1032);
            button4.Margin = new Padding(2, 6, 2, 6);
            button4.Name = "button4";
            button4.Size = new Size(130, 50);
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
            btnnuevo.Location = new Point(1498, 976);
            btnnuevo.Margin = new Padding(2, 6, 2, 6);
            btnnuevo.Name = "btnnuevo";
            btnnuevo.Size = new Size(130, 52);
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
            btnguardar.Location = new Point(1498, 916);
            btnguardar.Margin = new Padding(2, 6, 2, 6);
            btnguardar.Name = "btnguardar";
            btnguardar.Size = new Size(130, 52);
            btnguardar.TabIndex = 120;
            btnguardar.Text = "Guardar";
            btnguardar.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.busque_un_simbolo_de_interfaz_de_persona_de_una_lupa_en_forma_de_hombre;
            pictureBox1.Location = new Point(945, 70);
            pictureBox1.Margin = new Padding(2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(52, 62);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 121;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Calisto MT", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(18, 196);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(141, 22);
            label1.TabIndex = 95;
            label1.Text = "N° de Factura:";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Font = new Font("Calisto MT", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.Black;
            label6.Location = new Point(1454, 764);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new Size(99, 26);
            label6.TabIndex = 99;
            label6.Text = "Cambio:";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Calisto MT", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(1461, 689);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(78, 26);
            label4.TabIndex = 97;
            label4.Text = "Saldo:";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Calisto MT", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(1198, 88);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(81, 26);
            label3.TabIndex = 117;
            label3.Text = "Fecha:";
            // 
            // dgmostrar
            // 
            dgmostrar.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgmostrar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgmostrar.BackgroundColor = Color.FromArgb(238, 238, 238);
            dgmostrar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgmostrar.Columns.AddRange(new DataGridViewColumn[] { cliente, Column4, Column5, Column6, Column1, Column2, Column3, eliminar });
            dgmostrar.GridColor = Color.FromArgb(238, 238, 238);
            dgmostrar.Location = new Point(15, 531);
            dgmostrar.Margin = new Padding(2, 6, 2, 6);
            dgmostrar.Name = "dgmostrar";
            dgmostrar.RowHeadersWidth = 51;
            dgmostrar.RowTemplate.Height = 24;
            dgmostrar.Size = new Size(1402, 552);
            dgmostrar.TabIndex = 105;
            // 
            // cliente
            // 
            cliente.FillWeight = 72.30135F;
            cliente.HeaderText = "Código";
            cliente.MinimumWidth = 8;
            cliente.Name = "cliente";
            // 
            // Column4
            // 
            Column4.HeaderText = "Producto";
            Column4.MinimumWidth = 8;
            Column4.Name = "Column4";
            // 
            // Column5
            // 
            Column5.HeaderText = "Categoría";
            Column5.MinimumWidth = 6;
            Column5.Name = "Column5";
            // 
            // Column6
            // 
            Column6.HeaderText = "Marca";
            Column6.MinimumWidth = 6;
            Column6.Name = "Column6";
            // 
            // Column1
            // 
            Column1.HeaderText = "Precio";
            Column1.MinimumWidth = 8;
            Column1.Name = "Column1";
            // 
            // Column2
            // 
            Column2.HeaderText = "Cantidad";
            Column2.MinimumWidth = 8;
            Column2.Name = "Column2";
            // 
            // Column3
            // 
            Column3.HeaderText = "Subtotal";
            Column3.MinimumWidth = 8;
            Column3.Name = "Column3";
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
            label5.Location = new Point(1459, 428);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(156, 26);
            label5.TabIndex = 98;
            label5.Text = "Total a pagar:";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Calisto MT", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label15.ForeColor = Color.Black;
            label15.Location = new Point(445, 325);
            label15.Margin = new Padding(2, 0, 2, 0);
            label15.Name = "label15";
            label15.Size = new Size(77, 22);
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
            btncancelar.Location = new Point(566, 374);
            btncancelar.Margin = new Padding(2, 6, 2, 6);
            btncancelar.Name = "btncancelar";
            btncancelar.Size = new Size(132, 52);
            btncancelar.TabIndex = 107;
            btncancelar.Text = "Cancelar";
            btncancelar.UseVisualStyleBackColor = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Calisto MT", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.Black;
            label7.Location = new Point(22, 261);
            label7.Margin = new Padding(2, 0, 2, 0);
            label7.Name = "label7";
            label7.Size = new Size(100, 22);
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
            btnagregar.Location = new Point(430, 374);
            btnagregar.Margin = new Padding(2, 6, 2, 6);
            btnagregar.Name = "btnagregar";
            btnagregar.Size = new Size(132, 52);
            btnagregar.TabIndex = 106;
            btnagregar.Text = "Agregar ";
            btnagregar.TextImageRelation = TextImageRelation.TextAboveImage;
            btnagregar.UseVisualStyleBackColor = false;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Calisto MT", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.Black;
            label8.Location = new Point(719, 376);
            label8.Margin = new Padding(2, 0, 2, 0);
            label8.Name = "label8";
            label8.Size = new Size(99, 22);
            label8.TabIndex = 101;
            label8.Text = "Cantidad:";
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(160, 459);
            comboBox2.Margin = new Padding(2, 4, 2, 4);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(214, 33);
            comboBox2.TabIndex = 150;
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(538, 459);
            comboBox3.Margin = new Padding(2, 4, 2, 4);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(214, 33);
            comboBox3.TabIndex = 151;
            // 
            // comboBox4
            // 
            comboBox4.FormattingEnabled = true;
            comboBox4.Location = new Point(956, 455);
            comboBox4.Margin = new Padding(2, 4, 2, 4);
            comboBox4.Name = "comboBox4";
            comboBox4.Size = new Size(214, 33);
            comboBox4.TabIndex = 152;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(160, 258);
            textBox2.Margin = new Padding(2, 6, 2, 6);
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new Size(214, 31);
            textBox2.TabIndex = 153;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("Calisto MT", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label19.ForeColor = Color.Black;
            label19.Location = new Point(29, 462);
            label19.Margin = new Padding(2, 0, 2, 0);
            label19.Name = "label19";
            label19.Size = new Size(100, 22);
            label19.TabIndex = 154;
            label19.Text = "Producto:";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Font = new Font("Calisto MT", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label20.ForeColor = Color.Black;
            label20.Location = new Point(441, 462);
            label20.Margin = new Padding(2, 0, 2, 0);
            label20.Name = "label20";
            label20.Size = new Size(76, 22);
            label20.TabIndex = 155;
            label20.Text = "Marca:";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Font = new Font("Calisto MT", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label21.ForeColor = Color.Black;
            label21.Location = new Point(830, 459);
            label21.Margin = new Padding(2, 0, 2, 0);
            label21.Name = "label21";
            label21.Size = new Size(108, 22);
            label21.TabIndex = 156;
            label21.Text = "Categoría:";
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button1.BackColor = Color.FromArgb(3, 171, 229);
            button1.Cursor = Cursors.Hand;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("Calisto MT", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.Black;
            button1.Location = new Point(1498, 851);
            button1.Margin = new Padding(2, 6, 2, 6);
            button1.Name = "button1";
            button1.Size = new Size(130, 52);
            button1.TabIndex = 157;
            button1.Text = "Pagar";
            button1.UseVisualStyleBackColor = false;
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Font = new Font("Calisto MT", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label22.ForeColor = Color.Black;
            label22.Location = new Point(22, 400);
            label22.Margin = new Padding(2, 0, 2, 0);
            label22.Name = "label22";
            label22.Size = new Size(165, 22);
            label22.TabIndex = 158;
            label22.Text = "Buscar producto:";
            // 
            // Factura
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(238, 238, 238);
            ClientSize = new Size(1642, 1102);
            Controls.Add(label22);
            Controls.Add(button1);
            Controls.Add(label21);
            Controls.Add(label20);
            Controls.Add(label19);
            Controls.Add(textBox2);
            Controls.Add(comboBox4);
            Controls.Add(comboBox3);
            Controls.Add(comboBox2);
            Controls.Add(txtfaltante);
            Controls.Add(dateTimePicker1);
            Controls.Add(label18);
            Controls.Add(textBox1);
            Controls.Add(txtpago);
            Controls.Add(label14);
            Controls.Add(label16);
            Controls.Add(label17);
            Controls.Add(radioButton2);
            Controls.Add(radioButton1);
            Controls.Add(textBox22);
            Controls.Add(label45);
            Controls.Add(checkBox1);
            Controls.Add(textBox5);
            Controls.Add(txtcat);
            Controls.Add(txtmarca);
            Controls.Add(txtcodigo);
            Controls.Add(txtcambio);
            Controls.Add(txtnombrecliente);
            Controls.Add(txtsaldo);
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
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            Controls.Add(label6);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(dgmostrar);
            Controls.Add(label5);
            Controls.Add(label15);
            Controls.Add(btncancelar);
            Controls.Add(label7);
            Controls.Add(btnagregar);
            Controls.Add(label8);
            Controls.Add(label10);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(2, 6, 2, 6);
            Name = "Factura";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Factura";
            Load += Factura_Load;
            ((System.ComponentModel.ISupportInitialize)fechafactura).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
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
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox txtpago;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.TextBox textBox22;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox txtcat;
        private System.Windows.Forms.TextBox txtmarca;
        private System.Windows.Forms.TextBox txtcodigo;
        private System.Windows.Forms.TextBox txtcambio;
        private System.Windows.Forms.TextBox txtnombrecliente;
        private System.Windows.Forms.TextBox txtsaldo;
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
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgmostrar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btncancelar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnagregar;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridViewTextBoxColumn cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn eliminar;
        private Label label21;
        private Label label20;
        private Label label19;
        private TextBox textBox2;
        private ComboBox comboBox4;
        private ComboBox comboBox3;
        private ComboBox comboBox2;
        private Button button1;
        private Label label22;
    }
}