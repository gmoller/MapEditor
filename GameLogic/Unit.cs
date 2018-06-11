using GameLogic.NewLocationCalculators;

namespace GameLogic
{
    /// <summary>
    /// A unit is a game entity that can be controlled by the player/AI to do
    /// things such as move around and explore the map, attack and start a new
    /// city.
    /// </summary>
    public struct Unit
    {
        private const float Half = 0.5f;

        private readonly GameWorld _gameWorld;
        public Point Location { get; }
        public float MovementPoints { get; }

        private Unit(GameWorld gameWorld, Point location, float movementPoints)
        {
            _gameWorld = gameWorld;
            Location = location;
            MovementPoints = movementPoints;
        }

        public static Unit Create(GameWorld gameWorld, Point newLocation, float movementPoints)
        {
            var unit = new Unit(gameWorld, newLocation, movementPoints);

            return unit;
        }

        public Unit Move(CompassDirection direction)
        {
            // get new location
            // IDEA: make factory injectable?
            INewLocationCalculator newLocationCalculator =
                NewLocationCalculatorFactory.GetNewLocationCalculator(direction);
            Point newLocation = newLocationCalculator.Calculate(Location);

            int movementCostCurrent = GetMovementCostForTerrain(Location);
            int movementCostNew = GetMovementCostForTerrain(newLocation);
            float movementCost = (movementCostCurrent + movementCostNew) * Half;

            if (UnitHasEnoughMovementPoints(movementCost))
            {
                Unit unit = Create(_gameWorld, newLocation, MovementPoints - movementCost);

                return unit;
            }

            return this;
        }

        private int GetMovementCostForTerrain(Point location)
        {
            // get terrain type for location
            Cell cell = _gameWorld.Board.GetCell(location);

            // get movement cost for that terrain type
            TerrainType terrainType = _gameWorld.TerrainTypes[cell.TerrainTypeId];
            int movementCost = terrainType.MovementCost;

            return movementCost;
        }

        private bool UnitHasEnoughMovementPoints(float movementCost)
        {
            return MovementPoints - movementCost >= 0.0f;
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