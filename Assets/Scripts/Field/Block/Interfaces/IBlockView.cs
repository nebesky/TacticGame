using DefaultNamespace.Enums;
using UnityEngine;

public interface IBlockView
{
    Vector2Int Position { get; set; }

    void Show();
    void Hide();
    void SetHelper(BlockHelperType blockHelperType);
}
