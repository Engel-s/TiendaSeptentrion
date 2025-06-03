using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using formstienda.Datos;
using formstienda.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace formstienda.capa_de_negocios
{
    internal class DetalleCompraServicio
    {
        public List<DetalleCompra> ListarDetalleCompra()
        {
            try
            {
                using (var context = new DbTiendaSeptentrionContext())
                {
                    return context.DetalleCompras.ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<DetalleCompra>();
            }
        }

        // Nuevo método que devuelve los detalles con el nombre del producto
        public List<DetalleCompraViewModel> ListarDetalleCompraConNombreProducto()
        {
            try
            {
                using (var context = new DbTiendaSeptentrionContext())
                {
                    return context.DetalleCompras
                        .Include(d => d.CodigoProductoNavigation) // Carga la relación con Producto
                        .Select(d => new DetalleCompraViewModel
                        {
                            IdDetalleCompra = d.IdDetalleCompra,
                            IdCompra = d.IdCompra,
                            CodigoProducto = d.CodigoProducto,
                            NombreProducto = d.CodigoProductoNavigation.ModeloProducto, // Obtiene el nombre
                            CantidadCompra = d.CantidadCompra,
                            PrecioCompra = d.PrecioCompra
                        })
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<DetalleCompraViewModel>();
            }
        }

        // En DetalleCompraServicio.cs
        public List<DetalleCompraViewModel> ListarDetalleCompraPorIdCompra(int idCompra)
        {
            try
            {
                using (var context = new DbTiendaSeptentrionContext())
                {
                    return context.DetalleCompras
                        .Include(d => d.CodigoProductoNavigation) // Incluye el producto
                        .Where(d => d.IdCompra == idCompra) // Filtra solo los de esta compra
                        .Select(d => new DetalleCompraViewModel
                        {
                            IdDetalleCompra = d.IdDetalleCompra,
                            IdCompra = d.IdCompra,
                            CodigoProducto = d.CodigoProducto,
                            NombreProducto = d.CodigoProductoNavigation.ModeloProducto,
                            CantidadCompra = d.CantidadCompra,
                            PrecioCompra = d.PrecioCompra,
                        })
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<DetalleCompraViewModel>();
            }
        }

        public bool AgregarDetalleCompra(DetalleCompra detallecompra)
        {
            using (var context = new DbTiendaSeptentrionContext())
            {
                var detalle = context.DetalleCompras.Add(detallecompra);
                context.SaveChanges();

                return detalle != null ? false : true; 
            }


        }

        public void EliminarDetallesPorIdCompra(int idCompra)
        {
            using (var context = new DbTiendaSeptentrionContext())
            {
                var detalles = context.DetalleCompras.Where(dc => dc.IdCompra == idCompra).ToList();
                context.DetalleCompras.RemoveRange(detalles);
                context.SaveChanges();
            }
        }

        public void ActualizarDetalleCompra(int idDetalle, int cantidad, float precio)
        {
            using (var context = new DbTiendaSeptentrionContext())
            {
                // Usar Where + FirstOrDefault para claves compuestas
                var detalle = context.DetalleCompras
                    .FirstOrDefault(d => d.IdDetalleCompra == idDetalle);

                if (detalle != null)
                {
                    detalle.CantidadCompra = cantidad;
                    detalle.PrecioCompra = precio;
                    detalle.SubtotalCompra = cantidad * precio;
                    context.SaveChanges();
                }
            }
        }

        public List<DetalleCompraViewModel> ObtenerDetallesParaReportes()
        {
            try
            {
                using (var context = new DbTiendaSeptentrionContext())
                {
                    return context.DetalleCompras
                        .Include(d => d.IdCompraNavigation)
                            .ThenInclude(c => c.CodigoRucNavigation)
                            .Include(d => d.CodigoProductoNavigation)
                            .Select(d => new DetalleCompraViewModel
                            {
                                IdDetalleCompra = d.IdDetalleCompra,
                                //IdCompra = d.IdCompra,
                                NumeroFactura = d.IdCompraNavigation.NumeroFactura,
                                FechaCompra = d.IdCompraNavigation.FechaCompra,
                                NombreProveedor = d.IdCompraNavigation.CodigoRucNavigation.NombreProveedor,
                                ApellidoProveedor = d.IdCompraNavigation.CodigoRucNavigation.ApellidoProveedor,
                                RucProveedor = d.IdCompraNavigation.CodigoRucNavigation.CodigoRuc,
                                CodigoProducto = d.CodigoProducto,
                                NombreProducto = d.CodigoProductoNavigation.ModeloProducto,
                                CantidadCompra = d.CantidadCompra,
                                PrecioCompra = d.PrecioCompra,
                                TotalCompra = d.IdCompraNavigation.TotalCompra
                            })
                            .ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener detalles completos: {ex.Message}");
                return new List<DetalleCompraViewModel>();
            }
        }
    }
}
