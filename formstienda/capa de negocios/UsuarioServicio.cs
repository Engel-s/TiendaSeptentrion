using formstienda.Datos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace formstienda.capa_de_negocios
{
<<<<<<< HEAD
   public class UsuarioServicio
=======
    public class UsuarioServicio
>>>>>>> productos
    {
        //listar usuarios
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
<<<<<<< HEAD
        public bool AgregarUsuario(Usuario usuario)
        {
            if (usuario == null)
=======
        public bool AgregarUsuario(Usuario usuario) 
        {
            if (usuario == null) 
>>>>>>> productos
            {
                MessageBox.Show("Rellenar los campos correctamente.");
                return false;
            }
<<<<<<< HEAD

            try
            {
                using (var _context = new DbTiendaSeptentrionContext())
                {
                    // Check if the user already exists based on some unique identifier (e.g., CorreoUsuario or NombreUsuario)
                    var usuarioExistente = _context.Usuarios.FirstOrDefault(u => u.CorreoUsuario == usuario.CorreoUsuario);

                    if (usuarioExistente != null)
                    {
                        MessageBox.Show("El usuario ya existe.");
                        return false;
                    }

                    // If not, add the new user
                    _context.Usuarios.Add(usuario);
                    _context.SaveChanges();
                    MessageBox.Show("Usuario agregado correctamente.");
=======
            try
            {
                using (var _context = new DbTiendaSeptentrionContext()) 
                {
                    _context.Usuarios.Add (usuario);
                    _context.SaveChanges(); 
>>>>>>> productos
                    return true;
                }
            }
            catch (Exception ex)
            {
<<<<<<< HEAD
                string errorMessage = ex.Message;

                if (ex.InnerException != null)
                {
                    errorMessage += "\n\nInner Exception:\n" + ex.InnerException.Message;
                }

                MessageBox.Show(errorMessage, "Error al guardar usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }

=======
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        
>>>>>>> productos
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
<<<<<<< HEAD
        public bool Actualizarusuario(Usuario usuario)
        {
            try
            {
                using (var _contexto = new DbTiendaSeptentrionContext())
                {
                    var usuarioExistente = _contexto.Usuarios.Find(usuario.IdUsuario);
                    if (usuarioExistente == null)
                    {
                        Console.WriteLine($"Error:No se encontro el proveedor con ID(usuario.IdUsuario).");
                        return false;

                    }
                    usuarioExistente.NombreUsuario=usuario.NombreUsuario;
                    usuarioExistente.ApellidoUsuario=usuario.ApellidoUsuario;
                    usuarioExistente.CorreoUsuario=usuario.CorreoUsuario;
                    usuarioExistente.RolUsuario=usuario.RolUsuario;
                    usuarioExistente.EstadoUsuario=usuario.EstadoUsuario;
                    usuarioExistente.ContraseñaUsuario=usuario.ContraseñaUsuario;
                    _contexto.Usuarios.Update(usuarioExistente);
                    _contexto .SaveChanges();
                    return true;
                }
                


            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
                return false;
            }
                
        }

=======
>>>>>>> productos

    }
}
