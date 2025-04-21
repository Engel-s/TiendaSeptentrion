using formstienda.capa_de_negocios;
using formstienda.Datos;
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
    public partial class Apertura_Caja : Form
    {
        private AperturaServicio? aperturaServicio;
        private TasaServicio? tasaServicio;
        //private BindingList<Tasadecambio>? Listatasacambios;

        public Apertura_Caja()
        {
            InitializeComponent();
            aperturaServicio = new AperturaServicio();
            tasaServicio = new TasaServicio();
        }

        private void btnabrircaja_Click(object sender, EventArgs e)
        {
            var apertura = new AperturaCaja
            {
                FechaApertura = DateTime.Now,
                HoraApertura = TimeOnly.FromDateTime(DateTime.Now),

                MontoApertura = decimal.Parse(txtapertura.Text),
                EstadoApertura = "Abierta",

            };

            // Validar si ya hay una apertura hoy
            //var aperturaExistente = aperturaServicio?.ListaAperturas()
            //                                        .FirstOrDefault(a => a.FechaApertura.Date == DateTime.Today);
            //if (aperturaExistente != null)
            //{
            //    MessageBox.Show("Ya se realizó una apertura hoy.");
            //    return;
            //}

            aperturaServicio?.Agregarfondo(apertura);
            //ListaAperturas?.Add(apertura);
            MessageBox.Show("Apertura de caja registrada correctamente.");
            var tasadecambio = new TasaDeCambio
            {
                FechaCambio = DateTime.Now,
                ValorCambio = decimal.Parse(txttasadecambio.Text),

            };

            // Validar si ya existe una tasa registrada hoy
            //var tasaExistente = tasaServicio?.Listatasas()
            //                                .FirstOrDefault(t => t.FechaCambio == tasa.FechaCambio);
            //if (tasaExistente != null)
            //{
            //    MessageBox.Show("Ya hay una tasa registrada para hoy.");
            //    return;
            //}

            tasaServicio?.AgregarTasa(tasadecambio);
            //Listatasacambios?.Add(tasadecambio);
            MessageBox.Show("Tasa de cambio registrada correctamente.");


        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
