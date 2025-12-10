using board;
using chess;

namespace chess_console.chess
{
    class King : Piece
    {
        private ChessGame chessGame;
        public King(Board board, Color color, ChessGame chessGame) : base(board, color)
        {
            this.chessGame = chessGame;
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

            //# special move castling
            if(moveCount == 0 && !chessGame.check)
            {
                // king side rook
                Position posT1 = new Position(Position.row, Position.column + 3);
                if (testRookCastling(posT1))
                {
                    Position p1 = new Position(Position.row, Position.column + 1);
                    Position p2 = new Position(Position.row, Position.column + 2);
                    if (board.piece(p1) == null && board.piece(p2) == null)
                    {
                        movements[Position.row, Position.column + 2] = true;
                    }
                }
                // queen side rook
                Position posT2 = new Position(Position.row, Position.column - 4);
                if (testRookCastling(posT2))
                {
                    Position p1 = new Position(Position.row, Position.column - 1);
                    Position p2 = new Position(Position.row, Position.column - 2);
                    Position p3 = new Position(Position.row, Position.column - 3);
                    if (board.piece(p1) == null && board.piece(p2) == null && board.piece(p3) == null)
                    {
                        movements[Position.row, Position.column - 2] = true;
                    }
                }
            }

            return movements;
        }

        private bool testRookCastling(Position position)
        {
            Piece p = board.piece(position);
            return p != null && p is Tower && p.color == color && p.moveCount == 0;
        }
    }
}
