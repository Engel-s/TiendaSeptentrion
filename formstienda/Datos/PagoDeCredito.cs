using System;
using System.Collections.Generic;

namespace formstienda.Datos;

public partial class PagoDeCredito
{
    public int IdCredito { get; set; }

    public int IdVenta { get; set; }

    public string EstadoCredito { get; set; } = null!;

    public float TotalAbonado { get; set; }

    public float? CordobasAbonados { get; set; }

    public float? DolaresAbonados { get; set; }

    public float Cambio { get; set; }

    public float NuevoSaldo { get; set; }

    public DateOnly? FechaPago { get; set; }

    public virtual Ventum IdVentaNavigation { get; set; } = null!;
}
