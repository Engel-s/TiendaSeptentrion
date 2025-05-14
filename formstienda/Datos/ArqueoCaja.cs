using System;
using System.Collections.Generic;

namespace formstienda.Datos;

public partial class ArqueoCaja
{
    public int IdArqueoCaja { get; set; }

    public int IdUsuario { get; set; }

    public int IdApertura { get; set; }

    public decimal TotalEfectivoCordoba { get; set; }

    public decimal TotalEfectivoDolar { get; set; }

    public decimal? FaltanteCordoba { get; set; }

    public decimal? FaltanteDolar { get; set; }

    public decimal? SobranteCordoba { get; set; }

    public decimal? SobranteDolar { get; set; }

    public virtual ICollection<Egreso> Egresos { get; set; } = new List<Egreso>();

    public virtual AperturaCaja IdAperturaNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
