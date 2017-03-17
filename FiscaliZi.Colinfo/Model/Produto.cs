using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FiscaliZi.Colinfo.Model
{
    public class Produto : INotifyPropertyChanged
    {
        [Key]
        public int ProdutoID { get; set; }

        #region Properties
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public string Sigla { get; set; }
        public string Familia { get; set; }
        public int Unidades { get; set; }
        public decimal Preco { get; set; }
        public decimal PesoUnd { get; set; }
        public decimal PesoEmb{ get; set; }
        #endregion

        #region Foreign Keys
        public int ItemID { get; set; }
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
