using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile {
    private GameObject tileObject;
    private TileView tileView;

    public bool road = false;
    public bool[] roads = new bool[6];
    public TilePosition tilePosition;

    public Tile(TilePosition position)
    {
        this.tilePosition = position;
        tileObject = Spawner.instance.spawnTile(position.x, position.y);
        tileView = tileObject.GetComponent<TileView>();
        tileView.link(this);
    }

    public void addRoad()
    {
        road = true;
        tileView.updateView();
    }

    public void connectRoad(List<TilePosition> neighborRoads)
    {
        neighborRoads.ForEach(direction => roads[direction.toIndex()] = true);
        tileView.updateView();
    }

    public void connectRoad(TilePosition direction)
    {
        roads[direction.toIndex()] = true;
        tileView.updateView();
    }

}
