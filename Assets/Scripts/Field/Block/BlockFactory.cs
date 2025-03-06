using DefaultNamespace.Interfaces;
using UnityEngine;
using Zenject;

namespace DefaultNamespace
{
    public class BlockFactory : IBlockFactory
    {
        private readonly BlockConfig _blockConfig;
        private readonly DiContainer _diContainer;
        private readonly GameObject _fieldContainer;

        public BlockFactory(
            BlockConfig blockConfig, 
            DiContainer diContainer,
            GameObject fieldContainer)
        {
            _blockConfig = blockConfig;
            _diContainer = diContainer;
            _fieldContainer = fieldContainer;
        }

        public void Load()
        {

        }

        public IBlock Create(EditorCellType editorCellType, Vector2Int position)
        {
            var go = _diContainer.InstantiatePrefab(editorCellType == EditorCellType.Blocked
                ? _blockConfig.blockedCell
                : _blockConfig.emptyCell);

            go.transform.SetParent(_fieldContainer.transform);
            go.transform.SetLocalPositionAndRotation(GetFieldPosition(position), Quaternion.identity);

            return new Block(editorCellType == EditorCellType.Blocked, go, position);
        }

        private Vector3 GetFieldPosition(Vector2Int position)
        {
            //TODO to config
            var odd = position.y % 2 == 0 ? 0f : 1f;
            return new Vector3(position.x * 2f + odd, 0, position.y * 2f);
        }
    }
}