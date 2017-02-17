using PropertyChanged;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Policy;

namespace FiscaliZi.Colinfo.Model
{
    [ImplementPropertyChanged]
    public class Vendedor : INotifyPropertyChanged
    {
        [Key]
        public int VendedorID { get; set; }
        

        #region Properties
        public int NumVendedor { get; set; }
        public string NomeVendedor { get; set; }
        public string ArquivoVendedor { get; set; }
        public DateTime DataColeta { get; set; }
        public DateTime DataEnvio { get; set; }
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
