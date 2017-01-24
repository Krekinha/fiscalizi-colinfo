﻿using System.Collections.ObjectModel;
using FluentValidation.Results;

namespace FiscaliZi.MDFast.Model
{
    public interface IDataService
    {
        #region VeiculosViewModel
        void AdicionarVeiculo(Veiculo car);
        ObservableCollection<Veiculo> GetVeiculos();
        Veiculo GetStandVeiculo();
        void RemoverVeiculo(Veiculo car);
        #endregion

        #region MotoristasViewModel
        ObservableCollection<Motorista> GetMotoristas();
        void RemoverMotorista(Motorista mot);
        void AddMotorista(Motorista newMotorista);
        void GerarDadosVeiculos();
        #endregion

        ObservableCollection<ValidationFailure> fakeERR();
        void TesteData(Veiculo car);
    }
}
