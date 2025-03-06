using System;
using System.Linq;
using Extensions;
using Field;
using MovingController.Interfaces;
using PlayerMode.Enums;
using PlayerMode.Interfaces;
using UnityEngine;

namespace PlayerMode.Strategies
{
    public class MovePlayerModeState : IPlayerModeState
    {
        private readonly IEntitiesController _entitiesController;
        private readonly IField _field;
        private readonly IMovingController _movingController;

        public MovePlayerModeState(
            IEntitiesController entitiesController, 
            IField field,
            IMovingController movingController)
        {
            _entitiesController = entitiesController;
            _field = field;
            _movingController = movingController;
        }

        public void Execute(Vector2Int goalCell)
        {
            CalculatePath(goalCell);
        }

        private void CalculatePath(Vector2Int goalCellCoordinate)
        {
            var occupiedCellCoordinates = _entitiesController.OccupiedCoordinates;
            var startCellCoordinate = _entitiesController.ActiveEntityCell;
            var freeCellCoordinates = _field.FreeCells
                .Where(c => !occupiedCellCoordinates.Contains(c))
                .ToList();
            var path = Hex.AStar(startCellCoordinate, goalCellCoordinate, freeCellCoordinates).ToList();

            if (path.Count > 1) _movingController.MoveEntity(path);
        }
    }
}