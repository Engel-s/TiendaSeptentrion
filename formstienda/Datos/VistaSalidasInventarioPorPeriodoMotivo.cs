using System;
using System.Collections.Generic;

namespace formstienda.Datos;

public partial class VistaSalidasInventarioPorPeriodoMotivo
{
    public int IdSalida { get; set; }

    public string CódigoProducto { get; set; } = null!;

    public string Producto { get; set; } = null!;

    public string Categoría { get; set; } = null!;

    public string Marca { get; set; } = null!;

    public int Cantidad { get; set; }

    public string Motivo { get; set; } = null!;

    public string Descripción { get; set; } = null!;

    public DateOnly FechaSalida { get; set; }

    public float PrecioUnitario { get; set; }

    public float? ValorTotal { get; set; }
}
