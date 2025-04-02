namespace formstienda
{
    partial class Login
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            label1 = new Label();
            linkLabel1 = new LinkLabel();
            error1 = new ErrorProvider(components);
            txtusername = new TextBox();
            txtpassword = new TextBox();
            btnIniciarSesion = new Button();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            label2 = new Label();
            label3 = new Label();
            pb_Password = new PictureBox();
            pictureBox2 = new PictureBox();
            btnminimizar = new PictureBox();
            btncerrar = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)error1).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pb_Password).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnminimizar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btncerrar).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Calisto MT", 24F, FontStyle.Bold);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(552, 11);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(265, 54);
            label1.TabIndex = 0;
            label1.Text = "Bienvenido";
            label1.TextAlign = ContentAlignment.TopCenter;
            label1.Click += label1_Click;
            // 
            // linkLabel1
            // 
            linkLabel1.ActiveLinkColor = Color.Black;
            linkLabel1.AutoSize = true;
            linkLabel1.BackColor = Color.FromArgb(238, 238, 238);
            linkLabel1.DisabledLinkColor = Color.Transparent;
            linkLabel1.Font = new Font("Calisto MT", 12F, FontStyle.Bold);
            linkLabel1.ForeColor = Color.Black;
            linkLabel1.LinkColor = Color.Black;
            linkLabel1.Location = new Point(541, 469);
            linkLabel1.Margin = new Padding(4, 0, 4, 0);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(315, 28);
            linkLabel1.TabIndex = 3;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "¿Ha olvidado la contraseña?";
            linkLabel1.VisitedLinkColor = Color.Black;
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // error1
            // 
            error1.ContainerControl = this;
            // 
            // txtusername
            // 
            txtusername.BackColor = Color.White;
            txtusername.BorderStyle = BorderStyle.FixedSingle;
            txtusername.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtusername.ForeColor = Color.Black;
            txtusername.Location = new Point(494, 172);
            txtusername.Margin = new Padding(4, 2, 4, 2);
            txtusername.Multiline = true;
            txtusername.Name = "txtusername";
            txtusername.Size = new Size(400, 36);
            txtusername.TabIndex = 9;
            txtusername.TextChanged += txtusuario_TextChanged;
            txtusername.Enter += txtusuario_Enter;
            txtusername.Leave += txtusuario_Leave;
            // 
            // txtpassword
            // 
            txtpassword.BackColor = Color.White;
            txtpassword.BorderStyle = BorderStyle.FixedSingle;
            txtpassword.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtpassword.ForeColor = Color.Black;
            txtpassword.Location = new Point(494, 290);
            txtpassword.Margin = new Padding(4, 2, 4, 2);
            txtpassword.Name = "txtpassword";
            txtpassword.Size = new Size(400, 35);
            txtpassword.TabIndex = 11;
            txtpassword.UseSystemPasswordChar = true;
            txtpassword.TextChanged += txtpassword_TextChanged;
            txtpassword.Enter += txtcontraseña_Enter;
            txtpassword.Leave += txtcontraseña_Leave;
            // 
            // btnIniciarSesion
            // 
            btnIniciarSesion.BackColor = Color.White;
            btnIniciarSesion.BackgroundImageLayout = ImageLayout.Zoom;
            btnIniciarSesion.FlatAppearance.BorderSize = 0;
            btnIniciarSesion.FlatAppearance.MouseDownBackColor = Color.White;
            btnIniciarSesion.FlatAppearance.MouseOverBackColor = Color.White;
            btnIniciarSesion.FlatStyle = FlatStyle.Popup;
            btnIniciarSesion.Font = new Font("Calisto MT", 10F, FontStyle.Bold);
            btnIniciarSesion.ForeColor = Color.Black;
            btnIniciarSesion.Location = new Point(605, 381);
            btnIniciarSesion.Margin = new Padding(4, 2, 4, 2);
            btnIniciarSesion.Name = "btnIniciarSesion";
            btnIniciarSesion.Size = new Size(179, 58);
            btnIniciarSesion.TabIndex = 12;
            btnIniciarSesion.Text = "Iniciar sesión\r\n";
            btnIniciarSesion.UseVisualStyleBackColor = false;
            btnIniciarSesion.Click += btnIniciarSesion_Click;
            btnIniciarSesion.Enter += pictureBox2_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(3, 171, 229);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(4, 2, 4, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(314, 625);
            panel1.TabIndex = 7;
            panel1.Paint += panel1_Paint_1;
            panel1.MouseDown += panel1_MouseDown;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.logo_actualizado_removebg_preview;
            pictureBox1.Location = new Point(-141, 74);
            pictureBox1.Margin = new Padding(4, 2, 4, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(580, 468);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Calisto MT", 12F, FontStyle.Bold);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(489, 132);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(99, 28);
            label2.TabIndex = 15;
            label2.Text = "Usuario";
            label2.Click += label2_Click_1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Calisto MT", 12F, FontStyle.Bold);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(489, 251);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(138, 28);
            label3.TabIndex = 16;
            label3.Text = "Contraseña";
            label3.Click += label3_Click_1;
            // 
            // pb_Password
            // 
            pb_Password.Image = Properties.Resources.Mostrar_Contraseña;
            pb_Password.Location = new Point(901, 285);
            pb_Password.Margin = new Padding(4, 5, 4, 5);
            pb_Password.Name = "pb_Password";
            pb_Password.Size = new Size(44, 48);
            pb_Password.SizeMode = PictureBoxSizeMode.Zoom;
            pb_Password.TabIndex = 18;
            pb_Password.TabStop = false;
            pb_Password.Click += pb_Password_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(559, 392);
            pictureBox2.Margin = new Padding(4, 2, 4, 2);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(39, 39);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 17;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // btnminimizar
            // 
            btnminimizar.Image = (Image)resources.GetObject("btnminimizar.Image");
            btnminimizar.Location = new Point(1008, 0);
            btnminimizar.Margin = new Padding(4, 2, 4, 2);
            btnminimizar.Name = "btnminimizar";
            btnminimizar.Size = new Size(50, 42);
            btnminimizar.SizeMode = PictureBoxSizeMode.StretchImage;
            btnminimizar.TabIndex = 14;
            btnminimizar.TabStop = false;
            btnminimizar.Click += btnminimizar_Click;
            // 
            // btncerrar
            // 
            btncerrar.Image = (Image)resources.GetObject("btncerrar.Image");
            btncerrar.Location = new Point(1065, 0);
            btncerrar.Margin = new Padding(4, 2, 4, 2);
            btncerrar.Name = "btncerrar";
            btncerrar.Size = new Size(46, 42);
            btncerrar.SizeMode = PictureBoxSizeMode.Zoom;
            btncerrar.TabIndex = 13;
            btncerrar.TabStop = false;
            btncerrar.Click += pictureBox1_Click_1;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(238, 238, 238);
            ClientSize = new Size(1111, 625);
            Controls.Add(pb_Password);
            Controls.Add(pictureBox2);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(btnminimizar);
            Controls.Add(btncerrar);
            Controls.Add(btnIniciarSesion);
            Controls.Add(txtpassword);
            Controls.Add(txtusername);
            Controls.Add(panel1);
            Controls.Add(linkLabel1);
            Controls.Add(label1);
            ForeColor = SystemColors.ControlText;
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 6, 4, 6);
            MaximumSize = new Size(1111, 625);
            MinimumSize = new Size(1111, 625);
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            Load += Form1_Load;
            MouseDown += Form1_MouseDown;
            ((System.ComponentModel.ISupportInitialize)error1).EndInit();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pb_Password).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnminimizar).EndInit();
            ((System.ComponentModel.ISupportInitialize)btncerrar).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.ErrorProvider error1;
        private System.Windows.Forms.TextBox txtusername;
        private System.Windows.Forms.TextBox txtpassword;
        private System.Windows.Forms.Button btnIniciarSesion;
        private System.Windows.Forms.PictureBox btncerrar;
        private System.Windows.Forms.PictureBox btnminimizar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pb_Password;
    }
}

