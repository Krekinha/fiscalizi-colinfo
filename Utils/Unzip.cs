using System.IO;
using System.IO.Compression;

namespace FiscaliZi.Colinfo.Utils
{
    public class Unzip
    {
        public static void Start(FileInfo fileToDecompress)
        {
            using (var originalFileStream = fileToDecompress.OpenRead())
            {
                var currentFileName = fileToDecompress.FullName;
                var newFileName = currentFileName.Remove(currentFileName.Length - fileToDecompress.Extension.Length);

                using (var decompressedFileStream = File.Create(newFileName))
                {
                    using (var decompressionStream = new GZipStream(originalFileStream, CompressionMode.Decompress))
                    {
                        decompressionStream.CopyTo(decompressedFileStream);
                    }
                }
            }
        }
    }
}
