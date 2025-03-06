using System;
using PlayerMode.Enums;
using PlayerMode.Interfaces;
using UnityEngine;
using Zenject;

namespace PlayerMode.Selector
{
    public class PlayerMode : IPlayerMode
    {
        [Inject]
        private DiContainer _container;
        private IPlayerModeState _currentPlayerModeState;

        public event Action<PlayerModeType> OnPlayerModeChange;

        public void SetMode(PlayerModeType playerModeType)
        {
            _currentPlayerModeState = _container.ResolveId<IPlayerModeState>(playerModeType);
            
            OnPlayerModeChange?.Invoke(playerModeType);
        }

        public void Execute(Vector2Int goalCell)
        {
            _currentPlayerModeState.Execute(goalCell);
        }
    }
}