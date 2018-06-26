namespace GameLogic
{
    internal static class CellVisibilitySetter
    {
        internal static void SetCellVisibility(Point location, GameWorld gameWorld)
        {
            gameWorld.SetCellVisible(Point.Create(location.X - 1, location.Y + 1)); // northwest
            gameWorld.SetCellVisible(Point.Create(location.X, location.Y + 1)); // north
            gameWorld.SetCellVisible(Point.Create(location.X + 1, location.Y + 1)); // northeast
            gameWorld.SetCellVisible(Point.Create(location.X - 1, location.Y)); // west
            gameWorld.SetCellVisible(location);
            gameWorld.SetCellVisible(Point.Create(location.X + 1, location.Y)); // east
            gameWorld.SetCellVisible(Point.Create(location.X - 1, location.Y - 1)); // southwest
            gameWorld.SetCellVisible(Point.Create(location.X, location.Y - 1)); // south
            gameWorld.SetCellVisible(Point.Create(location.X + 1, location.Y - 1)); // southeast
        }
    }
}