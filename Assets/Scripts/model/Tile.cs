using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile {
    private GameObject tileObject;
    private TileView tileView;

    public bool road = false;
    public bool[] roads = new bool[6];

    public Tile(int posX, int posY)
    {
        tileObject = Spawner.instance.spawnTile(posX, posY);
        tileView = tileObject.GetComponent<TileView>();
        tileView.link(this);
    }

    public void addRoad(int dir)
    {
        road = true;
        if (dir >= 0)
        {
            roads[dir] = true;
        }
        tileView.updateView();
    }

}
