using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace formstienda
{
    public class persona
    {
        private string nombrecliente;
        private string producto;

        public string NombreCliente { get; set; }
        public string Producto { get; set; }
        
        public persona(string nombrecliente, string producto)
        {
            Producto = producto;
            NombreCliente = nombrecliente;
        }
    }
    public class usuarios  //aqui guardo lo que ocupo xd
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Rol { get; set; }
        public string EnviarCodigoRecuperacion { get; set; }



    }
    public class productos
    {
        public string CODIGOPRODUCTO { get; set; }
        public string NOMBREPRODUCTO { get; set; }
        public string CATEGORIA { get; set; }
        public string MARCA { get; set; }
        public int STOCKACTUAL { get; set; }
        public int STOCKMINIMO { get; set; }
        public double PRECIOBASE { get; set; }
        public double PRECIOVENTA { get; set; }
        
    }
}
