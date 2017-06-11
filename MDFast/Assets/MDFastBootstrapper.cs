using System.Windows;
using Caliburn.Micro;

namespace FiscaliZi.MDFast.Assets
{
    public class MDFastBootstrapper : BootstrapperBase
    {
        public MDFastBootstrapper()
        {
            Initialize();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<MainViewModel>();
        }
    }
}
