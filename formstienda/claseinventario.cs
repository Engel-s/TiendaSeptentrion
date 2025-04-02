using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace formstienda
{
    public class Claseinventario
    {
        private static Claseinventario _instance;
        public static Claseinventario Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Claseinventario();
                }
                return _instance;
            }
        }
        public List<productos> Productos;
        private Claseinventario()
        {
            Productos = new List<productos>
            {
                new productos {CODIGOPRODUCTO="01CPV1", NOMBREPRODUCTO="Protectores Celulares Samsung",CATEGORIA="Protectores",MARCA="Generico",STOCKACTUAL=150,STOCKMINIMO=25,PRECIOBASE=250,PRECIOVENTA=280,},
                new productos {CODIGOPRODUCTO="02CRPV2",NOMBREPRODUCTO="Cargadores Genericos",CATEGORIA="Cargadores",MARCA="Generico",STOCKACTUAL=250,STOCKMINIMO=25,PRECIOBASE=150,PRECIOVENTA=185,},
                new productos {CODIGOPRODUCTO = "03TFPV1",NOMBREPRODUCTO = "Samsung A54",CATEGORIA="Celulares",MARCA="Samsung",STOCKACTUAL=50,STOCKMINIMO=5,PRECIOBASE=7500,PRECIOVENTA=8800,},
                new productos {CODIGOPRODUCTO = "04TFPV2",NOMBREPRODUCTO="Iphone 12 Pro",CATEGORIA="Celulares",MARCA="Iphone",STOCKACTUAL=45,STOCKMINIMO=5,PRECIOBASE=7600, PRECIOVENTA=9954},
                new productos {CODIGOPRODUCTO ="05AUPV3",NOMBREPRODUCTO="Auriculares alambricos genericos",CATEGORIA="Auriculares",MARCA="Generico",STOCKACTUAL=150,STOCKMINIMO=5,PRECIOBASE=200,PRECIOVENTA=250 }
            };
        }
        public void ReducirStock(string productoId, int cantidad)
        {
            var producto = Productos.FirstOrDefault(p => p.CODIGOPRODUCTO == productoId);

            if (producto != null)
            {
                if (producto.STOCKACTUAL >= cantidad)
                {
                    producto.STOCKACTUAL -= cantidad;
                }
                else
                {
                    MessageBox.Show("Stock insuficiente.");
                }
            }
            else
            {
                MessageBox.Show("Producto no encontrado.");
            }
        }
        public void RestaurarStock(string idProducto, int cantidad)
        {
            var producto = Productos.FirstOrDefault(p => p.CODIGOPRODUCTO == idProducto);
            if (producto != null)
            {
                producto.STOCKACTUAL += cantidad;
            }
        }


    }
}
