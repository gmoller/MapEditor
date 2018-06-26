using System.IO;

namespace GameLogic
{
    public static class GameBoardLoader
    {
        public static GameBoard Load(string filename)
        {
            byte[] bytes = File.ReadAllBytes(filename);
            GameBoard gameBoard = GameBoard.Create(0, 0, 0);
            gameBoard.SetState(bytes);

            return gameBoard;
        }

        public static GameBoard Load(int numberOfColumns, int numberOfRows)
        {
            GameBoard gameBoard = GameBoard.Create(1, numberOfColumns, numberOfRows);

            return gameBoard;
        }
    }
}