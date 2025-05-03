
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
            txtNombreProduct = new TextBox();
            label14 = new Label();
            comboBox9 = new ComboBox();
            label13 = new Label();
            comboBox5 = new ComboBox();
            label10 = new Label();
            label21 = new Label();
            comboBox4 = new ComboBox();
            btnSalirProductos = new Button();
            DGPRODUCTOS = new DataGridView();
            button2 = new Button();
            button1 = new Button();
            cmbEstado = new ComboBox();
            label9 = new Label();
            txtPrecioVenta = new TextBox();
            label8 = new Label();
            txtStockMinimo = new TextBox();
            label7 = new Label();
            txtStockActual = new TextBox();
            label6 = new Label();
            cmbMarcProduct = new ComboBox();
            label5 = new Label();
            cmbCategoriaProduc = new ComboBox();
            label4 = new Label();
            label3 = new Label();
            txtCodigoProduct = new TextBox();
            label2 = new Label();
            label1 = new Label();
            tabPage2 = new TabPage();
            txtNuevaCategoria = new TextBox();
            btnSalirCategorias = new Button();
            DGCATEGORIAS = new DataGridView();
            btnCancelaCategoria = new Button();
            btnAgregarCategoria = new Button();
            label12 = new Label();
            label11 = new Label();
            tabPage3 = new TabPage();
            txtNuevaMarca = new TextBox();
            btnSalirMarcas = new Button();
            DGMARCAS = new DataGridView();
            btnCancelarMarca = new Button();
            btnGuardarMarca = new Button();
            label15 = new Label();
            label16 = new Label();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DGPRODUCTOS).BeginInit();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DGCATEGORIAS).BeginInit();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DGMARCAS).BeginInit();
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
            tabPage1.Controls.Add(txtNombreProduct);
            tabPage1.Controls.Add(label14);
            tabPage1.Controls.Add(comboBox9);
            tabPage1.Controls.Add(label13);
            tabPage1.Controls.Add(comboBox5);
            tabPage1.Controls.Add(label10);
            tabPage1.Controls.Add(label21);
            tabPage1.Controls.Add(comboBox4);
            tabPage1.Controls.Add(btnSalirProductos);
            tabPage1.Controls.Add(DGPRODUCTOS);
            tabPage1.Controls.Add(button2);
            tabPage1.Controls.Add(button1);
            tabPage1.Controls.Add(cmbEstado);
            tabPage1.Controls.Add(label9);
            tabPage1.Controls.Add(txtPrecioVenta);
            tabPage1.Controls.Add(label8);
            tabPage1.Controls.Add(txtStockMinimo);
            tabPage1.Controls.Add(label7);
            tabPage1.Controls.Add(txtStockActual);
            tabPage1.Controls.Add(label6);
            tabPage1.Controls.Add(cmbMarcProduct);
            tabPage1.Controls.Add(label5);
            tabPage1.Controls.Add(cmbCategoriaProduc);
            tabPage1.Controls.Add(label4);
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(txtCodigoProduct);
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
            // txtNombreProduct
            // 
            txtNombreProduct.Anchor = AnchorStyles.Top;
            txtNombreProduct.Location = new Point(191, 70);
            txtNombreProduct.Margin = new Padding(2);
            txtNombreProduct.Name = "txtNombreProduct";
            txtNombreProduct.Size = new Size(118, 31);
            txtNombreProduct.TabIndex = 163;
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
            // btnSalirProductos
            // 
            btnSalirProductos.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnSalirProductos.BackColor = Color.FromArgb(3, 171, 229);
            btnSalirProductos.FlatStyle = FlatStyle.Popup;
            btnSalirProductos.Location = new Point(1238, 716);
            btnSalirProductos.Margin = new Padding(2);
            btnSalirProductos.Name = "btnSalirProductos";
            btnSalirProductos.Size = new Size(126, 46);
            btnSalirProductos.TabIndex = 39;
            btnSalirProductos.Text = "Salir";
            btnSalirProductos.UseVisualStyleBackColor = false;
            btnSalirProductos.Click += button12_Click;
            // 
            // DGPRODUCTOS
            // 
            DGPRODUCTOS.AllowUserToAddRows = false;
            DGPRODUCTOS.AllowUserToDeleteRows = false;
            DGPRODUCTOS.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DGPRODUCTOS.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DGPRODUCTOS.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGPRODUCTOS.Location = new Point(18, 257);
            DGPRODUCTOS.Margin = new Padding(2);
            DGPRODUCTOS.Name = "DGPRODUCTOS";
            DGPRODUCTOS.ReadOnly = true;
            DGPRODUCTOS.RowHeadersWidth = 51;
            DGPRODUCTOS.RowTemplate.Height = 24;
            DGPRODUCTOS.ScrollBars = ScrollBars.None;
            DGPRODUCTOS.Size = new Size(1253, 413);
            DGPRODUCTOS.TabIndex = 19;
            DGPRODUCTOS.CellContentClick += DGPRODUCTOS_CellContentClick;
            DGPRODUCTOS.CellDoubleClick += DGPRODUCTOS_CellDoubleClick;
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
            button1.Click += button1_Click;
            // 
            // cmbEstado
            // 
            cmbEstado.Anchor = AnchorStyles.Top;
            cmbEstado.FormattingEnabled = true;
            cmbEstado.Items.AddRange(new object[] { "Activo", "Inactivo" });
            cmbEstado.Location = new Point(938, 133);
            cmbEstado.Margin = new Padding(2);
            cmbEstado.Name = "cmbEstado";
            cmbEstado.Size = new Size(114, 30);
            cmbEstado.TabIndex = 16;
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
            // txtPrecioVenta
            // 
            txtPrecioVenta.Anchor = AnchorStyles.Top;
            txtPrecioVenta.Location = new Point(702, 136);
            txtPrecioVenta.Margin = new Padding(2);
            txtPrecioVenta.Name = "txtPrecioVenta";
            txtPrecioVenta.Size = new Size(110, 31);
            txtPrecioVenta.TabIndex = 14;
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
            // txtStockMinimo
            // 
            txtStockMinimo.Anchor = AnchorStyles.Top;
            txtStockMinimo.Location = new Point(392, 129);
            txtStockMinimo.Margin = new Padding(2);
            txtStockMinimo.Name = "txtStockMinimo";
            txtStockMinimo.Size = new Size(110, 31);
            txtStockMinimo.TabIndex = 12;
            txtStockMinimo.TextChanged += textBox4_TextChanged;
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
            // txtStockActual
            // 
            txtStockActual.Anchor = AnchorStyles.Top;
            txtStockActual.Location = new Point(173, 131);
            txtStockActual.Margin = new Padding(2);
            txtStockActual.Name = "txtStockActual";
            txtStockActual.Size = new Size(74, 31);
            txtStockActual.TabIndex = 10;
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
            // cmbMarcProduct
            // 
            cmbMarcProduct.Anchor = AnchorStyles.Top;
            cmbMarcProduct.FormattingEnabled = true;
            cmbMarcProduct.Location = new Point(1151, 75);
            cmbMarcProduct.Margin = new Padding(2);
            cmbMarcProduct.Name = "cmbMarcProduct";
            cmbMarcProduct.Size = new Size(192, 30);
            cmbMarcProduct.TabIndex = 8;
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
            // cmbCategoriaProduc
            // 
            cmbCategoriaProduc.Anchor = AnchorStyles.Top;
            cmbCategoriaProduc.FormattingEnabled = true;
            cmbCategoriaProduc.Location = new Point(875, 70);
            cmbCategoriaProduc.Margin = new Padding(2);
            cmbCategoriaProduc.Name = "cmbCategoriaProduc";
            cmbCategoriaProduc.Size = new Size(177, 30);
            cmbCategoriaProduc.TabIndex = 6;
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
            // txtCodigoProduct
            // 
            txtCodigoProduct.Anchor = AnchorStyles.Top;
            txtCodigoProduct.Location = new Point(583, 70);
            txtCodigoProduct.Margin = new Padding(2);
            txtCodigoProduct.Name = "txtCodigoProduct";
            txtCodigoProduct.Size = new Size(118, 31);
            txtCodigoProduct.TabIndex = 2;
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
            tabPage2.Controls.Add(txtNuevaCategoria);
            tabPage2.Controls.Add(btnSalirCategorias);
            tabPage2.Controls.Add(DGCATEGORIAS);
            tabPage2.Controls.Add(btnCancelaCategoria);
            tabPage2.Controls.Add(btnAgregarCategoria);
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
            // txtNuevaCategoria
            // 
            txtNuevaCategoria.Location = new Point(248, 66);
            txtNuevaCategoria.Margin = new Padding(2);
            txtNuevaCategoria.Name = "txtNuevaCategoria";
            txtNuevaCategoria.Size = new Size(297, 31);
            txtNuevaCategoria.TabIndex = 41;
            // 
            // btnSalirCategorias
            // 
            btnSalirCategorias.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnSalirCategorias.BackColor = Color.FromArgb(3, 171, 229);
            btnSalirCategorias.FlatStyle = FlatStyle.Popup;
            btnSalirCategorias.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSalirCategorias.Location = new Point(14, 705);
            btnSalirCategorias.Margin = new Padding(2);
            btnSalirCategorias.Name = "btnSalirCategorias";
            btnSalirCategorias.Size = new Size(110, 57);
            btnSalirCategorias.TabIndex = 39;
            btnSalirCategorias.Text = "Salir";
            btnSalirCategorias.UseVisualStyleBackColor = false;
            btnSalirCategorias.Click += button11_Click;
            // 
            // DGCATEGORIAS
            // 
            DGCATEGORIAS.AllowUserToAddRows = false;
            DGCATEGORIAS.AllowUserToDeleteRows = false;
            DGCATEGORIAS.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DGCATEGORIAS.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DGCATEGORIAS.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGCATEGORIAS.Location = new Point(14, 182);
            DGCATEGORIAS.Margin = new Padding(2);
            DGCATEGORIAS.Name = "DGCATEGORIAS";
            DGCATEGORIAS.ReadOnly = true;
            DGCATEGORIAS.RowHeadersWidth = 51;
            DGCATEGORIAS.RowTemplate.Height = 24;
            DGCATEGORIAS.Size = new Size(1282, 501);
            DGCATEGORIAS.TabIndex = 20;
            DGCATEGORIAS.CellClick += DGCATEGORIAS_CellClick;
            DGCATEGORIAS.CellDoubleClick += DGCATEGORIAS_CellDoubleClick;
            // 
            // btnCancelaCategoria
            // 
            btnCancelaCategoria.BackColor = Color.FromArgb(3, 171, 229);
            btnCancelaCategoria.Font = new Font("Calisto MT", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancelaCategoria.Location = new Point(746, 49);
            btnCancelaCategoria.Margin = new Padding(2);
            btnCancelaCategoria.Name = "btnCancelaCategoria";
            btnCancelaCategoria.Size = new Size(112, 62);
            btnCancelaCategoria.TabIndex = 19;
            btnCancelaCategoria.Text = "Cancelar";
            btnCancelaCategoria.UseVisualStyleBackColor = false;
            // 
            // btnAgregarCategoria
            // 
            btnAgregarCategoria.BackColor = Color.FromArgb(3, 171, 229);
            btnAgregarCategoria.Font = new Font("Calisto MT", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAgregarCategoria.Location = new Point(594, 49);
            btnAgregarCategoria.Margin = new Padding(2);
            btnAgregarCategoria.Name = "btnAgregarCategoria";
            btnAgregarCategoria.Size = new Size(110, 62);
            btnAgregarCategoria.TabIndex = 18;
            btnAgregarCategoria.Text = "Guardar";
            btnAgregarCategoria.UseVisualStyleBackColor = false;
            btnAgregarCategoria.Click += btnAgregarCategoria_Click;
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
            tabPage3.Controls.Add(txtNuevaMarca);
            tabPage3.Controls.Add(btnSalirMarcas);
            tabPage3.Controls.Add(DGMARCAS);
            tabPage3.Controls.Add(btnCancelarMarca);
            tabPage3.Controls.Add(btnGuardarMarca);
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
            // txtNuevaMarca
            // 
            txtNuevaMarca.Location = new Point(223, 69);
            txtNuevaMarca.Margin = new Padding(2);
            txtNuevaMarca.Name = "txtNuevaMarca";
            txtNuevaMarca.Size = new Size(286, 31);
            txtNuevaMarca.TabIndex = 41;
            txtNuevaMarca.UseWaitCursor = true;
            // 
            // btnSalirMarcas
            // 
            btnSalirMarcas.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnSalirMarcas.BackColor = Color.FromArgb(3, 171, 229);
            btnSalirMarcas.FlatStyle = FlatStyle.Popup;
            btnSalirMarcas.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSalirMarcas.Location = new Point(14, 704);
            btnSalirMarcas.Margin = new Padding(2);
            btnSalirMarcas.Name = "btnSalirMarcas";
            btnSalirMarcas.Size = new Size(103, 57);
            btnSalirMarcas.TabIndex = 39;
            btnSalirMarcas.Text = "Salir";
            btnSalirMarcas.UseVisualStyleBackColor = false;
            btnSalirMarcas.UseWaitCursor = true;
            btnSalirMarcas.Click += button10_Click;
            // 
            // DGMARCAS
            // 
            DGMARCAS.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DGMARCAS.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DGMARCAS.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGMARCAS.Location = new Point(14, 182);
            DGMARCAS.Margin = new Padding(2);
            DGMARCAS.Name = "DGMARCAS";
            DGMARCAS.RowHeadersWidth = 51;
            DGMARCAS.RowTemplate.Height = 24;
            DGMARCAS.Size = new Size(1357, 506);
            DGMARCAS.TabIndex = 28;
            DGMARCAS.UseWaitCursor = true;
            DGMARCAS.CellClick += DGMARCAS_CellClick;
            DGMARCAS.CellDoubleClick += DGMARCAS_CellDoubleClick;
            // 
            // btnCancelarMarca
            // 
            btnCancelarMarca.BackColor = Color.FromArgb(3, 171, 229);
            btnCancelarMarca.Font = new Font("Calisto MT", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancelarMarca.Location = new Point(751, 50);
            btnCancelarMarca.Margin = new Padding(2);
            btnCancelarMarca.Name = "btnCancelarMarca";
            btnCancelarMarca.Size = new Size(130, 57);
            btnCancelarMarca.TabIndex = 27;
            btnCancelarMarca.Text = "Cancelar";
            btnCancelarMarca.UseVisualStyleBackColor = false;
            btnCancelarMarca.UseWaitCursor = true;
            // 
            // btnGuardarMarca
            // 
            btnGuardarMarca.BackColor = Color.FromArgb(3, 171, 229);
            btnGuardarMarca.Font = new Font("Calisto MT", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGuardarMarca.Location = new Point(594, 50);
            btnGuardarMarca.Margin = new Padding(2);
            btnGuardarMarca.Name = "btnGuardarMarca";
            btnGuardarMarca.Size = new Size(125, 57);
            btnGuardarMarca.TabIndex = 26;
            btnGuardarMarca.Text = "Guardar";
            btnGuardarMarca.UseVisualStyleBackColor = false;
            btnGuardarMarca.UseWaitCursor = true;
            btnGuardarMarca.Click += button6_Click;
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
            ((System.ComponentModel.ISupportInitialize)DGCATEGORIAS).EndInit();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DGMARCAS).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox txtCodigoProduct;
        private System.Windows.Forms.ComboBox cmbMarcProduct;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbCategoriaProduc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView DGPRODUCTOS;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtPrecioVenta;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtStockMinimo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtStockActual;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnAgregarCategoria;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridView DGCATEGORIAS;
        private System.Windows.Forms.Button btnCancelaCategoria;
        private System.Windows.Forms.DataGridView DGMARCAS;
        private System.Windows.Forms.Button btnCancelarMarca;
        private System.Windows.Forms.Button btnGuardarMarca;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btnSalirProductos;
        private System.Windows.Forms.Button btnSalirCategorias;
        private System.Windows.Forms.Button btnSalirMarcas;
        private ComboBox comboBox4;
        private Label label21;
        private ComboBox comboBox9;
        private Label label13;
        private ComboBox comboBox5;
        private Label label10;
        private Label label14;
        private TextBox txtNombreProduct;
        private TextBox txtNuevaCategoria;
        private TextBox txtNuevaMarca;
    }
}