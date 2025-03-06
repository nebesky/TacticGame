using BattleStart.Interfaces;
using Zenject;

namespace BattleStart.Installers
{
    public class BattleInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<IBattleController>()
                .To<BattleController>()
                .AsSingle()
                .NonLazy();
        }
    }
}