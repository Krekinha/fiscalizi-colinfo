using FiscaliZi.Colinfo.ViewModel;

namespace FiscaliZi.Colinfo
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            Closing += (s, e) => ViewModelLocator.Cleanup();
        }
    }
}
