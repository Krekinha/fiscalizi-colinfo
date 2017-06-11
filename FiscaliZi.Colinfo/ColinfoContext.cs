
using FiscaliZi.Colinfo.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FiscaliZi.Colinfo
{
    public class ColinfoContext : DbContext
    {
        public DbSet<Arquivo> Arquivos { get; set; }
        public DbSet<Venda> Vendas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            const string conn = "User ID=postgres;Password=123456;Host=localhost;Port=5432;Database=db_colinfo;Pooling=true;";
            optionsBuilder.UseNpgsql(conn);
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Tables Config

            modelBuilder.Entity<Item>(itm =>
            {
                itm.HasOne(p => p.Pedido)
                    .WithMany( x => x.Items)
                    .HasForeignKey(x => x.PedidoID)
                    .OnDelete(DeleteBehavior.Cascade);

                itm.HasOne(x => x.Produto)
                    .WithMany(x => x.Items);
            });

            #endregion
        }
    }
}
