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

        
            searchTimer = new System.Windows.Forms.Timer();
            searchTimer.Interval = 300; 
            searchTimer.Tick += SearchTimer_Tick;

            txtBuscarEgresos.TextChanged += TxtBuscarEgresos_TextChanged;
            dateTimePicker1.ValueChanged += DateTimePicker1_ValueChanged;

            ConfigurarDataGridView();
            CargarDatosEgresos();
        }

        private void ConfigurarDataGridView()
        {
            DGCONTROLEGRESOS.AutoGenerateColumns = false;
            DGCONTROLEGRESOS.Columns.Clear();

            DGCONTROLEGRESOS.DefaultCellStyle = new DataGridViewCellStyle
            {
                ForeColor = Color.Black,
                Font = new Font(DGCONTROLEGRESOS.Font, FontStyle.Regular)
            };

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
                HeaderText = "Monto Córdobas",
                Name = "colCordobas",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N2" }
            });

            DGCONTROLEGRESOS.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "CantidadEgresadaDolar",
                HeaderText = "Monto Dólares",
                Name = "colDolares",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N2" }
            });

            DGCONTROLEGRESOS.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "IdUsuario",
                HeaderText = "ID Usuario",
                Name = "colIdUsuario",
                Width = 80
            });
        }

        private void CargarDatosEgresos(string filtro = "", DateTime? fechaFiltro = null)
        {
            try
            {
                
                var query = _contexto.Egresos
                    .Join(_contexto.Usuarios,
                        egreso => egreso.IdUsuario,
                        usuario => usuario.IdUsuario,
                        (egreso, usuario) => new
                        {
                            egreso.IdEgreso, 
                            egreso.FechaEgreso,
                            NombreUsuario = usuario.NombreUsuario + " " + usuario.ApellidoUsuario,
                            egreso.MotivoEgreso,
                            egreso.CantidadEgresadaCordoba,
                            egreso.CantidadEgresadaDolar,
                            egreso.IdUsuario,

                        });


                if (!string.IsNullOrWhiteSpace(filtro))
                {
                    query = query.Where(e =>
                        e.IdUsuario.ToString().Contains(filtro) ||
                        e.NombreUsuario.Contains(filtro) ||
                        e.MotivoEgreso.Contains(filtro) ||
                        e.FechaEgreso.ToString().Contains(filtro) ||
                        e.CantidadEgresadaCordoba.ToString().Contains(filtro) ||
                        e.CantidadEgresadaDolar.ToString().Contains(filtro));
                }

    
                if (fechaFiltro.HasValue && dateTimePicker1.Checked)
                {
                    query = query.Where(e => e.FechaEgreso == DateOnly.FromDateTime(fechaFiltro.Value));
                }

               
                var resultado = query
                    .OrderByDescending(e => e.IdEgreso) 
                    .ThenByDescending(e => e.FechaEgreso)
                    .ToList();

           
                DGCONTROLEGRESOS.DataSource = resultado;

    
                if (DGCONTROLEGRESOS.Columns["colCordobas"] != null)
                    DGCONTROLEGRESOS.Columns["colCordobas"].DefaultCellStyle.Format = "N2";

                if (DGCONTROLEGRESOS.Columns["colDolares"] != null)
                    DGCONTROLEGRESOS.Columns["colDolares"].DefaultCellStyle.Format = "N2";

                if (DGCONTROLEGRESOS.Columns["colFechaEgreso"] != null)
                    DGCONTROLEGRESOS.Columns["colFechaEgreso"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }
            catch (Exception ex)
            {
               
            }
        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            CargarDatosEgresos(fechaFiltro: dateTimePicker1.Value);
        }

        private void TxtBuscarEgresos_TextChanged(object sender, EventArgs e)
        {
            searchTimer.Stop();
            searchTimer.Start();
        }

        private void SearchTimer_Tick(object sender, EventArgs e)
        {
            searchTimer.Stop();
            var fechaFiltro = dateTimePicker1.Checked ? dateTimePicker1.Value : (DateTime?)null;
            CargarDatosEgresos(txtBuscarEgresos.Text.Trim(), fechaFiltro);
        }

        private void btnLimpiarFiltro_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Today;
            dateTimePicker1.Checked = false;
            CargarDatosEgresos(txtBuscarEgresos.Text.Trim());
        }

        private void button1_Click(object sender, EventArgs e)
        {            
            this.Close();
            var menuForm = this.MdiParent as menu;
            if (menuForm == null)
            {
                menuForm = Application.OpenForms.OfType<menu>().FirstOrDefault();
            }
            if (menuForm != null)
            {
                menuForm.AbrirformInPanel(new Arqueo_Caja());
            }
        }
        private void ControldeEgresos_Load(object sender, EventArgs e)
        {
            
            CargarDatosEgresos();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            
        }

    }
}