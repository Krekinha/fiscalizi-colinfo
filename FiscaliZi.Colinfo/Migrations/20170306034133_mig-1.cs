using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FiscaliZi.Colinfo.Migrations
{
    public partial class mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Vendedores_VendedorID",
                table: "Pedidos");

            migrationBuilder.DropTable(
                name: "Vendedores");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_VendedorID",
                table: "Pedidos");

            migrationBuilder.AddColumn<int>(
                name: "ArquivoID",
                table: "Pedidos",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Arquivos",
                columns: table => new
                {
                    ArquivoID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ArquivoVendedor = table.Column<string>(nullable: true),
                    DataColeta = table.Column<DateTime>(nullable: false),
                    DataEnvio = table.Column<DateTime>(nullable: false),
                    NomeVendedor = table.Column<string>(nullable: true),
                    NumVendedor = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arquivos", x => x.ArquivoID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_ArquivoID",
                table: "Pedidos",
                column: "ArquivoID");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Arquivos_ArquivoID",
                table: "Pedidos",
                column: "ArquivoID",
                principalTable: "Arquivos",
                principalColumn: "ArquivoID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Arquivos_ArquivoID",
                table: "Pedidos");

            migrationBuilder.DropTable(
                name: "Arquivos");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_ArquivoID",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "ArquivoID",
                table: "Pedidos");

            migrationBuilder.CreateTable(
                name: "Vendedores",
                columns: table => new
                {
                    VendedorID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ArquivoVendedor = table.Column<string>(nullable: true),
                    DataColeta = table.Column<DateTime>(nullable: false),
                    DataEnvio = table.Column<DateTime>(nullable: false),
                    NomeVendedor = table.Column<string>(nullable: true),
                    NumVendedor = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendedores", x => x.VendedorID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_VendedorID",
                table: "Pedidos",
                column: "VendedorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Vendedores_VendedorID",
                table: "Pedidos",
                column: "VendedorID",
                principalTable: "Vendedores",
                principalColumn: "VendedorID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
