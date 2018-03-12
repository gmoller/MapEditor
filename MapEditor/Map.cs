using System.Drawing;

namespace MapEditor
{
    internal class Map
    {
        private readonly Cell[] _cells;

        internal int NumberOfLayers { get; }
        internal int NumberOfColumns { get; }
        internal int NumberOfRows { get; }
        internal Point CellSize => new Point(64, 64);

        internal Map(int numberOfLayers, int numberOfColumns, int numberOfRows)
        {
            NumberOfLayers = numberOfLayers;
            NumberOfColumns = numberOfColumns;
            NumberOfRows = numberOfRows;
            _cells = Initialize(numberOfLayers, numberOfColumns, numberOfRows);
        }

        internal Cell GetCell(int layer, int column, int row)
        {
            int cellId = DetermineCellId(layer, column, row);
            Cell cell = _cells[cellId];

            return cell;
        }

        internal void SetCell(int layer, int column, int row, byte paletteId, byte tileId)
        {
            int cellId = DetermineCellId(layer, column, row);
            _cells[cellId] = Cell.NewCell(paletteId, tileId);
        }

        private Cell[] Initialize(int numberOfLayers, int numberOfColumns, int numberOfRows)
        {
            Cell[] array = new Cell[numberOfLayers * numberOfColumns * numberOfRows];
            for (int layer = 0; layer < numberOfLayers; ++layer)
            {
                for (int row = 0; row < numberOfRows; ++row)
                {
                    for (int column = 0; column < numberOfColumns; ++column)
                    {
                        int cellId = DetermineCellId(layer, column, row);
                        array[cellId] = Cell.EmptyCell();
                        //array[cellId] = layer == 0 ? Cell.NewCell(1, 11) : Cell.NewCell(0, 0);
                    }
                }
            }

            return array;
        }

        private int DetermineCellId(int layer, int column, int row)
        {
            int cellId = (layer * NumberOfColumns * NumberOfRows) + (row * NumberOfColumns) + column;

            return cellId;
        }
    }
}