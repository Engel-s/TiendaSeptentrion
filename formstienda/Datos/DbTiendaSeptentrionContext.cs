using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace formstienda.Datos;

public partial class DbTiendaSeptentrionContext : DbContext
{
    public DbTiendaSeptentrionContext()
    {
    }

    public DbTiendaSeptentrionContext(DbContextOptions<DbTiendaSeptentrionContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AperturaCaja> AperturaCajas { get; set; }

    public virtual DbSet<ArqueoCaja> ArqueoCajas { get; set; }

    public virtual DbSet<Categorium> Categoria { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Compra> Compras { get; set; }

    public virtual DbSet<DetalleCompra> DetalleCompras { get; set; }

    public virtual DbSet<DetalleDeVentum> DetalleDeVenta { get; set; }

    public virtual DbSet<Devolucion> Devolucions { get; set; }

    public virtual DbSet<Egreso> Egresos { get; set; }

    public virtual DbSet<Marca> Marcas { get; set; }

    public virtual DbSet<OtrasSalidasDeInventario> OtrasSalidasDeInventarios { get; set; }

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
            entity.HasKey(e => e.IdApertura).HasName("PK__Apertura__1DCB12E51C91C1B6");

            entity.ToTable("Apertura caja");

            entity.Property(e => e.IdApertura).HasColumnName("Id_Apertura");
            entity.Property(e => e.EstadoApertura)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Estado_Apertura");
            entity.Property(e => e.FechaApertura).HasColumnName("Fecha_Apertura");
            entity.Property(e => e.HoraApertura).HasColumnName("Hora_Apertura");
            entity.Property(e => e.MontoApertura).HasColumnName("Monto_Apertura");
        });

        modelBuilder.Entity<ArqueoCaja>(entity =>
        {
            entity.HasKey(e => new { e.IdUsuario, e.IdApertura, e.IdArqueoCaja }).HasName("PK__Arqueo c__6F38EB3D2C7E3091");

            entity.ToTable("Arqueo caja");

            entity.Property(e => e.IdUsuario).HasColumnName("Id_usuario");
            entity.Property(e => e.IdApertura).HasColumnName("Id_Apertura");
            entity.Property(e => e.IdArqueoCaja)
                .ValueGeneratedOnAdd()
                .HasColumnName("Id_Arqueo_Caja");
            entity.Property(e => e.FaltanteCordoba).HasColumnName("Faltante_Cordoba");
            entity.Property(e => e.FaltanteDolar).HasColumnName("Faltante_Dolar");
            entity.Property(e => e.SobranteCordoba).HasColumnName("Sobrante_Cordoba");
            entity.Property(e => e.SobranteDolar).HasColumnName("Sobrante_Dolar");
            entity.Property(e => e.TotalEfectivoCordoba).HasColumnName("Total_Efectivo_Cordoba");
            entity.Property(e => e.TotalEfectivoDolar).HasColumnName("Total_Efectivo_Dolar");

            entity.HasOne(d => d.IdAperturaNavigation).WithMany(p => p.ArqueoCajas)
                .HasForeignKey(d => d.IdApertura)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Arqueo ca__Id_Ap__5629CD9C");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.ArqueoCajas)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Arqueo ca__Id_us__571DF1D5");
        });

        modelBuilder.Entity<Categorium>(entity =>
        {
            entity.HasKey(e => e.IdCategoria).HasName("PK__Categori__CB9033492B40A361");

            entity.Property(e => e.IdCategoria).HasColumnName("Id_Categoria");
            entity.Property(e => e.Categoria)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.CedulaCliente).HasName("PK__Cliente__6E21107A60C0F434");

            entity.ToTable("Cliente");

            entity.Property(e => e.CedulaCliente)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Cedula_Cliente");
            entity.Property(e => e.ApellidoCliente)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("Apellido_Cliente");
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
            entity.HasKey(e => new { e.IdCompra, e.CodigoRuc }).HasName("PK__Compra__5BA93A33048A6BA4");

            entity.ToTable("Compra");

            entity.Property(e => e.IdCompra).HasColumnName("Id_Compra");
            entity.Property(e => e.CodigoRuc)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Codigo_Ruc");
            entity.Property(e => e.FechaCompra).HasColumnName("Fecha_Compra");
            entity.Property(e => e.TotalCompra).HasColumnName("Total_Compra");

            entity.HasOne(d => d.CodigoRucNavigation).WithMany(p => p.Compras)
                .HasForeignKey(d => d.CodigoRuc)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Compra__Codigo_R__5812160E");
        });

        modelBuilder.Entity<DetalleCompra>(entity =>
        {
            entity.HasKey(e => new { e.CodigoProducto, e.IdDetalleCompra, e.IdCategoria, e.IdMarca, e.IdCompra, e.CodigoRuc }).HasName("PK__Detalle___31B72CB7C3B2EBC6");

            entity.ToTable("Detalle_Compra");

            entity.Property(e => e.CodigoProducto)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Codigo_Producto");
            entity.Property(e => e.IdDetalleCompra)
                .ValueGeneratedOnAdd()
                .HasColumnName("Id_Detalle_Compra");
            entity.Property(e => e.IdCategoria).HasColumnName("Id_Categoria");
            entity.Property(e => e.IdMarca).HasColumnName("Id_Marca");
            entity.Property(e => e.IdCompra).HasColumnName("Id_Compra");
            entity.Property(e => e.CodigoRuc)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Codigo_Ruc");
            entity.Property(e => e.CantidadCompra).HasColumnName("Cantidad_compra");
            entity.Property(e => e.PrecioCompra).HasColumnName("Precio_Compra");

            entity.HasOne(d => d.Compra).WithMany(p => p.DetalleCompras)
                .HasForeignKey(d => new { d.IdCompra, d.CodigoRuc })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Detalle_Compra__59FA5E80");

            entity.HasOne(d => d.Producto).WithMany(p => p.DetalleCompras)
                .HasForeignKey(d => new { d.IdCategoria, d.IdMarca, d.CodigoProducto })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Detalle_Compra__59063A47");
        });

        modelBuilder.Entity<DetalleDeVentum>(entity =>
        {
            entity.HasKey(e => new { e.IdDetalleVenta, e.IdCategoria, e.IdMarca, e.IdVenta, e.CodigoProducto, e.CedulaCliente }).HasName("PK__Detalle___BC4114A52E781918");

            entity.ToTable("Detalle_De_Venta");

            entity.Property(e => e.IdDetalleVenta)
                .ValueGeneratedOnAdd()
                .HasColumnName("Id_Detalle_Venta");
            entity.Property(e => e.IdCategoria).HasColumnName("Id_Categoria");
            entity.Property(e => e.IdMarca).HasColumnName("Id_Marca");
            entity.Property(e => e.IdVenta).HasColumnName("Id_Venta");
            entity.Property(e => e.CodigoProducto)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Codigo_Producto");
            entity.Property(e => e.CedulaCliente)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Cedula_Cliente");
            entity.Property(e => e.Precio)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.Ventum).WithMany(p => p.DetalleDeVenta)
                .HasForeignKey(d => new { d.IdVenta, d.CedulaCliente })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Detalle_De_Venta__5BE2A6F2");

            entity.HasOne(d => d.Producto).WithMany(p => p.DetalleDeVenta)
                .HasForeignKey(d => new { d.IdCategoria, d.IdMarca, d.CodigoProducto })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Detalle_De_Venta__5AEE82B9");
        });

        modelBuilder.Entity<Devolucion>(entity =>
        {
            entity.HasKey(e => new { e.IdDevolucion, e.IdVenta, e.CedulaCliente }).HasName("PK__Devoluci__155B897EBE28D141");

            entity.ToTable("Devolucion");

            entity.Property(e => e.IdDevolucion)
                .ValueGeneratedOnAdd()
                .HasColumnName("Id_Devolucion");
            entity.Property(e => e.IdVenta).HasColumnName("Id_Venta");
            entity.Property(e => e.CedulaCliente)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Cedula_Cliente");
            entity.Property(e => e.CantidadDevuelta).HasColumnName("Cantidad_Devuelta");
            entity.Property(e => e.DescripcionDevolucion)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("Descripcion_Devolucion");
            entity.Property(e => e.MontoDevolucion).HasColumnName("Monto_Devolucion");
            entity.Property(e => e.MotivoDevolucion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Motivo_Devolucion");

            entity.HasOne(d => d.Ventum).WithMany(p => p.Devolucions)
                .HasForeignKey(d => new { d.IdVenta, d.CedulaCliente })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Devolucion__5CD6CB2B");
        });

        modelBuilder.Entity<Egreso>(entity =>
        {
            entity.HasKey(e => new { e.IdEgreso, e.IdUsuario, e.IdApertura, e.IdArqueoCaja }).HasName("PK__Egreso__BA278E388FD52431");

            entity.ToTable("Egreso");

            entity.Property(e => e.IdEgreso)
                .ValueGeneratedOnAdd()
                .HasColumnName("Id_Egreso");
            entity.Property(e => e.IdUsuario).HasColumnName("Id_usuario");
            entity.Property(e => e.IdApertura).HasColumnName("Id_Apertura");
            entity.Property(e => e.IdArqueoCaja).HasColumnName("Id_Arqueo_Caja");
            entity.Property(e => e.CantidadEgresada).HasColumnName("Cantidad_Egresada");
            entity.Property(e => e.FechaEgreso).HasColumnName("Fecha_Egreso");
            entity.Property(e => e.MotivoEgreso)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("Motivo_Egreso");

            entity.HasOne(d => d.ArqueoCaja).WithMany(p => p.Egresos)
                .HasForeignKey(d => new { d.IdUsuario, d.IdApertura, d.IdArqueoCaja })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Egreso__5DCAEF64");
        });

        modelBuilder.Entity<Marca>(entity =>
        {
            entity.HasKey(e => e.IdMarca).HasName("PK__Marca__28EFE28A3B0685C4");

            entity.ToTable("Marca");

            entity.Property(e => e.IdMarca).HasColumnName("Id_Marca");
            entity.Property(e => e.Marca1)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Marca");
        });

        modelBuilder.Entity<OtrasSalidasDeInventario>(entity =>
        {
            entity.HasKey(e => new { e.IdInventario, e.IdCategoria, e.IdMarca, e.CodigoProducto }).HasName("PK__Otras sa__30DACF911783EA6E");

            entity.ToTable("Otras salidas de inventario");

            entity.Property(e => e.IdInventario)
                .ValueGeneratedOnAdd()
                .HasColumnName("Id_Inventario");
            entity.Property(e => e.IdCategoria).HasColumnName("Id_Categoria");
            entity.Property(e => e.IdMarca).HasColumnName("Id_Marca");
            entity.Property(e => e.CodigoProducto)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Codigo_Producto");
            entity.Property(e => e.CantidadSalir).HasColumnName("Cantidad_Salir");
            entity.Property(e => e.DescripcionSalida)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("Descripcion_Salida");
            entity.Property(e => e.MotivoSalida)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Motivo_Salida");

            entity.HasOne(d => d.Producto).WithMany(p => p.OtrasSalidasDeInventarios)
                .HasForeignKey(d => new { d.IdCategoria, d.IdMarca, d.CodigoProducto })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Otras salidas de__5EBF139D");
        });

        modelBuilder.Entity<PagoDeCredito>(entity =>
        {
            entity.HasKey(e => new { e.IdCredito, e.IdVenta, e.CedulaCliente }).HasName("PK__Pago de __2AF1F28430099C36");

            entity.ToTable("Pago de credito");

            entity.Property(e => e.IdCredito)
                .ValueGeneratedOnAdd()
                .HasColumnName("Id_Credito");
            entity.Property(e => e.IdVenta).HasColumnName("Id_Venta");
            entity.Property(e => e.CedulaCliente)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Cedula_Cliente");
            entity.Property(e => e.EstadoCredito)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Estado_Credito");
            entity.Property(e => e.NuevoSaldo).HasColumnName("Nuevo_Saldo");
            entity.Property(e => e.PagoCordobas).HasColumnName("Pago_Cordobas");
            entity.Property(e => e.PagoDolares).HasColumnName("Pago_Dolares");
            entity.Property(e => e.TotalAbonado).HasColumnName("Total_Abonado");

            entity.HasOne(d => d.Ventum).WithMany(p => p.PagoDeCreditos)
                .HasForeignKey(d => new { d.IdVenta, d.CedulaCliente })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Pago de credito__5FB337D6");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => new { e.IdCategoria, e.IdMarca, e.CodigoProducto }).HasName("PK__Producto__9018C0D85D74FDEE");

            entity.ToTable("Producto");

            entity.Property(e => e.IdCategoria).HasColumnName("Id_Categoria");
            entity.Property(e => e.IdMarca).HasColumnName("Id_Marca");
            entity.Property(e => e.CodigoProducto)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Codigo_Producto");
            entity.Property(e => e.EstadoProducto).HasColumnName("Estado_Producto");
            entity.Property(e => e.ModeloProducto)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("Modelo_Producto");
            entity.Property(e => e.PrecioVenta).HasColumnName("Precio_Venta");
            entity.Property(e => e.StockActual).HasColumnName("Stock_Actual");
            entity.Property(e => e.StockMinimo).HasColumnName("Stock_Minimo");

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdCategoria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Producto__Id_Cat__60A75C0F");

            entity.HasOne(d => d.IdMarcaNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdMarca)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Producto__Id_Mar__619B8048");
        });

        modelBuilder.Entity<Proveedor>(entity =>
        {
            entity.HasKey(e => e.CodigoRuc).HasName("PK__Proveedo__DB734E32829611AB");

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
            entity.HasKey(e => e.IdTasaCambio).HasName("PK__Tasa de __D4136D07244404B2");

            entity.ToTable("Tasa de cambio");

            entity.Property(e => e.IdTasaCambio).HasColumnName("Id_Tasa_Cambio");
            entity.Property(e => e.FechaCambio).HasColumnName("Fecha_Cambio");
            entity.Property(e => e.ValorCambio).HasColumnName("Valor_Cambio");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__EF59F76277A2DF64");

            entity.ToTable("Usuario");

            entity.Property(e => e.IdUsuario).HasColumnName("Id_usuario");
            entity.Property(e => e.ApellidoUsuario)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("Apellido_Usuario");
            entity.Property(e => e.ContraseñaUsuario)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Contraseña_Usuario");
            entity.Property(e => e.CorreoUsuario)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Correo_Usuario");
            entity.Property(e => e.EstadoUsuario).HasColumnName("Estado_Usuario");
            entity.Property(e => e.FechaRecuperacion).HasColumnName("Fecha_Recuperacion");
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
            entity.Property(e => e.TokenRecuperacion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Token_Recuperacion");
        });

        modelBuilder.Entity<Ventum>(entity =>
        {
            entity.HasKey(e => new { e.IdVenta, e.CedulaCliente }).HasName("PK__Venta__052BFBBAA9D35516");

            entity.Property(e => e.IdVenta).HasColumnName("Id_Venta");
            entity.Property(e => e.CedulaCliente)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Cedula_Cliente");
            entity.Property(e => e.CambioVenta).HasColumnName("Cambio_Venta");
            entity.Property(e => e.FechaVenta).HasColumnName("Fecha_Venta");
            entity.Property(e => e.PagoCordobas).HasColumnName("Pago_Cordobas");
            entity.Property(e => e.PagoDolares).HasColumnName("Pago_Dolares");
            entity.Property(e => e.SubTotal).HasColumnName("Sub_Total");
            entity.Property(e => e.TipoPago)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Tipo_Pago");
            entity.Property(e => e.TotalVenta).HasColumnName("Total_Venta");

            entity.HasOne(d => d.CedulaClienteNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.CedulaCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Venta__Cedula_Cl__628FA481");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
