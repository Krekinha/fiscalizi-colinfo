using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using FiscaliZi.Colinfo.Utils;

namespace FiscaliZi.Colinfo.Assets
{
    public class ColetaViewModel : PropertyChangedBase
    {

        public ColetaViewModel(IEventAggregator events)
        {
                
        }

        public void AtualizaPedidos()
        {
            var peds = Coletor.GetPedidos(@"C:\Users\krekm\Desktop\PEDIDOS.CSV");
        }
    }
}
