using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using GameData;
using GameLogic;
using GameMap;
using GeneralUtilities;

namespace WinFormsGui
{
    public partial class Form1 : Form
    {
        private new const int Margin = 5;
        private const int Columns = 60; // 200
        private const int Rows = 40; // 160

        private const bool AllVisible = true;

        private int _turn;
        private readonly SlidingBuffer<string> _events = new SlidingBuffer<string>(30);
        private List<string> _texts;

        private Map _mapWindow;
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

            _texts = new List<string>();
            foreach (TerrainType terrainType in terrainTypes)
            {
                string text = $"{terrainType.Id} - {terrainType.Name}";
                _texts.Add(text);
            }

            _images = new Images();

            // Create gameboard
            //int[,] terrain = MapLoader.Load("Map.txt");
            int[,] terrain = MapGenerator.Generate(Columns, Rows);
            GameBoard testMap = GameBoard.Create(1, terrain, AllVisible);

            Globals.Instance.GameWorld.SetGameBoard(testMap);

            var player = new Player();
            player.TurnEnded += Player_TurnEnded;
            var player2 = new Player2();
            player2.UnitMoved += Player2_UnitMoved;
            player2.AddUnit(0, Point2.Create(1, 0)); // 50,30
            player2.AddUnit(0, Point2.Create(2, 0));

            Globals.Instance.GameWorld.SetPlayer(player);
            Globals.Instance.GameWorld.SetPlayer2(player2);

            // Add unit
            Globals.Instance.GameWorld.AddUnitForPlayer(4, Point2.Create(0, 0));

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
            Resize2();
        }

        private void Resize2()
        {
            int width = ClientRectangle.Width - 200 - Margin * 4;
            int height = ClientRectangle.Height - Margin * 2;

            Graphics graphics = CreateGraphics();
            _mapWindow = new Map(graphics, Margin, Margin, 32 * Map.CellWidth, 28 * Map.CellHeight, Color.Black, Globals.Instance.GameWorld, _images); // TODO: fix hard-coding

            width = 100;
            _panelStatusBar = new Panel(graphics, ClientRectangle.Width - width - Margin, 0 + Margin, width, height, Color.LightBlue);

            width = 100;
            _panelEventsBar = new Panel(graphics, ClientRectangle.Width - width - Margin - 100 - Margin, 0 + Margin, width, height, Color.LightGray); // 100 is width of statusbar
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
            _mapWindow.Clear();
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
            Unit unit = Globals.Instance.GameWorld.SelectedUnit;
            if (unit.UnitType == -1)
            {
                _panelStatusBar.DrawText(new Point(0, y), "Next Turn", Font, Color.Green, Color.Transparent, Color.Transparent);
            }
            else
            {
                _panelStatusBar.DrawText(new Point(0, y), $"Unit: {unit.UnitTypeName}", Font, Color.Green, Color.Transparent, Color.Transparent);
                y += 15;
                _panelStatusBar.DrawText(new Point(0, y), $"Moves: {unit.MovementPoints}", Font, Color.Green, Color.Transparent, Color.Transparent);
                y += 15;
                _panelStatusBar.DrawText(new Point(0, y), $"Loc: {unit.Location}", Font, Color.Green, Color.Transparent, Color.Transparent);
            }

            _panelStatusBar.DrawText(new Point(0, 500), $"MLoc: {_panelStatusBar.Location}", Font, Color.Blue, Color.Transparent, Color.Transparent);
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
            _mapWindow.DrawBoard(_showGrid);
        }

        private void DrawUnits()
        {
            _mapWindow.DrawUnits(Font);
        }

        private void FlipBuffer()
        {
            _mapWindow.FlipBuffer();
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

            if (keyData == Keys.NumPad1 || keyData == Keys.End) // SW
            {
                Globals.Instance.GameWorld.KeyPressed(Key.NumPad1);
                return true;
            }

            if (keyData == Keys.NumPad2 || keyData == Keys.Down) // S
            {
                Globals.Instance.GameWorld.KeyPressed(Key.NumPad2);
                return true;
            }

            if (keyData == Keys.NumPad3  || keyData == Keys.PageDown) // SE
            {
                Globals.Instance.GameWorld.KeyPressed(Key.NumPad3);
                return true;
            }

            if (keyData == Keys.NumPad4 || keyData == Keys.Left) // W
            {
                Globals.Instance.GameWorld.KeyPressed(Key.NumPad4);
                return true;
            }

            if (keyData == Keys.NumPad6 || keyData == Keys.Right) // E
            {
                Action centerOnSelectedUnitAction = CenterOnSelectedUnitCell;
                Globals.Instance.GameWorld.KeyPressed(Key.NumPad6, centerOnSelectedUnitAction);
                return true;
            }

            if (keyData == Keys.NumPad7 || keyData == Keys.Home) // NW
            {
                Globals.Instance.GameWorld.KeyPressed(Key.NumPad7);
                return true;
            }

            if (keyData == Keys.NumPad8 || keyData == Keys.Up) // N
            {
                Globals.Instance.GameWorld.KeyPressed(Key.NumPad8);
                return true;
            }

            if (keyData == Keys.NumPad9 || keyData == Keys.PageUp)
            {
                Globals.Instance.GameWorld.KeyPressed(Key.NumPad9); // NE
                return true;
            }

            if (keyData == Keys.Enter)
            {
                Globals.Instance.GameWorld.KeyPressed(Key.Enter);
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void Player_TurnEnded(object sender, EventArgs e)
        {
            Globals.Instance.GameWorld.DoTurnForPlayer2();
            Globals.Instance.GameWorld.EndTurnForPlayer2();
            _turn++;
        }

        private void Player2_UnitMoved(object sender, UnitMovedEventArgs e)
        {
            _mapWindow.DrawUnit(e.Unit, "#", Font);
            _mapWindow.FlipBuffer();
        }

        private void CenterOnSelectedUnitCell()
        {
            Point cell = new Point(Globals.Instance.GameWorld.SelectedUnit.Location.X, Globals.Instance.GameWorld.SelectedUnit.Location.Y);
            _mapWindow.CenterOnCell(cell);
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Point? worldCell = GetWorldCell(e.Location);

                if (worldCell != null)
                {
                    _mapWindow.CenterOnCell(worldCell.GetValueOrDefault());
                }
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            Point? worldCell = GetWorldCell(e.Location);

            if (_panelStatusBar != null)
            {
                _panelStatusBar.Location = worldCell;
            }
        }

        private Point? GetWorldCell(Point location)
        {
            if (_mapWindow == null) return null;

            // are we are on the map?
            if (location.X < Margin || location.X > _mapWindow.Width + Margin) return null;
            if (location.Y < Margin || location.Y > _mapWindow.Height + Margin) return null;

            // figure out screen cell
            int screenColumn = (location.X - Margin) / Map.CellWidth;
            int screenRow = (location.Y - Margin) / Map.CellHeight;

            // convert to world cell
            Point viewCell = new Point(screenColumn, screenRow);
            Point worldCell = _mapWindow.ConvertViewToWorld(viewCell);

            return worldCell;
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