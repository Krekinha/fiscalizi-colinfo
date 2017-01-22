using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FiscaliZi.MDFast.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Motoristas_Veiculos_VeiculoID",
                table: "Motoristas");

            migrationBuilder.DropIndex(
                name: "IX_Motoristas_VeiculoID",
                table: "Motoristas");

            migrationBuilder.DropColumn(
                name: "VeiculoID",
                table: "Motoristas");

            migrationBuilder.AddColumn<int>(
                name: "MotoristaID",
                table: "Veiculos",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Veiculos_MotoristaID",
                table: "Veiculos",
                column: "MotoristaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Veiculos_Motoristas_MotoristaID",
                table: "Veiculos",
                column: "MotoristaID",
                principalTable: "Motoristas",
                principalColumn: "MotoristaID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Veiculos_Motoristas_MotoristaID",
                table: "Veiculos");

            migrationBuilder.DropIndex(
                name: "IX_Veiculos_MotoristaID",
                table: "Veiculos");

            migrationBuilder.DropColumn(
                name: "MotoristaID",
                table: "Veiculos");

            migrationBuilder.AddColumn<int>(
                name: "VeiculoID",
                table: "Motoristas",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Motoristas_VeiculoID",
                table: "Motoristas",
                column: "VeiculoID");

            migrationBuilder.AddForeignKey(
                name: "FK_Motoristas_Veiculos_VeiculoID",
                table: "Motoristas",
                column: "VeiculoID",
                principalTable: "Veiculos",
                principalColumn: "VeiculoID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
