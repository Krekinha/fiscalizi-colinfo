using System;
using System.ComponentModel;

namespace MDFast.Model
{
    public class Veiculo : IEquatable<Veiculo>, INotifyPropertyChanged
    {
        #region NotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void ForcePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        public int ID { get; set; }
        public string Placa { get; set; }
        public int Tara { get; set; }
        public int CapKG { get; set; }
        public string TPRod { get; set; }
        public string TPCar { get; set; }
        public string UF { get; set; }

        public bool Equals(Veiculo other)
        {
            if (other == null) return false;
            return (Placa.Equals(other.Placa));
        }

    }
}
