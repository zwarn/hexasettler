using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileView {

    private int x;
    private int y;
    GameObject tile;


    public TileView(int posX, int posY)
    {
        this.x = posX;
        this.y = posY;
        tile = Spawner.instance.spawnTile(x, y);
    }
}
