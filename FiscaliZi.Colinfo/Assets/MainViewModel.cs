using Caliburn.Micro;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace FiscaliZi.Colinfo.Assets
{
    public class MainViewModel : PropertyChangedBase
    {
        public MainViewModel()
        {
            IEventAggregator events = new EventAggregator();
            EntradaVM = new EntradaViewModel(events);
            ColetaVM = new ColetaViewModel(events);
            ConfigProdutosVM = new ConfigProdutosViewModel(events);
            ConfigClientesVM = new ConfigClientesViewModel(events);
            MigrationUpdate();
        }

        public EntradaViewModel EntradaVM { get; set; }

        public ColetaViewModel ColetaVM { get; set; }

        public ConfigProdutosViewModel ConfigProdutosVM { get; set; }

        public ConfigClientesViewModel ConfigClientesVM { get; set; }

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
    }
}