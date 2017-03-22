using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using FiscaliZi.Colinfo;

namespace FiscaliZi.Colinfo.Migrations
{
    [DbContext(typeof(ColinfoContext))]
    [Migration("20170322171249_mig")]
    partial class mig
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752");

            modelBuilder.Entity("FiscaliZi.Colinfo.Model.Arquivo", b =>
                {
                    b.Property<int>("ArquivoID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ArquivoVendedor");

                    b.Property<int>("CodVendedor");

                    b.Property<DateTime>("DataColeta");

                    b.Property<DateTime>("DataEnvio");

                    b.Property<string>("NomeVendedor");

                    b.HasKey("ArquivoID");

                    b.ToTable("Arquivos");
                });

            modelBuilder.Entity("FiscaliZi.Colinfo.Model.Cliente", b =>
                {
                    b.Property<int>("ClienteID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CNPJ");

                    b.Property<string>("IE");

                    b.Property<int>("NumCliente");

                    b.Property<string>("Razao");

                    b.Property<int>("RegiaoCliente");

                    b.Property<int>("Rota");

                    b.Property<string>("Sigla");

                    b.Property<string>("Situacao");

                    b.HasKey("ClienteID");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("FiscaliZi.Colinfo.Model.ender", b =>
                {
                    b.Property<int>("enderID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CEP");

                    b.Property<string>("cMun");

                    b.Property<int>("infCadID");

                    b.Property<string>("nro");

                    b.Property<string>("xBairro");

                    b.Property<string>("xLgr");

                    b.Property<string>("xMun");

                    b.HasKey("enderID");

                    b.HasIndex("infCadID")
                        .IsUnique();

                    b.ToTable("ender");
                });

            modelBuilder.Entity("FiscaliZi.Colinfo.Model.infCad", b =>
                {
                    b.Property<int>("infCadID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CNAE");

                    b.Property<string>("CNPJ");

                    b.Property<string>("IE");

                    b.Property<string>("IEAtual");

                    b.Property<int>("InfConsID");

                    b.Property<string>("UF");

                    b.Property<string>("cSit");

                    b.Property<string>("dBaixa");

                    b.Property<string>("dIniAtiv");

                    b.Property<string>("indCredCTe");

                    b.Property<string>("indCredNFe");

                    b.Property<string>("xFant");

                    b.Property<string>("xNome");

                    b.Property<string>("xRegApur");

                    b.HasKey("infCadID");

                    b.HasIndex("InfConsID");

                    b.ToTable("infCad");
                });

            modelBuilder.Entity("FiscaliZi.Colinfo.Model.infCons", b =>
                {
                    b.Property<int>("InfConsID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CNPJ");

                    b.Property<string>("UF");

                    b.Property<string>("cStat");

                    b.Property<string>("cUF");

                    b.Property<string>("dhCons");

                    b.Property<int>("retConsCadID");

                    b.Property<string>("verAplic");

                    b.Property<string>("xMotivo");

                    b.HasKey("InfConsID");

                    b.HasIndex("retConsCadID")
                        .IsUnique();

                    b.ToTable("infCons");
                });

            modelBuilder.Entity("FiscaliZi.Colinfo.Model.Info", b =>
                {
                    b.Property<int>("InfoID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClienteID");

                    b.Property<string>("ErroID");

                    b.Property<string>("Mensagem");

                    b.HasKey("InfoID");

                    b.HasIndex("ClienteID")
                        .IsUnique();

                    b.ToTable("Info");
                });

            modelBuilder.Entity("FiscaliZi.Colinfo.Model.Item", b =>
                {
                    b.Property<int>("ItemID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("MotOcorrencia");

                    b.Property<int>("Ocorrencia");

                    b.Property<int>("PedidoID");

                    b.Property<int?>("ProdutoID");

                    b.Property<int>("QntCX");

                    b.Property<int>("QntUND");

                    b.Property<decimal>("ValorCusto");

                    b.Property<decimal>("ValorTotal");

                    b.Property<decimal>("ValorUnid");

                    b.HasKey("ItemID");

                    b.HasIndex("PedidoID");

                    b.HasIndex("ProdutoID");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("FiscaliZi.Colinfo.Model.Pedido", b =>
                {
                    b.Property<int>("PedidoID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ArquivoID");

                    b.Property<int>("ClienteID");

                    b.Property<int>("CodVendedor");

                    b.Property<DateTime>("DataPedido");

                    b.Property<string>("FormPgt");

                    b.Property<string>("NumPedPalm");

                    b.Property<string>("NumPedido");

                    b.Property<string>("Pasta");

                    b.Property<string>("SitPed");

                    b.Property<decimal>("ValorTotal");

                    b.Property<int?>("VendaID");

                    b.HasKey("PedidoID");

                    b.HasIndex("ArquivoID");

                    b.HasIndex("ClienteID");

                    b.HasIndex("VendaID");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("FiscaliZi.Colinfo.Model.Produto", b =>
                {
                    b.Property<int>("ProdutoID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Codigo");

                    b.Property<string>("Descricao");

                    b.Property<string>("Familia");

                    b.Property<decimal>("PesoEmb");

                    b.Property<decimal>("PesoUnd");

                    b.Property<string>("Sigla");

                    b.Property<int>("Unidades");

                    b.HasKey("ProdutoID");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("FiscaliZi.Colinfo.Model.retConsCad", b =>
                {
                    b.Property<int>("retConsCadID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClienteID");

                    b.Property<string>("ErrorCode");

                    b.Property<string>("ErrorDetail");

                    b.Property<string>("ErrorMessage");

                    b.Property<string>("versao");

                    b.HasKey("retConsCadID");

                    b.HasIndex("ClienteID")
                        .IsUnique();

                    b.ToTable("retConsCad");
                });

            modelBuilder.Entity("FiscaliZi.Colinfo.Model.Venda", b =>
                {
                    b.Property<int>("VendaID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CodVendedor");

                    b.Property<DateTime>("DataColeta");

                    b.HasKey("VendaID");

                    b.ToTable("Vendas");
                });

            modelBuilder.Entity("FiscaliZi.Colinfo.Model.ender", b =>
                {
                    b.HasOne("FiscaliZi.Colinfo.Model.infCad")
                        .WithOne("ender")
                        .HasForeignKey("FiscaliZi.Colinfo.Model.ender", "infCadID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FiscaliZi.Colinfo.Model.infCad", b =>
                {
                    b.HasOne("FiscaliZi.Colinfo.Model.infCons")
                        .WithMany("infCad")
                        .HasForeignKey("InfConsID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FiscaliZi.Colinfo.Model.infCons", b =>
                {
                    b.HasOne("FiscaliZi.Colinfo.Model.retConsCad")
                        .WithOne("infCons")
                        .HasForeignKey("FiscaliZi.Colinfo.Model.infCons", "retConsCadID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FiscaliZi.Colinfo.Model.Info", b =>
                {
                    b.HasOne("FiscaliZi.Colinfo.Model.Cliente")
                        .WithOne("Info")
                        .HasForeignKey("FiscaliZi.Colinfo.Model.Info", "ClienteID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FiscaliZi.Colinfo.Model.Item", b =>
                {
                    b.HasOne("FiscaliZi.Colinfo.Model.Pedido", "Pedido")
                        .WithMany("Items")
                        .HasForeignKey("PedidoID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FiscaliZi.Colinfo.Model.Produto", "Produto")
                        .WithMany("Items")
                        .HasForeignKey("ProdutoID");
                });

            modelBuilder.Entity("FiscaliZi.Colinfo.Model.Pedido", b =>
                {
                    b.HasOne("FiscaliZi.Colinfo.Model.Arquivo", "Arquivo")
                        .WithMany("Pedidos")
                        .HasForeignKey("ArquivoID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FiscaliZi.Colinfo.Model.Cliente", "Cliente")
                        .WithMany("NavPedidos")
                        .HasForeignKey("ClienteID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FiscaliZi.Colinfo.Model.Venda")
                        .WithMany("Pedidos")
                        .HasForeignKey("VendaID");
                });

            modelBuilder.Entity("FiscaliZi.Colinfo.Model.retConsCad", b =>
                {
                    b.HasOne("FiscaliZi.Colinfo.Model.Cliente")
                        .WithOne("RetConsultaCadastro")
                        .HasForeignKey("FiscaliZi.Colinfo.Model.retConsCad", "ClienteID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
