using System.ComponentModel.DataAnnotations;
using PostSharp.Patterns.Model;

namespace FiscaliZi.Colinfo.Model
{
    [NotifyPropertyChanged]
    public class Item
    {
        [Key]
        public int ItemID { get; set; }

        #region Properties
        public int Quantidade { get; set; }
        public decimal ValorUnid { get; set; }
        public decimal ValorTotal { get; set; }
        public Produto Produto { get; set; }
        #endregion

        #region Foreign Keys
        public int PedidoID { get; set; }
        #endregion

    }
}
