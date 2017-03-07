using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FiscaliZi.Colinfo.Migrations
{
    public partial class mig4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NumVendedor",
                table: "Pedidos",
                newName: "CodVendedor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CodVendedor",
                table: "Pedidos",
                newName: "NumVendedor");
        }
    }
}
