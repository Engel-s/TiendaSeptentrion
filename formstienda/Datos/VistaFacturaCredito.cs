using System;
using System.Collections.Generic;

namespace formstienda.Datos;

public partial class VistaFacturaCredito
{
    public int IdCredito { get; set; }

    public int IdVenta { get; set; }

    public string CedulaCliente { get; set; } = null!;

    public string Cliente { get; set; } = null!;

    public DateOnly FechaVenta { get; set; }

    public float MontoCredito { get; set; }

    public float TotalAbonado { get; set; }

    public float NuevoSaldo { get; set; }

    public int PlazosMeses { get; set; }

    public float InteresMensual { get; set; }

    public DateOnly FechaInicio { get; set; }

    public DateOnly FechaFinal { get; set; }

    public string EstadoCredito { get; set; } = null!;

    public string UsuarioRegistro { get; set; } = null!;

    public int? CuotasPagadas { get; set; }

    public double? TotalPagado { get; set; }

    public DateTime? UltimoPago { get; set; }

    public float TotalVenta { get; set; }

    public string? Observaciones { get; set; }
}
