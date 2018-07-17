using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardController : MonoBehaviour {
    public static BoardController instance;

    public int size = 5;
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
}
