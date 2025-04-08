    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace formstienda.Acceso_Datos.Email_Servicios
{
    public abstract class MasterEmailServer
    {
        private SmtpClient smtpClient;
        protected string senderEmail { get; set; }
        protected string contraseña { get; set; }
        protected string host { get; set; }
        protected int port { get; set; }
        protected bool Ssl { get; set; }

        protected void initializarSmtpClient()
        {
            smtpClient = new SmtpClient();
            smtpClient.Credentials = new NetworkCredential(senderEmail, contraseña);
            smtpClient.Host = host;
            smtpClient.Port = port;
            smtpClient.EnableSsl = Ssl;
        }

        public void sendMail(string subject, string body, List<string> recipientMail)
        {
            var mailMessage = new MailMessage();

            try
            {
                mailMessage.From = new MailAddress(senderEmail);
                foreach(string mail in recipientMail)
                {
                    mailMessage.To.Add(mail);
                }
                mailMessage.Subject = subject;
                mailMessage.Body = body;
                mailMessage.Priority = MailPriority.Normal;
                smtpClient.Send(mailMessage);
            }
            catch (Exception ex)
            {
            }
            finally
            {
                mailMessage.Dispose();
                smtpClient.Dispose();
            }
        }
    }   
}
