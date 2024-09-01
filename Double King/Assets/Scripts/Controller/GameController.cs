using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameController : MonoBehaviour
{
    private BoardController boardController;

    [SerializeField]
    public GameObject tilePrefab;
    [SerializeField]
    public int tileSize;

    private const int INITIAL_WIDTH = 8;
    private const int INITIAL_LENGTH = 8;



    private void Awake()
    {
        boardController = new BoardController(tilePrefab, INITIAL_WIDTH, INITIAL_LENGTH, tileSize);


    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
