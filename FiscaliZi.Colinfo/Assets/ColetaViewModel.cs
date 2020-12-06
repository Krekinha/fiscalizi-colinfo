using System.Collections.Generic;
using Caliburn.Micro;
using FiscaliZi.Colinfo.Model;
using FiscaliZi.Colinfo.Utils;
using System.Collections.ObjectModel;
using System.Linq;
using System;
using MaterialDesignThemes.Wpf;
using System.Threading.Tasks;

namespace FiscaliZi.Colinfo.Assets
{
    public class ColetaViewModel : PropertyChangedBase
    {

        public ColetaViewModel(IEventAggregator events)
        {
            Vendas = new ObservableCollection<Venda>();
        }

        #region · Properties ·
        public ObservableCollection<Venda> Vendas { get; set; }
        #endregion
        public void AtualizaPedidos(DateTime date)
        {
            var vendstands = new int[] { 301, 302, 303, 304, 305, 306,
                                         401, 402, 403, 404, 405, 406,
                                         601, 602, 603, 604};
            var pc = Environment.MachineName;

            var path = @"F:\SOF\VDWIN\EXP\PEDIDOS.CSV";

            if (pc == "ATAIDE-PC")
                path = @"C:\Users\krekm\Desktop\PEDIDOS.CSV";
            if (pc == "KREKINHA-PC")
                path = @"C:\Users\krekm\Desktop\PEDIDOS.CSV";

            var peds = Coletor.GetPedidos(path, date);

            var vendas = new ObservableCollection<Venda>();

            if (Vendas == null)
                Vendas = new ObservableCollection<Venda>();

            if (Vendas.Count > 0)
                Vendas.Clear();

            foreach (var ped in peds)
            {
                var vnd = vendas.FirstOrDefault(vd => vd.CodVendedor == ped.CodVendedor);
                if (vnd == null && ped.CodVendedor != 900)
                {
                    vendas.Add(new Venda
                    {
                        CodVendedor = ped.CodVendedor,
                        DataColeta = ped.DataPedido,
                        Pedidos = new List<Pedido>{ped}
                    });
                }
                else
                {
                    if (ped.CodVendedor == 900) continue;
                    vnd.Pedidos.Add(ped);
                }                
            }

            var vends = vendas.Select(x => x.CodVendedor).Distinct().ToArray();
            var vendfauls = vendstands.Except(vends).ToArray();

            if (vendfauls.Length > 0)
            {
                foreach (var item in vendfauls)
                {
                    vendas.Add(new Venda() { CodVendedor = item });
                }
            }

            var vendas2 = CheckDuple(vendas).OrderBy(x => x.CodVendedor);

            foreach (var vd in vendas2)
            {
                Vendas.Add(vd);
            }
        }
        private Pedido CriarPedidoErroOcorr(Pedido ped, Item item)
        {
            var pedErr = new Pedido() {
                NumPedido = ped.NumPedido,
                CodVendedor = ped.CodVendedor,
                DP = ped.Items.Count().ToString(),
                GeraNF = ped.GeraNF,
                Cliente = ped.Cliente,
                Items = new List<Item>() {
                    item
                }
            };

            return pedErr;
        }
        public async Task PedsMinAPrazoAsync()
        {
            var pedMin = new List<Pedido>();
            if (Vendas != null)
            {
                foreach (var vnd in Vendas)
                {
                    if (vnd.Pedidos != null)
                    {
                        foreach (var ped in vnd.Pedidos)
                        {
                            var val = ped.Items.Sum(itm => itm.ValorTotal);
                            if (val < 100 && ped.TipoPgt != 1)
                            {
                                pedMin.Add(ped);
                            }
                        }
                    }
                }
                        
                var view = new Dialog_PedMin()
                {
                    DataContext = pedMin
                };

                var result = await DialogHost.Show(view, "RootDialog", ClosingEventHandler);
            }

        }
        public async Task PedsAbaixo70Async()
        {
            var pedMin = new List<Pedido>();
            if (Vendas != null)
            {
                foreach (var vnd in Vendas)
                {
                    if (vnd.Pedidos != null)
                    {
                        foreach (var ped in vnd.Pedidos)
                        {
                            var val = ped.Items.Sum(itm => itm.ValorTotal);
                            if (val > 0 && val < 30)
                            {
                                pedMin.Add(ped);
                            }
                        }
                    }
                }

                var view = new Dialog_PedMin()
                {
                    DataContext = pedMin
                };

                var result = await DialogHost.Show(view, "RootDialog", ClosingEventHandler);
            }
        }
        public async Task PedsErroOcorrenciaMotivo()
        {
            var pedErro = new List<Pedido>();
            if (Vendas != null)
            {
                foreach (var vnd in Vendas)
                {
                    if (vnd.Pedidos != null)
                    {
                        foreach (var ped in vnd.Pedidos)
                        {
                            foreach (var item in ped.Items)
                            {
                                var ocorr = int.Parse(item.Ocorrencia);
                                var mot = item.MotOcorrencia;

                                switch (ocorr)
                                {
                                    case 2:
                                        if (mot != "001")
                                            pedErro.Add(CriarPedidoErroOcorr(ped, item));
                                        break;
                                    case 45:
                                        pedErro.Add(CriarPedidoErroOcorr(ped, item));
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }
                    }
                }

                var view = new Dialog_PedErroOcorr()
                {
                    DataContext = pedErro
                };

                var result = await DialogHost.Show(view, "RootDialog", ClosingEventHandler);
            }
        }
        public async Task PedsAvistaDuplicados()
        {
            var pedsAvista = new List<Pedido>();
            var pedsAvistaDup = new List<Pedido>();
            if (Vendas != null)
            {
                foreach (var vnd in Vendas)
                {
                    if (vnd.Pedidos != null)
                    {
                        foreach (var ped in vnd.Pedidos)
                        {
                            var val = ped.Items.Sum(itm => itm.ValorTotal);
                            if (ped.TipoPgt == 1 && ped.PrazoPgt == 6 || ped.PrazoPgt == 14 && val > 0)
                            {
                                pedsAvista.Add(ped);
                            }
                        }
                    }
                }

                var dups = pedsAvista.GroupBy(x => x.Cliente.CNPJ)
                    .Where(g => g.Count() > 1)
                    //.Select(y => y.Key)
                    .ToList();

                IEnumerable<Pedido> lst = dups.SelectMany(group => group);
                List<Pedido> newList = lst.ToList();

                var view = new Dialog_PedsAvistaDup()
                {
                    DataContext = newList
                };

                var result = await DialogHost.Show(view, "RootDialog", ClosingEventHandler);
            }
        }
        public void RemoverVenda(Venda vnd)
        {
            Vendas.Remove(vnd);
        }
        public async Task ShowTotaisVendaAsync(object vnd)
        {
            if (vnd != null)
            {
                var view = new Dialog_TotaisVenda()
                {
                    DataContext = vnd,
                    MaxHeight = App.Current.MainWindow.Height
                };

                var result = await DialogHost.Show(view, "RootDialog", ClosingEventHandler);
            }
        }
        private ObservableCollection<Venda> CheckDuple( ObservableCollection<Venda> vnds )
        {
            foreach (var vnd in vnds)
            {
                if (vnd.Pedidos != null)
                {
                    foreach (var ped in vnd.Pedidos)
                    {
                        var peds = (vnd.Pedidos.Except(new List<Pedido> { ped })).ToList();
                        foreach (var p in peds)
                        {
                            if (ped.Equals(p))
                            {
                                if (p.DP == "S")
                                {
                                    ped.DP = "S1";
                                }
                                else
                                {
                                    ped.DP = "S";
                                }

                            }
                        }
                    }
                }

            }
            return vnds;





        }
        private void ClosingEventHandler(object sender, DialogClosingEventArgs eventArgs)
        {
            Console.WriteLine("You can intercept the closing event, and cancel here.");
        }

    }
}
