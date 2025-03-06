using DefaultNamespace.Enums;
using UnityEngine;
using Vector2 = System.Numerics.Vector2;

namespace DefaultNamespace
{
    public class BlockView : MonoBehaviour, IBlockView
    {
        public Sprite asset;

        public void SetParent(Transform parent)
        {
            gameObject.transform.parent = parent;
        }

        public void SetPosition(Vector2 position)
        {
            gameObject.transform.position = new Vector3(position.X, position.Y, 0);
        }

        public void SetSprite(Sprite sprite)
        {
            asset = sprite;
        }

        public Vector2Int Position { get; set; }
        public void Show()
        {
            throw new System.NotImplementedException();
        }

        public void Hide()
        {
            throw new System.NotImplementedException();
        }

        public void SetHelper(BlockHelperType blockHelperType)
        {
            throw new System.NotImplementedException();
        }
    }
}