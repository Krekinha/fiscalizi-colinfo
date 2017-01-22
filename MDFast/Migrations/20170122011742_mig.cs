using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FiscaliZi.MDFast.Migrations
{
    public partial class mig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Veiculos",
                columns: table => new
                {
                    VeiculoID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CapKG = table.Column<int>(nullable: false),
                    ChoferMotoristaID = table.Column<int>(nullable: true),
                    Placa = table.Column<string>(nullable: true),
                    TPCar = table.Column<string>(nullable: true),
                    TPRod = table.Column<string>(nullable: true),
                    Tara = table.Column<int>(nullable: false),
                    UF = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veiculos", x => x.VeiculoID);
                });

            migrationBuilder.CreateTable(
                name: "Motoristas",
                columns: table => new
                {
                    MotoristaID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CPF = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: true),
                    VeiculoID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motoristas", x => x.MotoristaID);
                    table.ForeignKey(
                        name: "FK_Motoristas_Veiculos_VeiculoID",
                        column: x => x.VeiculoID,
                        principalTable: "Veiculos",
                        principalColumn: "VeiculoID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Motoristas_VeiculoID",
                table: "Motoristas",
                column: "VeiculoID");

            migrationBuilder.CreateIndex(
                name: "IX_Veiculos_ChoferMotoristaID",
                table: "Veiculos",
                column: "ChoferMotoristaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Veiculos_Motoristas_ChoferMotoristaID",
                table: "Veiculos",
                column: "ChoferMotoristaID",
                principalTable: "Motoristas",
                principalColumn: "MotoristaID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Motoristas_Veiculos_VeiculoID",
                table: "Motoristas");

            migrationBuilder.DropTable(
                name: "Veiculos");

            migrationBuilder.DropTable(
                name: "Motoristas");
        }
    }
}
