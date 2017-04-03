using System;
using Caliburn.Micro;
using FiscaliZi.Colinfo.Utils;

namespace FiscaliZi.Colinfo.Assets
{
    public class ConfigClientesViewModel
    {
        private IEventAggregator _events;

        public ConfigClientesViewModel(IEventAggregator events)
        {
            _events = events;
            _events.Subscribe(this);
        }

        public void AtualizaClientes()
        {
            var path = @"F:\SOF\VDWIN\EXP\CLIENTES.CSV";

            if (Environment.MachineName == "ATAIDE-PC")
                path = @"C:\Users\krekm\Desktop\CLIENTES.CSV";

            Coletor.GetClientes(path);
        }
    }
}
