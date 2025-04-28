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
            SuspendLayout();
            // 
            // btnCambiar_Contraseña
            // 
            btnCambiar_Contraseña.Location = new Point(300, 295);
            btnCambiar_Contraseña.Name = "btnCambiar_Contraseña";
            btnCambiar_Contraseña.Size = new Size(196, 44);
            btnCambiar_Contraseña.TabIndex = 0;
            btnCambiar_Contraseña.Text = "Cambiar contraseña";
            btnCambiar_Contraseña.UseVisualStyleBackColor = true;
           // btnCambiar_Contraseña.Click += btnCambiar_Contraseña_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(300, 49);
            label1.Name = "label1";
            label1.Size = new Size(199, 25);
            label1.TabIndex = 1;
            label1.Text = "codigo de recuperación";
            // 
            // txtCambiarContraseña
            // 
            txtCambiarContraseña.Location = new Point(300, 103);
            txtCambiarContraseña.Name = "txtCambiarContraseña";
            txtCambiarContraseña.Size = new Size(199, 31);
            txtCambiarContraseña.TabIndex = 2;
            // 
            // txtContraseñaNueva
            // 
            txtContraseñaNueva.Location = new Point(300, 215);
            txtContraseñaNueva.Name = "txtContraseñaNueva";
            txtContraseñaNueva.Size = new Size(199, 31);
            txtContraseñaNueva.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(313, 163);
            label2.Name = "label2";
            label2.Size = new Size(153, 25);
            label2.TabIndex = 4;
            label2.Text = "Nueva contraseña";
            // 
            // Cambiar_contraseña
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(txtContraseñaNueva);
            Controls.Add(txtCambiarContraseña);
            Controls.Add(label1);
            Controls.Add(btnCambiar_Contraseña);
            Name = "Cambiar_contraseña";
            Text = "Cambiar_contraseña";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCambiar_Contraseña;
        private Label label1;
        private TextBox txtCambiarContraseña;
        private TextBox txtContraseñaNueva;
        private Label label2;
    }
}