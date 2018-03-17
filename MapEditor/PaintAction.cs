using System.Collections;
using System.Collections.Generic;

namespace MapEditor
{
    internal class PaintActionList : IEnumerable<PaintAction>
    {
        private readonly List<PaintAction> _actions = new List<PaintAction>();

        internal void Add(int layer, int x, int y, byte paletteId, byte imageId)
        {
            _actions.Add(new PaintAction(layer, x, y, paletteId, imageId));
        }

        internal void Add(PaintAction paintAction)
        {
            _actions.Add(paintAction);
        }

        internal void Add(PaintActionList paintActions)
        {
            foreach (PaintAction paintAction in paintActions)
            {
                _actions.Add(paintAction);
            }
        }

        public IEnumerator<PaintAction> GetEnumerator()
        {
            return ((IEnumerable<PaintAction>)_actions).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    internal class PaintAction
    {
        internal int X { get; }
        internal int Y { get; }
        internal int Layer { get; }
        internal byte PaletteId { get; }
        internal byte ImageId { get; }

        internal PaintAction(int layer, int x, int y, byte paletteId, byte imageId)
        {
            X = x;
            Y = y;
            Layer = layer;
            PaletteId = paletteId;
            ImageId = imageId;
        }
    }
}