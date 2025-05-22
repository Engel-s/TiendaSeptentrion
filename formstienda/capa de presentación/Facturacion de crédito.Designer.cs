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
            pictureBox1 = new PictureBox();
            txtBusqueda = new TextBox();
            pictureBox2 = new PictureBox();
            Tabla_Credito = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            Column8 = new DataGridViewTextBoxColumn();
            Column9 = new DataGridViewTextBoxColumn();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtTotalAbonado = new TextBox();
            txtCordobas = new TextBox();
            btnGuardar = new Button();
            label6 = new Label();
            txtDolares = new TextBox();
            btnCancelar = new Button();
            pictureBox4 = new PictureBox();
            pictureBox3 = new PictureBox();
            btnSalir = new Button();
            pictureBox6 = new PictureBox();
            txtCambio = new TextBox();
            checkBox1 = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Tabla_Credito).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Font = new Font("Calisto MT", 12F, FontStyle.Bold);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(281, 118);
            label1.Name = "label1";
            label1.Size = new Size(145, 22);
            label1.TabIndex = 0;
            label1.Text = "Buscar cliente:";
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top;
            pictureBox1.Image = Properties.Resources.busque_un_simbolo_de_interfaz_de_persona_de_una_lupa_en_forma_de_hombre;
            pictureBox1.Location = new Point(663, 103);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(47, 40);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 37;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // txtBusqueda
            // 
            txtBusqueda.Anchor = AnchorStyles.Top;
            txtBusqueda.Location = new Point(470, 116);
            txtBusqueda.Margin = new Padding(3, 2, 3, 2);
            txtBusqueda.Name = "txtBusqueda";
            txtBusqueda.Size = new Size(165, 27);
            txtBusqueda.TabIndex = 38;
            txtBusqueda.TextChanged += textBox1_TextChanged;
            // 
            // pictureBox2
            // 
            pictureBox2.Anchor = AnchorStyles.Top;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(89, 65);
            pictureBox2.Margin = new Padding(3, 2, 3, 2);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(112, 93);
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
            Tabla_Credito.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4, Column5, Column8, Column9 });
            Tabla_Credito.Location = new Point(28, 162);
            Tabla_Credito.Margin = new Padding(3, 2, 3, 2);
            Tabla_Credito.Name = "Tabla_Credito";
            Tabla_Credito.RowHeadersWidth = 62;
            Tabla_Credito.RowTemplate.Height = 28;
            Tabla_Credito.Size = new Size(1001, 402);
            Tabla_Credito.TabIndex = 41;
            Tabla_Credito.CellContentClick += Tabla_Credito_CellContentClick;
            // 
            // Column1
            // 
            Column1.HeaderText = "Nº Factura";
            Column1.MinimumWidth = 8;
            Column1.Name = "Column1";
            // 
            // Column2
            // 
            Column2.HeaderText = "Fecha";
            Column2.MinimumWidth = 8;
            Column2.Name = "Column2";
            // 
            // Column3
            // 
            Column3.HeaderText = "Saldo";
            Column3.MinimumWidth = 8;
            Column3.Name = "Column3";
            // 
            // Column4
            // 
            Column4.HeaderText = "Abono";
            Column4.MinimumWidth = 8;
            Column4.Name = "Column4";
            // 
            // Column5
            // 
            Column5.HeaderText = "Nuevo saldo";
            Column5.MinimumWidth = 8;
            Column5.Name = "Column5";
            // 
            // Column8
            // 
            Column8.HeaderText = "Tasa de interés";
            Column8.MinimumWidth = 6;
            Column8.Name = "Column8";
            // 
            // Column9
            // 
            Column9.HeaderText = "Número de plazo ";
            Column9.MinimumWidth = 6;
            Column9.Name = "Column9";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Bottom;
            label3.AutoSize = true;
            label3.Font = new Font("Calisto MT", 12F, FontStyle.Bold);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(45, 651);
            label3.Name = "label3";
            label3.Size = new Size(105, 22);
            label3.TabIndex = 42;
            label3.Text = "Córdobas:";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Bottom;
            label4.AutoSize = true;
            label4.Font = new Font("Calisto MT", 12F, FontStyle.Bold);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(1, 598);
            label4.Name = "label4";
            label4.Size = new Size(149, 22);
            label4.TabIndex = 43;
            label4.Text = "Total abonado:";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Bottom;
            label5.AutoSize = true;
            label5.Font = new Font("Calisto MT", 12F, FontStyle.Bold);
            label5.ForeColor = Color.Black;
            label5.Location = new Point(417, 651);
            label5.Name = "label5";
            label5.Size = new Size(90, 22);
            label5.TabIndex = 44;
            label5.Text = "Dólares:";
            // 
            // txtTotalAbonado
            // 
            txtTotalAbonado.Anchor = AnchorStyles.Bottom;
            txtTotalAbonado.Location = new Point(220, 598);
            txtTotalAbonado.Margin = new Padding(3, 2, 3, 2);
            txtTotalAbonado.Name = "txtTotalAbonado";
            txtTotalAbonado.Size = new Size(147, 27);
            txtTotalAbonado.TabIndex = 45;
            // 
            // txtCordobas
            // 
            txtCordobas.Anchor = AnchorStyles.Bottom;
            txtCordobas.Location = new Point(221, 651);
            txtCordobas.Margin = new Padding(3, 2, 3, 2);
            txtCordobas.Name = "txtCordobas";
            txtCordobas.Size = new Size(147, 27);
            txtCordobas.TabIndex = 46;
            txtCordobas.TextChanged += txtCordobas_TextChanged;
            // 
            // btnGuardar
            // 
            btnGuardar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnGuardar.BackColor = Color.FromArgb(3, 171, 229);
            btnGuardar.FlatStyle = FlatStyle.Popup;
            btnGuardar.Font = new Font("Microsoft Sans Serif", 8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGuardar.ForeColor = Color.Black;
            btnGuardar.Location = new Point(271, 733);
            btnGuardar.Margin = new Padding(3, 2, 3, 2);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(141, 42);
            btnGuardar.TabIndex = 48;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Bottom;
            label6.AutoSize = true;
            label6.Font = new Font("Calisto MT", 12F, FontStyle.Bold);
            label6.ForeColor = Color.Black;
            label6.Location = new Point(733, 651);
            label6.Name = "label6";
            label6.Size = new Size(91, 22);
            label6.TabIndex = 49;
            label6.Text = "Cambio:";
            // 
            // txtDolares
            // 
            txtDolares.Anchor = AnchorStyles.Bottom;
            txtDolares.Enabled = false;
            txtDolares.Location = new Point(542, 651);
            txtDolares.Margin = new Padding(3, 2, 3, 2);
            txtDolares.Name = "txtDolares";
            txtDolares.Size = new Size(147, 27);
            txtDolares.TabIndex = 47;
            txtDolares.TextChanged += txtDolares_TextChanged;
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnCancelar.BackColor = Color.FromArgb(3, 171, 229);
            btnCancelar.FlatStyle = FlatStyle.Popup;
            btnCancelar.Font = new Font("Microsoft Sans Serif", 8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancelar.ForeColor = Color.Black;
            btnCancelar.Location = new Point(62, 731);
            btnCancelar.Margin = new Padding(3, 2, 3, 2);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(141, 42);
            btnCancelar.TabIndex = 51;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            // 
            // pictureBox4
            // 
            pictureBox4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(227, 733);
            pictureBox4.Margin = new Padding(3, 2, 3, 2);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(31, 42);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 52;
            pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            pictureBox3.Image = Properties.Resources.prohibido;
            pictureBox3.Location = new Point(11, 736);
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
            btnSalir.Location = new Point(894, 744);
            btnSalir.Margin = new Padding(3, 2, 3, 2);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(119, 40);
            btnSalir.TabIndex = 54;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += button3_Click;
            // 
            // pictureBox6
            // 
            pictureBox6.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            pictureBox6.Image = (Image)resources.GetObject("pictureBox6.Image");
            pictureBox6.Location = new Point(857, 742);
            pictureBox6.Margin = new Padding(3, 2, 3, 2);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(31, 42);
            pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox6.TabIndex = 55;
            pictureBox6.TabStop = false;
            // 
            // txtCambio
            // 
            txtCambio.Anchor = AnchorStyles.Bottom;
            txtCambio.Location = new Point(882, 650);
            txtCambio.Margin = new Padding(3, 2, 3, 2);
            txtCambio.Name = "txtCambio";
            txtCambio.Size = new Size(147, 27);
            txtCambio.TabIndex = 56;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(430, 613);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(119, 24);
            checkBox1.TabIndex = 57;
            checkBox1.Text = "Pago Dólares";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // Facturacion_de_crédito
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1045, 793);
            Controls.Add(checkBox1);
            Controls.Add(txtCambio);
            Controls.Add(pictureBox6);
            Controls.Add(btnSalir);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox4);
            Controls.Add(btnCancelar);
            Controls.Add(label6);
            Controls.Add(btnGuardar);
            Controls.Add(txtDolares);
            Controls.Add(txtCordobas);
            Controls.Add(txtTotalAbonado);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(Tabla_Credito);
            Controls.Add(pictureBox2);
            Controls.Add(txtBusqueda);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            ForeColor = Color.Black;
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "Facturacion_de_crédito";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Facturacion_de_crédito";
            Load += Facturacion_de_crédito_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
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
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtBusqueda;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.DataGridView Tabla_Credito;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTotalAbonado;
        private System.Windows.Forms.TextBox txtCordobas;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDolares;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.PictureBox pictureBox6;
        private TextBox txtCambio;
        private CheckBox checkBox1;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column8;
        private DataGridViewTextBoxColumn Column9;
    }
}