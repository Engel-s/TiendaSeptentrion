using System;
using System.Linq;
using System.Windows.Forms;
using formstienda.Datos;
using Microsoft.EntityFrameworkCore;

namespace formstienda.capa_de_presentación
{
    public partial class ControldeEgresos : Form
    {
        private readonly DbTiendaSeptentrionContext _contexto;
        private System.Windows.Forms.Timer searchTimer;

        public ControldeEgresos()
        {
            InitializeComponent();
            _contexto = new DbTiendaSeptentrionContext();

            // Configuración del timer para búsqueda con delay
            searchTimer = new System.Windows.Forms.Timer();
            searchTimer.Interval = 300; // 300ms de delay
            searchTimer.Tick += SearchTimer_Tick;

            txtBuscarEgresos.TextChanged += TxtBuscarEgresos_TextChanged;

            ConfigurarDataGridView();
            CargarDatosEgresos();
        }

        private void ConfigurarDataGridView()
        {
            DGCONTROLEGRESOS.AutoGenerateColumns = false;
            DGCONTROLEGRESOS.Columns.Clear();

            // Configuración de columnas
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
                DataPropertyName = "NombreUsuario",
                HeaderText = "Usuario",
                Name = "colUsuario",
                Width = 150
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

            
            DGCONTROLEGRESOS.AllowUserToAddRows = false;
            DGCONTROLEGRESOS.AllowUserToDeleteRows = false;
            DGCONTROLEGRESOS.ReadOnly = true;
            DGCONTROLEGRESOS.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGCONTROLEGRESOS.MultiSelect = false;
            DGCONTROLEGRESOS.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void CargarDatosEgresos(string filtro = "")
        {
            try
            {
                
                var query = _contexto.Egresos
                    .Join(_contexto.Usuarios,
                        egreso => egreso.IdUsuario,
                        usuario => usuario.IdUsuario,
                        (egreso, usuario) => new
                        {
                            egreso.FechaEgreso,
                            NombreUsuario = usuario.NombreUsuario + " " + usuario.ApellidoUsuario,
                            egreso.MotivoEgreso,
                            egreso.CantidadEgresadaCordoba,
                            egreso.CantidadEgresadaDolar,
                            egreso.IdUsuario 
                        });

                if (!string.IsNullOrWhiteSpace(filtro))
                {
                    query = query.Where(e =>
                        e.IdUsuario.ToString().Contains(filtro) || 
                        e.NombreUsuario.Contains(filtro) ||        
                        e.MotivoEgreso.Contains(filtro)            
                    );
                }

                DGCONTROLEGRESOS.DataSource = query.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar egresos: {ex.Message}\n\nDetalles: {ex.InnerException?.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtBuscarEgresos_TextChanged(object sender, EventArgs e)
        {
            searchTimer.Stop();
            searchTimer.Start();
        }

        private void SearchTimer_Tick(object sender, EventArgs e)
        {
            searchTimer.Stop();
            CargarDatosEgresos(txtBuscarEgresos.Text.Trim());
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