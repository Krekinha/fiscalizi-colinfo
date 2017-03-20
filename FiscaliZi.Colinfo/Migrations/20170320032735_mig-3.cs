using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FiscaliZi.Colinfo.Migrations
{
    public partial class mig3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Produtos_ProdutoID",
                table: "Items");

            migrationBuilder.AlterColumn<int>(
                name: "ProdutoID",
                table: "Items",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Produtos_ProdutoID",
                table: "Items",
                column: "ProdutoID",
                principalTable: "Produtos",
                principalColumn: "ProdutoID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Produtos_ProdutoID",
                table: "Items");

            migrationBuilder.AlterColumn<int>(
                name: "ProdutoID",
                table: "Items",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Produtos_ProdutoID",
                table: "Items",
                column: "ProdutoID",
                principalTable: "Produtos",
                principalColumn: "ProdutoID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
