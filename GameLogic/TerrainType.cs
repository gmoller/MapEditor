using System.Diagnostics;

namespace GameLogic
{
    /// <summary>
    /// This struct is immutable.
    /// </summary>
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public struct TerrainType
    {
        public static readonly TerrainType Invalid = new TerrainType(-1, "Invalid", short.MaxValue);

        public int Id { get; }
        public string Name { get; }
        public int MovementCost { get; }

        private TerrainType(int id, string name, int movementCost)
        {
            Id = id;
            Name = name;
            MovementCost = movementCost;
        }

        public static TerrainType Create(int id, string name, int movementCost)
        {
            return new TerrainType(id, name, movementCost);
        }

        private string DebuggerDisplay => $"{{Id={Id},Name={Name}}}";
    }
}