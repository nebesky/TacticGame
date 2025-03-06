using UnityEngine;

public interface IFieldPositionProvider
{
    Vector3 GetFieldPosition(Vector2Int position);
}