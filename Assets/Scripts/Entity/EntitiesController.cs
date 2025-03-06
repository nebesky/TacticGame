using System;
using System.Collections.Generic;
using System.Linq;
using DefaultNamespace.Hero.Enums;
using Field;
using GameSession;
using Level;
using UI.Interfaces;
using UnityEngine;

public class EntitiesController : IEntitiesController, IDisposable
{
    private readonly IField _field;
    private readonly IEntityFactory _entityFactory;
    private readonly IFieldPositionProvider _fieldPositionProvider;
    private readonly IMainBarView _mainBarView;
    private int _step = 1;
    private IEntity _activeEntity;

    private Dictionary<Vector2Int, IEntity> _entities = new ();
    
    public event Action OnMovingEnd;

    public TeamData ActiveEntityTeamData => _activeEntity.TeamData;

    public IList<Vector2Int> OccupiedCoordinates => _entities.Keys.ToList();
    
    public EntitiesController(
        IField field,
        IEntityFactory entityFactory,
        IMainBarView mainBarView)
    {
        _field = field;
        _entityFactory = entityFactory;
        _mainBarView = mainBarView;
        
        _field.OnFieldClick += OnFieldClick;
    }

    public void MoveEntityTo(Vector2Int targetEntityCoordinate, Vector2Int destinationCoordinate)
    {
        if (_entities.TryGetValue(targetEntityCoordinate, out var entity))
        {
            entity.MoveTo(_field.GetCellPosition(destinationCoordinate));
            
            _entities.Remove(targetEntityCoordinate);
            _entities[destinationCoordinate] = entity;
        }
    }

    public Vector2Int ActiveEntityCell => _entities.First(e => e.Value  == _activeEntity).Key;

    private void OnFieldClick(Vector2Int obj)
    {
        
    }

    public void NextHeroesStep()
    {
        throw new NotImplementedException();
    }

    public void PlaceHero(Vector2Int position, IEntity entity)
    {
        throw new NotImplementedException();
    }
    
    /*public void InitHeroes(LevelData levelData)
    {
        foreach (var levelCellTypePosition in levelData.Cells
                     .Where(pair => pair.Value is EditorCellType.Team1 or EditorCellType.Team2))
        {
            var heroModel = new EntityModel();
            var hero = _entityFactory.Create(heroModel);

            //to fix, looks weird
            var teamTypeConverted = TeamSideType.Team1;
            if (levelCellTypePosition.Value == EditorCellType.Team2) 
                teamTypeConverted = TeamSideType.Team2; 

            //var teamInfo = levelData.Teams.FirstOrDefault(teamInfo => teamInfo.SideType == teamTypeConverted);
            var lookRotation = GetDirectionByType(teamTypeConverted);

            hero.SetPositionImmediately(_field.GetCellPosition(levelCellTypePosition.Key));

            //hero.SetTeam(teamInfo);
            hero.SetDirection(lookRotation);

            _entities.Add(levelCellTypePosition.Key, hero);

            hero.OnMovingEnd += HeroOnMovingEnd;
        }

        _activeEntity = _entities.First().Value;
        _mainBarView.SetPlayerHero(_activeEntity);

        SortEntitiesByDexterity();
    }*/

    private void HeroOnMovingEnd()
    {
        OnMovingEnd?.Invoke();
    }

    public void SortEntitiesByDexterity()
    {
        _step = 0;
        _entities.First().Value.Activate();
        // _entities.ToList()
    }

    //for extend
    private Quaternion GetDirectionByType(TeamSideType teamSideType) => teamSideType == TeamSideType.Team1
        ? Quaternion.LookRotation(Vector3.forward)
        : Quaternion.LookRotation(Vector3.back);

    public void Dispose()
    {
        _field.OnFieldClick -= OnFieldClick;
    }
}