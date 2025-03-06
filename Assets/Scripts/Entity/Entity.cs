using System;
using DefaultNamespace.Hero.Enums;
using GameSession;
using TMPro.EditorUtilities;
using UnityEngine;

namespace DefaultNamespace.Entity
{
    public class Entity : IEntity
    {
        private readonly EntityModel _entityModel;
        private readonly IEntityView _entityView;
        private TeamData _teamData;

        public event Action OnMovingEnd;

        public string Name => _entityModel.Name;
        public TeamData TeamData => _teamData;

        public Entity(EntityModel entityModel, IEntityView entityView)
        {
            _entityModel = entityModel;
            _entityView = entityView;
            _entityView.OnMovingEnd += OnMovingEndView;
        }

        private void OnMovingEndView()
        {
            OnMovingEnd?.Invoke(); 
        }

        public void SetTeam(TeamData teamData)
        {
            _teamData = teamData;
            _entityView.SetTeamColor(teamData.Color);
        }

        public void SetDirection(Quaternion quaternion)
        {
            _entityView.SetRotation(quaternion);
        }

        public void SetPositionImmediately(Vector3 position)
        {
            _entityView.SetLocalPosition(position);
        }

        public void Activate()
        {
            _entityView.ShowTargetAura();
        }

        public void Deactivate()
        {
            _entityView.HideTargetAura();
        }

        public void MoveTo(Vector3 position)
        {
            _entityView.Run(position);
        }
    }
}