
using System;
using System.Globalization;
using System.Runtime.InteropServices;
using SRTPluginProviderRE4.Structs;
using SRTPluginProviderRE4.Structs.GameStructs;
using System.Diagnostics;
using System.Reflection;

namespace SRTPluginProviderRE4
{
    public class GameMemoryRE4 : IGameMemoryRE4
    {
        public string GameName => "RE4";

        // Versioninfo
        public string VersionInfo => FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion;

        // Leon HP
        public short PlayerCurrentHealth { get => _playerCurrentHealth; set => _playerCurrentHealth = value; }
        internal short _playerCurrentHealth;

        public short PlayerMaxHealth { get => _playerMaxHealth; set => _playerMaxHealth = value; }
        internal short _playerMaxHealth;

        // Ashley HP
        public short PlayerCurrentHealth2 { get => _playerCurrentHealth2; set => _playerCurrentHealth2 = value; }
        internal short _playerCurrentHealth2;

        public short PlayerMaxHealth2 { get => _playerMaxHealth2; set => _playerMaxHealth2 = value; }
        internal short _playerMaxHealth2;

        // Money
        public int Money { get => _money; set => _money = value; }
        internal int _money;

    }
}
