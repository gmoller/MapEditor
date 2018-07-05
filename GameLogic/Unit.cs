using System.Collections.Generic;
using System.Diagnostics;
using GameLogic.Actions;
using GeneralUtilities;

namespace GameLogic
{
    /// <summary>
    /// A unit is a game entity that can be controlled by the player/AI to do
    /// things such as move around and explore the map, attack and start a new
    /// city.
    /// This class is immutable.
    /// </summary>
    [DebuggerDisplay("{" + nameof(DebuggerDisplay) + ",nq}")]
    public struct Unit
    {
        private readonly GameWorld _gameWorld;

        private readonly Dictionary<string, IAct> _actions;

        public int UnitType { get; }
        public Point2 Location { get; }
        public float MovementPoints { get; }

        public string UnitTypeName
        {
            get
            {
                if (UnitType == -1) return "Null";
                return Globals.Instance.UnitTypes[UnitType].Name;
            }
        }

        public static readonly Unit Null = new Unit(-1, Point2.Null, 0.0f, null);

        private Unit(int unitType, Point2 location, float movementPoints, GameWorld gameWorld)
        {
            _gameWorld = gameWorld;
            UnitType = unitType;
            Location = location;
            MovementPoints = movementPoints;

            _actions = new Dictionary<string, IAct> {{"Move", new MoveAction()}, {"Explore", new ExploreAction()}};
        }

        public static Unit CreateNew(int unitType, Point2 location, GameWorld gameWorld)
        {
            float movementPoints = Globals.Instance.UnitTypes[unitType].Moves;
            var unit = new Unit(unitType, location, movementPoints, gameWorld);
            CellVisibilitySetter.SetCellVisibility(unit.Location, gameWorld);

            return unit;
        }

        public static Unit Create(int unitType, Point2 newLocation, float movementPoints, GameWorld gameWorld)
        {
            var unit = new Unit(unitType, newLocation, movementPoints, gameWorld);

            return unit;
        }

        public Unit DoAction(string action, object parameters)
        {
            Unit unit = _actions[action].Execute(this, parameters, _gameWorld);

            return unit;
        }

        public void FoundCity()
        {
            // if movemenet points >= 1 and this unit is a settler, create city
            // kill this unit -> MarkForDeath
        }

        public Unit StartNewTurn()
        {
            float movementPoints = Globals.Instance.UnitTypes[UnitType].Moves;
            Unit unit = Create(UnitType, Location, movementPoints, _gameWorld);

            return unit;
        }

        public override string ToString()
        {
            return DebuggerDisplay;
        }

        private string DebuggerDisplay
        {
            get
            {
                if (UnitType == -1)
                {
                    return "NullUnit";
                }

                return $"{{UnitType={Globals.Instance.UnitTypes[UnitType].Name},Location={Location},MovementPoints={MovementPoints}/{Globals.Instance.UnitTypes[UnitType].Moves}}}";
            }
        }
    }
}