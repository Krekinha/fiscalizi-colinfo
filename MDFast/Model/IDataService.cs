using System.Collections.ObjectModel;
using FluentValidation.Results;

namespace MDFast.Model
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
        #endregion

        ObservableCollection<ValidationFailure> fakeERR();
        
    }
}
