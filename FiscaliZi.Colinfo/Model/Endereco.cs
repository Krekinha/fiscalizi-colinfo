using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FiscaliZi.Colinfo.Model
{
    public class Endereco
    {
        #region Properties
        [Key]
        public int EnderecoID { get; set; }

        public string xPrepLgr { get; set; }
        public string xTPLgr { get; set; }
        public string xLgr { get; set; }
        public string nro { get; set; }
        public string xBairro { get; set; }
        public string cMun { get; set; }
        public string xMun { get; set; }
        public string CEP { get; set; }
        public int infCadID { get; set; }
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
