using System.Diagnostics;

namespace GameLogic
{
    /// <summary>
    /// This class is immutable.
    /// </summary>
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public class GameBoard
    {
        private readonly int _numberOfRows;
        private readonly int _numberOfColumns;
        private readonly Cell[] _cells;

        private GameBoard(int numberOfColumns, int numberOfRows, int[] terrainTypes)
        {
            _numberOfRows = numberOfRows;
            _numberOfColumns = numberOfColumns;

            _cells = new Cell[numberOfRows * numberOfColumns];
            for (int i = 0; i < _numberOfRows * _numberOfColumns; ++i)
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
                location.X > _numberOfColumns - 1 ||
                location.Y > _numberOfRows - 1)
            {
                return Cell.Null;
            }

            int index = location.Y * _numberOfColumns + location.X;
            //Console.WriteLine($"Index: {index}, X: {location.X}, Y: {location.Y}");

            return _cells[index];
        }

        private string DebuggerDisplay => $"{{Rows={_numberOfRows},Columns={_numberOfColumns}}}";
    }
}