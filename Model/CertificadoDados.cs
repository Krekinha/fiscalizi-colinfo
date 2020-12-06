using System;
using System.ComponentModel;

namespace FiscaliZi.Colinfo.Model
{
    public class CertificadoDados : INotifyPropertyChanged
    {
        #region Properties
        public string Serial { get; set; }
        public string Nome { get; set; }
        public DateTime Validade { get; set; }
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