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
            Mots = _dataService.GetMotoristas();
        }

        private readonly IDataService _dataService;

        private string _dialogMessage;
        public string DialogMessage
        {
            get { return _dialogMessage; }
            set
            {
                if (_dialogMessage == value)
                {
                    return;
                }
                _dialogMessage = value;
                RaisePropertyChanged();
            }
        }
        private RelayCommand _sendMessageCommand;
        public RelayCommand SendMessageCommand
        {
            get
            {
                return _sendMessageCommand
                       ?? (_sendMessageCommand = new RelayCommand(SendMessage));
            }
        }
        private void SendMessage()
        {
            Messenger.Default.Send(DialogMessage);
        }

        private ObservableCollection<Motorista> _mots;
        public ObservableCollection<Motorista> Mots
        {
            get
            {
                return _mots;
            }

            set
            {
                Set(() => Mots, ref _mots, value);
            }
        }
    }
}
