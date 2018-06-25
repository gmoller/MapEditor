using System;
using System.Diagnostics;

namespace GameLogic
{
    /// <summary>
    /// </summary>
    [DebuggerDisplay("{" + nameof(DebuggerDisplay) + ",nq}")]
    public class GameBoard
    {
        private Cell[,,] _cells; // layer-z, column-x, row-y

        public int NumberOfLayers => _cells.GetLength(0);
        public int NumberOfColumns => _cells.GetLength(1);
        public int NumberOfRows => _cells.GetLength(2);

        public GameBoard(int numberOfLayers, int numberOfColumns, int numberOfRows)
        {
            _cells = new Cell[numberOfLayers, numberOfColumns, numberOfRows];

            for (int layer = 0; layer < numberOfLayers; ++layer)
            {
                for (int column = 0; column < numberOfColumns; ++column)
                {
                    for (int row = 0; row < numberOfRows; ++row)
                    {
                        _cells[layer, column, row] = Cell.Create(0);
                    }
                }
            }
        }

        public void SetState(byte[] bytes)
        {
            // check version
            if (bytes[0] != 0x00 || bytes[1] != 0x01)
            {
                throw new Exception("Only version 1 supported!");
            }

            // number of layers, columns, rows
            byte numberOfLayers = bytes[2];
            int numberOfColumns = BitConverter.ToInt32(bytes, 3);
            int numberOfRows = BitConverter.ToInt32(bytes, 7);

            _cells = new Cell[numberOfLayers, numberOfColumns, numberOfRows];

            // cells
            int cursor = 11;
            int layer = 0;
            int column = 0;
            int row = 0;
            for (int i = cursor; i < bytes.Length - NumberOfLayers; i += 2)
            {
                byte b1 = bytes[i];
                byte b2 = bytes[i + 1];

                if (b2 == 0) b2 = 1;
                else if (b2 == 7) b2 = 6;
                else if (b2 == 8) b2 = 7;
                else if (b2 == 9) b2 = 11;
                else if (b2 == 10) b2 = 0;
                //_cells[layer, column, row].PaletteId = b1;
                //_cells[layer, column, row].TileId = b2;
                _cells[layer, column, row] = Cell.Create(b2);

                row++;
                if (row > NumberOfRows - 1)
                {
                    row = 0;
                    column++;
                    if (column > NumberOfColumns - 1)
                    {
                        column = 0;
                        layer++;
                    }
                }
            }
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

            return _cells[0, location.X, location.Y];
        }

        private string DebuggerDisplay => $"{{NumberOfLayers={NumberOfLayers}, NumberOfColumns={NumberOfColumns}, NumberOfRows={NumberOfRows}}}";
    }
}