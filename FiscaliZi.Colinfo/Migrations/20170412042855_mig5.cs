using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FiscaliZi.Colinfo.Migrations
{
    public partial class mig5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_infCad_ender_enderID",
                table: "infCad");

            migrationBuilder.DropIndex(
                name: "IX_infCad_enderID",
                table: "infCad");

            migrationBuilder.DropColumn(
                name: "enderID",
                table: "infCad");

            migrationBuilder.AddColumn<int>(
                name: "infCadID",
                table: "ender",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ender_infCadID",
                table: "ender",
                column: "infCadID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ender_infCad_infCadID",
                table: "ender",
                column: "infCadID",
                principalTable: "infCad",
                principalColumn: "infCadID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ender_infCad_infCadID",
                table: "ender");

            migrationBuilder.DropIndex(
                name: "IX_ender_infCadID",
                table: "ender");

            migrationBuilder.DropColumn(
                name: "infCadID",
                table: "ender");

            migrationBuilder.AddColumn<int>(
                name: "enderID",
                table: "infCad",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_infCad_enderID",
                table: "infCad",
                column: "enderID");

            migrationBuilder.AddForeignKey(
                name: "FK_infCad_ender_enderID",
                table: "infCad",
                column: "enderID",
                principalTable: "ender",
                principalColumn: "enderID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
