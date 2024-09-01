using UnityEngine;
using  ChessGame;

public class BoardController : MonoBehaviour
{
    public int boardWidth = 8; 
    public int boardLength = 8;
    public int tileSize;

    public GameObject tilePrefab; 

    private Board board;

    private void Awake()
    {
        Tile.OnTileClicked += HandleTileClicked;
    }

    private void OnDestroy()
    {
        Tile.OnTileClicked -= HandleTileClicked;
    }

    public BoardController(GameObject tilePrefab, int boardWidth, int boardLength, int tileSize)
    {
        this.tilePrefab = tilePrefab;
        this.boardWidth = boardWidth;
        this.boardLength = boardLength;
        this.tileSize = tileSize;
        this.board = new Board(boardWidth, boardLength);

        CreateBoard();
    }



    public void CreateBoard()
    {
        for (int x = 0; x < boardWidth; x++)
        {
            for (int y = 0; y < boardLength; y++)
            {
                Vector3 position = new Vector3(x*tileSize, y*tileSize, 0);

                GameObject tile = Instantiate(tilePrefab, position, Quaternion.identity);
                tile.name = $"Tile_{x}_{y}";


                Tile tileScript = tile.GetComponent<Tile>();
                tileScript.SetTileColor(((x + y) % 2 == 0)? true: false);

            }
        }
    }

    private void HandleTileClicked(Tile clickedTile)
    {
        Debug.Log($"Tile clicked at position: {clickedTile.position}");
        clickedTile.SetTileColor(TileAction.Movment);
    }
}
