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
                CreateDirectoryIfNotExists(Directories.SirstrapFiles);
                CreateFileIfNotExists(Paths.SirstrapConfiguration);
                CreateFileIfNotExists(Paths.SirstrapLog);
            }
            catch (Exception) { }

            return CreateFilesSuccess();
        }

        private static void CreateDirectoryIfNotExists(string path)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

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
            return Directory.Exists(Directories.SirstrapFiles) &&
                File.Exists(Paths.SirstrapConfiguration) &&
                File.Exists(Paths.SirstrapLog);
        }
    }
}
