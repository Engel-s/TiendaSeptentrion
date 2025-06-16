namespace formstienda.capa_de_presentación
{
    partial class Facturacion_de_crédito
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Facturacion_de_crédito));
            label1 = new Label();
            pcbusqueda = new PictureBox();
            txtBusqueda = new TextBox();
            pictureBox2 = new PictureBox();
            Tabla_Credito = new DataGridView();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtTotalAbonado = new TextBox();
            txtCordobas = new TextBox();
            btnGuardar = new Button();
            btnCancelar = new Button();
            pictureBox4 = new PictureBox();
            pictureBox3 = new PictureBox();
            btnSalir = new Button();
            pictureBox6 = new PictureBox();
            CBBUSQUEDADETALLE = new ComboBox();
            label2 = new Label();
            label7 = new Label();
            label8 = new Label();
            txtcliente = new TextBox();
            txtcedula = new TextBox();
            txtcolilla = new TextBox();
            label9 = new Label();
            txtdiasenmoras = new TextBox();
            label10 = new Label();
            txtpagomora = new TextBox();
            txtDolares = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pcbusqueda).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Tabla_Credito).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Calisto MT", 12F, FontStyle.Bold);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(132, 47);
            label1.Name = "label1";
            label1.Size = new Size(79, 22);
            label1.TabIndex = 0;
            label1.Text = "Buscar:";
            // 
            // pcbusqueda
            // 
            pcbusqueda.Image = Properties.Resources.busque_un_simbolo_de_interfaz_de_persona_de_una_lupa_en_forma_de_hombre;
            pcbusqueda.Location = new Point(589, 37);
            pcbusqueda.Margin = new Padding(3, 2, 3, 2);
            pcbusqueda.Name = "pcbusqueda";
            pcbusqueda.Size = new Size(47, 40);
            pcbusqueda.SizeMode = PictureBoxSizeMode.StretchImage;
            pcbusqueda.TabIndex = 37;
            pcbusqueda.TabStop = false;
            pcbusqueda.Click += pcbusqueda_Click;
            // 
            // txtBusqueda
            // 
            txtBusqueda.Location = new Point(337, 45);
            txtBusqueda.Margin = new Padding(3, 2, 3, 2);
            txtBusqueda.Name = "txtBusqueda";
            txtBusqueda.Size = new Size(226, 27);
            txtBusqueda.TabIndex = 38;
            txtBusqueda.TextChanged += textBox1_TextChanged;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(28, 11);
            pictureBox2.Margin = new Padding(3, 2, 3, 2);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(78, 66);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 39;
            pictureBox2.TabStop = false;
            // 
            // Tabla_Credito
            // 
            Tabla_Credito.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Tabla_Credito.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            Tabla_Credito.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            Tabla_Credito.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Tabla_Credito.Location = new Point(28, 326);
            Tabla_Credito.Margin = new Padding(3, 2, 3, 2);
            Tabla_Credito.Name = "Tabla_Credito";
            Tabla_Credito.RowHeadersWidth = 62;
            Tabla_Credito.RowTemplate.Height = 28;
            Tabla_Credito.Size = new Size(754, 440);
            Tabla_Credito.TabIndex = 41;
            Tabla_Credito.CellContentClick += Tabla_Credito_CellContentClick;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Calisto MT", 12F, FontStyle.Bold);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(841, 435);
            label3.Name = "label3";
            label3.Size = new Size(105, 22);
            label3.TabIndex = 42;
            label3.Text = "Córdobas:";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Calisto MT", 12F, FontStyle.Bold);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(836, 349);
            label4.Name = "label4";
            label4.Size = new Size(152, 22);
            label4.TabIndex = 43;
            label4.Text = "Total a abonar:";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Font = new Font("Calisto MT", 12F, FontStyle.Bold);
            label5.ForeColor = Color.Black;
            label5.Location = new Point(841, 521);
            label5.Name = "label5";
            label5.Size = new Size(90, 22);
            label5.TabIndex = 44;
            label5.Text = "Dólares:";
            // 
            // txtTotalAbonado
            // 
            txtTotalAbonado.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            txtTotalAbonado.Location = new Point(841, 390);
            txtTotalAbonado.Margin = new Padding(3, 2, 3, 2);
            txtTotalAbonado.Name = "txtTotalAbonado";
            txtTotalAbonado.ReadOnly = true;
            txtTotalAbonado.Size = new Size(147, 27);
            txtTotalAbonado.TabIndex = 45;
            // 
            // txtCordobas
            // 
            txtCordobas.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            txtCordobas.Location = new Point(841, 472);
            txtCordobas.Margin = new Padding(3, 2, 3, 2);
            txtCordobas.Name = "txtCordobas";
            txtCordobas.Size = new Size(147, 27);
            txtCordobas.TabIndex = 46;
            txtCordobas.TextChanged += txtCordobas_TextChanged;
            txtCordobas.KeyPress += txtCordobas_KeyPress;
            txtCordobas.KeyUp += txtCordobas_KeyUp;
            // 
            // btnGuardar
            // 
            btnGuardar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnGuardar.BackColor = Color.FromArgb(3, 171, 229);
            btnGuardar.FlatStyle = FlatStyle.Popup;
            btnGuardar.Font = new Font("Microsoft Sans Serif", 8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGuardar.ForeColor = Color.Black;
            btnGuardar.Location = new Point(868, 630);
            btnGuardar.Margin = new Padding(3, 2, 3, 2);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(141, 42);
            btnGuardar.TabIndex = 48;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancelar.BackColor = Color.FromArgb(3, 171, 229);
            btnCancelar.FlatStyle = FlatStyle.Popup;
            btnCancelar.Font = new Font("Microsoft Sans Serif", 8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancelar.ForeColor = Color.Black;
            btnCancelar.Location = new Point(869, 676);
            btnCancelar.Margin = new Padding(3, 2, 3, 2);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(141, 42);
            btnCancelar.TabIndex = 51;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // pictureBox4
            // 
            pictureBox4.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(818, 627);
            pictureBox4.Margin = new Padding(3, 2, 3, 2);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(44, 42);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 52;
            pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            pictureBox3.Image = Properties.Resources.prohibido;
            pictureBox3.Location = new Point(818, 676);
            pictureBox3.Margin = new Padding(3, 5, 3, 5);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(45, 35);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 53;
            pictureBox3.TabStop = false;
            // 
            // btnSalir
            // 
            btnSalir.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSalir.BackColor = Color.FromArgb(3, 171, 229);
            btnSalir.FlatStyle = FlatStyle.Popup;
            btnSalir.Font = new Font("Microsoft Sans Serif", 8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSalir.ForeColor = Color.Black;
            btnSalir.Location = new Point(869, 722);
            btnSalir.Margin = new Padding(3, 2, 3, 2);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(141, 40);
            btnSalir.TabIndex = 54;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += button3_Click;
            // 
            // pictureBox6
            // 
            pictureBox6.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            pictureBox6.Image = (Image)resources.GetObject("pictureBox6.Image");
            pictureBox6.Location = new Point(819, 724);
            pictureBox6.Margin = new Padding(3, 2, 3, 2);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(44, 42);
            pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox6.TabIndex = 55;
            pictureBox6.TabStop = false;
            // 
            // CBBUSQUEDADETALLE
            // 
            CBBUSQUEDADETALLE.FormattingEnabled = true;
            CBBUSQUEDADETALLE.Items.AddRange(new object[] { "Cliente", "Factura" });
            CBBUSQUEDADETALLE.Location = new Point(221, 46);
            CBBUSQUEDADETALLE.Name = "CBBUSQUEDADETALLE";
            CBBUSQUEDADETALLE.Size = new Size(100, 28);
            CBBUSQUEDADETALLE.TabIndex = 58;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Calisto MT", 12F, FontStyle.Bold);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(20, 143);
            label2.Name = "label2";
            label2.Size = new Size(191, 22);
            label2.TabIndex = 59;
            label2.Text = "Nombre del cliente:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Calisto MT", 12F, FontStyle.Bold);
            label7.ForeColor = Color.Black;
            label7.Location = new Point(28, 193);
            label7.Name = "label7";
            label7.Size = new Size(183, 22);
            label7.TabIndex = 60;
            label7.Text = "Número de cedúla:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Calisto MT", 12F, FontStyle.Bold);
            label8.ForeColor = Color.Black;
            label8.Location = new Point(78, 240);
            label8.Name = "label8";
            label8.Size = new Size(133, 22);
            label8.TabIndex = 61;
            label8.Text = "Colilla INSS:";
            // 
            // txtcliente
            // 
            txtcliente.Location = new Point(227, 138);
            txtcliente.Margin = new Padding(3, 2, 3, 2);
            txtcliente.Name = "txtcliente";
            txtcliente.Size = new Size(336, 27);
            txtcliente.TabIndex = 62;
            // 
            // txtcedula
            // 
            txtcedula.Location = new Point(227, 188);
            txtcedula.Margin = new Padding(3, 2, 3, 2);
            txtcedula.Name = "txtcedula";
            txtcedula.Size = new Size(336, 27);
            txtcedula.TabIndex = 63;
            // 
            // txtcolilla
            // 
            txtcolilla.Location = new Point(227, 240);
            txtcolilla.Margin = new Padding(3, 2, 3, 2);
            txtcolilla.Name = "txtcolilla";
            txtcolilla.Size = new Size(336, 27);
            txtcolilla.TabIndex = 64;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Calisto MT", 12F, FontStyle.Bold);
            label9.ForeColor = Color.Black;
            label9.Location = new Point(600, 138);
            label9.Name = "label9";
            label9.Size = new Size(141, 22);
            label9.TabIndex = 65;
            label9.Text = "Dias en mora:";
            // 
            // txtdiasenmoras
            // 
            txtdiasenmoras.Location = new Point(776, 133);
            txtdiasenmoras.Margin = new Padding(3, 2, 3, 2);
            txtdiasenmoras.Name = "txtdiasenmoras";
            txtdiasenmoras.Size = new Size(156, 27);
            txtdiasenmoras.TabIndex = 66;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Calisto MT", 12F, FontStyle.Bold);
            label10.ForeColor = Color.Black;
            label10.Location = new Point(600, 193);
            label10.Name = "label10";
            label10.Size = new Size(155, 22);
            label10.TabIndex = 67;
            label10.Text = "Pago por mora:";
            // 
            // txtpagomora
            // 
            txtpagomora.Location = new Point(776, 193);
            txtpagomora.Margin = new Padding(3, 2, 3, 2);
            txtpagomora.Name = "txtpagomora";
            txtpagomora.Size = new Size(156, 27);
            txtpagomora.TabIndex = 68;
            // 
            // txtDolares
            // 
            txtDolares.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            txtDolares.Location = new Point(841, 561);
            txtDolares.Margin = new Padding(3, 2, 3, 2);
            txtDolares.Name = "txtDolares";
            txtDolares.Size = new Size(147, 27);
            txtDolares.TabIndex = 69;
            txtDolares.TextChanged += txtDolares_TextChanged_1;
            txtDolares.KeyPress += txtDolares_KeyPress;
            // 
            // Facturacion_de_crédito
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1045, 793);
            Controls.Add(txtDolares);
            Controls.Add(txtpagomora);
            Controls.Add(label10);
            Controls.Add(txtdiasenmoras);
            Controls.Add(label9);
            Controls.Add(txtcolilla);
            Controls.Add(txtcedula);
            Controls.Add(txtcliente);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label2);
            Controls.Add(CBBUSQUEDADETALLE);
            Controls.Add(pictureBox6);
            Controls.Add(btnSalir);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox4);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(txtCordobas);
            Controls.Add(txtTotalAbonado);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(Tabla_Credito);
            Controls.Add(pictureBox2);
            Controls.Add(txtBusqueda);
            Controls.Add(pcbusqueda);
            Controls.Add(label1);
            ForeColor = Color.Black;
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "Facturacion_de_crédito";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Facturacion_de_crédito";
            Load += Facturacion_de_crédito_Load;
            ((System.ComponentModel.ISupportInitialize)pcbusqueda).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)Tabla_Credito).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pcbusqueda;
        private System.Windows.Forms.TextBox txtBusqueda;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.DataGridView Tabla_Credito;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTotalAbonado;
        private System.Windows.Forms.TextBox txtCordobas;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.PictureBox pictureBox6;
        private ComboBox CBBUSQUEDADETALLE;
        private Label label2;
        private Label label7;
        private Label label8;
        private TextBox txtcliente;
        private TextBox txtcedula;
        private TextBox txtcolilla;
        private Label label9;
        private TextBox txtdiasenmoras;
        private Label label10;
        private TextBox txtpagomora;
        private TextBox txtDolares;
    }
}