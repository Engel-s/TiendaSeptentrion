namespace formstienda.capa_de_presentación
{
    partial class Clientes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Clientes));
            pictureBox1 = new PictureBox();
            panel1 = new Panel();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txttelefonocliente = new TextBox();
            txtnombrecliente = new TextBox();
            label6 = new Label();
            txtdireccion = new RichTextBox();
            button2 = new Button();
            button1 = new Button();
            btnregistrar = new Button();
            txtcedula = new RichTextBox();
            label8 = new Label();
            label1 = new Label();
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            label9 = new Label();
            txtcolillainss = new TextBox();
            label5 = new Label();
            txtapellidocliente = new TextBox();
            dateTimePicker1 = new DateTimePicker();
            DGCLIENTES = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DGCLIENTES).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Bottom;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 67);
            pictureBox1.Margin = new Padding(2, 3, 2, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(834, 90);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(3, 171, 229);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(2, 3, 2, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(834, 157);
            panel1.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Calisto MT", 10F, FontStyle.Bold);
            label2.Location = new Point(14, 178);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(75, 20);
            label2.TabIndex = 3;
            label2.Text = "Nombre:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Calisto MT", 10F, FontStyle.Bold);
            label3.Location = new Point(14, 263);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(84, 20);
            label3.TabIndex = 4;
            label3.Text = "Teléfono: ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Calisto MT", 10F, FontStyle.Bold);
            label4.Location = new Point(486, 186);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(59, 20);
            label4.TabIndex = 5;
            label4.Text = "Fecha:";
            // 
            // txttelefonocliente
            // 
            txttelefonocliente.Font = new Font("Calisto MT", 10F, FontStyle.Bold);
            txttelefonocliente.Location = new Point(118, 263);
            txttelefonocliente.Margin = new Padding(2, 3, 2, 3);
            txttelefonocliente.Name = "txttelefonocliente";
            txttelefonocliente.Size = new Size(146, 27);
            txttelefonocliente.TabIndex = 8;
            // 
            // txtnombrecliente
            // 
            txtnombrecliente.Font = new Font("Calisto MT", 10F, FontStyle.Bold);
            txtnombrecliente.Location = new Point(118, 178);
            txtnombrecliente.Margin = new Padding(2, 3, 2, 3);
            txtnombrecliente.Name = "txtnombrecliente";
            txtnombrecliente.Size = new Size(214, 27);
            txtnombrecliente.TabIndex = 10;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Calisto MT", 10F, FontStyle.Bold);
            label6.Location = new Point(368, 378);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new Size(88, 20);
            label6.TabIndex = 7;
            label6.Text = "Dirección:";
            // 
            // txtdireccion
            // 
            txtdireccion.Font = new Font("Calisto MT", 10F, FontStyle.Bold);
            txtdireccion.Location = new Point(486, 378);
            txtdireccion.Margin = new Padding(2, 3, 2, 3);
            txtdireccion.Name = "txtdireccion";
            txtdireccion.Size = new Size(310, 47);
            txtdireccion.TabIndex = 12;
            txtdireccion.Text = "";
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button2.BackColor = Color.FromArgb(3, 171, 229);
            button2.Cursor = Cursors.Hand;
            button2.FlatStyle = FlatStyle.Popup;
            button2.Font = new Font("Microsoft Sans Serif", 8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(707, 817);
            button2.Margin = new Padding(2, 3, 2, 3);
            button2.Name = "button2";
            button2.Size = new Size(117, 38);
            button2.TabIndex = 64;
            button2.Text = "Salir";
            button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(3, 171, 229);
            button1.Cursor = Cursors.Hand;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("Calisto MT", 10F, FontStyle.Bold);
            button1.Location = new Point(194, 430);
            button1.Margin = new Padding(2, 3, 2, 3);
            button1.Name = "button1";
            button1.Size = new Size(130, 35);
            button1.TabIndex = 65;
            button1.Text = "Cancelar";
            button1.UseVisualStyleBackColor = false;
            // 
            // btnregistrar
            // 
            btnregistrar.BackColor = Color.FromArgb(3, 171, 229);
            btnregistrar.Cursor = Cursors.Hand;
            btnregistrar.FlatStyle = FlatStyle.Popup;
            btnregistrar.Font = new Font("Calisto MT", 10F, FontStyle.Bold);
            btnregistrar.Location = new Point(46, 430);
            btnregistrar.Margin = new Padding(2, 3, 2, 3);
            btnregistrar.Name = "btnregistrar";
            btnregistrar.Size = new Size(124, 35);
            btnregistrar.TabIndex = 66;
            btnregistrar.Text = "Registrar";
            btnregistrar.UseVisualStyleBackColor = false;
         
            // 
            // txtcedula
            // 
            txtcedula.Font = new Font("Calisto MT", 10F, FontStyle.Bold);
            txtcedula.Location = new Point(486, 323);
            txtcedula.Margin = new Padding(2, 3, 2, 3);
            txtcedula.Name = "txtcedula";
            txtcedula.Size = new Size(284, 29);
            txtcedula.TabIndex = 68;
            txtcedula.Text = "";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Calisto MT", 10F, FontStyle.Bold);
            label8.Location = new Point(390, 330);
            label8.Margin = new Padding(2, 0, 2, 0);
            label8.Name = "label8";
            label8.Size = new Size(67, 20);
            label8.TabIndex = 70;
            label8.Text = "Cédula:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Calisto MT", 10F, FontStyle.Bold);
            label1.Location = new Point(14, 366);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(134, 20);
            label1.TabIndex = 71;
            label1.Text = "Sujeto a crédito: ";
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Font = new Font("Calisto MT", 10F, FontStyle.Bold);
            radioButton1.Location = new Point(174, 368);
            radioButton1.Margin = new Padding(2, 3, 2, 3);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(44, 24);
            radioButton1.TabIndex = 72;
            radioButton1.TabStop = true;
            radioButton1.Text = "Si";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Font = new Font("Calisto MT", 10F, FontStyle.Bold);
            radioButton2.Location = new Point(230, 366);
            radioButton2.Margin = new Padding(2, 3, 2, 3);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(53, 24);
            radioButton2.TabIndex = 73;
            radioButton2.TabStop = true;
            radioButton2.Text = "No";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Calisto MT", 10F, FontStyle.Bold);
            label9.Location = new Point(14, 310);
            label9.Margin = new Padding(2, 0, 2, 0);
            label9.Name = "label9";
            label9.Size = new Size(109, 20);
            label9.TabIndex = 74;
            label9.Text = "Colilla INSS: ";
            // 
            // txtcolillainss
            // 
            txtcolillainss.Font = new Font("Calisto MT", 10F, FontStyle.Bold);
            txtcolillainss.Location = new Point(140, 310);
            txtcolillainss.Margin = new Padding(2, 3, 2, 3);
            txtcolillainss.Name = "txtcolillainss";
            txtcolillainss.Size = new Size(214, 27);
            txtcolillainss.TabIndex = 75;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Calisto MT", 10F, FontStyle.Bold);
            label5.Location = new Point(14, 223);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(77, 20);
            label5.TabIndex = 76;
            label5.Text = "Apellido:";
            // 
            // txtapellidocliente
            // 
            txtapellidocliente.Font = new Font("Calisto MT", 10F, FontStyle.Bold);
            txtapellidocliente.Location = new Point(118, 223);
            txtapellidocliente.Margin = new Padding(2, 3, 2, 3);
            txtapellidocliente.Name = "txtapellidocliente";
            txtapellidocliente.Size = new Size(214, 27);
            txtapellidocliente.TabIndex = 77;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Font = new Font("Calisto MT", 8F, FontStyle.Bold);
            dateTimePicker1.Location = new Point(553, 186);
            dateTimePicker1.Margin = new Padding(3, 4, 3, 4);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(272, 23);
            dateTimePicker1.TabIndex = 78;
            // 
            // DGCLIENTES
            // 
            DGCLIENTES.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DGCLIENTES.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DGCLIENTES.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGCLIENTES.Location = new Point(14, 502);
            DGCLIENTES.Margin = new Padding(2, 3, 2, 3);
            DGCLIENTES.Name = "DGCLIENTES";
            DGCLIENTES.RowHeadersWidth = 62;
            DGCLIENTES.RowTemplate.Height = 28;
            DGCLIENTES.Size = new Size(666, 353);
            DGCLIENTES.TabIndex = 13;
            // 
            // Clientes
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(834, 882);
            Controls.Add(dateTimePicker1);
            Controls.Add(txtapellidocliente);
            Controls.Add(label5);
            Controls.Add(txtcolillainss);
            Controls.Add(label9);
            Controls.Add(radioButton2);
            Controls.Add(radioButton1);
            Controls.Add(label1);
            Controls.Add(label8);
            Controls.Add(txtcedula);
            Controls.Add(btnregistrar);
            Controls.Add(button1);
            Controls.Add(button2);
            Controls.Add(DGCLIENTES);
            Controls.Add(txtdireccion);
            Controls.Add(txtnombrecliente);
            Controls.Add(txttelefonocliente);
            Controls.Add(label6);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(panel1);
            ForeColor = Color.Black;
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(2, 3, 2, 3);
            Name = "Clientes";
            Text = "Clientes";
            Load += Clientes_Load_1;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DGCLIENTES).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txttelefonocliente;
        private System.Windows.Forms.TextBox txtnombrecliente;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox txtdireccion;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnregistrar;
        private System.Windows.Forms.RichTextBox txtcedula;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtcolillainss;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtapellidocliente;
        private DateTimePicker dateTimePicker1;
        private DataGridView DGCLIENTES;
    }
}