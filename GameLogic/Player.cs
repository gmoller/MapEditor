using System;
using System.Collections.Generic;
using GeneralUtilities;

namespace GameLogic
{
    public class Player
    {
        private List<Unit> _units = new List<Unit>();
        private int _selectedUnitIndex = -1;

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

        public event EventHandler TurnEnded;

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
                Move(direction, centerOnSelectedUnitAction);
            }
        }

        private void Move(CompassDirection direction, Action centerOnSelectedUnitAction)
        {
            Unit unit = _units[_selectedUnitIndex].DoAction("Move", direction);

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

        public void AddUnit(int unitType, Point2 startLocation)
        {
            Unit unit = Unit.CreateNew(unitType, startLocation);
            _units.Add(unit);
            _selectedUnitIndex = _units.Count - 1;
        }

        private void EndTurn()
        {
            List<Unit> units = new List<Unit>(_units.Count);

            foreach (Unit item in _units)
            {
                Unit unit = item.StartNewTurn();
                units.Add(unit);
                CellVisibilitySetter.SetCellVisibility(unit.Location, Globals.Instance.GameWorld);
            }

            _units = units;
            _selectedUnitIndex = 0;

            // raise event here to inform listeners that turn has been ended
            OnTurnEnded(EventArgs.Empty);
        }

        private void OnTurnEnded(EventArgs e)
        {
            //Interlocked.CompareExchange(ref TurnEnded, null, null)?.Invoke(this, e);
            TurnEnded?.Invoke(this, e);
        }

        //private Unit Explore(Unit item)
        //{
        //    Point2 newLocation = item.Explore();

        //    Cell cell = _gameWorld.GetCell(newLocation);
        //    TerrainType terrainType = Globals.Instance.TerrainTypes[cell.TerrainTypeId];
        //    int movementCost = terrainType.MovementCost;

        //    if (item.MovementPoints - movementCost >= 0)
        //    {
        //        Unit unit = Unit.Create(item.UnitType, newLocation, item.MovementPoints - movementCost, _gameWorld);
        //        return unit;
        //        //result = $"{item.ToString()} -> {unit.ToString()}";
        //    }
        //    else // can't move, not enough points
        //    {
        //        // TODO: fix bug where if not enough movement points, unit keeps to trying to move to same spot and gets stuck!
        //        return item;
        //        //result = "Nothing";
        //    }

        //    return item;
        //}
    }
}