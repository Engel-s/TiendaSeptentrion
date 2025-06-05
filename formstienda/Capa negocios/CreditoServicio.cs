using formstienda.Capa_negocios;
using formstienda.Datos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace formstienda.Capa_negocios
{
  public class CreditoServicio
       {
        public bool AñadirCredito(DetalleCredito credito)
        {

            using (var contexto = new DbTiendaSeptentrionContext())
            {
                var resultado = contexto.DetalleCreditos.Add(credito);
                contexto.SaveChanges();
                return resultado == null ? false : true;
            }
        }

        public List<DetalleCredito> ListarCredito()
        {
            using (var contexto = new DbTiendaSeptentrionContext())
            {
                return contexto.DetalleCreditos.ToList();
            }
        }
        public bool AgregarPagoCredito(int idVenta, decimal montoAbonado, bool esDolares, DateOnly? FechaPago)
        {
            using (var contexto = new DbTiendaSeptentrionContext())
            {
                // Buscar la venta por id y cargar los créditos relacionados
                var venta = contexto.Venta
                    .Include(v => v.FacturaCreditos)
                    .FirstOrDefault(v => v.IdVenta == idVenta);

                if (venta == null)
                    return false;

                decimal montoEnCordobas = montoAbonado;
                if (esDolares)
                {
                    decimal tasaCambio = 36.5m; // Idealmente obtener dinámicamente
                    montoEnCordobas = montoAbonado * tasaCambio;
                }

                // Obtener el crédito activo 
                var creditoActivo = venta.FacturaCreditos.FirstOrDefault(fc => fc.NuevoSaldo > 0);
                if (creditoActivo == null)
                    return false; // No hay crédito activo para esa venta

                // Actualizar saldo y total abonado en el crédito
                creditoActivo.TotalAbonado += (float)montoEnCordobas;
                creditoActivo.NuevoSaldo -= (float)montoEnCordobas;
                if (creditoActivo.NuevoSaldo < 0)
                    creditoActivo.NuevoSaldo = 0;

                // Registrar el pago en DetalleCredito
                var pago = new DetalleCredito
                {
                    IdCredito = creditoActivo.IdCredito,
                    FechaPago = FechaPago.HasValue ? FechaPago.Value.ToDateTime(TimeOnly.MinValue) : DateTime.Now,
                    AbonoCapital = (float)montoEnCordobas,
                    UsuarioRegistro = "usuario_actual", 
                    ValorCuota = 0, // Ajusta según tu lógica
                    InteresPagado = 0,
                    TotalCordobas = (float)montoEnCordobas
                };

                contexto.DetalleCreditos.Add(pago);
                contexto.SaveChanges();

                return true;
            }

        }   }
}
       