using System;
using UnityEngine;

namespace DefaultNamespace.Interfaces
{
    public interface IBlock
    {
        bool IsBlocked { get; }
        Vector3 Position { get; }
        Vector2Int Coordinate { get; }
        event Action<Vector2Int> OnFieldClick;
    }
}