using formstienda.capa_de_negocios;
using formstienda.Datos;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static formstienda.Login;
using formstienda.capa_de_presentación;



namespace formstienda
{

    public partial class Factura : Form
    {
        private ProductoServicio productoServicio;
        private UsuarioServicio usuarioServicio;
        private ClienteServicio clienteServicio;
        private AperturaServicio aperturaServicio;
        private BindingList<Producto> Listaproducto;
        private VentaServicio VentaServicio;
        private BindingList<DetalleDeVentum> Listaventa;
        private TasaServicio tasaServicio;
        private int NUEVOIDVENTAREGISTRO;
        public int STOCKACTUALPRODUCTO;


        private BindingList<Cliente>? Listacliente;

        public Factura()
        {
            InitializeComponent();
            productoServicio = new ProductoServicio();
            usuarioServicio = new UsuarioServicio();
            clienteServicio = new ClienteServicio();
            aperturaServicio = new AperturaServicio();

        }
        private void CargarCombos(List<Producto> productos)
        {
            CBcategorias.SelectedIndexChanged -= ComboBox_Changed;
            CBmarcas.SelectedIndexChanged -= ComboBox_Changed;
            CBproductos.SelectedIndexChanged -= ComboBox_Changed;

            CBcategorias.DataSource = productos
                .Select(p => p.IdCategoriaNavigation.Categoria)
                .Distinct()
                .OrderBy(c => c)
                .ToList();

            CBmarcas.DataSource = null;
            CBproductos.DataSource = null;

            CBcategorias.SelectedIndex = -1;
            CBmarcas.SelectedIndex = -1;
            CBproductos.SelectedIndex = -1;

            CBcategorias.SelectedIndexChanged += ComboBox_Changed;
            CBmarcas.SelectedIndexChanged += ComboBox_Changed;
            CBproductos.SelectedIndexChanged += ComboBox_Changed;
        }

        private void ComboBox_Changed(object sender, EventArgs e)
        {
            string categoria = CBcategorias.SelectedItem?.ToString();
            string marca = CBmarcas.SelectedItem?.ToString();

            // Filtrar marcas al seleccionar categoría
            if (sender == CBcategorias && !string.IsNullOrEmpty(categoria))
            {
                var marcasFiltradas = Listaproducto
                    .Where(p => p.IdCategoriaNavigation.Categoria == categoria)
                    .Select(p => p.IdMarcaNavigation.Marca1)
                    .Distinct()
                    .OrderBy(m => m)
                    .ToList();

                CBmarcas.SelectedIndexChanged -= ComboBox_Changed;
                CBmarcas.DataSource = marcasFiltradas;
                CBmarcas.SelectedIndex = -1;
                CBmarcas.SelectedIndexChanged += ComboBox_Changed;

                // Limpiar combos dependientes
                CBproductos.DataSource = null;
                CBproductos.SelectedIndex = -1;
                LimpiarDetalleProducto();
            }
            // Filtrar productos al seleccionar marca (y categoría ya seleccionada)
            else if (sender == CBmarcas && !string.IsNullOrEmpty(categoria) && !string.IsNullOrEmpty(marca))
            {
                var productosFiltrados = Listaproducto
                    .Where(p => p.IdCategoriaNavigation.Categoria == categoria && p.IdMarcaNavigation.Marca1 == marca)
                    .Select(p => p.ModeloProducto)
                    .Distinct()
                    .OrderBy(p => p)
                    .ToList();

                CBproductos.SelectedIndexChanged -= ComboBox_Changed;
                CBproductos.DataSource = productosFiltrados;
                CBproductos.SelectedIndex = -1;
                CBproductos.SelectedIndexChanged += ComboBox_Changed;

                LimpiarDetalleProducto();
            }
            // Al seleccionar producto, mostrar sus detalles
            else if (sender == CBproductos && !string.IsNullOrEmpty(categoria) && !string.IsNullOrEmpty(marca))
            {
                var modelo = CBproductos.SelectedItem?.ToString();
                var prod = Listaproducto.FirstOrDefault(p => p.IdCategoriaNavigation.Categoria == categoria &&
                                                             p.IdMarcaNavigation.Marca1 == marca &&
                                                             p.ModeloProducto == modelo);

                if (prod != null)
                {
                    txtprecio.Text = prod.PrecioVenta.ToString("C", new CultureInfo("es-NI"));
                    txtmarca.Text = prod.IdMarcaNavigation.Marca1;
                    txtcategoria.Text = prod.IdCategoriaNavigation.Categoria;
                    txtproducto.Text = prod.ModeloProducto;
                    txtcodigoproducto.Text = prod.CodigoProducto;
                    txtstock.Text = prod.StockActual.ToString();
                    txtcantidad.Text = "1";

                    productoSeleccionadoTemporal = new ProductoSeleccionado
                    {
                        CodigoProducto = prod.CodigoProducto,
                        ModeloProducto = prod.ModeloProducto,
                        Marca = prod.IdMarcaNavigation.Marca1,
                        Categoria = prod.IdCategoriaNavigation.Categoria,
                        PrecioVenta = prod.PrecioVenta,
                        stockactualproducto = (int)prod.StockActual
                    };
                }
            }
            else
            {
                LimpiarDetalleProducto();
            }
        }

        private void LimpiarDetalleProducto()
        {
            txtprecio.Clear();
            txtcantidad.Clear();
            txtmarca.Clear();
            txtcategoria.Clear();
            txtproducto.Clear();
            txtstock.Clear();
            txtcodigoproducto.Clear();
            productoSeleccionadoTemporal = null;
        }
        public class ProductoSeleccionado
        {
            public string CodigoProducto { get; set; }
            public string ModeloProducto { get; set; }
            public string Marca { get; set; }
            public string Categoria { get; set; }
            public double PrecioVenta { get; set; }
            public int Cantidad { get; set; }
            public double Subtotal => PrecioVenta * Cantidad;  // Calcular el subtotal
            public int stockactualproducto;

        }

        private ProductoSeleccionado productoSeleccionadoTemporal = null;




        private void ActualizarCombo(System.Windows.Forms.ComboBox combo, List<string> datosFiltrados, string valorSeleccionado)
        {
            // Obtener todas las opciones posibles según el ComboBox
            var todos = combo == CBproductos
                ? Listaproducto.Select(p => p.ModeloProducto).Distinct()
                : combo == CBcategorias
                    ? Listaproducto.Select(p => p.IdCategoriaNavigation.Categoria).Distinct()
                    : Listaproducto.Select(p => p.IdMarcaNavigation.Marca1).Distinct();

            // Ordenar: primero los filtrados (en el orden original), luego los restantes (ordenados)
            var noFiltrados = todos.Except(datosFiltrados).OrderBy(x => x);
            var final = datosFiltrados.Concat(noFiltrados).ToList();

            // Evitar refrescos innecesarios
            combo.DataSource = null;
            combo.DataSource = final;

            // Restaurar selección si es válida
            if (!string.IsNullOrEmpty(valorSeleccionado) && final.Contains(valorSeleccionado))
                combo.SelectedItem = valorSeleccionado;
            else
                combo.SelectedIndex = -1;
        }



        public void ActivarDatosFactura()
        {
            txtnombrecliente.Enabled = true;

            txtcantidad.Enabled = true;
            txtprecio.Enabled = true;
        }
        public void LimpiarFactura()
        {
            txtnombrecliente.Clear();

            txtcantidad.Clear();
            txtprecio.Clear();

            txtpago.Clear();
            txtfaltante.Clear();

            txtcambio.Clear();
            dgmostrar.Rows.Clear();

        }
        public void LimpiarControles()
        {
            txtcantidad.Text = "";
            txtprecio.Text = "";
        }




        private void Factura_Load(object sender, EventArgs e)
        {
            productoServicio = new ProductoServicio(); // ya lo haces
            VentaServicio = new VentaServicio();
            Listaventa = new BindingList<DetalleDeVentum>(); // simplemente iniciar la lista vacía
            ClienteServicio clienteServicio = new ClienteServicio();

            tasaServicio = new TasaServicio();
            var productos = productoServicio.ListarProductos();
            Listaproducto = new BindingList<Producto>(productos);

            if (Listaproducto.Count > 0)
            {
                CargarCombos(productos);
            }
            txtpago.KeyUp += txtpago_KeyUp;
            txtfaltante.KeyUp += txtfaltante_KeyUp;
            txtpago.KeyDown += txtpago_KeyDown;
            txtfaltante.KeyDown += txtfaltante_KeyDown;
            CargarNumeroFactura();
            rbcontado.Checked = true;

            ocultarderegistro();




        }

        private void facturafecha_Tick(object sender, EventArgs e)
        {

        }



        private void button4_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btneditar_Click(object sender, EventArgs e)
        {

            LimpiarControles();

        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cedulaClienteActual))
            {
                MessageBox.Show("Primero debe buscar un cliente.");
                return;
            }

            if (dgmostrar.Rows.Count == 0 || (dgmostrar.Rows.Count == 1 && dgmostrar.Rows[0].IsNewRow))
            {
                MessageBox.Show("Debe agregar al menos un producto a la factura.");
                return;
            }

            var tasa = tasaServicio.ObtenerTasaDeHoy();
            if (tasa == null)
            {
                var resultado = MessageBox.Show(
                    "No hay una tasa de cambio registrada para hoy. ¿Desea aperturar ahora?",
                    "Tasa de cambio faltante",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (resultado == DialogResult.Yes)
                {
                    Apertura_Caja apertura = new Apertura_Caja();
                    apertura.Show();



                    // Intentar cargar nuevamente la tasa después de que se haya cerrado el formulario
                    tasa = tasaServicio.ObtenerTasaDeHoy();

                    if (tasa == null)
                    {
                        MessageBox.Show("No se registró una tasa de cambio. No se puede continuar.", "Proceso cancelado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    return; // El usuario no quiso aperturar, cancelamos proceso
                }
            }

            if (!float.TryParse(txtpago.Text, out float pagoCordobas) || pagoCordobas < 0)
            {
                MessageBox.Show("El pago en córdobas debe ser un número positivo válido.");
                return;
            }

            float pagoDolares = 0f;  // declarar antes

            if (!string.IsNullOrWhiteSpace(txtfaltante.Text))
            {
                if (!float.TryParse(txtfaltante.Text, out pagoDolares) || pagoDolares < 0)
                {
                    MessageBox.Show("El pago en dólares debe ser un número válido mayor o igual a 0.");
                    return;
                }
            }

            // Ahora puedes usar pagoDolares sin problemas
            float valorTasa = (float)tasa.ValorCambio;
            float totalPagado = pagoCordobas + (pagoDolares * valorTasa);


            float totalVenta = float.TryParse(txttotal.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out float total) ? total : 0f;

            if (ObtenerTipoPagoSeleccionado() == "Contado" && totalPagado < totalVenta)
            {
                MessageBox.Show("El monto pagado es insuficiente. No se puede registrar la venta.");
                return;
            }
            string cambioTexto = txtcambio.Text.Replace("C$", "").Trim();

            float cambio = float.TryParse(cambioTexto, NumberStyles.Any, CultureInfo.CurrentCulture, out float valorCambio)
                ? valorCambio
                : 0f;


            var venta = new Ventum
            {
                IdVenta = NUEVOIDVENTAREGISTRO,
                CedulaCliente = cedulaClienteActual,
                FechaVenta = DateOnly.FromDateTime(DateTime.Now),
                TipoPago = ObtenerTipoPagoSeleccionado(),
                PagoCordobas = pagoCordobas,
                PagoDolares = pagoDolares,
                CambioVenta = cambio,
                TotalVenta = totalVenta
            };


            var detalles = new List<DetalleDeVentum>();
            foreach (DataGridViewRow row in dgmostrar.Rows)
            {
                if (row.IsNewRow) continue;

                string codProd = row.Cells["CodigoProducto"].Value?.ToString();
                var producto = Listaproducto.FirstOrDefault(p => p.CodigoProducto == codProd);
                if (producto == null) continue;

                int cantidadVendida = Convert.ToInt32(row.Cells["Cantidad"].Value);

                var detalle = new DetalleDeVentum
                {
                    IdVenta = NUEVOIDVENTAREGISTRO,
                    CodigoProducto = producto.CodigoProducto,
                    Cantidad = cantidadVendida,
                    Precio = row.Cells["Precio"].Value?.ToString() ?? producto.PrecioVenta.ToString("N2"),
                    CedulaCliente = cedulaClienteActual,
                    SubTotal = cantidadVendida * producto.PrecioVenta,
                };

                producto.StockActual -= cantidadVendida;
                detalles.Add(detalle);
            }

            if (venta.TipoPago == "Crédito")
            {
                if (!float.TryParse(txtinteresparaloscreditos.Text, out float interesMensual))
                {
                    MessageBox.Show("Ingrese un interés mensual válido en formato numérico (ej. 2.5).");
                    return;
                }

                if (interesMensual <= 0)
                {
                    MessageBox.Show("El interés mensual debe ser mayor que 0%.");
                    return;
                }

                if (interesMensual > 40)
                {
                    MessageBox.Show("El interés mensual no puede ser mayor a 40%. Verifique el valor ingresado.");
                    return;
                }

                if (txtinteresparaloscreditos.Text.Contains(","))
                {
                    MessageBox.Show("Use punto (.) como separador decimal, no coma (,).");
                    return;
                }

                if (cbnumerodeplazos.SelectedIndex == -1)
                {
                    MessageBox.Show("Seleccione un plazo para el crédito.");
                    return;
                }

                string plazoTexto = cbnumerodeplazos.SelectedItem.ToString(); // Ej. "3 MESES"
                int plazosMeses = int.Parse(plazoTexto.Split(' ')[0]);

                DateOnly fechaInicio = DateOnly.FromDateTime(DateTime.Now);
                DateOnly fechaFinal = fechaInicio.AddMonths(plazosMeses);

                var detalleCreditos = new List<DetalleCredito>();
                float saldoRestante = totalVenta;
                float tasaDecimal = interesMensual / 100f;
                float cuotaBase = totalVenta / plazosMeses;
                float montoTotalCredito = 0;

                for (int i = 1; i <= plazosMeses; i++)
                {
                    float interes = saldoRestante * tasaDecimal;
                    float cuotaTotal = cuotaBase + interes;
                    float abonoCapital = cuotaBase;
                    DateTime fechaPago = DateTime.Now.AddMonths(i);

                    detalleCreditos.Add(new DetalleCredito
                    {
                        NumeroCuota = i,
                        FechaPago = fechaPago,
                        ValorCuota = cuotaTotal,
                        AbonoCapital = abonoCapital,
                        InteresPagado = interes,
                        TotalCordobas = 0,
                        TotalDolares = 0,
                        CambioDevuelto = 0,
                        Observaciones = "Pendiente de pago",
                        UsuarioRegistro = UsuarioActivo.ObtenerUsuarioLogueo() // usa la variable real del usuario logueado
                    });

                    saldoRestante -= abonoCapital;
                    montoTotalCredito += cuotaTotal;
                }

                var facturaCredito = new FacturaCredito
                {
                    EstadoCredito = "Activo",
                    TotalAbonado = 0,
                    NuevoSaldo = montoTotalCredito,
                    Observaciones = "Sin Observaciones",
                    PlazosMeses = plazosMeses,
                    FechaInicio = fechaInicio,
                    FechaFinal = fechaFinal,
                    MontoCredito = montoTotalCredito,
                    InteresMensual = interesMensual,
                    UsuarioRegistro = UsuarioActivo.ObtenerUsuarioLogueo(),
                    FechaCreacion = DateTime.Now
                };

                if (VentaServicio.AgregarVentaConDetallesYCredito(venta, detalles, facturaCredito, detalleCreditos))
                {
                    MessageBox.Show("Venta al crédito guardada correctamente.");
                    LimpiarFormulario();
                    cedulaClienteActual = string.Empty;
                    CargarNumeroFactura();
                }
                else
                {
                    MessageBox.Show("Error al guardar la venta con crédito.");
                }

                return; // Salimos para no repetir el guardado
            }

            // 🔹 Si es venta al CONTADO
            if (VentaServicio.AgregarVentaConDetalles(venta, detalles))
            {
                MessageBox.Show("Venta guardada correctamente.");
                LimpiarFormulario();
                cedulaClienteActual = string.Empty;
                CargarNumeroFactura();
            }
            else
            {
                MessageBox.Show("Error al guardar la venta.");
            }
            using (var context = new DbTiendaSeptentrionContext())
            {
                DateOnly hoy = DateOnly.FromDateTime(DateTime.Today);

                var arqueoDeHoy = context.ArqueoCajas
                    .FirstOrDefault(a => a.FechaArqueo.Date == hoy.ToDateTime(TimeOnly.MinValue).Date);

                if (arqueoDeHoy != null)
                {
                    arqueoDeHoy.TotalEfectivoCordoba += venta.PagoCordobas.GetValueOrDefault();
                    arqueoDeHoy.TotalEfectivoDolar += venta.PagoDolares.GetValueOrDefault();


                    context.SaveChanges();
                }
                else
                {
                    MessageBox.Show("⚠️ No hay arqueo registrado para hoy. No se puede actualizar el arqueo de caja.");
                }
            }


        }

        private void ValidarEntradaNumerica(object sender, KeyPressEventArgs e)
        {
            TextBox txt = sender as TextBox;

            if (char.IsControl(e.KeyChar)) return;

            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
                return;
            }

            // No más de un punto
            if (e.KeyChar == '.' && txt.Text.Contains("."))
            {
                e.Handled = true;
                return;
            }

            // Máximo dos decimales
            if (txt.Text.Contains("."))
            {
                int index = txt.Text.IndexOf(".");
                string decimales = txt.Text.Substring(index + 1);
                if (txt.SelectionStart > index && decimales.Length >= 2)
                {
                    e.Handled = true;
                }
            }

            // Límite de longitud total (por ejemplo 10 caracteres)
            if (txt.Text.Length >= 10 && !txt.SelectedText.Any())
            {
                e.Handled = true;
            }
        }


        private void dgmostrar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void AgregarAlDataGridView(ProductoSeleccionado producto)
        {
            foreach (DataGridViewRow fila in dgmostrar.Rows)
            {
                if (fila.Cells[0].Value != null && fila.Cells[0].Value.ToString() == producto.CodigoProducto)
                {
                    // Sumar cantidades
                    int cantidadExistente = Convert.ToInt32(fila.Cells[5].Value); // columna de cantidad
                    int nuevaCantidad = cantidadExistente + producto.Cantidad;
                    fila.Cells[5].Value = nuevaCantidad;

                    // Recalcular subtotal
                    decimal precio = Convert.ToDecimal(fila.Cells[4].Value); // columna de precio
                    fila.Cells[6].Value = precio * nuevaCantidad;

                    // Salir porque ya se actualizó la fila existente
                    ActualizarTotal();
                    return;
                }
            }

            // Si no existe, agregar nueva fila
            dgmostrar.Rows.Add(producto.CodigoProducto, producto.ModeloProducto, producto.Marca, producto.Categoria, producto.PrecioVenta, producto.Cantidad, producto.Subtotal);

            // Actualizar total general
            ActualizarTotal();
        }

        private void ActualizarTotal()
        {
            double total = 0;

            // Sumar los subtotales de todas las filas
            foreach (DataGridViewRow row in dgmostrar.Rows)
            {
                if (row.Cells["Subtotal"].Value != null && double.TryParse(row.Cells["Subtotal"].Value.ToString(), out double subtotal))
                {
                    total += subtotal;
                }
            }

            txttotal.Text = total.ToString("N2"); // Ejemplo: 1,234.56
        }


        private void btnagregar_Click(object sender, EventArgs e)
        {
            if (productoSeleccionadoTemporal != null)
            {
                if (!int.TryParse(txtcantidad.Text, out int cantidadIngresada) || cantidadIngresada <= 0)
                {
                    MessageBox.Show("Ingrese una cantidad válida.");
                    return;
                }

                if (cantidadIngresada > productoSeleccionadoTemporal.stockactualproducto)
                {
                    MessageBox.Show($"Stock insuficiente para {productoSeleccionadoTemporal.ModeloProducto}. Disponible: {productoSeleccionadoTemporal.stockactualproducto}");
                    return;
                }

                // Restar stock en la lista original
                var productoOriginal = Listaproducto.FirstOrDefault(p => p.CodigoProducto == productoSeleccionadoTemporal.CodigoProducto);
                if (productoOriginal != null)
                {
                    productoOriginal.StockActual -= cantidadIngresada;
                    productoSeleccionadoTemporal.stockactualproducto = (int)productoOriginal.StockActual;
                }

                productoSeleccionadoTemporal.Cantidad = cantidadIngresada;

                AgregarAlDataGridView(productoSeleccionadoTemporal);

                productoSeleccionadoTemporal = null;

                LimpiarCampos();

                // Actualiza combos y muestra stock actualizado
                CargarCombos(Listaproducto.ToList());
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un producto antes de agregar.");
            }
        }
        private void LimpiarCampos()
        {
            txtprecio.Clear();
            txtcantidad.Clear();
            txtmarca.Clear();
            txtcategoria.Clear();
            txtproducto.Clear();
            txtstock.Clear();
            txtcodigoproducto.Clear();
        }


        private void LimpiarFormulario()
        {
            LimpiarFactura();         // Limpia los controles de factura
            LimpiarCampos();          // Limpia los campos de producto
            productoSeleccionadoTemporal = null; // Quitar selección
            CBproductos.SelectedIndex = -1;
            CBcategorias.SelectedIndex = -1;
            CBmarcas.SelectedIndex = -1;
            txttotal.Clear();
            txtcambio.Clear();
            txtpago.Clear();
            txtfaltante.Clear();
            txtcedula.Clear();
            txtnombrecliente.Clear();
            txtbuscarcliente.Clear();
            CBBUSCARPOR.SelectedIndex = -1;
            cbnumerodeplazos.SelectedIndex = -1;
            txtinteresparaloscreditos.Clear();
            txtcolillainss.Clear();
            LimpiarCamposCliente();


        }

        private string cedulaClienteActual = string.Empty;

        private void CargarNumeroFactura()
        {
            int nuevoIdVenta = VentaServicio.ObtenerUltimoIdVenta() + 1;
            NUEVOIDVENTAREGISTRO = nuevoIdVenta;
            txtnumerofactura.Text = nuevoIdVenta.ToString();
        }



        private void BuscarCliente()
        {
            string criterio = txtbuscarcliente.Text.Trim();
            string tipoBusqueda = CBBUSCARPOR.SelectedItem?.ToString();

            if (GENERICOCHECK.Checked)
            {
                CargarClienteGenerico();
                return;
            }

            using (var _context = new DbTiendaSeptentrionContext())
            {
                List<Cliente> resultados;

                if (tipoBusqueda == "Cédula")
                {
                    resultados = _context.Clientes
                        .Where(c => c.CedulaCliente.Contains(criterio))
                        .ToList();
                }
                else if (tipoBusqueda == "Telefono")
                {
                    resultados = _context.Clientes
                        .Where(c => c.TelefonoCliente.Contains(criterio))
                        .ToList();
                }
                else
                {
                    MessageBox.Show("Seleccione un tipo de búsqueda.");
                    return;
                }

                if (resultados.Count == 0)
                {
                    MessageBox.Show("Cliente no encontrado. Puede agregar al nuevo cliente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                    activarregistro();


                }
                else
                {
                    var cliente = resultados.First();
                    txtnombrecliente.Text = cliente.NombreCliente;
                    txtcedula.Text = cliente.CedulaCliente;
                    cedulaClienteActual = cliente.CedulaCliente;
                    txtnombrecliente.ReadOnly = true;
                    TXTTELEFONODELNUEVOCLIENTE.ReadOnly = true;
                    txtcolillainss.Text = cliente.ColillaInssCliente;
                    ocultarderegistro();


                    // Validación si es sujeto a crédito
                    clienteEsSujetoACredito = cliente.SujetoCredito == true;

                    if (!clienteEsSujetoACredito)
                    {
                        MessageBox.Show("Este cliente no está habilitado para crédito. Se seleccionará 'Contado'.");
                        rbcredito.Checked = false;
                        rbcontado.Checked = true;
                    }

                }
            }
        }
        private bool clienteEsSujetoACredito = false;

        private void CargarClienteGenerico()
        {
            using (var _context = new DbTiendaSeptentrionContext())
            {
                var cliente = _context.Clientes.FirstOrDefault(c => c.CedulaCliente == "Generico");

                if (cliente == null)
                {
                    MessageBox.Show("No se encontró un cliente con cédula 'Generico'.");
                    activarregistro();
                    return;
                }

                txtnombrecliente.Text = cliente.NombreCliente;
                txtcedula.Text = cliente.CedulaCliente;
                cedulaClienteActual = cliente.CedulaCliente;
                clienteEsSujetoACredito = cliente.SujetoCredito == true;
                ocultarderegistro();

                if (!clienteEsSujetoACredito)
                {
                    MessageBox.Show("El cliente genérico no está habilitado para crédito. Se seleccionará 'Contado'.");
                    rbcredito.Checked = false;
                    rbcontado.Checked = true;
                    ocultarderegistro();
                }
            }
        }


        private string ObtenerTipoPagoSeleccionado()
        {
            string tipoPago = rbcontado.Checked ? "Contado" : (rbcredito.Checked ? "Crédito" : "");
            return tipoPago;

        }

        private float CalcularSubtotal()
        {
            float subtotal = 0f;
            foreach (DataGridViewRow row in dgmostrar.Rows)
            {
                if (row.IsNewRow) continue;
                if (float.TryParse(row.Cells["Subtotal"].Value?.ToString(), out float sub))
                {
                    subtotal += sub;
                }
            }
            return subtotal;
        }

        private void txtpago_TextChanged(object sender, EventArgs e)
        {
            CalcularCambio();

        }

        private void txtfaltante_TextChanged(object sender, EventArgs e)
        {
            CalcularCambio();

        }

        private void CalcularCambio()
        {
            // Validar el total de la venta
            if (!float.TryParse(txttotal.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out float totalVenta))
                totalVenta = 0f;

            // Validar los pagos
            float pagoCordobas = float.TryParse(txtpago.Text, out float cordobas) ? cordobas : 0f;
            float pagoDolares = float.TryParse(txtfaltante.Text, out float dolares) ? dolares : 0f;

            // Obtener la tasa del día
            var tasa = tasaServicio.ObtenerTasaDeHoy();
            if (tasa == null)
            {
                var resultado = MessageBox.Show(
                    "No hay una tasa de cambio registrada para hoy. ¿Desea registrarla?",
                    "Tasa no encontrada",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (resultado == DialogResult.Yes)
                {
                    using (var apertura = new Apertura_Caja())
                    {
                        apertura.ShowDialog(); // ShowDialog bloquea hasta que se cierre
                    }

                    tasa = tasaServicio.ObtenerTasaDeHoy();
                }

                if (tasa == null)
                {
                    txtcambio.Text = "C$ 0.00";
                    txtcambio.BackColor = SystemColors.Window;
                    txtcambio.ForeColor = Color.Black;
                    return;
                }
            }

            float tasaActual = tasa.ValorCambio;
            float totalPagado = pagoCordobas + (pagoDolares * tasaActual);
            float cambio = totalPagado - totalVenta;

            // Mostrar el cambio en C$ con 2 decimales
            txtcambio.Text = $"C$ {Math.Abs(cambio):N2}";

            // Color según si alcanza o no
            if (cambio < 0)
            {
                txtcambio.BackColor = Color.MistyRose;
                txtcambio.ForeColor = Color.DarkRed;
            }
            else
            {
                txtcambio.BackColor = Color.Honeydew;
                txtcambio.ForeColor = Color.DarkGreen;
            }
        }


        private void txtpago_KeyUp(object sender, KeyEventArgs e)
        {
            CalcularCambio();


        }

        private void txtfaltante_KeyUp(object sender, KeyEventArgs e)
        {
            CalcularCambio();
        }

        private void txtpago_KeyDown(object sender, KeyEventArgs e)
        {
            CalcularCambio();
        }

        private void txtfaltante_KeyDown(object sender, KeyEventArgs e)
        {
            CalcularCambio();
        }

        private void Busquedacliente_Click(object sender, EventArgs e)
        {
            BuscarCliente();
        }

        private void rbcontado_CheckedChanged(object sender, EventArgs e)
        {
            lblcolillainss.Visible = false;
            txtcolillainss.Visible = false;
            lblinteres.Visible = false;
            txtinteresparaloscreditos.Visible = false;
            cbnumerodeplazos.Visible = false;
            lblnumeroplazos.Visible = false;
            txtpago.Visible = true;
            txtfaltante.Visible = true;
            txtcambio.Visible = true;
            lblcordoba.Visible = true;
            lbldolares.Visible = true;
            lblcambio.Visible = true;
            simbolo3.Visible = true;
            lblsimbolo.Visible = true;
            lblsimbolo2.Visible = true;

        }

        private void rbcredito_CheckedChanged(object sender, EventArgs e)
        {
            lblcolillainss.Visible = true;
            txtcolillainss.Visible = true;
            lblinteres.Visible = true;
            txtinteresparaloscreditos.Visible = true;
            cbnumerodeplazos.Visible = true;
            lblnumeroplazos.Visible = true;
            txtpago.Visible = false;
            txtfaltante.Visible = false;
            txtcambio.Visible = false;
            lblcordoba.Visible = false;
            lbldolares.Visible = false;
            lblcambio.Visible = false;
            simbolo3.Visible = false;
            lblsimbolo.Visible = false;
            lblsimbolo2.Visible = false;
            if (rbcredito.Checked && !clienteEsSujetoACredito)
            {
                MessageBox.Show("Este cliente no está habilitado para crédito.");
                rbcredito.Checked = false;
                rbcontado.Checked = true;
            }
        }

        private void GENERICOCHECK_CheckedChanged(object sender, EventArgs e)
        {
            if (GENERICOCHECK.Checked)
            {
                CargarClienteGenerico();
            }
            else
            {
                LimpiarCamposCliente();
            }
        }
        private void LimpiarCamposCliente()
        {
            txtnombrecliente.Clear();
            txtcedula.Clear();
            cedulaClienteActual = string.Empty;
            TXTTELEFONODELNUEVOCLIENTE.Clear();
            GENERICOCHECK.Checked = false;
        }

        private void txtpago_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            
        }

        private void txtfaltante_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        public void ocultarderegistro()
        {
            txtdireccion.Visible = false;
            TXTTELEFONODELNUEVOCLIENTE.Visible = false;
            btnagregarnuevocliente.Visible = false;

            txtnombrecliente.ReadOnly = true;
            TXTTELEFONODELNUEVOCLIENTE.ReadOnly = true;
            txtcedula.ReadOnly = true;

            lbldireccion.Visible = false;
            LBLTELEFONODELNUEVOCLIENTE.Visible = false;
        }
        public void activarregistro()
        {
            lbldireccion.Visible = true;
            LBLTELEFONODELNUEVOCLIENTE.Visible = true;
            txtdireccion.Visible = true;
            TXTTELEFONODELNUEVOCLIENTE.Visible = true;
            btnagregarnuevocliente.Visible = true;
            txtnombrecliente.ReadOnly = false;
            TXTTELEFONODELNUEVOCLIENTE.ReadOnly = false;
            txtcedula.ReadOnly = false;
            btnagregarnuevocliente.Enabled = true;
            txtdireccion.ReadOnly = false;


        }
        private void btnagregarnuevocliente_Click(object sender, EventArgs e)
        {
            var cliente = new Cliente
            {
                NombreCliente = txtnombrecliente.Text.Trim(),
                ApellidoCliente = "Generico",
                DireccionCliente = txtdireccion.Text.Trim(),
                CedulaCliente = txtcedula.Text.Trim(),
                ColillaInssCliente = txtcolillainss.Text.Trim(),
                SujetoCredito = false,
                TelefonoCliente = new string(TXTTELEFONODELNUEVOCLIENTE.Text.Trim().Where(char.IsDigit).ToArray())
            };

            // Validar campos obligatorios
            if (string.IsNullOrWhiteSpace(cliente.NombreCliente) ||
                string.IsNullOrWhiteSpace(cliente.CedulaCliente) ||
                string.IsNullOrWhiteSpace(cliente.TelefonoCliente))
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios.");
                return;
            }

            // Validar formato del teléfono (solo números, 8-15 dígitos)
            if (!Regex.IsMatch(cliente.TelefonoCliente, @"^\d{8}$"))
            {
                MessageBox.Show("Ingrese un número de teléfono válido (solo dígitos, entre 8 y 15).");
                return;
            }

            // Validar formato de cédula: 11 dígitos seguidos de una letra (ej. 441160505100W)
            if (!Regex.IsMatch(cliente.CedulaCliente, @"^\d{13}[A-Za-z]$"))
            {
                MessageBox.Show("La cédula debe tener 13 dígitos seguidos de una letra. Ejemplo: 4412020122000W.");
                return;
            }

            // Validar formato de colilla INSS: exactamente 8 dígitos
            if (!Regex.IsMatch(cliente.ColillaInssCliente, @"^\d{8}$"))
            {
                MessageBox.Show("El número de colilla INSS debe tener exactamente 8 dígitos.");
                return;
            }

            // Verificar si ya existe cliente con ese teléfono o cédula
            var clienteExistente = clienteServicio?.Listaclientes()
                                                   .FirstOrDefault(p => p.TelefonoCliente == cliente.TelefonoCliente ||
                                                                        p.CedulaCliente == cliente.CedulaCliente);
            if (clienteExistente != null)
            {
                MessageBox.Show("Este cliente ya existe. Ingrese otro teléfono o cédula.");
                return;
            }


            // Agregar cliente
            clienteServicio?.Agregarcliente(cliente);
            Listacliente?.Add(cliente);
            MessageBox.Show("Cliente agregado correctamente");
            LimpiarCamposCliente();

            ocultarderegistro();

        }

        private void btnnuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            LimpiarCamposCliente();
            LimpiarFormulario();

        }

        private void btnnuevo_Click_1(object sender, EventArgs e)
        {
            LimpiarCampos();
            LimpiarCamposCliente();
            LimpiarFormulario();
        }

        private void dgmostrar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgmostrar.Columns[e.ColumnIndex].Name == "eliminar")
            {
                var confirm = MessageBox.Show("¿Está seguro de eliminar esta fila?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    dgmostrar.Rows.RemoveAt(e.RowIndex);
                    ActualizarTotal(); // Recalcula el total
                }
            }
        }

        private void dgmostrar_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((e.ColumnIndex == 4 || e.ColumnIndex == 6) && e.Value != null)
            {
                if (decimal.TryParse(e.Value.ToString(), out decimal valor))
                {
                    e.Value = "C$" + valor.ToString("N2");
                    e.FormattingApplied = true;
                }
            }
        }

        private void txtinteresparaloscreditos_TextChanged(object sender, EventArgs e)
        {

        }
    }

}


