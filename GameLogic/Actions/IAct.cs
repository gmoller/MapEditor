using GeneralUtilities;

namespace GameLogic.Actions
{
    public interface IAct
    {
        Point2 Execute(Unit unit, GameWorld gameWorld);
    }
}