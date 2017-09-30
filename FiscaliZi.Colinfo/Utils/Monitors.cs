using System;
using System.IO;
using System.Threading;

namespace FiscaliZi.Colinfo.Utils
{
    public class Monitors
    {
        static string dir_Pedidos = @"Pedidos\";
        static string DIR_BACKUP_FILE = getZipFolder();

        public static void MonitorGZPTPED(string pathPTPED)
        {
            if (!Directory.Exists(dir_Pedidos))
            {
                Directory.CreateDirectory(dir_Pedidos);
            }

            var fsw = new FileSystemWatcher(pathPTPED, "*.gz");
            fsw.Created += new FileSystemEventHandler(fswGZPTPED_Created);
            fsw.NotifyFilter = NotifyFilters.FileName | NotifyFilters.CreationTime;
            fsw.EnableRaisingEvents = true;
        }

        private static void fswGZPTPED_Created(object sender, FileSystemEventArgs e)
        {
            const int NumberOfRetries = 3000;
            const int DelayOnRetry = 10;

            for (var i = 1; i <= NumberOfRetries; ++i)
            {
                try
                {
                    File.Copy(e.FullPath, dir_Pedidos + e.Name, true);

                    // Descompactar e gurdar backup
                    UnzipAndBackup(e.FullPath, e.Name);
                    
                    break;
                }
                catch (IOException ex)
                {
                    if (i == NumberOfRetries)
                        throw;

                    Thread.Sleep(DelayOnRetry);
                }
            }
        }

        public static void MonitorGZPED()
        {
            if (!Directory.Exists(dir_Pedidos))
            {
                Directory.CreateDirectory(dir_Pedidos);
            }

            var fsw = new FileSystemWatcher(dir_Pedidos, "*.gz");
            fsw.Created += new FileSystemEventHandler(fswGZPED_Created);
            fsw.NotifyFilter = NotifyFilters.FileName | NotifyFilters.CreationTime;
            fsw.EnableRaisingEvents = true;
        }

        private static void fswGZPED_Created(object sender, FileSystemEventArgs e)
        {
            var gzfile = new FileInfo(e.FullPath);
            const int NumberOfRetries = 3000;
            const int DelayOnRetry = 10;

            for (var i = 1; i <= NumberOfRetries; ++i)
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

        private static void UnzipAndBackup(string fullpath, string filename)
        {
            var gzfile = new FileInfo(fullpath);

            Unzip.Start(gzfile);

            if (File.Exists(DIR_BACKUP_FILE + filename))
            {
                File.Delete(DIR_BACKUP_FILE + filename);
            }
            File.Move(fullpath, DIR_BACKUP_FILE + filename);

        }

        private static string getZipFolder() {

            var pc = Environment.MachineName;
            var path = @"F:\SOF\VDWIN\PTPED\ZIPS\";
            if (pc == "ATAIDE-PC")
                path = @"C:\Users\KREKM\Desktop\PTPED\ZIPS\";
            if (pc == "KREKINHA-PC")
                path = @"C:\Users\Krekinha\Desktop\PTPED\ZIPS\";

            return path;
        }
    }
}
