using formstienda.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace formstienda.capa_de_negocios
{
    public class DevolucionServicio
    {
        public Ventum? ObtenerVentaContadoPorId(int idVenta)
        {
            try
            {
                using (var _contexto = new DbTiendaSeptentrionContext())
                {
                    return _contexto.Venta
                        .Include(v => v.CedulaClienteNavigation)
                        .Include(v => v.DetalleDeVenta)
                            .ThenInclude(d => d.CodigoProductoNavigation) // <--- Importante
                        .FirstOrDefault(v => v.IdVenta == idVenta && v.TipoPago == "Contado");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al buscar venta: {ex.Message}");
                return null;
            }
        }

        public List<DetalleDeVentum> ObtenerDetallesPorVenta(int idVenta)
        {
            try
            {
                using (var _contexto = new DbTiendaSeptentrionContext())
                {
                    return _contexto.DetalleDeVenta
                        .Where(d => d.IdVenta == idVenta)
                        .Include(d => d.CodigoProductoNavigation)
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al buscar detalles: {ex.Message}");
                return new List<DetalleDeVentum>();
            }
        }

        public Cliente? ObtenerClientePorCedula(string cedula)
        {
            try
            {
                using (var _contexto = new DbTiendaSeptentrionContext())
                {
                    return _contexto.Clientes.FirstOrDefault(c => c.CedulaCliente == cedula);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al buscar cliente: {ex.Message}");
                return null;
            }
        }
    }
}
