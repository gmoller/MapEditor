using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using GameLogic;
using GameLogic.Loaders;
using Point = System.Drawing.Point;

namespace WinFormsGui
{
    public partial class Form1 : Form
    {
        private const int Columns = 200; // 50
        private const int Rows = 160; // 40

        private const bool AllVisible = true;

        private GameWorld _gameWorld;
        private int _turn;
        private readonly SlidingBuffer<string> _events = new SlidingBuffer<string>(30);
        private List<string> _texts;

        private Map _map;
        private Panel _panelStatusBar;
        private Panel _panelEventsBar;

        private readonly Stopwatch _stopwatch = new Stopwatch();
        private Images _images;

        private bool _showGrid = true;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Load stuff
            List<TerrainType> terrainTypes = TerrainTypesLoader.GetTerrainTypes();
            List<UnitType> unitTypes = UnitTypesLoader.GetUnitTypes();

            _texts = new List<string>();
            foreach (TerrainType terrainType in terrainTypes)
            {
                string text = $"{terrainType.Id} - {terrainType.Name}";
                _texts.Add(text);
            }

            _images = new Images();

            // Create gameboard
            //GameBoard testMap = GameBoardLoader.Load("Map.txt");
            GameBoard testMap = GameBoardGenerator.Generate(Columns, Rows, AllVisible);
            _gameWorld = GameWorld.Create(testMap, terrainTypes, unitTypes);

            // Add unit
            _gameWorld.AddUnitForPlayer(4, GameLogic.Point.Create(0, 159), _gameWorld); // 2;3

            // Start timer
            timer1.Interval = 1;
            timer1.Start();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            int margin = 5;

            int width = ClientRectangle.Width - 200 - margin * 4;
            int height = ClientRectangle.Height - margin * 2;

            Graphics graphics = CreateGraphics();
            _map = new Map(graphics, margin, margin, width, height, Color.Black, _gameWorld, _images);

            width = 100;
            _panelStatusBar = new Panel(graphics, ClientRectangle.Width - width - margin, 0 + margin, width, height, Color.LightBlue);

            width = 100;
            _panelEventsBar = new Panel(graphics, ClientRectangle.Width - width - margin - 100 - margin, 0 + margin, width, height, Color.LightGray); // 100 is width of statusbar
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;

            _stopwatch.Restart();
            //string result = _gameWorld.DoTurnForPlayer();
            //_gameWorld.EndTurnForPlayer();
            //_turn++;
            _stopwatch.Stop();

            //_events.Add($"Turn {_turn + 1}: {result}");
            _events.Add($"Time taken: {_stopwatch.ElapsedMilliseconds} ms.");

            RenderScreen();

            timer1.Enabled = true;
        }

        private void Tick()
        {
            // if state 
            // if state is <all moves done> do nothing
            // if state is <end of turn pressed> do next turn
        }

        private void RenderScreen()
        {
            _stopwatch.Restart();

            ClearScreen();
            DrawStatusBar();
            DrawEventsBar();
            DrawBoard();
            DrawUnits();

            FlipBuffer();
            _stopwatch.Stop();

            Text = $@"Time taken: {_stopwatch.ElapsedMilliseconds} ms.";
        }

        private void ClearScreen()
        {
            _map.Clear();
            _panelEventsBar.Clear();
            _panelStatusBar.Clear();
        }

        private void DrawStatusBar()
        {
            _panelStatusBar.DrawText(new Point(0, 0), $"Turn: {_turn}", Font, Color.Red, Color.Transparent, Color.Blue);

            int y = 35;
            foreach (string item in _texts)
            {
                _panelStatusBar.DrawText(new Point(0, y), item, Font, Color.AliceBlue, Color.Transparent, Color.Transparent);
                y += 15;
            }

            y += 15;

            // unit status
            Unit unit = _gameWorld.SelectedUnit;
            if (unit.UnitType == -1)
            {
                _panelStatusBar.DrawText(new Point(0, y), "Next Turn", Font, Color.Green, Color.Transparent, Color.Transparent);
            }
            else
            {
                _panelStatusBar.DrawText(new Point(0, y), $"Unit: {unit.UnitTypeName}", Font, Color.Green, Color.Transparent, Color.Transparent);
                y += 15;
                _panelStatusBar.DrawText(new Point(0, y), $"Moves: {unit.MovementPoints}", Font, Color.Green, Color.Transparent, Color.Transparent);
            }
        }

        private void DrawEventsBar()
        {
            List<string> events = new List<string>(30);
            foreach (string item in _events)
            {
                events.Add(item);
            }
            events.Reverse();

            int y = 0;
            foreach (string item in events)
            {
                _panelEventsBar.DrawText(new Point(0, y), item, Font, Color.White, Color.Transparent, Color.Transparent);
                y += 15;
            }
        }

        private void DrawBoard()
        {
            _map.DrawBoard(_showGrid);
        }

        private void DrawUnits()
        {
            _map.DrawUnits(Font);
        }

        private void FlipBuffer()
        {
            _map.FlipBuffer();
            _panelEventsBar.FlipBuffer();
            _panelStatusBar.FlipBuffer();
        }

        // TODO: do not allow a moved unit to move outside the view window (the window must scroll by one)

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                Close();
                return true;
            }

            if (keyData == Keys.F1)
            {
                _showGrid = !_showGrid;
                return true;
            }

            if (keyData == Keys.NumPad1)
            {
                _gameWorld.KeyPressed(Key.NumPad1);
                return true;
            }

            if (keyData == Keys.NumPad2 || keyData == Keys.Down)
            {
                _gameWorld.KeyPressed(Key.NumPad2);
                return true;
            }

            if (keyData == Keys.NumPad3)
            {
                _gameWorld.KeyPressed(Key.NumPad3);
                return true;
            }

            if (keyData == Keys.NumPad4 || keyData == Keys.Left)
            {
                _gameWorld.KeyPressed(Key.NumPad4);
                return true;
            }

            if (keyData == Keys.NumPad6 || keyData == Keys.Right)
            {
                Action centerOnSelectedUnitAction = CenterOnCell;
                _gameWorld.KeyPressed(Key.NumPad6, centerOnSelectedUnitAction);
                return true;
            }

            if (keyData == Keys.NumPad7)
            {
                _gameWorld.KeyPressed(Key.NumPad7);
                return true;
            }

            if (keyData == Keys.NumPad8 || keyData == Keys.Up)
            {
                _gameWorld.KeyPressed(Key.NumPad8);
                return true;
            }

            if (keyData == Keys.NumPad9)
            {
                _gameWorld.KeyPressed(Key.NumPad9);
                return true;
            }

            if (keyData == Keys.Enter)
            {
                _gameWorld.KeyPressed(Key.Enter);
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void CenterOnCell()
        {
            Point cell = new Point(_gameWorld.SelectedUnit.Location.X, (Rows - 1) - _gameWorld.SelectedUnit.Location.Y);
            _map.CenterOnCell(cell);
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // did we click on the map?
                if (e.Location.X < 5 || e.Location.X > _map.Width + 5) return; // clicked off the map
                if (e.Location.Y < 5 || e.Location.Y > _map.Height + 5) return; // clicked off the map

                // figure out screen cell
                int screenColumn = (e.Location.X - 5) / 20;
                int screenRow = (e.Location.Y - 5) / 20;

                // convert to world cell
                Point viewCell = new Point(screenColumn, screenRow);
                Point worldCell = _map.ConvertViewToWorld(viewCell);

                // and finally center
                _map.CenterOnCell(worldCell);
            }
        }
    }

    public class Images
    {
        private readonly Dictionary<int, Image> _dictionary;

        public Images()
        {
            _dictionary = new Dictionary<int, Image>();

            AddImage(0, "00-plains_1.png");
            AddImage(1, "01-conifer_forest_inner.png");
            AddImage(6, "06-hills_inner_1.png");
            AddImage(7, "07-mountains_inner.png");
            AddImage(11, "11-ocean_inner.png");
        }

        private void AddImage(int index, string filename)
        {
            Image image = Image.FromFile($"Images/{filename}");
            _dictionary.Add(index, image);
        }

        internal Image GetImage(int imageId)
        {
            return _dictionary[imageId];
        }

        internal Rectangle GetImageSize()
        {
            return new Rectangle(0, 0, 64, 64);
        }
    }
}