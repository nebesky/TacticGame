using Unity.VisualScripting;
using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(menuName = "ScriptableObject/Installers/blockConfig", fileName = "BlockConfig")]
    public class BlockConfig : ScriptableObject
    {
        [Serialize] public GameObject emptyCell;
        [Serialize] public GameObject blockedCell;
    }
}