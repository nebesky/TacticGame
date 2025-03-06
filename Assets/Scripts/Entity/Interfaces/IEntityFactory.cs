using GameSession;

public interface IEntityFactory : ICommonFactory
{
    IEntity Create(EntityModel entityModel);
}