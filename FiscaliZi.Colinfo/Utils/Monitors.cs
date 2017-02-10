using FiscaliZi.Colinfo.ViewModel;
using FiscaliZi.Colinfo.Model;
using Microsoft.Practices.ServiceLocation;
using System.IO;
using System.Threading;

namespace FiscaliZi.Colinfo.Utils
{
    public class Monitors
    {
        static string folderPedidos = @"..\Pedidos\";

        public static void MonitorGZPTPED(string pathPTPED)
        {
            if (!Directory.Exists(folderPedidos))
            {
                Directory.CreateDirectory(folderPedidos);
            }

            FileSystemWatcher fsw = new FileSystemWatcher(pathPTPED, "*.gz");
            fsw.Created += new FileSystemEventHandler(fswGZPTPED_Created);
            fsw.NotifyFilter = NotifyFilters.FileName | NotifyFilters.CreationTime;
            fsw.EnableRaisingEvents = true;
        }

        private static void fswGZPTPED_Created(object sender, FileSystemEventArgs e)
        {
            int NumberOfRetries = 3000;
            int DelayOnRetry = 10;

            for (int i = 1; i <= NumberOfRetries; ++i)
            {
                try
                {
                    File.Copy(e.FullPath, folderPedidos + e.Name, true);
                    break;
                }
                catch (IOException)
                {
                    if (i == NumberOfRetries)
                        throw;

                    Thread.Sleep(DelayOnRetry);
                }
            }
        }

        public static void MonitorGZPED()
        {
            if (!Directory.Exists(folderPedidos))
            {
                Directory.CreateDirectory(folderPedidos);
            }

            FileSystemWatcher fsw = new FileSystemWatcher(folderPedidos, "*.gz");
            fsw.Created += new FileSystemEventHandler(fswGZPED_Created);
            fsw.NotifyFilter = NotifyFilters.FileName | NotifyFilters.CreationTime;
            fsw.EnableRaisingEvents = true;
        }

        private static void fswGZPED_Created(object sender, FileSystemEventArgs e)
        {
            FileInfo gzfile = new FileInfo(e.FullPath);
            int NumberOfRetries = 3000;
            int DelayOnRetry = 10;

            for (int i = 1; i <= NumberOfRetries; ++i)
            {
                try
                {
                    Unzip.Start(gzfile);
                    File.Delete(e.FullPath);
                    break;
                }
                catch (IOException)
                {
                    if (i == NumberOfRetries)
                        throw;

                    Thread.Sleep(DelayOnRetry);
                }
            }
        }

        public static void MonitorTXTPED()
        {
            if (!Directory.Exists(folderPedidos))
            {
                Directory.CreateDirectory(folderPedidos);
            }

            DirectoryInfo dir = new DirectoryInfo(folderPedidos);
            foreach (FileInfo file in dir.GetFiles())
            {
                file.Delete();
            }

            FileSystemWatcher fsw = new FileSystemWatcher(folderPedidos, "*.txt");
            fsw.Created += new FileSystemEventHandler(fswTXT_Created);
            fsw.NotifyFilter = NotifyFilters.FileName | NotifyFilters.CreationTime;
            fsw.EnableRaisingEvents = true;

        }
        private static void fswTXT_Created(object sender, FileSystemEventArgs e)
        {
            int NumberOfRetries = 3000;
            int DelayOnRetry = 10;

            for (int i = 1; i <= NumberOfRetries; ++i)
            {
                try
                {

                    Vendedor vnd = Coletor.getColeta(e.FullPath, e.Name);
                    var vm = ServiceLocator.Current.GetInstance<ColetaViewModel>();
                    App.Current.Dispatcher.Invoke(delegate
                    {
                        //vm.SalvarVendedor(vnd);
                    });
                    break;
                }
                catch (IOException)
                {
                    if (i == NumberOfRetries)
                        throw;

                    Thread.Sleep(DelayOnRetry);
                }
            }
        }
    }
}
