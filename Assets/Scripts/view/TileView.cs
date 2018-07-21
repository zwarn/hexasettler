using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileView : MonoBehaviour {

    public GameObject roadM;
    public GameObject roadW;
    public GameObject roadSW;
    public GameObject roadSE;
    public GameObject roadE;
    public GameObject roadNE;
    public GameObject roadNW;

    public GameObject[] roads;

    public Tile tile;
    private BoardController boardController;

    public void Awake()
    {
        boardController = BoardController.instance;
    }

    public void Start()
    {
        roads = new GameObject[] { roadW, roadSW, roadSE, roadE, roadNE, roadNW };
    }

    public void link(Tile tile)
    {
        this.tile = tile;
    }

    public void updateView()
    {
        if (tile.road)
        {
            roadM.GetComponent<SpriteRenderer>().enabled = true;

            for (int i = 0; i < 6; i++)
            {
                roads[i].GetComponent<SpriteRenderer>().enabled = tile.roads[i];
            }

        }
    }

    private void OnMouseEnter()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(0.9f, 0.9f, 0.9f);
        boardController.selectedTile(tile);
    }

    private void OnMouseExit()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f);
        boardController.deselectTile(tile);
    }
}
