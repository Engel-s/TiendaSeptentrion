namespace formstienda.capa_de_presentación
{
    partial class VentanaEmergenteProveedor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VentanaEmergenteProveedor));
            label1 = new Label();
            cmbestado = new ComboBox();
            label2 = new Label();
            txtnombreproveedor = new TextBox();
            txtapeliidoproveedor = new TextBox();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            txtcorreoproveedor = new TextBox();
            label7 = new Label();
            btnguardar = new Button();
            button2 = new Button();
            pictureBox1 = new PictureBox();
            pictureBox4 = new PictureBox();
            txttelefonoproveedor = new MaskedTextBox();
            txtcodigorucproveedor = new MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(179, 9);
            label1.Name = "label1";
            label1.Size = new Size(230, 35);
            label1.TabIndex = 0;
            label1.Text = "Nuevo proveedor";
            // 
            // cmbestado
            // 
            cmbestado.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbestado.FormattingEnabled = true;
            cmbestado.Items.AddRange(new object[] { "Activo", "Inactivo" });
            cmbestado.Location = new Point(81, 270);
            cmbestado.Name = "cmbestado";
            cmbestado.Size = new Size(113, 28);
            cmbestado.TabIndex = 2;
            cmbestado.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label2.Location = new Point(346, 74);
            label2.Name = "label2";
            label2.Size = new Size(94, 28);
            label2.TabIndex = 3;
            label2.Text = "Nombre:";
            // 
            // txtnombreproveedor
            // 
            txtnombreproveedor.Location = new Point(346, 105);
            txtnombreproveedor.Name = "txtnombreproveedor";
            txtnombreproveedor.Size = new Size(177, 27);
            txtnombreproveedor.TabIndex = 4;
            // 
            // txtapeliidoproveedor
            // 
            txtapeliidoproveedor.Location = new Point(346, 190);
            txtapeliidoproveedor.Name = "txtapeliidoproveedor";
            txtapeliidoproveedor.Size = new Size(177, 27);
            txtapeliidoproveedor.TabIndex = 5;
            txtapeliidoproveedor.TextChanged += textBox3_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label3.Location = new Point(346, 158);
            label3.Name = "label3";
            label3.Size = new Size(96, 28);
            label3.TabIndex = 6;
            label3.Text = "Apellido:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label4.Location = new Point(81, 74);
            label4.Name = "label4";
            label4.Size = new Size(119, 28);
            label4.TabIndex = 7;
            label4.Text = "Código ruc:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label5.Location = new Point(81, 158);
            label5.Name = "label5";
            label5.Size = new Size(99, 28);
            label5.TabIndex = 8;
            label5.Text = "Teléfono:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label6.Location = new Point(346, 239);
            label6.Name = "label6";
            label6.Size = new Size(181, 28);
            label6.TabIndex = 10;
            label6.Text = "Correo (opcional):";
            // 
            // txtcorreoproveedor
            // 
            txtcorreoproveedor.Location = new Point(346, 270);
            txtcorreoproveedor.Name = "txtcorreoproveedor";
            txtcorreoproveedor.Size = new Size(220, 27);
            txtcorreoproveedor.TabIndex = 11;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label7.Location = new Point(81, 239);
            label7.Name = "label7";
            label7.Size = new Size(80, 28);
            label7.TabIndex = 12;
            label7.Text = "Estado:";
            // 
            // btnguardar
            // 
            btnguardar.BackColor = Color.FromArgb(3, 171, 229);
            btnguardar.FlatStyle = FlatStyle.Popup;
            btnguardar.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold);
            btnguardar.Location = new Point(117, 344);
            btnguardar.Name = "btnguardar";
            btnguardar.Size = new Size(100, 38);
            btnguardar.TabIndex = 13;
            btnguardar.Text = "Guardar";
            btnguardar.UseVisualStyleBackColor = false;
            btnguardar.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(3, 171, 229);
            button2.FlatStyle = FlatStyle.Popup;
            button2.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold);
            button2.Location = new Point(390, 344);
            button2.Name = "button2";
            button2.Size = new Size(105, 38);
            button2.TabIndex = 14;
            button2.Text = "Cancelar";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.prohibido;
            pictureBox1.Location = new Point(339, 344);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(51, 38);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 15;
            pictureBox1.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(78, 344);
            pictureBox4.Margin = new Padding(2);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(39, 38);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 135;
            pictureBox4.TabStop = false;
            // 
            // txttelefonoproveedor
            // 
            txttelefonoproveedor.Location = new Point(81, 190);
            txttelefonoproveedor.Mask = "0000-0000";
            txttelefonoproveedor.Name = "txttelefonoproveedor";
            txttelefonoproveedor.Size = new Size(113, 27);
            txttelefonoproveedor.TabIndex = 136;
            // 
            // txtcodigorucproveedor
            // 
            txtcodigorucproveedor.Location = new Point(81, 119);
            txtcodigorucproveedor.Mask = "000-000000-0000>L";
            txtcodigorucproveedor.Name = "txtcodigorucproveedor";
            txtcodigorucproveedor.Size = new Size(136, 27);
            txtcodigorucproveedor.TabIndex = 137;
            // 
            // VentanaEmergenteProveedor
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(605, 437);
            Controls.Add(txtcodigorucproveedor);
            Controls.Add(txttelefonoproveedor);
            Controls.Add(pictureBox4);
            Controls.Add(pictureBox1);
            Controls.Add(button2);
            Controls.Add(btnguardar);
            Controls.Add(label7);
            Controls.Add(txtcorreoproveedor);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(txtapeliidoproveedor);
            Controls.Add(txtnombreproveedor);
            Controls.Add(label2);
            Controls.Add(cmbestado);
            Controls.Add(label1);
            MaximumSize = new Size(623, 484);
            MinimumSize = new Size(623, 484);
            Name = "VentanaEmergenteProveedor";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Agregar proveedor";
            Load += VentanaEmergenteProveedor_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cmbestado;
        private Label label2;
        private TextBox txtnombreproveedor;
        private TextBox txtapeliidoproveedor;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox txtcorreoproveedor;
        private Label label7;
        private Button btnguardar;
        private Button button2;
        private PictureBox pictureBox1;
        private PictureBox pictureBox4;
        private MaskedTextBox txttelefonoproveedor;
        private MaskedTextBox txtcodigorucproveedor;
    }
}