using System;
using PlayerMode.Enums;
using UnityEngine;

namespace PlayerMode.Interfaces
{
    public interface IPlayerMode
    {
        void SetMode(PlayerModeType playerModeType);
        void Execute(Vector2Int goalCell);
        
        event Action<PlayerModeType> OnPlayerModeChange;
    }
}