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
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_ender_EnderecoenderID",
                table: "Clientes");

            migrationBuilder.RenameColumn(
                name: "EnderecoenderID",
                table: "Clientes",
                newName: "EnderecoID");

            migrationBuilder.RenameIndex(
                name: "IX_Clientes_EnderecoenderID",
                table: "Clientes",
                newName: "IX_Clientes_EnderecoID");

            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    EnderecoID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CEP = table.Column<string>(nullable: true),
                    cMun = table.Column<string>(nullable: true),
                    infCadID = table.Column<int>(nullable: false),
                    nro = table.Column<string>(nullable: true),
                    xBairro = table.Column<string>(nullable: true),
                    xLgr = table.Column<string>(nullable: true),
                    xMun = table.Column<string>(nullable: true),
                    xPrepLgr = table.Column<string>(nullable: true),
                    xTPLgr = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.EnderecoID);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Endereco_EnderecoID",
                table: "Clientes",
                column: "EnderecoID",
                principalTable: "Endereco",
                principalColumn: "EnderecoID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Endereco_EnderecoID",
                table: "Clientes");

            migrationBuilder.DropTable(
                name: "Endereco");

            migrationBuilder.RenameColumn(
                name: "EnderecoID",
                table: "Clientes",
                newName: "EnderecoenderID");

            migrationBuilder.RenameIndex(
                name: "IX_Clientes_EnderecoID",
                table: "Clientes",
                newName: "IX_Clientes_EnderecoenderID");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_ender_EnderecoenderID",
                table: "Clientes",
                column: "EnderecoenderID",
                principalTable: "ender",
                principalColumn: "enderID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
