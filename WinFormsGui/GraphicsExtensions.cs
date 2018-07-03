using System.Drawing;
using System.Windows.Forms;

namespace WinFormsGui
{
    public static class GraphicsExtensions
    {
        public static void DrawEllipse(this Graphics graphics, Rectangle rectangle, Color color)
        {
            using (var pen = new Pen(color))
            {
                graphics.DrawEllipse(pen, rectangle);
            }
        }

        public static void DrawCircle(this Graphics graphics, Point center, float radius, Color color)
        {
            using (var pen = new Pen(color))
            {
                graphics.DrawEllipse(pen, center.X - radius, center.Y - radius, radius * 2, radius * 2);
            }
        }

        public static void DrawRectangle(this Graphics graphics, Rectangle rectangle, Color color)
        {
            using (var pen = new Pen(color))
            {
                graphics.DrawRectangle(pen, rectangle);
            }
        }

        public static void FillRectangle(this Graphics graphics, Rectangle rectangle, Color color)
        {
            using (var brush = new SolidBrush(color))
            {
                graphics.FillRectangle(brush, rectangle);
            }
        }

        public static void DrawText(this Graphics graphics, Point position, string text, Font font, Color foreColor, Color backColor, Color borderColor)
        {
            Size size = TextRenderer.MeasureText(text, font);
            Rectangle rectangle = new Rectangle(position.X, position.Y, size.Width, size.Height);
            TextFormatFlags flags = TextFormatFlags.Default;
            TextRenderer.DrawText(graphics, text, font, rectangle, foreColor, backColor, flags);

            // Draw border
            graphics.DrawRectangle(rectangle, borderColor);
        }

        public static void DrawText(this Graphics graphics, Rectangle rectangle, string text, Font font, Color foreColor, Color backColor, Color borderColor, TextFormatFlags flags = TextFormatFlags.Default)
        {
            TextRenderer.DrawText(graphics, text, font, rectangle, foreColor, backColor, flags);

            // Draw border
            graphics.DrawRectangle(rectangle, borderColor);
        }
    }
}