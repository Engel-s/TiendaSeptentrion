using formstienda.Datos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace formstienda.Capa_negocios
{
    public class CreditoServicio
    {
        public bool AñadirCredito(DetalleCredito credito)
        {
            using (var contexto = new DbTiendaSeptentrionContext())
            {
                // Calcular interés inicial si es necesario
                if (credito.InteresPagado == 0 && credito.IdCreditoNavigation != null)
                {
                    credito.InteresPagado = credito.IdCreditoNavigation.InteresMensual;
                }

                contexto.DetalleCreditos.Add(credito);
                return contexto.SaveChanges() > 0;
            }
        }

        public List<DetalleCredito> ListarCreditos()
        {
            using (var contexto = new DbTiendaSeptentrionContext())
            {
                return contexto.DetalleCreditos
                    .Include(d => d.IdCreditoNavigation)
                    .ToList();
            }
        }

        public bool ProcesarPagoCredito(int idDetalleCredito, decimal montoAbonado, bool esDolares)
        {
            using (var contexto = new DbTiendaSeptentrionContext())
            {
                using (var transaction = contexto.Database.BeginTransaction())
                {
                    try
                    {
                        // Obtener tasa de cambio
                        var tasaCambioHoy = contexto.TasaDeCambios
                            .OrderByDescending(t => t.FechaCambio)
                            .FirstOrDefault(t => t.FechaCambio == DateOnly.FromDateTime(DateTime.Now));

                        if (tasaCambioHoy == null)
                        {
                            throw new Exception("No se encontró tasa de cambio para hoy");
                        }

                        var detalle = contexto.DetalleCreditos
                            .Include(d => d.IdCreditoNavigation)
                            .FirstOrDefault(d => d.IdDetalleCredito == idDetalleCredito);

                        if (detalle == null) return false;

                        // Convertir monto si es en dólares
                        decimal montoEnCordobas = esDolares ?
                            montoAbonado * (decimal)tasaCambioHoy.ValorCambio :
                            montoAbonado;

                        // Calcular distribución del pago
                        var distribucion = CalcularDistribucionPago(detalle, montoEnCordobas);

                        // Aplicar los cálculos
                        detalle.AbonoCapital += (float)distribucion.AbonoCapital;
                        detalle.InteresPagado += (float)distribucion.Interes;
                        detalle.ValorCuota = Math.Max(0, detalle.ValorCuota - (float)distribucion.TotalAplicado);
                        detalle.FechaPago = DateTime.Now;

                        // Actualizar totales
                        detalle.TotalCordobas += (float)montoEnCordobas;
                        if (esDolares)
                        {
                            detalle.TotalDolares += (float)montoAbonado;
                        }

                        // Actualizar factura crédito
                        ActualizarFacturaCredito(detalle.IdCreditoNavigation, contexto);

                        contexto.SaveChanges();
                        transaction.Commit();

                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        // Logear el error (implementar según necesidad)
                        throw new Exception("Error al procesar pago: " + ex.Message);
                    }
                }
            }
        }

        private (decimal Interes, decimal AbonoCapital, decimal TotalAplicado) CalcularDistribucionPago(
            DetalleCredito detalle, decimal montoAbonado)
        {
            // Obtener el interés pendiente
            decimal interesPendiente = (decimal)(detalle.IdCreditoNavigation?.InteresMensual ?? 0 - detalle.InteresPagado);
            interesPendiente = Math.Max(0, interesPendiente);

            decimal interesAAplicar = Math.Min(interesPendiente, montoAbonado);
            decimal abonoCapital = montoAbonado - interesAAplicar;

            // Si hay saldo pendiente menor al abono, ajustar
            decimal saldoPendiente = (decimal)(detalle.ValorCuota - detalle.AbonoCapital);
            if (saldoPendiente < abonoCapital)
            {
                abonoCapital = saldoPendiente;
                interesAAplicar = montoAbonado - abonoCapital;
            }

            return (interesAAplicar, abonoCapital, montoAbonado);
        }

        private void ActualizarFacturaCredito(FacturaCredito factura, DbTiendaSeptentrionContext contexto)
        {
            // Recalcular totales basados en los detalles
            var detalles = contexto.DetalleCreditos
                .Where(d => d.IdCredito == factura.IdCredito)
                .ToList();

            factura.TotalAbonado = detalles.Sum(d => d.AbonoCapital);
            factura.NuevoSaldo = factura.MontoCredito + factura.InteresMensual * factura.PlazosMeses
                                - factura.TotalAbonado;
        }

        public decimal CalcularInteresPendiente(int idDetalleCredito)
        {
            using (var contexto = new DbTiendaSeptentrionContext())
            {
                var detalle = contexto.DetalleCreditos
                    .Include(d => d.IdCreditoNavigation)
                    .FirstOrDefault(d => d.IdDetalleCredito == idDetalleCredito);

                if (detalle == null) return 0;

                decimal interesTotal = (decimal)(detalle.IdCreditoNavigation?.InteresMensual ?? 0);
                return Math.Max(0, interesTotal - (decimal)detalle.InteresPagado);
            }
        }
    }
}