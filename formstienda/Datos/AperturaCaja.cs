using System;
using System.Collections.Generic;

namespace formstienda.Datos;

public partial class AperturaCaja
{
    public int IdApertura { get; set; }

    public double MontoApertura { get; set; }

    public DateOnly FechaApertura { get; set; }

    public DateTime HoraApertura { get; set; }

    public string EstadoApertura { get; set; } = null!;

    public virtual ICollection<ArqueoCaja> ArqueoCajas { get; set; } = new List<ArqueoCaja>();
}
