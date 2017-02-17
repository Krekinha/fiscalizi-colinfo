using NFe.Classes.Servicos.ConsultaCadastro;
using PropertyChanged;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FiscaliZi.Colinfo.Model
{
    [ImplementPropertyChanged]
    public class Cliente : INotifyPropertyChanged
    {
        [Key]
        public int ClienteID { get; set; }

        #region Properties
        public int RegiaoCliente { get; set; }
        public int NumCliente { get; set; }
        public int Rota { get; set; }
        public string CNPJ { get; set; }
        public string IE { get; set; }
        public string Situacao { get; set; }
        public string Razao { get; set; }
        public string Sigla { get; set; }
        public Info Info { get; set; }
        public retConsCad RetConsultaCadastro { get; set; }
        #endregion

        #region Navigation Properties
        public virtual ICollection<Pedido> NavPedidos { get; set; }
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
