using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using formstienda.Datos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace formstienda.capa_de_negocios
{
    public class ProveedorServicio
    {

        public Proveedor buscarProvee(string numero)
        {
            try
            {
                using (var _context = new DbTiendaSeptentrionContext())
                {
                    return _context.Proveedors
                                   .AsNoTracking()
                                   .FirstOrDefault(c => c.TelefonoProveedor == numero);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        //Listar proveedor

        public List<Proveedor> ListarProveedores()
        {
            //validar con try-catch
            try
            {
                //Abrir context
                using (var contexto = new DbTiendaSeptentrionContext())
                {
                    //SELECT * FROM Proveedores
                    return contexto.Proveedors.ToList();
                }
            }
            catch(Exception ex)  
            {
                Console.WriteLine(ex.Message);
                return new List<Proveedor>();
            }
        }
        //Agregar proveedor

        public bool AgregarProveedor(Proveedor proveedor)
        {
            if (proveedor == null)
            {
                Console.WriteLine("El proveedor no puede ser nulo");
                return false;
            }
            try
            {
                using (var contexto = new DbTiendaSeptentrionContext())
                {
                    contexto.Proveedors.Add(proveedor);
                    contexto.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        //Actualizar proveedor
        public bool ActualizarProveedor(Proveedor proveedor, string rucAnterior)
        {
            /*try
            {
                using (var contexto = new DbTiendaSeptentrionContext())
                {
                    var proveedorExistente = contexto.Proveedors.Find(proveedor.CodigoRuc);
                    if (proveedorExistente == null)
                    {
                        Console.WriteLine("Proveedor no encontrado");
                        return false;
                    }

                    //Asignar valores actualizados
                    proveedorExistente.NombreProveedor = proveedor.NombreProveedor;
                    proveedorExistente.ApellidoProveedor = proveedor.ApellidoProveedor;
                    proveedorExistente.CorreoProveedor = proveedor.CorreoProveedor;
                    proveedorExistente.TelefonoProveedor = proveedor.TelefonoProveedor;
                    proveedorExistente.CodigoRuc = proveedor.CodigoRuc;
                    proveedorExistente.EstadoProveedor = proveedor.EstadoProveedor;

                    contexto.Proveedors.Update(proveedorExistente);
                    contexto.SaveChanges();
                    return true;

                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }*/
            try
            {
                using (var contexto = new DbTiendaSeptentrionContext())
                {
                    var proveedorExistente = contexto.Proveedors.Find(rucAnterior);
                    if (proveedorExistente == null)
                    {
                        Console.WriteLine("Proveedor no encontrado");
                        return false;
                    }

                    // Si el RUC no cambió, solo actualizamos los campos
                    if (rucAnterior == proveedor.CodigoRuc)
                    {
                        proveedorExistente.NombreProveedor = proveedor.NombreProveedor;
                        proveedorExistente.ApellidoProveedor = proveedor.ApellidoProveedor;
                        proveedorExistente.CorreoProveedor = proveedor.CorreoProveedor;
                        proveedorExistente.TelefonoProveedor = proveedor.TelefonoProveedor;
                        proveedorExistente.EstadoProveedor = proveedor.EstadoProveedor;

                        contexto.Proveedors.Update(proveedorExistente);
                    }
                    else
                    {
                        // Verificar si el nuevo RUC ya está en uso
                        bool rucYaExiste = contexto.Proveedors.Any(p => p.CodigoRuc == proveedor.CodigoRuc);
                        if (rucYaExiste)
                        {
                            Console.WriteLine("El nuevo Código RUC ya está en uso");
                            return false;
                        }

                        // Eliminar el antiguo y agregar uno nuevo con el nuevo RUC
                        contexto.Proveedors.Remove(proveedorExistente);
                        contexto.Proveedors.Add(proveedor); // proveedor tiene el nuevo RUC y datos actualizados
                    }

                    contexto.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

       public string ObtenerCodigoRucPorNombre(string NombreCompleto)
        {
            using(var context = new DbTiendaSeptentrionContext())
            {
                var proveedor = context.Proveedors
                    .FirstOrDefault(p => (p.NombreProveedor + " " + p.ApellidoProveedor).ToLower() == NombreCompleto.ToLower());
                return proveedor != null ? proveedor.CodigoRuc : "0" ;
            }
       }
    }
}
