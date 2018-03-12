using System;
using System.IO;
using System.Windows.Forms;

namespace MapEditor
{
    public partial class Form1 : Form
    {
        private readonly PaletteList _palettes;
        private Palette _selectedPalette;
        private PaletteImage _selectedImage;
        private int _selectedLayer;

        private readonly Map _map;

        public Form1()
        {
            InitializeComponent();

            _selectedLayer = 0;
            _palettes = LoadPalettes();
            CreatePaletteMenus(_palettes);
            SetPalette(_palettes[0]);

            _map = new Map(2, 16, 16);
            picMap.Image = MapRenderer.Render(_map, _palettes);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private PaletteList LoadPalettes()
        {
            string[] directories = Directory.GetDirectories(@"Content\Tilesets\");

            var palettes = new PaletteList();
            byte paletteId = 0;
            foreach (string directory in directories)
            {
                string name = Path.GetFileName(directory);
                var palette = new Palette(paletteId, name, directory);

                palettes.Add(palette);
                paletteId++;
            }

            return palettes;
        }

        private void CreatePaletteMenus(PaletteList palettes)
        {
            foreach (Palette palette in palettes)
            {
                ToolStripMenuItem item = new ToolStripMenuItem(palette.Name, null, toolstrip_click);
                //item.CheckState = CheckState.Unchecked;
                palletteToolStripMenuItem.DropDownItems.Add(item);
            }
        }

        private void toolstrip_click(object sender, EventArgs e)
        {
            var menuItem = (ToolStripMenuItem) sender;
            //menuItem.CheckState = CheckState.Checked;

            SetPalette(_palettes[menuItem.Text]);
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            //var menuItem = (ToolStripMenuItem)sender;
            //menuItem.CheckState = CheckState.Checked;
            _selectedLayer = 0;
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            //var menuItem = (ToolStripMenuItem)sender;
            //menuItem.CheckState = CheckState.Checked;
            _selectedLayer = 1;
        }

        private void SetPalette(Palette palette)
        {
            lblSelectedPalette.Text = $"Palette: {palette.Name}";
            picPalette.Width = palette.Image.Width;
            picPalette.Height = palette.Image.Height;
            picPalette.Image = palette.Image;

            _selectedPalette = palette;
        }

        private void picPalette_Click(object sender, EventArgs e)
        {
        }

        private void picPalette_MouseDown(object sender, MouseEventArgs e)
        {
            MouseEventArgs mouseEventArgs = e;
            PaletteImage image = _selectedPalette.HitTest(mouseEventArgs.Location);

            picSelectedImage.Image = image?.Bitmap;
            lblSelectedImage.Text = image?.Name;

            _selectedImage = image;
        }

        private void picMap_Click(object sender, EventArgs e)
        {
            if (_selectedPalette == null) return;
            if (_selectedImage == null) return;

            // figure out which cell is clicked
            var mouseEventArgs = (MouseEventArgs)e;
            if (mouseEventArgs.X > _map.CellSize.X * _map.NumberOfColumns) return;
            if (mouseEventArgs.Y > _map.CellSize.Y * _map.NumberOfRows) return;

            int cellX = DetermineClickedCell(mouseEventArgs.X, _map.CellSize.X);
            int cellY = DetermineClickedCell(mouseEventArgs.Y, _map.CellSize.Y);

            // place selected image in that cell
            _map.SetCell(_selectedLayer, cellX, cellY, _selectedPalette.Id, _selectedImage.Id);

            // redraw the map
            picMap.Image = MapRenderer.Render(_map, _palettes);
        }

        private int DetermineClickedCell(int pos, int cellSize)
        {
            int cell = 0;
            int test = pos - cellSize;
            while (test > 0)
            {
                cell++;
                test -= cellSize;
            }

            return cell;
        }
    }
}