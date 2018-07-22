using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMap {


    public Dictionary<TilePosition, Tile> tiles;

    public TileMap(int size) {
        tiles = new Dictionary<TilePosition, Tile>();
        for (int x = -size; x <= size; x++)
        {
            for (int y = -size; y <= +size; y++)
            {
                if (Mathf.Abs(x + y) <= size)
                {
                    TilePosition tilePosition = new TilePosition(x, y);
                    tiles.Add(tilePosition, new Tile(tilePosition));
                }
            }
        }
    }
}
