using System.Runtime.InteropServices;

namespace SRTPluginProviderRE4.Structs.GameStructs
{
    [StructLayout(LayoutKind.Explicit, Pack = 1, Size = 892)]

    public struct GameSaveData
    {
        [FieldOffset(0x0)] private int rankScore;
        [FieldOffset(0x14)] private int money;
        [FieldOffset(0x378)] private int igtFrames;


        public int RankScore => rankScore;
        public int Money => money;
        public int IGTFrames => igtFrames;
    }
}