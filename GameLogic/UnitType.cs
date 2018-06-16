using System.Diagnostics;

namespace GameLogic
{
    /// <summary>
    /// This struct is immutable.
    /// </summary>
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public struct UnitType
    {
        public static readonly UnitType Invalid = new UnitType(-1, "Invalid", 0);

        public int Id { get; }
        public string Name { get; }
        public int Moves { get; }

        private UnitType(int id, string name, int moves)
        {
            Id = id;
            Name = name;
            Moves = moves;
        }

        public static UnitType Create(int id, string name, int moves)
        {
            return new UnitType(id, name, moves);
        }

        private string DebuggerDisplay => $"{{Id={Id},Name={Name}}}";
    }
}