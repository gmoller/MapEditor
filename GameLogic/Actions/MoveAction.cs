using GameLogic.NewLocationCalculators;
using GameLogic.Processors;
using GeneralUtilities;

namespace GameLogic.Actions
{
    public class MoveAction : IAct
    {
        public Unit Execute(Unit unit, object parameters, GameWorld gameWorld)
        {
            var compassDirection = (CompassDirection)parameters;
            INewLocationCalculator newLocationCalculator = NewLocationCalculatorFactory.GetNewLocationCalculator(compassDirection);
            ProcessResponse response = gameWorld.MovementProcessor.Process(new ProcessRequest(unit.Location, unit.MovementPoints), newLocationCalculator);

            Unit ret = Unit.Create(unit.UnitType, response.NewLocation, response.NewMovementPoints, gameWorld);

            return ret;
        }
    }
}