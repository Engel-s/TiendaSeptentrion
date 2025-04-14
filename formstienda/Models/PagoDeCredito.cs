using System;
using System.Collections.Generic;

namespace formstienda.Models;

public partial class PagoDeCredito
{
    public int IdCredito { get; set; }

    public int IdFactura { get; set; }

    public int IdProducto { get; set; }

    public int IdCategoria { get; set; }

    public int IdMarca { get; set; }

    public int IdCliente { get; set; }

    public int IdVenta { get; set; }

    public double TotalAbonado { get; set; }

    public double? PagoCordobas { get; set; }

    public double? PagoDolares { get; set; }

    public double Cambio { get; set; }

    public double NuevoSaldo { get; set; }

    public virtual DetalleDeVentum DetalleDeVentum { get; set; } = null!;
}
