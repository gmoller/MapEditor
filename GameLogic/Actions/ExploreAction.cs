using System.Collections.Generic;

namespace GameLogic.Actions
{
    public class ExploreAction : IAct
    {
        public Point Execute(Unit unit, GameWorld gameWorld)
        {
            // find closest non-visible cell
            Dictionary<Point, Point> cameFrom = BreadthFirstSearch.CalculateCameFrom(unit.Location, gameWorld);
            Point closest = FindClosestNonVisibleCell(cameFrom, gameWorld);

            if (closest != Point.Null)
            {
                Point[] path = BreadthFirstSearch.GetPath(unit.Location, closest, cameFrom);

                // move towards there
                if (path.Length > 0)
                {
                    return path[0];
                }
            }

            return unit.Location;
        }

        private Point FindClosestNonVisibleCell(Dictionary<Point, Point> cameFrom, GameWorld gameWorld)
        {
            foreach (Point item in cameFrom.Keys)
            {
                if (!gameWorld.IsCellVisible(item))
                {
                    // the location to move towards
                    return item;
                }
            }

            return Point.Null;
        }
    }
}