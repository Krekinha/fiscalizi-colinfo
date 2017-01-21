using FluentValidation.Results;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using FiscaliZi.MDFast.Model;
using FiscaliZi.MDFast.Validation;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System;
using MahApps.Metro.Controls.Dialogs;
using FiscaliZi.MDFast.Views;

namespace FiscaliZi.MDFast.ViewModel
{
    public class VeiculosViewModel : ViewModelBase, INotifyPropertyChanged
    {
        public VeiculosViewModel(IDataService dataService)
        {
            _dataService = dataService;

            Cars = _dataService.GetVeiculos();
            NewVeiculo = _dataService.GetStandVeiculo();
            Errors = _dataService.fakeERR();

            #region · Commands ·
            AddVeiculoCommand = new RelayCommand(AddVeiculo);
            CancelAddVeiculoCommand = new RelayCommand(CancelAddVeiculo);
            FlyNaviCommand = new RelayCommand<int>(FlyNavi);
            RemoverVeiculoCommand = new RelayCommand<Veiculo>(RemoverVeiculo);
            GerarDadosVeiculosCommand = new RelayCommand(GerarDadosVeiculos);
            ShowMotoristasDialog = new RelayCommand(ShowMotoristas);
            #endregion

        }

        #region · Propriedades ·

        private readonly IDataService _dataService;

        #region · Commands ·
        public RelayCommand AddVeiculoCommand { get; set; }
        public RelayCommand CancelAddVeiculoCommand { get; set; }
        public RelayCommand<int> FlyNaviCommand { get; set; }
        public RelayCommand<Veiculo> RemoverVeiculoCommand { get; set; }
        public RelayCommand GerarDadosVeiculosCommand { get; set; }
        public RelayCommand ShowMotoristasDialog { get; set; }
        #endregion

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

        private int _flyIndex;

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

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

        public bool HasErrors
        {
            get
            {
                throw new NotImplementedException();
            }
        }

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
        private async void ShowMotoristas()
        {
            var customDialog = new CustomDialog() { Title = "Motoristas" };

            var customDialogExampleContent = new CustomDialogExampleContent(instance =>
            {
                _dialogCoordinator.HideMetroDialogAsync(this, customDialog);
                System.Diagnostics.Debug.WriteLine(instance.FirstName);
            });
            customDialog.Content = new DialogMotoristas { DataContext = customDialogExampleContent };

            await _dialogCoordinator.ShowMetroDialogAsync(this, customDialog);
        }

        #endregion
    }
}
