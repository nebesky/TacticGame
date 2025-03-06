public class EntityModel : IEntityModel
{
    public string Name;
    public int CurrentHealth = 1;
    public int MaxHealth = 1;
    public int CurrentMana = 1;
    public int MaxMana = 1;
    public int CurrentMove = 1;
    public int MaxMove = 1;
    public int Vision = 1;
    public int Power = 1;
    public int Level = 1;
    public int Experience = 1;
    public int Attack = 1;
    public int Dexterity = 1;
    public SkillBuffType SkillBuffType;
    public SkillDebuffType SkillDebuffType;
}

public interface IEntityModel {}
