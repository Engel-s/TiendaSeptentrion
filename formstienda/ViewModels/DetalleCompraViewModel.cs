using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace formstienda.ViewModels
{
    public class DetalleCompraViewModel : INotifyPropertyChanged
    {

        private int _idDetalleCompra;
        private int _idCompra;
        private int _numeroFactura;
        private DateTime _fechaCompra;
        private string _nombreProveedor;
        private string _rucProveedor;
        private string _codigoProducto;
        private string _nombreProducto;
        private string _ApellidoProveedor;
        private int _cantidadCompra;
        private float _precioCompra;
        private string _nombremarca;
        private string _nombrecategoria;
        private double _totalCompra;

        public string NombreCompleto => $"{NombreProveedor} {ApellidoProveedor}";

        // Propiedad calculada para el subtotal
        public double SubtotalCompra => CantidadCompra * PrecioCompra;

        // Propiedad formateada para mostrar en la UI
        [DisplayName("Subtotal")]
        public string SubtotalFormateado => SubtotalCompra.ToString("C", new CultureInfo("es-NI"));


        public string NombreMarca
        {
            get => _nombremarca;
            set { _nombremarca = value; OnPropertyChanged(); }
        }

        public string NombreCategoria
        {
            get => _nombrecategoria;
            set { _nombrecategoria = value; OnPropertyChanged(); }
        }

        public int IdDetalleCompra
        {
            get => _idDetalleCompra;
            set { _idDetalleCompra = value; OnPropertyChanged(); }
        }

        public int IdCompra
        {
            get => _idCompra;
            set { _idCompra = value; OnPropertyChanged(); }
        }

        public int NumeroFactura
        {
            get => _numeroFactura;
            set { _numeroFactura = value; OnPropertyChanged(); }
        }

        public DateTime FechaCompra
        {
            get => _fechaCompra;
            set { _fechaCompra = value; OnPropertyChanged(); }
        }

        public string NombreProveedor
        {
            get => _nombreProveedor;
            set { _nombreProveedor = value; OnPropertyChanged(); }
        }

        public string ApellidoProveedor
        {
            get => _ApellidoProveedor;
            set { _ApellidoProveedor = value; OnPropertyChanged(); }
        }

        public string RucProveedor
        {
            get => _rucProveedor;
            set { _rucProveedor = value; OnPropertyChanged(); }
        }

        public string CodigoProducto
        {
            get => _codigoProducto;
            set { _codigoProducto = value; OnPropertyChanged(); }
        }

        public string NombreProducto
        {
            get => _nombreProducto;
            set { _nombreProducto = value; OnPropertyChanged(); }
        }

        public int CantidadCompra
        {
            get => _cantidadCompra;
            set
            {
                _cantidadCompra = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(SubtotalCompra));
                OnPropertyChanged(nameof(SubtotalFormateado));
            }
        }

        public float PrecioCompra
        {
            get => _precioCompra;
            set
            {
                _precioCompra = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(SubtotalCompra));
                OnPropertyChanged(nameof(SubtotalFormateado));
            }
        }
        [DisplayName("Precio de compra")]
        public string PrecioCompraFormateado => PrecioCompra.ToString("C", new CultureInfo("es-NI"));


        public double TotalCompra
        {
            get => _totalCompra;
            set { _totalCompra = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
