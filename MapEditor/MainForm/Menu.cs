using System;
using System.Drawing;
using System.Windows.Forms;

namespace MapEditor.MainForm
{
    public class Menu
    {
        private MenuStrip _menuStrip;

        private ToolStripMenuItem _fileToolStripMenuItem;
        private ToolStripMenuItem _newToolStripMenuItem;
        private ToolStripMenuItem _openToolStripMenuItem;
        private ToolStripMenuItem _saveToolStripMenuItem;
        private ToolStripSeparator _toolStripMenuItem1;
        private ToolStripMenuItem _exitToolStripMenuItem;

        private ToolStripMenuItem _viewToolStripMenuItem;
        private ToolStripMenuItem _increaseGridSizeToolStripMenuItem;
        private ToolStripMenuItem _decreaseGridSizeToolStripMenuItem;

        private ToolStripMenuItem _actionsToolStripMenuItem;
        private ToolStripMenuItem _fillAllToolStripMenuItem;
        private ToolStripMenuItem _undoToolStripMenuItem;
        private ToolStripMenuItem _redoToolStripMenuItem;

        public MenuStrip Create(EventHandler newToolStripMenuItemClick, EventHandler openToolStripMenuItemClick, EventHandler saveToolStripMenuItemClick, EventHandler exitToolStripMenuItemClick, EventHandler increaseGridSizeToolStripMenuItemClick, EventHandler decreaseGridSizeToolStripMenuItemClick, EventHandler fillAllToolStripMenuItemClick, EventHandler undoToolStripMenuItemClick, EventHandler redoToolStripMenuItemClick)
        {
            _menuStrip = new MenuStrip();
            _fileToolStripMenuItem = new ToolStripMenuItem();
            _newToolStripMenuItem = new ToolStripMenuItem();
            _openToolStripMenuItem = new ToolStripMenuItem();
            _saveToolStripMenuItem = new ToolStripMenuItem();
            _toolStripMenuItem1 = new ToolStripSeparator();
            _exitToolStripMenuItem = new ToolStripMenuItem();
            _viewToolStripMenuItem = new ToolStripMenuItem();
            _increaseGridSizeToolStripMenuItem = new ToolStripMenuItem();
            _decreaseGridSizeToolStripMenuItem = new ToolStripMenuItem();
            _actionsToolStripMenuItem = new ToolStripMenuItem();
            _fillAllToolStripMenuItem = new ToolStripMenuItem();
            _undoToolStripMenuItem = new ToolStripMenuItem();
            _redoToolStripMenuItem = new ToolStripMenuItem();

            _menuStrip.SuspendLayout();

            _menuStrip.Items.AddRange(new ToolStripItem[] { _fileToolStripMenuItem, _viewToolStripMenuItem, _actionsToolStripMenuItem });
            _menuStrip.Location = new Point(0, 0);
            _menuStrip.Name = "menuStrip";
            _menuStrip.Size = new Size(1377, 24);
            _menuStrip.TabIndex = 0;
            _menuStrip.Text = @"menuStrip";

            _fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { _newToolStripMenuItem, _openToolStripMenuItem, _saveToolStripMenuItem, _toolStripMenuItem1, _exitToolStripMenuItem });
            _fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            _fileToolStripMenuItem.Size = new Size(37, 20);
            _fileToolStripMenuItem.Text = @"&File";

            _newToolStripMenuItem.Name = "newToolStripMenuItem";
            _newToolStripMenuItem.Size = new Size(134, 22);
            _newToolStripMenuItem.Text = @"&New";
            _newToolStripMenuItem.Click += newToolStripMenuItemClick;

            _openToolStripMenuItem.Name = "openToolStripMenuItem";
            _openToolStripMenuItem.Size = new Size(134, 22);
            _openToolStripMenuItem.Text = @"Open";
            _openToolStripMenuItem.Click += openToolStripMenuItemClick;

            _saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            _saveToolStripMenuItem.Size = new Size(134, 22);
            _saveToolStripMenuItem.Text = @"Save";
            _saveToolStripMenuItem.Click += saveToolStripMenuItemClick;

            _toolStripMenuItem1.Name = "toolStripMenuItem1";
            _toolStripMenuItem1.Size = new Size(131, 6);

            _exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            _exitToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.F4;
            _exitToolStripMenuItem.Size = new Size(134, 22);
            _exitToolStripMenuItem.Text = @"E&xit";
            _exitToolStripMenuItem.Click += exitToolStripMenuItemClick;

            _viewToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { _increaseGridSizeToolStripMenuItem, _decreaseGridSizeToolStripMenuItem });
            _viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            _viewToolStripMenuItem.Size = new Size(44, 20);
            _viewToolStripMenuItem.Text = @"&View";

            _increaseGridSizeToolStripMenuItem.Name = "increaseGridSizeToolStripMenuItem";
            _increaseGridSizeToolStripMenuItem.Size = new Size(169, 22);
            _increaseGridSizeToolStripMenuItem.Text = @"Increase Grid Size";
            _increaseGridSizeToolStripMenuItem.Click += increaseGridSizeToolStripMenuItemClick;

            _decreaseGridSizeToolStripMenuItem.Name = "decreaseGridSizeToolStripMenuItem";
            _decreaseGridSizeToolStripMenuItem.Size = new Size(169, 22);
            _decreaseGridSizeToolStripMenuItem.Text = @"Decrease Grid Size";
            _decreaseGridSizeToolStripMenuItem.Click += decreaseGridSizeToolStripMenuItemClick;

            _actionsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { _fillAllToolStripMenuItem, _undoToolStripMenuItem, _redoToolStripMenuItem });
            _actionsToolStripMenuItem.Name = "actionsToolStripMenuItem";
            _actionsToolStripMenuItem.Size = new Size(59, 20);
            _actionsToolStripMenuItem.Text = @"Actions";

            _fillAllToolStripMenuItem.Name = "fillAllToolStripMenuItem";
            _fillAllToolStripMenuItem.Size = new Size(152, 22);
            _fillAllToolStripMenuItem.Text = @"Fill All";
            _fillAllToolStripMenuItem.Click += fillAllToolStripMenuItemClick;

            _undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            _undoToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Z;
            _undoToolStripMenuItem.Size = new Size(152, 22);
            _undoToolStripMenuItem.Text = @"Undo";
            _undoToolStripMenuItem.Click += undoToolStripMenuItemClick;

            _redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            _redoToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Y;
            _redoToolStripMenuItem.Size = new Size(152, 22);
            _redoToolStripMenuItem.Text = @"Redo";
            _redoToolStripMenuItem.Click += redoToolStripMenuItemClick;

            return _menuStrip;
        }
    }
}