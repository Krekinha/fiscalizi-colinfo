using System.Windows;
using GalaSoft.MvvmLight.Threading;
using MahApps.Metro;
using System;

namespace NFPush
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        static App()
        {
            DispatcherHelper.Initialize();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            // get the current app style (theme and accent) from the application
            // you can then use the current theme and custom accent instead set a new theme
            Tuple<AppTheme, Accent> appStyle = ThemeManager.DetectAppStyle(Application.Current);

            // now set the Green accent and dark theme
            ThemeManager.ChangeAppStyle(Application.Current,
                                        ThemeManager.GetAccent("Steel"),
                                        ThemeManager.GetAppTheme("BaseLight")); // or appStyle.Item1

            base.OnStartup(e);
        }
    }
}
