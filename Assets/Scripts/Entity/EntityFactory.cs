using DefaultNamespace.Entity;
using GameSession;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

public class EntityFactory : IEntityFactory
{
    private readonly DiContainer _diContainer;
    private Object _hero;
    private const string WizardAssetName = "Prefabs\\Wizard";
    private readonly GameObject _fieldContainer;
    private IFieldPositionProvider _fieldPositionProvider;

    public EntityFactory(
        DiContainer diContainer,
        GameObject fieldContainer,
        IFieldPositionProvider fieldPositionProvider)
    {
        _fieldPositionProvider = fieldPositionProvider;
        _diContainer = diContainer;
        _fieldContainer = fieldContainer;

        Load();
    }

    public void Load()
    {
        _hero = Resources.Load(WizardAssetName);
    }

    public IEntity Create(EntityModel entityModel)
    {
        var entityGameObject = _diContainer.InstantiatePrefab(_hero);
        entityGameObject.transform.SetParent(_fieldContainer.transform);

        var entityView = entityGameObject.GetComponent<EntityView>();

        return new Entity(entityModel, entityView);
    }
}