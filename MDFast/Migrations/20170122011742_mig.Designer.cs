using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using FiscaliZi.MDFast;

namespace FiscaliZi.MDFast.Migrations
{
    [DbContext(typeof(MDFastContext))]
    [Migration("20170122011742_mig")]
    partial class mig
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752");

            modelBuilder.Entity("FiscaliZi.MDFast.Model.Motorista", b =>
                {
                    b.Property<int>("MotoristaID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CPF");

                    b.Property<string>("Nome");

                    b.Property<int?>("VeiculoID");

                    b.HasKey("MotoristaID");

                    b.HasIndex("VeiculoID");

                    b.ToTable("Motoristas");
                });

            modelBuilder.Entity("FiscaliZi.MDFast.Model.Veiculo", b =>
                {
                    b.Property<int>("VeiculoID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CapKG");

                    b.Property<int?>("ChoferMotoristaID");

                    b.Property<string>("Placa");

                    b.Property<string>("TPCar");

                    b.Property<string>("TPRod");

                    b.Property<int>("Tara");

                    b.Property<string>("UF");

                    b.HasKey("VeiculoID");

                    b.HasIndex("ChoferMotoristaID");

                    b.ToTable("Veiculos");
                });

            modelBuilder.Entity("FiscaliZi.MDFast.Model.Motorista", b =>
                {
                    b.HasOne("FiscaliZi.MDFast.Model.Veiculo", "Veiculo")
                        .WithMany()
                        .HasForeignKey("VeiculoID");
                });

            modelBuilder.Entity("FiscaliZi.MDFast.Model.Veiculo", b =>
                {
                    b.HasOne("FiscaliZi.MDFast.Model.Motorista", "Chofer")
                        .WithMany()
                        .HasForeignKey("ChoferMotoristaID");
                });
        }
    }
}
