using System;
using System.Collections.Generic;

namespace formstienda.Models;

public partial class Ventum
{
    public int IdVenta { get; set; }

    public DateOnly FechaVenta { get; set; }

    public virtual ICollection<DetalleDeVentum> DetalleDeVenta { get; set; } = new List<DetalleDeVentum>();
}
