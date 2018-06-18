using System.Diagnostics;
using GameLogic.NewLocationCalculators;
using GameLogic.Processors;

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

        public int UnitType { get; }
        public Point Location { get; }
        public float MovementPoints { get; }

        private Unit(int unitType, Point location, float movementPoints, GameWorld gameWorld)
        {
            _gameWorld = gameWorld;
            UnitType = unitType;
            Location = location;
            MovementPoints = movementPoints;
        }

        public static Unit CreateNew(int unitType, Point location, GameWorld gameWorld)
        {
            float movementPoints = gameWorld.UnitTypes[unitType].Moves;
            var unit = new Unit(unitType, location, movementPoints, gameWorld);

            return unit;
        }

        public static Unit Create(int unitType, Point newLocation, float movementPoints, GameWorld gameWorld)
        {
            var unit = new Unit(unitType, newLocation, movementPoints, gameWorld);

            return unit;
        }

        public Unit Move(MovementProcessor movementProcessor, CompassDirection compassDirection)
        {
            INewLocationCalculator newLocationCalculator = NewLocationCalculatorFactory.GetNewLocationCalculator(compassDirection);
            ProcessResponse response = movementProcessor.Process(new ProcessRequest(Location, MovementPoints), newLocationCalculator);

            Unit unit = Create(UnitType, response.NewLocation, response.NewMovementPoints, _gameWorld);

            return unit;
        }

        public void FoundCity()
        {
            // if movemenet points >= 1 and this unit is a settler, create city
            // kill this unit -> MarkForDeath
        }

        public Unit StartNewTurn()
        {
            float movementPoints = _gameWorld.UnitTypes[UnitType].Moves;
            Unit unit = Create(UnitType, Location, movementPoints, _gameWorld);

            return unit;
        }

        public override string ToString()
        {
            return DebuggerDisplay;
        }

        private string DebuggerDisplay => $"{{UnitType={_gameWorld.UnitTypes[UnitType].Name},Location={Location},MovementPoints={MovementPoints}/{_gameWorld.UnitTypes[UnitType].Moves}}}";
    }
}