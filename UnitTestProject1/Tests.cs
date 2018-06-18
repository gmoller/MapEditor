using System;
using System.Collections.Generic;
using GameLogic;
using GameLogic.Loaders;
using GameLogic.Processors;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class Tests
    {
        private static GameWorld _gameWorld;
        private static MovementProcessor _movementProcessor;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            List<TerrainType> terrainTypes = TerrainTypesLoader.GetTerrainTypes();
            List<UnitType> unitTypes = UnitTypesLoader.GetUnitTypes();
            _gameWorld = GameWorld.Create(3, 3, new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, terrainTypes, unitTypes);
            _movementProcessor = new MovementProcessor(_gameWorld);
        }

        [TestMethod]
        public void Two_turns()
        {
            var player = new Player(_gameWorld);
            player.AddUnit(0, Point.Create(0, 0), _gameWorld);

            PrintGameBoard(_gameWorld.Board, player);

            for (int i = 0; i < 2; ++i)
            {
                player.DoTurn();
                player.EndTurn();
                PrintGameBoard(_gameWorld.Board, player);
            }
        }

        private void PrintGameBoard(GameBoard gameBoard, Player player)
        {
            for (int rowIndex = gameBoard.NumberOfRows - 1; rowIndex >= 0; --rowIndex)
            {
                PrintRow(" +", "-+");
                PrintRow2(rowIndex, player);
            }

            PrintRow(" +", "-+");
            PrintRowFinal();
            Console.WriteLine();
        }

        private void PrintRow(string s1, string s2)
        {
            Console.Write(s1);
            for (int colIndex = 0; colIndex < _gameWorld.Board.NumberOfColumns; ++colIndex)
            {
                Console.Write(s2);
            }
            Console.WriteLine();
        }

        private void PrintRow2(int rowIndex, Player player)
        {
            Console.Write($"{rowIndex}|");
            for (int colIndex = 0; colIndex < _gameWorld.Board.NumberOfColumns; ++colIndex)
            {
                string s = " ";
                if (player.UnitInCell(colIndex, rowIndex))
                {
                    s = "@";
                }

                Console.Write(s);
                Console.Write("|");
            }
            Console.WriteLine();
        }

        private void PrintRowFinal()
        {
            Console.Write("  ");
            for (int colIndex = 0; colIndex < _gameWorld.Board.NumberOfColumns; ++colIndex)
            {
                Console.Write($"{colIndex} ");
            }
            Console.WriteLine();
        }

        [TestMethod]
        public void One_turn()
        {
            List<Unit> units = CreateUnits(Point.Create(0, 1));

            // move each unit east twice
            foreach (Unit unit in units)
            {
                Unit unit2 = unit.Move(_movementProcessor, CompassDirection.East);
                Unit unit3 = unit2.Move(_movementProcessor, CompassDirection.East);

                Assert.AreEqual(Point.Create(2, 1), unit3.Location, "Location incorrect.");
                Assert.AreEqual(0, unit3.MovementPoints, "MovementPoints incorrect.");
            }

            // end turn and they all have their movement points reset
            foreach (Unit unit in units)
            {
                Unit unit2 = unit.StartNewTurn();

                Assert.AreEqual(2.0f, unit2.MovementPoints, "MovementPoints incorrect.");
            }
        }

        private List<Unit> CreateUnits(Point startLocation)
        {
            List<Unit> units = new List<Unit>();

            for (int i = 0; i < 10; ++i)
            {
                Unit unit = Unit.CreateNew(4, startLocation, _gameWorld);
                units.Add(unit);
            }

            return units;
        }
    }
}