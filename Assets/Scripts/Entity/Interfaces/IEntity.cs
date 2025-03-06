using System;
using UnityEngine;

namespace GameSession
{
    public interface IEntity : IView
    {
        public string Name { get; }
        public TeamData TeamData { get; }
        public void Activate();
        public void Deactivate();
        public void MoveTo(Vector3 position);
        public void SetTeam(TeamData teamData);
        
        event Action OnMovingEnd;
    }
}