using System;
using System.Collections.Generic;

namespace formstienda.Datos;

public partial class DevolucionVenta
{
    public int IdDevolucion { get; set; }

    public int IdVenta { get; set; }

    public string CedulaCliente { get; set; } = null!;

    public string MotivoDevolucion { get; set; } = null!;

    public string DescripcionDevolucion { get; set; } = null!;

    public DateOnly FechaDevolucion { get; set; }
}
