using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardController : MonoBehaviour {
    public static BoardController instance;

    public int size = 5;
    public float deltaX = 1.735f;
    public float deltaY = 1.5f;
    public TileMap tileMap;

    void Awake() {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start () {
        tileMap = new TileMap(size, size);
	}

    public Vector3 coordToVector3(int x, int y)
    {
        return new Vector3(x * deltaX + (y % 2 == 1 ? 0f : deltaX/2), y * deltaY);
    }
}
