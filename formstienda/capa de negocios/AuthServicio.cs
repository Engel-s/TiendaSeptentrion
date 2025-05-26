using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using formstienda.Datos;
using Microsoft.EntityFrameworkCore;

namespace formstienda.capa_de_negocios
{
    public class AuthServicio
    {
        public Usuario? Validar_Credenciales(string nombreusuario, string password)
        {
            using (var contexto = new DbTiendaSeptentrionContext())
            {
                return contexto.Usuarios.FirstOrDefault(u => u.NombreUsuario == nombreusuario && u.ContraseñaUsuario == password);
            }
        }
    }
}