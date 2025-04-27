using System;
using System.Collections.Generic;

namespace formstienda.Datos;

public partial class Usuario
{
    public bool EnviarCodigoRecuperacion(string email)
    {
        using (var contexto = new BdUsuarioContex())
        {
            var usuario = contexto.Usuarios
                .FirstOrDefault( u => u.Email == email);
            if (usuario = null)
                return false;

            var token = Guid.NewGuid().ToString();
            usuario.TokenRecuperacion = token;
            usuario.FechaHoraRecuperacion = DateTime.Now.AddMinutes(10);

            contexto.Usuarios.Update(usuario);

            contexto.SaveChange();

        }
    }
    public int IdUsuario { get; set; }

    public string NombreUsuario { get; set; } = null!;

    public string ApellidoUsuario { get; set; } = null!;

    public string ContraseñaUsuario { get; set; } = null!;

    public string CorreoUsuario { get; set; } = null!;

    public string TelefonoUsuario { get; set; } = null!;

    public string RolUsuario { get; set; } = null!;

    public bool EstadoUsuario { get; set; }

    public virtual ICollection<ArqueoCaja> ArqueoCajas { get; set; } = new List<ArqueoCaja>();
}


