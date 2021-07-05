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
        GameSaveData GameData { get; set; }
        TimeSpan IGTTimeSpan { get; }
        string IGTFormattedString { get; }
    }
}