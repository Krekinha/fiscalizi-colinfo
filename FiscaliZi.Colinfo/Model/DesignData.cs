using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using FiscaliZi.Colinfo.Utils;

namespace FiscaliZi.Colinfo.Model
{
    public class DesignData
    {
        public DesignData()
        {
            Arquivos = GetArquivos();
            Vendas = GetVendas2();
            Pedido = GetPedido();
            Pedidos = GetPedidos();
            Pedidos2 = GetPedidos2();
        }



        public ObservableCollection<Arquivo> Arquivos { get; set; }
        public ObservableCollection<Venda> Vendas { get; set; }
        public ObservableCollection<Pedido> Pedidos { get; set; }
        public List<Pedido> Pedidos2 { get; set; }

        public Pedido Pedido { get; set; }

        public ObservableCollection<Arquivo> GetArquivos()
        {
            return new ObservableCollection<Arquivo>
            {
                new Arquivo
                {
                    ArquivoID = 1,
                    CodVendedor = 307,
                    DataColeta = DateTime.Now,
                    DataEnvio = DateTime.Parse("03/05/2000 00:00:00"),
                    NomeVendedor = "RAFAEL ALVES",
                    ArquivoVendedor = "TXAA0600000307.TXT",
                    Pedidos = new List<Pedido>
                    {
                        new Pedido
                        {
                            PedidoID = 1,
                            NumPedido = "0",
                            NumPedPalm = "20160611102653",
                            CodVendedor = 307,
                            ValorTotalPed = 645.10m,
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
                                Situacao = "REJEIÇÃO"
                            },
                            Items = new List<Item>
                            {
                                new Item
                                {
                                    ItemID = 1,
                                    Produto = new Produto{Codigo = "900089"},
                                    QntCX = 5,
                                    ValorUnid = 1830.00m,
                                    ValorTotal = 9150.00m
                                },
                                {
                                    new Item
                                    {
                                        ItemID = 2,
                                        Produto = new Produto{Codigo = "900090"},
                                        QntCX = 2,
                                        ValorUnid = 5800.00m,
                                        ValorTotal = 11600.00m
                                    }
                                },
                                {
                                    new Item
                                    {
                                        ItemID = 3,
                                        Produto = new Produto{Codigo = "900350"},
                                        QntCX = 1,
                                        ValorUnid = 1850.00m,
                                        ValorTotal = 1850.00m
                                    }
                                },
                                {
                                    new Item
                                    {
                                        ItemID = 4,
                                        Produto = new Produto{Codigo = "902410"},
                                        QntCX = 2,
                                        ValorUnid = 2360.00m,
                                        ValorTotal = 4720.00m
                                    }
                                },
                                {
                                    new Item
                                    {
                                        ItemID = 5,
                                        Produto = new Produto{Codigo = "902780"},
                                        QntCX = 6,
                                        ValorUnid = 1850.00m,
                                        ValorTotal = 11100.00m
                                    }
                                },
                                {
                                    new Item
                                    {
                                        ItemID = 6,
                                        Produto = new Produto{Codigo = "902795"},
                                        QntCX = 3,
                                        ValorUnid = 1850.00m,
                                        ValorTotal = 5550.00m
                                    }
                                },
                                {
                                    new Item
                                    {
                                        ItemID = 7,
                                        Produto = new Produto{Codigo = "902802"},
                                        QntCX = 2,
                                        ValorUnid = 1850.00m,
                                        ValorTotal = 3700.00m
                                    }
                                },
                                {
                                    new Item
                                    {
                                        ItemID = 8,
                                        Produto = new Produto{Codigo = "902809"},
                                        QntCX = 4,
                                        ValorUnid = 1850.00m,
                                        ValorTotal = 7400.00m
                                    }
                                },
                                {
                                    new Item
                                    {
                                        ItemID = 9,
                                        Produto = new Produto{Codigo = "902815"},
                                        QntCX = 2,
                                        ValorUnid = 1850.00m,
                                        ValorTotal = 3700.00m
                                    }
                                },
                                {
                                    new Item
                                    {
                                        ItemID = 10,
                                        Produto = new Produto{Codigo = "902817"},
                                        QntCX = 2,
                                        ValorUnid = 1850.00m,
                                        ValorTotal = 3700.00m
                                    }
                                },
                                {
                                    new Item
                                    {
                                        ItemID = 11,
                                        Produto = new Produto{Codigo = "903122"},
                                        QntCX = 1,
                                        ValorUnid = 2040.00m,
                                        ValorTotal = 2040.00m
                                    }
                                },
                            }
                        },
                        new Pedido
                        {
                            PedidoID = 2,
                            NumPedido = "0",
                            NumPedPalm = "20160611092020",
                            CodVendedor = 307,
                            ValorTotalPed = 426.00m,
                            Cliente = new Cliente
                            {
                                ClienteID = 2,
                                RegiaoCliente = 101,
                                NumCliente = 596,
                                Razao = "ROMUALDO ANTUNES PEREIRA - ME",
                                Sigla = "",
                                Rota = 0,
                                CNPJ = "00.395.494/0001-50",
                                IE = "333919.491/0096",
                                Situacao = ""
                            },
                            Items = new List<Item>
                            {
                                new Item
                                {
                                    ItemID = 12,
                                    Produto = new Produto{Codigo = "900416"},
                                    QntCX = 20,
                                    ValorUnid = 2130.00m,
                                    ValorTotal = 42600.00m
                                }
                            },
                        },
                        new Pedido
                        {
                            PedidoID = 3,
                            NumPedido = "0",
                            NumPedPalm = "20160611074516",
                            CodVendedor = 307,
                            ValorTotalPed = 2249.88m,
                            Cliente =
                                new Cliente
                                {
                                    ClienteID = 3,
                                    RegiaoCliente = 101,
                                    NumCliente = 629,
                                    Razao = "SUPERMERCADO COSTA E FARIAS LT",
                                    Sigla = "",
                                    Rota = 0,
                                    CNPJ = "00.705.844/0001-38",
                                    IE = "333937.442/0003",
                                    Situacao = ""
                                },
                            Items = new List<Item>
                            {
                                new Item
                                {
                                    ItemID = 13,
                                    Produto = new Produto{Codigo = "900032"},
                                    QntCX = 2,
                                    ValorUnid = 1420.00m,
                                    ValorTotal = 2840.00m
                                },
                                {
                                    new Item
                                    {
                                        ItemID = 14,
                                        Produto = new Produto{Codigo = "900320"},
                                        QntCX = 3,
                                        ValorUnid = 1850.00m,
                                        ValorTotal = 5550.00m
                                    }
                                },
                                {
                                    new Item
                                    {
                                        ItemID = 15,
                                        Produto = new Produto{Codigo = "900350"},
                                        QntCX = 3,
                                        ValorUnid = 1850.00m,
                                        ValorTotal = 5550.00m
                                    }
                                },
                                {
                                    new Item
                                    {
                                        ItemID = 16,
                                        Produto = new Produto{Codigo = "902900362410"},
                                        QntCX = 1,
                                        ValorUnid = 2040.00m,
                                        ValorTotal = 2040.00m
                                    }
                                },
                                {
                                    new Item
                                    {
                                        ItemID = 17,
                                        Produto = new Produto{Codigo = "900416"},
                                        QntCX = 50,
                                        ValorUnid = 2130.00m,
                                        ValorTotal = 106500.00m
                                    }
                                },
                                {
                                    new Item
                                    {
                                        ItemID = 18,
                                        Produto = new Produto{Codigo = "902410"},
                                        QntCX = 10,
                                        ValorUnid = 2360.00m,
                                        ValorTotal = 23600.00m
                                    }
                                },
                                {
                                    new Item
                                    {
                                        ItemID = 19,
                                        Produto = new Produto{Codigo = "902417"},
                                        QntCX = 2,
                                        ValorUnid = 1629.00m,
                                        ValorTotal = 3258.00m
                                    }
                                },
                                {
                                    new Item
                                    {
                                        ItemID = 20,
                                        Produto = new Produto{Codigo = "902430"},
                                        QntCX = 3,
                                        ValorUnid = 2400.00m,
                                        ValorTotal = 7200.00m
                                    }
                                },
                                {
                                    new Item
                                    {
                                        ItemID = 21,
                                        Produto = new Produto{Codigo = "902778"},
                                        QntCX = 3,
                                        ValorUnid = 1850.00m,
                                        ValorTotal = 5550.00m
                                    }
                                },
                                {
                                    new Item
                                    {
                                        ItemID = 22,
                                        Produto = new Produto{Codigo = "902780"},
                                        QntCX = 5,
                                        ValorUnid = 1850.00m,
                                        ValorTotal = 9250.00m
                                    }
                                },
                                {
                                    new Item
                                    {
                                        ItemID = 23,
                                        Produto = new Produto{Codigo = "900416"},
                                        QntCX = 10,
                                        ValorUnid = 1850.00m,
                                        ValorTotal = 18500.00m
                                    }
                                },
                                {
                                    new Item
                                    {
                                        ItemID = 24,
                                        Produto = new Produto{Codigo = "902802"},
                                        QntCX = 1,
                                        ValorUnid = 1850.00m,
                                        ValorTotal = 1850.00m
                                    }
                                },
                                {
                                    new Item
                                    {
                                        ItemID = 25,
                                        Produto = new Produto{Codigo = "902809"},
                                        QntCX = 10,
                                        ValorUnid = 1850.00m,
                                        ValorTotal = 18500.00m
                                    }
                                },
                                {
                                    new Item
                                    {
                                        ItemID = 26,
                                        Produto = new Produto{Codigo = "902815"},
                                        QntCX = 3,
                                        ValorUnid = 1850.00m,
                                        ValorTotal = 5550.00m
                                    }
                                },
                                {
                                    new Item
                                    {
                                        ItemID = 27,
                                        Produto = new Produto{Codigo = "902817"},
                                        QntCX = 5,
                                        ValorUnid = 1850.00m,
                                        ValorTotal = 9250.00m
                                    }
                                },
                            }
                        },
                        new Pedido
                        {
                            PedidoID = 4,
                            NumPedido = "0",
                            NumPedPalm = "20160611110832",
                            CodVendedor = 307,
                            ValorTotalPed = 348.00m,
                            Cliente =
                                new Cliente
                                {
                                    ClienteID = 4,
                                    RegiaoCliente = 101,
                                    NumCliente = 640,
                                    Razao = "JARIO ALVES DE SOUZA - ME",
                                    Sigla = "",
                                    Rota = 0,
                                    CNPJ = "11.338.187/0001-54",
                                    IE = "001500.653/0006",
                                    Situacao = ""
                                },
                            Items = new List<Item>
                            {
                                new Item
                                {
                                    ItemID = 28,
                                    Produto = new Produto{Codigo = "900089"},
                                    QntCX = 20,
                                    ValorUnid = 1740.00m,
                                    ValorTotal = 34800.00m
                                }
                            },
                        },
                        new Pedido
                        {
                            PedidoID = 5,
                            NumPedido = "0",
                            NumPedPalm = "20160611081132",
                            CodVendedor = 307,
                            ValorTotalPed = 273.22m,
                            Cliente =
                                new Cliente
                                {
                                    ClienteID = 5,
                                    RegiaoCliente = 101,
                                    NumCliente = 936,
                                    Razao = "MERCEARIA MAR E TERRA LTDA - M",
                                    Sigla = "",
                                    Rota = 0,
                                    CNPJ = "05.747.617/0001-99",
                                    IE = "333239.632/0013",
                                    Situacao = ""
                                },
                            Items = new List<Item>
                            {
                                new Item
                                {
                                    ItemID = 29,
                                    Produto = new Produto{Codigo = "900032"},
                                    QntCX = 1,
                                    ValorUnid = 1420.00m,
                                    ValorTotal = 1420.00m
                                },
                                {
                                    new Item
                                    {
                                        ItemID = 30,
                                        Produto = new Produto{Codigo = "900089"},
                                        QntCX = 4,
                                        ValorUnid = 1830.00m,
                                        ValorTotal = 7320.00m
                                    }
                                },
                                {
                                    new Item
                                    {
                                        ItemID = 31,
                                        Produto = new Produto{Codigo = "900362"},
                                        QntCX = 1,
                                        ValorUnid = 2040.00m,
                                        ValorTotal = 2040.00m
                                    }
                                },
                                {
                                    new Item
                                    {
                                        ItemID = 32,
                                        Produto = new Produto{Codigo = "902410"},
                                        QntCX = 3,
                                        ValorUnid = 2360.00m,
                                        ValorTotal = 7080.00m
                                    }
                                },
                                {
                                    new Item
                                    {
                                        ItemID = 33,
                                        Produto = new Produto{Codigo = "902430"},
                                        QntCX = 1,
                                        ValorUnid = 2400.00m,
                                        ValorTotal = 2400.00m
                                    }
                                },
                                {
                                    new Item
                                    {
                                        ItemID = 34,
                                        Produto = new Produto{Codigo = "902817"},
                                        QntCX = 2,
                                        ValorUnid = 1930.00m,
                                        ValorTotal = 3860.00m
                                    }
                                },
                                {
                                    new Item
                                    {
                                        ItemID = 35,
                                        Produto = new Produto{Codigo = "903122"},
                                        QntCX = 1,
                                        ValorUnid = 2040.00m,
                                        ValorTotal = 2040.00m
                                    }
                                },
                                {
                                    new Item
                                    {
                                        ItemID = 36,
                                        Produto = new Produto{Codigo = "903190"},
                                        QntCX = 1,
                                        ValorUnid = 1040.00m,
                                        ValorTotal = 1040.00m
                                    }
                                },
                            }
                        },
                        new Pedido
                        {
                            PedidoID = 6,
                            NumPedido = "0",
                            NumPedPalm = "20160611084522",
                            CodVendedor = 307,
                            ValorTotalPed = 983.85m,
                            Cliente =
                                new Cliente
                                {
                                    ClienteID = 6,
                                    RegiaoCliente = 101,
                                    NumCliente = 958,
                                    Razao = "MERCEARIA E PADARIA UNIAO LTDA",
                                    Sigla = "",
                                    Rota = 0,
                                    CNPJ = "07.033.037/0001-65",
                                    IE = "034175.800/0028",
                                    Situacao = ""
                                },
                            Items = new List<Item>
                            {
                                new Item
                                {
                                    ItemID = 37,
                                    Produto = new Produto{Codigo = "900023"},
                                    QntCX = 1,
                                    ValorUnid = 1150.00m,
                                    ValorTotal = 1150.00m
                                },
                                {
                                    new Item
                                    {
                                        ItemID = 38,
                                        Produto = new Produto{Codigo = "900089"},
                                        QntCX = 30,
                                        ValorUnid = 1740.00m,
                                        ValorTotal = 52200.00m
                                    }
                                },
                                {
                                    new Item
                                    {
                                        ItemID = 39,
                                        Produto = new Produto{Codigo = "900350"},
                                        QntCX = 2,
                                        ValorUnid = 1850.00m,
                                        ValorTotal = 3700.00m
                                    }
                                },
                                {
                                    new Item
                                    {
                                        ItemID = 40,
                                        Produto = new Produto{Codigo = "902780"},
                                        QntCX = 5,
                                        ValorUnid = 1850.00m,
                                        ValorTotal = 9250.00m
                                    }
                                },
                                {
                                    new Item
                                    {
                                        ItemID = 41,
                                        Produto = new Produto{Codigo = "902795"},
                                        QntCX = 5,
                                        ValorUnid = 1850.00m,
                                        ValorTotal = 9250.00m
                                    }
                                },
                                {
                                    new Item
                                    {
                                        ItemID = 42,
                                        Produto = new Produto{Codigo = "902802"},
                                        QntCX = 2,
                                        ValorUnid = 1850.00m,
                                        ValorTotal = 3700.00m
                                    }
                                },
                                {
                                    new Item
                                    {
                                        ItemID = 43,
                                        Produto = new Produto{Codigo = "902809"},
                                        QntCX = 5,
                                        ValorUnid = 1850.00m,
                                        ValorTotal = 9250.00m
                                    }
                                },
                                {
                                    new Item
                                    {
                                        ItemID = 44,
                                        Produto = new Produto{Codigo = "902815"},
                                        QntCX = 2,
                                        ValorUnid = 1850.00m,
                                        ValorTotal = 3700.00m
                                    }
                                },
                                {
                                    new Item
                                    {
                                        ItemID = 45,
                                        Produto = new Produto{Codigo = "902817"},
                                        QntCX = 3,
                                        ValorUnid = 1850.00m,
                                        ValorTotal = 5550.00m
                                    }
                                },
                            }
                        },
                        new Pedido
                        {
                            PedidoID = 7,
                            NumPedido = "0",
                            NumPedPalm = "20160611080243",
                            CodVendedor = 307,
                            ValorTotalPed = 292.01m,
                            Cliente =
                                new Cliente
                                {
                                    ClienteID = 7,
                                    RegiaoCliente = 101,
                                    NumCliente = 1537,
                                    Razao = "ALEXANDRE BORGES GUIMARAES - M",
                                    Sigla = "",
                                    Rota = 0,
                                    CNPJ = "08.297.701/0001-46",
                                    IE = "001021.903/0090",
                                    Situacao = ""
                                },
                            Items = new List<Item>
                            {
                                new Item
                                {
                                    ItemID = 46,
                                    Produto = new Produto{Codigo = "900032"},
                                    QntCX = 3,
                                    ValorUnid = 1420.00m,
                                    ValorTotal = 4260.00m
                                },
                                {
                                    new Item
                                    {
                                        ItemID = 47,
                                        Produto = new Produto{Codigo = "900089"},
                                        QntCX = 3,
                                        ValorUnid = 1830.00m,
                                        ValorTotal = 5490.00m
                                    }
                                },
                                {
                                    new Item
                                    {
                                        ItemID = 48,
                                        Produto = new Produto{Codigo = "902417"},
                                        QntCX = 1,
                                        ValorUnid = 1530.00m,
                                        ValorTotal = 1530.00m
                                    }
                                },
                                {
                                    new Item
                                    {
                                        ItemID = 49,
                                        Produto = new Produto{Codigo = "902430"},
                                        QntCX = 2,
                                        ValorUnid = 2400.00m,
                                        ValorTotal = 4800.00m
                                    }
                                },
                                {
                                    new Item
                                    {
                                        ItemID = 50,
                                        Produto = new Produto{Codigo = "902780"},
                                        QntCX = 1,
                                        ValorUnid = 1930.00m,
                                        ValorTotal = 1930.00m
                                    }
                                },
                                {
                                    new Item
                                    {
                                        ItemID = 51,
                                        Produto = new Produto{Codigo = "902817"},
                                        QntCX = 2,
                                        ValorUnid = 1930.00m,
                                        ValorTotal = 3860.00m
                                    }
                                },
                                {
                                    new Item
                                    {
                                        ItemID = 52,
                                        Produto = new Produto{Codigo = "903122"},
                                        QntCX = 2,
                                        ValorUnid = 2040.00m,
                                        ValorTotal = 4080.00m
                                    }
                                },
                                {
                                    new Item
                                    {
                                        ItemID = 53,
                                        Produto = new Produto{Codigo = "903189"},
                                        QntCX = 1,
                                        ValorUnid = 1040.00m,
                                        ValorTotal = 1040.00m
                                    }
                                },
                                {
                                    new Item
                                    {
                                        ItemID = 54,
                                        Produto = new Produto{Codigo = "903190"},
                                        QntCX = 1,
                                        ValorUnid = 1040.00m,
                                        ValorTotal = 1040.00m
                                    }
                                },
                                {
                                    new Item
                                    {
                                        ItemID = 55,
                                        Produto = new Produto{Codigo = "903201"},
                                        QntCX = 1,
                                        ValorUnid = 1040.00m,
                                        ValorTotal = 1040.00m
                                    }
                                },
                            }
                        },
                        new Pedido
                        {
                            PedidoID = 8,
                            NumPedido = "0",
                            NumPedPalm = "20160611073614",
                            CodVendedor = 307,
                            ValorTotalPed = 156.00m,
                            Cliente =
                                new Cliente
                                {
                                    ClienteID = 8,
                                    RegiaoCliente = 101,
                                    NumCliente = 1686,
                                    Razao = "EVANILDA GONCALVES DA SILVA",
                                    Sigla = "",
                                    Rota = 0,
                                    CNPJ = "65.937.076/0000-00",
                                    IE = "11057215",
                                    Situacao = ""
                                },
                            Items = new List<Item>
                            {
                                new Item
                                {
                                    ItemID = 56,
                                    Produto = new Produto{Codigo = "900032"},
                                    QntCX = 1,
                                    ValorUnid = 1420.00m,
                                    ValorTotal = 1420.00m
                                },
                                {
                                    new Item
                                    {
                                        ItemID = 57,
                                        Produto = new Produto{Codigo = "900362"},
                                        QntCX = 1,
                                        ValorUnid = 2040.00m,
                                        ValorTotal = 2040.00m
                                    }
                                },
                                {
                                    new Item
                                    {
                                        ItemID = 58,
                                        Produto = new Produto{Codigo = "900368"},
                                        QntCX = 1,
                                        ValorUnid = 2040.00m,
                                        ValorTotal = 2040.00m
                                    }
                                },
                                {
                                    new Item
                                    {
                                        ItemID = 59,
                                        Produto = new Produto{Codigo = "902372"},
                                        QntCX = 1,
                                        ValorUnid = 5000.00m,
                                        ValorTotal = 5000.00m
                                    }
                                },
                                {
                                    new Item
                                    {
                                        ItemID = 60,
                                        Produto = new Produto{Codigo = "902417"},
                                        QntCX = 2,
                                        ValorUnid = 1530.00m,
                                        ValorTotal = 3060.00m
                                    }
                                },
                                {
                                    new Item
                                    {
                                        ItemID = 61,
                                        Produto = new Produto{Codigo = "903122"},
                                        QntCX = 1,
                                        ValorUnid = 2040.00m,
                                        ValorTotal = 2040.00m
                                    }
                                },
                            }
                        }
                    }
                }
            };
        }
        public ObservableCollection<Venda> GetVendas(int _regs)
        {
            var vnds = new ObservableCollection<Venda>();
            var vnd = new Venda
            {
                VendaID = 1,
                CodVendedor = 307,
                DataColeta = DateTime.Now,
                Pedidos = new List<Pedido>
                {
                    new Pedido
                    {
                        PedidoID = 1,
                        NumPedido = "000000000370",
                        NumPedPalm = "20160611102653",
                        CodVendedor = 307,
                        Pasta = "3071",
                        ValorTotalPed = 645.10m,
                        TipoPgt = 4,
                        PrazoPgt = 34,
                        ADFinanceiro = 1.70m,
                        Cliente = new Cliente
                        {
                            ClienteID = 1,
                            RegiaoCliente = 101,
                            NumCliente = 28,
                            Razao = "SILVIO BATISTA ALVES - ME",
                            Sigla = "SUP. AVENIDA",
                            Rota = 1,
                            CNPJ = "64.436.249/0001-27",
                            IE = "333647.589/0096",
                            Situacao = "REJEIÇÃO",
                            Endereco = new Endereco
                            {
                                xTPLgr = "RUA",
                                xPrepLgr = "DA",
                                xLgr = "AMIZADE",
                                nro = "37",
                                xBairro = "INOCOP",
                                xMun = "MEDINA",
                                cMun = "MG",
                                CEP = "39630000"
                            }
                        },
                        Items = new List<Item>
                        {
                            new Item
                            {
                                ItemID = 1,
                                Produto =
                                    new Produto
                                    {
                                        Codigo = "900089",
                                        Descricao = "REFR SCHIN GUARN VIVA 0,350LT DES12UNPBR"
                                    },
                                QntCX = 5,
                                ValorUnid = 1830.00m,
                                ValorTotal = 9150.00m,
                                Ocorrencia = "001",
                                Tabela = "20170304"
                            },
                            {
                                new Item
                                {
                                    ItemID = 2,
                                    Produto =
                                        new Produto {Codigo = "902410", Descricao = "CERV SCHIN PILS 0,60LGFA 24UN"},
                                    QntCX = 2,
                                    ValorUnid = 5800.00m,
                                    ValorTotal = 11600.00m,
                                    Ocorrencia = "004",
                                    Tabela = "20170314"
                                }
                            },
                            {
                                new Item
                                {
                                    ItemID = 3,
                                    Produto = new Produto {Codigo = "900350"},
                                    QntCX = 1,
                                    ValorUnid = 1850.00m,
                                    ValorTotal = 1850.00m
                                }
                            },
                            {
                                new Item
                                {
                                    ItemID = 4,
                                    Produto = new Produto {Codigo = "902410"},
                                    QntCX = 2,
                                    ValorUnid = 2360.00m,
                                    ValorTotal = 4720.00m
                                }
                            },
                            {
                                new Item
                                {
                                    ItemID = 5,
                                    Produto = new Produto {Codigo = "902780"},
                                    QntCX = 6,
                                    ValorUnid = 1850.00m,
                                    ValorTotal = 11100.00m
                                }
                            },
                            {
                                new Item
                                {
                                    ItemID = 6,
                                    Produto = new Produto {Codigo = "902795"},
                                    QntCX = 3,
                                    ValorUnid = 1850.00m,
                                    ValorTotal = 5550.00m
                                }
                            },
                            {
                                new Item
                                {
                                    ItemID = 7,
                                    Produto = new Produto {Codigo = "902802"},
                                    QntCX = 2,
                                    ValorUnid = 1850.00m,
                                    ValorTotal = 3700.00m
                                }
                            },
                            {
                                new Item
                                {
                                    ItemID = 8,
                                    Produto = new Produto {Codigo = "902809"},
                                    QntCX = 4,
                                    ValorUnid = 1850.00m,
                                    ValorTotal = 7400.00m
                                }
                            },
                            {
                                new Item
                                {
                                    ItemID = 9,
                                    Produto = new Produto {Codigo = "902815"},
                                    QntCX = 2,
                                    ValorUnid = 1850.00m,
                                    ValorTotal = 3700.00m
                                }
                            },
                            {
                                new Item
                                {
                                    ItemID = 10,
                                    Produto = new Produto {Codigo = "902817"},
                                    QntCX = 2,
                                    ValorUnid = 1850.00m,
                                    ValorTotal = 3700.00m
                                }
                            },
                            {
                                new Item
                                {
                                    ItemID = 11,
                                    Produto = new Produto {Codigo = "903122"},
                                    QntCX = 1,
                                    ValorUnid = 2040.00m,
                                    ValorTotal = 2040.00m
                                }
                            },
                        }
                    },
                    new Pedido
                    {
                        PedidoID = 2,
                        NumPedido = "0",
                        NumPedPalm = "20160611092020",
                        CodVendedor = 307,
                        Pasta = "3071",
                        ValorTotalPed = 426.00m,
                        Cliente = new Cliente
                        {
                            ClienteID = 2,
                            RegiaoCliente = 101,
                            NumCliente = 596,
                            Razao = "ROMUALDO ANTUNES PEREIRA - ME",
                            Sigla = "",
                            Rota = 0,
                            CNPJ = "00.395.494/0001-50",
                            IE = "333919.491/0096",
                            Situacao = ""
                        },
                        Items = new List<Item>
                        {
                            new Item
                            {
                                ItemID = 12,
                                Produto = new Produto {Codigo = "900416"},
                                QntCX = 20,
                                ValorUnid = 2130.00m,
                                ValorTotal = 42600.00m
                            }
                        },
                    },
                    new Pedido
                    {
                        PedidoID = 3,
                        NumPedido = "0",
                        NumPedPalm = "20160611074516",
                        CodVendedor = 307,
                        Pasta = "33071",
                        ValorTotalPed = 2249.88m,
                        Cliente =
                            new Cliente
                            {
                                ClienteID = 3,
                                RegiaoCliente = 101,
                                NumCliente = 629,
                                Razao = "SUPERMERCADO COSTA E FARIAS LT",
                                Sigla = "",
                                Rota = 0,
                                CNPJ = "00.705.844/0001-38",
                                IE = "333937.442/0003",
                                Situacao = ""
                            },
                        Items = new List<Item>
                        {
                            new Item
                            {
                                ItemID = 13,
                                Produto = new Produto {Codigo = "900032"},
                                QntCX = 2,
                                ValorUnid = 1420.00m,
                                ValorTotal = 2840.00m
                            },
                            {
                                new Item
                                {
                                    ItemID = 14,
                                    Produto = new Produto {Codigo = "900320"},
                                    QntCX = 3,
                                    ValorUnid = 1850.00m,
                                    ValorTotal = 5550.00m
                                }
                            },
                            {
                                new Item
                                {
                                    ItemID = 15,
                                    Produto = new Produto {Codigo = "900350"},
                                    QntCX = 3,
                                    ValorUnid = 1850.00m,
                                    ValorTotal = 5550.00m
                                }
                            },
                            {
                                new Item
                                {
                                    ItemID = 16,
                                    Produto = new Produto {Codigo = "900362"},
                                    QntCX = 1,
                                    ValorUnid = 2040.00m,
                                    ValorTotal = 2040.00m
                                }
                            },
                            {
                                new Item
                                {
                                    ItemID = 17,
                                    Produto = new Produto {Codigo = "900416"},
                                    QntCX = 50,
                                    ValorUnid = 2130.00m,
                                    ValorTotal = 106500.00m
                                }
                            },
                            {
                                new Item
                                {
                                    ItemID = 18,
                                    Produto = new Produto {Codigo = "902410"},
                                    QntCX = 10,
                                    ValorUnid = 2360.00m,
                                    ValorTotal = 23600.00m
                                }
                            },
                            {
                                new Item
                                {
                                    ItemID = 19,
                                    Produto = new Produto {Codigo = "902417"},
                                    QntCX = 2,
                                    ValorUnid = 1629.00m,
                                    ValorTotal = 3258.00m
                                }
                            },
                            {
                                new Item
                                {
                                    ItemID = 20,
                                    Produto = new Produto {Codigo = "902430"},
                                    QntCX = 3,
                                    ValorUnid = 2400.00m,
                                    ValorTotal = 7200.00m
                                }
                            },
                            {
                                new Item
                                {
                                    ItemID = 21,
                                    Produto = new Produto {Codigo = "902778"},
                                    QntCX = 3,
                                    ValorUnid = 1850.00m,
                                    ValorTotal = 5550.00m
                                }
                            },
                            {
                                new Item
                                {
                                    ItemID = 22,
                                    Produto = new Produto {Codigo = "902780"},
                                    QntCX = 5,
                                    ValorUnid = 1850.00m,
                                    ValorTotal = 9250.00m
                                }
                            },
                            {
                                new Item
                                {
                                    ItemID = 23,
                                    Produto = new Produto {Codigo = "900416"},
                                    QntCX = 10,
                                    ValorUnid = 1850.00m,
                                    ValorTotal = 18500.00m
                                }
                            },
                            {
                                new Item
                                {
                                    ItemID = 24,
                                    Produto = new Produto {Codigo = "902802"},
                                    QntCX = 1,
                                    ValorUnid = 1850.00m,
                                    ValorTotal = 1850.00m
                                }
                            },
                            {
                                new Item
                                {
                                    ItemID = 25,
                                    Produto = new Produto {Codigo = "902809"},
                                    QntCX = 10,
                                    ValorUnid = 1850.00m,
                                    ValorTotal = 18500.00m
                                }
                            },
                            {
                                new Item
                                {
                                    ItemID = 26,
                                    Produto = new Produto {Codigo = "902815"},
                                    QntCX = 3,
                                    ValorUnid = 1850.00m,
                                    ValorTotal = 5550.00m
                                }
                            },
                            {
                                new Item
                                {
                                    ItemID = 27,
                                    Produto = new Produto {Codigo = "902817"},
                                    QntCX = 5,
                                    ValorUnid = 1850.00m,
                                    ValorTotal = 9250.00m
                                }
                            },
                        }
                    },
                    new Pedido
                    {
                        PedidoID = 4,
                        NumPedido = "0",
                        NumPedPalm = "20160611110832",
                        CodVendedor = 307,
                        Pasta = "3071",
                        ValorTotalPed = 348.00m,
                        Cliente =
                            new Cliente
                            {
                                ClienteID = 4,
                                RegiaoCliente = 101,
                                NumCliente = 640,
                                Razao = "JARIO ALVES DE SOUZA - ME",
                                Sigla = "",
                                Rota = 0,
                                CNPJ = "11.338.187/0001-54",
                                IE = "001500.653/0006",
                                Situacao = ""
                            },
                        Items = new List<Item>
                        {
                            new Item
                            {
                                ItemID = 28,
                                Produto = new Produto {Codigo = "900089"},
                                QntCX = 20,
                                ValorUnid = 1740.00m,
                                ValorTotal = 34800.00m
                            }
                        },
                    },
                    new Pedido
                    {
                        PedidoID = 5,
                        NumPedido = "0",
                        NumPedPalm = "20160611081132",
                        CodVendedor = 307,
                        Pasta = "3071",
                        ValorTotalPed = 273.22m,
                        Cliente =
                            new Cliente
                            {
                                ClienteID = 5,
                                RegiaoCliente = 101,
                                NumCliente = 936,
                                Razao = "MERCEARIA MAR E TERRA LTDA - M",
                                Sigla = "",
                                Rota = 0,
                                CNPJ = "05.747.617/0001-99",
                                IE = "333239.632/0013",
                                Situacao = ""
                            },
                        Items = new List<Item>
                        {
                            new Item
                            {
                                ItemID = 29,
                                Produto = new Produto {Codigo = "900032"},
                                QntCX = 1,
                                ValorUnid = 1420.00m,
                                ValorTotal = 1420.00m
                            },
                            {
                                new Item
                                {
                                    ItemID = 30,
                                    Produto = new Produto {Codigo = "900089"},
                                    QntCX = 4,
                                    ValorUnid = 1830.00m,
                                    ValorTotal = 7320.00m
                                }
                            },
                            {
                                new Item
                                {
                                    ItemID = 31,
                                    Produto = new Produto {Codigo = "900362"},
                                    QntCX = 1,
                                    ValorUnid = 2040.00m,
                                    ValorTotal = 2040.00m
                                }
                            },
                            {
                                new Item
                                {
                                    ItemID = 32,
                                    Produto = new Produto {Codigo = "902410"},
                                    QntCX = 3,
                                    ValorUnid = 2360.00m,
                                    ValorTotal = 7080.00m
                                }
                            },
                            {
                                new Item
                                {
                                    ItemID = 33,
                                    Produto = new Produto {Codigo = "902430"},
                                    QntCX = 1,
                                    ValorUnid = 2400.00m,
                                    ValorTotal = 2400.00m
                                }
                            },
                            {
                                new Item
                                {
                                    ItemID = 34,
                                    Produto = new Produto {Codigo = "902817"},
                                    QntCX = 2,
                                    ValorUnid = 1930.00m,
                                    ValorTotal = 3860.00m
                                }
                            },
                            {
                                new Item
                                {
                                    ItemID = 35,
                                    Produto = new Produto {Codigo = "903122"},
                                    QntCX = 1,
                                    ValorUnid = 2040.00m,
                                    ValorTotal = 2040.00m
                                }
                            },
                            {
                                new Item
                                {
                                    ItemID = 36,
                                    Produto = new Produto {Codigo = "903190"},
                                    QntCX = 1,
                                    ValorUnid = 1040.00m,
                                    ValorTotal = 1040.00m
                                }
                            },
                        }
                    },
                    new Pedido
                    {
                        PedidoID = 6,
                        NumPedido = "0",
                        NumPedPalm = "20160611084522",
                        CodVendedor = 307,
                        Pasta = "3071",
                        ValorTotalPed = 983.85m,
                        Cliente =
                            new Cliente
                            {
                                ClienteID = 6,
                                RegiaoCliente = 101,
                                NumCliente = 958,
                                Razao = "MERCEARIA E PADARIA UNIAO LTDA",
                                Sigla = "",
                                Rota = 0,
                                CNPJ = "07.033.037/0001-65",
                                IE = "034175.800/0028",
                                Situacao = ""
                            },
                        Items = new List<Item>
                        {
                            new Item
                            {
                                ItemID = 37,
                                Produto = new Produto {Codigo = "900023"},
                                QntCX = 1,
                                ValorUnid = 1150.00m,
                                ValorTotal = 1150.00m
                            },
                            {
                                new Item
                                {
                                    ItemID = 38,
                                    Produto = new Produto {Codigo = "900089"},
                                    QntCX = 30,
                                    ValorUnid = 1740.00m,
                                    ValorTotal = 52200.00m
                                }
                            },
                            {
                                new Item
                                {
                                    ItemID = 39,
                                    Produto = new Produto {Codigo = "900350"},
                                    QntCX = 2,
                                    ValorUnid = 1850.00m,
                                    ValorTotal = 3700.00m
                                }
                            },
                            {
                                new Item
                                {
                                    ItemID = 40,
                                    Produto = new Produto {Codigo = "902780"},
                                    QntCX = 5,
                                    ValorUnid = 1850.00m,
                                    ValorTotal = 9250.00m
                                }
                            },
                            {
                                new Item
                                {
                                    ItemID = 41,
                                    Produto = new Produto {Codigo = "902795"},
                                    QntCX = 5,
                                    ValorUnid = 1850.00m,
                                    ValorTotal = 9250.00m
                                }
                            },
                            {
                                new Item
                                {
                                    ItemID = 42,
                                    Produto = new Produto {Codigo = "902802"},
                                    QntCX = 2,
                                    ValorUnid = 1850.00m,
                                    ValorTotal = 3700.00m
                                }
                            },
                            {
                                new Item
                                {
                                    ItemID = 43,
                                    Produto = new Produto {Codigo = "902809"},
                                    QntCX = 5,
                                    ValorUnid = 1850.00m,
                                    ValorTotal = 9250.00m
                                }
                            },
                            {
                                new Item
                                {
                                    ItemID = 44,
                                    Produto = new Produto {Codigo = "902815"},
                                    QntCX = 2,
                                    ValorUnid = 1850.00m,
                                    ValorTotal = 3700.00m
                                }
                            },
                            {
                                new Item
                                {
                                    ItemID = 45,
                                    Produto = new Produto {Codigo = "902817"},
                                    QntCX = 3,
                                    ValorUnid = 1850.00m,
                                    ValorTotal = 5550.00m
                                }
                            },
                        }
                    },
                    new Pedido
                    {
                        PedidoID = 7,
                        NumPedido = "0",
                        NumPedPalm = "20160611080243",
                        CodVendedor = 307,
                        Pasta = "3071",
                        ValorTotalPed = 292.01m,
                        Cliente =
                            new Cliente
                            {
                                ClienteID = 7,
                                RegiaoCliente = 101,
                                NumCliente = 1537,
                                Razao = "ALEXANDRE BORGES GUIMARAES - M",
                                Sigla = "",
                                Rota = 0,
                                CNPJ = "08.297.701/0001-46",
                                IE = "001021.903/0090",
                                Situacao = ""
                            },
                        Items = new List<Item>
                        {
                            new Item
                            {
                                ItemID = 46,
                                Produto = new Produto {Codigo = "900032"},
                                QntCX = 3,
                                ValorUnid = 1420.00m,
                                ValorTotal = 4260.00m
                            },
                            {
                                new Item
                                {
                                    ItemID = 47,
                                    Produto = new Produto {Codigo = "900089"},
                                    QntCX = 3,
                                    ValorUnid = 1830.00m,
                                    ValorTotal = 5490.00m
                                }
                            },
                            {
                                new Item
                                {
                                    ItemID = 48,
                                    Produto = new Produto {Codigo = "902417"},
                                    QntCX = 1,
                                    ValorUnid = 1530.00m,
                                    ValorTotal = 1530.00m
                                }
                            },
                            {
                                new Item
                                {
                                    ItemID = 49,
                                    Produto = new Produto {Codigo = "902430"},
                                    QntCX = 2,
                                    ValorUnid = 2400.00m,
                                    ValorTotal = 4800.00m
                                }
                            },
                            {
                                new Item
                                {
                                    ItemID = 50,
                                    Produto = new Produto {Codigo = "902780"},
                                    QntCX = 1,
                                    ValorUnid = 1930.00m,
                                    ValorTotal = 1930.00m
                                }
                            },
                            {
                                new Item
                                {
                                    ItemID = 51,
                                    Produto = new Produto {Codigo = "902817"},
                                    QntCX = 2,
                                    ValorUnid = 1930.00m,
                                    ValorTotal = 3860.00m
                                }
                            },
                            {
                                new Item
                                {
                                    ItemID = 52,
                                    Produto = new Produto {Codigo = "903122"},
                                    QntCX = 2,
                                    ValorUnid = 2040.00m,
                                    ValorTotal = 4080.00m
                                }
                            },
                            {
                                new Item
                                {
                                    ItemID = 53,
                                    Produto = new Produto {Codigo = "903189"},
                                    QntCX = 1,
                                    ValorUnid = 1040.00m,
                                    ValorTotal = 1040.00m
                                }
                            },
                            {
                                new Item
                                {
                                    ItemID = 54,
                                    Produto = new Produto {Codigo = "903190"},
                                    QntCX = 1,
                                    ValorUnid = 1040.00m,
                                    ValorTotal = 1040.00m
                                }
                            },
                            {
                                new Item
                                {
                                    ItemID = 55,
                                    Produto = new Produto {Codigo = "903201"},
                                    QntCX = 1,
                                    ValorUnid = 1040.00m,
                                    ValorTotal = 1040.00m
                                }
                            },
                        }
                    },
                    new Pedido
                    {
                        PedidoID = 8,
                        NumPedido = "0",
                        NumPedPalm = "20160611073614",
                        CodVendedor = 307,
                        Pasta = "3071",
                        ValorTotalPed = 156.00m,
                        Cliente =
                            new Cliente
                            {
                                ClienteID = 8,
                                RegiaoCliente = 101,
                                NumCliente = 1686,
                                Razao = "EVANILDA GONCALVES DA SILVA",
                                Sigla = "",
                                Rota = 0,
                                CNPJ = "65.937.076/0000-00",
                                IE = "11057215",
                                Situacao = ""
                            },
                        Items = new List<Item>
                        {
                            new Item
                            {
                                ItemID = 56,
                                Produto = new Produto {Codigo = "900032"},
                                QntCX = 1,
                                ValorUnid = 1420.00m,
                                ValorTotal = 1420.00m
                            },
                            {
                                new Item
                                {
                                    ItemID = 57,
                                    Produto = new Produto {Codigo = "900362"},
                                    QntCX = 1,
                                    ValorUnid = 2040.00m,
                                    ValorTotal = 2040.00m
                                }
                            },
                            {
                                new Item
                                {
                                    ItemID = 58,
                                    Produto = new Produto {Codigo = "900368"},
                                    QntCX = 1,
                                    ValorUnid = 2040.00m,
                                    ValorTotal = 2040.00m
                                }
                            },
                            {
                                new Item
                                {
                                    ItemID = 59,
                                    Produto = new Produto {Codigo = "902372"},
                                    QntCX = 1,
                                    ValorUnid = 5000.00m,
                                    ValorTotal = 5000.00m
                                }
                            },
                            {
                                new Item
                                {
                                    ItemID = 60,
                                    Produto = new Produto {Codigo = "902417"},
                                    QntCX = 2,
                                    ValorUnid = 1530.00m,
                                    ValorTotal = 3060.00m
                                }
                            },
                            {
                                new Item
                                {
                                    ItemID = 61,
                                    Produto = new Produto {Codigo = "903122"},
                                    QntCX = 1,
                                    ValorUnid = 2040.00m,
                                    ValorTotal = 2040.00m
                                }
                            },
                        }
                    }
                }
            };

            for (int i = 0; i < _regs; i++)
            {
                vnds.Add(vnd);
            }
            return vnds;
        }

        private static ObservableCollection<Venda> GetVendas2()
        {

            var path = @"F:\SOF\VDWIN\EXP\PEDIDOSDUP.CSV";

            if (Environment.MachineName == "ATAIDE-PC")
                path = @"C:\Users\krekm\Desktop\PEDIDOS.CSV";

            var peds = Coletor.GetPedidos(path, new DateTime(2017,4,19));

            var vendas = new ObservableCollection<Venda>();

            foreach (var ped in peds)
            {
                var vnd = vendas.FirstOrDefault(vd => vd.CodVendedor == ped.CodVendedor);
                if (vnd == null && ped.CodVendedor != 900)
                {
                    vendas.Add(new Venda
                    {
                        CodVendedor = ped.CodVendedor,
                        DataColeta = ped.DataPedido,
                        Pedidos = new List<Pedido> { ped }
                    });
                }
                else
                {
                    if (ped.CodVendedor == 900) continue;
                    vnd.Pedidos.Add(ped);
                }
            }

            return vendas;

        }
        private Pedido GetPedido()
        {
            return new Pedido
            {
                Cliente = new Cliente
                {
                    Razao = "RESTAURANTE LEAO E CARVALHO LTDA",
                    CNPJ = "08.454.523/0001-10",
                    IE = "001022.887/0038",

                    RetConsultaCadastro = new retConsCad
                    {
                        infCons = new infCons
                        {
                            CNPJ = "08454523000110",
                            UF = "MG",
                            cStat = "111",
                            cUF = "31",
                            dhCons = "2017-02-27T19:23:54",
                            xMotivo = "Consulta cadastro com uma ocorrencia",
                            infCad = new List<infCad>
                            {
                                new infCad
                                {
                                    CNAE = "5611201",
                                    CNPJ = "08454523000110",
                                    IE = "0010228870038",
                                    IEAtual = "0010228870038",
                                    UF = "MG",
                                    cSit = "1",
                                    dIniAtiv = "2006-12-01",
                                    dBaixa = null,
                                    xFant = "RESTAURANTE E LANCHONETE CAFE PRETTO",
                                    xNome = "RESTAURANTE LEAO E CARVALHO LTDA - EPP",
                                    xRegApur = "SIMPLES NACIONAL",
                                    ender = null
                                }
                            }
                        }
                    }
                }
            };
        }
        private ObservableCollection<Pedido> GetPedidos()
        {
            var peds = new ObservableCollection<Pedido>();
            foreach (var arq in Arquivos)
            {
                foreach (var ped in arq.Pedidos)
                {
                    peds.Add(ped);
                }
            }
            return peds;
        }
        private List<Pedido> GetPedidos2()
        {
            var peds = new List<Pedido>();
            foreach (var arq in Arquivos)
            {
                foreach (var ped in arq.Pedidos)
                {
                    peds.Add(ped);
                }
            }
            return peds;
        }
    }
}