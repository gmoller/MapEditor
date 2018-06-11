using System;
using GameLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class GameBoardTests
    {
        [TestMethod]
        public void GameBoard_created_ok()
        {
            for (int x = 1; x < 5; ++x)
            {
                for (int y = 1; y < 5; ++y)
                {
                    TestBoard(x, y);
                }
            }
        }

        private void TestBoard(int cols, int rows)
        {
            Console.WriteLine($"Cols: {cols}, Rows: {rows}");
            Console.WriteLine("-----");

            var board = GameBoard.Create(cols, rows, new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 });

            for (int i = 0; i < cols * rows; ++i)
            {
                int x = i % cols;
                int y = i / cols;
                Point point = Point.Create(x, y);
                Cell cell = board.GetCell(point);
                Assert.AreEqual(cell.TerrainTypeId, i);
            }

            Console.WriteLine();
        }
    }
}