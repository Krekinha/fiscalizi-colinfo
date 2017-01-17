using System.Windows;
using FiscaliZi.MDFast.ViewModel;
using MahApps.Metro;

namespace FiscaliZi.MDFast
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        /// <summary>
        /// Initializes a new instance of the MainWindow class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            Closing += (s, e) => ViewModelLocator.Cleanup();
        }

        private void ChangeAccent()
        {
            var acc = new Accent();
            
            var theme = ThemeManager.DetectAppStyle(Application.Current);
            var accent = ThemeManager.GetAccent(this.Name);
            
            ThemeManager.ChangeAppStyle(Application.Current, accent, theme.Item1);
        }
    }
}