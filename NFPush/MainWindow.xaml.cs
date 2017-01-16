using NFPush.ViewModel;

namespace NFPush
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