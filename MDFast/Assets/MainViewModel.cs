using Caliburn.Micro;
using FiscaliZi.MDFast.Model;
using FiscaliZi.MDFast.ViewModel;
using MahApps.Metro.Controls.Dialogs;
using MaterialDesignThemes.Wpf;

namespace FiscaliZi.MDFast.Assets
{
    public class MainViewModel : PropertyChangedBase, IHandle<NotifyMessage>
    {
        public MainViewModel()
        {
            IEventAggregator events = new EventAggregator();
            IDialogCoordinator dialogCoordinator = new DialogCoordinator();

            events.Subscribe(this);

            #region · ViewModels Call ·
            EntradaVM = new EntradaViewModel(events);
            ConfigVeiculosVM = new ConfigVeiculosViewModel(events);
            #endregion

        }

        #region · ViewModels Scope ·
        public HomeViewModel HomeVM { get; set; }
        public EntradaViewModel EntradaVM { get; set; }
        public ConfigVeiculosViewModel ConfigVeiculosVM { get; set; }
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