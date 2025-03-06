using UnityEngine;

public class FieldPositionProvider : IFieldPositionProvider
{
    public Vector3 GetFieldPosition(Vector2Int position)
    {
        var odd = position.y % 2 == 0 ? 0f : 1f;
        return new Vector3(position.x * 2f + odd, 0, position.y * 2f);
    }
}