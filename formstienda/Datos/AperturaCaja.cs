using System;
using System.Collections.Generic;

namespace formstienda.Datos;

public partial class AperturaCaja
{
    public int IdApertura { get; set; }

    public decimal MontoApertura { get; set; }

    public DateTime FechaApertura { get; set; }

    public TimeOnly HoraApertura { get; set; }

    public string EstadoApertura { get; set; } = null!;

    public virtual ICollection<ArqueoCaja> ArqueoCajas { get; set; } = new List<ArqueoCaja>();
}
