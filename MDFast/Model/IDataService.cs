using System.Collections.ObjectModel;
using FluentValidation.Results;

namespace MDFast.Model
{
    public interface IDataService
    {
        void AddVeiculo(Veiculo car);
        ObservableCollection<Veiculo> GetVeiculos();
        Veiculo GetStandVeiculo();
        void RemoverVeiculo(Veiculo car);
        ObservableCollection<ValidationFailure> fakeERR();
    }
}
