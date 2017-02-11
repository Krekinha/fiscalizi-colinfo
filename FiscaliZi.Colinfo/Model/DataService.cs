using System;
using System.Collections.ObjectModel;

namespace FiscaliZi.Colinfo.Model
{
    public interface IDataService
    {
        ObservableCollection<Vendedor> GetVendedores();
        void AddVendedor(Vendedor vnd);
    }

    public class DataService : IDataService
    {
        public ObservableCollection<Vendedor> GetVendedores()
        {
            using (var context = new ColinfoContext())
            {
                var Vends = new ObservableCollection<Vendedor>();

                var vends = context.Vendedores;

                foreach (var item in vends)
                {
                    Vends.Add(item);
                }

                return Vends;
            }
        }

        public void AddVendedor(Vendedor vnd)
        {
            using (var context = new ColinfoContext())
            {
                context.Add(vnd);
                context.SaveChanges();
            }

        }
    }
}
