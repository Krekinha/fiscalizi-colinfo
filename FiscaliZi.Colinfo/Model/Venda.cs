using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FiscaliZi.Colinfo.Model
{
    public class Venda : INotifyPropertyChanged
    {
        [Key]
        public int VendaID { get; set; }

        #region Properties
        public string CodVendedor { get; set; }
        public DateTime DataColeta { get; set; }
        public List<Pedido> Pedidos { get; set; }
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
