using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.TextFormatting;
using formstienda.Models;
using Microsoft.EntityFrameworkCore;
using AppGestorEF.Data;

namespace formstienda
{
    public partial class Proveedores : Form
    {
        private Proveedores? Proveedor;
        private BindingList<Proveedores>? listaproveedores;
        public Proveedores()
        {
            InitializeComponent();
        }


        DbContext db = new DbContext();

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void cbproducto_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Proveedores_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string texto = txtEstado.Text.ToLower();
            bool estado = texto switch
            {
                "activo" => true,
                "inactivo" => false,
                _ => throw new ArgumentException("Valor no válido"),
            };
            try
            {

                var nuevo = new Proveedor()
                {
                    CodigoRuc = txtCodigo_ruc.Text,
                    TelefonoProveedor = txtTelefono.Text,
                    NombreProveedor = txtNombre_proveedor.Text,
                    EstadoProveedor = estado(),
                    ApellidoProveedor = txtApellido_proveedores.Text,
                    CorreoProveedor = textCorreo.Text
                }
                 db.Proveedor(nuevo);
                var listaProveedores = db.Proveedor.ToList();
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
