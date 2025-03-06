using System;
using System.Collections.Generic;
using System.Linq;
using DefaultNamespace.Interfaces;
using Level.Structs;
using UnityEngine;

namespace Field
{
    public class Field : IField, IDisposable
    {
        private readonly Dictionary<Vector2Int, IBlock> _cells = new ();
        private readonly IBlockFactory _blockFactory;
        private bool IsInteractable = false;

        public Field(IBlockFactory blockFactory) 
        {
            _blockFactory = blockFactory;

            //temp
            IsInteractable = true;
        }

        public void SetFieldCells(List<CellData> Cells)
        {
            throw new NotImplementedException();
        }

        public Vector3 GetCellPosition(Vector2Int cell)
        {
            var cellObject = _cells.FirstOrDefault(c => c.Key == cell);

            if (cellObject.Value == null) throw new Exception("Trying to get null cell.");

            return cellObject.Value.Position;
        }

        public IEnumerable<Vector2Int> FreeCells =>
              _cells
                  .Where(c => !c.Value.IsBlocked)
                  .Select(c => c.Value.Coordinate)
                  .ToList();

        public event Action<Vector2Int> OnFieldClick;
        public IList<Vector2Int> GetNeighborCellCoordinates(Vector2Int cellCoordinate)
        {
            throw new NotImplementedException();
        }

        public void SetFieldCells(Dictionary<Vector2Int, EditorCellType> Cells)
        {
            if (!IsInteractable) return;
            IsInteractable = true;

            foreach (var levelDataCell in Cells)
            {
                var cell = _blockFactory.Create(levelDataCell.Value, levelDataCell.Key);

                cell.OnFieldClick += CellOnFieldClick;

                _cells.Add(levelDataCell.Key, cell);
            }
        }

        private void CellOnFieldClick(Vector2Int coordinate)
        {
            Debug.Log(coordinate);

            OnFieldClick?.Invoke(coordinate);
        }

        public void Dispose()
        {

        }
    }
}