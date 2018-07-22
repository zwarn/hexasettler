using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardController : MonoBehaviour {
    public static BoardController instance;

    public int size = 5;
    public float deltaX = 1.735f;
    public float deltaY = 1.5f;
    public TileMap tileMap;

    private Tile currentlySelected = null;

    void Awake() {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start () {
        tileMap = new TileMap(5);
	}

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (currentlySelected != null)
            {
                // TODO: fix
                // currentlySelected.addRoad(Direction.NoWhere);
            }
        }
    }

    public Vector3 coordToVector3(int x, int y)
    {
        return new Vector3(x * deltaX + y * deltaX / 2, y * deltaY);
    }

    public void selectedTile(Tile tile)
    {
        currentlySelected = tile;
    }

    public void deselectTile(Tile tile)
    {
        if (currentlySelected == tile)
        {
            currentlySelected = null;
        }
    }
}
