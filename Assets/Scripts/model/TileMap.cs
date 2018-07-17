using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMap {
    private Tile[,] tiles;

    public TileMap(int sizeX, int sizeY) {
        tiles = new Tile[sizeX,sizeY];
        for (int x = 0; x < sizeX; x++ )
        {
            for (int y = 0; y < sizeY; y++)
            {
                tiles[x, y] = new Tile(x, y);
            }
        }
    }
}
