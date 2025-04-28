namespace formstienda
{
    partial class Usuarioadmin
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
            label1 = new Label();
            label2 = new Label();
            cbtipobusqueda = new ComboBox();
            textBox1 = new TextBox();
            label3 = new Label();
<<<<<<< HEAD
            txtnombreusuario = new TextBox();
            btnactualizarusuario = new Button();
            label6 = new Label();
=======
            label4 = new Label();
            txtnombreusuario = new TextBox();
            txtusername = new TextBox();
            btnactualizarusuario = new Button();
            label6 = new Label();
            txttelefonousuario = new TextBox();
>>>>>>> productos
            button3 = new Button();
            btnnuevousuario = new Button();
            label5 = new Label();
            txtpassword = new TextBox();
            DGUSUARIOS = new DataGridView();
<<<<<<< HEAD
=======
            eliminar = new DataGridViewTextBoxColumn();
>>>>>>> productos
            cbrolusuario = new ComboBox();
            cbestadousuario = new ComboBox();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            txtcorreousuario = new TextBox();
            label10 = new Label();
            txtapellidousuario = new TextBox();
            pictureBox1 = new PictureBox();
            btneliminar = new Button();
<<<<<<< HEAD
            txttelefonousuario = new MaskedTextBox();
            mensajes = new ToolTip(components);
=======
>>>>>>> productos
            ((System.ComponentModel.ISupportInitialize)DGUSUARIOS).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Calisto MT", 14F, FontStyle.Bold);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(178, 17);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(311, 28);
            label1.TabIndex = 0;
            label1.Text = "Administración de usuarios";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Calisto MT", 12F, FontStyle.Bold);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(12, 72);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(114, 22);
            label2.TabIndex = 1;
            label2.Text = "Buscar por ";
            label2.Click += label2_Click;
            // 
            // cbtipobusqueda
            // 
            cbtipobusqueda.DropDownStyle = ComboBoxStyle.DropDownList;
            cbtipobusqueda.FormattingEnabled = true;
            cbtipobusqueda.Items.AddRange(new object[] { "ID", "Nombre" });
            cbtipobusqueda.Location = new Point(166, 72);
            cbtipobusqueda.Margin = new Padding(2, 5, 2, 5);
            cbtipobusqueda.Name = "cbtipobusqueda";
            cbtipobusqueda.Size = new Size(100, 28);
            cbtipobusqueda.TabIndex = 2;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(284, 75);
            textBox1.Margin = new Padding(2, 5, 2, 5);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(286, 27);
            textBox1.TabIndex = 3;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            label3.AutoSize = true;
            label3.Font = new Font("Calisto MT", 12F, FontStyle.Bold);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(12, 127);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(93, 22);
            label3.TabIndex = 4;
            label3.Text = "Nombre:";
            label3.Click += label3_Click;
            // 
            // txtnombreusuario
            // 
<<<<<<< HEAD
            txtnombreusuario.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            txtnombreusuario.Location = new Point(198, 126);
            txtnombreusuario.Margin = new Padding(2, 5, 2, 5);
            txtnombreusuario.Name = "txtnombreusuario";
            txtnombreusuario.Size = new Size(214, 27);
            txtnombreusuario.TabIndex = 8;
            // 
            // btnactualizarusuario
            // 
=======
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            label4.AutoSize = true;
            label4.Font = new Font("Calisto MT", 12F, FontStyle.Bold);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(538, 125);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(92, 22);
            label4.TabIndex = 5;
            label4.Text = "Usuario:";
            label4.Click += label4_Click;
            // 
            // txtnombreusuario
            // 
            txtnombreusuario.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            txtnombreusuario.Location = new Point(198, 126);
            txtnombreusuario.Margin = new Padding(2, 5, 2, 5);
            txtnombreusuario.Name = "txtnombreusuario";
            txtnombreusuario.Size = new Size(214, 27);
            txtnombreusuario.TabIndex = 8;
            // 
            // txtusername
            // 
            txtusername.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            txtusername.Location = new Point(726, 127);
            txtusername.Margin = new Padding(2, 5, 2, 5);
            txtusername.Name = "txtusername";
            txtusername.Size = new Size(214, 27);
            txtusername.TabIndex = 9;
            // 
            // btnactualizarusuario
            // 
>>>>>>> productos
            btnactualizarusuario.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnactualizarusuario.BackColor = Color.FromArgb(3, 171, 229);
            btnactualizarusuario.Cursor = Cursors.Hand;
            btnactualizarusuario.FlatStyle = FlatStyle.Popup;
            btnactualizarusuario.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnactualizarusuario.Location = new Point(968, 177);
            btnactualizarusuario.Margin = new Padding(2, 5, 2, 5);
            btnactualizarusuario.Name = "btnactualizarusuario";
            btnactualizarusuario.Size = new Size(146, 40);
            btnactualizarusuario.TabIndex = 10;
            btnactualizarusuario.Text = "Actualizar ";
            btnactualizarusuario.UseVisualStyleBackColor = false;
            btnactualizarusuario.Click += btnactualizar_Click;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            label6.AutoSize = true;
            label6.Font = new Font("Calisto MT", 12F, FontStyle.Bold);
            label6.ForeColor = Color.Black;
            label6.Location = new Point(11, 205);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new Size(99, 22);
            label6.TabIndex = 11;
            label6.Text = "Teléfono:";
            label6.Click += label6_Click;
            // 
<<<<<<< HEAD
=======
            // txttelefonousuario
            // 
            txttelefonousuario.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            txttelefonousuario.Location = new Point(199, 205);
            txttelefonousuario.Margin = new Padding(2, 5, 2, 5);
            txttelefonousuario.Name = "txttelefonousuario";
            txttelefonousuario.Size = new Size(214, 27);
            txttelefonousuario.TabIndex = 12;
            // 
>>>>>>> productos
            // button3
            // 
            button3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button3.BackColor = Color.FromArgb(3, 171, 229);
            button3.Cursor = Cursors.Hand;
            button3.FlatStyle = FlatStyle.Popup;
            button3.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.Location = new Point(968, 232);
            button3.Margin = new Padding(2, 5, 2, 5);
            button3.Name = "button3";
            button3.Size = new Size(146, 40);
            button3.TabIndex = 32;
            button3.Text = "Salir";
            button3.UseVisualStyleBackColor = false;
            button3.Click += Button3_Click;
            // 
            // btnnuevousuario
            // 
            btnnuevousuario.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnnuevousuario.BackColor = Color.FromArgb(3, 171, 229);
            btnnuevousuario.Cursor = Cursors.Hand;
            btnnuevousuario.FlatStyle = FlatStyle.Popup;
            btnnuevousuario.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnnuevousuario.Location = new Point(968, 127);
            btnnuevousuario.Margin = new Padding(2, 5, 2, 5);
            btnnuevousuario.Name = "btnnuevousuario";
            btnnuevousuario.Size = new Size(146, 40);
            btnnuevousuario.TabIndex = 33;
            btnnuevousuario.Text = "Nuevo";
            btnnuevousuario.UseVisualStyleBackColor = false;
            btnnuevousuario.Click += btnnuevo_Click;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            label5.AutoSize = true;
            label5.Font = new Font("Calisto MT", 12F, FontStyle.Bold);
            label5.ForeColor = Color.Black;
<<<<<<< HEAD
            label5.Location = new Point(536, 126);
=======
            label5.Location = new Point(538, 164);
>>>>>>> productos
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(123, 22);
            label5.TabIndex = 34;
            label5.Text = "Contraseña:";
            label5.Click += label5_Click;
            // 
            // txtpassword
            // 
            txtpassword.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
<<<<<<< HEAD
            txtpassword.Location = new Point(724, 124);
=======
            txtpassword.Location = new Point(726, 162);
>>>>>>> productos
            txtpassword.Margin = new Padding(2, 5, 2, 5);
            txtpassword.Name = "txtpassword";
            txtpassword.Size = new Size(214, 27);
            txtpassword.TabIndex = 35;
            // 
            // DGUSUARIOS
            // 
            DGUSUARIOS.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DGUSUARIOS.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DGUSUARIOS.BackgroundColor = Color.FromArgb(238, 238, 238);
            DGUSUARIOS.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
<<<<<<< HEAD
=======
            DGUSUARIOS.Columns.AddRange(new DataGridViewColumn[] { eliminar });
>>>>>>> productos
            DGUSUARIOS.Location = new Point(12, 323);
            DGUSUARIOS.Margin = new Padding(2);
            DGUSUARIOS.Name = "DGUSUARIOS";
            DGUSUARIOS.RowHeadersWidth = 51;
            DGUSUARIOS.RowTemplate.Height = 24;
            DGUSUARIOS.Size = new Size(1237, 417);
            DGUSUARIOS.TabIndex = 37;
            DGUSUARIOS.CellContentClick += DGUSUARIOS_CellContentClick;
            DGUSUARIOS.CellEndEdit += DGUSUARIOS_CellEndEdit;
            // 
<<<<<<< HEAD
            // cbrolusuario
            // 
            cbrolusuario.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            cbrolusuario.DropDownStyle = ComboBoxStyle.DropDownList;
            cbrolusuario.FormattingEnabled = true;
            cbrolusuario.Items.AddRange(new object[] { "Administrador", "Cajero" });
            cbrolusuario.Location = new Point(737, 210);
            cbrolusuario.Margin = new Padding(2, 5, 2, 5);
            cbrolusuario.Name = "cbrolusuario";
            cbrolusuario.Size = new Size(126, 28);
            cbrolusuario.TabIndex = 38;
            // 
            // cbestadousuario
            // 
=======
            // eliminar
            // 
            eliminar.HeaderText = "Eliminar";
            eliminar.MinimumWidth = 6;
            eliminar.Name = "eliminar";
            // 
            // cbrolusuario
            // 
            cbrolusuario.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            cbrolusuario.DropDownStyle = ComboBoxStyle.DropDownList;
            cbrolusuario.FormattingEnabled = true;
            cbrolusuario.Items.AddRange(new object[] { "Administrador", "Cajero" });
            cbrolusuario.Location = new Point(739, 248);
            cbrolusuario.Margin = new Padding(2, 5, 2, 5);
            cbrolusuario.Name = "cbrolusuario";
            cbrolusuario.Size = new Size(126, 28);
            cbrolusuario.TabIndex = 38;
            // 
            // cbestadousuario
            // 
>>>>>>> productos
            cbestadousuario.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            cbestadousuario.DropDownStyle = ComboBoxStyle.DropDownList;
            cbestadousuario.FormattingEnabled = true;
            cbestadousuario.Items.AddRange(new object[] { "Activo", "Inactivo" });
<<<<<<< HEAD
            cbestadousuario.Location = new Point(737, 168);
=======
            cbestadousuario.Location = new Point(739, 206);
>>>>>>> productos
            cbestadousuario.Margin = new Padding(2, 5, 2, 5);
            cbestadousuario.Name = "cbestadousuario";
            cbestadousuario.Size = new Size(126, 28);
            cbestadousuario.TabIndex = 39;
            cbestadousuario.SelectedIndexChanged += comboBox3_SelectedIndexChanged;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            label7.AutoSize = true;
            label7.Font = new Font("Calisto MT", 12F, FontStyle.Bold);
            label7.ForeColor = Color.Black;
<<<<<<< HEAD
            label7.Location = new Point(551, 212);
=======
            label7.Location = new Point(553, 250);
>>>>>>> productos
            label7.Margin = new Padding(2, 0, 2, 0);
            label7.Name = "label7";
            label7.Size = new Size(51, 22);
            label7.TabIndex = 40;
            label7.Text = "Rol:";
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            label8.AutoSize = true;
            label8.Font = new Font("Calisto MT", 12F, FontStyle.Bold);
            label8.ForeColor = Color.Black;
<<<<<<< HEAD
            label8.Location = new Point(551, 170);
=======
            label8.Location = new Point(553, 208);
>>>>>>> productos
            label8.Margin = new Padding(2, 0, 2, 0);
            label8.Name = "label8";
            label8.Size = new Size(77, 22);
            label8.TabIndex = 41;
            label8.Text = "Estado:";
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            label9.AutoSize = true;
            label9.Font = new Font("Calisto MT", 12F, FontStyle.Bold);
            label9.ForeColor = Color.Black;
            label9.Location = new Point(11, 241);
            label9.Margin = new Padding(2, 0, 2, 0);
            label9.Name = "label9";
            label9.Size = new Size(84, 22);
            label9.TabIndex = 42;
            label9.Text = "Correo:";
            // 
            // txtcorreousuario
            // 
            txtcorreousuario.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            txtcorreousuario.Location = new Point(199, 240);
            txtcorreousuario.Margin = new Padding(2, 5, 2, 5);
            txtcorreousuario.Name = "txtcorreousuario";
            txtcorreousuario.Size = new Size(214, 27);
            txtcorreousuario.TabIndex = 43;
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            label10.AutoSize = true;
            label10.Font = new Font("Calisto MT", 12F, FontStyle.Bold);
            label10.ForeColor = Color.Black;
            label10.Location = new Point(10, 159);
            label10.Margin = new Padding(2, 0, 2, 0);
            label10.Name = "label10";
            label10.Size = new Size(97, 22);
            label10.TabIndex = 44;
            label10.Text = "Apellido:";
            // 
            // txtapellidousuario
            // 
            txtapellidousuario.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            txtapellidousuario.Location = new Point(198, 163);
            txtapellidousuario.Margin = new Padding(2, 5, 2, 5);
            txtapellidousuario.Name = "txtapellidousuario";
            txtapellidousuario.Size = new Size(214, 27);
            txtapellidousuario.TabIndex = 45;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.busque_un_simbolo_de_interfaz_de_persona_de_una_lupa_en_forma_de_hombre;
            pictureBox1.Location = new Point(589, 72);
            pictureBox1.Margin = new Padding(2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(36, 35);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 46;
            pictureBox1.TabStop = false;
            // 
            // btneliminar
            // 
            btneliminar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btneliminar.BackColor = Color.FromArgb(3, 171, 229);
            btneliminar.Cursor = Cursors.Hand;
            btneliminar.FlatStyle = FlatStyle.Popup;
            btneliminar.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btneliminar.Location = new Point(968, 75);
            btneliminar.Margin = new Padding(2, 5, 2, 5);
            btneliminar.Name = "btneliminar";
            btneliminar.Size = new Size(146, 40);
            btneliminar.TabIndex = 47;
            btneliminar.Text = "Eliminar";
            btneliminar.UseVisualStyleBackColor = false;
            btneliminar.Click += btneliminar_Click;
            // 
<<<<<<< HEAD
            // txttelefonousuario
            // 
            txttelefonousuario.Location = new Point(198, 205);
            txttelefonousuario.Mask = "0000-0000";
            txttelefonousuario.Name = "txttelefonousuario";
            txttelefonousuario.Size = new Size(215, 27);
            txttelefonousuario.TabIndex = 48;
            txttelefonousuario.TextAlign = HorizontalAlignment.Center;
            // 
            // mensajes
            // 
            mensajes.BackColor = SystemColors.GradientActiveCaption;
            mensajes.ForeColor = Color.Black;
            mensajes.IsBalloon = true;
            mensajes.OwnerDraw = true;
            mensajes.ToolTipIcon = ToolTipIcon.Info;
            // 
=======
>>>>>>> productos
            // Usuarioadmin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(238, 238, 238);
            ClientSize = new Size(1273, 775);
<<<<<<< HEAD
            Controls.Add(txttelefonousuario);
=======
>>>>>>> productos
            Controls.Add(btneliminar);
            Controls.Add(pictureBox1);
            Controls.Add(txtapellidousuario);
            Controls.Add(label10);
            Controls.Add(txtcorreousuario);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(cbestadousuario);
            Controls.Add(cbrolusuario);
            Controls.Add(DGUSUARIOS);
            Controls.Add(txtpassword);
            Controls.Add(label5);
            Controls.Add(btnnuevousuario);
            Controls.Add(button3);
<<<<<<< HEAD
            Controls.Add(label6);
            Controls.Add(btnactualizarusuario);
            Controls.Add(txtnombreusuario);
=======
            Controls.Add(txttelefonousuario);
            Controls.Add(label6);
            Controls.Add(btnactualizarusuario);
            Controls.Add(txtusername);
            Controls.Add(txtnombreusuario);
            Controls.Add(label4);
>>>>>>> productos
            Controls.Add(label3);
            Controls.Add(textBox1);
            Controls.Add(cbtipobusqueda);
            Controls.Add(label2);
            Controls.Add(label1);
            ForeColor = Color.Black;
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(2, 5, 2, 5);
            Name = "Usuarioadmin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Usuarios";
            Load += Form9_Load;
            ((System.ComponentModel.ISupportInitialize)DGUSUARIOS).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbtipobusqueda;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
<<<<<<< HEAD
        private System.Windows.Forms.TextBox txtnombreusuario;
        private System.Windows.Forms.Button btnactualizarusuario;
        private System.Windows.Forms.Label label6;
=======
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtnombreusuario;
        private System.Windows.Forms.TextBox txtusername;
        private System.Windows.Forms.Button btnactualizarusuario;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txttelefonousuario;
>>>>>>> productos
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnnuevousuario;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtpassword;
        private System.Windows.Forms.DataGridView DGUSUARIOS;
        private System.Windows.Forms.ComboBox cbrolusuario;
        private System.Windows.Forms.ComboBox cbestadousuario;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtcorreousuario;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtapellidousuario;
        private PictureBox pictureBox1;
<<<<<<< HEAD
        private Button btneliminar;
        private MaskedTextBox txttelefonousuario;
        private ToolTip mensajes;
=======
        private DataGridViewTextBoxColumn eliminar;
        private Button btneliminar;
>>>>>>> productos
    }
}