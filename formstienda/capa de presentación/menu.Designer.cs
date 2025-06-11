namespace formstienda.capa_de_presentación
{
    partial class menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(menu));
            MenuVertical = new FlowLayoutPanel();
            panel3 = new Panel();
            lblusuario = new Label();
            iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            btncompras = new FontAwesome.Sharp.IconButton();
            btnventas = new FontAwesome.Sharp.IconButton();
            btndevoluciones = new FontAwesome.Sharp.IconButton();
            btncreditos = new FontAwesome.Sharp.IconButton();
            btnproductos = new FontAwesome.Sharp.IconButton();
            btnsalidasinventario = new FontAwesome.Sharp.IconButton();
            btnclientes = new FontAwesome.Sharp.IconButton();
            btnproveedores = new FontAwesome.Sharp.IconButton();
            btnusuarios = new FontAwesome.Sharp.IconButton();
            btnarqueo = new FontAwesome.Sharp.IconButton();
            btninformes = new FontAwesome.Sharp.IconButton();
            btnmantenimiento = new FontAwesome.Sharp.IconButton();
            btnacercade = new FontAwesome.Sharp.IconButton();
            panel2 = new Panel();
            Salir = new FontAwesome.Sharp.IconPictureBox();
            maximizar = new FontAwesome.Sharp.IconPictureBox();
            lblpantallainfo = new Label();
            btnminimizar = new PictureBox();
            PanelContenedor = new Panel();
            timerhora = new System.Windows.Forms.Timer(components);
            MenuVertical.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox1).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Salir).BeginInit();
            ((System.ComponentModel.ISupportInitialize)maximizar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnminimizar).BeginInit();
            SuspendLayout();
            // 
            // MenuVertical
            // 
            MenuVertical.BackColor = Color.FromArgb(0, 122, 204);
            MenuVertical.Controls.Add(panel3);
            MenuVertical.Controls.Add(btncompras);
            MenuVertical.Controls.Add(btnventas);
            MenuVertical.Controls.Add(btndevoluciones);
            MenuVertical.Controls.Add(btncreditos);
            MenuVertical.Controls.Add(btnproductos);
            MenuVertical.Controls.Add(btnsalidasinventario);
            MenuVertical.Controls.Add(btnclientes);
            MenuVertical.Controls.Add(btnproveedores);
            MenuVertical.Controls.Add(btnusuarios);
            MenuVertical.Controls.Add(btnarqueo);
            MenuVertical.Controls.Add(btninformes);
            MenuVertical.Controls.Add(btnmantenimiento);
            MenuVertical.Controls.Add(btnacercade);
            MenuVertical.Dock = DockStyle.Left;
            MenuVertical.Location = new Point(0, 35);
            MenuVertical.Margin = new Padding(3, 4, 3, 4);
            MenuVertical.Name = "MenuVertical";
            MenuVertical.Size = new Size(239, 964);
            MenuVertical.TabIndex = 1;
            MenuVertical.Paint += MenuVertical_Paint;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel3.Controls.Add(lblusuario);
            panel3.Controls.Add(iconPictureBox1);
            panel3.Location = new Point(3, 4);
            panel3.Margin = new Padding(3, 4, 3, 4);
            panel3.Name = "panel3";
            panel3.Size = new Size(251, 68);
            panel3.TabIndex = 1;
            panel3.Paint += panel3_Paint;
            // 
            // lblusuario
            // 
            lblusuario.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblusuario.AutoSize = true;
            lblusuario.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            lblusuario.Location = new Point(91, 13);
            lblusuario.Name = "lblusuario";
            lblusuario.Size = new Size(109, 25);
            lblusuario.TabIndex = 0;
            lblusuario.Text = "USUARIO";
            lblusuario.Click += label2_Click;
            // 
            // iconPictureBox1
            // 
            iconPictureBox1.BackColor = Color.FromArgb(0, 122, 204);
            iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.User;
            iconPictureBox1.IconColor = Color.White;
            iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconPictureBox1.IconSize = 43;
            iconPictureBox1.Location = new Point(18, 13);
            iconPictureBox1.Margin = new Padding(3, 4, 3, 4);
            iconPictureBox1.Name = "iconPictureBox1";
            iconPictureBox1.Size = new Size(67, 43);
            iconPictureBox1.TabIndex = 0;
            iconPictureBox1.TabStop = false;
            iconPictureBox1.Click += iconPictureBox1_Click;
            // 
            // btncompras
            // 
            btncompras.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btncompras.FlatAppearance.BorderColor = SystemColors.Window;
            btncompras.FlatStyle = FlatStyle.Flat;
            btncompras.Font = new Font("Microsoft Sans Serif", 8F, FontStyle.Bold);
            btncompras.ForeColor = Color.White;
            btncompras.IconChar = FontAwesome.Sharp.IconChar.ShoppingBasket;
            btncompras.IconColor = Color.BlanchedAlmond;
            btncompras.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btncompras.IconSize = 40;
            btncompras.ImageAlign = ContentAlignment.MiddleLeft;
            btncompras.Location = new Point(3, 80);
            btncompras.Margin = new Padding(3, 4, 3, 4);
            btncompras.Name = "btncompras";
            btncompras.Padding = new Padding(40, 0, 0, 0);
            btncompras.Size = new Size(230, 60);
            btncompras.TabIndex = 1;
            btncompras.Text = "Compras";
            btncompras.TextAlign = ContentAlignment.MiddleLeft;
            btncompras.TextImageRelation = TextImageRelation.ImageBeforeText;
            btncompras.UseVisualStyleBackColor = true;
            btncompras.Click += iconButton1_Click;
            // 
            // btnventas
            // 
            btnventas.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnventas.FlatStyle = FlatStyle.Flat;
            btnventas.Font = new Font("Microsoft Sans Serif", 8F, FontStyle.Bold);
            btnventas.ForeColor = Color.White;
            btnventas.IconChar = FontAwesome.Sharp.IconChar.Store;
            btnventas.IconColor = Color.BlanchedAlmond;
            btnventas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnventas.IconSize = 40;
            btnventas.ImageAlign = ContentAlignment.MiddleLeft;
            btnventas.Location = new Point(3, 148);
            btnventas.Margin = new Padding(3, 4, 3, 4);
            btnventas.Name = "btnventas";
            btnventas.Padding = new Padding(40, 0, 0, 0);
            btnventas.Size = new Size(230, 60);
            btnventas.TabIndex = 2;
            btnventas.Text = "Ventas";
            btnventas.TextAlign = ContentAlignment.MiddleLeft;
            btnventas.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnventas.UseVisualStyleBackColor = true;
            btnventas.Click += btnventas_Click;
            // 
            // btndevoluciones
            // 
            btndevoluciones.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btndevoluciones.FlatStyle = FlatStyle.Flat;
            btndevoluciones.Font = new Font("Microsoft Sans Serif", 8F, FontStyle.Bold);
            btndevoluciones.ForeColor = Color.White;
            btndevoluciones.IconChar = FontAwesome.Sharp.IconChar.TentArrowTurnLeft;
            btndevoluciones.IconColor = Color.BlanchedAlmond;
            btndevoluciones.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btndevoluciones.IconSize = 40;
            btndevoluciones.ImageAlign = ContentAlignment.MiddleLeft;
            btndevoluciones.Location = new Point(3, 216);
            btndevoluciones.Margin = new Padding(3, 4, 3, 4);
            btndevoluciones.Name = "btndevoluciones";
            btndevoluciones.Padding = new Padding(40, 0, 0, 0);
            btndevoluciones.Size = new Size(230, 60);
            btndevoluciones.TabIndex = 3;
            btndevoluciones.Text = "Devoluciones";
            btndevoluciones.TextAlign = ContentAlignment.MiddleLeft;
            btndevoluciones.TextImageRelation = TextImageRelation.ImageBeforeText;
            btndevoluciones.UseVisualStyleBackColor = true;
            btndevoluciones.Click += btndevoluciones_Click;
            // 
            // btncreditos
            // 
            btncreditos.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btncreditos.FlatStyle = FlatStyle.Flat;
            btncreditos.Font = new Font("Microsoft Sans Serif", 8F, FontStyle.Bold);
            btncreditos.ForeColor = Color.White;
            btncreditos.IconChar = FontAwesome.Sharp.IconChar.SackDollar;
            btncreditos.IconColor = Color.BlanchedAlmond;
            btncreditos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btncreditos.IconSize = 40;
            btncreditos.ImageAlign = ContentAlignment.MiddleLeft;
            btncreditos.Location = new Point(3, 284);
            btncreditos.Margin = new Padding(3, 4, 3, 4);
            btncreditos.Name = "btncreditos";
            btncreditos.Padding = new Padding(40, 0, 0, 0);
            btncreditos.Size = new Size(230, 60);
            btncreditos.TabIndex = 5;
            btncreditos.Text = "Créditos";
            btncreditos.TextAlign = ContentAlignment.MiddleLeft;
            btncreditos.TextImageRelation = TextImageRelation.ImageBeforeText;
            btncreditos.UseVisualStyleBackColor = true;
            btncreditos.Click += btncreditos_Click;
            // 
            // btnproductos
            // 
            btnproductos.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnproductos.FlatStyle = FlatStyle.Flat;
            btnproductos.Font = new Font("Microsoft Sans Serif", 8F, FontStyle.Bold);
            btnproductos.ForeColor = Color.White;
            btnproductos.IconChar = FontAwesome.Sharp.IconChar.ProductHunt;
            btnproductos.IconColor = Color.BlanchedAlmond;
            btnproductos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnproductos.IconSize = 40;
            btnproductos.ImageAlign = ContentAlignment.MiddleLeft;
            btnproductos.Location = new Point(3, 352);
            btnproductos.Margin = new Padding(3, 4, 3, 4);
            btnproductos.Name = "btnproductos";
            btnproductos.Padding = new Padding(40, 0, 0, 0);
            btnproductos.Size = new Size(230, 60);
            btnproductos.TabIndex = 6;
            btnproductos.Text = "Productos";
            btnproductos.TextAlign = ContentAlignment.MiddleLeft;
            btnproductos.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnproductos.UseVisualStyleBackColor = true;
            btnproductos.Click += btnproductos_Click;
            // 
            // btnsalidasinventario
            // 
            btnsalidasinventario.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnsalidasinventario.FlatStyle = FlatStyle.Flat;
            btnsalidasinventario.Font = new Font("Microsoft Sans Serif", 8F, FontStyle.Bold);
            btnsalidasinventario.ForeColor = Color.White;
            btnsalidasinventario.IconChar = FontAwesome.Sharp.IconChar.StoreAltSlash;
            btnsalidasinventario.IconColor = Color.BlanchedAlmond;
            btnsalidasinventario.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnsalidasinventario.IconSize = 40;
            btnsalidasinventario.ImageAlign = ContentAlignment.MiddleLeft;
            btnsalidasinventario.Location = new Point(3, 420);
            btnsalidasinventario.Margin = new Padding(3, 4, 3, 4);
            btnsalidasinventario.Name = "btnsalidasinventario";
            btnsalidasinventario.Padding = new Padding(40, 0, 0, 0);
            btnsalidasinventario.Size = new Size(230, 60);
            btnsalidasinventario.TabIndex = 4;
            btnsalidasinventario.Text = "Otras salidas de inventario";
            btnsalidasinventario.TextAlign = ContentAlignment.MiddleLeft;
            btnsalidasinventario.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnsalidasinventario.UseVisualStyleBackColor = true;
            btnsalidasinventario.Click += btnsalidasinventario_Click;
            // 
            // btnclientes
            // 
            btnclientes.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnclientes.FlatStyle = FlatStyle.Flat;
            btnclientes.Font = new Font("Microsoft Sans Serif", 8F, FontStyle.Bold);
            btnclientes.ForeColor = Color.White;
            btnclientes.IconChar = FontAwesome.Sharp.IconChar.PeopleGroup;
            btnclientes.IconColor = Color.BlanchedAlmond;
            btnclientes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnclientes.IconSize = 40;
            btnclientes.ImageAlign = ContentAlignment.MiddleLeft;
            btnclientes.Location = new Point(3, 488);
            btnclientes.Margin = new Padding(3, 4, 3, 4);
            btnclientes.Name = "btnclientes";
            btnclientes.Padding = new Padding(40, 0, 0, 0);
            btnclientes.Size = new Size(230, 60);
            btnclientes.TabIndex = 7;
            btnclientes.Text = "Clientes";
            btnclientes.TextAlign = ContentAlignment.MiddleLeft;
            btnclientes.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnclientes.UseVisualStyleBackColor = true;
            btnclientes.Click += btnclientes_Click;
            // 
            // btnproveedores
            // 
            btnproveedores.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnproveedores.FlatStyle = FlatStyle.Flat;
            btnproveedores.Font = new Font("Microsoft Sans Serif", 8F, FontStyle.Bold);
            btnproveedores.ForeColor = Color.White;
            btnproveedores.IconChar = FontAwesome.Sharp.IconChar.PeopleLine;
            btnproveedores.IconColor = Color.BlanchedAlmond;
            btnproveedores.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnproveedores.IconSize = 40;
            btnproveedores.ImageAlign = ContentAlignment.MiddleLeft;
            btnproveedores.Location = new Point(3, 556);
            btnproveedores.Margin = new Padding(3, 4, 3, 4);
            btnproveedores.Name = "btnproveedores";
            btnproveedores.Padding = new Padding(40, 0, 0, 0);
            btnproveedores.Size = new Size(230, 60);
            btnproveedores.TabIndex = 8;
            btnproveedores.Text = "Proveedores";
            btnproveedores.TextAlign = ContentAlignment.MiddleLeft;
            btnproveedores.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnproveedores.UseVisualStyleBackColor = true;
            btnproveedores.Click += btnproveedores_Click;
            // 
            // btnusuarios
            // 
            btnusuarios.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnusuarios.FlatStyle = FlatStyle.Flat;
            btnusuarios.Font = new Font("Microsoft Sans Serif", 8F, FontStyle.Bold);
            btnusuarios.ForeColor = Color.White;
            btnusuarios.IconChar = FontAwesome.Sharp.IconChar.PersonCircleCheck;
            btnusuarios.IconColor = Color.BlanchedAlmond;
            btnusuarios.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnusuarios.IconSize = 40;
            btnusuarios.ImageAlign = ContentAlignment.MiddleLeft;
            btnusuarios.Location = new Point(3, 624);
            btnusuarios.Margin = new Padding(3, 4, 3, 4);
            btnusuarios.Name = "btnusuarios";
            btnusuarios.Padding = new Padding(40, 0, 0, 0);
            btnusuarios.Size = new Size(230, 60);
            btnusuarios.TabIndex = 9;
            btnusuarios.Text = "Usuarios";
            btnusuarios.TextAlign = ContentAlignment.MiddleLeft;
            btnusuarios.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnusuarios.UseVisualStyleBackColor = true;
            btnusuarios.Click += btnusuarios_Click;
            // 
            // btnarqueo
            // 
            btnarqueo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnarqueo.FlatStyle = FlatStyle.Flat;
            btnarqueo.Font = new Font("Microsoft Sans Serif", 8F, FontStyle.Bold);
            btnarqueo.ForeColor = Color.White;
            btnarqueo.IconChar = FontAwesome.Sharp.IconChar.PiggyBank;
            btnarqueo.IconColor = Color.BlanchedAlmond;
            btnarqueo.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnarqueo.IconSize = 40;
            btnarqueo.ImageAlign = ContentAlignment.MiddleLeft;
            btnarqueo.Location = new Point(3, 692);
            btnarqueo.Margin = new Padding(3, 4, 3, 4);
            btnarqueo.Name = "btnarqueo";
            btnarqueo.Padding = new Padding(40, 0, 0, 0);
            btnarqueo.Size = new Size(230, 60);
            btnarqueo.TabIndex = 10;
            btnarqueo.Text = "Arqueo de caja";
            btnarqueo.TextAlign = ContentAlignment.MiddleLeft;
            btnarqueo.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnarqueo.UseVisualStyleBackColor = true;
            btnarqueo.Click += btnarqueo_Click;
            // 
            // btninformes
            // 
            btninformes.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btninformes.FlatStyle = FlatStyle.Flat;
            btninformes.Font = new Font("Microsoft Sans Serif", 8F, FontStyle.Bold);
            btninformes.ForeColor = Color.White;
            btninformes.IconChar = FontAwesome.Sharp.IconChar.FileZipper;
            btninformes.IconColor = Color.BlanchedAlmond;
            btninformes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btninformes.IconSize = 40;
            btninformes.ImageAlign = ContentAlignment.MiddleLeft;
            btninformes.Location = new Point(3, 760);
            btninformes.Margin = new Padding(3, 4, 3, 4);
            btninformes.Name = "btninformes";
            btninformes.Padding = new Padding(40, 0, 0, 0);
            btninformes.Size = new Size(230, 60);
            btninformes.TabIndex = 11;
            btninformes.Text = "Informes";
            btninformes.TextAlign = ContentAlignment.MiddleLeft;
            btninformes.TextImageRelation = TextImageRelation.ImageBeforeText;
            btninformes.UseVisualStyleBackColor = true;
            btninformes.Click += btninformes_Click;
            // 
            // btnmantenimiento
            // 
            btnmantenimiento.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnmantenimiento.FlatStyle = FlatStyle.Flat;
            btnmantenimiento.Font = new Font("Microsoft Sans Serif", 8F, FontStyle.Bold);
            btnmantenimiento.ForeColor = Color.White;
            btnmantenimiento.IconChar = FontAwesome.Sharp.IconChar.Tools;
            btnmantenimiento.IconColor = Color.BlanchedAlmond;
            btnmantenimiento.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnmantenimiento.IconSize = 40;
            btnmantenimiento.ImageAlign = ContentAlignment.MiddleLeft;
            btnmantenimiento.Location = new Point(3, 828);
            btnmantenimiento.Margin = new Padding(3, 4, 3, 4);
            btnmantenimiento.Name = "btnmantenimiento";
            btnmantenimiento.Padding = new Padding(40, 0, 0, 0);
            btnmantenimiento.Size = new Size(230, 60);
            btnmantenimiento.TabIndex = 12;
            btnmantenimiento.Text = "Mantenimiento";
            btnmantenimiento.TextAlign = ContentAlignment.MiddleLeft;
            btnmantenimiento.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnmantenimiento.UseVisualStyleBackColor = true;
            btnmantenimiento.Click += btnmantenimiento_Click;
            // 
            // btnacercade
            // 
            btnacercade.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnacercade.FlatStyle = FlatStyle.Flat;
            btnacercade.Font = new Font("Microsoft Sans Serif", 8F, FontStyle.Bold);
            btnacercade.ForeColor = Color.White;
            btnacercade.IconChar = FontAwesome.Sharp.IconChar.Uncharted;
            btnacercade.IconColor = Color.BlanchedAlmond;
            btnacercade.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnacercade.IconSize = 40;
            btnacercade.ImageAlign = ContentAlignment.MiddleLeft;
            btnacercade.Location = new Point(3, 896);
            btnacercade.Margin = new Padding(3, 4, 3, 4);
            btnacercade.Name = "btnacercade";
            btnacercade.Padding = new Padding(40, 0, 0, 0);
            btnacercade.Size = new Size(230, 60);
            btnacercade.TabIndex = 13;
            btnacercade.Text = "Acerca de";
            btnacercade.TextAlign = ContentAlignment.MiddleLeft;
            btnacercade.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnacercade.UseVisualStyleBackColor = true;
            btnacercade.Click += btnacercade_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(Salir);
            panel2.Controls.Add(maximizar);
            panel2.Controls.Add(lblpantallainfo);
            panel2.Controls.Add(btnminimizar);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(1577, 35);
            panel2.TabIndex = 3;
            panel2.Paint += panel2_Paint;
            // 
            // Salir
            // 
            Salir.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Salir.BackColor = SystemColors.Control;
            Salir.Cursor = Cursors.Hand;
            Salir.ForeColor = Color.Black;
            Salir.IconChar = FontAwesome.Sharp.IconChar.X;
            Salir.IconColor = Color.Black;
            Salir.IconFont = FontAwesome.Sharp.IconFont.Auto;
            Salir.IconSize = 28;
            Salir.Location = new Point(1525, 3);
            Salir.Margin = new Padding(3, 4, 3, 4);
            Salir.Name = "Salir";
            Salir.Size = new Size(30, 28);
            Salir.SizeMode = PictureBoxSizeMode.Zoom;
            Salir.TabIndex = 0;
            Salir.TabStop = false;
            Salir.Click += Salir_Click;
            // 
            // maximizar
            // 
            maximizar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            maximizar.BackColor = SystemColors.Control;
            maximizar.Cursor = Cursors.Hand;
            maximizar.ForeColor = Color.Black;
            maximizar.IconChar = FontAwesome.Sharp.IconChar.Square;
            maximizar.IconColor = Color.Black;
            maximizar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            maximizar.IconSize = 31;
            maximizar.Location = new Point(1471, 2);
            maximizar.Margin = new Padding(3, 4, 3, 4);
            maximizar.Name = "maximizar";
            maximizar.Size = new Size(49, 31);
            maximizar.SizeMode = PictureBoxSizeMode.Zoom;
            maximizar.TabIndex = 0;
            maximizar.TabStop = false;
            maximizar.Click += maximizar_Click;
            // 
            // lblpantallainfo
            // 
            lblpantallainfo.BackColor = Color.FromArgb(0, 122, 204);
            lblpantallainfo.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            lblpantallainfo.ForeColor = Color.White;
            lblpantallainfo.Location = new Point(0, 0);
            lblpantallainfo.Name = "lblpantallainfo";
            lblpantallainfo.Size = new Size(239, 35);
            lblpantallainfo.TabIndex = 0;
            lblpantallainfo.Text = "MENÚ PRINCIPAL";
            lblpantallainfo.TextAlign = ContentAlignment.MiddleCenter;
            lblpantallainfo.Click += lblpantallainfo_Click;
            // 
            // btnminimizar
            // 
            btnminimizar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnminimizar.Image = (Image)resources.GetObject("btnminimizar.Image");
            btnminimizar.Location = new Point(1420, 2);
            btnminimizar.Margin = new Padding(3, 2, 3, 2);
            btnminimizar.Name = "btnminimizar";
            btnminimizar.Size = new Size(40, 28);
            btnminimizar.SizeMode = PictureBoxSizeMode.StretchImage;
            btnminimizar.TabIndex = 15;
            btnminimizar.TabStop = false;
            btnminimizar.Click += btnminimizar_Click;
            // 
            // PanelContenedor
            // 
            PanelContenedor.Dock = DockStyle.Fill;
            PanelContenedor.Location = new Point(239, 35);
            PanelContenedor.Margin = new Padding(3, 4, 3, 4);
            PanelContenedor.Name = "PanelContenedor";
            PanelContenedor.Size = new Size(1338, 964);
            PanelContenedor.TabIndex = 2;
            PanelContenedor.Paint += PanelContenedor_Paint;
            // 
            // timerhora
            // 
            timerhora.Enabled = true;
            timerhora.Tick += timerhora_Tick;
            // 
            // menu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1577, 999);
            Controls.Add(PanelContenedor);
            Controls.Add(MenuVertical);
            Controls.Add(panel2);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "menu";
            Text = "Menu_Inicio";
            Load += Menu_Inicio_Load;
            MenuVertical.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox1).EndInit();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)Salir).EndInit();
            ((System.ComponentModel.ISupportInitialize)maximizar).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnminimizar).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel MenuVertical;
        private FontAwesome.Sharp.IconButton btninformes;
        private FontAwesome.Sharp.IconButton btnmantenimiento;
        private FontAwesome.Sharp.IconButton btnacercade;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblpantallainfo;
        private FontAwesome.Sharp.IconPictureBox maximizar;
        private FontAwesome.Sharp.IconPictureBox Salir;
        private FontAwesome.Sharp.IconButton btncompras;
        private FontAwesome.Sharp.IconButton btnventas;
        private FontAwesome.Sharp.IconButton btndevoluciones;
        private FontAwesome.Sharp.IconButton btnsalidasinventario;
        private FontAwesome.Sharp.IconButton btncreditos;
        private FontAwesome.Sharp.IconButton btnproductos;
        private FontAwesome.Sharp.IconButton btnclientes;
        private FontAwesome.Sharp.IconButton btnproveedores;
        private FontAwesome.Sharp.IconButton btnusuarios;
        private FontAwesome.Sharp.IconButton btnarqueo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel PanelContenedor;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblfecha;
        private System.Windows.Forms.Timer timerhora;
        private System.Windows.Forms.Label lblhora;
        private System.Windows.Forms.PictureBox btnminimizar;
        private Label lblusuario;
    }
}