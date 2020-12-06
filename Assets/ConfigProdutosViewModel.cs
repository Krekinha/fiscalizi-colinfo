using System;
using Caliburn.Micro;
using FiscaliZi.Colinfo.Utils;

namespace FiscaliZi.Colinfo.Assets
{
    public class ConfigProdutosViewModel
    {
        private IEventAggregator _events;

        public ConfigProdutosViewModel(IEventAggregator events)
        {
            _events = events;
            _events.Subscribe(this);
        }

        public void AtualizaProdutos()
        {
            var path = @"F:\SOF\VDWIN\EXP\PRODUTOS.CSV";

            if (Environment.MachineName == "ATAIDE-PC")
                path = @"C:\Users\krekm\Desktop\PRODUTOS.CSV";

            Coletor.GetProdutos(path);
        }
    }
}
