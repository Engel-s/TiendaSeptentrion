using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using formstienda.Datos;

namespace formstienda.Servicios
{
    public class EgresoServicio
    {
        private readonly DbTiendaSeptentrionContext _contexto;

        // El contexto no debería ser opcional (eliminar el = null)
        public EgresoServicio(DbTiendaSeptentrionContext contexto)
        {
            _contexto = contexto ?? throw new ArgumentNullException(nameof(contexto));
        }

        public List<AperturaCaja> ListarAperturaCaja()
        {
            try
            {
                // Solo selecciona las propiedades necesarias
                return _contexto.AperturaCajas
                    .AsNoTracking()
                    .ToList();
            }
            catch (Exception ex)
            {
                // Considera usar un sistema de logging profesional
                // En un servicio, no deberías mostrar MessageBox
                throw new ApplicationException("Error al listar la apertura de caja", ex);
            }
        }
    }
}