using System.IO;

namespace GameLogic
{
    public static class GameBoardLoader
    {
        public static GameBoard Load(string filename)
        {
            byte[] bytes = File.ReadAllBytes(filename);
            var gameBoard = new GameBoard(0, 0, 0);
            gameBoard.SetState(bytes);

            return gameBoard;
        }

        public static GameBoard Load(int numberOfColumns, int numberOfRows)
        {
            var gameBoard = new GameBoard(1, numberOfColumns, numberOfRows);

            return gameBoard;
        }
    }
}