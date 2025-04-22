using System;
using System.Collections.Generic;

namespace formstienda.Datos;

public partial class TasaDeCambio
{
    public int IdTasaCambio { get; set; }

    public DateTime FechaCambio { get; set; }

    public decimal ValorCambio { get; set; }
}
