using System;
using System.Collections.ObjectModel;
using FluentValidation.Results;
using MDFast.Model;
using MDFast.Validation;

namespace MDFast.Design
{
    public class DesignDataService : IDataService
    {
        public void AddMotorista(Motorista newMotorista)
        {
            throw new NotImplementedException();
        }

        public void AdicionarVeiculo(Veiculo car)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<ValidationFailure> fakeERR()
        {
            return new ObservableCollection<ValidationFailure>
            {
                new ValidationFailure("Placa", "Campo obrigatório"),
                new ValidationFailure("Tara", "Campo obrigatório")
            };
        }

        public ObservableCollection<Motorista> GetMotoristas()
        {
            throw new NotImplementedException();
        }

        public Veiculo GetStandVeiculo()
        {
            return new Veiculo { Placa = "AAA-1515", CapKG = 36000, Tara = 19000, TPCar = "02", TPRod = "00", UF = "MG" };
        }

        public ObservableCollection<Veiculo> GetVeiculos()
        {
            throw new NotImplementedException();
        }

        public void RemoverMotorista(Motorista mot)
        {
            throw new NotImplementedException();
        }

        public void RemoverVeiculo(Veiculo car)
        {
            throw new NotImplementedException();
        }
    }
}