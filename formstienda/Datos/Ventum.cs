using System;
using System.Collections.Generic;

namespace formstienda.Datos;

public partial class Ventum
{
    public int IdVenta { get; set; }

    public DateOnly FechaVenta { get; set; }

    public virtual ICollection<DetalleDeVentum> DetalleDeVenta { get; set; } = new List<DetalleDeVentum>();
}
