using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiscaliZi.Colinfo.Model
{
    public interface IDataService
    {
        ObservableCollection<Vendedor> GetVendedores();
    }

    public class DataService : IDataService
    {
        public ObservableCollection<Vendedor> GetVendedores()
        {
            return testData();
        }

        private ObservableCollection<Vendedor> testData()
        {
            return new ObservableCollection<Vendedor>
            {
                new Vendedor
                {
                    VendedorID = 1,
                    NumVendedor = 308,
                    DataColeta = DateTime.Now,
                    DataEnvio = DateTime.Parse("03/05/2000 00:00:00"),
                    NomeVendedor = "RAFAEL ALVES",
                    ArquivoVendedor = "TXAA0600000308.TXT",
                    Pedidos = new List<Pedido>
                    {
                        new Pedido
                        {
                            PedidoID = 1,
                            NumPedido = 0,
                            NumPedPalm = "20160611102653",
                            NumVendedor = 308,
                            ValorTotal = 645.10m,
                            Cliente = new Cliente
                            {
                                ClienteID = 1,
                                RegiaoCliente = 101,
                            NumCliente = 28,
                            Razao = "SILVIO BATISTA ALVES - ME",
                            Sigla = "",
                            Rota = 0,
                            CNPJ = "64.436.249/0001-27",
                            IE = "333647.589/0096",
                            Situacao = "REJEIÇÃO"},
                        Itens = new List<Item>
                        {
                            new Item
                            {
                                ItemID = 1,
                                Produto = new Produto
                                {
                                    ProdutoID = 1,
                                    Codigo = 900089,
                                    Descricao = "",
                                    Peso = 0m,
                                    Preco = 0m,
                                    Unidades = 0
                                },
                                Quantidade = 5,
                                ValorUnid = 1830.00m,
                                ValorTotal = 9150.00m },
                            { new Item
                            {
                                ItemID = 2, Produto = new Produto { ProdutoID = 2, Codigo = 900090, Descricao = "", Peso = 0m, Preco = 0m, Unidades = 0 }, Quantidade = 2, ValorUnid = 5800.00m, ValorTotal = 11600.00m } },
{ new Item { ItemID = 3, Produto = new Produto { ProdutoID = 3, Codigo = 900350, Descricao = "", Peso = 0m, Preco = 0m, Unidades = 0 }, Quantidade = 1, ValorUnid = 1850.00m, ValorTotal = 1850.00m } },
{ new Item { ItemID = 4, Produto = new Produto { ProdutoID = 4, Codigo = 902410, Descricao = "", Peso = 0m, Preco = 0m, Unidades = 0 }, Quantidade = 2, ValorUnid = 2360.00m, ValorTotal = 4720.00m } },
{ new Item { ItemID = 5, Produto = new Produto { ProdutoID = 5, Codigo = 902780, Descricao = "", Peso = 0m, Preco = 0m, Unidades = 0 }, Quantidade = 6, ValorUnid = 1850.00m, ValorTotal = 11100.00m } },
{ new Item { ItemID = 6, Produto = new Produto { ProdutoID = 6, Codigo = 902795, Descricao = "", Peso = 0m, Preco = 0m, Unidades = 0 }, Quantidade = 3, ValorUnid = 1850.00m, ValorTotal = 5550.00m } },
{ new Item { ItemID = 7, Produto = new Produto { ProdutoID = 7, Codigo = 902802, Descricao = "", Peso = 0m, Preco = 0m, Unidades = 0 }, Quantidade = 2, ValorUnid = 1850.00m, ValorTotal = 3700.00m } },
{ new Item { ItemID = 8, Produto = new Produto { ProdutoID = 8, Codigo = 902809, Descricao = "", Peso = 0m, Preco = 0m, Unidades = 0 }, Quantidade = 4, ValorUnid = 1850.00m, ValorTotal = 7400.00m } },
{ new Item { ItemID = 9, Produto = new Produto { ProdutoID = 9, Codigo = 902815, Descricao = "", Peso = 0m, Preco = 0m, Unidades = 0 }, Quantidade = 2, ValorUnid = 1850.00m, ValorTotal = 3700.00m } },
{ new Item { ItemID = 10, Produto = new Produto { ProdutoID = 10, Codigo = 902817, Descricao = "", Peso = 0m, Preco = 0m, Unidades = 0 }, Quantidade = 2, ValorUnid = 1850.00m, ValorTotal = 3700.00m } },
{ new Item { ItemID = 11, Produto = new Produto { ProdutoID = 11, Codigo = 903122, Descricao = "", Peso = 0m, Preco = 0m, Unidades = 0 }, Quantidade = 1, ValorUnid = 2040.00m, ValorTotal = 2040.00m } },
}},

{
                new Pedido
                {
                    PedidoID = 2,
                    NumPedido = 0,
                    NumPedPalm = "20160611092020",
                    NumVendedor = 308,
                    ValorTotal = 426.00m,
                    Cliente = new Cliente { ClienteID = 2, RegiaoCliente = 101, NumCliente = 596, Razao = "ROMUALDO ANTUNES PEREIRA - ME", Sigla = "", Rota = 0, CNPJ = "00.395.494/0001-50", IE = "333919.491/0096", Situacao = "" },
                    Itens = new List<Item>
{ new Item { ItemID = 12, Produto = new Produto { ProdutoID = 12, Codigo = 900416, Descricao = "", Peso = 0m, Preco = 0m, Unidades = 0 }, Quantidade = 20, ValorUnid = 2130.00m, ValorTotal = 42600.00m } },
                }
        },

{ new Pedido {PedidoID= 3, NumPedido = 0, NumPedPalm = "20160611074516", NumVendedor = 308, ValorTotal = 2249.88m, Cliente = new Cliente { ClienteID = 3, RegiaoCliente = 101, NumCliente = 629, Razao = "SUPERMERCADO COSTA E FARIAS LT", Sigla = "", Rota = 0, CNPJ = "00.705.844/0001-38", IE = "333937.442/0003", Situacao = ""}, Itens = new List<Item>
{ new Item { ItemID = 13, Produto = new Produto { ProdutoID = 13, Codigo = 900032, Descricao = "", Peso = 0m, Preco = 0m, Unidades = 0 }, Quantidade = 2, ValorUnid = 1420.00m, ValorTotal = 2840.00m },
{ new Item { ItemID = 14, Produto = new Produto { ProdutoID = 14, Codigo = 900320, Descricao = "", Peso = 0m, Preco = 0m, Unidades = 0 }, Quantidade = 3, ValorUnid = 1850.00m, ValorTotal = 5550.00m } },
{ new Item { ItemID = 15, Produto = new Produto { ProdutoID = 15, Codigo = 900350, Descricao = "", Peso = 0m, Preco = 0m, Unidades = 0 }, Quantidade = 3, ValorUnid = 1850.00m, ValorTotal = 5550.00m } },
{ new Item { ItemID = 16, Produto = new Produto { ProdutoID = 16, Codigo = 900362, Descricao = "", Peso = 0m, Preco = 0m, Unidades = 0 }, Quantidade = 1, ValorUnid = 2040.00m, ValorTotal = 2040.00m } },
{ new Item { ItemID = 17, Produto = new Produto { ProdutoID = 17, Codigo = 900416, Descricao = "", Peso = 0m, Preco = 0m, Unidades = 0 }, Quantidade = 50, ValorUnid = 2130.00m, ValorTotal = 106500.00m } },
{ new Item { ItemID = 18, Produto = new Produto { ProdutoID = 18, Codigo = 902410, Descricao = "", Peso = 0m, Preco = 0m, Unidades = 0 }, Quantidade = 10, ValorUnid = 2360.00m, ValorTotal = 23600.00m } },
{ new Item { ItemID = 19, Produto = new Produto { ProdutoID = 19, Codigo = 902417, Descricao = "", Peso = 0m, Preco = 0m, Unidades = 0 }, Quantidade = 2, ValorUnid = 1629.00m, ValorTotal = 3258.00m } },
{ new Item { ItemID = 20, Produto = new Produto { ProdutoID = 20, Codigo = 902430, Descricao = "", Peso = 0m, Preco = 0m, Unidades = 0 }, Quantidade = 3, ValorUnid = 2400.00m, ValorTotal = 7200.00m } },
{ new Item { ItemID = 21, Produto = new Produto { ProdutoID = 21, Codigo = 902778, Descricao = "", Peso = 0m, Preco = 0m, Unidades = 0 }, Quantidade = 3, ValorUnid = 1850.00m, ValorTotal = 5550.00m } },
{ new Item { ItemID = 22, Produto = new Produto { ProdutoID = 22, Codigo = 902780, Descricao = "", Peso = 0m, Preco = 0m, Unidades = 0 }, Quantidade = 5, ValorUnid = 1850.00m, ValorTotal = 9250.00m } },
{ new Item { ItemID = 23, Produto = new Produto { ProdutoID = 23, Codigo = 902795, Descricao = "", Peso = 0m, Preco = 0m, Unidades = 0 }, Quantidade = 10, ValorUnid = 1850.00m, ValorTotal = 18500.00m } },
{ new Item { ItemID = 24, Produto = new Produto { ProdutoID = 24, Codigo = 902802, Descricao = "", Peso = 0m, Preco = 0m, Unidades = 0 }, Quantidade = 1, ValorUnid = 1850.00m, ValorTotal = 1850.00m } },
{ new Item { ItemID = 25, Produto = new Produto { ProdutoID = 25, Codigo = 902809, Descricao = "", Peso = 0m, Preco = 0m, Unidades = 0 }, Quantidade = 10, ValorUnid = 1850.00m, ValorTotal = 18500.00m } },
{ new Item { ItemID = 26, Produto = new Produto { ProdutoID = 26, Codigo = 902815, Descricao = "", Peso = 0m, Preco = 0m, Unidades = 0 }, Quantidade = 3, ValorUnid = 1850.00m, ValorTotal = 5550.00m } },
{ new Item { ItemID = 27, Produto = new Produto { ProdutoID = 27, Codigo = 902817, Descricao = "", Peso = 0m, Preco = 0m, Unidades = 0 }, Quantidade = 5, ValorUnid = 1850.00m, ValorTotal = 9250.00m } },
}}},

{ new Pedido {PedidoID= 4, NumPedido = 0, NumPedPalm = "20160611110832", NumVendedor = 308, ValorTotal = 348.00m, Cliente = new Cliente { ClienteID = 4, RegiaoCliente = 101, NumCliente = 640, Razao = "JARIO ALVES DE SOUZA - ME", Sigla = "", Rota = 0, CNPJ = "11.338.187/0001-54", IE = "001500.653/0006", Situacao = ""}, Itens = new List<Item>
{ new Item { ItemID = 28, Produto = new Produto { ProdutoID = 28, Codigo = 900089, Descricao = "", Peso = 0m, Preco = 0m, Unidades = 0 }, Quantidade = 20, ValorUnid = 1740.00m, ValorTotal = 34800.00m } },
}},

{ new Pedido {PedidoID= 5, NumPedido = 0, NumPedPalm = "20160611081132", NumVendedor = 308, ValorTotal = 273.22m, Cliente = new Cliente { ClienteID = 5, RegiaoCliente = 101, NumCliente = 936, Razao = "MERCEARIA MAR E TERRA LTDA - M", Sigla = "", Rota = 0, CNPJ = "05.747.617/0001-99", IE = "333239.632/0013", Situacao = ""}, Itens = new List<Item>
{ new Item { ItemID = 29, Produto = new Produto { ProdutoID = 29, Codigo = 900032, Descricao = "", Peso = 0m, Preco = 0m, Unidades = 0 }, Quantidade = 1, ValorUnid = 1420.00m, ValorTotal = 1420.00m },
{ new Item { ItemID = 30, Produto = new Produto { ProdutoID = 30, Codigo = 900089, Descricao = "", Peso = 0m, Preco = 0m, Unidades = 0 }, Quantidade = 4, ValorUnid = 1830.00m, ValorTotal = 7320.00m } },
{ new Item { ItemID = 31, Produto = new Produto { ProdutoID = 31, Codigo = 900362, Descricao = "", Peso = 0m, Preco = 0m, Unidades = 0 }, Quantidade = 1, ValorUnid = 2040.00m, ValorTotal = 2040.00m } },
{ new Item { ItemID = 32, Produto = new Produto { ProdutoID = 32, Codigo = 902410, Descricao = "", Peso = 0m, Preco = 0m, Unidades = 0 }, Quantidade = 3, ValorUnid = 2360.00m, ValorTotal = 7080.00m } },
{ new Item { ItemID = 33, Produto = new Produto { ProdutoID = 33, Codigo = 902430, Descricao = "", Peso = 0m, Preco = 0m, Unidades = 0 }, Quantidade = 1, ValorUnid = 2400.00m, ValorTotal = 2400.00m } },
{ new Item { ItemID = 34, Produto = new Produto { ProdutoID = 34, Codigo = 902817, Descricao = "", Peso = 0m, Preco = 0m, Unidades = 0 }, Quantidade = 2, ValorUnid = 1930.00m, ValorTotal = 3860.00m } },
{ new Item { ItemID = 35, Produto = new Produto { ProdutoID = 35, Codigo = 903122, Descricao = "", Peso = 0m, Preco = 0m, Unidades = 0 }, Quantidade = 1, ValorUnid = 2040.00m, ValorTotal = 2040.00m } },
{ new Item { ItemID = 36, Produto = new Produto { ProdutoID = 36, Codigo = 903190, Descricao = "", Peso = 0m, Preco = 0m, Unidades = 0 }, Quantidade = 1, ValorUnid = 1040.00m, ValorTotal = 1040.00m } },
}}},

{ new Pedido {PedidoID= 6, NumPedido = 0, NumPedPalm = "20160611084522", NumVendedor = 308, ValorTotal = 983.85m, Cliente = new Cliente { ClienteID = 6, RegiaoCliente = 101, NumCliente = 958, Razao = "MERCEARIA E PADARIA UNIAO LTDA", Sigla = "", Rota = 0, CNPJ = "07.033.037/0001-65", IE = "034175.800/0028", Situacao = ""}, Itens = new List<Item>
{ new Item { ItemID = 37, Produto = new Produto { ProdutoID = 37, Codigo = 900023, Descricao = "", Peso = 0m, Preco = 0m, Unidades = 0 }, Quantidade = 1, ValorUnid = 1150.00m, ValorTotal = 1150.00m },
{ new Item { ItemID = 38, Produto = new Produto { ProdutoID = 38, Codigo = 900089, Descricao = "", Peso = 0m, Preco = 0m, Unidades = 0 }, Quantidade = 30, ValorUnid = 1740.00m, ValorTotal = 52200.00m } },
{ new Item { ItemID = 39, Produto = new Produto { ProdutoID = 39, Codigo = 900350, Descricao = "", Peso = 0m, Preco = 0m, Unidades = 0 }, Quantidade = 2, ValorUnid = 1850.00m, ValorTotal = 3700.00m } },
{ new Item { ItemID = 40, Produto = new Produto { ProdutoID = 40, Codigo = 902780, Descricao = "", Peso = 0m, Preco = 0m, Unidades = 0 }, Quantidade = 5, ValorUnid = 1850.00m, ValorTotal = 9250.00m } },
{ new Item { ItemID = 41, Produto = new Produto { ProdutoID = 41, Codigo = 902795, Descricao = "", Peso = 0m, Preco = 0m, Unidades = 0 }, Quantidade = 5, ValorUnid = 1850.00m, ValorTotal = 9250.00m } },
{ new Item { ItemID = 42, Produto = new Produto { ProdutoID = 42, Codigo = 902802, Descricao = "", Peso = 0m, Preco = 0m, Unidades = 0 }, Quantidade = 2, ValorUnid = 1850.00m, ValorTotal = 3700.00m } },
{ new Item { ItemID = 43, Produto = new Produto { ProdutoID = 43, Codigo = 902809, Descricao = "", Peso = 0m, Preco = 0m, Unidades = 0 }, Quantidade = 5, ValorUnid = 1850.00m, ValorTotal = 9250.00m } },
{ new Item { ItemID = 44, Produto = new Produto { ProdutoID = 44, Codigo = 902815, Descricao = "", Peso = 0m, Preco = 0m, Unidades = 0 }, Quantidade = 2, ValorUnid = 1850.00m, ValorTotal = 3700.00m } },
{ new Item { ItemID = 45, Produto = new Produto { ProdutoID = 45, Codigo = 902817, Descricao = "", Peso = 0m, Preco = 0m, Unidades = 0 }, Quantidade = 3, ValorUnid = 1850.00m, ValorTotal = 5550.00m } },
}}},

{ new Pedido {PedidoID= 7, NumPedido = 0, NumPedPalm = "20160611080243", NumVendedor = 308, ValorTotal = 292.01m, Cliente = new Cliente { ClienteID = 7, RegiaoCliente = 101, NumCliente = 1537, Razao = "ALEXANDRE BORGES GUIMARAES - M", Sigla = "", Rota = 0, CNPJ = "08.297.701/0001-46", IE = "001021.903/0090", Situacao = ""}, Itens = new List<Item>
{ new Item { ItemID = 46, Produto = new Produto { ProdutoID = 46, Codigo = 900032, Descricao = "", Peso = 0m, Preco = 0m, Unidades = 0 }, Quantidade = 3, ValorUnid = 1420.00m, ValorTotal = 4260.00m },
{ new Item { ItemID = 47, Produto = new Produto { ProdutoID = 47, Codigo = 900089, Descricao = "", Peso = 0m, Preco = 0m, Unidades = 0 }, Quantidade = 3, ValorUnid = 1830.00m, ValorTotal = 5490.00m } },
{ new Item { ItemID = 48, Produto = new Produto { ProdutoID = 48, Codigo = 902417, Descricao = "", Peso = 0m, Preco = 0m, Unidades = 0 }, Quantidade = 1, ValorUnid = 1530.00m, ValorTotal = 1530.00m } },
{ new Item { ItemID = 49, Produto = new Produto { ProdutoID = 49, Codigo = 902430, Descricao = "", Peso = 0m, Preco = 0m, Unidades = 0 }, Quantidade = 2, ValorUnid = 2400.00m, ValorTotal = 4800.00m } },
{ new Item { ItemID = 50, Produto = new Produto { ProdutoID = 50, Codigo = 902780, Descricao = "", Peso = 0m, Preco = 0m, Unidades = 0 }, Quantidade = 1, ValorUnid = 1930.00m, ValorTotal = 1930.00m } },
{ new Item { ItemID = 51, Produto = new Produto { ProdutoID = 51, Codigo = 902817, Descricao = "", Peso = 0m, Preco = 0m, Unidades = 0 }, Quantidade = 2, ValorUnid = 1930.00m, ValorTotal = 3860.00m } },
{ new Item { ItemID = 52, Produto = new Produto { ProdutoID = 52, Codigo = 903122, Descricao = "", Peso = 0m, Preco = 0m, Unidades = 0 }, Quantidade = 2, ValorUnid = 2040.00m, ValorTotal = 4080.00m } },
{ new Item { ItemID = 53, Produto = new Produto { ProdutoID = 53, Codigo = 903189, Descricao = "", Peso = 0m, Preco = 0m, Unidades = 0 }, Quantidade = 1, ValorUnid = 1040.00m, ValorTotal = 1040.00m } },
{ new Item { ItemID = 54, Produto = new Produto { ProdutoID = 54, Codigo = 903190, Descricao = "", Peso = 0m, Preco = 0m, Unidades = 0 }, Quantidade = 1, ValorUnid = 1040.00m, ValorTotal = 1040.00m } },
{ new Item { ItemID = 55, Produto = new Produto { ProdutoID = 55, Codigo = 903201, Descricao = "", Peso = 0m, Preco = 0m, Unidades = 0 }, Quantidade = 1, ValorUnid = 1040.00m, ValorTotal = 1040.00m } },
}}},

{ new Pedido {PedidoID= 8, NumPedido = 0, NumPedPalm = "20160611073614", NumVendedor = 308, ValorTotal = 156.00m, Cliente = new Cliente { ClienteID = 8, RegiaoCliente = 101, NumCliente = 1686, Razao = "EVANILDA GONCALVES DA SILVA", Sigla = "", Rota = 0, CNPJ = "65.937.076/0000-00", IE = "11057215", Situacao = ""}, Itens = new List<Item>
{ new Item { ItemID = 56, Produto = new Produto { ProdutoID = 56, Codigo = 900032, Descricao = "", Peso = 0m, Preco = 0m, Unidades = 0 }, Quantidade = 1, ValorUnid = 1420.00m, ValorTotal = 1420.00m },
{ new Item { ItemID = 57, Produto = new Produto { ProdutoID = 57, Codigo = 900362, Descricao = "", Peso = 0m, Preco = 0m, Unidades = 0 }, Quantidade = 1, ValorUnid = 2040.00m, ValorTotal = 2040.00m } },
{ new Item { ItemID = 58, Produto = new Produto { ProdutoID = 58, Codigo = 900368, Descricao = "", Peso = 0m, Preco = 0m, Unidades = 0 }, Quantidade = 1, ValorUnid = 2040.00m, ValorTotal = 2040.00m } },
{ new Item { ItemID = 59, Produto = new Produto { ProdutoID = 59, Codigo = 902372, Descricao = "", Peso = 0m, Preco = 0m, Unidades = 0 }, Quantidade = 1, ValorUnid = 5000.00m, ValorTotal = 5000.00m } },
{ new Item { ItemID = 60, Produto = new Produto { ProdutoID = 60, Codigo = 902417, Descricao = "", Peso = 0m, Preco = 0m, Unidades = 0 }, Quantidade = 2, ValorUnid = 1530.00m, ValorTotal = 3060.00m } },
{ new Item { ItemID = 61, Produto = new Produto { ProdutoID = 61, Codigo = 903122, Descricao = "", Peso = 0m, Preco = 0m, Unidades = 0 }, Quantidade = 1, ValorUnid = 2040.00m, ValorTotal = 2040.00m } },
}}},


}
                }
            };
        }
    }
}
