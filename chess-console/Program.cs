using board;
using chess;

namespace chess_console
{
    class Program
    {
        static void Main(string[] args)
        {
            ChessPosition chessPosition = new ChessPosition('c', 7);

            Console.WriteLine(chessPosition);
            Console.WriteLine(chessPosition.toPosition());

            Console.ReadLine();
        }
    }
}