using System.Runtime.InteropServices;

namespace SRTPluginProviderRE4.Structs.GameStructs
{
    [StructLayout(LayoutKind.Explicit, Pack = 1, Size = 892)]

    public struct GameSaveData
    {
        [FieldOffset(0x0)] private int rankScore;
        [FieldOffset(0x14)] private int money;
        [FieldOffset(0x20)] private short leonCurrentHP;
        [FieldOffset(0x22)] private short leonMaxHP;
        [FieldOffset(0x24)] private short ashleyCurrentHP;
        [FieldOffset(0x26)] private short ashleyMaxHP;
        [FieldOffset(0x378)] private int igtFrames;

        public int RankScore => rankScore;
        public int Money => money;
        public short LeonCurrentHP => leonCurrentHP;
        public short LeonMaxHP => leonMaxHP;
        public short AshleyCurrentHP => ashleyCurrentHP;
        public short AshleyMaxHP => ashleyMaxHP;
        public int IGTFrames => igtFrames;
    }
}