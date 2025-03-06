using System;
using System.Collections.Generic;
using System.Linq;
using Extensions;
using Newtonsoft.Json;

namespace Level.Installer
{
    public class LevelDataProvider : ILevelDataProvider
    {
        private readonly IReadOnlyList<LevelRawData> _levelRawDatas;

        public LevelDataProvider(IReadOnlyList<LevelRawData> levelRawDatas)
        {
            _levelRawDatas = levelRawDatas;
        }

        public LevelData Get(string levelName)
        {
            var valueText = _levelRawDatas
                .FirstOrDefault(level => level.name == levelName)
                ?.value.text;

            return valueText != null
                ? JsonConvert.DeserializeObject<LevelData>(valueText, new LevelDataConverter())
                : throw new Exception("Not found level " + levelName);
        }

        public string Serialize(LevelData level)
        {
            return JsonConvert.SerializeObject(level);
        }
    }
}