using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace formstienda.Negocios
{
    public class UsuarioDatos
    {
        public string recoverpassword(string userRequesting)
        {
            var datosusuario = new Acceso_Datos.Sqlserver.Datosusuario();
            return datosusuario.recoverpassword(userRequesting);
        }
    }
}
