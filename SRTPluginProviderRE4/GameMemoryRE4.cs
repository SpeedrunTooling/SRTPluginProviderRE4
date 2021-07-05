
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
        private const string IGT_TIMESPAN_STRING_FORMAT = @"hh\:mm\:ss";
        public string GameName => "RE4";

        // Versioninfo
        public string VersionInfo => FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion;

        // Game Data
        public GameSaveData GameData { get => _gameData; set => _gameData = value; }
        internal GameSaveData _gameData;

        public TimeSpan IGTTimeSpan
        {
            get
            {
                TimeSpan timespanIGT;

                if (GameData.IGTFrames >= 0f)
                    timespanIGT = TimeSpan.FromSeconds(GameData.IGTFrames / 60);
                else
                    timespanIGT = new TimeSpan();

                return timespanIGT;
            }
        }

        public string IGTFormattedString => IGTTimeSpan.ToString(IGT_TIMESPAN_STRING_FORMAT, CultureInfo.InvariantCulture);
    }
}
