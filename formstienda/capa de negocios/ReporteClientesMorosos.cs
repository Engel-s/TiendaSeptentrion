using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using formstienda.Datos;
using Microsoft.EntityFrameworkCore;

namespace formstienda.capa_de_negocios
{
    internal class ReporteClientesMorosos
    {
        public List<DetalleCredito> ListarClientesMorosos()
        {
            try
            {
                using (var context = new DbTiendaSeptentrionContext())
                {
                    return context.DetalleCreditos
                        .Include(d => d.IdCreditoNavigation)
                            .ThenInclude(d => d.IdVentaNavigation)
                            .ThenInclude(d => d.CedulaClienteNavigation)
                         .Where(d => d.FechaPago < DateTime.Now)
                        .Select(d => new DetalleCredito
                        {
                            IdDetalleCredito = d.IdDetalleCredito,
                            IdCredito = d.IdCredito,
                            FechaPago = d.FechaPago,
                            IdCreditoNavigation = new FacturaCredito
                            {
                                PlazosMeses = d.IdCreditoNavigation.PlazosMeses,
                                MontoCredito = d.IdCreditoNavigation.MontoCredito,
                                IdVentaNavigation = new Ventum
                                {
                                    IdVenta = d.IdCreditoNavigation.IdVenta,
                                    CedulaClienteNavigation = new Cliente
                                    {
                                        NombreCliente = d.IdCreditoNavigation.IdVentaNavigation.CedulaClienteNavigation.NombreCliente,
                                        DireccionCliente = d.IdCreditoNavigation.IdVentaNavigation.CedulaClienteNavigation.DireccionCliente,
                                        TelefonoCliente = d.IdCreditoNavigation.IdVentaNavigation.CedulaClienteNavigation.TelefonoCliente
                                    }
                                }
                            },
                       
                        })
                        .ToList();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener detalles completos: {ex.Message}");
                return new List<DetalleCredito>();
            }
        }
    }
}
