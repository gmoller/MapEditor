using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MapEditor.MainForm
{
    public partial class MainForm : Form
    {
        private Control _panelLeft;
        private Control _panelMiddle;
        private Control _panelRight;

        private readonly PaletteList _palettes;
        private Palette _selectedPalette;
        private PaletteImage _selectedImage;
        private int _selectedLayer;
        private Map _map;

        private Point? _mouseDownLocation;

        public MainForm()
        {
            InitializeComponent();
            InitializeControls();

            _palettes = new PaletteList();
            _palettes.Load();
            PopulatePaletteCombobox(_palettes);
        }

        private void InitializeControls()
        {
            var menu = new Menu();
            MenuStrip menuStrip = menu.Create(newToolStripMenuItem_Click, openToolStripMenuItem_Click, saveToolStripMenuItem_Click, exitToolStripMenuItem_Click, increaseGridSizeToolStripMenuItem_Click, decreaseGridSizeToolStripMenuItem_Click, fillAllToolStripMenuItem_Click, undoToolStripMenuItem_Click, redoToolStripMenuItem_Click);

            _panelLeft = new PanelLeft(this);
            Panel pnlLeft = _panelLeft.Create(new EventHandler[] { cboPalette_SelectedIndexChanged, picPalette_Click }, null);

            _panelMiddle = new PanelMiddle(this);
            Panel pnlMiddle = _panelMiddle.Create(null, new MouseEventHandler[] { picMap_MouseDown, picMap_MouseUp });

            _panelRight = new PanelRight(this);
            Panel pnlRight = _panelRight.Create(new EventHandler[] { radioButton_CheckedChanged, chkLayerVisible_CheckedChanged }, null);

            Controls.Add(pnlLeft);
            Controls.Add(pnlMiddle);
            Controls.Add(pnlRight);
            Controls.Add(menuStrip);
            MainMenuStrip = menuStrip;

            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            pnlLeft.ResumeLayout(false);
            pnlMiddle.ResumeLayout(false);
            pnlRight.ResumeLayout(false);

            Resize += MainForm_Resize;
        }

        private void PopulatePaletteCombobox(PaletteList palettes)
        {
            ComboBox cboPalette = Controls.Find("cboPalette", true).First() as ComboBox;
            if (cboPalette == null) throw new Exception("Control [cboPalette] not found on form.");

            cboPalette.Items.Clear();
            foreach (Palette palette in palettes)
            {
                cboPalette.Items.Add(palette.Name);
            }

            cboPalette.SelectedIndex = 0;
        }

        private void SetPalette(Palette palette)
        {
            PictureBox picPalette = Controls.Find("picPalette", true).First() as PictureBox;
            if (picPalette == null) throw new Exception("Control [picPalette] not found on form.");

            picPalette.Image = palette.Image;

            _selectedPalette = palette;
            SetSelectedImage(null);
        }

        private void SetSelectedImage(PaletteImage image)
        {
            PictureBox picSelectedImage = Controls.Find("picSelectedImage", true).First() as PictureBox;
            if (picSelectedImage == null) throw new Exception("Control [picSelectedImage] not found on form.");

            Label lblSelectedImage = Controls.Find("lblSelectedImage", true).First() as Label;
            if (lblSelectedImage == null) throw new Exception("Control [lblSelectedImage] not found on form.");

            picSelectedImage.Image = image?.Bitmap;
            lblSelectedImage.Text = image?.Name;
            _selectedImage = image;
        }

        private void CreateNewMap(int numberOfColumns, int numberOfRows)
        {
            PictureBox picMap = Controls.Find("picMap", true).First() as PictureBox;
            if (picMap == null) throw new Exception("Control [picMap] not found on form.");

            _selectedLayer = 0;
            _map = new Map(4, numberOfColumns, numberOfRows, 64, 64);
            _map.Layers[0].Visible = true;
            picMap.Image = MapRenderer.Render(_map, _palettes);
        }

        private int DetermineClickedCell(int pos, int cellSize)
        {
            if (pos < 0) return -1;

            int cell = pos / cellSize;

            return cell;
        }

        private void RedrawMap()
        {
            PictureBox picMap = Controls.Find("picMap", true).First() as PictureBox;
            if (picMap == null) throw new Exception("Control [picMap] not found on form.");

            picMap.Image = MapRenderer.Render(_map, _palettes);
        }

        //--------------------
        // Event Handlers
        //--------------------

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _panelLeft.Top = 100;
            _panelLeft.Enabled = false;
            _panelLeft.Resize();
            _panelMiddle.Top = 100;
            _panelMiddle.Enabled = false;
            _panelMiddle.Resize();
            _panelRight.Top = 100;
            _panelRight.Enabled = false;
            _panelRight.Resize();

            string output = "8x8";
            //DialogResult result = ShowInputDialog("Enter Map Size", ref output);

            //if (result == DialogResult.OK)
            {
                string[] test = output.Split('x');
                int numberOfColumns = Convert.ToInt32(test[0]);
                int numberOfRows = Convert.ToInt32(test[1]);
                CreateNewMap(numberOfColumns, numberOfRows);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _map = MapLoader.Load("Map.txt");
            _panelLeft.Enabled = true;
            _panelLeft.Resize();
            _panelMiddle.Enabled = true;
            _panelMiddle.Resize();
            _panelRight.Enabled = true;
            _panelRight.Resize();

            RedrawMap();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_map == null) return;

            byte[] mapState = _map.GetState();
            MapSaver.Save("Map.txt", mapState);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void increaseGridSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_map == null) return;

            _map.IncreaseCellSize();

            RedrawMap();
        }

        private void decreaseGridSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_map == null) return;

            _map.DecreaseCellSize();

            RedrawMap();
        }

        private void fillAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_map == null) return;
            if (_selectedPalette == null) return;
            if (_selectedImage == null) return;

            _map.FillBetween(_selectedLayer, _selectedPalette.Id, _selectedImage.Id, new Point(0, 0), new Point(_map.NumberOfColumns - 1, _map.NumberOfRows - 1));

            RedrawMap();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_map == null) return;

            _map.Undo();

            RedrawMap();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_map == null) return;

            _map.Redo();

            RedrawMap();
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
            int cellX = DetermineClickedCell(e.Location.X, _map.CellSize.X);
            int cellY = DetermineClickedCell(_map.NumberOfRows * _map.CellSize.Y - e.Location.Y, _map.CellSize.Y);
            _mouseDownLocation = new Point(cellX, cellY);
        }

        private void picMap_MouseUp(object sender, MouseEventArgs e)
        {
            if (_map == null) return;
            if (_mouseDownLocation == null) return;

            int cellX = DetermineClickedCell(e.X, _map.CellSize.X);
            int cellY = DetermineClickedCell(_map.NumberOfRows * _map.CellSize.Y - e.Y, _map.CellSize.Y);
            var mouseUpLocation = new Point(cellX, cellY);

            if (mouseUpLocation.X >= 0 && mouseUpLocation.X < _map.NumberOfColumns &&
                mouseUpLocation.Y >= 0 && mouseUpLocation.Y < _map.NumberOfRows)
            {
                _map.FillBetween(_selectedLayer, _selectedPalette?.Id, _selectedImage?.Id, _mouseDownLocation.Value, mouseUpLocation);

                RedrawMap();
            }

            _mouseDownLocation = null;
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            var control = (RadioButton)sender;

            if (control.Checked)
            {
                _selectedLayer = (int)control.Tag;
            }
        }

        private void chkLayerVisible_CheckedChanged(object sender, EventArgs e)
        {
            if (_map == null) return;

            var control = (CheckBox)sender;

            _map.Layers[(int)control.Tag].Visible = control.Checked;

            RedrawMap();
            // TODO: fix bug where layer visibility is out of sync on new map (if previously unchecked)
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            _panelLeft.Resize();
            _panelMiddle.Resize();
            _panelRight.Resize();
        }
    }
}