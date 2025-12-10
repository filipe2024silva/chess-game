namespace board
{
    abstract class Piece
    {
        public Position Position { get; set; }
        public Color color { get; protected set; }
        public int moveCount { get; protected set; }
        public Board board { get; protected set; }

        public Piece(Board board, Color color)
        {
            this.Position = null;
            this.board = board;
            this.color = color;
            this.moveCount = 0;
        }
        public bool thereIsPossibleMovements()
        {
            bool[,] mat = possibleMovements();
            for (int i = 0; i < board.rows; i++)
            {
                for (int j = 0; j < board.columns; j++)
                {
                    if (mat[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public void incrementMovementCount()
        {
            moveCount++;
        }
        public void decrementMovementCount()
        {
            moveCount--;
        }
        public bool canMoveTo(Position pos)
        {
            return possibleMovements()[pos.row, pos.column];
        }
        public abstract bool[,] possibleMovements();
    }
}
