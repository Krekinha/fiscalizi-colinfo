using Caliburn.Micro;
using Microsoft.EntityFrameworkCore;

namespace FiscaliZi.Colinfo.Assets
{
    public class MainViewModel : PropertyChangedBase
    {
        public MainViewModel()
        {
            IEventAggregator events = new EventAggregator();
            EntradaVM = new EntradaViewModel(events);
            ColetaVM = new ColetaViewModel(events);
        }

        public EntradaViewModel EntradaVM { get; set; }

        public ColetaViewModel ColetaVM { get; set; }

        private void MigrationUpdate()
        {
            using (var context = new ColinfoContext())
            {
                if (context.Database.EnsureCreated())
                {
                    context.Database.Migrate();
                }
                //context.Database.Migrate();

            }
        }
    }
}