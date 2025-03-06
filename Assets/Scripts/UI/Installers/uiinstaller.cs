using UI.Interfaces;
using UnityEngine;
using Zenject;

namespace UI.Installers
{
    public class uiinstaller : MonoInstaller
    {
        public GameObject MainBarViewPrefab;
        public Transform CanvasTransform;

        public override void InstallBindings()
        {
            Container
                .Bind<IMainBarView>()
                .To<MainBarView>()
                .AsSingle()
                .WithArguments(MainBarViewPrefab, CanvasTransform)
                .NonLazy();
        }
    }
}