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
                    try
                    {
                        Console.Clear();
                        Screen.printChessGame(chessGame);

                        Console.WriteLine();
                        Console.Write("Origin: ");
                        Position origin = Screen.ChessPositionFromInput().toPosition();
                        chessGame.validateOriginPosition(origin);

                        bool[,] possibleMoves = chessGame.board.piece(origin).possibleMovements();

                        Console.Clear();
                        Screen.PrintBoard(chessGame.board, possibleMoves);

                        Console.WriteLine();
                        Console.Write("Destiny: ");
                        Position destiny = Screen.ChessPositionFromInput().toPosition();
                        chessGame.validateDestinyPosition(origin, destiny);

                        chessGame.makeMovemement(origin, destiny);
                    }
                    catch (BoardException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                    
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