using System;
using System.Collections.Generic;
using System.Drawing;

namespace MapEditor
{
    internal class Map
    {
        private Cell[,,] _cells; // layer, column, row

        internal List<Layer> Layers { get; private set; }

        internal int NumberOfLayers => _cells.GetLength(0);
        internal int NumberOfColumns => _cells.GetLength(1);
        internal int NumberOfRows => _cells.GetLength(2);
        internal Point CellSize { get; private set; } // does this really belong here? I feel like it is only used for rendering.

        internal Map(int numberOfLayers, int numberOfColumns, int numberOfRows, int cellSizeX, int cellSizeY)
        {
            _cells = Initialize(numberOfLayers, numberOfColumns, numberOfRows);
            Layers = CreateLayers(numberOfLayers);
            CellSize = new Point(cellSizeX, cellSizeY);
        }

        internal Cell GetCell(int layer, int column, int row)
        {
            Cell cell = _cells[layer, column, row];

            return cell;
        }

        internal void SetCell(int layer, int column, int row, byte paletteId, byte tileId)
        {
            _cells[layer, column, row] = Cell.NewCell(paletteId, tileId);
        }

        internal void IncreaseCellSize()
        {
            CellSize = new Point(CellSize.X + 8, CellSize.Y + 8);
        }

        internal void DecreaseCellSize()
        {
            CellSize = new Point(CellSize.X - 8, CellSize.Y - 8);
        }

        internal void AddLayer()
        {
            Layers.Add(new Layer());
            Cell[,,] newCells = Initialize(NumberOfLayers + 1, NumberOfColumns, NumberOfRows);

            for (int layer = 0; layer < NumberOfLayers; ++layer)
            {
                for (int column = 0; column < NumberOfColumns; ++column)
                {
                    for (int row = 0; row < NumberOfRows; ++row)
                    {
                        newCells[layer, column, row] = GetCell(layer, column, row);
                    }
                }
            }

            _cells = newCells;
        }

        internal byte[] GetState()
        {
            List<byte> bytes = new List<byte>();

            // version
            bytes.Add(0x00);
            bytes.Add(0x01);

            // number of layers, columns, rows
            bytes.Add((byte)NumberOfLayers);

            bytes.Add((byte)NumberOfColumns);
            bytes.Add((byte)(NumberOfColumns >> 8));
            bytes.Add((byte)(NumberOfColumns >> 16));
            bytes.Add((byte)(NumberOfColumns >> 24));

            bytes.Add((byte)NumberOfRows);
            bytes.Add((byte)(NumberOfRows >> 8));
            bytes.Add((byte)(NumberOfRows >> 16));
            bytes.Add((byte)(NumberOfRows >> 24));

            // cells
            for (int layer = 0; layer < NumberOfLayers; ++layer)
            {
                for (int column = 0; column < NumberOfColumns ; ++column)
                {
                    for (int row = 0; row < NumberOfRows; ++row)
                    {
                        bytes.Add((byte)_cells[layer, column, row].PaletteId);
                        bytes.Add((byte)_cells[layer, column, row].TileId);
                    }
                }
            }

            // layers
            foreach (Layer layer in Layers)
            {
                if (layer.Visible)
                {
                    bytes.Add(0x00);
                }
                else
                {
                    bytes.Add(0x01);
                }
            }

            return bytes.ToArray();
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

            _cells = Initialize(numberOfLayers, numberOfColumns, numberOfRows);
            Layers = CreateLayers(numberOfLayers);

            // cells
            int cursor = 11;
            int layer = 0;
            int column = 0;
            int row = 0;
            for (int i = 11; i < bytes.Length - NumberOfLayers; i += 2)
            {
                byte b1 = bytes[i];
                byte b2 = bytes[i + 1];
                _cells[layer, column, row].PaletteId = b1;
                _cells[layer, column, row].TileId = b2;

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
                cursor = i;
            }
            cursor += 2;

            // layers
            for (int i = 0; i < NumberOfLayers; ++i)
            {
                Layers[i].Visible = bytes[cursor] == 0;
                cursor++;
            }
        }

        private Cell[,,] Initialize(int numberOfLayers, int numberOfColumns, int numberOfRows)
        {
            var array = new Cell[numberOfLayers, numberOfColumns, numberOfRows];

            for (int layer = 0; layer < numberOfLayers; ++layer)
            {
                for (int column = 0; column < numberOfColumns; ++column)
                {
                    for (int row = 0; row < numberOfRows; ++row)
                    {
                        array[layer, column, row] = Cell.EmptyCell();
                    }
                }
            }

            return array;
        }

        private List<Layer> CreateLayers(int numberOfLayers)
        {
            var layers = new List<Layer>();
            for (int i = 0; i < numberOfLayers; ++i)
            {
                layers.Add(new Layer());
            }

            return layers;
        }
    }
}