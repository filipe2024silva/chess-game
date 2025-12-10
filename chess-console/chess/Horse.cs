using board;

namespace chess_console.chess
{
    class Horse : Piece
    {
        public Horse(Board board, Color color) : base(board, color)
        {

        }

        public override string ToString()
        {
            return "H";
        }

        private bool canMove(Position position)
        {
            Piece p = board.piece(position);
            return p == null || p.color != color;
        }

        public override bool[,] possibleMovements()
        {
            bool[,] movements = new bool[board.rows, board.columns];

            Position pos = new Position(0, 0);

            pos.setValues(Position.row - 1, Position.column - 2);
            if (board.positionValid(pos) && canMove(pos))
            {
                movements[pos.row, pos.column] = true;
            }
            pos.setValues(Position.row - 2, Position.column - 1);
            if (board.positionValid(pos) && canMove(pos))
            {
                movements[pos.row, pos.column] = true;
            }
            pos.setValues(Position.row - 2, Position.column +1);
            if (board.positionValid(pos) && canMove(pos))
            {
                movements[pos.row, pos.column] = true;
            }
            pos.setValues(Position.row - 1, Position.column + 2);
            if (board.positionValid(pos) && canMove(pos))
            {
                movements[pos.row, pos.column] = true;
            }
            pos.setValues(Position.row + 1, Position.column + 2);
            if (board.positionValid(pos) && canMove(pos))
            {
                movements[pos.row, pos.column] = true;
            }
            pos.setValues(Position.row + 2, Position.column + 1);
            if (board.positionValid(pos) && canMove(pos))
            {
                movements[pos.row, pos.column] = true;
            }
            pos.setValues(Position.row + 2, Position.column - 1);
            if (board.positionValid(pos) && canMove(pos))
            {
                movements[pos.row, pos.column] = true;
            }
            pos.setValues(Position.row + 1, Position.column - 2);
            if (board.positionValid(pos) && canMove(pos))
            {
                movements[pos.row, pos.column] = true;
            }
            return movements;
        }
    }
}
