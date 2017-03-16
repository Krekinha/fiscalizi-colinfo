using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

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
        public string FormPgt { get; set; }
        public Cliente Cliente { get; set; }
        public List<Item> Itens { get; set; }
        public decimal ValorTotal { get; set; }
        public DateTime DataPedido { get; set; }
        public string Pasta { get; set; }
        #endregion

        #region Foreign Keys
        public int ArquivoID { get; set; }
        public int ClienteID { get; set; }
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
