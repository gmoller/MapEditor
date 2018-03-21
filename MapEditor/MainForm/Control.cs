using System;
using System.Windows.Forms;

namespace MapEditor.MainForm
{
    public abstract class Control
    {
        protected Form ParentForm { get; set; }
        public int Top { get; set; }
        public bool Enabled { get; set; }
        protected int MenuHeight = 24;

        public abstract Panel Create(EventHandler[] handlers1, MouseEventHandler[] handlers2);
        public abstract void Resize();
    }
}