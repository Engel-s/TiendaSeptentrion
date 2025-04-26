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
using System.Windows.Navigation;
using formstienda.capa_de_negocios;
using formstienda.Datos;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;


namespace formstienda
{
    public partial class Proveedores : Form
    {
        private ProveedorServicio? proveedorServicio;
        private BindingList<Proveedor>? listaProveedores;

        public Proveedores()
        {
            InitializeComponent();
        }


        private void limpiarcampos()
        {
            txtNombre_proveedor.Clear();
            txtApellido_proveedores.Clear();
            txtCodigo_ruc.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
        }
        //DbContext db = new DbContext();

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

        private void CargarProveedores()
        {
            //instanciar el servicio
            proveedorServicio = new ProveedorServicio();

            //Lista para almacenar los proveedores
            listaProveedores = new BindingList<Proveedor>(proveedorServicio.ListarProveedores());

            //vincular datagrid con el servicio
            dtgproveedores.DataSource = listaProveedores;
        }

        private void Proveedores_Load(object sender, EventArgs e)
        {
            //cuando se cargue el formulario se ejecuta esto
            CargarProveedores();
            cmbestado.SelectedItem = "Activo";
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


            var proveedor = new Proveedor
            {
                CodigoRuc = txtCodigo_ruc.Text,
                NombreProveedor = txtNombre_proveedor.Text,
                ApellidoProveedor = txtApellido_proveedores.Text,
                TelefonoProveedor = txtTelefono.Text,
                CorreoProveedor = txtCorreo.Text,
                EstadoProveedor = cmbestado.Text == "Activo" ? true : false,
            };

            if (txtNombre_proveedor.Text == "")
            {
                MessageBox.Show("Ingrese el nombre del proveedor");
                return;
            }

            if (txtApellido_proveedores.Text == "")
            {
                MessageBox.Show("Ingrese el apellido del proveedor");
                return;
            }
            if (txtTelefono.Text == "")
            {
                MessageBox.Show("Ingrese el numero telefonico del proveedor");
                return;
            }

            //Validar existencias del proveedor
            var proveedorExistente = proveedorServicio.ListarProveedores()
                .FirstOrDefault(p => p.CodigoRuc == proveedor.CodigoRuc
                || p.TelefonoProveedor == proveedor.TelefonoProveedor);

            if (proveedorExistente != null)
            {
                if (proveedorExistente.CodigoRuc == proveedor.CodigoRuc)
                {
                    MessageBox.Show("Este proveedor ya existe, verifique el codigo ruc");
                    return;
                }

                if (proveedorExistente.TelefonoProveedor == proveedor.TelefonoProveedor)
                {
                    MessageBox.Show("Este proveedor ya existe, verifique el numero de telefono");
                    return;
                }
            }

            //conectando con el servicio
            proveedorServicio.AgregarProveedor(proveedor);
            listaProveedores.Add(proveedor);
            MessageBox.Show("Proveedor agregado correctamente.");

            limpiarcampos();
        }

        private void dtgproveedores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtgproveedores_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int idProveedor = (int)dtgproveedores.Rows[e.RowIndex].Cells["IdProveedor"].Value;

            if (string.IsNullOrEmpty(dtgproveedores.Rows[e.RowIndex].Cells["NombreProveedor"].Value?.ToString()))
            {
                MessageBox.Show("El nombre no puede estar vacio");
                return;
            }
            if (string.IsNullOrEmpty(dtgproveedores.Rows[e.RowIndex].Cells["ApellidoProveedor"].Value?.ToString()))
            {
                MessageBox.Show("El apellido no puede estar vacio");
            }
            if (string.IsNullOrEmpty(dtgproveedores.Rows[e.RowIndex].Cells["TelefonoProveedor"].Value?.ToString()))
            {
                MessageBox.Show("El telefono no puede estar vacio");
            }

            var proveedorEditado = new Proveedor
            {
                IdProveedor = idProveedor,
                CodigoRuc = dtgproveedores.Rows[e.RowIndex].Cells["CodigoRuc"].Value?.ToString() ?? "",
                NombreProveedor = dtgproveedores.Rows[e.RowIndex].Cells["NombreProveedor"].Value?.ToString() ?? "",
                ApellidoProveedor = dtgproveedores.Rows[e.RowIndex].Cells["ApellidoProveedor"].Value.ToString() ?? "",
                TelefonoProveedor = dtgproveedores.Rows[e.RowIndex].Cells["TelefonoProveedor"].Value.ToString() ?? "",
                CorreoProveedor = dtgproveedores.Rows[e.RowIndex].Cells["CorreoProveedor"].Value?.ToString() ?? "",
                EstadoProveedor = Convert.ToBoolean(dtgproveedores.Rows[e.RowIndex].Cells["EstadoProveedor"].Value),

            };

            if (proveedorServicio.ActualizarProveedor(proveedorEditado))
            {
                MessageBox.Show("Proveedor actualizado correctamente");
            }
            else
                MessageBox.Show("No se pudo actualizar el proveedor");

        }

        private void Proveedores_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo números y control keys como backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Cancelar la tecla
            }
        }
    }
}
