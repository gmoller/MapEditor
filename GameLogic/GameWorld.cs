using System;
using System.Collections.Generic;
using GameLogic.Processors;
using GameMap;
using GeneralUtilities;

namespace GameLogic
{
    /// <summary>
    /// Contains accessors to the GameBoard, list of TerrainTypes and list of UnitTypes.
    /// This class is immutable.
    /// </summary>
    public class GameWorld
    {
        private Player _player;
        private Player2 _player2;

        public MovementProcessor MovementProcessor { get; }
        public GameBoard GameBoard { get; private set; }
        public IEnumerable<Unit> PlayerUnits => _player.Units;
        public IEnumerable<Unit> Player2Units => _player2.Units;
        public Unit SelectedUnit => _player.SelectedUnit;
        public int NumberOfColumns => GameBoard.NumberOfColumns;
        public int NumberOfRows => GameBoard.NumberOfRows;

        private GameWorld()
        {
            MovementProcessor = new MovementProcessor(this);
        }

        public static GameWorld Create()
        {
            return new GameWorld();
        }

        public void SetGameBoard(GameBoard gameBoard)
        {
            GameBoard = gameBoard;
        }

        public void SetPlayer(Player player)
        {
            _player = player;
        }

        public void SetPlayer2(Player2 player2)
        {
            _player2 = player2;
        }

        public void KeyPressed(Key key, Action centerOnSelectedUnitAction = null)
        {
            _player.KeyPressed(key, centerOnSelectedUnitAction);
        }

        public void DoTurnForPlayer2()
        {
            _player2.DoTurn();
        }

        public void EndTurnForPlayer2()
        {
            _player2.EndTurn();
        }

        public void AddUnitForPlayer(int unitType, Point2 startLocation)
        {
            _player.AddUnit(unitType, startLocation);
        }

        public Cell GetCell(Point2 location)
        {
            return GameBoard.GetCell(location);
        }

        internal List<Point2> GetCellNeighbors(Point2 location)
        {
            return GameBoard.GetCellNeighbors(location);
        }

        public bool IsCellVisible(Point2 location)
        {
            return GameBoard.IsCellVisible(location);
        }

        internal void SetCellVisible(Point2 location)
        {
            if (location.X < 0 || location.X > GameBoard.NumberOfColumns - 1) return; // 31
            if (location.Y < 0 || location.Y > GameBoard.NumberOfRows - 1) return; // 31

            GameBoard.SetCellVisible(location);
        }

        internal bool AreAllCellsVisible()
        {
            return GameBoard.AreAllCellsVisible();
        }

        internal void SetAllCellsInvisible()
        {
            GameBoard.SetAllCellsInvisible();
        }
    }
}