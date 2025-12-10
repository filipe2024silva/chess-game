using board;
using chess_console.chess;

namespace chess
{
    class ChessGame
    {
        public Board board {  get; private set; }
        public int turn { get; private set; }
        public Color currentPlayer { get; private set; }
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

        public void makeMovemement(Position origin, Position destiny)
        {
            executeMovement(origin, destiny);
            turn++;
            changePlayer();
        }
        public void validateOriginPosition(Position position)
        {
            if (board.piece(position) == null)
            {
                throw new BoardException("There is no piece in this position!");
            }
            if (currentPlayer != board.piece(position).color)
            {
                throw new BoardException("The chosen piece is not yours!");
            }
            if (!board.piece(position).thereIsPossibleMovements())
            {
                throw new BoardException("There are no possible movements for the chosen piece!");
            }
        }
        public void validateDestinyPosition(Position origin, Position destiny)
        {
            if (!board.piece(origin).canMoveTo(destiny))
            {
                throw new BoardException("Destiny position invalid!");
            }
        }
        private void changePlayer()
        {
            if (currentPlayer == Color.White)
            {
                currentPlayer = Color.Black;
            }
            else
            {
                currentPlayer = Color.White;
            }
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
