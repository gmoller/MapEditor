using System;
using System.Collections.Generic;
using GameData;
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
        private Player Player { get; }

        public GameBoard GameBoard { get; }
        public IEnumerable<Unit> PlayerUnits => Player.Units;
        public Unit SelectedUnit => Player.SelectedUnit;
        public int NumberOfColumns => GameBoard.NumberOfColumns;
        public int NumberOfRows => GameBoard.NumberOfRows;

        private GameWorld(GameBoard map)
        {
            GameBoard = map;
            Player = new Player(this);
        }

        public static GameWorld Create(GameBoard gameBoard)
        {
            return new GameWorld(gameBoard);
        }

        public void KeyPressed(Key key, Action centerOnSelectedUnitAction = null)
        {
            Player.KeyPressed(key, centerOnSelectedUnitAction);
        }

        public string DoTurnForPlayer()
        {
            return Player.DoTurn();
        }

        public void EndTurnForPlayer()
        {
            Player.EndTurn();
        }

        public void AddUnitForPlayer(int unitType, Point2 startLocation, GameWorld gameWorld)
        {
            Player.AddUnit(unitType, startLocation, gameWorld);
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