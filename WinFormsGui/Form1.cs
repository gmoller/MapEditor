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
        private const int CellWidth = 40;
        private const int CellHeight = 40;

        private GameWorld _gameWorld;
        private int _turn;
        private List<string> _events = new List<string>();

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

            // Create map
            _gameWorld = GameWorld.Create(5, 5, new[] {
                0, 1, 2, 3, 4,
                5, 6, 7, 8, 9,
                0, 0, 0, 0, 0,
                0, 0, 0, 0, 0,
                0, 0, 0, 0, 0}, terrainTypes, unitTypes);

            // Add unit
            _gameWorld.Player.AddUnit(4, GameLogic.Point.Create(0, 0), _gameWorld);

            // Start timer
            timer1.Start();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            BufferedGraphicsContext currentContext = BufferedGraphicsManager.Current;
            _bufferedGraphics = currentContext.Allocate(CreateGraphics(), DisplayRectangle);
            _graphicsBuffer = _bufferedGraphics.Graphics;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            _events.Add(_gameWorld.Player.DoTurn());
            _gameWorld.Player.EndTurn();
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
            const int margin = 5;
            const int width = 100;

            int x = ClientRectangle.Width - width - margin;
            int y = 0 + margin;
            int height = ClientRectangle.Height - margin * 2;

            _graphicsBuffer.FillRectangle(new Rectangle(x, y, width, height), Color.LightBlue);

            // turns
            _graphicsBuffer.DrawText(new Rectangle(x, y, width-1, 13), $"Turn: {_turn}", Font, Color.Red, Color.Transparent, Color.Blue);

            // key
            y += 30;
            for (int i = 0; i < _gameWorld.TerrainTypes.Count; ++i)
            {
                TerrainType terrainType = _gameWorld.TerrainTypes[i];
                string text = $"{terrainType.Id} - {terrainType.Name}";
                _graphicsBuffer.DrawText(new Point(x, y), text, Font, Color.AliceBlue, Color.Transparent, Color.Transparent);
                y += 15;
            }
        }

        private void DrawEventsBar()
        {
            const int margin = 5;
            const int height = 200;

            int x =  0 + margin;
            int y = ClientRectangle.Height - height - margin;
            int width = ClientRectangle.Width - margin * 2 - 100 - margin;

            _graphicsBuffer.FillRectangle(new Rectangle(x, y, width, height), Color.LightGray);

            foreach (string item in _events)
            {
                _graphicsBuffer.DrawText(new Point(x, y), item, Font, Color.White, Color.Transparent, Color.Transparent);
                y += 15;
            }
        }

        private void DrawBoard()
        {
            int x = 0;
            int y = 0;
            for (int rowIndex = _gameWorld.Board.NumberOfRows - 1; rowIndex >= 0; --rowIndex)
            {
                for (int colIndex = 0; colIndex < _gameWorld.Board.NumberOfColumns; ++colIndex)
                {
                    var rectangle = new Rectangle(x, y, CellWidth, CellHeight);
                    _graphicsBuffer.DrawRectangle(rectangle, Color.LightBlue);
                    _graphicsBuffer.DrawText(rectangle, $"{colIndex};{rowIndex}", Font, Color.Chartreuse, Color.Transparent, Color.Transparent, TextFormatFlags.Right);

                    Cell cell = _gameWorld.Board.GetCell(GameLogic.Point.Create(colIndex, rowIndex));
                    _graphicsBuffer.DrawText(rectangle, $"{cell.TerrainTypeId}", Font, Color.BlueViolet, Color.Transparent, Color.Transparent, TextFormatFlags.Left | TextFormatFlags.Bottom);

                    x += CellWidth;
                }

                y += CellHeight;
                x = 0;
            }
        }

        private void DrawUnits()
        {
            foreach (Unit item in _gameWorld.Player.Units)
            {
                int x = item.Location.X * CellWidth;
                int y = CellWidth * (_gameWorld.Board.NumberOfRows - 1) - item.Location.Y * CellHeight;
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