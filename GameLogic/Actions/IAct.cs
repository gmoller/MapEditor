namespace GameLogic.Actions
{
    public interface IAct
    {
        Point Execute(Unit unit, GameWorld gameWorld);
    }
}