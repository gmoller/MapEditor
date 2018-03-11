using System.Drawing;
using System.IO;

namespace MapEditor
{
    internal class Palette
    {
        internal string Name { get; private set; }
        internal string Directory { get; private set; }
        internal Bitmap Image { get; private set; }

        private PaletteImageList _images;

        internal Palette(string name, string directory)
        {
            Name = name;
            Directory = directory;

            _images = LoadTilesForPalette(directory);
            Image = _images.CombineImagesIntoOne(_images, 260);
        }

        private PaletteImageList LoadTilesForPalette(string paletteDirectory)
        {
            string[] files = System.IO.Directory.GetFiles(paletteDirectory, "*.png");

            var images = new PaletteImageList();

            foreach (string file in files)
            {
                var bitmap = new Bitmap(file);
                string name = Path.GetFileName(file);
                images.Add(new PaletteImage(name, paletteDirectory, bitmap));
            }

            return images;
        }
    }
}