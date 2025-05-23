using formstienda.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace formstienda.capa_de_negocios
{
    internal class ArqueoDeCajaServicio
    {
        // Contexto de base de datos
        private readonly DbTiendaSeptentrionContext _contexto;

        // Constructor
        public ArqueoDeCajaServicio(DbTiendaSeptentrionContext contexto)
        {
            _contexto = contexto ?? throw new ArgumentNullException(nameof(contexto));
        }
    }
}
