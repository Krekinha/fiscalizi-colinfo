using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using NFPush.Model;
using NFPush.Model.NFe.Classes;
using System.Collections.ObjectModel;
using System;

namespace NFPush.ViewModel
{
    public class BDNFEViewModel : ViewModelBase
    {

        public BDNFEViewModel(IDataService dataService)
        {
            _dataService = dataService;
            ListarNFsCommand = new RelayCommand(ListarNFs);
            //NFs = new ObservableCollection<nfeProc>();
        }

        private void ListarNFs()
        {
            /*if (NFs != null)
             NFs.Clear();
            foreach (var item in _dataService.GetDFs())
            {
                NFs.Add(item);
            }
            RaisePropertyChanged("NFs");*/
        }

        #region · Properties ·

        //public Color CurrentAccentColor = FirstFloor.ModernUI.Presentation.AppearanceManager.Current.AccentColor;

        public readonly IDataService _dataService;

        private ObservableCollection<nfeProc> _NFs;
        public ObservableCollection<nfeProc> NFs
        {
            get
            {
                return _NFs;
            }
            set
            {
                if (value != _NFs)
                {
                    var oldValue = _NFs;
                    _NFs = value;
                    RaisePropertyChanged("NFs", oldValue, value, true);
                }
            }
        }
        public RelayCommand ListarNFsCommand { get; set; }

        #endregion
    }
}