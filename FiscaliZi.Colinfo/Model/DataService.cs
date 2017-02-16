using System;
using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;

namespace FiscaliZi.Colinfo.Model
{
    public interface IDataService
    {
        ObservableCollection<Vendedor> GetVendedores();
        void AddVendedor(Vendedor vnd);
        void RemoverVendedor(Vendedor vnd);
        void EditarVendedor(Vendedor vnd);
    }

    public class DataService : IDataService
    {
        public ObservableCollection<Vendedor> GetVendedores()
        {
            using (var context = new ColinfoContext())
            {
                var Vends = new ObservableCollection<Vendedor>();

                var vends = context.Vendedores
                    .Include(vnd => vnd.Pedidos)
                    .ThenInclude(cli => cli.Cliente);

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
        public void RemoverVendedor(Vendedor vnd)
        {
            using (var context = new ColinfoContext())
            {
                try
                {
                    context.Remove(vnd);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    var msg = "";
                    if (!string.IsNullOrEmpty(ex.Message))
                    {
                        msg = ex.InnerException?.Message ?? ex.Message;
                        //ShowDialogErrorAsync(msg);
                    }
                }
            }

        }

        public void EditarVendedor(Vendedor vnd)
        {
            using (var context = new ColinfoContext())
            {
                context.Entry(vnd).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
