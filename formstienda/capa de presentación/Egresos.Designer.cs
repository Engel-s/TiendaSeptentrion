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
            label2 = new Label();
            button2 = new Button();
            btnGuardarCordobas = new Button();
            btnCancelarCordobas = new Button();
            dateTimePickerEgresos = new DateTimePicker();
            label5 = new Label();
            txtMotivoEgreso = new RichTextBox();
            txtCantidadEgresada = new TextBox();
            txtTotalCaja = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label1 = new Label();
            label6 = new Label();
            cmbMoneda = new ComboBox();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Calisto MT", 20F, FontStyle.Bold);
            label2.Location = new Point(385, 9);
            label2.Name = "label2";
            label2.Size = new Size(142, 39);
            label2.TabIndex = 1;
            label2.Text = "Egresos ";
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(3, 171, 229);
            button2.Cursor = Cursors.Hand;
            button2.FlatStyle = FlatStyle.Popup;
            button2.Font = new Font("Calisto MT", 10F, FontStyle.Bold);
            button2.Location = new Point(773, 656);
            button2.Margin = new Padding(3, 2, 3, 2);
            button2.Name = "button2";
            button2.Size = new Size(113, 44);
            button2.TabIndex = 63;
            button2.Text = "Volver";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // btnGuardarCordobas
            // 
            btnGuardarCordobas.BackColor = Color.FromArgb(3, 171, 229);
            btnGuardarCordobas.Cursor = Cursors.Hand;
            btnGuardarCordobas.FlatStyle = FlatStyle.Popup;
            btnGuardarCordobas.Font = new Font("Calisto MT", 10F, FontStyle.Bold);
            btnGuardarCordobas.Location = new Point(43, 560);
            btnGuardarCordobas.Margin = new Padding(3, 2, 3, 2);
            btnGuardarCordobas.Name = "btnGuardarCordobas";
            btnGuardarCordobas.Size = new Size(120, 44);
            btnGuardarCordobas.TabIndex = 82;
            btnGuardarCordobas.Text = "Guardar";
            btnGuardarCordobas.UseVisualStyleBackColor = false;
            btnGuardarCordobas.Click += this.btnGuardar_Click;
            // 
            // btnCancelarCordobas
            // 
            btnCancelarCordobas.BackColor = Color.FromArgb(3, 171, 229);
            btnCancelarCordobas.Cursor = Cursors.Hand;
            btnCancelarCordobas.FlatStyle = FlatStyle.Popup;
            btnCancelarCordobas.Font = new Font("Calisto MT", 10F, FontStyle.Bold);
            btnCancelarCordobas.Location = new Point(210, 560);
            btnCancelarCordobas.Margin = new Padding(3, 2, 3, 2);
            btnCancelarCordobas.Name = "btnCancelarCordobas";
            btnCancelarCordobas.Size = new Size(113, 44);
            btnCancelarCordobas.TabIndex = 81;
            btnCancelarCordobas.Text = "Cancelar";
            btnCancelarCordobas.UseVisualStyleBackColor = false;
            // 
            // dateTimePickerEgresos
            // 
            dateTimePickerEgresos.Font = new Font("Calisto MT", 8F, FontStyle.Bold);
            dateTimePickerEgresos.Location = new Point(597, 203);
            dateTimePickerEgresos.Margin = new Padding(3, 4, 3, 4);
            dateTimePickerEgresos.Name = "dateTimePickerEgresos";
            dateTimePickerEgresos.Size = new Size(272, 23);
            dateTimePickerEgresos.TabIndex = 80;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Calisto MT", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(506, 204);
            label5.Name = "label5";
            label5.Size = new Size(71, 22);
            label5.TabIndex = 79;
            label5.Text = "Fecha:";
            // 
            // txtMotivoEgreso
            // 
            txtMotivoEgreso.Location = new Point(263, 342);
            txtMotivoEgreso.Margin = new Padding(3, 2, 3, 2);
            txtMotivoEgreso.Name = "txtMotivoEgreso";
            txtMotivoEgreso.Size = new Size(409, 69);
            txtMotivoEgreso.TabIndex = 78;
            txtMotivoEgreso.Text = "";
            // 
            // txtCantidadEgresada
            // 
            txtCantidadEgresada.Location = new Point(263, 263);
            txtCantidadEgresada.Margin = new Padding(3, 2, 3, 2);
            txtCantidadEgresada.Name = "txtCantidadEgresada";
            txtCantidadEgresada.Size = new Size(108, 27);
            txtCantidadEgresada.TabIndex = 77;
            // 
            // txtTotalCaja
            // 
            txtTotalCaja.Location = new Point(263, 204);
            txtTotalCaja.Margin = new Padding(3, 2, 3, 2);
            txtTotalCaja.Name = "txtTotalCaja";
            txtTotalCaja.ReadOnly = true;
            txtTotalCaja.Size = new Size(193, 27);
            txtTotalCaja.TabIndex = 76;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Calisto MT", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(39, 343);
            label4.Name = "label4";
            label4.Size = new Size(184, 22);
            label4.TabIndex = 75;
            label4.Text = "Motivo del egreso: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Calisto MT", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(39, 264);
            label3.Name = "label3";
            label3.Size = new Size(183, 22);
            label3.TabIndex = 74;
            label3.Text = "Cantidad egresada:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Calisto MT", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(39, 205);
            label1.Name = "label1";
            label1.Size = new Size(113, 22);
            label1.TabIndex = 73;
            label1.Text = "Total caja: ";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Calisto MT", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(39, 157);
            label6.Name = "label6";
            label6.Size = new Size(211, 22);
            label6.TabIndex = 83;
            label6.Text = "Selecione la moneda: ";
            // 
            // cmbMoneda
            // 
            cmbMoneda.FormattingEnabled = true;
            cmbMoneda.Location = new Point(263, 156);
            cmbMoneda.Name = "cmbMoneda";
            cmbMoneda.Size = new Size(151, 28);
            cmbMoneda.TabIndex = 84;
            cmbMoneda.SelectedIndexChanged += cmbMoneda_SelectedIndexChanged;
            // 
            // Egresos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(908, 719);
            Controls.Add(cmbMoneda);
            Controls.Add(label6);
            Controls.Add(btnGuardarCordobas);
            Controls.Add(btnCancelarCordobas);
            Controls.Add(dateTimePickerEgresos);
            Controls.Add(label5);
            Controls.Add(txtMotivoEgreso);
            Controls.Add(txtCantidadEgresada);
            Controls.Add(txtTotalCaja);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(label2);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "Egresos";
            Text = "Egresos";
            Load += Egresos_Load;
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private Button btnGuardarCordobas;
        private Button btnCancelarCordobas;
        private DateTimePicker dateTimePickerEgresos;
        private Label label5;
        private RichTextBox txtMotivoEgreso;
        private TextBox txtCantidadEgresada;
        private TextBox txtTotalCaja;
        private Label label4;
        private Label label3;
        private Label label1;
        private Label label6;
        private ComboBox cmbMoneda;
    }
}