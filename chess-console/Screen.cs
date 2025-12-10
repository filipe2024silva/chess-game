using board;
using chess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess_console
{
    class Screen
    {
        public static void printChessGame(ChessGame chessGame)
        {
            PrintBoard(chessGame.board);
            Console.WriteLine();
            PrintCapturedPieces(chessGame);
            Console.WriteLine();
            Console.WriteLine("Turn: " + chessGame.turn);
            Console.WriteLine("Current Player: " + chessGame.currentPlayer);
            if (chessGame.check)
            {
                Console.WriteLine("CHECK!");
            }
            Console.WriteLine();
        }
        public static void PrintBoard(Board board)
        {
            for (int i = 0; i < board.rows; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.columns; j++)
                {
                    printPiece(board.piece(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }
        public static void PrintCapturedPieces(ChessGame chessGame)
        {
            Console.WriteLine("Captured pieces: ");
            Console.Write("White: ");
            printSet(chessGame.getCapturedPieces(Color.White));
            Console.WriteLine();
            Console.Write("Black: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            printSet(chessGame.getCapturedPieces(Color.Black));
            Console.ForegroundColor = aux;
            Console.WriteLine();
        }
        public static void printSet(HashSet<Piece> set)
        {
            Console.Write("[");
            foreach (Piece x in set)
            {
                Console.Write(x + " ");
            }
            Console.Write("]");
        }
        public static void PrintBoard(Board board, bool[,] possibleMoves)
        {
            ConsoleColor originColor = Console.BackgroundColor;
            ConsoleColor changedColor = ConsoleColor.DarkGray;

            for (int i = 0; i < board.rows; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.columns; j++)
                {
                    if (possibleMoves[i, j])
                    {
                        Console.BackgroundColor = changedColor;
                    }
                    else
                    {
                        Console.BackgroundColor = originColor;
                    }
                    printPiece(board.piece(i, j));
                    Console.BackgroundColor = originColor;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = originColor;
        }

        public static ChessPosition ChessPositionFromInput()
        {
            string s = Console.ReadLine();
            char column = s[0];
            int row = int.Parse(s[1] + "");
            return new ChessPosition(column, row);
        }

        public static void printPiece(Piece piece)
        {
            if(piece == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (piece.color == Color.White)
                {
                    Console.Write(piece);
                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(piece);
                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");
            } 
        }
    }
}
