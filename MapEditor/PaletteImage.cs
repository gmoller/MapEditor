using System.Drawing;

namespace MapEditor
{
    internal class PaletteImage
    {
        internal byte Id { get; }
        internal string Name { get; }
        internal string Directory { get; }
        internal Bitmap Bitmap { get; }
        internal Rectangle PlacementOnPalette { get; set; }
        internal int Width => Bitmap.Width;
        internal int Height => Bitmap.Height;

        internal PaletteImage(byte id, string name, string directory, Bitmap bitmap)
        {
            Id = id;
            Name = name;
            Directory = directory;
            Bitmap = bitmap;
        }
    }
}