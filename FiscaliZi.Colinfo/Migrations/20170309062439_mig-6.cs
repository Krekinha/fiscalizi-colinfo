using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FiscaliZi.Colinfo.Migrations
{
    public partial class mig6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VendaID",
                table: "Pedidos",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Vendas",
                columns: table => new
                {
                    VendaID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CodVendedor = table.Column<string>(nullable: true),
                    DataColeta = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendas", x => x.VendaID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_VendaID",
                table: "Pedidos",
                column: "VendaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Vendas_VendaID",
                table: "Pedidos",
                column: "VendaID",
                principalTable: "Vendas",
                principalColumn: "VendaID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Vendas_VendaID",
                table: "Pedidos");

            migrationBuilder.DropTable(
                name: "Vendas");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_VendaID",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "VendaID",
                table: "Pedidos");
        }
    }
}
