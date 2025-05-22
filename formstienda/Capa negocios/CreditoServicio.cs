using formstienda.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using formstienda.Capa_negocios;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;

namespace formstienda.Capa_negocios
{
  public class CreditoServicio
       {
        public bool AñadirCredito(DetalleCredito credito)
        {

            using (var contexto = new DbTiendaSeptentrionContext())
            {
                var resultado = contexto.FacturaCreditos.Add();
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
        public bool AgregarPagoCredito(int idVenta, int montoAbonado, bool esDolares, DateOnly? v)
        {
            using (var contexto = new DbTiendaSeptentrionContext())
            {
                // Buscar la factura
                var factura = contexto.Venta.FirstOrDefault(a => a.IdVenta == idVenta);
                if (factura == null)
                    return false;

                // Si la moneda es dólares, convierte a córdobas si es necesario
                decimal montoEnCordobas = montoAbonado;
                if (esDolares)
                {
                    // Supón que tienes una tasa de cambio disponible, por ejemplo:
                    decimal tasaCambio = 36.5m; 
                    montoEnCordobas = montoAbonado * tasaCambio;
                }

                 //Restar el monto abonado al saldo de la factura
              //  factura.SubTotal = montoEnCordobas;

                 //Registrar el pago en la tabla de pagos de crédito
                var pago = new FacturaCredito
                {
                    IdVenta = idVenta,
                    MontoCredito = montoAbonado, 
                   TotalAbonado = (float?) montoEnCordobas,
                   FechaCreacion = v
                   // Agrega otros campos necesarios
                };

                contexto.FacturaCreditos.Add(pago);
                contexto.SaveChanges();
                return true;
            }
        }

    }
}
       