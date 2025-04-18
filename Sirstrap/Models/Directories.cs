using System;
using System.IO;
using System.Linq;

namespace Sirstrap.Models
{
    public static class Directories
    {
        private static readonly string _localAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

        public static int SchemaVersion { get; set; } = 1;
        public static string SirstrapLocalAppData { get; set; } = Path.Combine(_localAppData, "Sirstrap");
        public static string RobloxLocalAppData { get; set; } = Path.Combine(_localAppData, "Roblox");
        public static string SirstrapVersions { get; set; } = Path.Combine(SirstrapLocalAppData, "Versions");
        public static string SirstrapFiles { get; set; } = Path.Combine(SirstrapLocalAppData, "Files");

        private static readonly string _sirstrapUpdateCache = Path.Combine(SirstrapFiles, "UpdateCache");

        public static string SelfUpdateCache { get; set; } = Path.Combine(_sirstrapUpdateCache, "Self");
        public static string RobloxUpdateCache { get; set; } = Path.Combine(_sirstrapUpdateCache, "Roblox");
        public static string SirstrapVersionsTarget { get; set; } = string.Empty;
    }
}
