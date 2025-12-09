using board;

namespace chess_console.chess
{
    class king : Piece
    {
        public king(Board board, Color color) : base(board, color)
        {

        }

        public override string ToString()
        {
            return "K";
        }
    }
}
