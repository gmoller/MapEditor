using System;
using System.Collections.Generic;
using GameData;
using GameLogic.Processors;
using GameMap;
using GeneralUtilities;

namespace GameLogic
{
    public class Player
    {
        private readonly GameWorld _gameWorld;
        private List<Unit> _units = new List<Unit>();
        private int _selectedUnitIndex = -1;

        private readonly MovementProcessor _movementProcessor;

        private readonly Random _random = new Random();

        public Player(GameWorld gameWorld)
        {
            _gameWorld = gameWorld;
            _movementProcessor = new MovementProcessor(gameWorld);
        }

        public IEnumerable<Unit> Units => _units;
        public Unit SelectedUnit
        {
            get
            {
                if (_selectedUnitIndex == -1)
                {
                    return Unit.Null;
                }

                return _units[_selectedUnitIndex];
            }
        }

        public void KeyPressed(Key key, Action centerOnSelectedUnitAction = null)
        {
            if (_selectedUnitIndex == -1)
            {
                if (key == Key.Enter)
                {
                    EndTurn();
                }
                return;
            }

            bool move = false;
            CompassDirection direction = CompassDirection.North;

            if (key == Key.NumPad1)
            {
                direction = CompassDirection.SouthWest;
                move = true;
            }

            if (key == Key.NumPad2)
            {
                direction = CompassDirection.South;
                move = true;
            }

            if (key == Key.NumPad3)
            {
                direction = CompassDirection.SouthEast;
                move = true;
            }

            if (key == Key.NumPad4)
            {
                direction = CompassDirection.West;
                move = true;
            }

            if (key == Key.NumPad6)
            {
                direction = CompassDirection.East;
                move = true;
            }

            if (key == Key.NumPad7)
            {
                direction = CompassDirection.NorthWest;
                move = true;
            }

            if (key == Key.NumPad8)
            {
                direction = CompassDirection.North;
                move = true;
            }

            if (key == Key.NumPad9)
            {
                direction = CompassDirection.NorthEast;
                move = true;
            }

            if (move)
            {
                Unit unit = _units[_selectedUnitIndex].Move(_movementProcessor, direction);
                _units[_selectedUnitIndex] = unit;

                centerOnSelectedUnitAction?.Invoke();

                if (unit.MovementPoints <= 0)
                {
                    _selectedUnitIndex++;
                    if (_selectedUnitIndex > _units.Count - 1)
                    {
                        _selectedUnitIndex = -1;
                    }
                }
            }
        }

        public void AddUnit(int unitType, Point2 startLocation, GameWorld gameWorld)
        {
            Unit unit = Unit.CreateNew(unitType, startLocation, gameWorld);
            _units.Add(unit);
            _selectedUnitIndex = _units.Count - 1;
        }

        public void EndTurn()
        {
            List<Unit> units = new List<Unit>(_units.Count);

            foreach (Unit item in _units)
            {
                Unit unit = item.StartNewTurn();
                units.Add(unit);
                CellVisibilitySetter.SetCellVisibility(unit.Location, _gameWorld);
            }

            _units = units;

            if (_gameWorld.AreAllCellsVisible())
            {
                //_gameWorld.SetAllCellsInvisible();
            }

            _selectedUnitIndex = 0;
        }

        public string DoTurn()
        {
            string result = string.Empty;

            List<Unit> units = new List<Unit>(_units.Count);

            foreach (Unit item in _units)
            {
                // decide what to do
                int num = _random.Next(0, 9);
                //if (num > 7) continue; // do nothing

                // do it
                //if (num == 0 || num == 2 || num == 4 || num == 6)
                {
                    //Unit unit = item.Move(_movementProcessor, (CompassDirection) num);
                    //item.Actions["Move"].Execute(item, gameWorld);
                    //or perhaps: item.DoAction("Move");

                    Unit unit = Explore(item);
                    units.Add(unit);
                }
            }

            _units = units;

            return result;
        }

        private Unit Explore(Unit item)
        {
            Point2 newLocation = item.Explore();

            Cell cell = _gameWorld.GetCell(newLocation);
            TerrainType terrainType = Globals.Instance.TerrainTypes[cell.TerrainTypeId];
            int movementCost = terrainType.MovementCost;

            if (item.MovementPoints - movementCost >= 0)
            {
                Unit unit = Unit.Create(item.UnitType, newLocation, item.MovementPoints - movementCost, _gameWorld);
                return unit;
                //result = $"{item.ToString()} -> {unit.ToString()}";
            }
            else // can't move, not enough points
            {
                // TODO: fix bug where if not enough movement points, unit keeps to trying to move to same spot and gets stuck!
                return item;
                //result = "Nothing";
            }
        }

        public bool UnitInCell(int colIndex, int rowIndex)
        {
            foreach (Unit item in _units)
            {
                if (item.Location.X == colIndex && item.Location.Y == rowIndex)
                {
                    return true;
                }
            }

            return false;
        }
    }
}