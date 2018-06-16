using System.Diagnostics;

namespace GameLogic
{
    /// <summary>
    /// This struct is immutable.
    /// </summary>
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public struct Point
    {
        public static readonly Point Empty = new Point();

        public int X { get; }
        public int Y { get; }

        private Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static Point Create(int x, int y)
        {
            return new Point(x, y);
        }

        public override string ToString()
        {
            return $"{{X={X},Y={Y}}}";
        }

        private string DebuggerDisplay => $"{{X={X},Y={Y}}}";
    }
}