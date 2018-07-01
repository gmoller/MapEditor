using System.Drawing;

namespace WinFormsGui
{
    public class Panel
    {
        private readonly BufferedGraphics _bufferedGraphics;
        private readonly Graphics _graphicsBuffer;
        private readonly Rectangle _drawingArea;
        private readonly Rectangle _rectangle;
        private readonly Color _color;

        public Panel(Graphics graphics, int x, int y, int width, int height, Color color)
        {
            _drawingArea = new Rectangle(x, y, width, height);

            BufferedGraphicsContext currentContext = BufferedGraphicsManager.Current;
            _bufferedGraphics = currentContext.Allocate(graphics, _drawingArea);
            _graphicsBuffer = _bufferedGraphics.Graphics;

            _rectangle = new Rectangle(0, 0, width, height);
            _color = color;
        }

        public void Clear()
        {
            _graphicsBuffer.Clear(_color);
        }

        public void DrawText(Point location, string text, Font font, Color foreColor, Color backColor, Color borderColor)
        {
            Rectangle rect = new Rectangle(location.X, location.Y, _drawingArea.Width - 1, 13);
            _graphicsBuffer.DrawText(rect, text, font, foreColor, backColor, borderColor);

            _graphicsBuffer.DrawRectangle(_drawingArea, Color.Magenta);
        }

        public void FlipBuffer()
        {
            _bufferedGraphics.Render();
        }
    }
}