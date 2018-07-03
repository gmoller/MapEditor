using System;
using System.Drawing;

namespace WinFormsGui
{
    public class Camera
    {
        private readonly int _cellWidth;
        private readonly int _cellHeight;
        private readonly Point _viewCenterCell; // Center cell of the view

        private readonly Rectangle _world;
        private readonly int _numberOfColumnsInWorld;
        private readonly int _numberOfRowsInWorld;

        /// <summary>
        /// The "view" into the world (what is seen on the screen).
        /// The entire world is 0,0 -> 4000 (200*20), 3200 (160*20)
        /// The rectangle should always be within these bounds.
        /// </summary>
        public Rectangle VisibleRectangle { get; private set; }

        public Camera(Rectangle view, Rectangle world, int cellWidth, int cellHeight)
        {
            _cellWidth = cellWidth;
            _cellHeight = cellHeight;

            VisibleRectangle = view;
            _world = world;

            _numberOfColumnsInWorld = world.Width / cellWidth;
            _numberOfRowsInWorld = world.Height / cellHeight;

            int numberOfColumnsInView = view.Width / cellWidth;
            int numberOfRowsInView = view.Height / cellHeight;

            _viewCenterCell = new Point(numberOfColumnsInView / 2, numberOfRowsInView / 2);
        }

        public void CenterOnCell(Point worldCell)
        {
            int left = (worldCell.X - _viewCenterCell.X) * _cellWidth;
            int top = (worldCell.Y - _viewCenterCell.Y) * _cellHeight;

            // check bounds
            left = Math.Max(0, left);
            top = Math.Max(0, top);

            left = Math.Min(left, _world.Right - VisibleRectangle.Width);
            top = Math.Min(top, _world.Bottom - VisibleRectangle.Height);

            // if (view.Right > world.Right) { view.Right = world.Right }
            //if (left + VisibleRectangle.Width > _world.Right)
            //{
            //    left = _world.Right - VisibleRectangle.Width;
            //}
            // if (view.Bottom > world.Bottom) { view.Bottom = world.Bottom }
            //if (top + VisibleRectangle.Height > _world.Bottom)
            //{
            //    top = _world.Bottom - VisibleRectangle.Height;
            //}

            var view = new Rectangle(left, top, VisibleRectangle.Width, VisibleRectangle.Height);

            VisibleRectangle = view;
        }
    }
}