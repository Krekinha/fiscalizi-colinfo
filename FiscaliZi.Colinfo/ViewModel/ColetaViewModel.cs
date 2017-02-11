using FiscaliZi.Colinfo.Model;
using GalaSoft.MvvmLight;
using PropertyChanged;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading;
using FiscaliZi.Colinfo.Utils;
using Microsoft.Practices.ServiceLocation;

namespace FiscaliZi.Colinfo.ViewModel
{
    [ImplementPropertyChanged]
    public class ColetaViewModel : ViewModelBase
    {
        private static IDataService dataService;
        const string dir_Pedidos = @"..\Pedidos\";

        public ColetaViewModel(IDataService _dataService)
        {
            dataService = _dataService;
            Vendedores = dataService.GetVendedores();
            InitializeMonitor();
        }

        #region · Properties ·
        public ObservableCollection<Vendedor> Vendedores { get; set; }
        #endregion

        #region · Constructors ·

        private static void InitializeMonitor()
        {
            MonitorTXTPED();
            Monitors.MonitorGZPTPED(@"D:\SOF\VDWIN\PTPED");
            Monitors.MonitorGZPED();
            
        }
        private void AtualizaVendedores()
        {
            var vnds = dataService.GetVendedores();
            Vendedores.Clear();
            foreach (var vnd in vnds)
            {
                Vendedores.Add(vnd);
            }
        }

        public static void MonitorTXTPED()
        {
            if (!Directory.Exists(dir_Pedidos))
            {
                Directory.CreateDirectory(dir_Pedidos);
            }

            var dir = new DirectoryInfo(dir_Pedidos);
            foreach (var file in dir.GetFiles())
            {
                file.Delete();
            }

            var fsw = new FileSystemWatcher(dir_Pedidos, "*.txt");
            fsw.Created += new FileSystemEventHandler(fswTXT_Created);
            fsw.NotifyFilter = NotifyFilters.FileName | NotifyFilters.CreationTime;
            fsw.EnableRaisingEvents = true;

        }
        private static void fswTXT_Created(object sender, FileSystemEventArgs e)
        {
            const int NumberOfRetries = 3000;
            const int DelayOnRetry = 10;

            for (var i = 1; i <= NumberOfRetries; ++i)
            {
                try
                {

                    var vnd = Coletor.getColeta(e.FullPath, e.Name);
                    dataService.AddVendedor(vnd);
                }
                catch (IOException)
                {
                    if (i == NumberOfRetries)
                        throw;

                    Thread.Sleep(DelayOnRetry);
                }
            }
        }

        #endregion
    }
}
