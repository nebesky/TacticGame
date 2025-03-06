using PlayerMode.Enums;
using PlayerMode.Interfaces;
using PlayerMode.Strategies;
using Zenject;

namespace PlayerMode.Installers
{
    public class PlayerModeInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<IPlayerMode>()
                .To<Selector.PlayerMode>()
                .AsSingle();

            Container
                .Bind<IPlayerModeState>()
                .WithId(PlayerModeType.Moving)
                .To<MovePlayerModeState>()
                .AsSingle()
                .WhenInjectedInto<Selector.PlayerMode>();

            Container
                .Bind<IPlayerModeState>()
                .WithId(PlayerModeType.Attack)
                .To<AttackPlayerModeState>()
                .AsSingle()
                .WhenInjectedInto<Selector.PlayerMode>();
        }
    }
}