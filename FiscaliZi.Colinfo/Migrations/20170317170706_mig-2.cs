using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FiscaliZi.Colinfo.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Produto",
                table: "Items");

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    ProdutoID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Codigo = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    Familia = table.Column<string>(nullable: true),
                    ItemID = table.Column<int>(nullable: false),
                    PesoEmb = table.Column<decimal>(nullable: false),
                    PesoUnd = table.Column<decimal>(nullable: false),
                    Preco = table.Column<decimal>(nullable: false),
                    Sigla = table.Column<string>(nullable: true),
                    Unidades = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.ProdutoID);
                    table.ForeignKey(
                        name: "FK_Produtos_Items_ItemID",
                        column: x => x.ItemID,
                        principalTable: "Items",
                        principalColumn: "ItemID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_ItemID",
                table: "Produtos",
                column: "ItemID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.AddColumn<string>(
                name: "Produto",
                table: "Items",
                nullable: true);
        }
    }
}
