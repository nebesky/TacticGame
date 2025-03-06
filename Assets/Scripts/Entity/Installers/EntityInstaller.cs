using UnityEngine;
using Zenject;

public class EntityInstaller : MonoInstaller
{
    public GameObject fieldContainer;
    
    public override void InstallBindings()
    {
        Container
            .Bind<IEntityFactory>()
            .To<EntityFactory>()
            .AsSingle()
            .WithArguments(fieldContainer);

        Container
            .Bind<IEntitiesController>()
            .To<EntitiesController>()
            .AsSingle();
    }
}