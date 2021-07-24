using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace SRTPluginProviderRE4.Structs.GameStructs
{
    [StructLayout(LayoutKind.Explicit, Pack = 1, Size = 8)]
    class Kills
    {
        [FieldOffset(0x0)] private int chapterKills;
        [FieldOffset(0x4)] private int kills;

        public int ChapterKills => chapterKills;
        public int Kills => kills;
    }
}
