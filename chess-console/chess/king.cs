using board;

namespace chess_console.chess
{
    class King : Piece
    {
        public King(Board board, Color color) : base(board, color)
        {

        }

        public override string ToString()
        {
            return "K";
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

            // above
            pos.setValues(Position.row - 1, Position.column);
            if (board.positionValid(pos) && canMove(pos))
            {
                movements[pos.row, pos.column] = true;
            }

            // ne
            pos.setValues(Position.row - 1, Position.column + 1);
            if (board.positionValid(pos) && canMove(pos))
            {
                movements[pos.row, pos.column] = true;
            }

            // right
            pos.setValues(Position.row, Position.column + 1);
            if (board.positionValid(pos) && canMove(pos))
            {
                movements[pos.row, pos.column] = true;
            }
            // se
            pos.setValues(Position.row + 1, Position.column + 1);
            if (board.positionValid(pos) && canMove(pos))
            {
                movements[pos.row, pos.column] = true;
            }
            // under
            pos.setValues(Position.row + 1, Position.column);
            if (board.positionValid(pos) && canMove(pos))
            {
                movements[pos.row, pos.column] = true;
            }
            // so
            pos.setValues(Position.row + 1, Position.column - 1);
            if (board.positionValid(pos) && canMove(pos))
            {
                movements[pos.row, pos.column] = true;
            }
            // left
            pos.setValues(Position.row, Position.column - 1);
            if (board.positionValid(pos) && canMove(pos))
            {
                movements[pos.row, pos.column] = true;
            }
            // no
            pos.setValues(Position.row - 1, Position.column - 1);
            if (board.positionValid(pos) && canMove(pos))
            {
                movements[pos.row, pos.column] = true;
            }

            return movements;
        }
    }
}
