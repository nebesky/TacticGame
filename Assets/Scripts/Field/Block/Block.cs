using System;
using DefaultNamespace.Interfaces;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace DefaultNamespace
{
    public class Block : IBlock, IDisposable
    {
        private readonly GameObject _gameObject;
        public Tile Tile { get; }
        public bool IsBlocked { get; }

        public Vector3 Position => _gameObject.transform.position;
        public Vector2Int Coordinate { get; }
        public event Action<Vector2Int> OnFieldClick;

        public Block(bool isBlocked, GameObject gameObject, Vector2Int coordinate)
        {
            Coordinate = coordinate;
            _gameObject = gameObject;
            IsBlocked = isBlocked;

            var cell = _gameObject.GetComponent<Cell>();
            
            cell.xT.text = coordinate.x.ToString();
            cell.yT.text = coordinate.y.ToString();
            
            cell.OnClick += OnClick;
        }

        private void OnClick(Transform transform)
        {
            OnFieldClick?.Invoke(Coordinate);
        }

        public void Dispose()
        {
            
        }
    }
}