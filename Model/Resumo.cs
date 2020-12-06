using System.ComponentModel.DataAnnotations;

namespace FiscaliZi.Colinfo.Model
{
    public class Resumo
    {
        [Key]
        public int ResumoID { get; set; }

        #region Properties
        public int QntCX { get; set; }
        public string Sigla { get; set; }
        #endregion
    }
}
