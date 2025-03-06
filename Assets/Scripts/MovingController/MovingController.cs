using System.Collections.Generic;
using System.Linq;
using MovingController.Interfaces;
using UnityEngine;

namespace MovingController
{
    public class MovingController : IMovingController
    {
        private readonly IEntitiesController _entitiesController;
        private Vector2Int[] _steps;
        private int i = 0;

        public MovingController(IEntitiesController entitiesController)
        {
            _entitiesController = entitiesController;
            _entitiesController.OnMovingEnd += EntitiesControllerOnMovingEnd;
        }

        private void EntitiesControllerOnMovingEnd()
        {
            OnMovingStepEnd();
        }

        public void MoveEntity(IEnumerable<Vector2Int> steps)
        {
            _steps = steps.ToArray();

            _entitiesController.MoveEntityTo(_steps[i], _steps[++i]);
        }

        private void OnMovingStepEnd()
        {
            if (_steps.Length == i + 1)
            {
                i = 0;
            }
            else
                _entitiesController.MoveEntityTo(_steps[i], _steps[++i]);
        }

    }
}