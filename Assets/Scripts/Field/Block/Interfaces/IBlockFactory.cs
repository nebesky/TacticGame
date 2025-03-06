using DefaultNamespace.Interfaces;
using UnityEngine;
using UnityEngine.Tilemaps;

public interface IBlockFactory : ICommonFactory
{
    public IBlock Create(EditorCellType editorCellType, Vector2Int position);
}
