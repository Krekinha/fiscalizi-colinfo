using PropertyChanged;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FiscaliZi.Colinfo.Model
{
    [ImplementPropertyChanged]
    public class Pedido : INotifyPropertyChanged
    {
        [Key]
        public int PedidoID { get; set; }

        #region Properties
        public int NumPedido { get; set; }
        public int NumVendedor { get; set; }
        public string NumPedPalm { get; set; }
        public string FormPgt { get; set; }
        public Cliente Cliente { get; set; }
        public List<Item> Itens { get; set; }
        public decimal ValorTotal { get; set; }
        #endregion

        #region Foreign Keys
        public int VendedorID { get; set; }
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
