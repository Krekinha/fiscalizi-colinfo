using System.Collections.Generic;
using Caliburn.Micro;
using FiscaliZi.Colinfo.Model;
using FiscaliZi.Colinfo.Utils;
using System.Collections.ObjectModel;
using System.Windows.Data;
using System.Linq;
using System;

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
        public void AtualizaPedidos(DateTime data)

        {
            var peds = Coletor.GetPedidos(@"C:\Users\krekm\Desktop\PEDIDOS.CSV", data);
            //var peds = Coletor.GetPedidos(@"C:\Users\CPD\Documents\DIU\PEDIDOS.CSV");
            //var peds = Coletor.GetPedidos(@"F:\SOF\VDWIN\EXP\PEDIDOS.CSV");

            if (Vendas == null)
                Vendas = new ObservableCollection<Venda>();

            if (Vendas.Count > 0)
                Vendas.Clear();

            foreach (var ped in peds)
            {
                var vnd = Vendas.FirstOrDefault(vd => vd.CodVendedor == ped.CodVendedor);
                if (vnd == null && ped.CodVendedor != 900)
                {
                    Vendas.Add(new Venda
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
                NotifyOfPropertyChange(() => Vendas);
            }
        }

        public void RemoverVenda(Venda vnd)
        {
            Vendas.Remove(vnd);
        }


    }
}
