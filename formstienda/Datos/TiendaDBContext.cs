using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace formstienda.Datos;

public partial class TiendaDBContext : DbContext
{
    public TiendaDBContext()
    {
    }

    public TiendaDBContext(DbContextOptions<TiendaDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AperturaCaja> AperturaCajas { get; set; }

    public virtual DbSet<ArqueoCaja> ArqueoCajas { get; set; }

    public virtual DbSet<Categorium> Categoria { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Compra> Compras { get; set; }

    public virtual DbSet<DetalleDeVentum> DetalleDeVenta { get; set; }

    public virtual DbSet<Devolucion> Devolucions { get; set; }

    public virtual DbSet<Egreso> Egresos { get; set; }

    public virtual DbSet<Inventario> Inventarios { get; set; }

    public virtual DbSet<Marca> Marcas { get; set; }

    public virtual DbSet<PagoDeCredito> PagoDeCreditos { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Proveedor> Proveedors { get; set; }

    public virtual DbSet<TasaDeCambio> TasaDeCambios { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Ventum> Venta { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DEngels;Database=DB_Tienda_Septentrion;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AperturaCaja>(entity =>
        {
            entity.HasKey(e => e.IdApertura)
                .HasName("PK12")
                .IsClustered(false);

            entity.ToTable("Apertura caja");

            entity.Property(e => e.IdApertura).HasColumnName("Id_Apertura");
            entity.Property(e => e.EstadoApertura)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Estado_Apertura");
            entity.Property(e => e.FechaApertura).HasColumnName("Fecha_Apertura");
            entity.Property(e => e.HoraApertura)
                .HasColumnType("datetime")
                .HasColumnName("Hora_Apertura");
            entity.Property(e => e.MontoApertura).HasColumnName("Monto_Apertura");
        });

        modelBuilder.Entity<ArqueoCaja>(entity =>
        {
            entity.HasKey(e => new { e.IdUsuario, e.IdApertura })
                .HasName("PK13")
                .IsClustered(false);

            entity.ToTable("Arqueo caja");

            entity.Property(e => e.IdUsuario).HasColumnName("Id_usuario");
            entity.Property(e => e.IdApertura).HasColumnName("Id_Apertura");
            entity.Property(e => e.FaltanteCordoba).HasColumnName("Faltante_Cordoba");
            entity.Property(e => e.FaltanteDolar).HasColumnName("Faltante_Dolar");
            entity.Property(e => e.SobranteCordoba).HasColumnName("Sobrante_Cordoba");
            entity.Property(e => e.SobranteDolar).HasColumnName("Sobrante_Dolar");
            entity.Property(e => e.TotalEfectivoCordoba).HasColumnName("Total_Efectivo_Cordoba");
            entity.Property(e => e.TotalEfectivoDolar).HasColumnName("Total_Efectivo_Dolar");

            entity.HasOne(d => d.IdAperturaNavigation).WithMany(p => p.ArqueoCajas)
                .HasForeignKey(d => d.IdApertura)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("RefApertura_caja11");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.ArqueoCajas)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("RefUsuario9");
        });

        modelBuilder.Entity<Categorium>(entity =>
        {
            entity.HasKey(e => e.IdCategoria)
                .HasName("PK5")
                .IsClustered(false);

            entity.Property(e => e.IdCategoria).HasColumnName("Id_Categoria");
            entity.Property(e => e.Categoria)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente)
                .HasName("PK2")
                .IsClustered(false);

            entity.ToTable("Cliente");

            entity.Property(e => e.IdCliente).HasColumnName("Id_cliente");
            entity.Property(e => e.ApellidoCliente)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("Apellido_Cliente");
            entity.Property(e => e.CedulaCliente)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Cedula_Cliente");
            entity.Property(e => e.ColillaInssCliente)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Colilla_INSS_Cliente");
            entity.Property(e => e.DireccionCliente)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("Direccion_Cliente");
            entity.Property(e => e.NombreCliente)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("Nombre_Cliente");
            entity.Property(e => e.SujetoCredito).HasColumnName("Sujeto_Credito");
            entity.Property(e => e.TelefonoCliente)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("Telefono_Cliente");
        });

        modelBuilder.Entity<Compra>(entity =>
        {
            entity.HasKey(e => new { e.IdCompra, e.IdProveedor, e.IdProducto, e.IdCategoria, e.IdMarca })
                .HasName("PK7")
                .IsClustered(false);

            entity.ToTable("Compra");

            entity.Property(e => e.IdCompra)
                .ValueGeneratedOnAdd()
                .HasColumnName("Id_Compra");
            entity.Property(e => e.IdProveedor).HasColumnName("Id_Proveedor");
            entity.Property(e => e.IdProducto).HasColumnName("Id_Producto");
            entity.Property(e => e.IdCategoria).HasColumnName("Id_Categoria");
            entity.Property(e => e.IdMarca).HasColumnName("Id_Marca");
            entity.Property(e => e.CantidadCompra).HasColumnName("Cantidad_compra");
            entity.Property(e => e.FechaCompra).HasColumnName("Fecha_Compra");
            entity.Property(e => e.NoFacturaCompra).HasColumnName("No_Factura_Compra");
            entity.Property(e => e.PrecioCompra).HasColumnName("Precio_Compra");
        });

        modelBuilder.Entity<DetalleDeVentum>(entity =>
        {
            entity.HasKey(e => new { e.IdFactura, e.IdProducto, e.IdCategoria, e.IdMarca, e.IdCliente, e.IdVenta })
                .HasName("PK8")
                .IsClustered(false);

            entity.ToTable("Detalle_De_Venta");

            entity.Property(e => e.IdFactura)
                .ValueGeneratedOnAdd()
                .HasColumnName("Id_Factura");
            entity.Property(e => e.IdProducto).HasColumnName("Id_Producto");
            entity.Property(e => e.IdCategoria).HasColumnName("Id_Categoria");
            entity.Property(e => e.IdMarca).HasColumnName("Id_Marca");
            entity.Property(e => e.IdCliente).HasColumnName("Id_cliente");
            entity.Property(e => e.IdVenta).HasColumnName("Id_Venta");
            entity.Property(e => e.CambioVenta).HasColumnName("Cambio_Venta");
            entity.Property(e => e.FormaDePago).HasColumnName("Forma_de_pago");
            entity.Property(e => e.PagoCordoba).HasColumnName("Pago_cordoba");
            entity.Property(e => e.PagoDolar).HasColumnName("Pago_Dolar");
            entity.Property(e => e.TotalPago).HasColumnName("Total_pago");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.DetalleDeVenta)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("RefCliente8");

            entity.HasOne(d => d.IdVentaNavigation).WithMany(p => p.DetalleDeVenta)
                .HasForeignKey(d => d.IdVenta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("RefVenta19");
        });

        modelBuilder.Entity<Devolucion>(entity =>
        {
            entity.HasKey(e => new { e.IdDevolucion, e.IdFactura, e.IdProducto, e.IdCategoria, e.IdMarca, e.IdCliente, e.IdVenta })
                .HasName("PK10")
                .IsClustered(false);

            entity.ToTable("Devolucion");

            entity.Property(e => e.IdDevolucion)
                .ValueGeneratedOnAdd()
                .HasColumnName("Id_Devolucion");
            entity.Property(e => e.IdFactura).HasColumnName("Id_Factura");
            entity.Property(e => e.IdProducto).HasColumnName("Id_Producto");
            entity.Property(e => e.IdCategoria).HasColumnName("Id_Categoria");
            entity.Property(e => e.IdMarca).HasColumnName("Id_Marca");
            entity.Property(e => e.IdCliente).HasColumnName("Id_cliente");
            entity.Property(e => e.IdVenta).HasColumnName("Id_Venta");
            entity.Property(e => e.DescripcionDevolucion)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("Descripcion_Devolucion");
            entity.Property(e => e.MontoDevolucion).HasColumnName("Monto_Devolucion");
            entity.Property(e => e.MotivoDevolucion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Motivo_Devolucion");

            entity.HasOne(d => d.DetalleDeVentum).WithMany(p => p.Devolucions)
                .HasForeignKey(d => new { d.IdFactura, d.IdProducto, d.IdCategoria, d.IdMarca, d.IdCliente, d.IdVenta })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("RefDetalle_De_Venta12");
        });

        modelBuilder.Entity<Egreso>(entity =>
        {
            entity.HasKey(e => new { e.IdEgreso, e.IdUsuario, e.IdApertura })
                .HasName("PK11")
                .IsClustered(false);

            entity.ToTable("Egreso");

            entity.Property(e => e.IdEgreso)
                .ValueGeneratedOnAdd()
                .HasColumnName("Id_Egreso");
            entity.Property(e => e.IdUsuario).HasColumnName("Id_usuario");
            entity.Property(e => e.IdApertura).HasColumnName("Id_Apertura");
            entity.Property(e => e.CantidadEgresada).HasColumnName("Cantidad_Egresada");
            entity.Property(e => e.FechaEgreso).HasColumnName("Fecha_Egreso");
            entity.Property(e => e.MotivoEgreso)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("Motivo_Egreso");

            entity.HasOne(d => d.ArqueoCaja).WithMany(p => p.Egresos)
                .HasForeignKey(d => new { d.IdUsuario, d.IdApertura })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("RefArqueo_caja13");
        });

        modelBuilder.Entity<Inventario>(entity =>
        {
            entity.HasKey(e => new { e.IdInventario, e.IdProducto, e.IdCategoria, e.IdMarca })
                .HasName("PK14")
                .IsClustered(false);

            entity.ToTable("Inventario");

            entity.Property(e => e.IdInventario)
                .ValueGeneratedOnAdd()
                .HasColumnName("Id_Inventario");
            entity.Property(e => e.IdProducto).HasColumnName("Id_Producto");
            entity.Property(e => e.IdCategoria).HasColumnName("Id_Categoria");
            entity.Property(e => e.IdMarca).HasColumnName("Id_Marca");
            entity.Property(e => e.CantidadSalir).HasColumnName("Cantidad_Salir");
            entity.Property(e => e.DescripcionSalida)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("Descripcion_Salida");
            entity.Property(e => e.MotivoSalida)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Motivo_Salida");
        });

        modelBuilder.Entity<Marca>(entity =>
        {
            entity.HasKey(e => e.IdMarca)
                .HasName("PK6")
                .IsClustered(false);

            entity.ToTable("Marca");

            entity.Property(e => e.IdMarca).HasColumnName("Id_Marca");
            entity.Property(e => e.Marca1)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Marca");
        });

        modelBuilder.Entity<PagoDeCredito>(entity =>
        {
            entity.HasKey(e => new { e.IdCredito, e.IdFactura, e.IdProducto, e.IdCategoria, e.IdMarca, e.IdCliente, e.IdVenta })
                .HasName("PK9")
                .IsClustered(false);

            entity.ToTable("Pago de credito");

            entity.Property(e => e.IdCredito)
                .ValueGeneratedOnAdd()
                .HasColumnName("Id_Credito");
            entity.Property(e => e.IdFactura).HasColumnName("Id_Factura");
            entity.Property(e => e.IdProducto).HasColumnName("Id_Producto");
            entity.Property(e => e.IdCategoria).HasColumnName("Id_Categoria");
            entity.Property(e => e.IdMarca).HasColumnName("Id_Marca");
            entity.Property(e => e.IdCliente).HasColumnName("Id_cliente");
            entity.Property(e => e.IdVenta).HasColumnName("Id_Venta");
            entity.Property(e => e.NuevoSaldo).HasColumnName("Nuevo_Saldo");
            entity.Property(e => e.PagoCordobas).HasColumnName("Pago_Cordobas");
            entity.Property(e => e.PagoDolares).HasColumnName("Pago_Dolares");
            entity.Property(e => e.TotalAbonado).HasColumnName("Total_Abonado");

            entity.HasOne(d => d.DetalleDeVentum).WithMany(p => p.PagoDeCreditos)
                .HasForeignKey(d => new { d.IdFactura, d.IdProducto, d.IdCategoria, d.IdMarca, d.IdCliente, d.IdVenta })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("RefDetalle_De_Venta7");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.CodigoProducto);

            entity.ToTable("Producto");

            entity.Property(e => e.CodigoProducto)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Codigo_Producto");
            entity.Property(e => e.EstadoProducto).HasColumnName("Estado_Producto");
            entity.Property(e => e.IdCategoria).HasColumnName("Id_Categoria");
            entity.Property(e => e.IdMarca).HasColumnName("Id_Marca");
            entity.Property(e => e.NombreProducto)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("Nombre_Producto");
            entity.Property(e => e.PrecioVenta).HasColumnName("Precio_Venta");
            entity.Property(e => e.StockActual).HasColumnName("Stock_Actual");
            entity.Property(e => e.StockMinimo).HasColumnName("Stock_Minimo");

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdCategoria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("RefCategoria1");

            entity.HasOne(d => d.IdMarcaNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdMarca)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("RefMarca5");
        });

        modelBuilder.Entity<Proveedor>(entity =>
        {
            entity.HasKey(e => e.CodigoRuc);

            entity.ToTable("Proveedor");

            entity.Property(e => e.CodigoRuc)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Codigo_Ruc");
            entity.Property(e => e.ApellidoProveedor)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("Apellido_Proveedor");
            entity.Property(e => e.CorreoProveedor)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("Correo_Proveedor");
            entity.Property(e => e.EstadoProveedor).HasColumnName("Estado_Proveedor");
            entity.Property(e => e.NombreProveedor)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("Nombre_Proveedor");
            entity.Property(e => e.TelefonoProveedor)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("Telefono_Proveedor");
        });

        modelBuilder.Entity<TasaDeCambio>(entity =>
        {
            entity.HasKey(e => e.IdTasaCambio)
                .HasName("PK17")
                .IsClustered(false);

            entity.ToTable("Tasa de cambio");

            entity.Property(e => e.IdTasaCambio).HasColumnName("Id_Tasa_Cambio");
            entity.Property(e => e.FechaCambio).HasColumnName("Fecha_Cambio");
            entity.Property(e => e.ValorCambio).HasColumnName("Valor_Cambio");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario)
                .HasName("PK1")
                .IsClustered(false);

            entity.ToTable("Usuario");

            entity.Property(e => e.IdUsuario).HasColumnName("Id_usuario");
            entity.Property(e => e.ApellidoUsuario)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("Apellido_Usuario");
            entity.Property(e => e.ContraseñaUsuario)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Contraseña_Usuario");
            entity.Property(e => e.CorreoUsuario)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Correo_Usuario");
            entity.Property(e => e.EstadoUsuario).HasColumnName("Estado_Usuario");
            entity.Property(e => e.NombreUsuario)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("Nombre_Usuario");
            entity.Property(e => e.RolUsuario)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Rol_Usuario");
            entity.Property(e => e.TelefonoUsuario)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("Telefono_Usuario");
            entity.Property(e => e.UsuarioLogueo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Usuario_Logueo");
        });

        modelBuilder.Entity<Ventum>(entity =>
        {
            entity.HasKey(e => e.IdVenta)
                .HasName("PK16")
                .IsClustered(false);

            entity.Property(e => e.IdVenta).HasColumnName("Id_Venta");
            entity.Property(e => e.FechaVenta).HasColumnName("Fecha_Venta");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
