using System;
using System.Collections.Generic;

namespace formstienda.Datos;

public partial class DetalleDevolucion
{
    public int IdDetalleDevolucion { get; set; }

    public int IdDevolucion { get; set; }

    public string InformacionProducto { get; set; } = null!;

    public int CantidadDevuelta { get; set; }

    public decimal MontoDevuelto { get; set; }

    public DateOnly FechaDevolucion { get; set; }

    public string CambiosDevolucion { get; set; } = null!;
}
