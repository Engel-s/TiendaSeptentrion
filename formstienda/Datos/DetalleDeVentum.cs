using System;
using System.Collections.Generic;

namespace formstienda.Datos;

public partial class DetalleDeVentum
{
    public int IdFactura { get; set; }

    public int IdProducto { get; set; }

    public int IdCategoria { get; set; }

    public int IdMarca { get; set; }

    public int IdCliente { get; set; }

    public int IdVenta { get; set; }

    public int Cantidad { get; set; }

    public bool FormaDePago { get; set; }

    public double? PagoCordoba { get; set; }

    public double? PagoDolar { get; set; }

    public double TotalPago { get; set; }

    public double? CambioVenta { get; set; }

    public virtual ICollection<Devolucion> Devolucions { get; set; } = new List<Devolucion>();

    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    public virtual Ventum IdVentaNavigation { get; set; } = null!;

    public virtual ICollection<PagoDeCredito> PagoDeCreditos { get; set; } = new List<PagoDeCredito>();
}
