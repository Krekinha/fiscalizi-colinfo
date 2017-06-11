using Caliburn.Micro;

namespace FiscaliZi.MDFast.Assets
{
    public class HomeViewModel : PropertyChangedBase
    {
        public HomeViewModel(IEventAggregator events)
        {
            _events = events;
        }
        #region · Propriedades ·
        private IEventAggregator _events;
        #endregion

        #region · Metodos ·
        #endregion
    }
}
