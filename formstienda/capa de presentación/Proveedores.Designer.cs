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
            label7 = new Label();
            pictureBox6 = new PictureBox();
            pictureBox4 = new PictureBox();
            btnSalir = new Button();
            btnGuardar = new Button();
            txtCodigo_ruc = new TextBox();
            txtNombre_proveedor = new TextBox();
            textCorreo = new TextBox();
            txtTelefono = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label2 = new Label();
            label1 = new Label();
            label3 = new Label();
            label6 = new Label();
            txtApellido_proveedores = new TextBox();
            txtEstado = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            SuspendLayout();
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top;
            label7.AutoSize = true;
            label7.Font = new Font("Times New Roman", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.Black;
            label7.Location = new Point(481, 58);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(310, 45);
            label7.TabIndex = 68;
            label7.Text = "Nuevo proveedor";
            label7.TextAlign = ContentAlignment.TopCenter;
            label7.Click += label7_Click;
            // 
            // pictureBox6
            // 
            pictureBox6.Anchor = AnchorStyles.Bottom;
            pictureBox6.Image = (Image)resources.GetObject("pictureBox6.Image");
            pictureBox6.Location = new Point(679, 519);
            pictureBox6.Margin = new Padding(4, 3, 4, 3);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(35, 56);
            pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox6.TabIndex = 82;
            pictureBox6.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.Anchor = AnchorStyles.Bottom;
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(432, 523);
            pictureBox4.Margin = new Padding(4, 3, 4, 3);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(35, 52);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 81;
            pictureBox4.TabStop = false;
            // 
            // btnSalir
            // 
            btnSalir.Anchor = AnchorStyles.Bottom;
            btnSalir.BackColor = Color.FromArgb(3, 171, 229);
            btnSalir.Cursor = Cursors.Hand;
            btnSalir.FlatStyle = FlatStyle.Popup;
            btnSalir.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSalir.ForeColor = Color.Black;
            btnSalir.Location = new Point(735, 519);
            btnSalir.Margin = new Padding(4, 6, 4, 6);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(138, 56);
            btnSalir.TabIndex = 79;
            btnSalir.Text = "Salir ";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += button4_Click_1;
            // 
            // btnGuardar
            // 
            btnGuardar.Anchor = AnchorStyles.Bottom;
            btnGuardar.BackColor = Color.FromArgb(3, 171, 229);
            btnGuardar.Cursor = Cursors.Hand;
            btnGuardar.FlatStyle = FlatStyle.Popup;
            btnGuardar.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGuardar.ForeColor = Color.Black;
            btnGuardar.Location = new Point(490, 519);
            btnGuardar.Margin = new Padding(4, 6, 4, 6);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(156, 56);
            btnGuardar.TabIndex = 80;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // txtCodigo_ruc
            // 
            txtCodigo_ruc.Anchor = AnchorStyles.Top;
            txtCodigo_ruc.Location = new Point(225, 166);
            txtCodigo_ruc.Margin = new Padding(4, 3, 4, 3);
            txtCodigo_ruc.Name = "txtCodigo_ruc";
            txtCodigo_ruc.ReadOnly = true;
            txtCodigo_ruc.Size = new Size(255, 31);
            txtCodigo_ruc.TabIndex = 77;
            // 
            // txtNombre_proveedor
            // 
            txtNombre_proveedor.Anchor = AnchorStyles.Top;
            txtNombre_proveedor.Location = new Point(904, 167);
            txtNombre_proveedor.Margin = new Padding(4, 3, 4, 3);
            txtNombre_proveedor.Name = "txtNombre_proveedor";
            txtNombre_proveedor.ReadOnly = true;
            txtNombre_proveedor.Size = new Size(292, 31);
            txtNombre_proveedor.TabIndex = 76;
            // 
            // textCorreo
            // 
            textCorreo.Anchor = AnchorStyles.Top;
            textCorreo.Location = new Point(904, 319);
            textCorreo.Margin = new Padding(4, 3, 4, 3);
            textCorreo.Name = "textCorreo";
            textCorreo.ReadOnly = true;
            textCorreo.Size = new Size(292, 31);
            textCorreo.TabIndex = 75;
            // 
            // txtTelefono
            // 
            txtTelefono.Anchor = AnchorStyles.Top;
            txtTelefono.Location = new Point(225, 236);
            txtTelefono.Margin = new Padding(4, 3, 4, 3);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.ReadOnly = true;
            txtTelefono.Size = new Size(255, 31);
            txtTelefono.TabIndex = 74;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top;
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.Black;
            label5.Location = new Point(565, 319);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(201, 26);
            label5.TabIndex = 73;
            label5.Text = "Correo(Opcional):";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top;
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(19, 319);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(93, 26);
            label4.TabIndex = 72;
            label4.Text = "Estado:";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top;
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(19, 236);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(110, 26);
            label2.TabIndex = 71;
            label2.Text = "Teléfono:";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(19, 164);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(152, 26);
            label1.TabIndex = 70;
            label1.Text = "Código RUC:";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top;
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(555, 166);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(255, 26);
            label3.TabIndex = 69;
            label3.Text = "Nombre del proveedor:";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top;
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.Black;
            label6.Location = new Point(555, 236);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(257, 26);
            label6.TabIndex = 83;
            label6.Text = "Apellido del proveedor:";
            // 
            // txtApellido_proveedores
            // 
            txtApellido_proveedores.Anchor = AnchorStyles.Top;
            txtApellido_proveedores.Location = new Point(904, 236);
            txtApellido_proveedores.Margin = new Padding(4, 3, 4, 3);
            txtApellido_proveedores.Name = "txtApellido_proveedores";
            txtApellido_proveedores.ReadOnly = true;
            txtApellido_proveedores.Size = new Size(292, 31);
            txtApellido_proveedores.TabIndex = 84;
            // 
            // txtEstado
            // 
            txtEstado.Anchor = AnchorStyles.Top;
            txtEstado.Location = new Point(225, 314);
            txtEstado.Margin = new Padding(4, 3, 4, 3);
            txtEstado.Name = "txtEstado";
            txtEstado.ReadOnly = true;
            txtEstado.Size = new Size(255, 31);
            txtEstado.TabIndex = 85;
            // 
            // Proveedores
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(1236, 664);
            Controls.Add(txtEstado);
            Controls.Add(txtApellido_proveedores);
            Controls.Add(label6);
            Controls.Add(pictureBox6);
            Controls.Add(pictureBox4);
            Controls.Add(btnSalir);
            Controls.Add(btnGuardar);
            Controls.Add(txtCodigo_ruc);
            Controls.Add(txtNombre_proveedor);
            Controls.Add(textCorreo);
            Controls.Add(txtTelefono);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(label3);
            Controls.Add(label7);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 3, 4, 3);
            Name = "Proveedores";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Proveedores";
            Load += Proveedores_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.TextBox txtCodigo_ruc;
        private System.Windows.Forms.TextBox txtNombre_proveedor;
        private System.Windows.Forms.TextBox textCorreo;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtApellido_proveedores;
        private TextBox txtEstado;
    }
}