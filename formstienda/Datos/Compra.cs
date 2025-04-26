using System;
using System.Collections.Generic;

namespace formstienda.Datos;

public partial class Compra
{
    public int IdCompra { get; set; }

    public int IdProveedor { get; set; }

    public int IdProducto { get; set; }

    public int IdCategoria { get; set; }

    public int IdMarca { get; set; }

    public int NoFacturaCompra { get; set; }

    public DateOnly FechaCompra { get; set; }

    public double PrecioCompra { get; set; }

    public int CantidadCompra { get; set; }

    public virtual Proveedor IdProveedorNavigation { get; set; } = null!;

    public virtual Producto Producto { get; set; } = null!;
}
