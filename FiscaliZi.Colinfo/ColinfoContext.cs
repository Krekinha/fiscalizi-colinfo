
using FiscaliZi.Colinfo.Model;
using Microsoft.EntityFrameworkCore;

namespace FiscaliZi.Colinfo
{
    public class ColinfoContext : DbContext
    {
        public DbSet<Vendedor> Vendedores { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            const string conn = "User ID=postgres;Password=admin;Host=localhost;Port=5432;Database=db_colinfo;Pooling=true;";
            optionsBuilder.UseNpgsql(conn);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
