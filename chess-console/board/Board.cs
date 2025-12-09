namespace board
{
    class Board
    {
        public int rows { get; set; }
        public int columns { get; set; }
        private Piece[,] pieces;

        public Board(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;
            pieces = new Piece[rows, columns];
        }

        public Piece piece(int row, int column)
        {
            return pieces[row, column];
        }

        public Piece piece(Position position)
        {
            return pieces[position.row, position.column];
        }

        public void placePiece(Piece piece, Position position)
        {
            if (thereIsAPiece(position))
            {
                throw new BoardException("There is already a piece in this position!");
            }
            pieces[position.row, position.column] = piece;
            piece.Position = position;
        }

        public bool thereIsAPiece(Position position)
        {
            validatePosition(position);
            return piece(position) != null;
        }

        public bool positionValid(Position position)
        {
            if (position.row < 0 || position.row >= rows || position.column < 0 || position.column >= columns)
            {
                return false;
            }
            return true;
        }

        public void validatePosition(Position position)
        {
            if (!positionValid(position))
            {
                throw new BoardException("Invalid position!");
            }
        }
    }
}
