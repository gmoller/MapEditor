using System.Collections.Generic;
using System.Drawing;

namespace MapEditor
{
    internal class Map
    {
        private Cell[] _cells;
        internal List<Layer> Layer { get; }

        internal int NumberOfLayers => Layer.Count;
        internal int NumberOfColumns { get; }
        internal int NumberOfRows { get; }
        internal Point CellSize { get; private set; }

        internal Map(int numberOfLayers, int numberOfColumns, int numberOfRows, int cellSizeX, int cellSizeY)
        {
            NumberOfColumns = numberOfColumns;
            NumberOfRows = numberOfRows;
            _cells = Initialize(numberOfLayers, numberOfColumns, numberOfRows);
            Layer = SetLayers(numberOfLayers);
            CellSize = new Point(cellSizeX, cellSizeY);
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

        internal void IncreaseGridSize()
        {
            CellSize = new Point(CellSize.X + 8, CellSize.Y + 8);
        }

        internal void DecreaseGridSize()
        {
            CellSize = new Point(CellSize.X - 8, CellSize.Y - 8);
        }

        internal Cell[] GetState()
        {
            return _cells;
        }

        internal void SetState(Cell[] mapState)
        {
            _cells = mapState;
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
                    }
                }
            }

            return array;
        }

        private List<Layer> SetLayers(int numberOfLayers)
        {
            var layers = new List<Layer>();
            for (int i = 0; i < numberOfLayers; ++i)
            {
                layers.Add(new Layer());
            }

            return layers;
        }

        private int DetermineCellId(int layer, int column, int row)
        {
            int cellId = (layer * NumberOfColumns * NumberOfRows) + (row * NumberOfColumns) + column;

            return cellId;
        }
    }
}