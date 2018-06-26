using System;
using System.Collections.Generic;
using GameLogic.Processors;

namespace GameLogic
{
    public class Player
    {
        private List<Unit> _units = new List<Unit>();
        private readonly MovementProcessor _movementProcessor;

        private readonly Random _random = new Random();

        public Player(GameWorld gameWorld)
        {
            _movementProcessor = new MovementProcessor(gameWorld);
        }

        public IEnumerable<Unit> Units => _units;

        public void AddUnit(int unitType, Point startLocation, GameWorld gameWorld)
        {
            Unit unit = Unit.CreateNew(unitType, startLocation, gameWorld);
            _units.Add(unit);
        }

        public void EndTurn()
        {
            List<Unit> units = new List<Unit>(_units.Count);

            foreach (Unit item in _units)
            {
                Unit unit = item.StartNewTurn();
                units.Add(unit);
            }

            _units = units;
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
                    Unit unit = item.Explore();
                    units.Add(unit);
                    result = $"{item.ToString()} -> {unit.ToString()}";
                }
                //else
                //{
                //    units.Add(item);
                //    result = "Nothing";
                //}
            }

            _units = units;

            return result;
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