using board;
using chess;
using chess_console.chess;

namespace chess_console
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ChessGame chessGame = new ChessGame();

                while (!chessGame.finished)
                {
                    Console.Clear();
                    Screen.PrintBoard(chessGame.board);

                    Console.WriteLine();
                    Console.Write("Origin: ");
                    Position origin = Screen.ChessPositionFromInput().toPosition();
                    Console.Write("Destiny: ");
                    Position destiny = Screen.ChessPositionFromInput().toPosition();

                    chessGame.executeMovement(origin, destiny);
                }
            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }
                

            Console.ReadLine();
        }
    }
}