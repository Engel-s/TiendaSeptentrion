using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using formstienda.Datos;
using System.Windows.Automation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Client;
using Microsoft.Identity.Client.Platforms.Features.DesktopOs.Kerberos;
using Microsoft.EntityFrameworkCore;

namespace formstienda
{
    public class UserManager
    {
        public bool EnviarCodigoRecuperacion(string email)
        {
            using (var contexto = new TiendaDBContext())
            {
                var usuario = contexto.Usuarios.FirstOrDefault(
                    u => u.CorreoUsuario == email
                    );
                if (usuario == null)
                    return false;

                var token = Guid.NewGuid().ToString();
                usuario.TokenRecuperacion = token;
                usuario.FechaHoraRecuperacion = DateTime.Now.AddMinutes(10);

                contexto.Usuarios.Update(usuario);

                contexto.SaveChanges();

                MessageBox.Show($"Se ha guardado el token {token} en BD");

                return EnviarCorreo(email, token);
            }

        }



        public bool EnviarCorreo(string correodestino, string token)
        {
            try
            {
                var correoserver = "isaac_zomber@zohomail.com";

                var stmp = new SmtpClient("smtp.zoho.com")
                {
                    Port = 587,
                    //poner correo de zoho. engell o elking//
                    Credentials = new NetworkCredential(correoserver, "9MfnbmDKxk1Q"),
                    EnableSsl = true,

                };
                string asuntoCorreo = "Recuperacion Contraseña";
                string cuerpoCorreo = $" Tu codigo de recuperación: {token}";

                var mensajeCorreo = new MailMessage
                {
                    From = new MailAddress(correoserver),
                    Subject = asuntoCorreo,
                    Body = cuerpoCorreo,
                    IsBodyHtml = false
                };
                mensajeCorreo.To.Add(correodestino);
                stmp.Send(mensajeCorreo);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;

            }

        }



        public bool cambiarcontraseña(string correo, string token, string nuevacontraseña)
        {
            using (var contexto = new TiendaDBContext())
            {
                var usuario = contexto.Usuarios.FirstOrDefault
                    (
                        u => u.CorreoUsuario == correo && 
                        u.TokenRecuperacion == token
                    );

                if (usuario == null)
                
                    return false;

                    bool realizarcambios = usuario.FechaHoraRecuperacion > DateTime.Now;

                    if (realizarcambios)
                    {
                        usuario.ContraseñaUsuario = nuevacontraseña;
                        usuario.TokenRecuperacion = null;
                        usuario.FechaHoraRecuperacion = null;

                        contexto.Usuarios.Update(usuario);

                        contexto.SaveChanges();
                        return true;
                    }
                    else 
                        return false;
                
            }
        }
        


        public static UserManager _instance;
        public static UserManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UserManager();
                }
                return _instance;
            }
        }

        // Lista para almacenar usuarios
        public List<usuarios> Usuarios { get; set; }

        // Constructor privado para el patrón Singleton
        public UserManager()
        {
            Usuarios = new List<usuarios>
            {
            new usuarios { Id= "01", Rol="Admin", Username = "Administrador", Password = "rafa8565" },
            new usuarios { Id= "02", Rol="Cajero", Username = "CajaEngel", Password = "engel59" },
            new usuarios { Id= "03", Rol="Cajero", Username = "CajaGuillermo", Password = "guillermo78" }
            };
        }

        // Método para agregar un usuario nuevo
        public bool AgregarUsuario(usuarios nuevoUsuario)
        {
            // Verificar si el usuario ya existe
            if (Usuarios.Any(u => u.Username == nuevoUsuario.Username))
            {
                MessageBox.Show("Error: El usuario ya existe.");
                return false; // Retornar falso si el usuario ya existe
            }
            else
            {
                // Agregar el nuevo usuario a la lista
                Usuarios.Add(nuevoUsuario);
                MessageBox.Show("Usuario agregado con éxito.");
                return true; // Retornar verdadero si se agregó el usuario
            }
        }

        // Otros métodos (UserLog y permisos)
        public string RolActual { get; private set; }
        public usuarios UserLog(string Username, string Password)
        {
            var user = Usuarios.FirstOrDefault(u => u.Username == Username && u.Password == Password);
            if (user != null)
            {
                RolActual = user.Rol; // Guarda el rol del usuario logueado
            }
            return user;
        }

    } 
}
