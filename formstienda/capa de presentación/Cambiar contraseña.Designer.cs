namespace formstienda.capa_de_presentación
{
    partial class Cambiar_contraseña
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
            btnCambiar_Contraseña = new Button();
            label1 = new Label();
            txtCambiarContraseña = new TextBox();
            txtContraseñaNueva = new TextBox();
            label2 = new Label();
            label3 = new Label();
            txtconfirmarcontraseña = new TextBox();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnCambiar_Contraseña
            // 
            btnCambiar_Contraseña.BackColor = Color.White;
            btnCambiar_Contraseña.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            btnCambiar_Contraseña.Location = new Point(456, 329);
            btnCambiar_Contraseña.Margin = new Padding(2);
            btnCambiar_Contraseña.Name = "btnCambiar_Contraseña";
            btnCambiar_Contraseña.Size = new Size(143, 35);
            btnCambiar_Contraseña.TabIndex = 0;
            btnCambiar_Contraseña.Text = "Cambiar";
            btnCambiar_Contraseña.UseVisualStyleBackColor = false;
            btnCambiar_Contraseña.Click += btnCambiar_Contraseña_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            label1.Location = new Point(402, 37);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(208, 23);
            label1.TabIndex = 1;
            label1.Text = "Código de recuperación";
            // 
            // txtCambiarContraseña
            // 
            txtCambiarContraseña.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            txtCambiarContraseña.Location = new Point(402, 81);
            txtCambiarContraseña.Margin = new Padding(2);
            txtCambiarContraseña.Name = "txtCambiarContraseña";
            txtCambiarContraseña.Size = new Size(244, 30);
            txtCambiarContraseña.TabIndex = 2;
            // 
            // txtContraseñaNueva
            // 
            txtContraseñaNueva.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            txtContraseñaNueva.Location = new Point(402, 171);
            txtContraseñaNueva.Margin = new Padding(2);
            txtContraseñaNueva.Name = "txtContraseñaNueva";
            txtContraseñaNueva.Size = new Size(244, 30);
            txtContraseñaNueva.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            label2.Location = new Point(402, 130);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(162, 23);
            label2.TabIndex = 4;
            label2.Text = "Nueva contraseña";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            label3.Location = new Point(402, 226);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(179, 23);
            label3.TabIndex = 5;
            label3.Text = "Repetir contraseña:";
            // 
            // txtconfirmarcontraseña
            // 
            txtconfirmarcontraseña.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            txtconfirmarcontraseña.Location = new Point(402, 268);
            txtconfirmarcontraseña.Margin = new Padding(2);
            txtconfirmarcontraseña.Name = "txtconfirmarcontraseña";
            txtconfirmarcontraseña.Size = new Size(244, 30);
            txtconfirmarcontraseña.TabIndex = 6;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(3, 171, 229);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(272, 401);
            panel1.TabIndex = 7;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.LOGOVERSIONCORREGIDAJUDC;
            pictureBox1.Location = new Point(-56, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(378, 341);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // Cambiar_contraseña
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(749, 401);
            Controls.Add(panel1);
            Controls.Add(txtconfirmarcontraseña);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtContraseñaNueva);
            Controls.Add(txtCambiarContraseña);
            Controls.Add(label1);
            Controls.Add(btnCambiar_Contraseña);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(2);
            MaximumSize = new Size(749, 401);
            MinimumSize = new Size(749, 401);
            Name = "Cambiar_contraseña";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cambiar_contraseña";
            Load += Cambiar_contraseña_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCambiar_Contraseña;
        private Label label1;
        private TextBox txtCambiarContraseña;
        private TextBox txtContraseñaNueva;
        private Label label2;
        private Label label3;
        private TextBox txtconfirmarcontraseña;
        private Panel panel1;
        private PictureBox pictureBox1;
    }
}