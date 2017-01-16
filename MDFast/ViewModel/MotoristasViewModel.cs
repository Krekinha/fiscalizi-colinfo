using FluentValidation.Results;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MDFast.Model;
using MDFast.Validation;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MDFast.ViewModel
{
    public class MotoristasViewModel : ViewModelBase, INotifyPropertyChanged
    {
        public MotoristasViewModel(IDataService dataService)
        {
            _dataService = dataService;
            Mots = _dataService.GetMotoristas();
            AddMotoristaCommand = new RelayCommand(AddMotorista);
            CancelAddMotoristaCommand = new RelayCommand(CancelAddMotorista);
            FlyNaviCommand = new RelayCommand<int>(FlyNavi);
            RemoverMotoristaCommand = new RelayCommand<Motorista>(RemoverMotorista);
            NewMotorista = new Motorista();
            Errors = _dataService.fakeERR();
        }


        #region · Propriedades ·

        private readonly IDataService _dataService;

        public RelayCommand AddMotoristaCommand { get; set; }
        public RelayCommand CancelAddMotoristaCommand { get; set; }
        public RelayCommand<int> FlyNaviCommand { get; set; }
        public RelayCommand<Motorista> RemoverMotoristaCommand { get; set; }

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

        private Motorista _newMotorista;
        public Motorista NewMotorista
        {
            get
            {
                return _newMotorista;
            }

            set
            {
                Set(() => NewMotorista, ref _newMotorista, value);
                RaisePropertyChanged("NewMotorista");
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
        private void AddMotorista()
        {
            var validator = new MotoristaValidator();
            var results = validator.Validate(NewMotorista);

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
                _dataService.AddMotorista(NewMotorista);
                AtualizaMotoristas();
                FlyIndex = 0;
                RaisePropertyChanged("FlyIndex");
            }

        }
        private void CancelAddMotorista()
        {
            FlyIndex = 0;
            RaisePropertyChanged("FlyIndex");
        }
        private void RemoverMotorista(Motorista mot)
        {
            _dataService.RemoverMotorista(mot);
            AtualizaMotoristas();
        }

        private void AtualizaMotoristas()
        {
            var mots = _dataService.GetMotoristas();
            Mots.Clear();
            foreach (var item in Mots)
            {
                Mots.Add(item);
            }
        }

        private void FlyNavi(int index)
        {
            FlyIndex = index;
        }

        private void Validate()
        {
            var validator = new MotoristaValidator();
            ValidationResult results = validator.Validate(NewMotorista);

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


        #endregion
    }
}
