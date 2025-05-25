using System;
using System.Collections.Generic;

namespace formstienda.Datos;

public partial class Compra
{
    public int IdCompra { get; set; }

    public string CodigoRuc { get; set; } = null!;

    public DateTime FechaCompra { get; set; }

    public double? TotalCompra { get; set; }

    public virtual Proveedor CodigoRucNavigation { get; set; } = null!;

    public virtual ICollection<DetalleCompra> DetalleCompras { get; set; } = new List<DetalleCompra>();
}
