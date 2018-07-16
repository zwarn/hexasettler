using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardController : MonoBehaviour {

    public GameObject hex;
    public GameObject map;
    public int size = 5;

	// Use this for initialization
	void Start () {
        spawnBoard();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void spawnBoard()
    {
        for (int x = 0; x < size; x++)
        {
            for (int y = 0; y < size; y++)
            {
                spawnTile(x, y);
            }
        }
    }

    void spawnTile(int x, int y)
    {
        Vector3 position = new Vector3(x * 0.5f + (y % 2 == 1 ? 0f : 0.25f), y * 0.435f);
        GameObject newTile = GameObject.Instantiate(hex, position, Quaternion.identity, map.transform);
        newTile.name = x + " : " + y;
    }
}
