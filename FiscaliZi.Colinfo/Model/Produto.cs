using System.ComponentModel.DataAnnotations;

namespace FiscaliZi.Colinfo.Model
{
    //[NotifyPropertyChanged]
    public class Produto
    {
        [Key]
        public int ProdutoID { get; set; }

        #region Properties
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public int Unidades { get; set; }
        public decimal Preco { get; set; }
        public decimal Peso { get; set; }
        #endregion

        #region Foreign Keys
        public int ItemID { get; set; }
        #endregion

    }
}
