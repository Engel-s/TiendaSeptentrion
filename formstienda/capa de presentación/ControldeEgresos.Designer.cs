namespace formstienda.capa_de_presentación
{
    partial class ControldeEgresos
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
            DGCONTROLEGRESOS = new DataGridView();
            Column5 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column1 = new DataGridViewTextBoxColumn();
            button1 = new Button();
            label1 = new Label();
            txtBuscarEgresos = new TextBox();
            dateTimePicker1 = new DateTimePicker();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)DGCONTROLEGRESOS).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // DGCONTROLEGRESOS
            // 
            DGCONTROLEGRESOS.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DGCONTROLEGRESOS.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DGCONTROLEGRESOS.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGCONTROLEGRESOS.Columns.AddRange(new DataGridViewColumn[] { Column5, Column2, Column3, Column4, Column1 });
            DGCONTROLEGRESOS.Location = new Point(30, 101);
            DGCONTROLEGRESOS.Name = "DGCONTROLEGRESOS";
            DGCONTROLEGRESOS.RowHeadersWidth = 51;
            DGCONTROLEGRESOS.Size = new Size(833, 260);
            DGCONTROLEGRESOS.TabIndex = 0;
            // 
            // Column5
            // 
            Column5.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Column5.HeaderText = "Fecha";
            Column5.MinimumWidth = 6;
            Column5.Name = "Column5";
            Column5.Width = 120;
            // 
            // Column2
            // 
            Column2.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Column2.FillWeight = 44.2067757F;
            Column2.HeaderText = "Cantidad";
            Column2.MinimumWidth = 6;
            Column2.Name = "Column2";
            Column2.Width = 125;
            // 
            // Column3
            // 
            Column3.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Column3.FillWeight = 44.2067757F;
            Column3.HeaderText = "Motivo de engreso";
            Column3.MinimumWidth = 6;
            Column3.Name = "Column3";
            Column3.Width = 152;
            // 
            // Column4
            // 
            Column4.FillWeight = 267.379669F;
            Column4.HeaderText = "Total de egreso córdobas";
            Column4.MinimumWidth = 6;
            Column4.Name = "Column4";
            // 
            // Column1
            // 
            Column1.HeaderText = "Total caja dólares";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(3, 171, 229);
            button1.Cursor = Cursors.Hand;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("Calisto MT", 10F, FontStyle.Bold);
            button1.Location = new Point(768, 410);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(120, 32);
            button1.TabIndex = 64;
            button1.Text = "Salir";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Calisto MT", 10F, FontStyle.Bold);
            label1.Location = new Point(30, 46);
            label1.Name = "label1";
            label1.Size = new Size(65, 20);
            label1.TabIndex = 65;
            label1.Text = "Buscar:";
            // 
            // txtBuscarEgresos
            // 
            txtBuscarEgresos.Location = new Point(101, 43);
            txtBuscarEgresos.Name = "txtBuscarEgresos";
            txtBuscarEgresos.Size = new Size(375, 27);
            txtBuscarEgresos.TabIndex = 66;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(482, 43);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(280, 27);
            dateTimePicker1.TabIndex = 67;
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.reinicio_removebg_preview;
            pictureBox1.Location = new Point(768, 43);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(41, 27);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 68;
            pictureBox1.TabStop = false;
            pictureBox1.Click += btnLimpiarFiltro_Click;
            pictureBox1.DoubleClick += btnLimpiarFiltro_Click;
            // 
            // ControldeEgresos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(902, 462);
            Controls.Add(pictureBox1);
            Controls.Add(dateTimePicker1);
            Controls.Add(txtBuscarEgresos);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(DGCONTROLEGRESOS);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ControldeEgresos";
            Text = "ControldeEgresos";
            Load += ControldeEgresos_Load;
            ((System.ComponentModel.ISupportInitialize)DGCONTROLEGRESOS).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView DGCONTROLEGRESOS;
        private Button button1;
        private Label label1;
        private TextBox txtBuscarEgresos;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column1;
        private DateTimePicker dateTimePicker1;
        private PictureBox pictureBox1;
    }
}