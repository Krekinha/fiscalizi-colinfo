using FiscaliZi.Colinfo.Utils;
using NFe.Utils;
using System.ComponentModel;
using DFe.Utils.Assinatura;

namespace FiscaliZi.Colinfo.Model
{
    public class AppSettings : INotifyPropertyChanged
    {
        public AppSettings()
        {
            CfgServico = ConfiguracaoServico.Instancia;
        }
        #region Properties
        private ConfiguracaoServico _cfgServico;
        public ConfiguracaoServico CfgServico
        {
            get
            {
                Funcoes.CopiarPropriedades(_cfgServico, ConfiguracaoServico.Instancia);
                return _cfgServico;
            }
            set
            {
                _cfgServico = value;
                Funcoes.CopiarPropriedades(value, ConfiguracaoServico.Instancia);
            }
        }
        public CertificadoDados Certificado { get; set; }
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
