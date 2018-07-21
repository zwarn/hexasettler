using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMap {


    private Dictionary<TilePosition, Tile> tiles;

    public TileMap(int size) {
        tiles = new Dictionary<TilePosition, Tile>();
        for (int x = -size; x <= size; x++)
        {
            for (int y = -size; y <= +size; y++)
            {
                if (Mathf.Abs(x + y) <= size)
                {
                    tiles.Add(new TilePosition(x, y), new Tile(x, y));
                }
            }
        }
    }
}
