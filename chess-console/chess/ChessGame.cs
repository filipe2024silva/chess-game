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
        private HashSet<Piece> capturedPieces;
        public bool check { get; private set; }

        public ChessGame()
        {
            board = new Board(8, 8);
            turn = 1;
            currentPlayer = Color.White;
            finished = false;
            check = false;
            piecesOnTheBoard = new HashSet<Piece>();
            capturedPieces = new HashSet<Piece>();
            putPieces();
        }

        public Piece executeMovement(Position origin, Position destiny)
        {
            Piece piece = board.removePiece(origin);
            piece.incrementMovementCount();
            Piece capturedPiece = board.removePiece(destiny);
            board.placePiece(piece, destiny);
            if (capturedPiece != null)
            {
                capturedPieces.Add(capturedPiece);
            }
            return capturedPiece;
        }

        public void makeMovemement(Position origin, Position destiny)
        {
            Piece _capturedPiece = executeMovement(origin, destiny);

            if (isInCheck(currentPlayer))
            {
                undoMovement(origin, destiny, _capturedPiece);
                throw new BoardException("You cannot put yourself in check!");
            }

            if (isInCheck(oponentColor(currentPlayer)))
            {
                check = true;
            }
            else
            {
                check = false;
            }

            turn++;
            changePlayer();
        }
        public void undoMovement(Position origin, Position destiny, Piece capturedPiece)
        {
            Piece piece = board.removePiece(destiny);
            piece.decrementMovementCount();
            if (capturedPiece != null)
            {
                board.placePiece(capturedPiece, destiny);
                capturedPieces.Remove(capturedPiece);
            }
            board.placePiece(piece, origin);
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
        private Color oponentColor(Color color)
        {
            if (color == Color.White)
            {
                return Color.Black;
            }
            else
            {
                return Color.White;
            }
        }
        private Piece king(Color color)
        {
            foreach (Piece x in getPiecesOnTheBoard(color))
            {
                if (x is King)
                {
                    return x;
                }
            }
            return null;
        }
        public bool isInCheck(Color color)
        {
            Piece K = king(color);
            if (K == null)
            {
                throw new BoardException("There is no " + color + " king on the board!");
            }
            foreach (Piece x in getPiecesOnTheBoard(oponentColor(color)))
            {
                bool[,] mat = x.possibleMovements();
                if (mat[K.Position.row, K.Position.column])
                {
                    return true;
                }
            }
            return false;
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
