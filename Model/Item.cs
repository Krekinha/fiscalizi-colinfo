using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FiscaliZi.Colinfo.Model
{
    public class Item : INotifyPropertyChanged
    {
        [Key]
        public int ItemID { get; set; }

        #region Properties
        public int QntCX { get; set; }
        public int QntUND { get; set; }
        public decimal ValorCusto { get; set; }
        public decimal ValorUnid { get; set; }
        public decimal ValorTotal { get; set; }
        public string Ocorrencia { get; set; }
        public string MotOcorrencia { get; set; }
        public string NatOper { get; set; }
        public string Tabela { get; set; }

        public virtual Produto Produto { get; set; }
        #endregion

        #region Foreign Keys
        public int PedidoID { get; set; }
        #endregion

        #region Navigation Properties
        public virtual Pedido Pedido { get; set; }
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
