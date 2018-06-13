using System.Threading.Tasks;
using GameLogic.NewLocationCalculators;

namespace GameLogic.Processors
{
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
            float movementCost = DetermineMovementCost(request.Location, newLocation);
            bool hasEnoughMovementPoints = HasEnoughMovementPoints(request.MovementPoints, movementCost);

            if (hasEnoughMovementPoints)
            {
                float newMovementPoints = request.MovementPoints - movementCost;

                return new ProcessResponse { NewLocation = newLocation, NewMovementPoints = newMovementPoints };
            }

            return new ProcessResponse { NewLocation = request.Location, NewMovementPoints = request.MovementPoints };
        }

        private Point DetermineNewPosition(Point currentLocation, INewLocationCalculator newLocationCalculator)
        {
            return newLocationCalculator.Calculate(currentLocation);
        }

        private float DetermineMovementCost(Point currentLocation, Point newLocation)
        {
            int movementCostCurrent = GetMovementCostForTerrain(currentLocation);
            int movementCostNew = GetMovementCostForTerrain(newLocation);
            float movementCost = (movementCostCurrent + movementCostNew) * 0.5f;

            return movementCost;
        }

        private bool HasEnoughMovementPoints(float movementPoints, float movementCost)
        {
            return movementPoints - movementCost >= 0.0f;
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
    }

    public struct ProcessRequest
    {
        public Point Location { get; set; }
        public float MovementPoints { get; set; }
    }

    public struct ProcessResponse
    {
        public Point NewLocation { get; set; }
        public float NewMovementPoints { get; set; }
    }
}