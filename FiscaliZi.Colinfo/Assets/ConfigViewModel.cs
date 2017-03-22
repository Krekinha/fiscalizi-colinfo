﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using FiscaliZi.Colinfo.Utils;

namespace FiscaliZi.Colinfo.Assets
{
    public class ConfigViewModel
    {
        private IEventAggregator _events;

        public ConfigViewModel(IEventAggregator events)
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