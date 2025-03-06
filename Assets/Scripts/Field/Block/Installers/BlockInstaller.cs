using UnityEngine;
using Zenject;

namespace DefaultNamespace.Installers
{
    public class BlockInstaller : MonoInstaller
    {
        public BlockConfig BlockConfig;
        public GameObject fieldContainer;

        public override void InstallBindings()
        {
            Container
                .Bind<IBlockFactory>()
                .To<BlockFactory>()
                .AsSingle()
                .WithArguments(BlockConfig, fieldContainer)
                .NonLazy();
        }
    }
}