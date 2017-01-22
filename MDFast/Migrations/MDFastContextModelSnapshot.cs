using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using FiscaliZi.MDFast;

namespace FiscaliZi.MDFast.Migrations
{
    [DbContext(typeof(MDFastContext))]
    partial class MDFastContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.HasKey("MotoristaID");

                    b.ToTable("Motoristas");
                });

            modelBuilder.Entity("FiscaliZi.MDFast.Model.Veiculo", b =>
                {
                    b.Property<int>("VeiculoID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CapKG");

                    b.Property<int?>("ChoferMotoristaID");

                    b.Property<int?>("MotoristaID");

                    b.Property<string>("Placa");

                    b.Property<string>("TPCar");

                    b.Property<string>("TPRod");

                    b.Property<int>("Tara");

                    b.Property<string>("UF");

                    b.HasKey("VeiculoID");

                    b.HasIndex("ChoferMotoristaID");

                    b.HasIndex("MotoristaID");

                    b.ToTable("Veiculos");
                });

            modelBuilder.Entity("FiscaliZi.MDFast.Model.Veiculo", b =>
                {
                    b.HasOne("FiscaliZi.MDFast.Model.Motorista", "Chofer")
                        .WithMany()
                        .HasForeignKey("ChoferMotoristaID");

                    b.HasOne("FiscaliZi.MDFast.Model.Motorista", "Motorista")
                        .WithMany()
                        .HasForeignKey("MotoristaID");
                });
        }
    }
}
