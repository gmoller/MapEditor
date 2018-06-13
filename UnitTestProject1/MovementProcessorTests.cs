using System;
using System.Collections.Generic;
using System.Diagnostics;
using GameLogic;
using GameLogic.NewLocationCalculators;
using GameLogic.Processors;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class MovementProcessorTests
    {
        private static readonly List<TerrainType> TerrainTypeList = new List<TerrainType>
            {
                TerrainType.Create(0, "Grassland", 1),
                TerrainType.Create(1, "Forest", 2),
                TerrainType.Create(2, "Desert", 1),
                TerrainType.Create(3, "Swamp", 3),
                TerrainType.Create(4, "River", 2),
                TerrainType.Create(5, "River Mouth", 2),
                TerrainType.Create(6, "Hills", 3),
                TerrainType.Create(7, "Mountain", 4),
                TerrainType.Create(8, "Volcano", 4),
                TerrainType.Create(9, "Tundra", 2),
                TerrainType.Create(10, "Shore", -1),
                TerrainType.Create(11, "Ocean", -1)
            };

        private static GameWorld _gameWorld;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            _gameWorld = GameWorld.Create(3, 3, new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, TerrainTypeList);
        }

        [TestMethod]
        public void Unit_can_move_east()
        {
            var movementProcessor = new MovementProcessor(_gameWorld);

            INewLocationCalculator newLocationCalculator = NewLocationCalculatorFactory.GetNewLocationCalculator(CompassDirection.East);

            Stopwatch sw = Stopwatch.StartNew();
            ProcessResponse response = movementProcessor.Process(new ProcessRequest { Location = Point.Empty, MovementPoints = 2.0f }, newLocationCalculator);
            sw.Stop();
            Console.WriteLine($"Time taken: {sw.ElapsedMilliseconds} ms");

            Unit unit = Unit.Create(response.NewLocation, response.NewMovementPoints);

            Assert.AreEqual(Point.Create(1, 0), unit.Location);
            Assert.AreEqual(1.0f, unit.MovementPoints);
        }

        [TestMethod]
        public void Multiple_units_can_move_east_single_threaded()
        {
            var movementProcessor = new MovementProcessor(_gameWorld);

            INewLocationCalculator newLocationCalculator = NewLocationCalculatorFactory.GetNewLocationCalculator(CompassDirection.East);

            const int repetitions = 1000;

            Stopwatch sw = Stopwatch.StartNew();
            for (int i = 0; i < repetitions; i++)
            {
                ProcessResponse response =
                    movementProcessor.Process(new ProcessRequest { Location = Point.Empty, MovementPoints = 2.0f },
                        newLocationCalculator);
            }
            sw.Stop();

            Console.WriteLine($"Time taken: {sw.ElapsedMilliseconds} ms for {repetitions}.");
        }

        [TestMethod]
        public void Unit_can_move_east_in_parallel()
        {
            var movementProcessor = new MovementProcessor(_gameWorld);

            INewLocationCalculator newLocationCalculator = NewLocationCalculatorFactory.GetNewLocationCalculator(CompassDirection.East);

            ProcessRequest[] requests = { new ProcessRequest { Location = Point.Empty, MovementPoints = 2.0f } };

            Stopwatch sw = Stopwatch.StartNew();
            ProcessResponse[] response = movementProcessor.Process(requests, newLocationCalculator);
            sw.Stop();
            Console.WriteLine($"Time taken: {sw.ElapsedMilliseconds} ms");

            Assert.AreEqual(Point.Create(1, 0), response[0].NewLocation);
            Assert.AreEqual(1.0f, response[0].NewMovementPoints);
        }

        [TestMethod]
        public void Multiple_units_can_move_east_in_parallel()
        {
            const int repetitions = 1;

            var movementProcessor = new MovementProcessor(_gameWorld);

            INewLocationCalculator newLocationCalculator = NewLocationCalculatorFactory.GetNewLocationCalculator(CompassDirection.East);

            var requests = new ProcessRequest[repetitions];

            for (int i = 0; i < repetitions; i++)
            {
                requests[i] = new ProcessRequest { Location = Point.Empty, MovementPoints = 2.0f + i };
            }

            Stopwatch sw = Stopwatch.StartNew();
            ProcessResponse[] response = movementProcessor.Process(requests, newLocationCalculator);
            sw.Stop();
            Console.WriteLine($"Time taken: {sw.ElapsedMilliseconds} ms");

            int cnt = 0;
            foreach (ProcessResponse item in response)
            {
                Assert.AreEqual(1.0f + cnt, item.NewMovementPoints);
                cnt++;
            }
        }
    }
}