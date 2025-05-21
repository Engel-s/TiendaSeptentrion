using formstienda.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using formstienda.Capa_negocios;
using System.Text;
using System.Threading.Tasks;

namespace formstienda.Capa_negocios
{
  public class CreditoServicio
       {
        public bool AñadirCredito(PagoDeCredito credito)
        {

            using (var contexto = new DbTiendaSeptentrionContext())
            {
                var resultado = contexto.PagoDeCreditos.Add(credito);
                contexto.SaveChanges();
                return resultado == null ? false : true;
            }
        }

        public List<PagoDeCredito> ListarCredito()
        {
            using (var contexto = new DbTiendaSeptentrionContext())
            {
                return contexto.PagoDeCreditos.ToList();
            }
        }
        //public bool AgregarPagoCredito(int idVenta, decimal montoAbonado, bool esDolares)
        //{
        //    using (var contexto = new DbTiendaSeptentrionContext())
        //    {
        //        // Buscar la factura
        //        var factura = contexto.Venta.FirstOrDefault(a => a.IdVenta == idVenta);
        //        if (factura == null)
        //            return false;

        //        // Si la moneda es dólares, convierte a córdobas si es necesario
        //        decimal montoEnCordobas = montoAbonado;
        //        if (esDolares)
        //        {
        //            // Supón que tienes una tasa de cambio disponible, por ejemplo:
        //            decimal tasaCambio = 36.5m; 
        //            montoEnCordobas = montoAbonado * tasaCambio;
        //        }

                // Restar el monto abonado al saldo de la factura
                //factura. -= montoEnCordobas;

                // Registrar el pago en la tabla de pagos de crédito
                //var pago = new PagoDeCredito
                //{
                //    IdVenta = idVenta,
                //    MontoPagado = montoAbonado,
                //    EsDolares = esDolares,
                //    FechaPago = DateTime.Now
                    // Agrega otros campos necesarios
            //    };

            //    contexto.PagoDeCreditos.Add(pago);
            //    contexto.SaveChanges();
            //    return true;
            //}
        //}

    }
}
       