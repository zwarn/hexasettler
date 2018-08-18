using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using view;

public class Tile {
    //TODO: move tileObject to tileView
    private GameObject _tileObject;
    private TileView _tileView;

    public TilePosition TilePosition;

    public Tile(TilePosition position)
    {
        this.TilePosition = position;
        _tileObject = Spawner.instance.spawnTile(position.x, position.y);
        _tileView = _tileObject.GetComponent<TileView>();
    }

}
