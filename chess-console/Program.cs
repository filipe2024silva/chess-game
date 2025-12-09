using board;
using chess_console.chess;

namespace chess_console
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Board board = new Board(8, 8);

                board.placePiece(new Tower(board, Color.Black), new Position(0, 0));
                board.placePiece(new Tower(board, Color.Black), new Position(1, 3));
                board.placePiece(new king(board, Color.Black), new Position(2, 4));

                board.placePiece(new Tower(board, Color.White), new Position(3, 5));

                Screen.PrintBoard(board);
            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }
                

            Console.ReadLine();
        }
    }
}