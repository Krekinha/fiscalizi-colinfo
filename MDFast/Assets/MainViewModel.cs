using Caliburn.Micro;
using FiscaliZi.MDFast.Model;
using FiscaliZi.MDFast.ViewModel;
using MaterialDesignThemes.Wpf;

namespace FiscaliZi.MDFast.Assets
{
    public class MainViewModel : PropertyChangedBase, IHandle<NotifyMessage>
    {
        public MainViewModel()
        {
            IEventAggregator events = new EventAggregator();
            events.Subscribe(this);

            #region · ViewModels Scope ·
            #endregion

        }

        #region · ViewModels Scope ·
        #endregion

        #region · Properties ·
        public SnackbarMessageQueue MainMessageQueue { get; set; }
        #endregion

        #region · Methods ·
        public void Handle(NotifyMessage message)
        {
            switch (message.Code)
            {
                case "NOTIFY":
                    MainMessageQueue.Enqueue(message.Message);
                    break;

            }

        }
        #endregion




    }
}