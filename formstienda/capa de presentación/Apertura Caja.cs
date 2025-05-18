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
        private BindingList<TasaDeCambio> Listatasacambio;
        private BindingList<AperturaCaja> Listaapertura;

        public Apertura_Caja()
        {
            InitializeComponent();
            aperturaServicio = new AperturaServicio();
            tasaServicio = new TasaServicio();
        }

        //private void btnabrircaja_Click(object sender, EventArgs e)
        //{
        //    var apertura = new AperturaCaja
        //    {
        //        FechaApertura = DateTime.Now,
        //        HoraApertura = TimeOnly.FromDateTime(DateTime.Now),

        //        MontoApertura = decimal.Parse(txtMontoApertura.Text),
        //        EstadoApertura = "Abierta",

        //    }
        //    ;

        //    // Validar si ya hay una apertura hoy
        //    //var aperturaExistente = aperturaServicio?.ListaAperturas()
        //    //                                        .FirstOrDefault(a => a.FechaApertura.Date == DateTime.Today);
        //    //if (aperturaExistente != null)
        //    //{
        //    //    MessageBox.Show("Ya se realizó una apertura hoy.");
        //    //    return;
        //    //}

        //    aperturaServicio?.Agregarfondo(apertura);
        //    //ListaAperturas?.Add(apertura);
        //    MessageBox.Show("Apertura de caja registrada correctamente.");
        //    var tasadecambio = new TasaDeCambio
        //    {
        //        FechaCambio = DateTime.Now,
        //        ValorCambio = decimal.Parse(txtTasaCambio.Text),

        //    };

        //    // Validar si ya existe una tasa registrada hoy
        //    //var tasaExistente = tasaServicio?.Listatasas()
        //    //                                .FirstOrDefault(t => t.FechaCambio == tasa.FechaCambio);
        //    //if (tasaExistente != null)
        //    //{
        //    //    MessageBox.Show("Ya hay una tasa registrada para hoy.");
        //    //    return;
        //    //}

        //    tasaServicio?.AgregarTasa(tasadecambio);
        //    //Listatasacambios?.Add(tasadecambio);
        //    MessageBox.Show("Tasa de cambio registrada correctamente.");


        //}

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Apertura_Caja_Load(object sender, EventArgs e)
        {

        }

        private void btnAbrirCaja_Click_1(object sender, EventArgs e)
        {
            var fechaHoy = DateOnly.FromDateTime(DateTime.Now);

            // Validar si ya existe una apertura hoy
            var aperturaExistente = aperturaServicio?.Listaapertura()
                                                     .FirstOrDefault(a => a.FechaApertura == fechaHoy);
            if (aperturaExistente != null)
            {
                MessageBox.Show("❌ Ya se realizó una apertura hoy.");
                return;
            }

            // Validar si ya existe una tasa de cambio hoy
            var tasaExistente = tasaServicio?.Listatasacambios()
                                             .FirstOrDefault(t => t.FechaCambio == fechaHoy);
            if (tasaExistente != null)
            {
                MessageBox.Show("❌ Ya hay una tasa de cambio registrada para hoy.");
                return;
            }

            // Crear y guardar apertura
            var apertura = new AperturaCaja
            {
                FechaApertura = fechaHoy,
                HoraApertura = TimeOnly.FromDateTime(DateTime.Now),
                MontoApertura = float.Parse(txtMontoApertura.Text),
                EstadoApertura = "Abierta"
            };

            aperturaServicio?.Agregarfondo(apertura);
            MessageBox.Show("✅ Apertura de caja registrada correctamente.");

            // Crear y guardar tasa de cambio
            var tasadecambio = new TasaDeCambio
            {
                FechaCambio = fechaHoy,
                ValorCambio = float.Parse(txtTasaCambio.Text),
            };

            tasaServicio?.AgregarTasa(tasadecambio);
            MessageBox.Show("✅ Tasa de cambio registrada correctamente.");

            this.Hide(); // Ocultar ventana tras éxito
        }

    }
}
