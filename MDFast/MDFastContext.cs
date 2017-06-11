﻿using FiscaliZi.MDFast.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FiscaliZi.MDFast
{
    public class MDFastContext : DbContext
    {
        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<Motorista> Motoristas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("User ID=postgres;Password=123456;Host=localhost;Port=5432;Database=db_mdfast;Pooling=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
