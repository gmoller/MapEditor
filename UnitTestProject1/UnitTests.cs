using GameLogic;
using GameLogic.Processors;
using GameMap;
using GeneralUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTests
    {
        private static GameWorld _gameWorld;
        private static MovementProcessor _movementProcessor;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            GameBoard gameBoard = GameBoard.Create(1, new int[3, 3], true);
            _gameWorld = GameWorld.Create(gameBoard);
            _movementProcessor = new MovementProcessor(_gameWorld);
        }

        [TestMethod]
        public void Unit_can_move_north()
        {
            Unit unit = CreateUnit(Point2.Create(1, 1));
            MoveUnit(unit, CompassDirection.North, Point2.Create(1, 2));
        }

        [TestMethod]
        public void Unit_can_move_northeast()
        {
            Unit unit = CreateUnit(Point2.Create(1, 1));
            MoveUnit(unit, CompassDirection.NorthEast, Point2.Create(2, 2));
        }

        [TestMethod]
        public void Unit_can_move_east()
        {
            Unit unit = CreateUnit(Point2.Create(1, 1));
            MoveUnit(unit, CompassDirection.East, Point2.Create(2, 1));
        }

        [TestMethod]
        public void Unit_can_move_southeast()
        {
            Unit unit = CreateUnit(Point2.Create(1, 1));
            MoveUnit(unit, CompassDirection.SouthEast, Point2.Create(2, 0));
        }

        [TestMethod]
        public void Unit_can_move_south()
        {
            Unit unit = CreateUnit(Point2.Create(1, 1));
            MoveUnit(unit, CompassDirection.South, Point2.Create(1, 0));
        }

        [TestMethod]
        public void Unit_can_move_southwest()
        {
            Unit unit = CreateUnit(Point2.Create(1, 1));
            MoveUnit(unit, CompassDirection.SouthWest, Point2.Create(0, 0));
        }

        [TestMethod]
        public void Unit_can_move_west()
        {
            Unit unit = CreateUnit(Point2.Create(1, 1));
            MoveUnit(unit, CompassDirection.West, Point2.Create(0, 1));
        }

        [TestMethod]
        public void Unit_can_not_move_west()
        {
            Unit unit = CreateUnit(Point2.Create(0, 0));
            MoveUnit(unit, CompassDirection.West, Point2.Create(0, 0), 2.0f);
        }

        [TestMethod]
        public void Unit_can_move_northwest()
        {
            Unit unit = CreateUnit(Point2.Create(1, 1));
            MoveUnit(unit, CompassDirection.NorthWest, Point2.Create(0, 2));
        }

        [TestMethod]
        public void Unit_can_move_east_twice_in_one_turn()
        {
            Unit unit = CreateUnit(Point2.Empty);
            unit = MoveUnit(unit, CompassDirection.East, Point2.Create(1, 0));
            MoveUnit(unit, CompassDirection.East, Point2.Create(2, 0), 0.0f);
        }

        [TestMethod]
        public void Unit_can_not_move_east_three_times_in_one_turn()
        {
            Unit unit = CreateUnit(Point2.Empty);
            unit = MoveUnit(unit, CompassDirection.East, Point2.Create(1, 0));
            unit = MoveUnit(unit, CompassDirection.East, Point2.Create(2, 0), 0.0f);
            MoveUnit(unit, CompassDirection.East, Point2.Create(2, 0), 0.0f);
        }

        private Unit CreateUnit(Point2 startLocation)
        {
            var unit = Unit.CreateNew(4, startLocation, _gameWorld);

            return unit;
        }

        private Unit MoveUnit(Unit unit, CompassDirection compassDirection, Point2 expectedLocation, float expectedMovementPoints = 1.0f)
        {
            //unit = unit.Move(_movementProcessor, compassDirection);

            Assert.AreEqual(expectedLocation, unit.Location, "Location incorrect.");
            Assert.AreEqual(expectedLocation.X, unit.Location.X, "Location.X incorrect.");
            Assert.AreEqual(expectedLocation.Y, unit.Location.Y, "Location.Y inocrrect.");
            Assert.AreEqual(expectedMovementPoints, unit.MovementPoints, "MovementPoints incorrect.");

            return unit;
        }
    }
}