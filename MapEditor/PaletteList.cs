using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace MapEditor
{
    internal class PaletteList : IEnumerable<Palette>
    {
        private readonly List<Palette> _palettes = new List<Palette>();

        internal void Load()
        {
            string[] directories = Directory.GetDirectories(@"Content\Tilesets\");

            byte paletteId = 0;
            foreach (string directory in directories)
            {
                string name = Path.GetFileName(directory);
                var palette = new Palette(paletteId, name, directory);

                _palettes.Add(palette);
                paletteId++;
            }
        }

        internal Palette this[int i] => _palettes[i];

        internal Palette this[string s]
        {
            get
            {
                foreach (Palette palette in _palettes)
                {
                    if (palette.Name.Equals(s))
                    {
                        return palette;
                    }
                }

                throw new Exception($"Palette [{s}] not found.");
            }
        }

        public IEnumerator<Palette> GetEnumerator()
        {
            return ((IEnumerable<Palette>)_palettes).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}