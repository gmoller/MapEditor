using System.Threading.Tasks;
using GameLogic.NewLocationCalculators;

namespace GameLogic.Processors
{
    /// <summary>
    /// This class is immutable.
    /// </summary>
    public class MovementProcessor
    {
        private readonly GameWorld _gameWorld;

        public MovementProcessor(GameWorld gameWorld)
        {
            _gameWorld = gameWorld;
        }

        public ProcessResponse[] Process(ProcessRequest[] requests, INewLocationCalculator newLocationCalculator)
        {
            ProcessResponse[] response = new ProcessResponse[requests.Length];

            //int cnt = 0;
            //foreach (ProcessRequest request in requests)
            Parallel.ForEach(requests, (request, state, cnt) =>
            {
                var resp = Process(request, newLocationCalculator);
                response[cnt] = resp;
            }
            );

            return response;
        }

        public ProcessResponse Process(ProcessRequest request, INewLocationCalculator newLocationCalculator)
        {
            Point newLocation = DetermineNewPosition(request.Location, newLocationCalculator);
            int movementCost = DetermineMovementCost(newLocation);
            bool canMoveIntoCell = CanMoveIntoCell(request.MovementPoints, movementCost);

            if (canMoveIntoCell)
            {
                float newMovementPoints = request.MovementPoints - movementCost;

                return new ProcessResponse(newLocation, newMovementPoints);
            }

            return new ProcessResponse(request.Location, request.MovementPoints);
        }

        private Point DetermineNewPosition(Point currentLocation, INewLocationCalculator newLocationCalculator)
        {
            return newLocationCalculator.Calculate(currentLocation);
        }

        private int DetermineMovementCost(Point newLocation)
        {
            int movementCost = GetMovementCostForTerrain(newLocation);

            return movementCost;
        }

        private bool CanMoveIntoCell(float movementPoints, int movementCost)
        {
            return movementPoints >= 0.5f && movementCost >= 0;
        }

        private int GetMovementCostForTerrain(Point location)
        {
            // get terrain type for location
            Cell cell = _gameWorld.GetCell(location);

            // get movement cost for that terrain type
            TerrainType terrainType = _gameWorld.TerrainTypes[cell.TerrainTypeId];
            int movementCost = terrainType.MovementCost;

            return movementCost;
        }
    }

    /// <summary>
    /// This struct is immutable.
    /// </summary>
    public struct ProcessRequest
    {
        public Point Location { get; }
        public float MovementPoints { get; }

        public ProcessRequest(Point location, float movementPoints)
        {
            Location = location;
            MovementPoints = movementPoints;
        }
    }

    /// <summary>
    /// This struct is immutable.
    /// </summary>
    public struct ProcessResponse
    {
        public Point NewLocation { get; }
        public float NewMovementPoints { get; }

        public ProcessResponse(Point newLocation, float newMovementPoints)
        {
            NewLocation = newLocation;
            NewMovementPoints = newMovementPoints;
        }
    }
}