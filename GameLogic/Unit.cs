using GameLogic.NewLocationCalculators;
using GameLogic.Processors;

namespace GameLogic
{
    /// <summary>
    /// A unit is a game entity that can be controlled by the player/AI to do
    /// things such as move around and explore the map, attack and start a new
    /// city.
    /// </summary>
    public struct Unit
    {
        public Point Location { get; }
        public float MovementPoints { get; }

        private Unit(Point location, float movementPoints)
        {
            Location = location;
            MovementPoints = movementPoints;
        }

        public static Unit Create(Point newLocation, float movementPoints)
        {
            var unit = new Unit(newLocation, movementPoints);

            return unit;
        }

        public Unit Move(MovementProcessor movementProcessor, CompassDirection compassDirection)
        {
            INewLocationCalculator newLocationCalculator = NewLocationCalculatorFactory.GetNewLocationCalculator(compassDirection);
            ProcessResponse response = movementProcessor.Process(new ProcessRequest { Location = Location, MovementPoints = MovementPoints }, newLocationCalculator);

            Unit unit = Create(response.NewLocation, response.NewMovementPoints);

            return unit;
        }

        internal void FoundCity()
        {
            // change state
            //MovementPoints = 0;
        }

        internal void Reset()
        {
            // change state
            //MovementPoints = 2;
        }
    }
}