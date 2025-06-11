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
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace formstienda
{
    public partial class Proveedores : Form
    {
        private ProveedorServicio? proveedorServicio;
        private BindingList<Proveedor>? listaProveedores;

        public Proveedores()
        {
            InitializeComponent();
            dtgproveedores.CellFormatting += dtgproveedores_CellFormatting;
        }

        public class EstadoOpcion
        {
            public string Descripcion { get; set; }
            public bool Valor { get; set; }

            public override string ToString()
            {
                return Descripcion;
            }
        }

        private void limpiarcampos()
        {
            txtNombre_proveedor.Clear();
            txtApellido_proveedores.Clear();
            txtCodigo_ruc.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
        }


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

            dtgproveedores.Columns["Compras"].Visible = false;
            dtgproveedores.Columns["CodigoRuc"].HeaderText = "Código RUC";
            dtgproveedores.Columns["NombreProveedor"].HeaderText = "Nombre";
            dtgproveedores.Columns["ApellidoProveedor"].HeaderText = "Apellido";
            dtgproveedores.Columns["TelefonoProveedor"].HeaderText = "Numero telefónico";
            dtgproveedores.Columns["CorreoProveedor"].HeaderText = "Correo electrónico";
            dtgproveedores.Columns["EstadoProveedor"].HeaderText = "Estado";

            DataGridViewComboBoxColumn estadoComboCol = new DataGridViewComboBoxColumn();
            estadoComboCol.Name = "EstadoProveedor";
            estadoComboCol.HeaderText = "Estado";
            estadoComboCol.DataPropertyName = "EstadoProveedor"; // Importante: esto se liga al valor bool de tu modelo
            estadoComboCol.DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton;
            estadoComboCol.FlatStyle = FlatStyle.Flat;

            estadoComboCol.DisplayMember = "Descripcion"; // Lo que se muestra
            estadoComboCol.ValueMember = "Valor";         // El valor real (bool)
            estadoComboCol.DataSource = new List<EstadoOpcion>
            {
                new EstadoOpcion { Descripcion = "Activo", Valor = true },
                new EstadoOpcion { Descripcion = "Inactivo", Valor = false }
            };

            int index = dtgproveedores.Columns["EstadoProveedor"].Index;
            dtgproveedores.Columns.RemoveAt(index);
            dtgproveedores.Columns.Insert(index, estadoComboCol);

            /* estadoComboCol = new DataGridViewComboBoxColumn();
            estadoComboCol.Name = "EstadoProveedor";
            estadoComboCol.HeaderText = "Estado";
            estadoComboCol.DataPropertyName = "EstadoProveedor"; 
            estadoComboCol.DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton;
            estadoComboCol.FlatStyle = FlatStyle.Flat;

            estadoComboCol.Items.AddRange(true, false);

            int index = dtgproveedores.Columns["EstadoProveedor"].Index;
            dtgproveedores.Columns.RemoveAt(index);
            dtgproveedores.Columns.Insert(index, estadoComboCol);*/
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
            txtTelefono.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            var codigoruc = txtCodigo_ruc.Text.Trim().Replace("-", "");

            // Validar formato
            string patronCodigoRuc = @"^\d{13}[A-Z]{1}$";
            if (!Regex.IsMatch(codigoruc, patronCodigoRuc))
            {
                MessageBox.Show("El formato del código RUC es incorrecto.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var proveedor = new Proveedor
            {
                CodigoRuc = codigoruc,
                NombreProveedor = txtNombre_proveedor.Text,
                ApellidoProveedor = txtApellido_proveedores.Text,
                TelefonoProveedor = txtTelefono.Text,
                CorreoProveedor = txtCorreo.Text,
                EstadoProveedor = cmbestado.Text == "Activo" ? true : false,
            };

            if (string.IsNullOrWhiteSpace(txtNombre_proveedor.Text) ||
                string.IsNullOrWhiteSpace(txtApellido_proveedores.Text) ||
                string.IsNullOrWhiteSpace(txtTelefono.Text) ||
                string.IsNullOrWhiteSpace(txtCodigo_ruc.Text))
            {
                MessageBox.Show("Rellene todos los campos obligatorios",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            var telefonoProveedor = txtTelefono.Text.Trim();
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

        private void dtgproveedores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtgproveedores_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            var row = dtgproveedores.Rows[e.RowIndex];

            string codigoRuc = row.Cells["CodigoRuc"].Value?.ToString()?.Trim() ?? "";
            string rucAnterior = row.Cells["CodigoRuc"].Tag?.ToString() ?? codigoRuc;

            string nombre = row.Cells["NombreProveedor"].Value?.ToString()?.Trim() ?? "";
            string apellido = row.Cells["ApellidoProveedor"].Value?.ToString()?.Trim() ?? "";
            string telefono = row.Cells["TelefonoProveedor"].Value?.ToString()?.Trim() ?? "";
            string correo = row.Cells["CorreoProveedor"].Value?.ToString()?.Trim() ?? "";
            object valorEstado = row.Cells["EstadoProveedor"].Value;

            bool estado = false;
            if (valorEstado is bool b) estado = b;
            else if (valorEstado is string s) estado = s == "Activo";

            // Validaciones
            if (string.IsNullOrWhiteSpace(codigoRuc) || string.IsNullOrWhiteSpace(nombre)
                || string.IsNullOrWhiteSpace(apellido) || string.IsNullOrWhiteSpace(telefono))
            {
                MessageBox.Show("Todos los campos obligatorios deben estar llenos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string patronRuc = @"^\d{13}[A-Z]{1}$";
            if (!Regex.IsMatch(codigoRuc, patronRuc))
            {
                MessageBox.Show("El formato del código RUC es incorrecto.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string patronTelefono = @"^\d{8}$";
            if (!Regex.IsMatch(telefono, patronTelefono))
            {
                MessageBox.Show("El formato del teléfono es incorrecto.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            var proveedorDuplicado = proveedorServicio.ListarProveedores().FirstOrDefault(p =>
                p.CodigoRuc != rucAnterior && (
                    (!string.IsNullOrWhiteSpace(correo) && p.CorreoProveedor == correo) ||
                    p.TelefonoProveedor == telefono
                ));

            if (proveedorDuplicado != null)
            {
                if (proveedorDuplicado.TelefonoProveedor == telefono)
                {
                    MessageBox.Show("Ya existe un proveedor con ese número de teléfono.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!string.IsNullOrWhiteSpace(correo) && proveedorDuplicado.CorreoProveedor == correo)
                {
                    MessageBox.Show("Ya existe un proveedor con ese correo electrónico.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            
            var proveedorActualizado = new Proveedor
            {
                CodigoRuc = codigoRuc,
                NombreProveedor = nombre,
                ApellidoProveedor = apellido,
                TelefonoProveedor = telefono,
                CorreoProveedor = correo,
                EstadoProveedor = estado
            };

            
            if (proveedorServicio.ActualizarProveedor(proveedorActualizado, rucAnterior))
            {
                MessageBox.Show("Proveedor actualizado correctamente.");
            }
            else
            {
                MessageBox.Show("No se pudo actualizar el proveedor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            row.Cells["CodigoRuc"].Tag = null;

        }

        private void Proveedores_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo números y control keys como backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dtgproveedores_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dtgproveedores.Columns[e.ColumnIndex].Name == "EstadoProveedor" &&
                dtgproveedores.Columns[e.ColumnIndex] is DataGridViewComboBoxColumn)
            {
                if (e.Value is bool estado)
                {
                    e.Value = estado ? "Activo" : "Inactivo";
                    e.FormattingApplied = true;
                }
            }
        }

        private void dtgproveedores_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (dtgproveedores.Columns[e.ColumnIndex].Name == "CodigoRuc")
            {
                var cell = dtgproveedores.Rows[e.RowIndex].Cells["CodigoRuc"];
                cell.Tag = cell.Value?.ToString();
            }
        }
    }
}
