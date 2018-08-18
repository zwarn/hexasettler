using System.Collections;
using System.Collections.Generic;
using model.map;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public static Spawner Instance;

    public GameObject TileObject;
    public GameObject RoadObject;
    public GameObject Map;

    private BoardController _boardController;

    public GameObject SpawnHex(int x, int y)
    {
        Vector3 position = _boardController.coordToVector3(x, y);
        GameObject newTile = Instantiate(TileObject, position, Quaternion.identity, Map.transform);
        newTile.name = x + " : " + y;
        return newTile;
    }

    void Start()
    {
        _boardController = BoardController.Instance;
    }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public GameObject SpawnRoad(TilePosition tilePosition, GameObject parent)
    {
        Vector3 position = _boardController.coordToVector3(tilePosition.x, tilePosition.y);
        return Instantiate(RoadObject, position, Quaternion.identity, parent.transform);
    }
}
