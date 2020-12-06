using System.ComponentModel.DataAnnotations;

namespace FiscaliZi.Colinfo.Model
{
    public class Info
    {
        [Key]
        public int InfoID { get; set; }

        #region Properties
        public string ErroID { get; set; }
        public string Mensagem { get; set; }
        #endregion

        #region Foreign Keys
        public int ClienteID { get; set; }
        #endregion

    }
}
