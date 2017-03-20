using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FiscaliZi.Colinfo.Model
{
    public class Arquivo : INotifyPropertyChanged
    {
        /*public Arquivo()
        {
               Pedidos = new List<Pedido>();
        }*/
        [Key]
        public int ArquivoID { get; set; }      

        #region Properties
        public int CodVendedor { get; set; }
        public string NomeVendedor { get; set; }
        public string ArquivoVendedor { get; set; }
        public DateTime DataColeta { get; set; }
        public DateTime DataEnvio { get; set; }

        public virtual ICollection<Pedido> Pedidos { get; set; }
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
