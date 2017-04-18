using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiscaliZi.Colinfo.Model
{
    public class Pedido : INotifyPropertyChanged
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
    }
}
