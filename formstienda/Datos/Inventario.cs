using System;
using System.Collections.Generic;

namespace formstienda.Datos;

public partial class Inventario
{
    public int IdInventario { get; set; }

    public int IdProducto { get; set; }

    public int IdCategoria { get; set; }

    public int IdMarca { get; set; }

    public int StockActual { get; set; }

    public int CantidadSalir { get; set; }

    public string MotivoSalida { get; set; } = null!;

    public string DescripcionSalida { get; set; } = null!;

    public virtual Producto Producto { get; set; } = null!;
}
