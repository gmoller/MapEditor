using System.Diagnostics;

namespace GameLogic
{
    /// <summary>
    /// This class is immutable.
    /// </summary>
    [DebuggerDisplay("{" + nameof(DebuggerDisplay) + ",nq}")]
    public class GameBoard
    {
        private readonly Cell[] _cells;

        public int NumberOfRows { get; }
        public int NumberOfColumns { get; }

        private GameBoard(int numberOfColumns, int numberOfRows, int[] terrainTypes)
        {
            NumberOfRows = numberOfRows;
            NumberOfColumns = numberOfColumns;

            _cells = new Cell[numberOfRows * numberOfColumns];
            for (int i = 0; i < NumberOfRows * NumberOfColumns; ++i)
            {
                _cells[i] = Cell.Create(terrainTypes[i]);
            }
        }

        public static GameBoard Create(int numberOfColumns, int numberOfRows, int[] terrainTypes)
        {
            return new GameBoard(numberOfColumns, numberOfRows, terrainTypes);
        }

        public Cell GetCell(Point location)
        {
            if (location.X < 0 ||
                location.Y < 0 ||
                location.X > NumberOfColumns - 1 ||
                location.Y > NumberOfRows - 1)
            {
                return Cell.Null;
            }

            int index = location.Y * NumberOfColumns + location.X;
            //Console.WriteLine($"Index: {index}, X: {location.X}, Y: {location.Y}");

            return _cells[index];
        }

        private string DebuggerDisplay => $"{{Rows={NumberOfRows},Columns={NumberOfColumns}}}";
    }
}