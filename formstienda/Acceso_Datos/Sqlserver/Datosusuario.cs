using formstienda.Datos;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace formstienda.Acceso_Datos.Sqlserver
{
    internal class Datosusuario
    {
        public string recoverpassword(string userRequesting)
        {
                using (var command = new SqlCommand())
                {
                    command.CommandText = "SELECT *from Usuario  where Correo_Usuario=@mail";
                    command.Parameters.AddWithValue("@Correo_Usuario", userRequesting);
                    command.CommandType = System.Data.CommandType.Text;
                    SqlDataReader reader = command.ExecuteReader();
                
                    if (reader.Read() == true)
                    {
                       string username = reader.GetString(1)+", "+reader.GetString(2);
                       string useremail = reader.GetString(4);
                       string contraseña = reader.GetString(3);

                    var emailService = new Email_Servicios.SoporteSistema();
                    emailService.sendMail(
                        subject: "SISTEMA: SOLICITAR VER CONTRASEÑA",
                        body: "Hola, " + username +" ha solicitado ver su usuario o contraseña" + 
                        "Su contraseña es " + contraseña + "no comparta esta contraseña, se recomienda cambiar contraseña al entrar al sistema.",
                        recipientMail: new List<string> { useremail }
                        );
                    return "Se ha enviado un correo a " + useremail + " con su contraseña";
                }
                else
                {
                    return "No existe un usuario registrado con ese correo";
                }
                }
        }
    }
}
