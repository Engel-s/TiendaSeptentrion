namespace formstienda
{
    partial class Devoluciones
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
            textBox1 = new TextBox();
            dataGridView1 = new DataGridView();
            label4 = new Label();
            comboBox2 = new ComboBox();
            label7 = new Label();
            textBox4 = new TextBox();
            button1 = new Button();
            btnsalir = new Button();
            button3 = new Button();
            pictureBox1 = new PictureBox();
            textBox5 = new TextBox();
            label8 = new Label();
            textBox6 = new TextBox();
            label5 = new Label();
            textBox2 = new TextBox();
            label3 = new Label();
            button2 = new Button();
            panel1 = new Panel();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            Column6 = new DataGridViewTextBoxColumn();
            Column7 = new DataGridViewTextBoxColumn();
            Column8 = new DataGridViewTextBoxColumn();
            Vendedor = new DataGridViewTextBoxColumn();
            cantidad_devuelta = new DataGridViewTextBoxColumn();
            Column1 = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Calisto MT", 14F, FontStyle.Bold);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(396, 0);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(463, 32);
            label1.TabIndex = 0;
            label1.Text = "Proceso de solicitud de devoluciones ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Calisto MT", 10F, FontStyle.Bold);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(89, 91);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(154, 22);
            label2.TabIndex = 1;
            label2.Text = "Buscar Factura:";
            label2.Click += label2_Click;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Calisto MT", 10F, FontStyle.Bold);
            textBox1.Location = new Point(252, 88);
            textBox1.Margin = new Padding(4, 6, 4, 6);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(368, 31);
            textBox1.TabIndex = 3;
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = Color.FromArgb(238, 238, 238);
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Column2, Column3, Column4, Column5, Column6, Column7, Column8, Vendedor, cantidad_devuelta, Column1 });
            dataGridView1.Location = new Point(21, 214);
            dataGridView1.Margin = new Padding(4, 6, 4, 6);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 24;
            dataGridView1.Size = new Size(1314, 345);
            dataGridView1.TabIndex = 5;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label4.AutoSize = true;
            label4.Font = new Font("Calisto MT", 10F, FontStyle.Bold);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(42, 634);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(214, 22);
            label4.TabIndex = 6;
            label4.Text = "Motivo de devolución:";
            label4.Click += label4_Click;
            // 
            // comboBox2
            // 
            comboBox2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "Defecto de fabrica", "Error de facturación", "Garantía" });
            comboBox2.Location = new Point(314, 634);
            comboBox2.Margin = new Padding(4, 6, 4, 6);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(344, 33);
            comboBox2.TabIndex = 7;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label7.AutoSize = true;
            label7.Font = new Font("Calisto MT", 10F, FontStyle.Bold);
            label7.ForeColor = Color.Black;
            label7.Location = new Point(48, 754);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(209, 22);
            label7.TabIndex = 12;
            label7.Text = "Monto de devolución:";
            label7.Click += label7_Click;
            // 
            // textBox4
            // 
            textBox4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            textBox4.Location = new Point(314, 750);
            textBox4.Margin = new Padding(4, 6, 4, 6);
            textBox4.Name = "textBox4";
            textBox4.ReadOnly = true;
            textBox4.Size = new Size(343, 31);
            textBox4.TabIndex = 13;
            textBox4.TextChanged += textBox4_TextChanged;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button1.BackColor = Color.FromArgb(3, 171, 229);
            button1.Cursor = Cursors.Hand;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("Calisto MT", 10F, FontStyle.Bold);
            button1.ForeColor = Color.Black;
            button1.Location = new Point(1008, 872);
            button1.Margin = new Padding(4, 6, 4, 6);
            button1.Name = "button1";
            button1.Size = new Size(161, 52);
            button1.TabIndex = 14;
            button1.Text = "Confirmar";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // btnsalir
            // 
            btnsalir.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnsalir.BackColor = Color.FromArgb(3, 171, 229);
            btnsalir.Cursor = Cursors.Hand;
            btnsalir.FlatStyle = FlatStyle.Popup;
            btnsalir.Font = new Font("Calisto MT", 10F, FontStyle.Bold);
            btnsalir.ForeColor = Color.Black;
            btnsalir.Location = new Point(1188, 872);
            btnsalir.Margin = new Padding(4, 6, 4, 6);
            btnsalir.Name = "btnsalir";
            btnsalir.Size = new Size(149, 52);
            btnsalir.TabIndex = 15;
            btnsalir.Text = "Salir";
            btnsalir.UseVisualStyleBackColor = false;
            btnsalir.Click += button2_Click;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button3.BackColor = Color.FromArgb(3, 171, 229);
            button3.Cursor = Cursors.Hand;
            button3.FlatStyle = FlatStyle.Popup;
            button3.Font = new Font("Calisto MT", 10F, FontStyle.Bold);
            button3.ForeColor = Color.Black;
            button3.Location = new Point(821, 871);
            button3.Margin = new Padding(4, 6, 4, 6);
            button3.MinimumSize = new Size(129, 52);
            button3.Name = "button3";
            button3.Size = new Size(168, 52);
            button3.TabIndex = 16;
            button3.Text = "Cancelar ";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.busque_un_simbolo_de_interfaz_de_persona_de_una_lupa_en_forma_de_hombre;
            pictureBox1.Location = new Point(640, 80);
            pictureBox1.Margin = new Padding(4, 2, 4, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(61, 51);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 40;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // textBox5
            // 
            textBox5.Font = new Font("Calisto MT", 10F, FontStyle.Bold);
            textBox5.Location = new Point(844, 150);
            textBox5.Margin = new Padding(4, 6, 4, 6);
            textBox5.Name = "textBox5";
            textBox5.ReadOnly = true;
            textBox5.Size = new Size(173, 31);
            textBox5.TabIndex = 41;
            textBox5.TextChanged += textBox5_TextChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Calisto MT", 10F, FontStyle.Bold);
            label8.ForeColor = Color.Black;
            label8.Location = new Point(89, 154);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(84, 22);
            label8.TabIndex = 42;
            label8.Text = "Cliente:";
            label8.Click += label8_Click;
            // 
            // textBox6
            // 
            textBox6.Font = new Font("Calisto MT", 10F, FontStyle.Bold);
            textBox6.Location = new Point(180, 150);
            textBox6.Margin = new Padding(4, 6, 4, 6);
            textBox6.Name = "textBox6";
            textBox6.ReadOnly = true;
            textBox6.Size = new Size(395, 31);
            textBox6.TabIndex = 43;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label5.AutoSize = true;
            label5.Font = new Font("Calisto MT", 10F, FontStyle.Bold);
            label5.ForeColor = Color.Black;
            label5.Location = new Point(42, 695);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(258, 22);
            label5.TabIndex = 44;
            label5.Text = "Descripción de devolución:";
            // 
            // textBox2
            // 
            textBox2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            textBox2.Location = new Point(314, 695);
            textBox2.Margin = new Padding(4, 6, 4, 6);
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new Size(343, 31);
            textBox2.TabIndex = 45;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Calisto MT", 10F, FontStyle.Bold);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(708, 154);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(99, 22);
            label3.TabIndex = 46;
            label3.Text = "Teléfono:";
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button2.BackColor = Color.FromArgb(3, 171, 229);
            button2.Cursor = Cursors.Hand;
            button2.FlatStyle = FlatStyle.Popup;
            button2.Font = new Font("Calisto MT", 10F, FontStyle.Bold);
            button2.ForeColor = Color.Black;
            button2.Location = new Point(914, 808);
            button2.Margin = new Padding(4, 6, 4, 6);
            button2.Name = "button2";
            button2.Size = new Size(330, 52);
            button2.TabIndex = 47;
            button2.Text = "Anular Factura";
            button2.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(textBox6);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(dataGridView1);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(btnsalir);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(textBox5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(comboBox2);
            panel1.Controls.Add(textBox4);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(4, 4, 4, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(1381, 952);
            panel1.TabIndex = 48;
            // 
            // Column2
            // 
            Column2.HeaderText = "Código";
            Column2.MinimumWidth = 6;
            Column2.Name = "Column2";
            // 
            // Column3
            // 
            Column3.HeaderText = "Producto";
            Column3.MinimumWidth = 6;
            Column3.Name = "Column3";
            // 
            // Column4
            // 
            Column4.HeaderText = "Categoría";
            Column4.MinimumWidth = 6;
            Column4.Name = "Column4";
            // 
            // Column5
            // 
            Column5.HeaderText = "Marca";
            Column5.MinimumWidth = 6;
            Column5.Name = "Column5";
            // 
            // Column6
            // 
            Column6.HeaderText = "Precio";
            Column6.MinimumWidth = 6;
            Column6.Name = "Column6";
            // 
            // Column7
            // 
            Column7.HeaderText = "Cantidad";
            Column7.MinimumWidth = 6;
            Column7.Name = "Column7";
            // 
            // Column8
            // 
            Column8.HeaderText = "Subtotal";
            Column8.MinimumWidth = 6;
            Column8.Name = "Column8";
            // 
            // Vendedor
            // 
            Vendedor.FillWeight = 78.20856F;
            Vendedor.HeaderText = "Vendedor";
            Vendedor.MinimumWidth = 6;
            Vendedor.Name = "Vendedor";
            // 
            // cantidad_devuelta
            // 
            cantidad_devuelta.HeaderText = "Cantidad devuelta";
            cantidad_devuelta.MinimumWidth = 8;
            cantidad_devuelta.Name = "cantidad_devuelta";
            // 
            // Column1
            // 
            Column1.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Column1.FillWeight = 187.1658F;
            Column1.HeaderText = "Eliminar";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            Column1.Width = 70;
            // 
            // Devoluciones
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 122, 204);
            ClientSize = new Size(1381, 952);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 6, 4, 6);
            Name = "Devoluciones";
            Text = "Devoluciones";
            Load += Form4_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnsalir;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox2;
        private Label label3;
        private Button button2;
        private Panel panel1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column6;
        private DataGridViewTextBoxColumn Column7;
        private DataGridViewTextBoxColumn Column8;
        private DataGridViewTextBoxColumn Vendedor;
        private DataGridViewTextBoxColumn cantidad_devuelta;
        private DataGridViewTextBoxColumn Column1;
    }
}