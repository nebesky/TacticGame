using System;
using UnityEngine;

namespace GameSession
{
    public interface IEntityView
    {
        void Run(Vector3 position);
        void SetRotation(Quaternion rotation);
        void SetLocalPosition(Vector3 position);
        void SetTeamColor(Color color);
        void ShowTargetAura();
        void HideTargetAura();
        event Action OnMovingEnd;
    }
}