using DefaultNamespace.Hero.Enums;
using UnityEngine;

namespace Level.Structs
{
    public struct CellData
    {
        public Vector2Int Position { get; } 
        public CellType Type { get; }
        
        public CellData(CellType type, Vector2Int position)
        {
            Type = type;
            Position = position;
        }
    }
}