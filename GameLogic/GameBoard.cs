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
        private Random _random = new Random();

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

            //if (location.X < 0 ||
            //    location.Y < 0 ||
            //    location.X > NumberOfColumns - 1 ||
            //    location.Y > NumberOfRows - 1)
            //{
            //    return Cell.Null;
            //}

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

            int i = _random.Next(1, 25);
            if (i == 1)
                AddCellsIfItsOnBoard(neighbors, a, b, c, d);
            else if (i == 2)
                AddCellsIfItsOnBoard(neighbors, a, b, d, c);
            else if (i == 3)
                AddCellsIfItsOnBoard(neighbors, a, c, b, d);
            else if (i == 4)
                AddCellsIfItsOnBoard(neighbors, a, c, d, b);
            else if (i == 5)
                AddCellsIfItsOnBoard(neighbors, a, d, b, c);
            else if (i == 6)
                AddCellsIfItsOnBoard(neighbors, a, d, c, b);
            else if (i == 7)
                AddCellsIfItsOnBoard(neighbors, b, a, c, d);
            else if (i == 8)
                AddCellsIfItsOnBoard(neighbors, b, a, d, c);
            else if (i == 9)
                AddCellsIfItsOnBoard(neighbors, b, c, a, d);
            else if (i == 10)
                AddCellsIfItsOnBoard(neighbors, b, c, d, a);
            else if (i == 11)
                AddCellsIfItsOnBoard(neighbors, b, d, a, c);
            else if (i == 12)
                AddCellsIfItsOnBoard(neighbors, b, d, c, a);
            else if (i == 13)
                AddCellsIfItsOnBoard(neighbors, c, a, b, d);
            else if (i == 14)
                AddCellsIfItsOnBoard(neighbors, c, a, d, b);
            else if (i == 15)
                AddCellsIfItsOnBoard(neighbors, c, b, a, d);
            else if (i == 16)
                AddCellsIfItsOnBoard(neighbors, c, b, d, a);
            else if (i == 17)
                AddCellsIfItsOnBoard(neighbors, c, d, a, b);
            else if (i == 18)
                AddCellsIfItsOnBoard(neighbors, c, d, b, a);
            else if (i == 19)
                AddCellsIfItsOnBoard(neighbors, d, a, b, c);
            else if (i == 20)
                AddCellsIfItsOnBoard(neighbors, d, a, c, b);
            else if (i == 21)
                AddCellsIfItsOnBoard(neighbors, d, b, a, c);
            else if (i == 22)
                AddCellsIfItsOnBoard(neighbors, d, b, c, a);
            else if (i == 23)
                AddCellsIfItsOnBoard(neighbors, d, c, a, b);
            else if (i == 24)
                AddCellsIfItsOnBoard(neighbors, d, c, b, a);

            //AddCellIfItsOnBoard(a, neighbors);
            //AddCellIfItsOnBoard(b, neighbors);
            //AddCellIfItsOnBoard(c, neighbors);
            //AddCellIfItsOnBoard(d, neighbors);

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

        private void AddCellIfItsOnBoard(Point p, List<Point> neighbors)
        {
            if (IsCellOnBoard(p))
            {
                neighbors.Add(p);
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

        private string DebuggerDisplay => $"{{NumberOfLayers={NumberOfLayers}, NumberOfColumns={NumberOfColumns}, NumberOfRows={NumberOfRows}}}";
    }
}