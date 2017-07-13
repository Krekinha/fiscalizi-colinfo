using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Caliburn.Micro;
using FiscaliZi.MDFast.Model;
using FiscaliZi.MDFast.Model.DialogContent;
using FiscaliZi.MDFast.Validation;
using FiscaliZi.MDFast.Views.Dialogs;
using FluentValidation.Results;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using MahApps.Metro.Controls.Dialogs;

namespace FiscaliZi.MDFast.Assets
{
    public class ConfigVeiculosViewModel : ViewModelBase, INotifyPropertyChanged
    {
        public ConfigVeiculosViewModel(IEventAggregator events)
        {
            //_dataService = new DataService(dialogCoordinator);
            _events = events;

            //Cars = _dataService.GetVeiculos();
            //Mots = _dataService.GetMotoristas();
            //NewVeiculo = _dataService.GetStandVeiculo();
            //Errors = _dataService.fakeERR();
            //    not       _dialogViewMotoristas = new DialogMotoristas { DataContext = this };

            //_dialogCoordinator = dialogCoordinator;
            //Messenger.Default.Register<string>(this, ProcessMessage);

            #region · Commands ·
            AddVeiculoCommand = new RelayCommand(AddVeiculo);
            CancelAddVeiculoCommand = new RelayCommand(CancelAddVeiculo);
            FlyNaviCommand = new RelayCommand<int>(FlyNavi);
            RemoverVeiculoCommand = new RelayCommand<Veiculo>(RemoverVeiculo);
            GerarDadosVeiculosCommand = new RelayCommand(GerarDadosVeiculos);
            ShowMotoristasDialog = new RelayCommand(ShowDialog);
            SendMotoristaCommand = new RelayCommand<Motorista>(SendMotorista);

            TesteCommand = new RelayCommand(Teste);

            #endregion

        }

        private void Teste()
        {
            _dataService.TesteData(NewVeiculo);
            AtualizaVeiculos();
            NewVeiculo = _dataService.GetStandVeiculo();
        }

        #region · Propriedades ·

        private readonly IDataService _dataService;
        private readonly IEventAggregator _events;

        #region · Commands ·
        public RelayCommand AddVeiculoCommand { get; set; }
        public RelayCommand CancelAddVeiculoCommand { get; set; }
        public RelayCommand<int> FlyNaviCommand { get; set; }
        public RelayCommand<Veiculo> RemoverVeiculoCommand { get; set; }
        public RelayCommand GerarDadosVeiculosCommand { get; set; }
        public RelayCommand ShowMotoristasDialog { get; set; }
        public RelayCommand<Motorista> SendMotoristaCommand{ get; set; }
        private RelayCommand _sendMessageCommand;
        public RelayCommand SendMessageCommand
        {
            get
            {
                return _sendMessageCommand
                       ?? (_sendMessageCommand = new RelayCommand(SendMessage));
            }
        }
        public RelayCommand TesteCommand { get; set; }
        #endregion

        #region · Propriedades ·
        private ObservableCollection<ValidationFailure> _errors;
        public ObservableCollection<ValidationFailure> Errors
        {
            get
            {
                return _errors;
            }

            set
            {
                Set(() => Errors, ref _errors, value);
            }
        }

        private ObservableCollection<Veiculo> _cars;
        public ObservableCollection<Veiculo> Cars
        {
            get
            {
                return _cars;
            }

            set
            {
                Set(() => Cars, ref _cars, value);
            }
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

        private Veiculo _newVeiculo;
        public Veiculo NewVeiculo
        {
            get
            {
                return _newVeiculo;
            }

            set
            {
                Set(() => NewVeiculo, ref _newVeiculo, value);
                RaisePropertyChanged("NewVeiculo");
                //Validate();

                //NewVeiculo.ForcePropertyChanged("UF");
            }
        }

        private DialogMotoristas _dialogViewMotoristas;
        public DialogMotoristas DialogViewMotoristas
        {
            get
            {
                return _dialogViewMotoristas;
            }

            set
            {
                Set(() => DialogViewMotoristas, ref _dialogViewMotoristas, value);
                RaisePropertyChanged("DialogViewMotoristas");
            }
        }

        private DialogError _dialogViewError;
        public DialogError DialogViewError
        {
            get
            {
                return _dialogViewError;
            }

            set
            {
                Set(() => DialogViewError, ref _dialogViewError, value);
                RaisePropertyChanged("DialogViewError");
            }
        }

        private DialogMessages _dialogMessages;
        public DialogMessages DialogMessages
        {
            get { return _dialogMessages; }
            set
            {
                if (_dialogMessages == value)
                {
                    return;
                }
                _dialogMessages = value;
                RaisePropertyChanged();
            }
        }

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

        private Motorista _selectedMotorista;
        public Motorista SelectedMotorista
        {
            get { return _selectedMotorista; }
            set
            {
                if (_selectedMotorista == value)
                {
                    return;
                }
                _selectedMotorista = value;
                RaisePropertyChanged();
            }
        }

        private int _flyIndex;
        public int FlyIndex
        {
            get
            {
                return _flyIndex;
            }

            set
            {
                Set(() => FlyIndex, ref _flyIndex, value);
            }
        }

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
        public bool HasErrors
        {
            get
            {
                throw new NotImplementedException();
            }
        }
        #endregion

        #endregion

        #region · Construtores ·
        private void AddVeiculo()
        {
            VeiculoValidator validator = new VeiculoValidator();
            ValidationResult results = validator.Validate(NewVeiculo);

            if (!results.IsValid)
            {
                Errors.Clear();

                foreach (var err in results.Errors)
                {
                    Errors.Add(err);
                    RaisePropertyChanged("Errors");
                }
            }
            else
            {
                Errors.Clear();
                RaisePropertyChanged("Errors");
                _dataService.AdicionarVeiculo(NewVeiculo);
                AtualizaVeiculos();
                FlyIndex = 0;
                RaisePropertyChanged("FlyIndex");
            }        
            
        }
        private void CancelAddVeiculo()
        {
            FlyIndex = 0;
            RaisePropertyChanged("FlyIndex");
        }
        private void RemoverVeiculo(Veiculo car)
        {
            _dataService.RemoverVeiculo(car);
            RaisePropertyChanged("Cars");
            AtualizaVeiculos();
        }
        private void GerarDadosVeiculos()
        {
            _dataService.GerarDadosVeiculos();
            AtualizaVeiculos();
        }
        private void AtualizaVeiculos()
        {
            Cars.Clear();
            Cars = _dataService.GetVeiculos();
        }
        private void FlyNavi(int index)
        {
            FlyIndex = index;
        }
        private void Validate()
        {
            VeiculoValidator validator = new VeiculoValidator();
            ValidationResult results = validator.Validate(NewVeiculo);

            if (!results.IsValid)
            {
                Errors.Clear();

                foreach (var err in results.Errors)
                {
                    Errors.Add(err);
                    RaisePropertyChanged("Errors");
                }
            }
            else
            {
                Errors.Clear();
                RaisePropertyChanged("Errors");
            }
        }
        private void SendMessage()
        {
            Messenger.Default.Send(DialogMessage);
        }
        private async void SendMotorista(Motorista mot)
        {
            //NewVeiculo.Motorista = SelectedMotorista;
            await _dialogCoordinator.HideMetroDialogAsync(this, _dialogViewMotoristas);
        }

        #endregion

        #region Dialog Motoristas
        private IDialogCoordinator _dialogCoordinator;
        private string _dialogResult;
        public string DialogResult
        {
            get { return _dialogResult; }
            set
            {
                if (_dialogResult == value)
                {
                    return;
                }
                _dialogResult = value;
                RaisePropertyChanged();
            }
        }
        private async void ShowDialog()
        {
            await _dialogCoordinator.ShowMetroDialogAsync(this, DialogViewMotoristas );
            /*var customDialog = new CustomDialog() { Title = "Custom Dialog" };

            customDialog.Content = new DialogMotoristas { DataContext = this };

            await _dialogCoordinator.ShowMetroDialogAsync(this, customDialog);*/
        }
        private async void ShowDialogErrorAsync(string erro)
        {
            DialogMessages.Message = erro;
            await _dialogCoordinator.ShowMetroDialogAsync(DialogMessages, DialogViewError);
        }
        private async void ProcessMessage(string messageContents)
        {
            DialogResult = messageContents;
            await _dialogCoordinator.HideMetroDialogAsync(this, DialogViewMotoristas);
        }

        #endregion
    }
}
