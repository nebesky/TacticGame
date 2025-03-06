using System;
using System.Collections.Generic;
using Level.Structs;

namespace Level
{
    [Serializable]
    public struct LevelData
    {
        public string Name;
        public List<CellData> Cells;
        public List<SideData> Sides;
    }
}