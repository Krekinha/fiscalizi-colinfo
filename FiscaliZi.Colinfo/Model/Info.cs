using System.ComponentModel.DataAnnotations;
using PostSharp.Patterns.Model;

namespace FiscaliZi.Colinfo.Model
{
    [NotifyPropertyChanged]
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
