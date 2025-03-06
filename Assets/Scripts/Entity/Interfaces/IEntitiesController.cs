using System;
using System.Collections.Generic;
using DefaultNamespace.Hero.Enums;
using GameSession;
using Level;
using UnityEngine;

public interface IEntitiesController
{
    void NextHeroesStep();
    void PlaceHero(Vector2Int position, IEntity entity);
    IList<Vector2Int> OccupiedCoordinates { get; }
    void MoveEntityTo(Vector2Int targetEntityCoordinate, Vector2Int destinationCoordinate);
    Vector2Int ActiveEntityCell { get; }
    TeamData ActiveEntityTeamData { get; }
    event Action OnMovingEnd;
}
