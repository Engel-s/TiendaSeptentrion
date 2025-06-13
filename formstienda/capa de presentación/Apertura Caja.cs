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
using static formstienda.Login;

namespace formstienda
{
    public partial class Apertura_Caja : Form
    {
        private AperturaServicio? aperturaServicio;
        private TasaServicio? tasaServicio;
        private BindingList<TasaDeCambio> Listatasacambio;
        private BindingList<AperturaCaja> Listaapertura;
        public event Action OnAperturaCreada;

        public Apertura_Caja()
        {
            InitializeComponent();
            aperturaServicio = new AperturaServicio();
            tasaServicio = new TasaServicio();
        }

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

            // 1. Verificar si hay una apertura abierta
            var aperturaAbierta = aperturaServicio?.Listaapertura()
                                                   .FirstOrDefault(a => a.EstadoApertura == "Abierta");

            if (aperturaAbierta != null)
            {
                var respuesta = MessageBox.Show(
                    "❗ Ya hay una apertura activa. ¿Deseas cerrarla y continuar con una nueva apertura?",
                    "Apertura existente",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (respuesta == DialogResult.No)
                    return;

                // Cerrar apertura actual (actualización de estado)
                aperturaAbierta.EstadoApertura = "Cerrada";
                aperturaServicio?.ActualizarApertura(aperturaAbierta);
            }

            // 2. Validar monto de apertura
            if (!float.TryParse(txtMontoApertura.Text, out float montoApertura) || montoApertura <= 0)
            {
                MessageBox.Show("Ingrese un monto de apertura válido.");
                return;
            }

            // 3. Validar tasa de cambio
            if (!float.TryParse(txtTasaCambio.Text, out float valorCambio) || valorCambio <= 0)
            {
                MessageBox.Show("Ingrese una tasa de cambio válida.");
                return;
            }

            // 🔔 Confirmar antes de guardar
            DialogResult confirmacion = MessageBox.Show(
                $"¿Desea registrar la apertura con:\n\n" +
                $"- Monto de apertura: {montoApertura.ToString("N2")} C$ \n" +
                $"- Tasa de cambio: {valorCambio.ToString("N2")} C$ por $1\n\n" +
                "Esta acción no se puede revertir.",
                "Confirmar apertura de caja",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirmacion != DialogResult.Yes)
                return;

            // 4. Registrar nueva apertura
            var nuevaApertura = new AperturaCaja
            {
                FechaApertura = fechaHoy,
                HoraApertura = TimeOnly.FromDateTime(DateTime.Now),
                MontoApertura = montoApertura,
                EstadoApertura = "Abierta"
            };

            using (var _context = new DbTiendaSeptentrionContext())
            {
                _context.AperturaCajas.Add(nuevaApertura);
                _context.SaveChanges();

                // 5. Registrar arqueo vinculado
                var arqueo = new ArqueoCaja
                {
                    TotalEfectivoCordoba = 0,
                    TotalEfectivoDolar = 0,
                    FechaArqueo = DateTime.Now,
                    IdUsuario = (int)UsuarioActivo.ObtenerIdUsuario(),
                    IdApertura = nuevaApertura.IdApertura
                };

                _context.ArqueoCajas.Add(arqueo);
                _context.SaveChanges();
            }

            // 6. Registrar o actualizar tasa de cambio
            var tasaHoy = tasaServicio?.Listatasacambios()
                                       .FirstOrDefault(t => t.FechaCambio == fechaHoy);

            if (tasaHoy != null)
            {
                // Actualizar tasa existente
                tasaHoy.ValorCambio = valorCambio;
                tasaServicio?.ActualizarTasa(tasaHoy);
            }
            else
            {
                // Registrar nueva tasa
                var nuevaTasa = new TasaDeCambio
                {
                    FechaCambio = fechaHoy,
                    ValorCambio = valorCambio
                };

                if (!tasaServicio.AgregarTasa(nuevaTasa))
                {
                    MessageBox.Show("❌ Error al registrar la tasa de cambio.");
                    return;
                }
            }

            MessageBox.Show("✅ Apertura de caja y tasa de cambio procesadas correctamente.");
            OnAperturaCreada?.Invoke();
            this.Hide();
        } // Oculta el formulario al terminar

        private void txtTasaCambio_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = sender as TextBox;

            // Permitir control (como Backspace)
            if (char.IsControl(e.KeyChar))
                return;

            // Si es punto, convertirlo a coma manualmente
            if (e.KeyChar == ',')
            {
                e.Handled = true;
                int pos = txt.SelectionStart;
                txt.Text = txt.Text.Insert(pos, ",");
                txt.SelectionStart = pos + 1;
                return;
            }

            // Permitir solo dígitos o una sola coma
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
                return;
            }

            // No permitir más de una coma
            if (e.KeyChar == ',' && txt.Text.Contains(','))
            {
                e.Handled = true;
                return;
            }

            // Limitar coma a ser después de mínimo dos dígitos
            if (e.KeyChar == ',' && txt.SelectionStart < 2)
            {
                e.Handled = true;
            }
            // Simular el texto después de presionar la tecla
            string textoActual = txt.Text;
            int posCursor = txt.SelectionStart;

            string nuevoTexto = textoActual.Insert(posCursor, e.KeyChar.ToString());

            // Contar cuántos dígitos hay antes de la coma (o en total si no hay coma)
            string parteAntesDeComa = nuevoTexto.Split(',')[0];
            int digitosAntesDeComa = parteAntesDeComa.Count(c => char.IsDigit(c));

            // Si se han escrito dos dígitos y no hay coma, insertar automáticamente
            if (digitosAntesDeComa == 2 && !textoActual.Contains(","))
            {
                e.Handled = true;
                txt.Text = textoActual.Insert(posCursor, e.KeyChar + ",");
                txt.SelectionStart = posCursor + 2;
                return;
            }
        }

        private void txtMontoApertura_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
