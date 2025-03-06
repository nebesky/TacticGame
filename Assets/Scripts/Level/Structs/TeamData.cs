using DefaultNamespace.Hero.Enums;

public struct TeamData
{
    public TeamSideType SideType { get; }
    public ColorJSON Color { get; }

    public TeamData(TeamSideType teamSideType, ColorJSON colorJson)
    {
        SideType = teamSideType;
        Color = colorJson;
    }
}