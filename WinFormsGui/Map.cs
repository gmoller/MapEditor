using System.Drawing;
using System.Windows.Forms;
using GameLogic;
using GameMap;
using GeneralUtilities;

namespace WinFormsGui
{
    public class Map
    {
        private const int CellWidth = 30;
        private const int CellHeight = 30;

        private readonly GameWorld _gameWorld;
        private readonly Images _images;

        private readonly BufferedGraphics _bufferedGraphics;
        private readonly Graphics _graphicsBuffer;
        private readonly Rectangle _drawingArea;
        private readonly Color _color;

        private readonly Camera _camera;

        public int Width => _drawingArea.Width;
        public int Height => _drawingArea.Height;
        public int ColumnCellsOnMap => _drawingArea.Width / CellWidth;
        public int RowsCellsOnMap => _drawingArea.Height / CellHeight;

        public Map(Graphics graphics, int x, int y, int width, int height, Color color, GameWorld gameWorld, Images images)
        {
            _gameWorld = gameWorld;
            _images = images;

            _drawingArea = new Rectangle(x, y, width, height);

            BufferedGraphicsContext currentContext = BufferedGraphicsManager.Current;
            _bufferedGraphics = currentContext.Allocate(graphics, _drawingArea);
            _graphicsBuffer = _bufferedGraphics.Graphics;

            _camera = new Camera(new Rectangle(0, 0, width, height), new Rectangle(0, 0, gameWorld.NumberOfColumns * CellWidth, gameWorld.NumberOfRows * CellHeight), CellWidth, CellHeight);
            _color = color;
        }

        internal Point ConvertViewToWorld(Point view)
        {
            int temp1 = _camera.VisibleRectangle.X - _drawingArea.X + 5;
            int temp2 = temp1 / CellWidth;

            int temp3 = temp2 + view.X;

            int temp4 = _camera.VisibleRectangle.Y - _drawingArea.Y + 5;
            int temp5 = temp4 / CellHeight;

            int temp6 = temp5 + view.Y;

            return new Point(temp3, temp6);
        }

        public void CenterOnCell(Point worldCell)
        {
            _camera.CenterOnCell(worldCell);
        }

        public void Clear()
        {
            _graphicsBuffer.Clear(_color);
        }

        public void DrawBoard(bool showGrid)
        {
            Rectangle sourceRectangle = _images.GetImageSize();
            int x = 0;
            int y = 0;
            for (int rowIndex = _gameWorld.GameBoard.NumberOfRows - 1; rowIndex >= 0; --rowIndex)
            {
                for (int colIndex = 0; colIndex < _gameWorld.GameBoard.NumberOfColumns; ++colIndex)
                {
                    var rectangle = new Rectangle(x + _drawingArea.X -_camera.VisibleRectangle.X, y + _drawingArea.Y - _camera.VisibleRectangle.Y, CellWidth, CellHeight);

                    Point2 p = Point2.Create(colIndex, rowIndex);
                    Cell cell = _gameWorld.GetCell(p);
                    if (_gameWorld.IsCellVisible(p))
                    {
                        _graphicsBuffer.DrawImage(_images.GetImage(cell.TerrainTypeId), rectangle, sourceRectangle, GraphicsUnit.Pixel);

                    }
                    else
                    {
                        _graphicsBuffer.FillRectangle(rectangle, Color.Black);
                    }

                    if (showGrid)
                    {
                        _graphicsBuffer.DrawRectangle(rectangle, Color.DimGray);
                    }

                    x += CellWidth;
                }

                y += CellHeight;
                x = 0;
            }

            // TODO: get below values from camera
            const int margin = 5;
            int radius = CellWidth / 2;
            _graphicsBuffer.DrawCircle(new Point( 0 * CellWidth + radius + margin,  0 * CellHeight + radius + margin), radius, Color.DeepPink); // NW
            _graphicsBuffer.DrawCircle(new Point(31 * CellWidth + radius + margin,  0 * CellHeight + radius + margin), radius, Color.DeepPink); // NE
            _graphicsBuffer.DrawCircle(new Point(16 * CellWidth + radius + margin, 14 * CellHeight + radius + margin), radius, Color.DeepPink); // Center
            _graphicsBuffer.DrawCircle(new Point( 0 * CellWidth + radius + margin, 27 * CellHeight + radius + margin), radius, Color.DeepPink); // SW
            _graphicsBuffer.DrawCircle(new Point(31 * CellWidth + radius + margin, 27 * CellHeight + radius + margin), radius, Color.DeepPink); // SE

            _graphicsBuffer.DrawRectangle(new Rectangle(_drawingArea.X, _drawingArea.Y, _drawingArea.Width - 1, _drawingArea.Height - 1), Color.Red);
            _graphicsBuffer.DrawRectangle(new Rectangle(_drawingArea.X + 1, _drawingArea.Y + 1, _drawingArea.Width - 3, _drawingArea.Height - 3), Color.Red);
            _graphicsBuffer.DrawRectangle(new Rectangle(_drawingArea.X + 2, _drawingArea.Y + 2, _drawingArea.Width - 4, _drawingArea.Height - 4), Color.Red);
        }

        public void DrawUnits(Font font)
        {
            foreach (Unit item in _gameWorld.PlayerUnits)
            {
                int x = item.Location.X * CellWidth;
                int y = CellWidth * (_gameWorld.GameBoard.NumberOfRows - 1) - item.Location.Y * CellHeight;
                Font font2 = new Font(font.FontFamily, 16.5f);
                var rectangle = new Rectangle(x - _camera.VisibleRectangle.X, y - _camera.VisibleRectangle.Y, CellWidth, CellHeight);
                _graphicsBuffer.DrawText(rectangle, "@", font2, Color.Red, Color.Transparent, Color.Transparent, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }
        }

        public void FlipBuffer()
        {
            _bufferedGraphics.Render();
        }
    }
}