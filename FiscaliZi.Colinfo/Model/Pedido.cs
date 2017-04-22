using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace FiscaliZi.Colinfo.Model
{
    public class Pedido : INotifyPropertyChanged, IEquatable<Pedido>
    {
        [Key]
        public int PedidoID { get; set; }

        #region Properties
        public string NumPedido { get; set; }
        public int CodVendedor { get; set; }
        public string NumPedPalm { get; set; }
        public int TipoPgt { get; set; }
        public int PrazoPgt { get; set; }
        public Cliente Cliente { get; set; }
        public decimal ValorTotalPed { get; set; }
        public decimal ADFinanceiro { get; set; }
        public DateTime DataPedido { get; set; }
        public string Pasta { get; set; }
        public string SitPed { get; set; }
        public string DP { get; set; }

        public virtual List<Item> Items { get; set; }
        #endregion

        #region Foreign Keys
        public int ClienteID { get; set; }
        public int ArquivoID { get; set; }
        #endregion

        #region Navigation Properties
        public virtual Arquivo Arquivo { get; set; }
        #endregion

        #region NotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        public void ForcePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region Compare
        public override bool Equals(object obj)
        {
            return Equals(obj as Pedido);
        }
        public bool Equals(Pedido other)
        {
            if (other == null) return false;
            if (Items == null) return false;

            if (this.Cliente.RegiaoCliente != other.Cliente.RegiaoCliente)
            {
                return false;
            }

            if (this.Cliente.NumCliente != other.Cliente.NumCliente)
            {
                return false;
            }

            var ThisItms = Items?.Select(item => $"{item?.Produto?.Codigo}{item?.QntCX}{item?.QntUND}").ToList();

            var OtherItms = other.Items?.Select(item => $"{item?.Produto?.Codigo}{item?.QntCX}{item?.QntUND}").ToList();

            var res = Enumerable.SequenceEqual(ThisItms.OrderBy(t => t), OtherItms.OrderBy(t => t));

            // TODO: Compare Members and return false if not the same

            return res;
        }
        #endregion
    }
}
