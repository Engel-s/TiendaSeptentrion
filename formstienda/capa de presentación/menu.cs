using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static formstienda.Login;
using static formstienda.capa_de_presentación.Facturacion_de_crédito;

namespace formstienda.capa_de_presentación
{
    public partial class menu : Form
    {
        public menu(string EsAdmin)
        {
            InitializeComponent();

            if (EsAdmin == "Administrador")
            {
                btncompras.Visible = true;
                btnventas.Visible = true;
                btndevoluciones.Visible = true;
                btncreditos.Visible = true;
                btnproductos.Visible = true;
                btnsalidasinventario.Visible = true;
                btnclientes.Visible = true;
                btnproveedores.Visible = true;
                btnusuarios.Visible = true;
                btnarqueo.Visible = true;
                btninformes.Visible = true;
                btnacercade.Visible = true;
            }
            else
            {
                btncompras.Visible = true;
                btnventas.Visible = true;
                btndevoluciones.Visible = true;
                btncreditos.Visible = true;
                btnproductos.Visible = true;
                btnsalidasinventario.Visible = true;
                btnclientes.Visible = true;
                btnproveedores.Visible = false;
                btnusuarios.Visible = false;
                btnarqueo.Visible = true;
                btninformes.Visible = false;
                btnacercade.Visible = true;
            }
        }

        private void Menu_Inicio_Load(object sender, EventArgs e)
        {
            AbrirformInPanel(new menuprincipal());
            string usuario;
            usuario = UsuarioActivo.ObtenerNombreUsuario();
            lblusuario.Text = usuario;
            Facturacion_de_crédito facturacion_De_Crédito = new Facturacion_de_crédito();
            facturacion_De_Crédito.DesactivarCreditosSaldados();
        }




        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void iconPictureBox1_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();

            this.Close(); 
        }



        private void PanelContenedor_Paint(object sender, PaintEventArgs e)
        {

        }



        private void label2_Click(object sender, EventArgs e)
        {

        }
        public void AbrirformInPanel(Form formHijo)
        {
          
            if (PanelContenedor.Controls.Count > 0)
                PanelContenedor.Controls.RemoveAt(0); 

            formHijo.TopLevel = false; 
            formHijo.FormBorderStyle = FormBorderStyle.None; 
            formHijo.Dock = DockStyle.Fill; 

            PanelContenedor.Controls.Add(formHijo);
            PanelContenedor.Tag = formHijo;

            formHijo.Show(); 

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            AbrirformInPanel(new FormCompras());

        }

        private void Menu_Resize(object sender, EventArgs e)
        {
            foreach (Control ctrl in MenuVertical.Controls)
            {
                if (ctrl is Button)
                {
                    ctrl.Width = MenuVertical.Width - 20; // Ajusta el ancho con un margen
                    ctrl.Height = MenuVertical.Height / MenuVertical.Controls.Count - 10; // Ajusta la altura proporcionalmente
                }
            }
        }




        private void MenuVertical_Paint(object sender, PaintEventArgs e)
        {

        }

        private void maximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            Menu_Resize(null, null); // Llama al ajuste de botones
                                     // Centrar el Label en el formulario

        }

        private void Salir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
   
        private void FormResize(Form formHijo)
        {
            formHijo.WindowState = FormWindowState.Maximized;
            formHijo.WindowState = FormWindowState.Normal;
        }
        private void menu_ResizeEnd()
        {
            menu_ResizeEnd();
        }

        private void btnventas_Click(object sender, EventArgs e)
        {
            AbrirformInPanel(new Factura());
        }

        private void btndevoluciones_Click(object sender, EventArgs e)
        {
            AbrirformInPanel(new Devoluciones());
        }

        private void btnsalidasinventario_Click(object sender, EventArgs e)
        {
            AbrirformInPanel(new OtrasSalidas());
        }

        private void btncreditos_Click(object sender, EventArgs e)
        {
            AbrirformInPanel(new Facturacion_de_crédito());
        }

        private void btnproductos_Click(object sender, EventArgs e)
        {
            AbrirformInPanel(new FormProductos());
        }

        private void btnclientes_Click(object sender, EventArgs e)
        {
            AbrirformInPanel(new Clientes());
        }

        private void btnproveedores_Click(object sender, EventArgs e)
        {
            AbrirformInPanel(new Proveedores());
        }

        private void btnusuarios_Click(object sender, EventArgs e)
        {
            AbrirformInPanel(new Usuarioadmin());
        }

        private void btnarqueo_Click(object sender, EventArgs e)
        {
            AbrirformInPanel(new Arqueo_Caja());
        }

        private void btninformes_Click(object sender, EventArgs e)
        {
            AbrirformInPanel(new Informes());
        }

        private void btnmantenimiento_Click(object sender, EventArgs e)
        {
            AbrirformInPanel(new Mantenimiento());
        }

        private void timerhora_Tick(object sender, EventArgs e)
        {
            
        }

        private void btnminimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnacercade_Click(object sender, EventArgs e)
        {
            AbrirformInPanel(new acercade());
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblfecha_Click(object sender, EventArgs e)
        {

        }

        private void lblpantallainfo_Click(object sender, EventArgs e)
        {
            AbrirformInPanel(new menuprincipal());
        }
    }
}