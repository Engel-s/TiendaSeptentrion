namespace formstienda
{
    partial class Recuperarcontraseña
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Recuperarcontraseña));
            pictureBox2 = new PictureBox();
            label2 = new Label();
            btnIniciarSesion = new Button();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            txtusername = new TextBox();
            label3 = new Label();
            linkLabel1 = new LinkLabel();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(435, 314);
            pictureBox2.Margin = new Padding(3, 2, 3, 2);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(31, 31);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 28;
            pictureBox2.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Calisto MT", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(327, 236);
            label2.Name = "label2";
            label2.Size = new Size(62, 20);
            label2.TabIndex = 26;
            label2.Text = "Correo";
            // 
            // btnIniciarSesion
            // 
            btnIniciarSesion.BackColor = Color.White;
            btnIniciarSesion.BackgroundImageLayout = ImageLayout.Zoom;
            btnIniciarSesion.FlatAppearance.BorderSize = 0;
            btnIniciarSesion.FlatAppearance.MouseDownBackColor = Color.White;
            btnIniciarSesion.FlatAppearance.MouseOverBackColor = Color.White;
            btnIniciarSesion.FlatStyle = FlatStyle.Popup;
            btnIniciarSesion.Font = new Font("Calisto MT", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnIniciarSesion.ForeColor = Color.Black;
            btnIniciarSesion.Location = new Point(472, 314);
            btnIniciarSesion.Margin = new Padding(3, 2, 3, 2);
            btnIniciarSesion.Name = "btnIniciarSesion";
            btnIniciarSesion.Size = new Size(143, 46);
            btnIniciarSesion.TabIndex = 23;
            btnIniciarSesion.Text = "Recuperar";
            btnIniciarSesion.UseVisualStyleBackColor = false;
            btnIniciarSesion.Click += btnIniciarSesion_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(3, 171, 229);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(251, 510);
            panel1.TabIndex = 20;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.logo_actualizado_removebg_preview;
            pictureBox1.Location = new Point(-113, 59);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(464, 374);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Calisto MT", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(337, 70);
            label1.Name = "label1";
            label1.Size = new Size(399, 46);
            label1.TabIndex = 18;
            label1.Text = "Recuperar contraseña";
            label1.TextAlign = ContentAlignment.TopCenter;
            label1.Click += label1_Click;
            // 
            // txtusername
            // 
            txtusername.BackColor = Color.White;
            txtusername.BorderStyle = BorderStyle.FixedSingle;
            txtusername.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtusername.ForeColor = Color.Black;
            txtusername.Location = new Point(419, 236);
            txtusername.Margin = new Padding(3, 2, 3, 2);
            txtusername.Multiline = true;
            txtusername.Name = "txtusername";
            txtusername.Size = new Size(320, 37);
            txtusername.TabIndex = 21;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Calisto MT", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(310, 170);
            label3.Name = "label3";
            label3.Size = new Size(377, 20);
            label3.TabIndex = 29;
            label3.Text = "Por favor ingresar el correo asociado a su usuario.";
            // 
            // linkLabel1
            // 
            linkLabel1.ActiveLinkColor = Color.Black;
            linkLabel1.AutoSize = true;
            linkLabel1.BackColor = Color.FromArgb(238, 238, 238);
            linkLabel1.DisabledLinkColor = Color.Transparent;
            linkLabel1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            linkLabel1.ForeColor = Color.Black;
            linkLabel1.LinkColor = Color.Black;
            linkLabel1.Location = new Point(430, 390);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(231, 25);
            linkLabel1.TabIndex = 19;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "¿Desea iniciar sesión?";
            linkLabel1.VisitedLinkColor = Color.Black;
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // Recuperarcontraseña
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(855, 510);
            Controls.Add(label3);
            Controls.Add(pictureBox2);
            Controls.Add(label2);
            Controls.Add(btnIniciarSesion);
            Controls.Add(txtusername);
            Controls.Add(panel1);
            Controls.Add(linkLabel1);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "Recuperarcontraseña";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form5";
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnIniciarSesion;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtusername;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}