using board;

namespace chess_console.chess
{
    class Pawn : Piece
    {
        public Pawn(Board board, Color color) : base(board, color)
        {

        }

        public override string ToString()
        {
            return "P";
        }
        public bool thereIsEnemy(Position position)
        {
            Piece p = board.piece(position);
            return p != null && p.color != color;
        }
        private bool free(Position position)
        {
            return board.piece(position) == null;
        }

        public override bool[,] possibleMovements()
        {
            bool[,] movements = new bool[board.rows, board.columns];

            Position pos = new Position(0, 0);

            if (color == Color.White)
            {
                pos.setValues(Position.row - 1, Position.column);
                if (board.positionValid(pos) && free(pos))
                {
                    movements[pos.row, pos.column] = true;
                }
                pos.setValues(Position.row - 2, Position.column);
                Position pos2 = new Position(Position.row - 1, Position.column);
                if (board.positionValid(pos) && free(pos) && moveCount == 0 && free(pos2))
                {
                    movements[pos.row, pos.column] = true;
                }
                // capture ne
                pos.setValues(Position.row - 1, Position.column + 1);
                if (board.positionValid(pos) && thereIsEnemy(pos))
                {
                    movements[pos.row, pos.column] = true;
                }
                // capture no
                pos.setValues(Position.row - 1, Position.column - 1);
                if (board.positionValid(pos) && thereIsEnemy(pos))
                {
                    movements[pos.row, pos.column] = true;
                }
            }
            else
            {
                pos.setValues(Position.row + 1, Position.column);
                if (board.positionValid(pos) && free(pos))
                {
                    movements[pos.row, pos.column] = true;
                }
                pos.setValues(Position.row + 2, Position.column);
                Position pos2 = new Position(Position.row + 1, Position.column);
                if (board.positionValid(pos) && free(pos) && moveCount == 0 && free(pos2))
                {
                    movements[pos.row, pos.column] = true;
                }
                // capture se
                pos.setValues(Position.row + 1, Position.column + 1);
                if (board.positionValid(pos) && thereIsEnemy(pos))
                {
                    movements[pos.row, pos.column] = true;
                }
                // capture so
                pos.setValues(Position.row + 1, Position.column - 1);
                if (board.positionValid(pos) && thereIsEnemy(pos))
                {
                    movements[pos.row, pos.column] = true;
                }

            }

            return movements;
        }
    }
}
