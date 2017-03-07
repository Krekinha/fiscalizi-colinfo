using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FiscaliZi.Colinfo.Migrations
{
    public partial class mig5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumVendedor",
                table: "Arquivos");

            migrationBuilder.AlterColumn<string>(
                name: "CodVendedor",
                table: "Pedidos",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "CodVendedor",
                table: "Arquivos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodVendedor",
                table: "Arquivos");

            migrationBuilder.AlterColumn<int>(
                name: "CodVendedor",
                table: "Pedidos",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumVendedor",
                table: "Arquivos",
                nullable: false,
                defaultValue: 0);
        }
    }
}
