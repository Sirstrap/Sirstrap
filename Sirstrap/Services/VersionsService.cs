using Sirstrap.Models;
using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Sirstrap.Services
{
    public static class VersionsService
    {
        private static readonly HttpService _httpService = new(new HttpClient()
        {
            Timeout = TimeSpan.FromMinutes(5)
        });

        public static async Task<bool> SetVersionAsync()
        {
            try
            {
                string versionHash = await GetVersionAsync();

                DownloadConfiguration.VersionHash = versionHash;
                Directories.SirstrapVersionsTarget = Path.Combine(Directories.SirstrapVersions, versionHash);

                CreateDirectoryIfNotExists(Directories.SirstrapVersionsTarget);
            }
            catch (Exception) { }

            return SetVersionAsyncSuccess();
        }

        private static async Task<string> GetVersionAsync()
        {
            try
            {
                if (DownloadConfiguration.BinaryType.Equals("WindowsPlayer"))
                {
                    JsonDocument jsonDocument = await GetJsonDocumentAsync();

                    if (jsonDocument != null)
                        if (jsonDocument.RootElement.TryGetProperty("clientVersionUpload", out JsonElement clientVersionUpload))
                            return clientVersionUpload.ToString();
                }
            }
            catch (Exception) { }

            return string.Empty;
        }

        private static async Task<JsonDocument> GetJsonDocumentAsync()
        {
            return JsonDocument.Parse(await _httpService.GetStringAsync("https://clientsettingscdn.roblox.com/v1/client-version/WindowsPlayer", 5));
        }

        private static void CreateDirectoryIfNotExists(string path)
        {
            if (!Directory.Exists(path))
            {
                string? parentDirectory = Path.GetDirectoryName(path);

                if (Directory.Exists(parentDirectory))
                {
                    DirectoryInfo directoryInfo = new(parentDirectory);

                    foreach (FileInfo file in directoryInfo.GetFiles())
                        file.Delete();

                    foreach (DirectoryInfo directory in directoryInfo.GetDirectories())
                        directory.Delete(true);
                }

                Directory.CreateDirectory(path);
            }

            return;
        }

        private static bool SetVersionAsyncSuccess()
        {
            return DownloadConfiguration.VersionHash != string.Empty &&
                Directories.SirstrapVersionsTarget != string.Empty &&
                Directory.Exists(Directories.SirstrapVersionsTarget);
        }
    }
}
