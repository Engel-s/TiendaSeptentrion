using formstienda.Capa_negocios;
using formstienda.Datos;
using iText.Commons.Actions;
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
        public FacturaCredito? BuscarCreditoPorCliente(string criterio)
        {
            using (var context = new DbTiendaSeptentrionContext())
            {
                // Buscar cliente por cédula o teléfono
                var cliente = context.Clientes
                    .FirstOrDefault(c => c.CedulaCliente == c.CedulaCliente || c.TelefonoCliente == c.TelefonoCliente);

                if (cliente == null)
                    return null;

                // Buscar la venta al crédito de ese cliente
                var credito = context.FacturaCreditos
                    .Include(fc => fc.DetalleCreditos)
                    .Include(fc => fc.IdVentaNavigation)
                    .ThenInclude(v => v.CedulaClienteNavigation)
                    .FirstOrDefault(fc => fc.IdVentaNavigation.CedulaCliente == cliente.CedulaCliente);

                return credito;
            }
        }

        public FacturaCredito? BuscarCreditoPorFactura(int idFactura)
        {
            using (var context = new DbTiendaSeptentrionContext())
            {
                return context.FacturaCreditos
                    .Include(fc => fc.DetalleCreditos)
                    .Include(fc => fc.IdVentaNavigation)
                    .ThenInclude(v => v.CedulaClienteNavigation)
                    .FirstOrDefault(fc => fc.IdVenta == idFactura);
            }
        }

        public DetalleCredito? ObtenerProximaCuota(FacturaCredito credito, out int diasMora, out float moraCalculada)
        {
            var hoy = DateTime.Today;
            diasMora = 0;
            moraCalculada = 0;

            // Buscar la primera cuota pendiente (sin pago)
            var proximaCuota = credito.DetalleCreditos
                .Where(dc => dc.TotalCordobas == 0 && dc.TotalDolares == 0)
                .OrderBy(dc => dc.FechaPago)
                .FirstOrDefault();

            if (proximaCuota != null && proximaCuota.FechaPago < hoy)
            {
                diasMora = (hoy - proximaCuota.FechaPago).Days;
                moraCalculada = (float)Math.Round(proximaCuota.ValorCuota * 0.03, 2);
            }

            return proximaCuota;
        }



  }
}
       