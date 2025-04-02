using System;
using System.Collections.Generic;

namespace formstienda.Datos;

public partial class TasaDeCambio
{
    public int IdTasaCambio { get; set; }

    public DateOnly FechaCambio { get; set; }

    public double ValorCambio { get; set; }
}
