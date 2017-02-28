using System.Windows;
using Caliburn.Micro;

namespace FiscaliZi.Colinfo.Assert
{
    public class ColinfoBootstrapper : BootstrapperBase
    {

        public ColinfoBootstrapper()
        {
                Initialize();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<MainViewModel>();
        }

    }
}
