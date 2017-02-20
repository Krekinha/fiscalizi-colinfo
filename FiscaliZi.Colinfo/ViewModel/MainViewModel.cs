using GalaSoft.MvvmLight;
using Microsoft.EntityFrameworkCore;

namespace FiscaliZi.Colinfo.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            //MigrationUpdate();
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
        }

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