namespace board
{
    class Piece
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
    }
}
