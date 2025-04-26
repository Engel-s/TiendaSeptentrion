using System;
using System.Collections.Generic;

namespace formstienda.Datos;

public partial class Devolucion
{
    public int IdDevolucion { get; set; }

    public int IdFactura { get; set; }

    public int IdProducto { get; set; }

    public int IdCategoria { get; set; }

    public int IdMarca { get; set; }

    public int IdCliente { get; set; }

    public int IdVenta { get; set; }

    public string MotivoDevolucion { get; set; } = null!;

    public string DescripcionDevolucion { get; set; } = null!;

    public double MontoDevolucion { get; set; }

    public int CantidadDevueltaDevolucion { get; set; }

    public virtual DetalleDeVentum DetalleDeVentum { get; set; } = null!;
}
