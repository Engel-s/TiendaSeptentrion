using formstienda.Datos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Client;
using Microsoft.Identity.Client.Platforms.Features.DesktopOs.Kerberos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;
using System.Windows.Forms;


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
                string correoRemitente = "ryuunxo@zohomail.com";
                string nombreRemitente = "Soporte - Sistema Tienda";
                string contraseña = "D61mFeth7tKu";
                string smtpServidor = "smtp.zoho.com";
                int puerto = 587;

                using (var smtp = new SmtpClient(smtpServidor, puerto))
                {
                    smtp.Credentials = new NetworkCredential(correoRemitente, contraseña);
                    smtp.EnableSsl = true;

                    var mensaje = new MailMessage
                    {
                        From = new MailAddress(correoRemitente, nombreRemitente),
                        Subject = "Recuperación de Contraseña - Sistema Tienda",
                        IsBodyHtml = true
                    };
                    mensaje.To.Add(correodestino);


                    // Ruta local de tu imagen (asegúrate que exista en esa ubicación)
                    string rutaImagen = @"..\..\..\Resources\logo_actualizado-removebg-preview.png";
                    string contentId = "LogoEmpresa";

                    // Crear HTML con imagen embebida
                    string htmlBody = $@"
                                <html>
                                <head>
                                  <style>
                                    body {{
                                        font-family: 'Segoe UI', sans-serif;
                                        background-color: #f0f2f5;
                                        margin: 0;
                                        padding: 0;
                                    }}
                                    .container {{
                                        max-width: 600px;
                                        margin: 40px auto;
                                        background-color: #ffffff;
                                        border-radius: 8px;
                                        box-shadow: 0 8px 20px rgba(0,0,0,0.1);
                                        overflow: hidden;
                                    }}
                                    .header {{
                                        background-color: #2980b9;
                                        padding: 20px;
                                        text-align: center;
                                    }}
                                    .header img {{
                                        max-height: 60px;
                                    }}
                                    .titulo {{
                                        color: #ffffff;
                                        font-size: 24px;
                                        margin-top: 10px;
                                    }}
                                    .contenido {{
                                        padding: 30px;
                                        color: #333333;
                                        font-size: 16px;
                                        line-height: 1.6;
                                    }}
                                    .codigo {{
                                        font-size: 28px;
                                        font-weight: bold;
                                        background-color: #f1f1f1;
                                        padding: 12px 24px;
                                        border-radius: 8px;
                                        display: inline-block;
                                        margin: 20px 0;
                                        color: #2c3e50;
                                        letter-spacing: 2px;
                                    }}
                                    .footer {{
                                        background-color: #f8f8f8;
                                        padding: 20px;
                                        text-align: center;
                                        font-size: 12px;
                                        color: #888888;
                                    }}
                                  </style>
                                </head>
                                <body>
                                  <div class='container'>
                                    <div class='header'>
                                      <img src='cid:{contentId}' alt='Logo' />
                                      <div class='titulo'>Recuperación de Contraseña</div>
                                    </div>
                                    <div class='contenido'>
                                      <p>Hola,</p>
                                      <p>Recibimos una solicitud para restablecer tu contraseña en el sistema <strong>Tienda - Septentrion</strong>.</p>
                                      <p>Usa el siguiente código para continuar con el proceso:</p>
                                      <div class='codigo'>{token}</div>
                                      <p>Este código expirará en pocos minutos por seguridad.</p>
                                      <p>Si tú no solicitaste este cambio, por favor ignora este mensaje.</p>
                                    </div>
                                    <div class='footer'>
                                      &copy; {DateTime.Now.Year} Sistema Tienda - Septentrion<br/>
                                      Este mensaje fue generado automáticamente. No respondas a este correo.
                                    </div>
                                  </div>
                                </body>
                                </html>";


                    // Crea una vista alternativa para embebidos
                    AlternateView vistaHtml = AlternateView.CreateAlternateViewFromString(htmlBody, null, MediaTypeNames.Text.Html);

                    // Adjunta la imagen
                    LinkedResource imagen = new LinkedResource(rutaImagen, MediaTypeNames.Image.Jpeg)
                    {
                        ContentId = contentId,
                        TransferEncoding = TransferEncoding.Base64
                    };
                    vistaHtml.LinkedResources.Add(imagen);

                    // Agrega la vista al mensaje
                    mensaje.AlternateViews.Add(vistaHtml);

                    smtp.Send(mensaje);
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al enviar el correo: " + ex.Message);
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

