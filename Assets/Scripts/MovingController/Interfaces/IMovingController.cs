using System;
using System.Collections.Generic;
using UnityEngine;

namespace MovingController.Interfaces
{
    public interface IMovingController
    {
        void MoveEntity(IEnumerable<Vector2Int> steps);
    }
}