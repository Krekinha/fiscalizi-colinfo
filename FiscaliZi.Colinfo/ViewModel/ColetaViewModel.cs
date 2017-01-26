using FiscaliZi.Colinfo.Model;
using GalaSoft.MvvmLight;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiscaliZi.Colinfo.ViewModel
{
    [ImplementPropertyChanged]
    public class ColetaViewModel : ViewModelBase
    {
        private readonly IDataService dataService;

        public ColetaViewModel(IDataService _dataService)
        {
            dataService = _dataService;
            Vendedores = dataService.GetVendedores();
        }

        #region · Properties ·
        public ObservableCollection<Vendedor> Vendedores { get; set; }
        #endregion
    }
}
