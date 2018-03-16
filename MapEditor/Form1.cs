using System;
using System.Drawing;
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

        private Map _map;

        private Point _mouseDownLocation = new Point(-1, -1);

        public Form1()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            MaximizeBox = false;
            pnlMiddle.Size = new Size(1596, 939);
            picMap.Size = new Size(1594, 937);

            _palettes = LoadPalettes();
            CreatePaletteCheckbox(_palettes);
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

        private void CreatePaletteCheckbox(PaletteList palettes)
        {
            cboPalette.Items.Clear();
            foreach (Palette palette in palettes)
            {
                cboPalette.Items.Add(palette.Name);
            }

            cboPalette.SelectedIndex = 0;
        }

        private void CreateNewMap(int numberOfColumns, int numberOfRows)
        {
            _selectedLayer = 0;
            _map = new Map(1, numberOfColumns, numberOfRows, 64, 64);
            _map.Layers[0].Visible = true;
            SetLayers();
            picMap.Image = MapRenderer.Render(_map, _palettes);
        }

        private void SetLayers()
        {
            lvwLayers.Items.Clear();

            int cnt = 1;
            foreach (Layer layer in _map.Layers)
            {
                ListViewItem item = lvwLayers.Items.Add($"{cnt}");
                item.Checked = layer.Visible;
                cnt++;
            }
        }

        private void SetPalette(Palette palette)
        {
            picPalette.Width = palette.Image.Width;
            picPalette.Height = palette.Image.Height;
            picPalette.Image = palette.Image;

            _selectedPalette = palette;
            SetSelectedImage(null);
        }

        private int DetermineClickedCell(int pos, int cellSize)
        {
            int cell = pos / cellSize;

            return cell;
        }

        private void SetSelectedImage(PaletteImage image)
        {
            picSelectedImage.Image = image?.Bitmap;
            lblSelectedImage.Text = image?.Name;
            _selectedImage = image;
        }

        private void cboPalette_SelectedIndexChanged(object sender, EventArgs e)
        {
            var control = (ComboBox)sender;
            SetPalette(_palettes[control.Text]);
        }

        private void picPalette_Click(object sender, EventArgs e)
        {
            var mouseEventArgs = (MouseEventArgs)e;
            PaletteImage image = _selectedPalette.HitTest(mouseEventArgs.Location);
            SetSelectedImage(image);
        }

        private void picMap_MouseDown(object sender, MouseEventArgs e)
        {
            if (_map == null) return;

            // store location
            _mouseDownLocation = e.Location;
        }

        private void picMap_MouseUp(object sender, MouseEventArgs e)
        {
            if (_map == null) return;

            int mouseEndCellX = DetermineClickedCell(e.X, _map.CellSize.X);
            int mouseEndCellY = DetermineClickedCell(_map.NumberOfRows * _map.CellSize.Y - e.Y, _map.CellSize.Y);

            int mouseStartCellX = DetermineClickedCell(_mouseDownLocation.X, _map.CellSize.X);
            int mouseStartCellY = DetermineClickedCell(_map.NumberOfRows * _map.CellSize.Y - _mouseDownLocation.Y, _map.CellSize.Y);

            CellPainter cellPainter = CellPainterFactory.GetCellPainter(new Point(mouseStartCellX, mouseStartCellY), new Point(mouseEndCellX, mouseEndCellY));
            cellPainter.Paint(_selectedLayer, _selectedPalette?.Id, _selectedImage?.Id, _map);

            // redraw the map
            picMap.Image = MapRenderer.Render(_map, _palettes);
        }

        private void radLayer0_CheckedChanged(object sender, EventArgs e)
        {
            _selectedLayer = 0;
        }

        private void radLayer1_CheckedChanged(object sender, EventArgs e)
        {
            _selectedLayer = 1;
        }

        private void chkLayer0_CheckedChanged(object sender, EventArgs e)
        {
            if (_map == null) return;

            var control = (CheckBox) sender;
            _map.Layers[0].Visible = control.Checked;
            picMap.Image = MapRenderer.Render(_map, _palettes);
        }

        private void chkLayer1_CheckedChanged(object sender, EventArgs e)
        {
            if (_map == null) return;

            var control = (CheckBox)sender;
            _map.Layers[1].Visible = control.Checked;
            picMap.Image = MapRenderer.Render(_map, _palettes);
        }

        private void increaseGridSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_map == null) return;

            _map.IncreaseCellSize();
            picMap.Image = MapRenderer.Render(_map, _palettes);
        }

        private void decreaseGridSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_map == null) return;

            _map.DecreaseCellSize();
            picMap.Image = MapRenderer.Render(_map, _palettes);
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string output = "32x32";
            DialogResult result = ShowInputDialog("Enter Map Size", ref output);

            if (result == DialogResult.OK)
            {
                string[] test = output.Split('x');
                int numberOfColumns = Convert.ToInt32(test[0]);
                int numberOfRows = Convert.ToInt32(test[1]);
                CreateNewMap(numberOfColumns, numberOfRows);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _map = MapLoader.Load();
            picMap.Image = MapRenderer.Render(_map, _palettes);
            SetLayers();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_map == null) return;

            byte[] mapState = _map.GetState();
            MapSaver.Save(mapState);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private static DialogResult ShowInputDialog(string caption, ref string output)
        {
            Size size = new Size(200, 70);
            Form inputBox = new Form
            {
                FormBorderStyle = FormBorderStyle.FixedToolWindow,
                ClientSize = size,
                Text = caption,
                StartPosition = FormStartPosition.CenterParent
            };


            TextBox textBox = new TextBox
            {
                Size = new Size(size.Width - 10, 23),
                Location = new Point(5, 5),
                Text = output
            };
            inputBox.Controls.Add(textBox);

            Button okButton = new Button
            {
                DialogResult = DialogResult.OK,
                Name = "okButton",
                Size = new Size(75, 23),
                Text = @"&OK",
                Location = new Point(size.Width - 80 - 80, 39)
            };
            inputBox.Controls.Add(okButton);

            Button cancelButton = new Button
            {
                DialogResult = DialogResult.Cancel,
                Name = "cancelButton",
                Size = new Size(75, 23),
                Text = @"&Cancel",
                Location = new Point(size.Width - 80, 39)
            };
            inputBox.Controls.Add(cancelButton);

            inputBox.AcceptButton = okButton;
            inputBox.CancelButton = cancelButton;

            DialogResult result = inputBox.ShowDialog();
            output = textBox.Text;

            return result;
        }

        private void fillAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_map == null) return;
            if (_selectedPalette == null) return;
            if (_selectedImage == null) return;

            for (int i = 0; i < _map.NumberOfRows; ++i)
            {
                for (int j = 0; j < _map.NumberOfColumns; ++j)
                {
                    _map.SetCell(_selectedLayer, j, i, _selectedPalette.Id, _selectedImage.Id);
                }
            }

            // redraw the map
            picMap.Image = MapRenderer.Render(_map, _palettes);
        }

        private void btnAddLayer_Click(object sender, EventArgs e)
        {
            _map.AddLayer();
            SetLayers();
        }

        private void btnRemoveLayer_Click(object sender, EventArgs e)
        {

        }

        private void lvwLayers_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (lvwLayers.FocusedItem != null)
            {
                int i = Convert.ToInt32(e.Item.Text);
                _map.Layers[i - 1].Visible = e.Item.Checked;

                // redraw the map
                picMap.Image = MapRenderer.Render(_map, _palettes);
            }
        }

        private void lvwLayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwLayers.SelectedIndices.Count > 0)
            {
                _selectedLayer = lvwLayers.SelectedIndices[0];
            }
        }
    }
}