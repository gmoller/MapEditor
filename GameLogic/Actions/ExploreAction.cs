using System.Collections.Generic;
using GeneralUtilities;

namespace GameLogic.Actions
{
    public class ExploreAction : IAct
    {
        public Point2 Execute(Unit unit, GameWorld gameWorld)
        {
            // find closest non-visible cell
            Dictionary<Point2, Point2> cameFrom = BreadthFirstSearch.CalculateCameFrom(unit.Location, gameWorld);
            Point2 closest = FindClosestNonVisibleCell(cameFrom, gameWorld);

            if (closest != Point2.Null)
            {
                Point2[] path = BreadthFirstSearch.GetPath(unit.Location, closest, cameFrom);

                // move towards there
                if (path.Length > 0)
                {
                    return path[0];
                }
            }

            return unit.Location;
        }

        private Point2 FindClosestNonVisibleCell(Dictionary<Point2, Point2> cameFrom, GameWorld gameWorld)
        {
            foreach (Point2 item in cameFrom.Keys)
            {
                if (!gameWorld.IsCellVisible(item))
                {
                    // the location to move towards
                    return item;
                }
            }

            return Point2.Null;
        }
    }
}