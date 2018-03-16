using System;
using System.Drawing;

namespace MapEditor
{
    internal static class CellPainterFactory
    {
        internal static CellPainter GetCellPainter(Point startCell, Point endCell)
        {
            if (startCell.X == endCell.X && startCell.Y == endCell.Y)
            {
                return new SingleCellPainter(startCell, endCell);
            }
            if (startCell.X == endCell.X && startCell.Y < endCell.Y) // N
            {
                return new UpFiller(startCell, endCell);
            }
            if (startCell.X < endCell.X && startCell.Y == endCell.Y) // E
            {
                return new RightFiller(startCell, endCell);
            }
            if (startCell.X == endCell.X && startCell.Y > endCell.Y) // S
            {
                return new DownFiller(startCell, endCell);
            }
            if (startCell.X > endCell.X && startCell.Y == endCell.Y) // W
            {
                return new LeftFiller(startCell, endCell);
            }
            if (startCell.X < endCell.X && startCell.Y > endCell.Y) // SE
            {
                return new DownRightFiller(startCell, endCell);
            }
            if (startCell.X > endCell.X && startCell.Y > endCell.Y) // SW
            {
                return new DownLeftFiller(startCell, endCell);
            }
            if (startCell.X < endCell.X && startCell.Y < endCell.Y) // NE
            {
                return new UpRightFiller(startCell, endCell);
            }
            if (startCell.X > endCell.X && startCell.Y < endCell.Y) // NW
            {
                return new UpLeftFiller(startCell, endCell);
            }

            throw new NotImplementedException("Could not determine CellPainter implementation.");
        }
    }

    internal abstract class CellPainter
    {
        protected Point StartCell;
        protected Point EndCell;

        internal CellPainter(Point startCell, Point endCell)
        {
            StartCell = startCell;
            EndCell = endCell;
        }

        internal abstract void Paint(int layer, byte? selectedPaletteId, byte? selectedImageId, Map map);

        protected void FillCell(Point cell, int layer, byte? selectedPaletteId, byte? selectedImageId, Map map)
        {
            if (selectedPaletteId != null && selectedImageId != null)
            {
                // place selected image in that cell
                map.SetCell(layer, cell.X, cell.Y, selectedPaletteId.Value, selectedImageId.Value);
            }
            else
            {
                // place nothing in that cell
                map.SetCell(layer, cell.X, cell.Y, 0xFF, 0xFF);
            }
        }
    }

    internal class SingleCellPainter : CellPainter
    {
        internal SingleCellPainter(Point startCell, Point endCell) : base(startCell, endCell)
        {
        }

        internal override void Paint(int layer, byte? selectedPaletteId, byte? selectedImageId, Map map)
        {
            FillCell(StartCell, layer, selectedPaletteId, selectedImageId, map);
        }
    }

    internal class UpFiller : CellPainter
    {
        internal UpFiller(Point startCell, Point endCell) : base(startCell, endCell)
        {
        }

        internal override void Paint(int layer, byte? selectedPaletteId, byte? selectedImageId, Map map)
        {
            Point currentCell = StartCell;

            do
            {
                FillCell(currentCell, layer, selectedPaletteId, selectedImageId, map);
                currentCell.Y++;
            } while (currentCell.Y <= EndCell.Y);
        }
    }

    internal class RightFiller : CellPainter
    {
        internal RightFiller(Point startCell, Point endCell) : base(startCell, endCell)
        {
        }

        internal override void Paint(int layer, byte? selectedPaletteId, byte? selectedImageId, Map map)
        {
            Point currentCell = StartCell;

            do
            {
                FillCell(currentCell, layer, selectedPaletteId, selectedImageId, map);
                currentCell.X++;
            } while (currentCell.X <= EndCell.X);
        }
    }

    internal class DownFiller : CellPainter
    {
        internal DownFiller(Point startCell, Point endCell) : base(startCell, endCell)
        {
        }

        internal override void Paint(int layer, byte? selectedPaletteId, byte? selectedImageId, Map map)
        {
            Point currentCell = StartCell;

            do
            {
                FillCell(currentCell, layer, selectedPaletteId, selectedImageId, map);
                currentCell.Y--;
            } while (currentCell.Y >= EndCell.Y);
        }
    }

    internal class LeftFiller : CellPainter
    {
        internal LeftFiller(Point startCell, Point endCell) : base(startCell, endCell)
        {
        }

        internal override void Paint(int layer, byte? selectedPaletteId, byte? selectedImageId, Map map)
        {
            Point currentCell = StartCell;

            do
            {
                FillCell(currentCell, layer, selectedPaletteId, selectedImageId, map);
                currentCell.X--;
            } while (currentCell.X >= EndCell.X);
        }
    }

    internal class DownRightFiller : CellPainter
    {
        internal DownRightFiller(Point startCell, Point endCell) : base(startCell, endCell)
        {
        }

        internal override void Paint(int layer, byte? selectedPaletteId, byte? selectedImageId, Map map)
        {
            Point currentCell = StartCell;

            do
            {
                do
                {
                    FillCell(currentCell, layer, selectedPaletteId, selectedImageId, map);
                    currentCell.X++;
                } while (currentCell.X <= EndCell.X);
                currentCell.X = StartCell.X;
                currentCell.Y--;
            } while (currentCell.Y >= EndCell.Y);
        }
    }

    internal class DownLeftFiller : CellPainter
    {
        internal DownLeftFiller(Point startCell, Point endCell) : base(startCell, endCell)
        {
        }

        internal override void Paint(int layer, byte? selectedPaletteId, byte? selectedImageId, Map map)
        {
            Point currentCell = StartCell;

            do
            {
                do
                {
                    FillCell(currentCell, layer, selectedPaletteId, selectedImageId, map);
                    currentCell.X--;
                } while (currentCell.X >= EndCell.X);
                currentCell.X = StartCell.X;
                currentCell.Y--;
            } while (currentCell.Y >= EndCell.Y);
        }
    }

    internal class UpRightFiller : CellPainter
    {
        internal UpRightFiller(Point startCell, Point endCell) : base(startCell, endCell)
        {
        }

        internal override void Paint(int layer, byte? selectedPaletteId, byte? selectedImageId, Map map)
        {
            Point currentCell = StartCell;

            do
            {
                do
                {
                    FillCell(currentCell, layer, selectedPaletteId, selectedImageId, map);
                    currentCell.X++;
                } while (currentCell.X <= EndCell.X);
                currentCell.X = StartCell.X;
                currentCell.Y++;
            } while (currentCell.Y <= EndCell.Y);
        }
    }

    internal class UpLeftFiller : CellPainter
    {
        internal UpLeftFiller(Point startCell, Point endCell) : base(startCell, endCell)
        {
        }

        internal override void Paint(int layer, byte? selectedPaletteId, byte? selectedImageId, Map map)
        {
            Point currentCell = StartCell;

            do
            {
                do
                {
                    FillCell(currentCell, layer, selectedPaletteId, selectedImageId, map);
                    currentCell.X--;
                } while (currentCell.X >= EndCell.X);
                currentCell.X = StartCell.X;
                currentCell.Y++;
            } while (currentCell.Y <= EndCell.Y);
        }
    }
}