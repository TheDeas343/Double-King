namespace ChessGame
{
    public abstract class Piece
    {
        public PieceColor color { get; set; }

        public Piece(PieceColor color)
        {
            this.color = color;
        }

       
        public abstract void MovmentOrCapture(Tile[,] board, Tile currentTile);

        public abstract void SpecialMovment(Tile[,] board, Tile currentTile);
    }
}
