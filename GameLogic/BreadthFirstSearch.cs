using System.Collections.Generic;
using System.Linq;

namespace GameLogic
{
    internal static class BreadthFirstSearch
    {
        internal static Point[] FloodFill(Point start, GameWorld gameWorld)
        {
            var frontier = new Queue<Point>();
            frontier.Enqueue(start);
            var visited = new Dictionary<Point, bool> { [start] = true };

            while (frontier.Count > 0)
            {
                Point current = frontier.Dequeue();

                List<Point> neighbors = gameWorld.GetCellNeighbors(current);
                foreach (Point item in neighbors)
                {
                    if (!visited.ContainsKey(item))
                    {
                        frontier.Enqueue(item);
                        visited[item] = true;
                    }
                }
            }

            Point[] array = visited.Keys.ToArray();

            return array;
        }

        internal static Dictionary<Point, Point> CalculateCameFrom(Point start, GameWorld gameWorld)
        {
            var frontier = new Queue<Point>();
            frontier.Enqueue(start);
            var cameFrom = new Dictionary<Point, Point>();
            cameFrom[start] = Point.Null;

            while (frontier.Count > 0)
            {
                Point current = frontier.Dequeue();

                List<Point> neighbors = gameWorld.GetCellNeighbors(current);
                foreach (Point next in neighbors)
                {
                    if (!cameFrom.ContainsKey(next))
                    {
                        frontier.Enqueue(next);
                        cameFrom[next] = current;
                    }
                }
            }

            return cameFrom;
        }

        internal static Point[] GetPath(Point start, Point goal, Dictionary<Point, Point> cameFrom)
        {
            Point current = goal;
            var path = new List<Point>();
            while (current != start)
            {
                path.Add(current);
                Point? o = cameFrom[current];
                current = (Point)o;
            }

            //path.Add(start);
            path.Reverse();

            return path.ToArray();
        }
    }
}