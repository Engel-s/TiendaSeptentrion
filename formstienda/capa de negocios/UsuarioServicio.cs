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
        public bool AgregarUsuario(Usuario usuario) 
        {
            if (usuario == null) 
            {
                MessageBox.Show("Rellenar los campos correctamente.");
                return false;
            }
            try
            {
                using (var _context = new DbTiendaSeptentrionContext()) 
                {
                    _context.Usuarios.Add (usuario);
                    _context.SaveChanges(); 
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
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
     

    }
}
