using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using MDFast;

namespace MDFast.Migrations
{
    [DbContext(typeof(MDFastContext))]
    [Migration("20170115033709_MIG")]
    partial class MIG
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752");

            modelBuilder.Entity("MDFast.Model.Motorista", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CPF");

                    b.Property<string>("Nome");

                    b.HasKey("ID");

                    b.ToTable("Motoristas");
                });

            modelBuilder.Entity("MDFast.Model.Veiculo", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CapKG");

                    b.Property<int?>("MotoristaID");

                    b.Property<string>("Placa");

                    b.Property<string>("TPCar");

                    b.Property<string>("TPRod");

                    b.Property<int>("Tara");

                    b.Property<string>("UF");

                    b.HasKey("ID");

                    b.HasIndex("MotoristaID");

                    b.ToTable("Veiculos");
                });

            modelBuilder.Entity("MDFast.Model.Veiculo", b =>
                {
                    b.HasOne("MDFast.Model.Motorista", "Motorista")
                        .WithMany()
                        .HasForeignKey("MotoristaID");
                });
        }
    }
}
