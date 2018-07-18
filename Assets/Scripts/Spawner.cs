using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public static Spawner instance;

    public GameObject tile;
    public GameObject map;

    private BoardController boardController;

    public GameObject spawnTile(int x, int y)
    {
        Vector3 position = boardController.coordToVector3(x, y);
        GameObject newTile = GameObject.Instantiate(tile, position, Quaternion.identity, map.transform);
        newTile.name = x + " : " + y;
        return newTile;
    }

    void Start()
    {
        boardController = BoardController.instance;
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
}
