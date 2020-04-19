using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public int BoardWidth;
    public int BoardHeight;
    public GameObject tilePrefab;
    public GameObject[] dots;
    public GameObject[,] allDots;

    private BackgroundTile[,] allTiles;


    // Start is called before the first frame update
    void Start()
    {
        allTiles = new BackgroundTile[BoardWidth, BoardHeight];
        allDots = new GameObject[BoardWidth, BoardHeight];
        BoardSetup();
    }

    private void BoardSetup() {
        for (int i = 0; i < BoardWidth; i++){
            for (int j = 0; j < BoardHeight; j++) {
                Vector2 tempPosition = new Vector2(i, j);
                GameObject backgroundTile = Instantiate(tilePrefab, tempPosition, Quaternion.identity) as GameObject;
                backgroundTile.transform.parent = this.transform;
                backgroundTile.name = "( " + i + ", " + j + " )";
                int dotToUse = Random.Range(0, dots.Length);
                GameObject dot = Instantiate(dots[dotToUse], tempPosition, Quaternion.identity);
                dot.transform.parent = this.transform;
                dot.name = "( " + i + ", " + j + " )";
                allDots[i, j] = dot;
            }
        }
    }
}
