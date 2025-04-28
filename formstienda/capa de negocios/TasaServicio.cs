using formstienda.Datos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace formstienda.capa_de_negocios
{
    public class TasaServicio
    {
       
            //listar usuarios
            public List<TasaDeCambio> Listatasacambios()
            {
                try
                {
                    using (var _context = new DbTiendaSeptentrionContext())
                    {
                        // select from * usuarios
                        return _context.TasaDeCambios.AsNoTracking().ToList();
                    }
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return new List<TasaDeCambio>();
                }
            }
        public bool AgregarTasa(TasaDeCambio tasadecambio)
        {
            if (tasadecambio == null)
            {
                MessageBox.Show("Rellenar los campos correctamente.");
                return false;
            }

            try
            {
                using (var _context = new DbTiendaSeptentrionContext())
                {
                    // Check if the user already exists based on some unique identifier (e.g., CorreoUsuario or NombreUsuario)
                    //var usuarioExistente = _context.Usuarios.FirstOrDefault(u => u.CorreoUsuario == usuario.CorreoUsuario);

                    //if (usuarioExistente != null)
                    //{
                    //    MessageBox.Show("El usuario ya existe.");
                    //    return false;
                    //}

                    // If not, add the new user
                    _context.TasaDeCambios.Add(tasadecambio);
                    _context.SaveChanges();
                    MessageBox.Show("Usuario agregado correctamente.");
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

                MessageBox.Show(errorMessage, "Error al guardar usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }
    }
}

