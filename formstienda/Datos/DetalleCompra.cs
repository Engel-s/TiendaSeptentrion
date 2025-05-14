using System;
using System.Collections.Generic;

namespace formstienda.Datos;

public partial class DetalleCompra
{
    public int IdDetalleCompra { get; set; }

    public int IdCompra { get; set; }

    public string CodigoProducto { get; set; } = null!;

    public float PrecioCompra { get; set; }

    public int CantidadCompra { get; set; }

    public string CodigoRuc { get; set; } = null!;

    public double SubtotalCompra { get; set; }

    public virtual Producto CodigoProductoNavigation { get; set; } = null!;

    public virtual Compra Compra { get; set; } = null!;
}
