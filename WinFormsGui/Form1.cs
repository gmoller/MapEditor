using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using GameLogic;
using GameLogic.Loaders;
using Point = System.Drawing.Point;

namespace WinFormsGui
{
    public partial class Form1 : Form
    {
        private const int CellWidth = 20;
        private const int CellHeight = 20;

        private GameWorld _gameWorld;
        private int _turn;
        private readonly SlidingBuffer<string> _events = new SlidingBuffer<string>(30);
        private List<string> _texts;

        private Panel _panelStatusBar;
        private Panel _panelEventsBar;

        private BufferedGraphics _bufferedGraphics;
        private Graphics _graphicsBuffer;

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

            // Create gameboard
            GameBoard testMap = GameBoardLoader.Load("Map.txt");
            _gameWorld = GameWorld.Create(testMap, terrainTypes, unitTypes);

            // Add unit
            _gameWorld.AddUnitForPlayer(4, GameLogic.Point.Create(2, 3), _gameWorld);

            // Start timer
            timer1.Start();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            BufferedGraphicsContext currentContext = BufferedGraphicsManager.Current;
            _bufferedGraphics = currentContext.Allocate(CreateGraphics(), DisplayRectangle);
            _graphicsBuffer = _bufferedGraphics.Graphics;

            int margin = 5;
            int width = 100;
            _panelStatusBar = new Panel(_graphicsBuffer, ClientRectangle.Width - width - margin, 0 + margin, width, ClientRectangle.Height - margin * 2, Color.LightBlue);

            //int height = 200;
            //_panelEventsBar = new Panel(_graphicsBuffer, 0 + margin, ClientRectangle.Height - height - margin, ClientRectangle.Width - margin * 2 - 100 - margin, height, Color.LightGray);
            width = 400;
            _panelEventsBar = new Panel(_graphicsBuffer, ClientRectangle.Width - width - margin - 100 - margin, 0 + margin, width, ClientRectangle.Height - margin * 2, Color.LightGray); // 100 is width of statusbar
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //string result = _gameWorld.Player.DoTurn();
            string result = _gameWorld.DoTurnForPlayer();
            _events.Add($"Turn {_turn + 1}: {result}");
            _gameWorld.EndTurnForPlayer();
            RenderScreen();
        }

        private void RenderScreen()
        {
            _turn++;

            ClearScreen();
            DrawStatusBar();
            DrawEventsBar();
            DrawBoard();
            DrawUnits();

            FlipBuffer();
        }

        private void ClearScreen()
        {
            _graphicsBuffer.Clear(Color.White);
        }

        private void DrawStatusBar()
        {
            _panelStatusBar.DrawPanel();
            _panelStatusBar.DrawText(new Point(0, 0), $"Turn: {_turn}", Font, Color.Red, Color.Transparent, Color.Blue);

            int y = 35;
            foreach (string item in _texts)
            {
                _panelStatusBar.DrawText(new Point(0, y), item, Font, Color.AliceBlue, Color.Transparent, Color.Transparent);
                y += 15;
            }
        }

        private void DrawEventsBar()
        {
            _panelEventsBar.DrawPanel();

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
            int x = 0;
            int y = 0;
            for (int rowIndex = _gameWorld.GameBoard.NumberOfRows - 1; rowIndex >= 0; --rowIndex)
            {
                for (int colIndex = 0; colIndex < _gameWorld.GameBoard.NumberOfColumns; ++colIndex)
                {
                    var rectangle = new Rectangle(x, y, CellWidth, CellHeight);
                    _graphicsBuffer.DrawRectangle(rectangle, Color.LightBlue);
                    _graphicsBuffer.DrawText(rectangle, $"{colIndex};{rowIndex}", Font, Color.Chartreuse, Color.Transparent, Color.Transparent, TextFormatFlags.Right);

                    Cell cell = _gameWorld.GameBoard.GetCell(GameLogic.Point.Create(colIndex, rowIndex));
                    _graphicsBuffer.DrawText(rectangle, $"{cell.TerrainTypeId}", Font, Color.BlueViolet, Color.Transparent, Color.Transparent, TextFormatFlags.Left | TextFormatFlags.Bottom);

                    x += CellWidth;
                }

                y += CellHeight;
                x = 0;
            }
        }

        private void DrawUnits()
        {
            foreach (Unit item in _gameWorld.PlayerUnits)
            {
                int x = item.Location.X * CellWidth;
                int y = CellWidth * (_gameWorld.GameBoard.NumberOfRows - 1) - item.Location.Y * CellHeight;
                Font font = new Font(Font.FontFamily, 16.5f);
                _graphicsBuffer.DrawText(new Rectangle(x, y, CellWidth, CellHeight), "@", font, Color.Red, Color.Transparent, Color.Transparent, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }
        }

        private void FlipBuffer()
        {
            _bufferedGraphics.Render();
        }
    }
}