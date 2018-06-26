using System.Diagnostics;

namespace GameLogic
{
    /// <summary>
    /// This struct is immutable.
    /// </summary>
    [DebuggerDisplay("{" + nameof(DebuggerDisplay) + ",nq}")]
    public struct Point
    {
        public static readonly Point Empty = new Point();
        public static readonly Point Null = new Point(int.MinValue, int.MinValue);

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

        public static bool operator == (Point left, Point right)
        {
            return left.X == right.X && left.Y == right.Y;
        }

        public static bool operator != (Point left, Point right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Point)) return false;
            Point comp = (Point)obj;
            return comp.X == X && comp.Y == Y;
        }

        public override int GetHashCode()
        {
            return X ^ Y;
        }

        public override string ToString()
        {
            return DebuggerDisplay;
        }

        private string DebuggerDisplay => $"{{X={X},Y={Y}}}";
    }
}