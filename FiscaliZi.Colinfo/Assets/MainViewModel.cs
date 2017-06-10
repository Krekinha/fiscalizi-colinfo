using System;
using Caliburn.Micro;
using MaterialDesignThemes.Wpf;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace FiscaliZi.Colinfo.Assets
{
    public class MainViewModel : PropertyChangedBase, IHandle<NotifyMessage>
    {
        public MainViewModel()
        {
            IEventAggregator events = new EventAggregator();
            events.Subscribe(this);

            EntradaVM = new EntradaViewModel(events);
            ColetaVM = new ColetaViewModel(events);
            ConfigProdutosVM = new ConfigProdutosViewModel(events);
            ConfigClientesVM = new ConfigClientesViewModel(events);
            ConfigGeralVM = new ConfigGeralViewModel(events);
            MigrationUpdate();
            MainMessageQueue = new SnackbarMessageQueue();
        }

        public EntradaViewModel EntradaVM { get; set; }

        public ColetaViewModel ColetaVM { get; set; }

        public ConfigProdutosViewModel ConfigProdutosVM { get; set; }

        public ConfigClientesViewModel ConfigClientesVM { get; set; }
        
        public ConfigGeralViewModel ConfigGeralVM { get; set; }

        private void MigrationUpdate()
        {
            using (var context = new ColinfoContext())
            {
                if (context.Database.EnsureCreated())
                {
                    context.Database.Migrate();
                }
                context.Database.Migrate();

            }
        }

        public SnackbarMessageQueue MainMessageQueue { get; set; }

        public void Handle(NotifyMessage message)
        {
            switch (message.Code)
            {
                case "NOTIFY":
                    MainMessageQueue.Enqueue(message.Message);
                    break;

            }
            
        }
    }
}