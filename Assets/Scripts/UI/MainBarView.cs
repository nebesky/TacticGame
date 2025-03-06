using GameSession;
using UI.Interfaces;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace UI
{
    public class MainBarView : IMainBarView
    {
        private readonly DiContainer _diContainer;
        private readonly MainBarBehavior _mainbar;

        public MainBarView(Object mainBar, Transform canvasTransform, DiContainer diContainer)
        {
            _diContainer = diContainer;
            var mainBarObject = _diContainer.InstantiatePrefab(mainBar, canvasTransform);
            _mainbar = mainBarObject.GetComponent<MainBarBehavior>();
        }

        public void SetPlayerHero(IEntity entity)
        {
            _mainbar.SetCaption(entity.Name);
        }
    }
}