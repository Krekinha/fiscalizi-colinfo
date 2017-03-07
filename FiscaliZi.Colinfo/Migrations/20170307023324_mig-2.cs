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
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Arquivos_ArquivoID",
                table: "Pedidos");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropColumn(
                name: "VendedorID",
                table: "Pedidos");

            migrationBuilder.RenameColumn(
                name: "Quantidade",
                table: "Items",
                newName: "QntUND");

            migrationBuilder.AlterColumn<int>(
                name: "ArquivoID",
                table: "Pedidos",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Produto",
                table: "Items",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QntCX",
                table: "Items",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "ValorCusto",
                table: "Items",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Arquivos_ArquivoID",
                table: "Pedidos",
                column: "ArquivoID",
                principalTable: "Arquivos",
                principalColumn: "ArquivoID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Arquivos_ArquivoID",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "Produto",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "QntCX",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "ValorCusto",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "QntUND",
                table: "Items",
                newName: "Quantidade");

            migrationBuilder.AlterColumn<int>(
                name: "ArquivoID",
                table: "Pedidos",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "VendedorID",
                table: "Pedidos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    ProdutoID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Codigo = table.Column<int>(nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    ItemID = table.Column<int>(nullable: false),
                    Peso = table.Column<decimal>(nullable: false),
                    Preco = table.Column<decimal>(nullable: false),
                    Unidades = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.ProdutoID);
                    table.ForeignKey(
                        name: "FK_Produto_Items_ItemID",
                        column: x => x.ItemID,
                        principalTable: "Items",
                        principalColumn: "ItemID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produto_ItemID",
                table: "Produto",
                column: "ItemID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Arquivos_ArquivoID",
                table: "Pedidos",
                column: "ArquivoID",
                principalTable: "Arquivos",
                principalColumn: "ArquivoID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
