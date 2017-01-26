using FiscaliZi.MDFast.Validation;
using NFe.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using FluentValidation.Results;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using FiscaliZi.MDFast.Model.DialogContent;
using MahApps.Metro.Controls.Dialogs;
using FiscaliZi.MDFast.Views.Dialogs;
using GalaSoft.MvvmLight;
using System.ComponentModel;

namespace FiscaliZi.MDFast.Model
{
    public class DataService : ViewModelBase, IDataService, INotifyPropertyChanged
    {
        //readonly MDFastContext context;
        public DataService(IDialogCoordinator dialogCoordinator)
        {
            _dialogCoordinator = dialogCoordinator;

            DialogMessages = new DialogMessages();
            DialogViewError = new DialogError();
        }

        #region · Dialogs ·

        private IDialogCoordinator _dialogCoordinator;
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
                RaisePropertyChanged("DialogMessages");
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

        private async void ShowDialogErrorAsync(string erro)
        {
            DialogMessages.Message = erro;
            await _dialogCoordinator.ShowMetroDialogAsync(DialogMessages, DialogViewError);
        }

        #endregion

        #region · MotoristasViewModel Objects ·
        public ObservableCollection<Motorista> GetMotoristas()
        {
            using (var context = new MDFastContext())
            {
                ObservableCollection<Motorista> Mots = new ObservableCollection<Motorista>();

                var mots = context.Motoristas;

                foreach (var item in mots)
                {
                    Mots.Add(item);
                }

                return Mots;
            }



        }
        public void GravaMotoristas()
        {
            using (var context = new MDFastContext())
            {
                var mots = new List<Motorista>
            {
                new Motorista() { Nome = "MARCELO CAPOVILLA", CPF = "38711273615" },
                new Motorista() { Nome = "VENI PEREIRA DA COSTA", CPF = "05739590647" },
                new Motorista() { Nome = "EDUARDO DOS REIS BATISTA", CPF = "05355520685" }
            };
                foreach (var mot in mots)
                {
                    try
                    {
                        context.Add(mot);
                        context.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        var msg = "";
                        if (!string.IsNullOrEmpty(ex.Message))
                        {
                            if (ex.InnerException != null)
                                msg = ex.InnerException.Message;
                            else
                                msg = ex.Message;
                            //Funcoes.Mensagem(msg, "Erro", MessageBoxButton.OK);
                        }
                    }

                }
            }

        }
        public void RemoverMotorista(Motorista mot)
        {
            using (var context = new MDFastContext())
            {
                try
                {

                    context.Remove(mot);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {

                    throw;
                }
            }

        }
        public void AddMotorista(Motorista mot)
        {
            using (var context = new MDFastContext())
            {
                context.Add(mot);
                context.SaveChanges();
            }

        }
        #endregion

        #region · VeiculosViewModel Objects ·
        public ObservableCollection<Veiculo> GetVeiculos()
        {
            //GerarDadosVeiculos();

            using (var context = new MDFastContext())
            {
                var Cars = new ObservableCollection<Veiculo>();

                var cars = context.Veiculos
                    .Include(car => car.Chofer);

                foreach (var car in cars)
                {
                    Cars.Add(car);
                }

                return Cars;
            }

            //GravaMotoristas();
        }
        public void AdicionarVeiculo(Veiculo car)
        {
            using (var context = new MDFastContext())
            {
                var mot = new Motorista();
                if (car.Chofer != null)
                {
                    mot = context.Motoristas.Find(car.Chofer.MotoristaID);
                }
                else
                {
                    mot = null;
                }
                var newCar = new Veiculo
                {
                    Placa = car.Placa,
                    CapKG = car.CapKG,
                    Tara = car.Tara,
                    TPCar = car.TPCar,
                    TPRod = car.TPRod,
                    UF = car.UF,
                    Chofer = mot
                };
                context.Veiculos.Add(newCar);
                context.SaveChanges();
            }

        }
        public void RemoverVeiculo(Veiculo car)
        {
            using (var context = new MDFastContext())
            {
                try
                {

                    context.Remove(car);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    var msg = "";
                    if (!string.IsNullOrEmpty(ex.Message))
                    {
                        if (ex.InnerException != null)
                            msg = ex.InnerException.Message;
                        else
                            msg = ex.Message;
                        ShowDialogErrorAsync(msg);
                    }
                }
            }

        }
        public void GerarDadosVeiculos()
        {
            using (var context = new MDFastContext())
            {
                var cars = new List<Veiculo>
            {
                new Veiculo { Placa = "HXO2461", Tara = 19000, CapKG = 39000, TPRod = "02", TPCar = "00", UF = "MG", Chofer = new Motorista() { Nome = "EDUARDO DOS REIS BATISTA", CPF = "05355520685" } },
                new Veiculo { Placa = "JSO9224", Tara = 19000, CapKG = 39000, TPRod = "02", TPCar = "00", UF = "MG" },
                new Veiculo { Placa = "DPB7119", Tara = 19000, CapKG = 39000, TPRod = "02", TPCar = "00", UF = "MG" },
                new Veiculo { Placa = "MET3489", Tara = 19000, CapKG = 39800, TPRod = "06", TPCar = "00", UF = "MG", Chofer = new Motorista() { Nome = "MARCELO CAPOVILLA", CPF = "38711273615" } },
                new Veiculo { Placa = "BXI4406", Tara = 19000, CapKG = 39000, TPRod = "02", TPCar = "00", UF = "MG" },
                new Veiculo { Placa = "AMZ8419", Tara = 19000, CapKG = 39000, TPRod = "02", TPCar = "00", UF = "MG" },
                new Veiculo { Placa = "MEB4051", Tara = 19000, CapKG = 39000, TPRod = "02", TPCar = "00", UF = "MG", Chofer = new Motorista() { Nome = "VENI PEREIRA DA COSTA", CPF = "05739590647" } },
                new Veiculo { Placa = "JQU7507", Tara = 19000, CapKG = 39000, TPRod = "02", TPCar = "00", UF = "MG" },
                new Veiculo { Placa = "MQP8818", Tara = 19000, CapKG = 39000, TPRod = "02", TPCar = "00", UF = "MG" },
                new Veiculo { Placa = "GMW1910", Tara = 19000, CapKG = 39000, TPRod = "02", TPCar = "00", UF = "MG" },
                new Veiculo { Placa = "GML5508", Tara = 19000, CapKG = 39000, TPRod = "02", TPCar = "00", UF = "MG" }
            };
                foreach (var car in cars)
                {
                    try
                    {
                        context.Add(car);
                        context.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        var msg = "";
                        if (!string.IsNullOrEmpty(ex.Message))
                        {
                            if (ex.InnerException != null)
                                msg = ex.InnerException.Message;
                            else
                                msg = ex.Message;
                            //Funcoes.Mensagem(msg, "Erro", MessageBoxButton.OK);
                        }
                    }

                }
            }

        }

        public Veiculo GetStandVeiculo()
        {
            return new Veiculo
            {
                Placa = "ABC-1234",
                CapKG = 36000,
                Tara = 19000,
                TPCar = "02",
                TPRod = "00",
                UF = "MG"
            };
        }
        #endregion

        public ObservableCollection<ValidationFailure> fakeERR()
        {
            return new ObservableCollection<ValidationFailure>();
        }

        public void TesteData(Veiculo car)
        {

            using (var context = new MDFastContext())
            {
                var mot = context.Motoristas.Find(1);
                var car2 = new Veiculo
                {
                    Placa = car.Placa,
                    CapKG = car.CapKG,
                    Tara = car.Tara,
                    TPCar = car.TPCar,
                    TPRod = car.TPRod,
                    UF = car.UF,
                    Chofer = mot
                };
                //car2.Chofer = mot;
                //context.Entry(car.Chofer).State = EntityState.Added;
                context.Veiculos.Add(car2);
                context.SaveChanges();
            }
        }

    }
}