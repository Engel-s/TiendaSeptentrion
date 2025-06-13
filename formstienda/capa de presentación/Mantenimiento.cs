using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace formstienda
{
    public partial class Mantenimiento : Form
    {
        private string _rutaBackup = @"C:\Backups"; // Carpeta para almacenar copias de seguridad
        private string _rutaRestore; // Ruta de la copia de seguridad a restaurar

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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Abrir cuadro de diálogo para seleccionar el archivo de backup
                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    Title = "Seleccionar Copia de Seguridad",
                    Filter = "Archivos de Copia de Seguridad (*.bak)|*.bak|Todos los archivos (*.*)|*.*"
                };

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    _rutaRestore = openFileDialog.FileName;

                    if (string.IsNullOrEmpty(_rutaRestore))
                    {
                        MessageBox.Show("Por favor, selecciona un archivo de copia de seguridad válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    string connectionString = "Server=DESKTOP-QJJDVK7\\SQLEXPRESS;Database=master;Trusted_Connection=True;";

                    string query = $@"
                        ALTER DATABASE [[DB_Tienda_Septentrion]] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
                        RESTORE DATABASE [[DB_Tienda_Septentrion]] FROM DISK = '{_rutaRestore}' WITH REPLACE;
                        ALTER DATABASE [[DB_Tienda_Septentrion]] SET MULTI_USER;";

                    ExecuteSqlCommand(connectionString, query);
                    MessageBox.Show("La base de datos ha sido restaurada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"Error SQL al restaurar la base de datos: {sqlEx.Message}", "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar si la carpeta de backups existe
                if (!Directory.Exists(_rutaBackup))
                {
                    try
                    {
                        Directory.CreateDirectory(_rutaBackup);
                    }
                    catch (UnauthorizedAccessException)
                    {
                        MessageBox.Show("No tienes permisos para crear la carpeta de backups.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // Nombre del archivo de backup con fecha y hora
                string nombreArchivoBackup = $"Backup_{DateTime.Now:yyyyMMdd_HHmmss}.bak";
                string rutaBackup = Path.Combine(_rutaBackup, nombreArchivoBackup);

                string connectionString = "Server=DESKTOP-QJJDVK7\\SQLEXPRESS;Database=MiBaseDeDatos;Trusted_Connection=True;";

                string query = $"BACKUP DATABASE [] TO DISK = '{rutaBackup}' WITH INIT;";
                ExecuteSqlCommand(connectionString, query);

                MessageBox.Show($"Copia de seguridad creada exitosamente en: {rutaBackup}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"Error SQL al crear la copia de seguridad: {sqlEx.Message}", "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExecuteSqlCommand(string connectionString, string query)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}

