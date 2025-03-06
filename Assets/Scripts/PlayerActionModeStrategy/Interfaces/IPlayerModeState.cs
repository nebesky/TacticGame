using System;
using PlayerMode.Enums;
using UnityEngine;

namespace PlayerMode.Interfaces
{
    public interface IPlayerModeState
    {
        void Execute(Vector2Int goalCell);
    }
}