using GameLogic.NewLocationCalculators;
using GameLogic.Processors;

namespace GameLogic.Actions
{
    public class MoveAction : IAct
    {
        public Point Execute(Unit unit, GameWorld gameWorld)
        {
            //INewLocationCalculator newLocationCalculator = NewLocationCalculatorFactory.GetNewLocationCalculator(compassDirection);
            //ProcessResponse response = movementProcessor.Process(new ProcessRequest(unit.Location, unit.MovementPoints), newLocationCalculator);

            //Unit ret = Unit.Create(unit.UnitType, response.NewLocation, response.NewMovementPoints, gameWorld);

            return unit.Location;
        }
    }
}