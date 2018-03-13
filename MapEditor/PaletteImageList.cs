using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;

namespace MapEditor
{
    internal class PaletteImageList : IEnumerable<PaletteImage>
    {
        private readonly List<PaletteImage> _images = new List<PaletteImage>();

        internal void Add(PaletteImage image)
        {
            _images.Add(image);
        }

        internal PaletteImage this[int i] => _images[i];

        internal void DeterminePlacementOnPalette(int width, int height, int numberPerLine)
        {
            int xOffset = 0;
            int yOffset = 0;
            int count = 0;

            foreach (PaletteImage image in _images)
            {
                Rectangle rect;
                if (count < numberPerLine)
                {
                    rect = new Rectangle(xOffset, yOffset, width, height);
                    xOffset += width + 1;
                    count++;
                }
                else
                {
                    count = 0;
                    xOffset = 0;
                    yOffset += height + 1;
                    rect = new Rectangle(xOffset, yOffset, width, height);
                    xOffset += width + 1;
                    count++;
                }

                image.PlacementOnPalette = rect;
            }
        }

        //internal void DeterminePlacementOnPalette(int maxWidth)
        //{
        //    int xOffset = 0;
        //    int yOffset = 0;
        //    foreach (PaletteImage image in _images)
        //    {
        //        Rectangle rect;
        //        if (xOffset + image.Width / 2 <= maxWidth)
        //        {
        //            rect = new Rectangle(xOffset, yOffset, image.Width / 2, image.Height / 2);
        //            xOffset += image.Width / 2 + 1;
        //        }
        //        else
        //        {
        //            xOffset = 0;
        //            yOffset += image.Height / 2 + 1;
        //            rect = new Rectangle(xOffset, yOffset, image.Width / 2, image.Height / 2);
        //            xOffset += image.Width / 2 + 1;
        //        }

        //        image.PlacementOnPalette = rect;
        //    }
        //}

        internal Bitmap CombineImagesIntoOne(int width, int height, int numberPerLine)
        {
            if (_images.Count == 0) return new Bitmap(1, 1);

            int width2 = width * numberPerLine + (numberPerLine - 1);

            int rows = _images.Count / numberPerLine + (_images.Count % numberPerLine == 0 ? 0 : 1);
            int height2 = rows * height + (rows - 1);

            var finalImage = new Bitmap(width2, height2);
            using (Graphics g = Graphics.FromImage(finalImage))
            {
                g.Clear(Color.Magenta);
                foreach (PaletteImage image in _images)
                {
                    g.DrawImage(image.Bitmap, image.PlacementOnPalette);
                }
            }

            return finalImage;
        }

        //internal Bitmap CombineImagesIntoOne(int maxWidth)
        //{
        //    int width = DetermineWidth(maxWidth);
        //    int height = DetermineHeight(maxWidth);

        //    if (width == 0 || height == 0) return new Bitmap(1, 1);

        //    var finalImage = new Bitmap(width, height);
        //    using (Graphics g = Graphics.FromImage(finalImage))
        //    {
        //        g.Clear(Color.Transparent);
        //        foreach (PaletteImage image in _images)
        //        {
        //            g.DrawImage(image.Bitmap, image.PlacementOnPalette);
        //        }
        //    }

        //    return finalImage;
        //}

        private int DetermineWidth(int maxWidth)
        {
            int width = 0;
            int xOffset = 0;

            foreach (PaletteImage image in _images)
            {
                if (image.Width > maxWidth)
                {
                    throw new Exception("Width of image too large. Must be smaller than [{maxWidth}].");
                }

                if (xOffset + image.Width <= maxWidth)
                {
                    xOffset += image.Width;
                }
                else
                {
                    if (width < xOffset)
                    {
                        width = xOffset;
                    }

                    xOffset = 0;
                    xOffset += image.Width;
                }
            }

            return width;
        }

        private int DetermineHeight(int maxWidth)
        {
            int width = 0;
            int height = 0;
            int xOffset = 0;
            int yOffset = 0;

            foreach (PaletteImage image in _images)
            {
                if (image.Width > maxWidth)
                {
                    throw new Exception("Width of image too large. Must be smaller than [{maxWidth}].");
                }

                if (xOffset + image.Width <= maxWidth)
                {
                    xOffset += image.Width;
                    height = image.Height + yOffset > height ? image.Height + yOffset : height;
                }
                else
                {
                    width = width < xOffset ? xOffset : width;
                    xOffset = image.Width;
                    yOffset = height;
                    height += image.Height;
                }
            }

            return height;
        }

        public IEnumerator<PaletteImage> GetEnumerator()
        {
            return ((IEnumerable<PaletteImage>)_images).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}