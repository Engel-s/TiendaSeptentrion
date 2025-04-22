using formstienda.Datos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public bool Actualizarcliente(Cliente cliente)
        {
            try
            {
                using (var _contexto = new DbTiendaSeptentrionContext())
                {
                    var clienteExistente = _contexto.Clientes.Find(cliente.IdCliente);
                    if (clienteExistente == null)
                    {
                        Console.WriteLine($"Error:No se encontro el cliente con ID(cliente.IdCliente).");
                        return false;

                    }
                    clienteExistente.NombreCliente = cliente.NombreCliente;
                    clienteExistente.ApellidoCliente = cliente.ApellidoCliente;
                    clienteExistente.CedulaCliente = cliente.CedulaCliente;
                    clienteExistente.TelefonoCliente = cliente.TelefonoCliente;
                    clienteExistente.ColillaInssCliente = cliente.ColillaInssCliente;
                    clienteExistente.DireccionCliente = cliente.DireccionCliente;
                    clienteExistente.SujetoCredito= cliente.SujetoCredito;
                    _contexto.Clientes.Update(clienteExistente);
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
    }
}
