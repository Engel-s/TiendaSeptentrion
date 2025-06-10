namespace formstienda.capa_de_presentación
{
    partial class menuprincipal
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
            components = new System.ComponentModel.Container();
            lblfecha = new Label();
            lblhora = new Label();
            horayfecha = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // lblfecha
            // 
            lblfecha.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblfecha.AutoSize = true;
            lblfecha.Font = new Font("Century Gothic", 48F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblfecha.ForeColor = Color.Black;
            lblfecha.Location = new Point(35, 705);
            lblfecha.Name = "lblfecha";
            lblfecha.Size = new Size(282, 98);
            lblfecha.TabIndex = 0;
            lblfecha.Text = "label1";
            // 
            // lblhora
            // 
            lblhora.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblhora.AutoSize = true;
            lblhora.Font = new Font("Century Gothic", 28.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblhora.ForeColor = Color.Black;
            lblhora.Location = new Point(1127, 723);
            lblhora.Name = "lblhora";
            lblhora.Size = new Size(165, 57);
            lblhora.TabIndex = 1;
            lblhora.Text = "label2";
            // 
            // horayfecha
            // 
            horayfecha.Enabled = true;
            horayfecha.Tick += horayfecha_Tick;
            // 
            // menuprincipal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1315, 847);
            Controls.Add(lblfecha);
            Controls.Add(lblhora);
            FormBorderStyle = FormBorderStyle.None;
            Name = "menuprincipal";
            Text = "menuprincipal";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblfecha;
        private Label lblhora;
        private System.Windows.Forms.Timer horayfecha;
        private Panel panelform;
    }
}