using Sirstrap.Models;
using System;
using System.Linq;

namespace Sirstrap.Services
{
    public static class UrlsService
    {
        public static string GetFileUrl(string fileName)
        {
            return $"{GetBaseUrl()}{fileName}";
        }

        public static string GetManifestUrl()
        {
            return $"{GetBaseUrl()}rbxPkgManifest.txt";
        }

        private static string GetBaseUrl()
        {
            var baseUrl = DownloadConfiguration.ChannelName.Equals("LIVE") ?
                Configuration.CdnUrl :
                $"{Configuration.CdnUrl}/channel/{DownloadConfiguration.ChannelName}";

            return baseUrl += $"{DownloadConfiguration.BlobDirectory}{DownloadConfiguration.VersionHash}-";
        }
    }
}
