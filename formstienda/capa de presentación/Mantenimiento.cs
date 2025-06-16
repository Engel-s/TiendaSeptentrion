using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace formstienda
{
    public partial class Mantenimiento : Form
    {
        public Mantenimiento()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog openFile = new OpenFileDialog())
                {
                    openFile.Filter = "Archivo de respaldo (*.bak)|*.bak";
                    openFile.Title = "Seleccionar respaldo a restaurar";

                    if (openFile.ShowDialog() == DialogResult.OK)
                    {
                        string backupFile = openFile.FileName;
                        string nombreBD = "DB_Tienda_Septentrion";
                        string connectionString = "Server=DEngels;Database=master;Trusted_Connection=True;";

                        using (SqlConnection conexion = new SqlConnection(connectionString))
                        {
                            string restoreQuery = $@"
                        USE master;
                        RESTORE DATABASE [{nombreBD}]
                        FROM DISK = '{backupFile}'
                        WITH REPLACE, STATS = 5;
                    ";

                            using (SqlCommand cmd = new SqlCommand(restoreQuery, conexion))
                            {
                                conexion.Open();
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("✅ Restauración completada exitosamente.", "Restauración", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Error al restaurar base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            try
            {
                using (SaveFileDialog saveFile = new SaveFileDialog())
                {
                    saveFile.Filter = "Archivo de respaldo (*.bak)|*.bak";
                    saveFile.Title = "Guardar respaldo de la base de datos";
                    saveFile.FileName = $"Respaldo_BD_{DateTime.Now:yyyyMMdd_HHmmss}.bak";

                    if (saveFile.ShowDialog() == DialogResult.OK)
                    {
                        string backupPath = saveFile.FileName;
                        string nombreBD = "DB_Tienda_Septentrion"; // Nombre de tu base
                        string connectionString = "Server=DENGELS;Database=master;Trusted_Connection=True;";

                        using (SqlConnection conexion = new SqlConnection(connectionString))
                        {
                            string query = $@"
                        BACKUP DATABASE [{nombreBD}]
                        TO DISK = '{backupPath}'
                        WITH FORMAT, INIT, NAME = 'Respaldo completo de {nombreBD}', SKIP, NOREWIND, NOUNLOAD, STATS = 10";

                            using (SqlCommand cmd = new SqlCommand(query, conexion))
                            {
                                conexion.Open();
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("✅ Respaldo realizado con éxito.", "Respaldo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Error al realizar respaldo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
