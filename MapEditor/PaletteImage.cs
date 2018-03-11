using System.Drawing;

namespace MapEditor
{
    internal class PaletteImage
    {
        internal string Name { get; private set; }
        internal string Directory { get; private set; }
        internal Bitmap Bitmap { get; }
        internal int Width => Bitmap.Width;
        internal int Height => Bitmap.Height;

        internal PaletteImage(string name, string directory, Bitmap bitmap)
        {
            Name = name;
            Directory = directory;
            Bitmap = bitmap;
        }
    }
}