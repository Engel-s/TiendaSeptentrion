using formstienda.Datos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace formstienda.capa_de_negocios
{
   public class UsuarioServicio
    {
        //listar usuarios3
        public List <Usuario> Listausuarios()
        {
            try 
            {
                using (var _context = new DbTiendaSeptentrionContext())
                {
                    // select from * usuarios
                    return _context.Usuarios.AsNoTracking().ToList();
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Usuario>();
            }
        }



        //agregar usuarios
        public bool AgregarUsuario(Usuario usuario)
        {
            if (usuario == null)
            {
                //MessageBox.Show("Rellenar los campos correctamente.");
                return false;
            }

            try
            {
                using (var _context = new DbTiendaSeptentrionContext())
                {
                   
                    var usuarioExistente = _context.Usuarios.FirstOrDefault(u => u.CorreoUsuario == usuario.CorreoUsuario);

                    if (usuarioExistente != null)
                    {
                       // MessageBox.Show("El usuario ya existe.");
                        return false;
                    }

                    // If not, add the new user
                    _context.Usuarios.Add(usuario);
                    _context.SaveChanges();
                   // MessageBox.Show("Usuario agregado correctamente.");
                    return true;
                }
            }
            catch (Exception ex)
            {
                string errorMessage = ex.Message;

                if (ex.InnerException != null)
                {
                    errorMessage += "\n\nInner Exception:\n" + ex.InnerException.Message;
                }

               // MessageBox.Show(errorMessage, "Error al guardar usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }

        //eliminar usuarios
        public bool Eliminarusuario(int IdUsuario)
        {
            try
            {
                using (var _contexto = new DbTiendaSeptentrionContext()) 
                
                {
                    var usuario = _contexto.Usuarios.Find(IdUsuario);
                    if (usuario == null)
                    {
                        Console.WriteLine("usuario no encontrado");
                        return false;

                    }
                    _contexto.Usuarios.Remove(usuario);
                    _contexto.SaveChanges();
                    return true;

                }          
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        //actualizar usuarios
        public bool Actualizarusuario(Usuario usuario)
        {
            try
            {
                using (var _contexto = new DbTiendaSeptentrionContext())
                {
                    var usuarioExistente = _contexto.Usuarios.Find(usuario.IdUsuario);
                    if (usuarioExistente == null)
                    {
                       
                        return false;
                    }

                    // Actualizar campos editables
                    usuarioExistente.NombreUsuario = usuario.NombreUsuario;
                    usuarioExistente.ApellidoUsuario = usuario.ApellidoUsuario;
                    usuarioExistente.CorreoUsuario = usuario.CorreoUsuario;
                    usuarioExistente.RolUsuario = usuario.RolUsuario;
                    usuarioExistente.EstadoUsuario = usuario.EstadoUsuario;
                    usuarioExistente.TelefonoUsuario = usuario.TelefonoUsuario;
                    usuarioExistente.UsuarioLogueo = usuario.UsuarioLogueo;

                    // No se actualiza la contraseña desde la edición directa

                    _contexto.Usuarios.Update(usuarioExistente);
                    _contexto.SaveChanges();
                    return true;
                }
                


            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
                return false;
            }
                
        }


    }
}
