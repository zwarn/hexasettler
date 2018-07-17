using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public static Spawner instance;

    public GameObject tile;
    public GameObject map;

    public GameObject spawnTile(int x, int y)
    {
        Vector3 position = coordToVector3(x, y);
        GameObject newTile = GameObject.Instantiate(tile, position, Quaternion.identity, map.transform);
        newTile.name = x + " : " + y;
        return newTile;
    }

    public Vector3 coordToVector3(int x, int y)
    {
        //TODO: parameterize
        return new Vector3(x * 0.5f + (y % 2 == 1 ? 0f : 0.25f), y * 0.435f);
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
}
