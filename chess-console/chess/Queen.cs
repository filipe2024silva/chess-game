using board;

namespace chess_console.chess
{
    class Queen: Piece
    {
        public Queen(Board board, Color color) : base(board, color)
        {

        }

        public override string ToString()
        {
            return "T";
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

            // left
            pos.setValues(Position.row, Position.column - 1);
            while (board.positionValid(pos) && canMove(pos))
            {
                movements[pos.row, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }
                pos.setValues(Position.row, Position.column - 1);
            }

            //right
            pos.setValues(Position.row, Position.column + 1);
            while (board.positionValid(pos) && canMove(pos))
            {
                movements[pos.row, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }
                pos.setValues(Position.row, Position.column + 1);
            }

            //above
            pos.setValues(Position.row - 1, Position.column);
            while (board.positionValid(pos) && canMove(pos))
            {
                movements[pos.row, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }
                pos.setValues(Position.row - 1, Position.column);
            }
            //under
            pos.setValues(Position.row + 1, Position.column);
            while (board.positionValid(pos) && canMove(pos))
            {
                movements[pos.row, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }
                pos.setValues(Position.row + 1, Position.column);
            }
            //no
            pos.setValues(Position.row - 1, Position.column - 1);
            while (board.positionValid(pos) && canMove(pos))
            {
                movements[pos.row, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }
                pos.setValues(Position.row - 1, Position.column - 1);
            }
            //ne
            pos.setValues(Position.row - 1, Position.column + 1);
            while (board.positionValid(pos) && canMove(pos))
            {
                movements[pos.row, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }
                pos.setValues(Position.row - 1, Position.column + 1);
            }
            //se
            pos.setValues(Position.row + 1, Position.column + 1);
            while (board.positionValid(pos) && canMove(pos))
            {
                movements[pos.row, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }
                pos.setValues(Position.row + 1, Position.column + 1);
            }
            //so
            pos.setValues(Position.row + 1, Position.column - 1);
            while (board.positionValid(pos) && canMove(pos))
            {
                movements[pos.row, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }
                pos.setValues(Position.row + 1, Position.column - 1);
            }
            return movements;
        }
    }
}
