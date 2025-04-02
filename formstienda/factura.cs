using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace formstienda
{
    public class factura
    {
        private int cantidad;
        private double total;
        private int plazos;
        private double subtotal;
        private string producto;
        private double precio;
        private double cambio;
        private double saldo;
        private double dolar;
        private string idproducto;

        

        public int Cantidad { get => cantidad; set => cantidad = value; }
        public double Total { get => total; set=> total = value; }
        public double Subtotal { get => subtotal; set=> subtotal = value; }
        public double Precio { get => precio; set=> precio = value; }
        public double Cambio { get => cambio; set=> cambio =  value; }
        public double Saldo { get => saldo; set => saldo =value; }
        public double Dolar { get => dolar; set => dolar = value; }
        public string Producto { get => producto; set => producto = value; }
        public string IDPRODUCTO { get=> idproducto; set => idproducto = value; }

        

        public factura(double precio, int cantidad)
        {
            Cantidad = cantidad;
            Precio = precio;
        }

        public double calcularsubtotal(double precio, int cantidad)
        {
            subtotal = 0;
            subtotal = precio * cantidad;
            return Math.Round(subtotal, 2);
        }
        public double CalcularTotal(double total)
        {
            total = 0;
            total = subtotal + total;
            return Math.Round(total, 2);
        }
        public string Descripcion()
        {
            string descripcion = "Prueba de descripcion";
            return descripcion;
        }
        public double CalcularCambio(double saldo, double total)
        {
            cambio = saldo - total;
            return Math.Round(cambio, 2);
        }

        public double CalculoDolar(double SaldoDolar)
        {
            dolar = 36.35;
            saldo = SaldoDolar * dolar;
            return Math.Round(saldo, 2);    
        }
        // ingresar un acumulador de totales, cambiar las opciones de cambio, adaptar el form compras al de guillermo, nuevo form proveedores, tab page de credito en venta, monto para abrir caja y ingresar tasa de cambio.si me sobra tiempo meter las validaciones.
    }
}
