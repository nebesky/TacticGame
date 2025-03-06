using System;
using Level.Installer;
using UnityEngine;
using Zenject;

namespace Level
{
    public class LevelsInstaller : MonoInstaller
    {
        public LevelRawData[] _levels;
    
        public override void InstallBindings()
        {
            Container
                .Bind<ILevelDataProvider>()
                .To<LevelDataProvider>()
                .AsSingle()
                .WithArguments(_levels).NonLazy();
        }
    }

    [Serializable]
    public class LevelRawData
    {
        public string name;
        public TextAsset value;
    }
}