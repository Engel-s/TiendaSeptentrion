using System;
using System.Collections.Generic;

namespace formstienda.Datos;

public partial class Egreso
{
    public int IdEgreso { get; set; }

    public int IdUsuario { get; set; }

    public int IdApertura { get; set; }

    public DateOnly FechaEgreso { get; set; }

    public double CantidadEgresada { get; set; }

    public string MotivoEgreso { get; set; } = null!;

    public virtual ArqueoCaja ArqueoCaja { get; set; } = null!;
}
