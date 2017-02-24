using System.Windows;
using Caliburn.Micro;

namespace FiscaliZi.Colinfo.ViewModel
{
    public class ColinfoBootstrapper : BootstrapperBase
    {

        public ColinfoBootstrapper()
        {
                Initialize();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ColetaViewModel>();
        }

    }
}
