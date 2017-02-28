using Caliburn.Micro;
using Microsoft.EntityFrameworkCore;

namespace FiscaliZi.Colinfo.Assert
{
    public class MainViewModel : PropertyChangedBase
    {
        public MainViewModel()
        {
            IEventAggregator events = new EventAggregator();
            ColetaVM = new ColetaViewModel(events);
        }

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