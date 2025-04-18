using System;
using System.IO;
using System.Linq;

namespace Sirstrap.Models
{
    public static class Paths
    {
        public static int SchemaVersion { get; set; } = 1;
        public static string SirstrapConfiguration { get; set; } = Path.Combine(Directories.SirstrapFiles, "Sirstrap.configuration");
        public static string SirstrapLog { get; set; } = Path.Combine(Directories.SirstrapFiles, "Sirstrap.log");
        public static string SelfUpdate { get; set; } = Path.Combine(Directories.SelfUpdateCache, "Sirstrap.zip");
        public static string RobloxUpdate { get; set; } = Path.Combine(Directories.RobloxUpdateCache, "Roblox.zip");
    }
}
