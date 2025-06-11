using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using formstienda.capa_de_negocios;
using formstienda.Datos;

namespace formstienda.capa_de_presentación
{
    public partial class VentanaEmergenteProveedor : Form
    {
        private ProveedorServicio? proveedorServicio;
        private BindingList<Proveedor>? listaProveedores;

        public VentanaEmergenteProveedor()
        {
            InitializeComponent();
        }
        private void limpiarcampos()
        {
            txtnombreproveedor.Clear();
            txtapeliidoproveedor.Clear();
            txtcodigorucproveedor.Clear();
            txttelefonoproveedor.Clear();
            txtcorreoproveedor.Clear();
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void VentanaEmergenteProveedor_Load(object sender, EventArgs e)
        {
            cmbestado.SelectedItem = "Activo";
            //instanciar el servicio
            proveedorServicio = new ProveedorServicio();

            //Lista para almacenar los proveedores
            listaProveedores = new BindingList<Proveedor>(proveedorServicio.ListarProveedores());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txttelefonoproveedor.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            var codigoruc = txtcodigorucproveedor.Text.Trim().Replace("-", "");
            string patronCodigoRuc = @"^\d{13}[A-Z]{1}$";

            if (!Regex.IsMatch(codigoruc, patronCodigoRuc))
            {
                MessageBox.Show("El formato del codigo RUC es incorrecto.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var proveedor = new Proveedor
            {
                CodigoRuc = codigoruc,
                NombreProveedor = txtnombreproveedor.Text,
                ApellidoProveedor = txtapeliidoproveedor.Text,
                TelefonoProveedor = txttelefonoproveedor.Text,
                CorreoProveedor = txtcorreoproveedor.Text,
                EstadoProveedor = cmbestado.Text == "Activo" ? true : false,
            };

            if (string.IsNullOrWhiteSpace(txtnombreproveedor.Text) ||
                string.IsNullOrWhiteSpace(txtapeliidoproveedor.Text) ||
                string.IsNullOrWhiteSpace(txttelefonoproveedor.Text) ||
                string.IsNullOrWhiteSpace(txtcodigorucproveedor.Text))
            {
                MessageBox.Show("Rellene todos los campos obligatorios",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            var telefonoProveedor = txttelefonoproveedor.Text.Trim();
            string patronTelefono = @"^\d{8}$";

            if (!Regex.IsMatch(telefonoProveedor, patronTelefono))
            {
                MessageBox.Show("El formato del telefono es incorrecto.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var rucDuplicado = proveedorServicio.ListarProveedores()
                .FirstOrDefault(p => p.CodigoRuc == proveedor.CodigoRuc);

            if (rucDuplicado != null)
            {
                MessageBox.Show("Este proveedor ya existe, verifique el código RUC.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var telefonoDuplicado = proveedorServicio.ListarProveedores()
                .FirstOrDefault(p => p.TelefonoProveedor == proveedor.TelefonoProveedor);

            if (telefonoDuplicado != null)
            {
                MessageBox.Show("Este proveedor ya existe, verifique el número de teléfono.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            if (!string.IsNullOrWhiteSpace(proveedor.CorreoProveedor))
            {
                var correoDuplicado = proveedorServicio.ListarProveedores()
                    .FirstOrDefault(p => p.CorreoProveedor == proveedor.CorreoProveedor);

                if (correoDuplicado != null)
                {
                    MessageBox.Show("Este proveedor ya existe, verifique el correo electrónico.",
                        "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            //conectando con el servicio
            proveedorServicio.AgregarProveedor(proveedor);
            listaProveedores.Add(proveedor);
            MessageBox.Show("Proveedor agregado correctamente.");

            limpiarcampos();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            if(MessageBox.Show("¿Está seguro de que desea salir?", "Salir", buttons) == DialogResult.Yes)
            {
                limpiarcampos();
                this.Close();
            }
        }
    }
}
