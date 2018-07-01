using System.Drawing;
using System.Windows.Forms;
using GameLogic;

namespace WinFormsGui
{
    public class Map
    {
        private const int CellWidth = 20;
        private const int CellHeight = 20;

        private readonly GameWorld _gameWorld;
        private readonly Images _images;

        private readonly BufferedGraphics _bufferedGraphics;
        private readonly Graphics _graphicsBuffer;
        private readonly Rectangle _drawingArea;
        private readonly Color _color;

        private readonly Camera _camera;

        public Map(Graphics graphics, int x, int y, int width, int height, Color color, GameWorld gameWorld, Images images)
        {
            _gameWorld = gameWorld;
            _images = images;

            _drawingArea = new Rectangle(x, y, width, height);

            BufferedGraphicsContext currentContext = BufferedGraphicsManager.Current;
            _bufferedGraphics = currentContext.Allocate(graphics, _drawingArea);
            _graphicsBuffer = _bufferedGraphics.Graphics;

            _camera = new Camera(new Rectangle(0, 0, width, height));
            _color = color;
        }

        public void PanUp()
        {
            _camera.PanUp();
        }

        public void PanDown()
        {
            _camera.PanDown();
        }

        public void PanRight()
        {
            _camera.PanRight();
        }

        public void PanLeft()
        {
            _camera.PanLeft();
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
                    var rectangle = new Rectangle(x + _drawingArea.X - _camera.VisibleRectangle.X, y + _drawingArea.Y - _camera.VisibleRectangle.Y, CellWidth, CellHeight);

                    GameLogic.Point p = GameLogic.Point.Create(colIndex, rowIndex);
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