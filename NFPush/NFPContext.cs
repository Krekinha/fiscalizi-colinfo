using Microsoft.EntityFrameworkCore;
using NFPush.Model.NFe.Classes;
using NFPush.Model.NFe.Classes.Informacoes.Detalhe.Produto_Específico;
using NFPush.Model.NFe.Classes.Informacoes.Detalhe.Tributacao.Estadual;
using NFPush.Model.NFe.Classes.Informacoes.Detalhe.Tributacao.Federal;
using System;

namespace NFPush
{
    public partial class NFPContext : DbContext
    {
        public DbSet<DFe> DFes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string conn = "User ID=krekinha;Password=123456;Host=localhost;Port=5432;Database=db_nfpush;Pooling=true;";
            optionsBuilder.UseNpgsql(conn);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*modelBuilder.Entity<COFINSAliq>().ToTable("COFINSAliq");
            modelBuilder.Entity<COFINSQtde>().ToTable("COFINSQtde");
            modelBuilder.Entity<COFINSNT>().ToTable("COFINSNT");
            modelBuilder.Entity<COFINSOutr>().ToTable("COFINSOutr");

            modelBuilder.Entity<ICMS00>().ToTable("ICMS00");
            modelBuilder.Entity<ICMS10>().ToTable("ICMS10");
            modelBuilder.Entity<ICMS20>().ToTable("ICMS20");
            modelBuilder.Entity<ICMS30>().ToTable("ICMS30");
            modelBuilder.Entity<ICMS40>().ToTable("ICMS40");
            modelBuilder.Entity<ICMS51>().ToTable("ICMS51");
            modelBuilder.Entity<ICMS60>().ToTable("ICMS60");
            modelBuilder.Entity<ICMS70>().ToTable("ICMS70");
            modelBuilder.Entity<ICMS90>().ToTable("ICMS90");
            modelBuilder.Entity<ICMSPart>().ToTable("ICMSPart");
            modelBuilder.Entity<ICMSST>().ToTable("ICMSST");
            modelBuilder.Entity<ICMSSN101>().ToTable("ICMSSN101");
            modelBuilder.Entity<ICMSSN102>().ToTable("ICMSSN102");
            modelBuilder.Entity<ICMSSN201>().ToTable("ICMSSN201");
            modelBuilder.Entity<ICMSSN202>().ToTable("ICMSSN202");
            modelBuilder.Entity<ICMSSN500>().ToTable("ICMSSN500");
            modelBuilder.Entity<ICMSSN900>().ToTable("ICMSSN900");

            modelBuilder.Entity<IPITrib>().ToTable("IPITrib");
            modelBuilder.Entity<IPINT>().ToTable("IPINT");

            modelBuilder.Entity<PISAliq>().ToTable("PISAliq");
            modelBuilder.Entity<PISQtde>().ToTable("PISQtde");
            modelBuilder.Entity<PISNT>().ToTable("PISNT");
            modelBuilder.Entity<PISOutr>().ToTable("PISOutr");

            modelBuilder.Entity<veicProd>().ToTable("veicProd");
            modelBuilder.Entity<med>().ToTable("med");
            modelBuilder.Entity<arma>().ToTable("arma");
            modelBuilder.Entity<comb>().ToTable("comb");*/
        }
    }
}
