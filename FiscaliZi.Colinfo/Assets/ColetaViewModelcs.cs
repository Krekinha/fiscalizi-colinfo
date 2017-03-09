using System.Collections.Generic;
using Caliburn.Micro;
using FiscaliZi.Colinfo.Model;
using FiscaliZi.Colinfo.Utils;
using System.Collections.ObjectModel;
using System.Windows.Data;

namespace FiscaliZi.Colinfo.Assets
{
    public class ColetaViewModel : PropertyChangedBase
    {

        public ColetaViewModel(IEventAggregator events)
        {
            Pedidos = new ObservableCollection<Pedido>();
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(Pedidos);
            PropertyGroupDescription groupDescription = new PropertyGroupDescription("CodVendedor");
            view.GroupDescriptions.Add(groupDescription);
            
        }

        public void AtualizaPedidos()
        {
            var peds = Coletor.GetPedidos(@"C:\Users\krekm\Desktop\PEDIDOS.CSV");
            //var peds = Coletor.GetPedidos(@"C:\Users\CPD\Documents\DIU\PEDIDOS.CSV");

            if (Pedidos == null)
                Pedidos = new ObservableCollection<Pedido>();

            if (Pedidos.Count > 0)
                Pedidos.Clear();

            foreach (var ped in peds)
            {
                Pedidos.Add(ped);
            }
        }

        public ObservableCollection<Pedido> Pedidos { get; set; }
    }
}
