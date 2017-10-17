using System.Collections.Generic;
using Caliburn.Micro;
using FiscaliZi.Colinfo.Model;
using FiscaliZi.Colinfo.Utils;
using System.Collections.ObjectModel;
using System.Windows.Data;
using System.Linq;
using System;
using MaterialDesignThemes.Wpf;
using System.Windows;

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
            var vendstands = new int[] { 301, 302, 303, 304, 305, 306, 307, 308,
                                         401, 402, 403, 404, 405, 406, 407,
                                         601, 602, 603, 604, 605};
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
        public async System.Threading.Tasks.Task PedsMinAPrazoAsync()
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
        public void RemoverVenda(Venda vnd)
        {
            Vendas.Remove(vnd);
        }
        public void ShowTotaisVendaFlyout(object vnd)
        {
            ((MainView)Application.Current.MainWindow).TotaisVendaFlyout.IsOpen = !((MainView)Application.Current.MainWindow).TotaisVendaFlyout.IsOpen;
            ((MainView)Application.Current.MainWindow).TotaisVendaFlyout.DataContext = vnd;
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
