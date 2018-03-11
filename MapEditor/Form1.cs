using System;
using System.IO;
using System.Windows.Forms;

namespace MapEditor
{
    public partial class Form1 : Form
    {
        private readonly PaletteList _palettes;

        public Form1()
        {
            InitializeComponent();

            _palettes = LoadPalettes();
            CreatePaletteMenus(_palettes);

            SetPalette(_palettes[0]);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private PaletteList LoadPalettes()
        {
            string[] directories = Directory.GetDirectories(@"Content\Tilesets\");

            var palettes = new PaletteList();
            foreach (string directory in directories)
            {
                string name = Path.GetFileName(directory);
                var palette = new Palette(name, directory);

                palettes.Add(palette);
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

        private void SetPalette(Palette palette)
        {
            lblSelectedPalette.Text = $"Palette: {palette.Name}";
            picPalette.Width = palette.Image.Width;
            picPalette.Height = palette.Image.Height;
            picPalette.Image = palette.Image;
        }

        private void picPalette_Click(object sender, EventArgs e)
        {
            var test = (MouseEventArgs) e;
            MessageBox.Show($"Hi! {test.Location}");
        }
    }
}