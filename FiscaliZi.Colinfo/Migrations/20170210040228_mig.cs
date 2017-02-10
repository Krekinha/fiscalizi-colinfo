﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FiscaliZi.Colinfo.Migrations
{
    public partial class mig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClienteID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CNPJ = table.Column<string>(nullable: true),
                    IE = table.Column<string>(nullable: true),
                    NumCliente = table.Column<int>(nullable: false),
                    Razao = table.Column<string>(nullable: true),
                    RegiaoCliente = table.Column<int>(nullable: false),
                    Rota = table.Column<int>(nullable: false),
                    Sigla = table.Column<string>(nullable: true),
                    Situacao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ClienteID);
                });

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

            migrationBuilder.CreateTable(
                name: "Info",
                columns: table => new
                {
                    InfoID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ClienteID = table.Column<int>(nullable: false),
                    ErroID = table.Column<string>(nullable: true),
                    Mensagem = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Info", x => x.InfoID);
                    table.ForeignKey(
                        name: "FK_Info_Clientes_ClienteID",
                        column: x => x.ClienteID,
                        principalTable: "Clientes",
                        principalColumn: "ClienteID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "retConsCad",
                columns: table => new
                {
                    retConsCadID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ClienteID = table.Column<int>(nullable: false),
                    ErrorCode = table.Column<string>(nullable: true),
                    ErrorDetail = table.Column<string>(nullable: true),
                    ErrorMessage = table.Column<string>(nullable: true),
                    versao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_retConsCad", x => x.retConsCadID);
                    table.ForeignKey(
                        name: "FK_retConsCad_Clientes_ClienteID",
                        column: x => x.ClienteID,
                        principalTable: "Clientes",
                        principalColumn: "ClienteID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    PedidoID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ClienteID = table.Column<int>(nullable: false),
                    FormPgt = table.Column<string>(nullable: true),
                    NumPedPalm = table.Column<string>(nullable: true),
                    NumPedido = table.Column<int>(nullable: false),
                    NumVendedor = table.Column<int>(nullable: false),
                    ValorTotal = table.Column<decimal>(nullable: false),
                    VendedorID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.PedidoID);
                    table.ForeignKey(
                        name: "FK_Pedidos_Clientes_ClienteID",
                        column: x => x.ClienteID,
                        principalTable: "Clientes",
                        principalColumn: "ClienteID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pedidos_Vendedores_VendedorID",
                        column: x => x.VendedorID,
                        principalTable: "Vendedores",
                        principalColumn: "VendedorID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "infCons",
                columns: table => new
                {
                    InfConsID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CNPJ = table.Column<string>(nullable: true),
                    UF = table.Column<string>(nullable: true),
                    cStat = table.Column<string>(nullable: true),
                    cUF = table.Column<string>(nullable: true),
                    dhCons = table.Column<string>(nullable: true),
                    retConsCadID = table.Column<int>(nullable: false),
                    verAplic = table.Column<string>(nullable: true),
                    xMotivo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_infCons", x => x.InfConsID);
                    table.ForeignKey(
                        name: "FK_infCons_retConsCad_retConsCadID",
                        column: x => x.retConsCadID,
                        principalTable: "retConsCad",
                        principalColumn: "retConsCadID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ItemID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    PedidoID = table.Column<int>(nullable: false),
                    Quantidade = table.Column<int>(nullable: false),
                    ValorTotal = table.Column<decimal>(nullable: false),
                    ValorUnid = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ItemID);
                    table.ForeignKey(
                        name: "FK_Items_Pedidos_PedidoID",
                        column: x => x.PedidoID,
                        principalTable: "Pedidos",
                        principalColumn: "PedidoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "infCad",
                columns: table => new
                {
                    infCadID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CNAE = table.Column<string>(nullable: true),
                    CNPJ = table.Column<string>(nullable: true),
                    IE = table.Column<string>(nullable: true),
                    IEAtual = table.Column<string>(nullable: true),
                    InfConsID = table.Column<int>(nullable: false),
                    UF = table.Column<string>(nullable: true),
                    cSit = table.Column<string>(nullable: true),
                    dBaixa = table.Column<string>(nullable: true),
                    dIniAtiv = table.Column<string>(nullable: true),
                    indCredCTe = table.Column<string>(nullable: true),
                    indCredNFe = table.Column<string>(nullable: true),
                    xFant = table.Column<string>(nullable: true),
                    xNome = table.Column<string>(nullable: true),
                    xRegApur = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_infCad", x => x.infCadID);
                    table.ForeignKey(
                        name: "FK_infCad_infCons_InfConsID",
                        column: x => x.InfConsID,
                        principalTable: "infCons",
                        principalColumn: "InfConsID",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "ender",
                columns: table => new
                {
                    enderID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CEP = table.Column<string>(nullable: true),
                    cMun = table.Column<string>(nullable: true),
                    infCadID = table.Column<int>(nullable: false),
                    nro = table.Column<string>(nullable: true),
                    xBairro = table.Column<string>(nullable: true),
                    xLgr = table.Column<string>(nullable: true),
                    xMun = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ender", x => x.enderID);
                    table.ForeignKey(
                        name: "FK_ender_infCad_infCadID",
                        column: x => x.infCadID,
                        principalTable: "infCad",
                        principalColumn: "infCadID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ender_infCadID",
                table: "ender",
                column: "infCadID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_infCad_InfConsID",
                table: "infCad",
                column: "InfConsID");

            migrationBuilder.CreateIndex(
                name: "IX_infCons_retConsCadID",
                table: "infCons",
                column: "retConsCadID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Info_ClienteID",
                table: "Info",
                column: "ClienteID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Items_PedidoID",
                table: "Items",
                column: "PedidoID");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_ClienteID",
                table: "Pedidos",
                column: "ClienteID");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_VendedorID",
                table: "Pedidos",
                column: "VendedorID");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_ItemID",
                table: "Produto",
                column: "ItemID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_retConsCad_ClienteID",
                table: "retConsCad",
                column: "ClienteID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ender");

            migrationBuilder.DropTable(
                name: "Info");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "infCad");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "infCons");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "retConsCad");

            migrationBuilder.DropTable(
                name: "Vendedores");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
