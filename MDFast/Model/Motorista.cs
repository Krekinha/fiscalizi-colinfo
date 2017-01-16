using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiscaliZi.MDFast.Model
{
    public class Motorista : IEquatable<Motorista>, INotifyPropertyChanged
    {
        #region NotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void ForcePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public bool Equals(Motorista other)
        {
            if (other == null) return false;
            return (CPF.Equals(other.CPF));
        }
        #endregion

        public int ID { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
    }
}
