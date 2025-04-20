namespace formstienda
{
    partial class Apertura_Caja
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
            panel1 = new Panel();
            txtapertura = new TextBox();
            txttasadecambio = new TextBox();
            btnabrircaja = new Button();
            button2 = new Button();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Calisto MT", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(96, 65);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(151, 20);
            label1.TabIndex = 0;
            label1.Text = "Monto de apertura:";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Transparent;
            label2.Location = new Point(78, 11);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(183, 25);
            label2.TabIndex = 1;
            label2.Text = "Apertura de caja";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Calisto MT", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(106, 131);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(131, 20);
            label3.TabIndex = 2;
            label3.Text = "Tasa de cambio:";
            label3.Click += label3_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(3, 171, 229);
            panel1.Controls.Add(label2);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(4, 5, 4, 5);
            panel1.Name = "panel1";
            panel1.Size = new Size(343, 51);
            panel1.TabIndex = 3;
            // 
            // txtapertura
            // 
            txtapertura.Location = new Point(70, 95);
            txtapertura.Margin = new Padding(4, 5, 4, 5);
            txtapertura.Name = "txtapertura";
            txtapertura.Size = new Size(216, 27);
            txtapertura.TabIndex = 4;
            // 
            // txttasadecambio
            // 
            txttasadecambio.Location = new Point(70, 158);
            txttasadecambio.Margin = new Padding(4, 5, 4, 5);
            txttasadecambio.Name = "txttasadecambio";
            txttasadecambio.Size = new Size(216, 27);
            txttasadecambio.TabIndex = 5;
            // 
            // btnabrircaja
            // 
            btnabrircaja.BackColor = Color.FromArgb(3, 171, 229);
            btnabrircaja.FlatAppearance.BorderColor = Color.FromArgb(3, 171, 229);
            btnabrircaja.FlatStyle = FlatStyle.Popup;
            btnabrircaja.Font = new Font("Calisto MT", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnabrircaja.Location = new Point(17, 215);
            btnabrircaja.Margin = new Padding(4, 5, 4, 5);
            btnabrircaja.Name = "btnabrircaja";
            btnabrircaja.Size = new Size(123, 45);
            btnabrircaja.TabIndex = 6;
            btnabrircaja.Text = "Abrir caja";
            btnabrircaja.UseVisualStyleBackColor = false;
            btnabrircaja.Click += btnabrircaja_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(3, 171, 229);
            button2.FlatAppearance.BorderColor = Color.FromArgb(3, 171, 229);
            button2.FlatStyle = FlatStyle.Popup;
            button2.Font = new Font("Calisto MT", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(198, 215);
            button2.Margin = new Padding(4, 5, 4, 5);
            button2.Name = "button2";
            button2.Size = new Size(127, 45);
            button2.TabIndex = 7;
            button2.Text = "Cancelar";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.desbloquear;
            pictureBox2.Location = new Point(70, 283);
            pictureBox2.Margin = new Padding(3, 4, 3, 4);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(45, 35);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 9;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.prohibido;
            pictureBox1.Location = new Point(233, 283);
            pictureBox1.Margin = new Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(45, 35);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // Apertura_Caja
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(343, 339);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(button2);
            Controls.Add(btnabrircaja);
            Controls.Add(txttasadecambio);
            Controls.Add(txtapertura);
            Controls.Add(panel1);
            Controls.Add(label3);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 5, 4, 5);
            MaximumSize = new Size(343, 339);
            MinimumSize = new Size(343, 339);
            Name = "Apertura_Caja";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Apertura_Caja";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtapertura;
        private System.Windows.Forms.TextBox txttasadecambio;
        private System.Windows.Forms.Button btnabrircaja;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}