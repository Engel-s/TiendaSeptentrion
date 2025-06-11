using formstienda.Datos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using formstienda.Datos;
using System.Windows.Automation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Client;
using Microsoft.Identity.Client.Platforms.Features.DesktopOs.Kerberos;
using Microsoft.EntityFrameworkCore;

namespace formstienda.capa_de_negocios
{
    
    public class ClienteServicio
    {
        //listar usuarios
        public List<Cliente> Listaclientes()
        {
            try
            {
                using (var _context = new DbTiendaSeptentrionContext())
                {
                    // select from * usuarios
                    return _context.Clientes.AsNoTracking().ToList();
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Cliente>();
            }
        }

        //agregar usuarios
        public bool Agregarcliente(Cliente cliente)
        {
            if (cliente == null)
            {
                MessageBox.Show("Rellenar los campos correctamente.");
                return false;
            }
            try
            {
                using (var _context = new DbTiendaSeptentrionContext())
                {
                    _context.Clientes.Add(cliente);
                    _context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        //eliminar usuarios
        public bool Eliminarcliente(int IdCliente)
        {
            try
            {
                using (var _contexto = new DbTiendaSeptentrionContext())

                {
                    var cliente = _contexto.Clientes.Find(IdCliente);
                    if (cliente == null)
                    {
                        Console.WriteLine("Cliente no encontrado");
                        return false;

                    }
                    _contexto.Clientes.Remove(cliente);
                    _contexto.SaveChanges();
                    return true;

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public Cliente BuscarClientePorNumero(string numero)
        {
            try
            {
                using (var _context = new DbTiendaSeptentrionContext())
                {
                    return _context.Clientes
                                   .AsNoTracking()
                                   .FirstOrDefault(c => c.TelefonoCliente == numero);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public bool Actualizarcliente(Cliente cliente)
        {
            try
            {
                using (var _contexto = new DbTiendaSeptentrionContext())
                {
                    var clienteExistente = _contexto.Clientes.Find(cliente.CedulaCliente);
                    if (clienteExistente == null)
                        return false;

                    clienteExistente.NombreCliente = cliente.NombreCliente;
                    clienteExistente.ApellidoCliente = cliente.ApellidoCliente;
                    clienteExistente.DireccionCliente = cliente.DireccionCliente;
                    clienteExistente.ColillaInssCliente = cliente.ColillaInssCliente;
                    clienteExistente.TelefonoCliente = cliente.TelefonoCliente;
                    clienteExistente.SujetoCredito = cliente.SujetoCredito;

                    _contexto.Clientes.Update(clienteExistente);
                    _contexto.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar cliente: " + ex.Message);
                return false;
            }
        }


    }

}
