using System;
using System.Collections.Generic;
using Editor;
using model.map;
using model.position;
using UnityEngine;

public class BoardController : MonoBehaviour {
    public static BoardController Instance { get; private set; }

    private Hex _currentlySelected;
    internal Grid grid;
    Map _map;
    Roads _roads;

    void Awake() {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start ()
    {
        grid = GetComponent<Grid>();
        _map = new Map();
        _roads = new Roads();
        ImportMap();
	}

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_currentlySelected != null)
            {
                //TODO rework
//                _currentlySelected.AddRoad();
//                _currentlySelected.Road.UpdateView();
//                var neighborRoads = MapHelper.GetNeighborRoads(_currentlySelected.Position).ToList();
//                neighborRoads.ForEach(road => road.UpdateView());
            }
        }
    }

    private void ImportMap()
    {
        foreach (Transform child in transform)
        {
            TilePosition position = new TilePosition(grid.WorldToCell(child.position));
            Dictionary<Layer, GameObject> layers = ExtractGameObjectPerLayer(child);
            Hex hex = new Hex(position, layers);
            
            _map.AddHex(position, hex);
            
        }
    }

    private Dictionary<Layer, GameObject> ExtractGameObjectPerLayer(Transform child)
    {
        Dictionary<Layer, GameObject> layers = new Dictionary<Layer, GameObject>();
        foreach (Layer layer in Enum.GetValues(typeof(Layer)))
        {
            GameObject gameObject = gameObjectFromLayer(child, layer);
            if (gameObject != null)
            {
                layers.Add(layer, gameObject);
            }
        }

        return layers;
    }
    
    private GameObject gameObjectFromLayer(Transform transform, Layer layer)
    {
        var child = transform.Find(layer.ToString());
        return child == null ? null : child.gameObject;
    }

    public void SelectedTile(Hex hex)
    {
        _currentlySelected = hex;
    }

    public void DeselectTile(Hex hex)
    {
        if (_currentlySelected == hex)
        {
            _currentlySelected = null;
        }
    }
}
