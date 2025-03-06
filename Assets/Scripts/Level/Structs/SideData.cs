using System;
using System.Collections.Generic;
using UnityEngine;

namespace Level.Structs
{
    [Serializable]
    public struct SideData
    {
        public TeamData TeamData { get; }
        public List<Vector2Int> HeroPositions { get; } 

        public SideData(TeamData teamData, List<Vector2Int> heroPositions)
        {
            TeamData = teamData;
            HeroPositions = heroPositions;
        }
    }
}