using System;
using System.Collections.Generic;

namespace formstienda.Datos;

public partial class Producto
{
    public string CodigoProducto { get; set; } = null!;

    public int IdCategoria { get; set; }

    public int IdMarca { get; set; }

    public string NombreProducto { get; set; } = null!;

    public double PrecioVenta { get; set; }

    public bool EstadoProducto { get; set; }

    public int StockActual { get; set; }

    public int StockMinimo { get; set; }

    public virtual Categorium IdCategoriaNavigation { get; set; } = null!;

    public virtual Marca IdMarcaNavigation { get; set; } = null!;
}
