using BattleStart.Interfaces;
using Field;
using Level;
using PlayerMode.Enums;
using PlayerMode.Interfaces;

namespace BattleStart
{
    public class BattleController : IBattleController
    {
        private readonly ILevelDataProvider _levelDataProvider;
        private readonly IEntitiesController _entitiesController;
        private readonly IPlayerMode _playerMode;
        private readonly IField _field;

        public BattleController(
            ILevelDataProvider levelDataProvider,
            IEntitiesController entitiesController,
            IPlayerMode playerMode,
            IField field)
        {
            _levelDataProvider = levelDataProvider;
            _entitiesController = entitiesController;
            _playerMode = playerMode;
            _field = field;

            Start();
        }

        public void Start()
        {
            var level = _levelDataProvider.Get("default_level");

            //формируем поле
            _field.SetFieldCells(level.Cells);

            //заполняем героями и монстрами
            
            //_entitiesController.InitHeroes(level);
            _playerMode.SetMode(PlayerModeType.Moving);
        }
    }
}