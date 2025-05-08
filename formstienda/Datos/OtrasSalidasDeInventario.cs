using System;
using System.Collections.Generic;

namespace formstienda.Datos;

public partial class OtrasSalidasDeInventario
{
    public int IdInventario { get; set; }

    public string CodigoProducto { get; set; } = null!;

    public int IdCategoria { get; set; }

    public int IdMarca { get; set; }

    public int CantidadSalir { get; set; }

    public string MotivoSalida { get; set; } = null!;

    public string DescripcionSalida { get; set; } = null!;

    public virtual Producto Producto { get; set; } = null!;
}
