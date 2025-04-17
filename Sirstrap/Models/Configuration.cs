using System;
using System.Linq;

namespace Sirstrap.Models
{
    public static class Configuration
    {
        public static int SchemaVersion { get; set; } = 1;
        public static string CdnUrl { get; set; } = "https://setup.rbxcdn.com";
        public static bool MultiInstanceEnabled { get; set; } = true;
    }
}
