using board;

namespace chess_console.chess
{
    class Bishop : Piece
    {
        public Bishop(Board board, Color color) : base(board, color)
        {

        }

        public override string ToString()
        {
            return "B";
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
