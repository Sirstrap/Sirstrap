using System;
using System.Linq;

namespace Sirstrap.Models
{
    public static class DownloadConfiguration
    {
        public static Enums.BinaryType BinaryType { get; set; } = Enums.BinaryType.WindowsPlayer;
        public static string ChannelName { get; set; } = "LIVE";
        public static string VersionHash { get; set; } = string.Empty;
        public static bool CompressOutputZip { get; set; }
        public static int ZipCompressionLevel { get; set; } = 5;
        public static string BlobDirectory { get; set; } = "/";
    }
}
