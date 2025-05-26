using formstienda.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace formstienda.capa_de_negocios
{
    public class ArqueoServicio
    {
        public ArqueoCaja ObtenerArqueoActivo()
        {
            using (var contexto = new DbTiendaSeptentrionContext())
            {
                var hoy = DateOnly.FromDateTime(DateTime.Now);

                return contexto.ArqueoCajas
                    .Include(a => a.IdAperturaNavigation)
                    .FirstOrDefault(a => a.IdAperturaNavigation.FechaApertura == hoy);
            }
        }

    }
}
