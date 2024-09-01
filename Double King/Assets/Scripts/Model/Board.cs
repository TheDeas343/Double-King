namespace ChessGame
{

    public class Board
    {
        private int width { get; set; }
        private int length { get; set; }
        private Tile[,] boardTiles { get; set; }
        public string[,] debugBoard { get; private set; }



        public Board(int width, int length)
        {
            this.width = width;
            this.length = length;
            boardTiles = new Tile[width, length];
            debugBoard = new string[width, length];

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < length; y++)
                {
                    boardTiles[x, y] = new Tile(x, y);
                    debugBoard[x, y] = " ";
                }
            }
        }
    }

}