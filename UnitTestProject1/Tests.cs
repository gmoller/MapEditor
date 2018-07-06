using System.Collections.Generic;
using GameLogic;
using GameMap;
using GeneralUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class Tests
    {
        private static GameWorld _gameWorld;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            GameBoard gameBoard = GameBoard.Create(1, new int[3, 3], true);
            Globals.Instance.GameWorld.SetGameBoard(gameBoard);
            Globals.Instance.GameWorld.SetPlayer(new Player());
            Globals.Instance.GameWorld.SetPlayer2(new Player2());
        }

        [TestMethod]
        public void One_turn()
        {
            List<Unit> units = CreateUnits(Point2.Create(0, 1));

            // move each unit east twice
            foreach (Unit unit in units)
            {
                //Unit unit2 = unit.Move(_movementProcessor, CompassDirection.East);
                //Unit unit3 = unit2.Move(_movementProcessor, CompassDirection.East);

                //Assert.AreEqual(Point2.Create(2, 1), unit3.Location, "Location incorrect.");
                //Assert.AreEqual(0, unit3.MovementPoints, "MovementPoints incorrect.");
            }

            // end turn and they all have their movement points reset
            foreach (Unit unit in units)
            {
                Unit unit2 = unit.StartNewTurn();

                Assert.AreEqual(2.0f, unit2.MovementPoints, "MovementPoints incorrect.");
            }
        }

        private List<Unit> CreateUnits(Point2 startLocation)
        {
            List<Unit> units = new List<Unit>();

            for (int i = 0; i < 10; ++i)
            {
                Unit unit = Unit.CreateNew(4, startLocation);
                units.Add(unit);
            }

            return units;
        }
    }
}