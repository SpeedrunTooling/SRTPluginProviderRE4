using System.Runtime.InteropServices;

namespace SRTPluginProviderRE4.Structs.GameStructs
{
    [StructLayout(LayoutKind.Explicit, Pack = 1, Size = 8)]
    public struct PlayerKills
    {
        [FieldOffset(0x0)] private int chapterKills;
        [FieldOffset(0x4)] private int kills;

        public int ChapterKills => chapterKills;
        public int Kills => kills;
    }
}
