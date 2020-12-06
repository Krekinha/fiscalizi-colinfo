using System.Windows;
using Caliburn.Micro;

namespace FiscaliZi.Colinfo.Assets
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
