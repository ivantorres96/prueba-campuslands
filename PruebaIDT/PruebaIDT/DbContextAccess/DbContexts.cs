using Microsoft.EntityFrameworkCore;
using PruebaIDT.Models.Models;

namespace PruebaIDT.DbContextAccess
{
    public class DbContexts(DbContextOptions options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Cliente
            var clienteEntity = modelBuilder.Entity<ClienteModel>();
            clienteEntity.ToTable("Clientes").HasKey(pk => pk.Id);
            clienteEntity.HasIndex(c => c.Id);
            clienteEntity.Property(c => c.Email).IsUnicode();
            clienteEntity.HasMany(c => c.Pedidos)
                .WithOne(x => x.Cliente)
                .HasForeignKey(x => x.ClienteId);
            #endregion

            #region Producto
            var productoEntity = modelBuilder.Entity<ProductoModel>();
            productoEntity.ToTable("Productos").HasKey(pk => pk.Id);
            productoEntity.HasMany(p => p.PedidoProductos)
                .WithOne(pp => pp.Producto)
                .HasForeignKey(pp => pp.ProductoId);
            #endregion

            #region Pedido
            var pedidoEntity = modelBuilder.Entity<PedidoModel>();
            pedidoEntity.ToTable("Pedidos").HasKey(pk => pk.Id);
            pedidoEntity.HasMany(p => p.PedidoProductos)
                .WithOne(pp => pp.Pedido)
                .HasForeignKey(pp => pp.PedidoId);
            #endregion

            #region PedidoProductos
            var pedidoProductos = modelBuilder.Entity<PedidoProductoModel>();
            pedidoProductos.ToTable("PedidosProductos").HasKey(pk => pk.Id);
            #endregion

            base.OnModelCreating(modelBuilder);           
        }

        public DbSet<ClienteModel> Clientes { get; set; }

        public DbSet<PedidoModel> Pedidos { get; set; }

        public DbSet<PedidoProductoModel> PedidoProductos { get; set; }

        public DbSet<ProductoModel> Productos { get; set; }
    }
}
