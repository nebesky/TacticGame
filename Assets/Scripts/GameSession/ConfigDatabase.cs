using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace GameSession
{
    [CreateAssetMenu(menuName = "ScriptableObject/Installers/configInstaller", fileName = "ConfigInstaller")]
    public class configDatabase : ScriptableObjectInstaller
    {
        [SerializeField] private List<IEntityView> _defaultSettings;
        
        public override void InstallBindings()
        {
            Container.Bind<EntityFactory>().AsSingle();
        }
    }
}