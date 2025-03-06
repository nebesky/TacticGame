using System;
using System.Collections.Generic;
using Level.Structs;
using UnityEngine;

namespace Field
{
    public interface IField
    {
        void SetFieldCells(List<CellData> Cells);
        Vector3 GetCellPosition(Vector2Int cell);
        IEnumerable<Vector2Int> FreeCells { get; }
        event Action<Vector2Int> OnFieldClick;

    }
}