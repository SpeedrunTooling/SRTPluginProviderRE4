using System;
using SRTPluginProviderRE4.Structs;
using SRTPluginProviderRE4.Structs.GameStructs;

namespace SRTPluginProviderRE4
{
    public interface IGameMemoryRE4
    {
        // Versioninfo
        string GameName { get; }
        string VersionInfo { get; }

        // Leon HP
        short PlayerCurrentHealth { get; set; }
        short PlayerMaxHealth { get; set; }

        // Ashley HP
        short PlayerCurrentHealth2 { get; set; }
        short PlayerMaxHealth2 { get; set; }

        // Money
        int Money { get; set; }

        int IGT { get; set; }
        TimeSpan IGTTimeSpan { get; }
        string IGTFormattedString { get; }
    }
}