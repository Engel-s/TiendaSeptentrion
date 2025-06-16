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


namespace formstienda.capa_de_negocios
{
    internal class ClienteRecuperacion
    {

        public bool EnviarCodigoRecuperacion(string email)
        {
            using (var contexto = new DbTiendaSeptentrionContext())
            {
                var usuario = contexto.Usuarios.FirstOrDefault(
                    u => u.CorreoUsuario == email
                    );
                if (usuario == null)
                    return false;

                var token = Guid.NewGuid().ToString();
                usuario.TokenRecuperacion = token;
                usuario.FechaRecuperacion = DateTime.Now.AddMinutes(10);

                contexto.Usuarios.Update(usuario);

                contexto.SaveChanges();

        

                return EnviarCorreo(email, token);
            }

        }

        public bool EnviarCorreo(string correodestino, string token)
        {
            try
            {
                var correoserver = "ryuunxo@zohomail.com";

                var stmp = new SmtpClient("smtp.zoho.com")
                {
                    Port = 587,
                    //poner correo de zoho. engell o elking//
                    Credentials = new NetworkCredential(correoserver, "D61mFeth7tKu"),
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
            using (var contexto = new DbTiendaSeptentrionContext())
            {
                var usuario = contexto.Usuarios.FirstOrDefault
                    (
                        u => u.CorreoUsuario == correo &&
                        u.TokenRecuperacion == token
                    );

                if (usuario == null)

                    return false;

                bool realizarcambios = usuario.FechaRecuperacion > DateTime.Now;

                if (realizarcambios)
                {
                    usuario.ContraseñaUsuario = nuevacontraseña;
                    usuario.TokenRecuperacion = null;
                    usuario.FechaRecuperacion = null;

                    contexto.Usuarios.Update(usuario);

                    contexto.SaveChanges();
                    return true;
                }
                else
                    return false;

            }
        }

    }
}

