using System;
using System.Collections.Generic;

namespace formstienda.Datos;

public partial class VistaDetalleCreditoCliente
{
    public int Factura { get; set; }

    public DateOnly FechaDeVenta { get; set; }

    public string Producto { get; set; } = null!;

    public string Categoría { get; set; } = null!;

    public string Marca { get; set; } = null!;

    public decimal? PrecioDeVenta { get; set; }

    public int Cantidad { get; set; }

    public decimal? Subtotal { get; set; }

    public decimal? Total { get; set; }

    public DateTime? FechaDePago { get; set; }

    public string TeléfonoCliente { get; set; } = null!;

    public string NombreDelCliente { get; set; } = null!;

    public string? Dirección { get; set; }

    public float TotalCrédito { get; set; }
}
