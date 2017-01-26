using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiscaliZi.Colinfo.Model
{
    public interface IDataService
    {
        ObservableCollection<Vendedor> GetVendedores();
    }

    public class DataService : IDataService
    {
        public ObservableCollection<Vendedor> GetVendedores()
        {
            throw new NotImplementedException();
        }
    }
}
