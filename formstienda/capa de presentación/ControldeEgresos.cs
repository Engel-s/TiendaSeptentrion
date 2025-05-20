using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using formstienda.Datos;
using Microsoft.EntityFrameworkCore;

namespace formstienda.capa_de_presentación
{
    public partial class ControldeEgresos : Form
    {
        private readonly DbTiendaSeptentrionContext _contexto;

        public ControldeEgresos()
        {
            InitializeComponent();
            _contexto = new DbTiendaSeptentrionContext();
            ConfigurarDataGridView();
            CargarDatosEgresos();
        }

        private void ConfigurarDataGridView()
        {
            // Limpiar configuración previa
            DGCONTROLEGRESOS.AutoGenerateColumns = false;
            DGCONTROLEGRESOS.Columns.Clear();

            // Configurar columnas con los campos solicitados
            DGCONTROLEGRESOS.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "FechaEgreso",
                HeaderText = "Fecha Egreso",
                Name = "colFechaEgreso",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" }
            });

            DGCONTROLEGRESOS.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "IdUsuario",
                HeaderText = "ID Usuario",
                Name = "colIdUsuario",
                Width = 100
            });

            DGCONTROLEGRESOS.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "MotivoEgreso",
                HeaderText = "Motivo",
                Name = "colMotivo",
                Width = 200
            });

            DGCONTROLEGRESOS.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "CantidadEgresadaCordoba",
                HeaderText = "Córdobas",
                Name = "colCordobas",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "N2",
                    Alignment = DataGridViewContentAlignment.MiddleRight
                }
            });

            DGCONTROLEGRESOS.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "CantidadEgresadaDolar",
                HeaderText = "Dólares",
                Name = "colDolares",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "N2",
                    Alignment = DataGridViewContentAlignment.MiddleRight
                }
            });

            // Configuración adicional para solo lectura
            DGCONTROLEGRESOS.AllowUserToAddRows = false;
            DGCONTROLEGRESOS.AllowUserToDeleteRows = false;
            DGCONTROLEGRESOS.ReadOnly = true;
            DGCONTROLEGRESOS.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGCONTROLEGRESOS.MultiSelect = false;
            DGCONTROLEGRESOS.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void CargarDatosEgresos()
        {
            try
            {
                // Consulta directa a la base de datos
                var egresos = _contexto.Egresos
                    .AsNoTracking()
                    .Select(e => new
                    {
                        e.FechaEgreso,
                        e.IdUsuario,
                        e.MotivoEgreso,
                        e.CantidadEgresadaCordoba,
                        e.CantidadEgresadaDolar
                    })
                    .ToList();

                DGCONTROLEGRESOS.DataSource = egresos;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los egresos: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ControldeEgresos_Load(object sender, EventArgs e)
        {
          
        }
    }
}