using FiscaliZi.MDFast.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiscaliZi.MDFast.ViewModel
{
    public class DialogViewModel : ViewModelBase, INotifyPropertyChanged
    {

        public DialogViewModel(IDataService dataService)
        {
            _dataService = dataService;
            
        }

        private readonly IDataService _dataService;






    }
}
