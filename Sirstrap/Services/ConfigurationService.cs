using Sirstrap.Models;
using System;
using System.IO;
using System.Linq;

namespace Sirstrap.Services
{
    public static class ConfigurationService
    {
        public static bool SetConfiguration()
        {
            try
            {
                if (File.Exists(Paths.SirstrapConfiguration))
                {
                    GetConfiguration();

                    return true;
                }
            }
            catch (Exception) { }

            return false;
        }

        private static void GetConfiguration()
        {
            string[] rawConfiguration = File.ReadAllLines(Paths.SirstrapConfiguration);

            if (rawConfiguration.Length == 0)
                WriteConfiguration();

            foreach (string line in rawConfiguration)
            {
                if (string.IsNullOrWhiteSpace(line) ||
                    line.StartsWith('#'))
                    continue;

                int equalsIndex = line.IndexOf('=');

                if (equalsIndex > 0)
                {
                    string key = line[..equalsIndex].Trim();
                    string value = line[(equalsIndex + 1)..].Trim();

                    switch (key.ToLower())
                    {
                        case "schemaversion":
                            if (!Configuration.SchemaVersion.Equals(value))
                                WriteConfiguration();
                            return;
                        case "cdnurl":
                            Configuration.CdnUrl = value;
                            break;
                        case "multiinstanceenabled":
                            Configuration.MultiInstanceEnabled = value.ToLower().Equals("true");
                            break;
                        default:
                            break;
                    }
                }
            }

            return;
        }

        private static void WriteConfiguration()
        {
            string[] rawConfiguration =
            [
                $"SchemaVersion={Configuration.SchemaVersion}",
                $"CdnUrl={Configuration.CdnUrl}",
                $"MultiInstanceEnabled={Configuration.MultiInstanceEnabled}"
            ];

            File.WriteAllLines(Paths.SirstrapConfiguration, rawConfiguration);

            return;
        }
    }
}
