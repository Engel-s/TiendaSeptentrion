namespace formstienda.capa_de_presentación
{
    partial class Egresos
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
            label4 = new Label();
            txtTotalCaja = new TextBox();
            txtCantidadEgresada = new TextBox();
            TxtMotivoEgreso = new RichTextBox();
            dataGridView1 = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            label5 = new Label();
            dtpFechaEgreso = new DateTimePicker();
            button3 = new Button();
            button1 = new Button();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Calisto MT", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(19, 101);
            label1.Name = "label1";
            label1.Size = new Size(113, 22);
            label1.TabIndex = 0;
            label1.Text = "Total caja: ";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Calisto MT", 20F, FontStyle.Bold);
            label2.Location = new Point(375, 11);
            label2.Name = "label2";
            label2.Size = new Size(142, 39);
            label2.TabIndex = 1;
            label2.Text = "Egresos ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Calisto MT", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(19, 156);
            label3.Name = "label3";
            label3.Size = new Size(183, 22);
            label3.TabIndex = 2;
            label3.Text = "Cantidad egresada:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Calisto MT", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(19, 205);
            label4.Name = "label4";
            label4.Size = new Size(184, 22);
            label4.TabIndex = 3;
            label4.Text = "Motivo del egreso: ";
            // 
            // txtTotalCaja
            // 
            txtTotalCaja.Location = new Point(281, 101);
            txtTotalCaja.Margin = new Padding(3, 2, 3, 2);
            txtTotalCaja.Name = "txtTotalCaja";
            txtTotalCaja.Size = new Size(193, 27);
            txtTotalCaja.TabIndex = 4;
            // 
            // txtCantidadEgresada
            // 
            txtCantidadEgresada.Location = new Point(281, 159);
            txtCantidadEgresada.Margin = new Padding(3, 2, 3, 2);
            txtCantidadEgresada.Name = "txtCantidadEgresada";
            txtCantidadEgresada.Size = new Size(108, 27);
            txtCantidadEgresada.TabIndex = 5;
            txtCantidadEgresada.TextChanged += textBox2_TextChanged;
            // 
            // TxtMotivoEgreso
            // 
            TxtMotivoEgreso.Location = new Point(281, 208);
            TxtMotivoEgreso.Margin = new Padding(3, 2, 3, 2);
            TxtMotivoEgreso.Name = "TxtMotivoEgreso";
            TxtMotivoEgreso.Size = new Size(409, 69);
            TxtMotivoEgreso.TabIndex = 6;
            TxtMotivoEgreso.Text = "";
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4 });
            dataGridView1.Location = new Point(12, 468);
            dataGridView1.Margin = new Padding(3, 2, 3, 2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.RowTemplate.Height = 28;
            dataGridView1.Size = new Size(763, 222);
            dataGridView1.TabIndex = 7;
            // 
            // Column1
            // 
            Column1.HeaderText = "Fecha";
            Column1.MinimumWidth = 8;
            Column1.Name = "Column1";
            // 
            // Column2
            // 
            Column2.HeaderText = "Motivo";
            Column2.MinimumWidth = 8;
            Column2.Name = "Column2";
            // 
            // Column3
            // 
            Column3.HeaderText = "Cantidad";
            Column3.MinimumWidth = 8;
            Column3.Name = "Column3";
            // 
            // Column4
            // 
            Column4.HeaderText = "Egresos del día ";
            Column4.MinimumWidth = 8;
            Column4.Name = "Column4";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Calisto MT", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(515, 104);
            label5.Name = "label5";
            label5.Size = new Size(71, 22);
            label5.TabIndex = 8;
            label5.Text = "Fecha:";
            label5.Click += label5_Click;
            // 
            // dtpFechaEgreso
            // 
            dtpFechaEgreso.Font = new Font("Calisto MT", 8F, FontStyle.Bold);
            dtpFechaEgreso.Location = new Point(624, 104);
            dtpFechaEgreso.Margin = new Padding(3, 4, 3, 4);
            dtpFechaEgreso.Name = "dtpFechaEgreso";
            dtpFechaEgreso.Size = new Size(272, 23);
            dtpFechaEgreso.TabIndex = 60;
            dtpFechaEgreso.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(3, 171, 229);
            button3.Cursor = Cursors.Hand;
            button3.FlatStyle = FlatStyle.Popup;
            button3.Font = new Font("Calisto MT", 10F, FontStyle.Bold);
            button3.Location = new Point(190, 374);
            button3.Margin = new Padding(3, 2, 3, 2);
            button3.Name = "button3";
            button3.Size = new Size(113, 44);
            button3.TabIndex = 61;
            button3.Text = "Cancelar";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(3, 171, 229);
            button1.Cursor = Cursors.Hand;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("Calisto MT", 10F, FontStyle.Bold);
            button1.Location = new Point(23, 374);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(120, 44);
            button1.TabIndex = 62;
            button1.Text = "Guardar";
            button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(3, 171, 229);
            button2.Cursor = Cursors.Hand;
            button2.FlatStyle = FlatStyle.Popup;
            button2.Font = new Font("Calisto MT", 10F, FontStyle.Bold);
            button2.Location = new Point(783, 646);
            button2.Margin = new Padding(3, 2, 3, 2);
            button2.Name = "button2";
            button2.Size = new Size(113, 44);
            button2.TabIndex = 63;
            button2.Text = "Volver";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // Egresos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(908, 719);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(button3);
            Controls.Add(dtpFechaEgreso);
            Controls.Add(label5);
            Controls.Add(dataGridView1);
            Controls.Add(TxtMotivoEgreso);
            Controls.Add(txtCantidadEgresada);
            Controls.Add(txtTotalCaja);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "Egresos";
            Text = "Egresos";
            Load += Egresos_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTotalCaja;
        private System.Windows.Forms.TextBox txtCantidadEgresada;
        private System.Windows.Forms.RichTextBox TxtMotivoEgreso;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpFechaEgreso;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    }
}