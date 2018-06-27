using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace GameLogic
{
    /// <summary>
    /// </summary>
    [DebuggerDisplay("{" + nameof(DebuggerDisplay) + ",nq}")]
    public class GameBoard
    {
        private readonly Random _random = new Random();

        private Cell[,,] _cells; // layer-z, column-x, row-y
        private bool[,] _isVisible;

        internal int NumberOfLayers => _cells.GetLength(0);
        public int NumberOfColumns => _cells.GetLength(1);
        public int NumberOfRows => _cells.GetLength(2);

        private GameBoard(int numberOfLayers, int numberOfColumns, int numberOfRows)
        {
            _cells = new Cell[numberOfLayers, numberOfColumns, numberOfRows];
            _isVisible = new bool[numberOfColumns, numberOfRows];

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

        internal static GameBoard Create(int numberOfLayers, int numberOfColumns, int numberOfRows)
        {
            return new GameBoard(numberOfLayers, numberOfColumns, numberOfRows);
        }

        internal void SetState(byte[] bytes)
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
            _isVisible = new bool[numberOfColumns, numberOfRows];

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

        internal Cell GetCell(Point location)
        {
            if (!IsCellOnBoard(location))
            {
                return Cell.Null;
            }

            return _cells[0, location.X, location.Y];
        }

        private bool IsCellOnBoard(Point location)
        {
            if (location.X < 0 ||
                location.Y < 0 ||
                location.X > NumberOfColumns - 1 ||
                location.Y > NumberOfRows - 1)
            {
                return false;
            }

            return true;
        }

        internal List<Point> GetCellNeighbors(Point location)
        {
            var neighbors = new List<Point>();
            Point a = Point.Create(location.X, location.Y + 1); // north
            Point b = Point.Create(location.X - 1, location.Y); // west
            Point c = Point.Create(location.X, location.Y - 1); // south
            Point d = Point.Create(location.X + 1, location.Y); // east

            var dic = new Dictionary<int, Point[]>
            {
                {1, new[] {a, b, c, d}},
                {2, new[] {a, b, d, c}},
                {3, new[] {a, c, b, d}},
                {4, new[] {a, c, d, b}},
                {5, new[] {a, d, b, c}},
                {6, new[] {a, d, c, b}},
                {7, new[] {b, a, c, d}},
                {8, new[] {b, a, d, c}},
                {9, new[] {b, c, a, d}},
                {10, new[] {b, c, d, a}},
                {11, new[] {b, d, a, c}},
                {12, new[] {b, d, c, a}},
                {13, new[] {c, a, b, d}},
                {14, new[] {c, a, d, b}},
                {15, new[] {c, b, a, d}},
                {16, new[] {c, b, d, a}},
                {17, new[] {c, d, a, b}},
                {18, new[] {c, d, b, a}},
                {19, new[] {d, a, b, c}},
                {20, new[] {d, a, c, b}},
                {21, new[] {d, b, a, c}},
                {22, new[] {d, b, c, a}},
                {23, new[] {d, c, a, b}},
                {24, new[] {d, c, b, a}}
            };

            int i = _random.Next(1, 25);
            Point[] points = dic[i];
            AddCellsIfItsOnBoard(neighbors, points);

            return neighbors;
        }
        private void AddCellsIfItsOnBoard(List<Point> neighbors, params Point[] points)
        {
            foreach (Point item in points)
            {
                if (IsCellOnBoard(item))
                {
                    neighbors.Add(item);
                }
            }
        }

        internal bool IsCellVisible(Point location)
        {
            return _isVisible[location.X, location.Y];
        }

        internal void SetCellVisible(Point location)
        {
            _isVisible[location.X, location.Y] = true;
        }

        internal void SetAllCellsInvisible()
        {
            _isVisible = new bool[NumberOfColumns, NumberOfRows];
        }

        private string DebuggerDisplay => $"{{NumberOfLayers={NumberOfLayers}, NumberOfColumns={NumberOfColumns}, NumberOfRows={NumberOfRows}}}";
    }
}