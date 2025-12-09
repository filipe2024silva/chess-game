namespace board
{
    class Board
    {
        public int lines { get; set; }
        public int columns { get; set; }
        private Piece[,] pieces;

        public Board(int lines, int columns)
        {
            this.lines = lines;
            this.columns = columns;
            pieces = new Piece[lines, columns];
        }

        public Piece piece(int line, int column)
        {
            return pieces[line, column];
        }

        public Piece piece(Position position)
        {
            return pieces[position.line, position.column];
        }

        public void placePiece(Piece piece, Position position)
        {
            if (thereIsAPiece(position))
            {
                throw new BoardException("There is already a piece in this position!");
            }
            pieces[position.line, position.column] = piece;
            piece.Position = position;
        }

        public bool thereIsAPiece(Position position)
        {
            validatePosition(position);
            return piece(position) != null;
        }

        public bool positionValid(Position position)
        {
            if (position.line < 0 || position.line >= lines || position.column < 0 || position.column >= columns)
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
