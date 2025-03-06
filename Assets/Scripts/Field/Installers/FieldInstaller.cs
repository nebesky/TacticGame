using System;
using UnityEngine.Tilemaps;
using Zenject;

namespace Field.Installers
{
    public class FieldInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<IFieldPositionProvider>()
                .To<FieldPositionProvider>()
                .AsSingle();

            Container
                .Bind<IField>()
                .To<Field>()
                .AsSingle()
                .NonLazy();
        }
    }

    [Serializable]
    public class TileBaseRaw
    {
        public string name;
        public TileBase value;
    }
}