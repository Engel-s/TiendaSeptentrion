using System;
using System.Collections.Generic;

namespace formstienda.Datos;

public partial class Compra
{
    public int IdCompra { get; set; }

    public string CodigoRuc { get; set; } = null!;

<<<<<<< HEAD
    public int NumeroFactura { get; set; }

    public DateTime FechaCompra { get; set; }

    public double TotalCompra { get; set; }
=======
    public DateTime FechaCompra { get; set; }

    public double? TotalCompra { get; set; }
>>>>>>> ventas

    public virtual Proveedor CodigoRucNavigation { get; set; } = null!;

    public virtual ICollection<DetalleCompra> DetalleCompras { get; set; } = new List<DetalleCompra>();
}
