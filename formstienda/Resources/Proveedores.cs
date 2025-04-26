
using formstienda.Datos;

namespace formstienda.Resources
{
    public class Proveedores
    {
        //Listar proveedores 
        public List<Proveedor> listarProveedores()
        {
            // Validacion con try-catch
            //validar si la lsita es 
            try
            {
                using (var _contexto = new TiendaDBContext())
                {
                    return _contexto.Proveedors.ToList();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Proveedor>();
            }



        }
    }
}
