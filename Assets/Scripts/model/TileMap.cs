using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMap {


    private Dictionary<TilePosition, Tile> tiles;

    public TileMap(int fromX, int fromY, int toX, int toY) {
        tiles = new Dictionary<TilePosition, Tile>();
        for (int x = fromX; x <= toX; x++)
        {
            for (int y = fromY; y <= toY; y++)
            {
                tiles.Add(new TilePosition(x, y), new Tile(x, y));
            }
        }
    }
}
