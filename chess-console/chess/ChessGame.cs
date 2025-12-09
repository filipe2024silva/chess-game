using board;
using chess_console.chess;

namespace chess
{
    class ChessGame
    {
        public Board board {  get; private set; }
        private int turn;
        private Color currentPlayer;
        public bool finished { get; private set; }

        public ChessGame()
        {
            board = new Board(8, 8);
            turn = 1;
            currentPlayer = Color.White;
            finished = false;
            putPieces();
        }

        public void executeMovement(Position origin, Position destiny)
        {
            Piece piece = board.removePiece(origin);
            piece.incrementMovementCount();
            Piece capturedPiece = board.removePiece(destiny);
            board.placePiece(piece, destiny);
        }

        private void putPieces()
        {
            board.placePiece(new Tower(board, Color.White), new ChessPosition('c', 1).toPosition());
            board.placePiece(new Tower(board, Color.White), new ChessPosition('c', 2).toPosition());
            board.placePiece(new Tower(board, Color.White), new ChessPosition('d', 2).toPosition());
            board.placePiece(new Tower(board, Color.White), new ChessPosition('e', 2).toPosition());
            board.placePiece(new Tower(board, Color.White), new ChessPosition('e', 1).toPosition());
            board.placePiece(new King(board, Color.White), new ChessPosition('d', 1).toPosition());

            board.placePiece(new Tower(board, Color.Black), new ChessPosition('c', 7).toPosition());
            board.placePiece(new Tower(board, Color.Black), new ChessPosition('c', 8).toPosition());
            board.placePiece(new Tower(board, Color.Black), new ChessPosition('d', 7).toPosition());
            board.placePiece(new Tower(board, Color.Black), new ChessPosition('e', 7).toPosition());
            board.placePiece(new Tower(board, Color.Black), new ChessPosition('e', 8).toPosition());
            board.placePiece(new King(board, Color.Black), new ChessPosition('d', 8).toPosition());
        }
    }
}
