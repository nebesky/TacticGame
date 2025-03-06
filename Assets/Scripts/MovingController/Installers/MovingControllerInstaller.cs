using MovingController.Interfaces;
using Zenject;

public class MovingControllerInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container
            .Bind<IMovingController>()
            .To<MovingController.MovingController>()
            .AsSingle()
            .NonLazy();
    }
}