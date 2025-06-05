using formstienda.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace formstienda.capa_de_negocios
{
    internal class OtrasSalidasServicio
    {

        private readonly DbTiendaSeptentrionContext _contexto;

        public OtrasSalidasServicio(DbTiendaSeptentrionContext contexto)
        {
            _contexto = contexto ?? throw new ArgumentNullException(nameof(contexto));
        }

        public Producto ObtenerProductoPorCodigo(string codigoProducto)
        {
            return _contexto.Productos
                .FirstOrDefault(p => p.CodigoProducto == codigoProducto);
        }

    }
}
