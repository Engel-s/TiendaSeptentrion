using System;
using System.Collections.Generic;

namespace formstienda.Datos;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public string NombreCliente { get; set; } = null!;

    public string ApellidoCliente { get; set; } = null!;

    public bool? SujetoCredito { get; set; }

    public string TelefonoCliente { get; set; } = null!;

    public string CedulaCliente { get; set; } = null!;

    public string ColillaInssCliente { get; set; } = null!;

    public string? DireccionCliente { get; set; }

    public virtual ICollection<DetalleDeVentum> DetalleDeVenta { get; set; } = new List<DetalleDeVentum>();
}
