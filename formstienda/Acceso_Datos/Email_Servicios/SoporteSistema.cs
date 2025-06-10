using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace formstienda.Acceso_Datos.Email_Servicios
{
    class SoporteSistema : MasterEmailServer
    {
        public SoporteSistema() 
        {
            senderEmail = "sistemasoporte06@gmail.com";
            contraseña = "Sistemasoporte06_/";
            host = "smtp.gmail.com";
            port = 587;
            Ssl = true;
            initializarSmtpClient();
        }
    }
}
