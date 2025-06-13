namespace formstienda
{
    partial class Mantenimiento
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            button3 = new Button();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            btnCargar = new Button();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Calisto MT", 18F, FontStyle.Bold);
            label1.Location = new Point(369, 11);
            label1.Name = "label1";
            label1.Size = new Size(224, 34);
            label1.TabIndex = 0;
            label1.Text = "Mantenimiento ";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Font = new Font("Calisto MT", 16F, FontStyle.Bold);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(95, 438);
            label2.Name = "label2";
            label2.Size = new Size(318, 31);
            label2.TabIndex = 1;
            label2.Text = "Crear copia de seguridad ";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.Font = new Font("Calisto MT", 16F, FontStyle.Bold);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(617, 438);
            label3.Name = "label3";
            label3.Size = new Size(330, 31);
            label3.TabIndex = 2;
            label3.Text = "Modificar la base de datos ";
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button3.BackColor = Color.FromArgb(3, 171, 229);
            button3.Cursor = Cursors.Hand;
            button3.FlatStyle = FlatStyle.Popup;
            button3.Font = new Font("Calisto MT", 12F, FontStyle.Bold);
            button3.Location = new Point(16, 580);
            button3.Name = "button3";
            button3.Size = new Size(115, 48);
            button3.TabIndex = 32;
            button3.Text = "Salir";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Anchor = AnchorStyles.None;
            pictureBox2.Image = Properties.Resources.recuperacion;
            pictureBox2.Location = new Point(651, 114);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(219, 322);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 4;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.None;
            pictureBox1.Image = Properties.Resources.gestion_de_base_de_datos;
            pictureBox1.Location = new Point(145, 114);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(203, 322);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // btnCargar
            // 
            btnCargar.Anchor = AnchorStyles.None;
            btnCargar.BackColor = Color.FromArgb(3, 171, 229);
            btnCargar.Cursor = Cursors.Hand;
            btnCargar.FlatStyle = FlatStyle.Popup;
            btnCargar.Font = new Font("Calisto MT", 12F, FontStyle.Bold);
            btnCargar.Location = new Point(704, 503);
            btnCargar.Name = "btnCargar";
            btnCargar.Size = new Size(116, 45);
            btnCargar.TabIndex = 33;
            btnCargar.Text = "Cargar";
            btnCargar.UseVisualStyleBackColor = false;
            btnCargar.Click += button1_Click;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.None;
            button2.BackColor = Color.FromArgb(3, 171, 229);
            button2.Cursor = Cursors.Hand;
            button2.FlatStyle = FlatStyle.Popup;
            button2.Font = new Font("Calisto MT", 12F, FontStyle.Bold);
            button2.Location = new Point(183, 503);
            button2.Name = "button2";
            button2.Size = new Size(116, 45);
            button2.TabIndex = 34;
            button2.Text = "Crear";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // Mantenimiento
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(238, 238, 238);
            ClientSize = new Size(981, 642);
            Controls.Add(button2);
            Controls.Add(btnCargar);
            Controls.Add(button3);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            ForeColor = Color.Black;
            FormBorderStyle = FormBorderStyle.None;
            MinimumSize = new Size(819, 640);
            Name = "Mantenimiento";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Mantenimiento";
            Load += Form7_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnCargar;
        private System.Windows.Forms.Button button2;
    }
}