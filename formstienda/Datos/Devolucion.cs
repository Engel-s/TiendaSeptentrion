using System;
using System.Collections.Generic;

namespace formstienda.Datos;

public partial class Devolucion
{
    public int IdDevolucion { get; set; }

    public int IdVenta { get; set; }

    public string MotivoDevolucion { get; set; } = null!;

    public string DescripcionDevolucion { get; set; } = null!;

    public float MontoDevolucion { get; set; }

    public int CantidadDevuelta { get; set; }

    public string CedulaCliente { get; set; } = null!;

    public virtual Ventum Ventum { get; set; } = null!;
}
