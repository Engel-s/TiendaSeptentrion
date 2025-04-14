using System;
using System.Collections.Generic;

namespace formstienda.Models;

public partial class ArqueoCaja
{
    public int IdUsuario { get; set; }

    public int IdApertura { get; set; }

    public double TotalEfectivoCordoba { get; set; }

    public double TotalEfectivoDolar { get; set; }

    public double? FaltanteCordoba { get; set; }

    public double? FaltanteDolar { get; set; }

    public double? SobranteCordoba { get; set; }

    public double? SobranteDolar { get; set; }

    public virtual ICollection<Egreso> Egresos { get; set; } = new List<Egreso>();

    public virtual AperturaCaja IdAperturaNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
