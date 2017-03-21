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
        public void AtualizaPedidos(DateTime date)
        {
            var path = @"F:\SOF\VDWIN\EXP\PEDIDOS.CSV";

            if (Environment.MachineName == "ATAIDE-PC")
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

            var vendas2 = vendas.OrderBy(x => x.CodVendedor);
            foreach (var vd in vendas2)
            {
                Vendas.Add(vd);
            }
            
        }

        public void RemoverVenda(Venda vnd)
        {
            Vendas.Remove(vnd);
        }


    }
}
