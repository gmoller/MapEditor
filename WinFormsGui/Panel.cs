using System.Drawing;

namespace WinFormsGui
{
    public class Panel
    {
        private readonly Graphics _graphicsBuffer;
        private readonly Rectangle _rectangle;
        private readonly Color _color;

        public Panel(Graphics graphicsBuffer, int x, int y, int width, int height, Color color)
        {
            _graphicsBuffer = graphicsBuffer;
            _rectangle = new Rectangle(x, y, width, height);
            _color = color;
        }

        public void DrawPanel()
        {
            _graphicsBuffer.FillRectangle(_rectangle, _color);
        }

        public void DrawText(Point location, string text, Font font, Color foreColor, Color backColor, Color borderColor)
        {
            _graphicsBuffer.DrawText(new Rectangle(_rectangle.X + location.X, _rectangle.Y + location.Y, _rectangle.Width - 1, 13), text, font, foreColor, backColor, borderColor);
        }
    }
}