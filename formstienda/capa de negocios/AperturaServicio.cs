using formstienda.Datos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace formstienda.capa_de_negocios
{
    public class AperturaServicio
    {
        public List<AperturaCaja> Listaapertura()
        {
            try
            {
                using (var _context = new DbTiendaSeptentrionContext())
                {
                    // select from * usuarios
                    return _context.AperturaCajas.AsNoTracking().ToList();
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<AperturaCaja>();
            }
        }
        public bool Agregarfondo(AperturaCaja aperturaCaja)
        {
            if (aperturaCaja == null)
            {
                MessageBox.Show("Rellenar los campos correctamente.");
                return false;
            }
            try
            {
                using (var _context = new DbTiendaSeptentrionContext())
                {
                    _context.AperturaCajas.Add(aperturaCaja);
                    _context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                string errorMessage = ex.Message;

                if (ex.InnerException != null)
                {
                    errorMessage += "\n\nInner Exception:\n" + ex.InnerException.Message;
                }

                MessageBox.Show(errorMessage, "Error al registrar fondo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }
        public AperturaCaja? ObtenerAperturaHoy()
        {
            try
            {
                using (var _context = new DbTiendaSeptentrionContext())
                {
                    var hoy = DateOnly.FromDateTime(DateTime.Today);
                    return _context.AperturaCajas
                                   .AsNoTracking()
                                   .FirstOrDefault(a => a.FechaApertura == hoy);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener apertura de hoy: " + ex.Message);
                return null;
            }
        }
        public bool ActualizarApertura(AperturaCaja apertura)
        {
            try
            {
                using (var context = new DbTiendaSeptentrionContext())
                {
                    var existente = context.AperturaCajas.FirstOrDefault(a => a.IdApertura == apertura.IdApertura);
                    if (existente != null)
                    {
                        existente.EstadoApertura = apertura.EstadoApertura;
                        context.SaveChanges();
                        return true;
                    }

                    return false;
                }
            }
            catch
            {
                return false;
            }
        }


    }
}
