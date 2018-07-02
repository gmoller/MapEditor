using System.Drawing;

namespace WinFormsGui
{
    public class Camera
    {
        private readonly int _cellWidth;
        private readonly int _cellHeight;

        public Rectangle VisibleRectangle { get; private set; }

        public Camera(Rectangle rectangle, int cellWidth, int cellHeight)
        {
            _cellWidth = cellWidth;
            _cellHeight = cellHeight;
            VisibleRectangle = rectangle;
        }

        public void CenterOnCell(int column, int row)
        {
            int left = (column - 24) * _cellWidth; // TODO: remove magic number 24
            int top = (row - 21) * _cellHeight; // TODO: remove magic number 21
            VisibleRectangle = new Rectangle(left, top, VisibleRectangle.Width, VisibleRectangle.Height);
        }

        //public void PanUp()
        //{
        //    VisibleRectangle = new Rectangle(VisibleRectangle.X, VisibleRectangle.Y - Step, VisibleRectangle.Width, VisibleRectangle.Height);
        //}

        //public void PanDown()
        //{
        //    VisibleRectangle = new Rectangle(VisibleRectangle.X, VisibleRectangle.Y + Step, VisibleRectangle.Width, VisibleRectangle.Height);
        //}

        //public void PanRight()
        //{
        //    VisibleRectangle = new Rectangle(VisibleRectangle.X + Step, VisibleRectangle.Y, VisibleRectangle.Width, VisibleRectangle.Height);
        //}

        //public void PanLeft()
        //{
        //    VisibleRectangle = new Rectangle(VisibleRectangle.X - Step, VisibleRectangle.Y, VisibleRectangle.Width, VisibleRectangle.Height);
        //}
    }
}