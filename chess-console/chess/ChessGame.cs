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
        private HashSet<Piece> piecesOnTheBoard;
        public HashSet<Piece> capturedPieces;

        public ChessGame()
        {
            board = new Board(8, 8);
            turn = 1;
            currentPlayer = Color.White;
            finished = false;
            piecesOnTheBoard = new HashSet<Piece>();
            capturedPieces = new HashSet<Piece>();
            putPieces();
        }

        public void executeMovement(Position origin, Position destiny)
        {
            Piece piece = board.removePiece(origin);
            piece.incrementMovementCount();
            Piece capturedPiece = board.removePiece(destiny);
            board.placePiece(piece, destiny);
            if (capturedPiece != null)
            {
                capturedPieces.Add(capturedPiece);
                piecesOnTheBoard.Remove(capturedPiece);
            }
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
        public HashSet<Piece> getCapturedPieces(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in capturedPieces)
            {
                if (x.color == color)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }
        public HashSet<Piece> getPiecesOnTheBoard(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in piecesOnTheBoard)
            {
                if (x.color == color)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(getCapturedPieces(color));

            return aux;
        }
        public void placeNewPiece(char column, int row, Piece piece)
        {
            board.placePiece(piece, new ChessPosition(column, row).toPosition());
            piecesOnTheBoard.Add(piece);
        }
        private void putPieces()
        {
            placeNewPiece('c', 1, new Tower(board, Color.White));
            placeNewPiece('c', 2, new Tower(board, Color.White));
            placeNewPiece('d', 2, new Tower(board, Color.White));
            placeNewPiece('e', 2, new Tower(board, Color.White));
            placeNewPiece('e', 1, new Tower(board, Color.White));
            placeNewPiece('d', 1, new King(board, Color.White));

            placeNewPiece('c', 7, new Tower(board, Color.Black));
            placeNewPiece('c', 8, new Tower(board, Color.Black));
            placeNewPiece('d', 7, new Tower(board, Color.Black));
            placeNewPiece('e', 7, new Tower(board, Color.Black));
            placeNewPiece('e', 8, new Tower(board, Color.Black));
            placeNewPiece('d', 8, new King(board, Color.Black));
        }
    }
}
