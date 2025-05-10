namespace formstienda
{
    partial class Proveedores
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Proveedores));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            label7 = new Label();
            pictureBox6 = new PictureBox();
            pictureBox4 = new PictureBox();
            btnSalir = new Button();
            btnGuardar = new Button();
            txtNombre_proveedor = new TextBox();
            txtCorreo = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label2 = new Label();
            label1 = new Label();
            label3 = new Label();
            label6 = new Label();
            txtApellido_proveedores = new TextBox();
            cmbestado = new ComboBox();
            dtgproveedores = new DataGridView();
            txtCodigo_ruc = new MaskedTextBox();
            txtTelefono = new MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtgproveedores).BeginInit();
            SuspendLayout();
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top;
            label7.AutoSize = true;
            label7.Font = new Font("Times New Roman", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.Black;
            label7.Location = new Point(385, 46);
            label7.Name = "label7";
            label7.Size = new Size(267, 38);
            label7.TabIndex = 68;
            label7.Text = "Nuevo proveedor";
            label7.TextAlign = ContentAlignment.TopCenter;
            label7.Click += label7_Click;
            // 
            // pictureBox6
            // 
            pictureBox6.Anchor = AnchorStyles.Right;
            pictureBox6.Image = (Image)resources.GetObject("pictureBox6.Image");
            pictureBox6.Location = new Point(813, 730);
            pictureBox6.Margin = new Padding(3, 2, 3, 2);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(28, 45);
            pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox6.TabIndex = 82;
            pictureBox6.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.Anchor = AnchorStyles.Top;
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(24, 317);
            pictureBox4.Margin = new Padding(3, 2, 3, 2);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(28, 42);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 81;
            pictureBox4.TabStop = false;
            // 
            // btnSalir
            // 
            btnSalir.Anchor = AnchorStyles.Right;
            btnSalir.BackColor = Color.FromArgb(3, 171, 229);
            btnSalir.Cursor = Cursors.Hand;
            btnSalir.FlatStyle = FlatStyle.Popup;
            btnSalir.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSalir.ForeColor = Color.Black;
            btnSalir.Location = new Point(847, 730);
            btnSalir.Margin = new Padding(3, 5, 3, 5);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(110, 45);
            btnSalir.TabIndex = 79;
            btnSalir.Text = "Salir ";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += button4_Click_1;
            // 
            // btnGuardar
            // 
            btnGuardar.Anchor = AnchorStyles.Top;
            btnGuardar.BackColor = Color.FromArgb(3, 171, 229);
            btnGuardar.Cursor = Cursors.Hand;
            btnGuardar.FlatStyle = FlatStyle.Popup;
            btnGuardar.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGuardar.ForeColor = Color.Black;
            btnGuardar.Location = new Point(58, 314);
            btnGuardar.Margin = new Padding(3, 5, 3, 5);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(125, 45);
            btnGuardar.TabIndex = 80;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // txtNombre_proveedor
            // 
            txtNombre_proveedor.Anchor = AnchorStyles.Top;
            txtNombre_proveedor.Location = new Point(723, 134);
            txtNombre_proveedor.Margin = new Padding(3, 2, 3, 2);
            txtNombre_proveedor.Name = "txtNombre_proveedor";
            txtNombre_proveedor.Size = new Size(234, 27);
            txtNombre_proveedor.TabIndex = 76;
            // 
            // txtCorreo
            // 
            txtCorreo.Anchor = AnchorStyles.Top;
            txtCorreo.Location = new Point(723, 255);
            txtCorreo.Margin = new Padding(3, 2, 3, 2);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(234, 27);
            txtCorreo.TabIndex = 75;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top;
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.Black;
            label5.Location = new Point(452, 255);
            label5.Name = "label5";
            label5.Size = new Size(170, 22);
            label5.TabIndex = 73;
            label5.Text = "Correo(Opcional):";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top;
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(15, 255);
            label4.Name = "label4";
            label4.Size = new Size(78, 22);
            label4.TabIndex = 72;
            label4.Text = "Estado:";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top;
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(15, 189);
            label2.Name = "label2";
            label2.Size = new Size(95, 22);
            label2.TabIndex = 71;
            label2.Text = "Teléfono:";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(15, 131);
            label1.Name = "label1";
            label1.Size = new Size(127, 22);
            label1.TabIndex = 70;
            label1.Text = "Código RUC:";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top;
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(444, 133);
            label3.Name = "label3";
            label3.Size = new Size(214, 22);
            label3.TabIndex = 69;
            label3.Text = "Nombre del proveedor:";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top;
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.Black;
            label6.Location = new Point(444, 189);
            label6.Name = "label6";
            label6.Size = new Size(217, 22);
            label6.TabIndex = 83;
            label6.Text = "Apellido del proveedor:";
            // 
            // txtApellido_proveedores
            // 
            txtApellido_proveedores.Anchor = AnchorStyles.Top;
            txtApellido_proveedores.Location = new Point(723, 189);
            txtApellido_proveedores.Margin = new Padding(3, 2, 3, 2);
            txtApellido_proveedores.Name = "txtApellido_proveedores";
            txtApellido_proveedores.Size = new Size(234, 27);
            txtApellido_proveedores.TabIndex = 84;
            // 
            // cmbestado
            // 
            cmbestado.Anchor = AnchorStyles.Top;
            cmbestado.FormattingEnabled = true;
            cmbestado.Items.AddRange(new object[] { "Activo", "Inactivo" });
            cmbestado.Location = new Point(180, 249);
            cmbestado.Margin = new Padding(3, 2, 3, 2);
            cmbestado.Name = "cmbestado";
            cmbestado.Size = new Size(151, 28);
            cmbestado.TabIndex = 85;
            // 
            // dtgproveedores
            // 
            dtgproveedores.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            dtgproveedores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgproveedores.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = Color.Black;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dtgproveedores.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dtgproveedores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dtgproveedores.DefaultCellStyle = dataGridViewCellStyle2;
            dtgproveedores.Location = new Point(15, 423);
            dtgproveedores.Name = "dtgproveedores";
            dtgproveedores.RowHeadersWidth = 51;
            dtgproveedores.Size = new Size(942, 282);
            dtgproveedores.TabIndex = 86;
            dtgproveedores.CellContentClick += dtgproveedores_CellContentClick;
            dtgproveedores.CellEndEdit += dtgproveedores_CellEndEdit;
            // 
            // txtCodigo_ruc
            // 
            txtCodigo_ruc.Anchor = AnchorStyles.Top;
            txtCodigo_ruc.Location = new Point(180, 134);
            txtCodigo_ruc.Mask = "000-000000-0000X";
            txtCodigo_ruc.Name = "txtCodigo_ruc";
            txtCodigo_ruc.Size = new Size(205, 27);
            txtCodigo_ruc.TabIndex = 87;
            // 
            // txtTelefono
            // 
            txtTelefono.Anchor = AnchorStyles.Top;
            txtTelefono.Location = new Point(180, 189);
            txtTelefono.Mask = "0000-0000";
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(205, 27);
            txtTelefono.TabIndex = 88;
            txtTelefono.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            // 
            // Proveedores
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(989, 789);
            Controls.Add(txtTelefono);
            Controls.Add(txtCodigo_ruc);
            Controls.Add(dtgproveedores);
            Controls.Add(cmbestado);
            Controls.Add(txtApellido_proveedores);
            Controls.Add(label6);
            Controls.Add(pictureBox6);
            Controls.Add(pictureBox4);
            Controls.Add(btnSalir);
            Controls.Add(btnGuardar);
            Controls.Add(txtNombre_proveedor);
            Controls.Add(txtCorreo);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(label3);
            Controls.Add(label7);
            ForeColor = Color.Black;
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "Proveedores";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Proveedores";
            Load += Proveedores_Load;
            KeyPress += Proveedores_KeyPress;
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtgproveedores).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnGuardar;
     
        private System.Windows.Forms.TextBox txtNombre_proveedor;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtApellido_proveedores;
        private ComboBox cmbestado;
        private DataGridView dtgproveedores;
        private MaskedTextBox txtCodigo_ruc;
        private MaskedTextBox txtTelefono;
    }
}