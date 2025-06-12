using formstienda.capa_de_negocios;
using formstienda.capa_de_negocios;
using formstienda.Datos;
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
using System.Text.RegularExpressions;

namespace formstienda.capa_de_presentación
{
    public partial class Clientes : Form
    {
        private ClienteServicio? clienteServicio;
        private BindingList<Cliente>? Listacliente;

        public Clientes()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Clientes_Load(object sender, EventArgs e)
        {
            cargarclientes();

        }
        private void cargarclientes()
        {
            clienteServicio = new ClienteServicio();
            Listacliente = new BindingList<Cliente>(clienteServicio.Listaclientes());

            DGCLIENTES.DataSource = null;
            DGCLIENTES.Columns.Clear();
            DGCLIENTES.AutoGenerateColumns = false;
            DGCLIENTES.DataSource = Listacliente;

            DGCLIENTES.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "CedulaCliente",
                HeaderText = "Cédula",
                Name = "CedulaCliente",
                ReadOnly = true // No se puede editar porque es clave primaria
            });

            DGCLIENTES.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NombreCliente",
                HeaderText = "Nombre",
                Name = "NombreCliente"
            });

            DGCLIENTES.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ApellidoCliente",
                HeaderText = "Apellido",
                Name = "ApellidoCliente"
            });

            DGCLIENTES.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TelefonoCliente",
                HeaderText = "Teléfono",
                Name = "TelefonoCliente"
            });

            DGCLIENTES.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ColillaInssCliente",
                HeaderText = "Colilla INSS",
                Name = "ColillaInssCliente"
            });

            DGCLIENTES.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DireccionCliente",
                HeaderText = "Dirección",
                Name = "DireccionCliente"
            });

            DGCLIENTES.Columns.Add(new DataGridViewComboBoxColumn
            {
                DataPropertyName = "SujetoCredito",
                HeaderText = "¿Sujeto a Crédito?",
                Name = "SujetoCredito",
                DataSource = new[]
                {
        new { Texto = "Sí", Valor = true },
        new { Texto = "No", Valor = false }
    },
                DisplayMember = "Texto",
                ValueMember = "Valor",
                DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton,
                FlatStyle = FlatStyle.Flat
            });


            // Estilo del encabezado
            var headerStyle = DGCLIENTES.ColumnHeadersDefaultCellStyle;
            headerStyle.Font = new Font(DGCLIENTES.Font, FontStyle.Bold);
            headerStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            headerStyle.BackColor = Color.SteelBlue;
            headerStyle.ForeColor = Color.White;
            DGCLIENTES.EnableHeadersVisualStyles = false;

            // Estilo de las celdas
            DGCLIENTES.DefaultCellStyle.Font = new Font("Century gothic", 9);
            DGCLIENTES.DefaultCellStyle.BackColor = Color.White;
            DGCLIENTES.DefaultCellStyle.ForeColor = Color.Black;

            // Estilo alternado de filas
            DGCLIENTES.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;

            // Estilo de selección
            DGCLIENTES.DefaultCellStyle.SelectionBackColor = Color.DodgerBlue;
            DGCLIENTES.DefaultCellStyle.SelectionForeColor = Color.White;

            // Autoajuste del ancho de columnas
            DGCLIENTES.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }



        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void btnregistrar_Click(object sender, EventArgs e, string telefonoCliente)
        {
            // validar si ya existe el usuario

        }

        private void Clientes_Load_1(object sender, EventArgs e)
        {
            cargarclientes();
            lblcolilla.Visible = false;
            txtcolillainss.Visible = false;
        }

        private void btnregistrar_Click(object sender, EventArgs e)
        {


            // Crear cliente con valores limpios
            var cliente = new Cliente
            {
                NombreCliente = txtnombrecliente.Text.Trim(),
                ApellidoCliente = txtapellidocliente.Text.Trim(),
                DireccionCliente = txtdireccion.Text.Trim(),
                CedulaCliente = txtcedula.Text.Trim(),
                ColillaInssCliente = txtcolillainss.Text.Trim(),
                SujetoCredito = rbsi.Checked ? (bool?)true : (bool?)false,
                TelefonoCliente = new string(txttelefonocliente.Text.Trim().Where(char.IsDigit).ToArray())
            };

            // Validar campos obligatorios
            if (string.IsNullOrWhiteSpace(cliente.NombreCliente) ||
                string.IsNullOrWhiteSpace(cliente.ApellidoCliente) ||
                string.IsNullOrWhiteSpace(cliente.DireccionCliente) ||
                string.IsNullOrWhiteSpace(cliente.CedulaCliente) ||
                string.IsNullOrWhiteSpace(cliente.TelefonoCliente))
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios.");
                return;
            }

            // Validar que nombre y apellido contengan solo letras y espacios
            Regex soloLetras = new Regex(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$");

            if (!soloLetras.IsMatch(cliente.NombreCliente))
            {
                MessageBox.Show("El nombre solo debe contener letras.");
                return;
            }

            if (!soloLetras.IsMatch(cliente.ApellidoCliente))
            {
                MessageBox.Show("El apellido solo debe contener letras.");
                return;
            }

            // Validar cédula: (puedes ajustar el patrón según el formato que usas)
            Regex cedulaRegex = new Regex(@"^\d{13}[a-zA-Z]$");
            if (!cedulaRegex.IsMatch(cliente.CedulaCliente))
            {
                MessageBox.Show("La cédula solo puede contener un formato de trece digitos seguido de una letra.");
                return;
            }

            // Validar teléfono (solo números y entre 8 y 15 dígitos)
            if (cliente.TelefonoCliente.Length < 8 || cliente.TelefonoCliente.Length > 15)
            {
                MessageBox.Show("Ingrese un número de teléfono válido (entre 8 y 15 dígitos).");
                return;
            }
            // Si es sujeto a crédito, validar que la colilla INSS esté presente
            if (cliente.SujetoCredito == true && string.IsNullOrWhiteSpace(cliente.ColillaInssCliente))
            {
                MessageBox.Show("Debe ingresar la colilla INSS si el cliente es sujeto a crédito.");
                return;
            }


            // Validar si ya existe cliente con ese teléfono
            var clienteExistente = clienteServicio?.Listaclientes()
                                                   .FirstOrDefault(p => p.TelefonoCliente == cliente.TelefonoCliente && p.CedulaCliente == cliente.CedulaCliente);
            if (clienteExistente != null)
            {
                MessageBox.Show("Este cliente ya existe, agregue otro teléfono.");
                return;
            }

            // Agregar cliente
            clienteServicio?.Agregarcliente(cliente);
            Listacliente?.Add(cliente);
            MessageBox.Show("Cliente agregado correctamente");

            // Limpiar campos después de guardar
            txtnombrecliente.Text = "";
            txtapellidocliente.Text = "";
            txtdireccion.Text = "";
            txtcedula.Text = "";
            txtcolillainss.Text = "";
            txttelefonocliente.Text = "";
            rbsi.Checked = false;
            rbno.Checked = true;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            lblcolilla.Visible = true;
            txtcolillainss.Visible = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            lblcolilla.Visible = false;
            txtcolillainss.Visible = false;
            txtcolillainss.Clear();
        }

        private void DGCLIENTES_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var fila = DGCLIENTES.Rows[e.RowIndex];
                if (fila.IsNewRow) return;

                string cedula = fila.Cells["CedulaCliente"].Value?.ToString()?.Trim();
                if (string.IsNullOrWhiteSpace(cedula))
                {
                    MessageBox.Show("La cédula es obligatoria y no puede cambiarse.");
                    return;
                }

                string nombre = fila.Cells["NombreCliente"].Value?.ToString()?.Trim() ?? "";
                string apellido = fila.Cells["ApellidoCliente"].Value?.ToString()?.Trim() ?? "";
                string direccion = fila.Cells["DireccionCliente"].Value?.ToString()?.Trim() ?? "";
                string colilla = fila.Cells["ColillaInssCliente"].Value?.ToString()?.Trim() ?? "";
                string telefono = new string((fila.Cells["TelefonoCliente"].Value?.ToString() ?? "").Where(char.IsDigit).ToArray());

                bool sujetoCredito = false;
                if (fila.Cells["SujetoCredito"].Value is bool valor)
                    sujetoCredito = valor;

                // Validaciones básicas
                Regex soloLetras = new Regex(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$");
                if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(apellido) ||
                    string.IsNullOrWhiteSpace(direccion) || string.IsNullOrWhiteSpace(telefono))
                {
                    MessageBox.Show("Por favor, complete todos los campos obligatorios.");
                    return;
                }

                if (!soloLetras.IsMatch(nombre))
                {
                    MessageBox.Show("El nombre solo debe contener letras.");
                    return;
                }

                if (!soloLetras.IsMatch(apellido))
                {
                    MessageBox.Show("El apellido solo debe contener letras.");
                    return;
                }

                Regex cedulaRegex = new Regex(@"^\d{13}[a-zA-Z]$");
                if (!cedulaRegex.IsMatch(cedula))
                {
                    MessageBox.Show("La cédula debe tener 13 dígitos y una letra.");
                    return;
                }

                if (telefono.Length < 8 || telefono.Length > 15)
                {
                    MessageBox.Show("Teléfono debe tener entre 8 y 15 dígitos.");
                    return;
                }

                // ✅ Validar colilla si es sujeto a crédito
                if (sujetoCredito && string.IsNullOrWhiteSpace(colilla))
                {
                    MessageBox.Show("Debe ingresar la colilla INSS si el cliente es sujeto a crédito.");
                    return;
                }

                // Crear y actualizar cliente
                var clienteEditado = new Cliente
                {
                    CedulaCliente = cedula,
                    NombreCliente = nombre,
                    ApellidoCliente = apellido,
                    DireccionCliente = direccion,
                    ColillaInssCliente = colilla,
                    TelefonoCliente = telefono,
                    SujetoCredito = sujetoCredito
                };

                if (clienteServicio.Actualizarcliente(clienteEditado))
                    MessageBox.Show("Cliente actualizado correctamente");
                else
                    MessageBox.Show("No se pudo actualizar el cliente");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar cliente: " + ex.Message);
            }
        }
    }
}
