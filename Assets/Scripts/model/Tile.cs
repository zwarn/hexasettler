using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile {
    private int posX;
    private int posY;
    private TileView tileView;

    public Tile(int posX, int posY)
    {
        this.posX = posX;
        this.posY = posY;
        tileView = new TileView(posX, posY);
    }
    
}
