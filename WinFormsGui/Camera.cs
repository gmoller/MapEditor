using System.Drawing;

namespace WinFormsGui
{
    public class Camera
    {
        private const int Step = 20;

        public Rectangle VisibleRectangle { get; private set; }

        public Camera(Rectangle rectangle)
        {
            VisibleRectangle = rectangle;
        }

        public void PanUp()
        {
            VisibleRectangle = new Rectangle(VisibleRectangle.X, VisibleRectangle.Y - Step, VisibleRectangle.Width, VisibleRectangle.Height);
        }

        public void PanDown()
        {
            VisibleRectangle = new Rectangle(VisibleRectangle.X, VisibleRectangle.Y + Step, VisibleRectangle.Width, VisibleRectangle.Height);
        }

        public void PanRight()
        {
            VisibleRectangle = new Rectangle(VisibleRectangle.X + Step, VisibleRectangle.Y, VisibleRectangle.Width, VisibleRectangle.Height);
        }

        public void PanLeft()
        {
            VisibleRectangle = new Rectangle(VisibleRectangle.X - Step, VisibleRectangle.Y, VisibleRectangle.Width, VisibleRectangle.Height);
        }
    }
}