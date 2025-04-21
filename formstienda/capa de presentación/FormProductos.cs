using formstienda.capa_de_negocios;
using formstienda.Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace formstienda
{
    public partial class FormProductos : Form
    {
        private MarcaServicio? marcaServicio;
        private BindingList<Marca>? Listamarcas;
        private CategoriaServicio? categoriaServicio;
        private BindingList<Categorium>? Listacategoria;
        public FormProductos()
        {

            InitializeComponent();

        }

        private void button12_Click(object sender, EventArgs e)
        {


            this.Close();
        }

        private void button11_Click(object sender, EventArgs e)
        {


            this.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {


            this.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {


            this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FormProductos_Load(object sender, EventArgs e)
        {
            marcaServicio = new MarcaServicio();
            //listar
            Listamarcas = new BindingList<Marca>(marcaServicio.Listamarcas());
            DGMARCA.DataSource = Listamarcas;
            categoriaServicio = new CategoriaServicio();
            //listar
            Listacategoria = new BindingList<Categorium>(categoriaServicio.Listacategorias());
            DGCATEGORIA.DataSource = Listacategoria;
        }

        private void button13_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnguardarmarca_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnguardacarac_Click(object sender, EventArgs e)
        {

            // validar si ya existe el usuario
            var categorium = new Categorium
            {
                Categoria = cbcategoria.Text
            };
            var categoriaExistente = categoriaServicio?.Listacategorias()
                                                  .FirstOrDefault(p => p.IdCategoria == categorium.IdCategoria);
            if (categoriaExistente != null)
            {
                MessageBox.Show("Esta categoria ya existe, por favor ingrese otra");
                return;
            }
            categoriaServicio.Agregarcategoria(categorium);
            Listacategoria.Add(categorium);
            MessageBox.Show("Categoria agregada exitosamente");

        }

        private void btnguardarmarca_Click_1(object sender, EventArgs e)
        {
            // validar si ya existe el usuario
            var marca = new Marca
            {
                Marca1 = cbmarca.Text
            };
            var marcaExistente = marcaServicio?.Listamarcas()
                                                  .FirstOrDefault(p => p.IdMarca == marca.IdMarca);
            if (marcaExistente != null)
            {
                MessageBox.Show("Esta marca ya existe, por favor ingrese otra");
                return;
            }
            marcaServicio.Agregarmarca(marca);
            Listamarcas.Add(marca);
            MessageBox.Show("marca agregada exitosamente");
        }

        private void DGMARCA_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int IdMarca = (int)DGMARCA.Rows[e.RowIndex].Cells["IdMarca"].Value;
            //validacion 
            if (string.IsNullOrEmpty(DGMARCA.Rows[e.RowIndex].Cells["IdMarca"].Value?.ToString()))
            {
                MessageBox.Show("El nombre no puede estar vacio o ser nulo");
                return;
            }
            var marcaEditada = new Marca
            {
                IdMarca = IdMarca,
                Marca1 = DGMARCA.Rows[e.RowIndex].Cells["Marca1"].Value?.ToString() ?? "",


            };
            if (marcaServicio.Actualizarmarca(marcaEditada))
                MessageBox.Show("Marca actualizada correctamente");
            else
                MessageBox.Show("No se pudo actualizar la marca");
        }

        private void DGCATEGORIA_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DGCATEGORIA_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int IdCategoria = (int)DGCATEGORIA.Rows[e.RowIndex].Cells["IdCategoria"].Value;
            //validacion 
            if (string.IsNullOrEmpty(DGCATEGORIA.Rows[e.RowIndex].Cells["IdCategoria"].Value?.ToString()))
            {
                MessageBox.Show("El nombre no puede estar vacio o ser nulo");
                return;
            }
            var categoriaEditada = new Categorium
            {
                IdCategoria = IdCategoria,
                Categoria = DGCATEGORIA.Rows[e.RowIndex].Cells["Categoria"].Value?.ToString() ?? "",


            };
            if (categoriaServicio.Actualizarcategoria(categoriaEditada))
                MessageBox.Show("Categoria actualizada correctamente");
            else
                MessageBox.Show("No se pudo actualizar la categoria");
        }
    }
}

