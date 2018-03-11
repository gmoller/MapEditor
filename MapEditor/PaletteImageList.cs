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

        internal Bitmap CombineImagesIntoOne(PaletteImageList images, int maxWidth)
        {
            int width = DetermineWidth(images, maxWidth);
            int height = DetermineHeight(images, maxWidth);

            var finalImage = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(finalImage))
            {
                g.Clear(Color.Pink);
                int xOffset = 0;
                int yOffset = 0;
                foreach (PaletteImage image in images)
                {
                    if (xOffset + image.Width <= maxWidth)
                    {
                        g.DrawImage(image.Bitmap, new Rectangle(xOffset, yOffset, image.Width, image.Height));
                        xOffset += image.Width + 1;
                    }
                    else
                    {
                        xOffset = 0;
                        yOffset += image.Height + 1;
                        g.DrawImage(image.Bitmap, new Rectangle(xOffset, yOffset, image.Width, image.Height));
                    }
                }
            }

            return finalImage;
        }

        private int DetermineWidth(PaletteImageList images, int maxWidth)
        {
            int width = 0;
            int xOffset = 0;

            foreach (PaletteImage image in images)
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

        private int DetermineHeight(PaletteImageList images, int maxWidth)
        {
            int width = 0;
            int height = 0;
            int xOffset = 0;
            int yOffset = 0;

            foreach (PaletteImage image in images)
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