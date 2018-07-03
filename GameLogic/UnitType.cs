using System.Diagnostics;

namespace GameLogic
{
    /// <summary>
    /// This struct is immutable.
    /// </summary>
    [DebuggerDisplay("{" + nameof(DebuggerDisplay) + ",nq}")]
    public struct UnitType
    {
        public static readonly UnitType Invalid = new UnitType(-1, "Invalid", 0, MovementType.None);

        public int Id { get; }
        public string Name { get; }
        public int Moves { get; }
        public MovementType MovementType { get; }

        private UnitType(int id, string name, int moves, MovementType movementType)
        {
            Id = id;
            Name = name;
            Moves = moves;
            MovementType = movementType;
        }

        public static UnitType Create(int id, string name, int moves, MovementType movementType)
        {
            return new UnitType(id, name, moves, movementType);
        }

        private string DebuggerDisplay => $"{{Id={Id},Name={Name}}}";
    }
}