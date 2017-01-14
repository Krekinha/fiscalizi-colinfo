using MDFast.Validation;
using NFe.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using FluentValidation.Results;

namespace MDFast.Model
{
    public class DataService : IDataService
    {
        readonly MDFastContext mdfastContext;
        public DataService()
        {
            mdfastContext = new MDFastContext();
        }
        public void AddVeiculo(Veiculo car)
        {
            var cars = FuncoesXml.ArquivoXmlParaClasse<List<Veiculo>>("DBase\\Veiculos.xml");
            cars.Add(car);
            FuncoesXml.ClasseParaArquivoXml(cars, "DBase\\Veiculos.xml");
        }

        public ObservableCollection<Veiculo> GetVeiculos()
        {
            ObservableCollection<Veiculo> Cars = new ObservableCollection<Veiculo>();

            var cars = mdfastContext.Veiculos;

            //GravaVeiculos();

            foreach (var item in cars)
            {
                Cars.Add(item);
            }

            return Cars;
        }

        public void GravaVeiculos()
        {
            var cars = new List<Veiculo>();

            cars.Add(new Veiculo { Placa = "HXO2461", Tara = 19000, CapKG = 39000, TPRod = "02", TPCar = "00", UF = "MG" });
            cars.Add(new Veiculo { Placa = "HXO2461", Tara = 19000, CapKG = 39000, TPRod = "02", TPCar = "00", UF = "MG" });
            cars.Add(new Veiculo { Placa = "JSO9224", Tara = 19000, CapKG = 39000, TPRod = "02", TPCar = "00", UF = "MG" });
            cars.Add(new Veiculo { Placa = "DPB7119", Tara = 19000, CapKG = 39000, TPRod = "02", TPCar = "00", UF = "MG" });
            cars.Add(new Veiculo { Placa = "MET3489", Tara = 19000, CapKG = 39800, TPRod = "06", TPCar = "00", UF = "MG" });
            cars.Add(new Veiculo { Placa = "BXI4406", Tara = 19000, CapKG = 39000, TPRod = "02", TPCar = "00", UF = "MG" });
            cars.Add(new Veiculo { Placa = "AMZ8419", Tara = 19000, CapKG = 39000, TPRod = "02", TPCar = "00", UF = "MG" });
            cars.Add(new Veiculo { Placa = "MEB4051", Tara = 19000, CapKG = 39000, TPRod = "02", TPCar = "00", UF = "MG" });
            cars.Add(new Veiculo { Placa = "JQU7507", Tara = 19000, CapKG = 39000, TPRod = "02", TPCar = "00", UF = "MG" });
            cars.Add(new Veiculo { Placa = "MQP8818", Tara = 19000, CapKG = 39000, TPRod = "02", TPCar = "00", UF = "MG" });
            cars.Add(new Veiculo { Placa = "GMW1910", Tara = 19000, CapKG = 39000, TPRod = "02", TPCar = "00", UF = "MG" });
            cars.Add(new Veiculo { Placa = "GML5508", Tara = 19000, CapKG = 39000, TPRod = "02", TPCar = "00", UF = "MG" });

            foreach (var car in cars)
            {
                try
                {
                    mdfastContext.Add(car);
                    mdfastContext.SaveChanges();
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

        public void RemoverVeiculo(Veiculo car)
        {
            var cars = FuncoesXml.ArquivoXmlParaClasse<List<Veiculo>>("DBase\\Veiculos.xml");
            cars.Remove(new Veiculo { Placa=car.Placa });
            FuncoesXml.ClasseParaArquivoXml(cars, "DBase\\Veiculos.xml");
        }

        public Veiculo GetStandVeiculo()
        {
            return new Veiculo { Placa = "ABC1234", CapKG = 36000, Tara = 19000, TPCar = "02", TPRod = "00", UF = "MG" };
        }

        public ObservableCollection<ValidationFailure> fakeERR()
        {
            return new ObservableCollection<ValidationFailure>();
        }
    }
}