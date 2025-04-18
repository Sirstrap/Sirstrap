using Sirstrap.Models;
using System;
using System.IO;
using System.Linq;

namespace Sirstrap.Services
{
    public static class FilesService
    {
        public static bool CreateFiles()
        {
            try
            {
                CreateDirectoryIfNotExists(Directories.SelfUpdateCache);
                CreateDirectoryIfNotExists(Directories.RobloxUpdateCache);
                CreateFileIfNotExists(Paths.SirstrapConfiguration);
                CreateFileIfNotExists(Paths.SirstrapLog);
            }
            catch (Exception) { }

            return CreateFilesSuccess();
        }

        private static void CreateDirectoryIfNotExists(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            else
            {
                DirectoryInfo directoryInfo = new(path);

                foreach (FileInfo file in directoryInfo.GetFiles())
                    file.Delete();

                foreach (DirectoryInfo directory in directoryInfo.GetDirectories())
                    directory.Delete(true);
            }

            return;
        }

        private static void CreateFileIfNotExists(string path)
        {
            if (!File.Exists(path))
                File.Create(path).Close();

            return;
        }

        private static bool CreateFilesSuccess()
        {
            return Directory.Exists(Directories.SelfUpdateCache) &&
                Directory.Exists(Directories.RobloxUpdateCache) &&
                File.Exists(Paths.SirstrapConfiguration) &&
                File.Exists(Paths.SirstrapLog);
        }
    }
}
