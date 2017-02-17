using System;
using System.Collections.ObjectModel;
using System.Linq;
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
        Vendedor GetVendedor(int id);
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
                    .ThenInclude(cli => cli.Cliente)
                    .ThenInclude(ret => ret.RetConsultaCadastro)
                    .ThenInclude(inf => inf.infCons)
                    .ThenInclude(inf2 => inf2.infCad);

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
                var vend = context.Vendedores
                    .Include(vnd => vnd.Pedidos)
                    .ThenInclude(cli => cli.Cliente)
                    .FirstOrDefault(x => x.VendedorID == ped.VendedorID);
                var pedA = vend.Pedidos.Find(x => x.PedidoID == ped.PedidoID);
                pedA.Cliente.RetConsultaCadastro = ped.Cliente.RetConsultaCadastro;
                context.Entry(vend).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public Vendedor GetVendedor(int id)
        {
            using (var context = new ColinfoContext())
            {
                return context.Vendedores.Find(id);
            }
        }
    }
}
