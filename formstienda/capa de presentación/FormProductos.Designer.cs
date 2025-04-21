
namespace formstienda
{
    partial class FormProductos
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
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            label14 = new Label();
            comboBox9 = new ComboBox();
            label13 = new Label();
            comboBox5 = new ComboBox();
            label10 = new Label();
            label21 = new Label();
            comboBox4 = new ComboBox();
            comboBox6 = new ComboBox();
            button12 = new Button();
            DGPRODUCTOS = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            Columm6 = new DataGridViewTextBoxColumn();
            Column6 = new DataGridViewTextBoxColumn();
            Column7 = new DataGridViewTextBoxColumn();
            button2 = new Button();
            button1 = new Button();
            comboBox3 = new ComboBox();
            label9 = new Label();
            textBox5 = new TextBox();
            label8 = new Label();
            textBox4 = new TextBox();
            label7 = new Label();
            textBox3 = new TextBox();
            label6 = new Label();
            comboBox2 = new ComboBox();
            label5 = new Label();
            comboBox1 = new ComboBox();
            label4 = new Label();
            label3 = new Label();
            textBox1 = new TextBox();
            label2 = new Label();
            label1 = new Label();
            tabPage2 = new TabPage();
            cbcategoria = new ComboBox();
            button11 = new Button();
            DGCATEGORIA = new DataGridView();
            button4 = new Button();
            btnguardacarac = new Button();
            label12 = new Label();
            label11 = new Label();
            tabPage3 = new TabPage();
            cbmarca = new ComboBox();
            button10 = new Button();
            DGMARCA = new DataGridView();
            button5 = new Button();
            btnguardarmarca = new Button();
            label15 = new Label();
            label16 = new Label();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DGPRODUCTOS).BeginInit();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DGCATEGORIA).BeginInit();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DGMARCA).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.CausesValidation = false;
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Font = new Font("Calisto MT", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tabControl1.Location = new Point(-2, 51);
            tabControl1.Margin = new Padding(2);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1394, 816);
            tabControl1.TabIndex = 0;
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(label14);
            tabPage1.Controls.Add(comboBox9);
            tabPage1.Controls.Add(label13);
            tabPage1.Controls.Add(comboBox5);
            tabPage1.Controls.Add(label10);
            tabPage1.Controls.Add(label21);
            tabPage1.Controls.Add(comboBox4);
            tabPage1.Controls.Add(comboBox6);
            tabPage1.Controls.Add(button12);
            tabPage1.Controls.Add(DGPRODUCTOS);
            tabPage1.Controls.Add(button2);
            tabPage1.Controls.Add(button1);
            tabPage1.Controls.Add(comboBox3);
            tabPage1.Controls.Add(label9);
            tabPage1.Controls.Add(textBox5);
            tabPage1.Controls.Add(label8);
            tabPage1.Controls.Add(textBox4);
            tabPage1.Controls.Add(label7);
            tabPage1.Controls.Add(textBox3);
            tabPage1.Controls.Add(label6);
            tabPage1.Controls.Add(comboBox2);
            tabPage1.Controls.Add(label5);
            tabPage1.Controls.Add(comboBox1);
            tabPage1.Controls.Add(label4);
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(textBox1);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(label1);
            tabPage1.Location = new Point(4, 31);
            tabPage1.Margin = new Padding(2);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(2);
            tabPage1.Size = new Size(1386, 781);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Productos";
            tabPage1.UseVisualStyleBackColor = true;
            tabPage1.Click += tabPage1_Click;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Calisto MT", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label14.Location = new Point(18, 191);
            label14.Margin = new Padding(2, 0, 2, 0);
            label14.Name = "label14";
            label14.Size = new Size(165, 22);
            label14.TabIndex = 162;
            label14.Text = "Buscar producto:";
            // 
            // comboBox9
            // 
            comboBox9.FormattingEnabled = true;
            comboBox9.Location = new Point(115, 216);
            comboBox9.Margin = new Padding(2, 3, 2, 3);
            comboBox9.Name = "comboBox9";
            comboBox9.Size = new Size(172, 30);
            comboBox9.TabIndex = 161;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Calisto MT", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label13.ForeColor = Color.Black;
            label13.Location = new Point(18, 221);
            label13.Margin = new Padding(2, 0, 2, 0);
            label13.Name = "label13";
            label13.Size = new Size(83, 20);
            label13.TabIndex = 160;
            label13.Text = "Producto:";
            // 
            // comboBox5
            // 
            comboBox5.FormattingEnabled = true;
            comboBox5.Location = new Point(392, 216);
            comboBox5.Margin = new Padding(2, 3, 2, 3);
            comboBox5.Name = "comboBox5";
            comboBox5.Size = new Size(172, 30);
            comboBox5.TabIndex = 159;
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.Top;
            label10.AutoSize = true;
            label10.Font = new Font("Calisto MT", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(314, 221);
            label10.Margin = new Padding(2, 0, 2, 0);
            label10.Name = "label10";
            label10.Size = new Size(63, 20);
            label10.TabIndex = 158;
            label10.Text = "Marca:";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Font = new Font("Calisto MT", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label21.ForeColor = Color.Black;
            label21.Location = new Point(589, 221);
            label21.Margin = new Padding(2, 0, 2, 0);
            label21.Name = "label21";
            label21.Size = new Size(88, 20);
            label21.TabIndex = 157;
            label21.Text = "Categoría:";
            // 
            // comboBox4
            // 
            comboBox4.FormattingEnabled = true;
            comboBox4.Location = new Point(696, 216);
            comboBox4.Margin = new Padding(2, 3, 2, 3);
            comboBox4.Name = "comboBox4";
            comboBox4.Size = new Size(172, 30);
            comboBox4.TabIndex = 153;
            // 
            // comboBox6
            // 
            comboBox6.Anchor = AnchorStyles.Top;
            comboBox6.FormattingEnabled = true;
            comboBox6.Location = new Point(242, 70);
            comboBox6.Margin = new Padding(2);
            comboBox6.Name = "comboBox6";
            comboBox6.Size = new Size(206, 30);
            comboBox6.TabIndex = 40;
            // 
            // button12
            // 
            button12.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button12.BackColor = Color.FromArgb(3, 171, 229);
            button12.FlatStyle = FlatStyle.Popup;
            button12.Location = new Point(1238, 716);
            button12.Margin = new Padding(2);
            button12.Name = "button12";
            button12.Size = new Size(126, 46);
            button12.TabIndex = 39;
            button12.Text = "Salir";
            button12.UseVisualStyleBackColor = false;
            button12.Click += button12_Click;
            // 
            // DGPRODUCTOS
            // 
            DGPRODUCTOS.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DGPRODUCTOS.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DGPRODUCTOS.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGPRODUCTOS.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4, Column5, Columm6, Column6, Column7 });
            DGPRODUCTOS.Location = new Point(18, 257);
            DGPRODUCTOS.Margin = new Padding(2);
            DGPRODUCTOS.Name = "DGPRODUCTOS";
            DGPRODUCTOS.RowHeadersWidth = 51;
            DGPRODUCTOS.RowTemplate.Height = 24;
            DGPRODUCTOS.ScrollBars = ScrollBars.None;
            DGPRODUCTOS.Size = new Size(1256, 413);
            DGPRODUCTOS.TabIndex = 19;
            DGPRODUCTOS.CellContentClick += dataGridView1_CellContentClick;
            // 
            // Column1
            // 
            Column1.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Column1.FillWeight = 96.25668F;
            Column1.HeaderText = "Código";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            Column1.Width = 160;
            // 
            // Column2
            // 
            Column2.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Column2.FillWeight = 299.9042F;
            Column2.HeaderText = "Nombre del Producto";
            Column2.MinimumWidth = 6;
            Column2.Name = "Column2";
            Column2.Width = 300;
            // 
            // Column3
            // 
            Column3.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Column3.FillWeight = 71.97699F;
            Column3.HeaderText = "Categoría";
            Column3.MinimumWidth = 6;
            Column3.Name = "Column3";
            Column3.Width = 150;
            // 
            // Column4
            // 
            Column4.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Column4.FillWeight = 71.97699F;
            Column4.HeaderText = "Marca";
            Column4.MinimumWidth = 6;
            Column4.Name = "Column4";
            Column4.Width = 150;
            // 
            // Column5
            // 
            Column5.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Column5.FillWeight = 71.97699F;
            Column5.HeaderText = "Stock Actual";
            Column5.MinimumWidth = 6;
            Column5.Name = "Column5";
            Column5.Width = 95;
            // 
            // Columm6
            // 
            Columm6.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Columm6.FillWeight = 71.97699F;
            Columm6.HeaderText = "Stock Mínimo";
            Columm6.MinimumWidth = 6;
            Columm6.Name = "Columm6";
            Columm6.Width = 150;
            // 
            // Column6
            // 
            Column6.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Column6.FillWeight = 71.97699F;
            Column6.HeaderText = "Precio de Venta";
            Column6.MinimumWidth = 6;
            Column6.Name = "Column6";
            Column6.Width = 150;
            // 
            // Column7
            // 
            Column7.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Column7.FillWeight = 71.97699F;
            Column7.HeaderText = "Estado";
            Column7.MinimumWidth = 6;
            Column7.Name = "Column7";
            Column7.Width = 110;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Top;
            button2.BackColor = Color.FromArgb(3, 171, 229);
            button2.Font = new Font("Calisto MT", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(1238, 151);
            button2.Margin = new Padding(2);
            button2.Name = "button2";
            button2.Size = new Size(126, 55);
            button2.TabIndex = 18;
            button2.Text = "Cancelar";
            button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top;
            button1.BackColor = Color.FromArgb(3, 171, 229);
            button1.Font = new Font("Calisto MT", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(1094, 152);
            button1.Margin = new Padding(2);
            button1.Name = "button1";
            button1.Size = new Size(126, 54);
            button1.TabIndex = 17;
            button1.Text = "Guardar";
            button1.UseVisualStyleBackColor = false;
            // 
            // comboBox3
            // 
            comboBox3.Anchor = AnchorStyles.Top;
            comboBox3.FormattingEnabled = true;
            comboBox3.Items.AddRange(new object[] { "Activo", "Inactivo" });
            comboBox3.Location = new Point(938, 133);
            comboBox3.Margin = new Padding(2);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(114, 30);
            comboBox3.TabIndex = 16;
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Top;
            label9.AutoSize = true;
            label9.Font = new Font("Calisto MT", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(843, 134);
            label9.Margin = new Padding(2, 0, 2, 0);
            label9.Name = "label9";
            label9.Size = new Size(66, 20);
            label9.TabIndex = 15;
            label9.Text = "Estado:";
            // 
            // textBox5
            // 
            textBox5.Anchor = AnchorStyles.Top;
            textBox5.Location = new Point(702, 136);
            textBox5.Margin = new Padding(2);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(110, 31);
            textBox5.TabIndex = 14;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Top;
            label8.AutoSize = true;
            label8.Font = new Font("Calisto MT", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(525, 138);
            label8.Margin = new Padding(2, 0, 2, 0);
            label8.Name = "label8";
            label8.Size = new Size(131, 20);
            label8.TabIndex = 13;
            label8.Text = "Precio de Venta:";
            // 
            // textBox4
            // 
            textBox4.Anchor = AnchorStyles.Top;
            textBox4.Location = new Point(418, 130);
            textBox4.Margin = new Padding(2);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(74, 31);
            textBox4.TabIndex = 12;
            textBox4.TextChanged += textBox4_TextChanged;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top;
            label7.AutoSize = true;
            label7.Font = new Font("Calisto MT", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(262, 134);
            label7.Margin = new Padding(2, 0, 2, 0);
            label7.Name = "label7";
            label7.Size = new Size(119, 20);
            label7.TabIndex = 11;
            label7.Text = "Stock Mínimo:";
            // 
            // textBox3
            // 
            textBox3.Anchor = AnchorStyles.Top;
            textBox3.Location = new Point(173, 131);
            textBox3.Margin = new Padding(2);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(74, 31);
            textBox3.TabIndex = 10;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Calisto MT", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(14, 134);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new Size(108, 20);
            label6.TabIndex = 9;
            label6.Text = "Stock Actual:";
            // 
            // comboBox2
            // 
            comboBox2.Anchor = AnchorStyles.Top;
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(1172, 76);
            comboBox2.Margin = new Padding(2);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(142, 30);
            comboBox2.TabIndex = 8;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top;
            label5.AutoSize = true;
            label5.Font = new Font("Calisto MT", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(1084, 80);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(63, 20);
            label5.TabIndex = 7;
            label5.Text = "Marca:";
            // 
            // comboBox1
            // 
            comboBox1.Anchor = AnchorStyles.Top;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(938, 70);
            comboBox1.Margin = new Padding(2);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(114, 30);
            comboBox1.TabIndex = 6;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top;
            label4.AutoSize = true;
            label4.Font = new Font("Calisto MT", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(786, 76);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(88, 20);
            label4.TabIndex = 5;
            label4.Text = "Categoría:";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top;
            label3.AutoSize = true;
            label3.Font = new Font("Calisto MT", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(18, 76);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(172, 20);
            label3.TabIndex = 3;
            label3.Text = "Nombre del Producto:";
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Top;
            textBox1.Location = new Point(583, 70);
            textBox1.Margin = new Padding(2);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(118, 31);
            textBox1.TabIndex = 2;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top;
            label2.AutoSize = true;
            label2.Font = new Font("Calisto MT", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(475, 81);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(70, 20);
            label2.TabIndex = 1;
            label2.Text = "Código:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Calisto MT", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(10, 22);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(165, 22);
            label1.TabIndex = 0;
            label1.Text = "Nuevo Producto:";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(cbcategoria);
            tabPage2.Controls.Add(button11);
            tabPage2.Controls.Add(DGCATEGORIA);
            tabPage2.Controls.Add(button4);
            tabPage2.Controls.Add(btnguardacarac);
            tabPage2.Controls.Add(label12);
            tabPage2.Controls.Add(label11);
            tabPage2.Location = new Point(4, 31);
            tabPage2.Margin = new Padding(2);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(2);
            tabPage2.Size = new Size(1386, 781);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Categoría";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // cbcategoria
            // 
            cbcategoria.FormattingEnabled = true;
            cbcategoria.Location = new Point(242, 66);
            cbcategoria.Margin = new Padding(2);
            cbcategoria.Name = "cbcategoria";
            cbcategoria.Size = new Size(298, 30);
            cbcategoria.TabIndex = 40;
            // 
            // button11
            // 
            button11.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button11.BackColor = Color.FromArgb(3, 171, 229);
            button11.FlatStyle = FlatStyle.Popup;
            button11.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button11.Location = new Point(14, 705);
            button11.Margin = new Padding(2);
            button11.Name = "button11";
            button11.Size = new Size(110, 57);
            button11.TabIndex = 39;
            button11.Text = "Salir";
            button11.UseVisualStyleBackColor = false;
            button11.Click += button11_Click;
            // 
            // DGCATEGORIA
            // 
            DGCATEGORIA.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DGCATEGORIA.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DGCATEGORIA.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGCATEGORIA.Location = new Point(14, 182);
            DGCATEGORIA.Margin = new Padding(2);
            DGCATEGORIA.Name = "DGCATEGORIA";
            DGCATEGORIA.RowHeadersWidth = 51;
            DGCATEGORIA.RowTemplate.Height = 24;
            DGCATEGORIA.Size = new Size(1282, 526);
            DGCATEGORIA.TabIndex = 20;
            DGCATEGORIA.CellContentClick += DGCATEGORIA_CellContentClick;
            DGCATEGORIA.CellEndEdit += DGCATEGORIA_CellEndEdit;
            // 
            // button4
            // 
            button4.BackColor = Color.FromArgb(3, 171, 229);
            button4.Font = new Font("Calisto MT", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button4.Location = new Point(739, 65);
            button4.Margin = new Padding(2);
            button4.Name = "button4";
            button4.Size = new Size(112, 62);
            button4.TabIndex = 19;
            button4.Text = "Cancelar";
            button4.UseVisualStyleBackColor = false;
            // 
            // btnguardacarac
            // 
            btnguardacarac.BackColor = Color.FromArgb(3, 171, 229);
            btnguardacarac.Font = new Font("Calisto MT", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnguardacarac.Location = new Point(585, 65);
            btnguardacarac.Margin = new Padding(2);
            btnguardacarac.Name = "btnguardacarac";
            btnguardacarac.Size = new Size(110, 62);
            btnguardacarac.TabIndex = 18;
            btnguardacarac.Text = "Guardar";
            btnguardacarac.UseVisualStyleBackColor = false;
            btnguardacarac.Click += btnguardacarac_Click;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Calisto MT", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.Location = new Point(10, 71);
            label12.Margin = new Padding(2, 0, 2, 0);
            label12.Name = "label12";
            label12.Size = new Size(173, 20);
            label12.TabIndex = 2;
            label12.Text = "Nombre de Categoría:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Calisto MT", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.Location = new Point(10, 20);
            label11.Margin = new Padding(2, 0, 2, 0);
            label11.Name = "label11";
            label11.Size = new Size(172, 22);
            label11.TabIndex = 1;
            label11.Text = "Nueva Categoría:";
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(cbmarca);
            tabPage3.Controls.Add(button10);
            tabPage3.Controls.Add(DGMARCA);
            tabPage3.Controls.Add(button5);
            tabPage3.Controls.Add(btnguardarmarca);
            tabPage3.Controls.Add(label15);
            tabPage3.Controls.Add(label16);
            tabPage3.Location = new Point(4, 31);
            tabPage3.Margin = new Padding(2);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(1386, 781);
            tabPage3.TabIndex = 3;
            tabPage3.Text = "Marcas";
            tabPage3.UseVisualStyleBackColor = true;
            tabPage3.UseWaitCursor = true;
            // 
            // cbmarca
            // 
            cbmarca.FormattingEnabled = true;
            cbmarca.Location = new Point(226, 63);
            cbmarca.Margin = new Padding(2);
            cbmarca.Name = "cbmarca";
            cbmarca.Size = new Size(282, 30);
            cbmarca.TabIndex = 40;
            cbmarca.UseWaitCursor = true;
            // 
            // button10
            // 
            button10.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button10.BackColor = Color.FromArgb(3, 171, 229);
            button10.FlatStyle = FlatStyle.Popup;
            button10.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button10.Location = new Point(14, 704);
            button10.Margin = new Padding(2);
            button10.Name = "button10";
            button10.Size = new Size(103, 57);
            button10.TabIndex = 39;
            button10.Text = "Salir";
            button10.UseVisualStyleBackColor = false;
            button10.UseWaitCursor = true;
            button10.Click += button10_Click;
            // 
            // DGMARCA
            // 
            DGMARCA.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DGMARCA.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DGMARCA.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGMARCA.Location = new Point(14, 182);
            DGMARCA.Margin = new Padding(2);
            DGMARCA.Name = "DGMARCA";
            DGMARCA.RowHeadersWidth = 51;
            DGMARCA.RowTemplate.Height = 24;
            DGMARCA.Size = new Size(1282, 535);
            DGMARCA.TabIndex = 28;
            DGMARCA.UseWaitCursor = true;
            DGMARCA.CellEndEdit += DGMARCA_CellEndEdit;
            // 
            // button5
            // 
            button5.BackColor = Color.FromArgb(3, 171, 229);
            button5.Font = new Font("Calisto MT", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button5.Location = new Point(750, 63);
            button5.Margin = new Padding(2);
            button5.Name = "button5";
            button5.Size = new Size(130, 57);
            button5.TabIndex = 27;
            button5.Text = "Cancelar";
            button5.UseVisualStyleBackColor = false;
            button5.UseWaitCursor = true;
            // 
            // btnguardarmarca
            // 
            btnguardarmarca.BackColor = Color.FromArgb(3, 171, 229);
            btnguardarmarca.Font = new Font("Calisto MT", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnguardarmarca.Location = new Point(590, 63);
            btnguardarmarca.Margin = new Padding(2);
            btnguardarmarca.Name = "btnguardarmarca";
            btnguardarmarca.Size = new Size(125, 57);
            btnguardarmarca.TabIndex = 26;
            btnguardarmarca.Text = "Guardar";
            btnguardarmarca.UseVisualStyleBackColor = false;
            btnguardarmarca.UseWaitCursor = true;
            btnguardarmarca.Click += btnguardarmarca_Click_1;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Calisto MT", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label15.Location = new Point(10, 69);
            label15.Margin = new Padding(2, 0, 2, 0);
            label15.Name = "label15";
            label15.Size = new Size(148, 20);
            label15.TabIndex = 24;
            label15.Text = "Nombre de Marca:";
            label15.UseWaitCursor = true;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label16.Location = new Point(10, 20);
            label16.Margin = new Padding(2, 0, 2, 0);
            label16.Name = "label16";
            label16.Size = new Size(147, 25);
            label16.TabIndex = 23;
            label16.Text = "Nueva Marca:";
            label16.UseWaitCursor = true;
            // 
            // FormProductos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(238, 238, 238);
            ClientSize = new Size(1401, 882);
            Controls.Add(tabControl1);
            ForeColor = Color.Black;
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(2);
            Name = "FormProductos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Productos";
            Load += FormProductos_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DGPRODUCTOS).EndInit();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DGCATEGORIA).EndInit();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DGMARCA).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView DGPRODUCTOS;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnguardacarac;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridView DGCATEGORIA;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DataGridView DGMARCA;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button btnguardarmarca;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.ComboBox comboBox6;
        private System.Windows.Forms.ComboBox cbcategoria;
        private System.Windows.Forms.ComboBox cbmarca;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columm6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private ComboBox comboBox4;
        private Label label21;
        private ComboBox comboBox9;
        private Label label13;
        private ComboBox comboBox5;
        private Label label10;
        private Label label14;
    }
}