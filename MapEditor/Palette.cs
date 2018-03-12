using System.Drawing;
using System.IO;

namespace MapEditor
{
    internal class Palette
    {
        internal byte Id { get; }
        internal string Name { get; }
        internal string Directory { get; }
        internal Bitmap Image { get; }

        internal PaletteImageList Images { get; }

        internal Palette(byte id, string name, string directory)
        {
            Id = id;
            Name = name;
            Directory = directory;

            Images = LoadTilesForPalette(directory);
            Images.DeterminePlacementOnPalette(260);
            Image = Images.CombineImagesIntoOne(260);
        }

        internal PaletteImage HitTest(Point location)
        {
            foreach (PaletteImage item in Images)
            {
                if (item.PlacementOnPalette.Contains(location))
                {
                    return item;
                }
            }

            return null;
        }

        private PaletteImageList LoadTilesForPalette(string paletteDirectory)
        {
            string[] files = System.IO.Directory.GetFiles(paletteDirectory, "*.png");

            var images = new PaletteImageList();

            byte tileId = 0;
            foreach (string file in files)
            {
                var bitmap = new Bitmap(file);
                string name = Path.GetFileName(file);
                images.Add(new PaletteImage(tileId, name, paletteDirectory, bitmap));
                tileId++;
            }

            return images;
        }
    }
}