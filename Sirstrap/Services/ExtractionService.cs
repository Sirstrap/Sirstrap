using Sirstrap.Models;
using System;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace Sirstrap.Services
{
    public static class ExtractionService
    {
        public static bool ExtractSelf()
        {
            try
            {
                Extract(Paths.SelfUpdate, AppDomain.CurrentDomain.BaseDirectory);
            }
            catch (Exception) { }

            return ExtractSuccess(true);
        }

        public static bool ExtractRoblox()
        {
            try
            {
                Extract(Paths.RobloxUpdate, Directories.SirstrapVersionsTarget);
            }
            catch (Exception) { }

            return ExtractSuccess();
        }

        private static void Extract(string path, string target)
        {
            using var zip = ZipFile.OpenRead(path);

            foreach (var entry in zip.Entries)
            {
                var subTarget = Path.GetFullPath(Path.Combine(target, entry.FullName));

                Directory.CreateDirectory(subTarget);

                entry.ExtractToFile(subTarget, true);
            }
        }

        private static bool ExtractSuccess(bool isSelf = false)
        {
            return isSelf ?
                AppDomain.CurrentDomain.BaseDirectory.Length > 0 :
                Directory.GetFiles(Directories.SirstrapVersionsTarget).Length > 0;
        }
    }
}
