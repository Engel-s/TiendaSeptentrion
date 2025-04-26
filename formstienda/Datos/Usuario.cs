using System;
using System.Collections.Generic;

namespace formstienda.Datos;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string NombreUsuario { get; set; } = null!;

    public string ApellidoUsuario { get; set; } = null!;

    public string ContraseñaUsuario { get; set; } = null!;

    public string CorreoUsuario { get; set; } = null!;

    public string TelefonoUsuario { get; set; } = null!;

    public string RolUsuario { get; set; } = null!;

    public bool? EstadoUsuario { get; set; }
<<<<<<< HEAD
=======

    public string UsuarioLogueo { get; set; } = null!;
<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> d25b44a56df6453a6106d9619f5573ed3d7b80b2
>>>>>>> b010f4a8a85e19fa2f9bf5429bc3252f6dd76b95

    public string UsuarioLogueo { get; set; } = null!;
=======
>>>>>>> proveedores

    public virtual ICollection<ArqueoCaja> ArqueoCajas { get; set; } = new List<ArqueoCaja>();
}
