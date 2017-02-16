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
        void EditarPedido(Pedido ped);
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
                context.Entry(vnd).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void EditarPedido(Pedido ped)
        {
            using (var context = new ColinfoContext())
            {
                var vend = context.Vendedores.Find(ped.VendedorID);
                var pedA = vend.Pedidos.Find(ped2 => ped2.PedidoID == ped.PedidoID);
                pedA.Cliente.RetConsultaCadastro = ped.Cliente.RetConsultaCadastro;
                context.Entry(vend).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
