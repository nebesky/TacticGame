namespace Level
{
    public interface ILevelDataProvider
    {
        LevelData Get(string levelName);
        string Serialize(LevelData level);
    }
}