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
            textBox1 = new TextBox();
            textBox3 = new TextBox();
            label6 = new Label();
            richTextBox1 = new RichTextBox();
            dataGridView1 = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Nombre = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            button2 = new Button();
            button1 = new Button();
            button3 = new Button();
            richTextBox2 = new RichTextBox();
            label8 = new Label();
            label1 = new Label();
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            label9 = new Label();
            textBox2 = new TextBox();
            label5 = new Label();
            textBox5 = new TextBox();
            dateTimePicker1 = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Bottom;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 84);
            pictureBox1.Margin = new Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1042, 112);
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
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(1042, 196);
            panel1.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Calisto MT", 10F, FontStyle.Bold);
            label2.Location = new Point(17, 223);
            label2.Name = "label2";
            label2.Size = new Size(93, 22);
            label2.TabIndex = 3;
            label2.Text = "Nombre:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Calisto MT", 10F, FontStyle.Bold);
            label3.Location = new Point(17, 329);
            label3.Name = "label3";
            label3.Size = new Size(104, 22);
            label3.TabIndex = 4;
            label3.Text = "Teléfono: ";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Calisto MT", 10F, FontStyle.Bold);
            label4.Location = new Point(607, 232);
            label4.Name = "label4";
            label4.Size = new Size(71, 22);
            label4.TabIndex = 5;
            label4.Text = "Fecha:";
            label4.Click += label4_Click;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Calisto MT", 10F, FontStyle.Bold);
            textBox1.Location = new Point(147, 329);
            textBox1.Margin = new Padding(3, 4, 3, 4);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(182, 31);
            textBox1.TabIndex = 8;
            // 
            // textBox3
            // 
            textBox3.Font = new Font("Calisto MT", 10F, FontStyle.Bold);
            textBox3.Location = new Point(147, 223);
            textBox3.Margin = new Padding(3, 4, 3, 4);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(266, 31);
            textBox3.TabIndex = 10;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Calisto MT", 10F, FontStyle.Bold);
            label6.Location = new Point(460, 473);
            label6.Name = "label6";
            label6.Size = new Size(108, 22);
            label6.TabIndex = 7;
            label6.Text = "Dirección:";
            // 
            // richTextBox1
            // 
            richTextBox1.Font = new Font("Calisto MT", 10F, FontStyle.Bold);
            richTextBox1.Location = new Point(607, 473);
            richTextBox1.Margin = new Padding(3, 4, 3, 4);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(387, 58);
            richTextBox1.TabIndex = 12;
            richTextBox1.Text = "";
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Column1, Nombre, Column2, Column3, Column4 });
            dataGridView1.Location = new Point(17, 627);
            dataGridView1.Margin = new Padding(3, 4, 3, 4);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.RowTemplate.Height = 28;
            dataGridView1.Size = new Size(832, 441);
            dataGridView1.TabIndex = 13;
            // 
            // Column1
            // 
            Column1.HeaderText = "ID cliente";
            Column1.MinimumWidth = 8;
            Column1.Name = "Column1";
            // 
            // Nombre
            // 
            Nombre.HeaderText = "Nombre";
            Nombre.MinimumWidth = 8;
            Nombre.Name = "Nombre";
            // 
            // Column2
            // 
            Column2.HeaderText = "Teléfono ";
            Column2.MinimumWidth = 8;
            Column2.Name = "Column2";
            // 
            // Column3
            // 
            Column3.HeaderText = "Dirección";
            Column3.MinimumWidth = 8;
            Column3.Name = "Column3";
            // 
            // Column4
            // 
            Column4.HeaderText = "Historial";
            Column4.MinimumWidth = 8;
            Column4.Name = "Column4";
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button2.BackColor = Color.FromArgb(3, 171, 229);
            button2.Cursor = Cursors.Hand;
            button2.FlatStyle = FlatStyle.Popup;
            button2.Font = new Font("Microsoft Sans Serif", 8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(884, 1021);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(146, 47);
            button2.TabIndex = 64;
            button2.Text = "Salir";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(3, 171, 229);
            button1.Cursor = Cursors.Hand;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("Calisto MT", 10F, FontStyle.Bold);
            button1.Location = new Point(242, 538);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(163, 44);
            button1.TabIndex = 65;
            button1.Text = "Cancelar";
            button1.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(3, 171, 229);
            button3.Cursor = Cursors.Hand;
            button3.FlatStyle = FlatStyle.Popup;
            button3.Font = new Font("Calisto MT", 10F, FontStyle.Bold);
            button3.Location = new Point(57, 538);
            button3.Margin = new Padding(3, 4, 3, 4);
            button3.Name = "button3";
            button3.Size = new Size(155, 44);
            button3.TabIndex = 66;
            button3.Text = "Registrar";
            button3.UseVisualStyleBackColor = false;
            // 
            // richTextBox2
            // 
            richTextBox2.Font = new Font("Calisto MT", 10F, FontStyle.Bold);
            richTextBox2.Location = new Point(607, 404);
            richTextBox2.Margin = new Padding(3, 4, 3, 4);
            richTextBox2.Name = "richTextBox2";
            richTextBox2.Size = new Size(354, 35);
            richTextBox2.TabIndex = 68;
            richTextBox2.Text = "";
            richTextBox2.TextChanged += richTextBox2_TextChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Calisto MT", 10F, FontStyle.Bold);
            label8.Location = new Point(487, 412);
            label8.Name = "label8";
            label8.Size = new Size(82, 22);
            label8.TabIndex = 70;
            label8.Text = "Cédula:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Calisto MT", 10F, FontStyle.Bold);
            label1.Location = new Point(17, 458);
            label1.Name = "label1";
            label1.Size = new Size(164, 22);
            label1.TabIndex = 71;
            label1.Text = "Sujeto a crédito: ";
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Font = new Font("Calisto MT", 10F, FontStyle.Bold);
            radioButton1.Location = new Point(218, 460);
            radioButton1.Margin = new Padding(3, 4, 3, 4);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(53, 26);
            radioButton1.TabIndex = 72;
            radioButton1.TabStop = true;
            radioButton1.Text = "Si";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Font = new Font("Calisto MT", 10F, FontStyle.Bold);
            radioButton2.Location = new Point(288, 458);
            radioButton2.Margin = new Padding(3, 4, 3, 4);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(63, 26);
            radioButton2.TabIndex = 73;
            radioButton2.TabStop = true;
            radioButton2.Text = "No";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Calisto MT", 10F, FontStyle.Bold);
            label9.Location = new Point(17, 388);
            label9.Name = "label9";
            label9.Size = new Size(138, 22);
            label9.TabIndex = 74;
            label9.Text = "Colilla INSS: ";
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Calisto MT", 10F, FontStyle.Bold);
            textBox2.Location = new Point(175, 388);
            textBox2.Margin = new Padding(3, 4, 3, 4);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(266, 31);
            textBox2.TabIndex = 75;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Calisto MT", 10F, FontStyle.Bold);
            label5.Location = new Point(17, 279);
            label5.Name = "label5";
            label5.Size = new Size(97, 22);
            label5.TabIndex = 76;
            label5.Text = "Apellido:";
            // 
            // textBox5
            // 
            textBox5.Font = new Font("Calisto MT", 10F, FontStyle.Bold);
            textBox5.Location = new Point(147, 279);
            textBox5.Margin = new Padding(3, 4, 3, 4);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(266, 31);
            textBox5.TabIndex = 77;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Font = new Font("Calisto MT", 8F, FontStyle.Bold);
            dateTimePicker1.Location = new Point(691, 232);
            dateTimePicker1.Margin = new Padding(4, 5, 4, 5);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(339, 26);
            dateTimePicker1.TabIndex = 78;
            // 
            // Clientes
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1042, 1106);
            Controls.Add(dateTimePicker1);
            Controls.Add(textBox5);
            Controls.Add(label5);
            Controls.Add(textBox2);
            Controls.Add(label9);
            Controls.Add(radioButton2);
            Controls.Add(radioButton1);
            Controls.Add(label1);
            Controls.Add(label8);
            Controls.Add(richTextBox2);
            Controls.Add(button3);
            Controls.Add(button1);
            Controls.Add(button2);
            Controls.Add(dataGridView1);
            Controls.Add(richTextBox1);
            Controls.Add(textBox3);
            Controls.Add(textBox1);
            Controls.Add(label6);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(panel1);
            ForeColor = Color.Black;
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "Clientes";
            Text = "Clientes";
            Load += Clientes_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox5;
        private DateTimePicker dateTimePicker1;
    }
}