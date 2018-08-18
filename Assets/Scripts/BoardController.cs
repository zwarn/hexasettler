using System.Collections;
using System.Collections.Generic;
using System.Linq;
using model.map;
using UnityEngine;

public class BoardController : MonoBehaviour {
    public static BoardController Instance { get; private set; }

    public int Size = 5;
    public float DeltaX = 1.735f;
    public float DeltaY = 1.5f;

    private Hex _currentlySelected;
    private Map _map;

    void Awake() {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start () {
        _map = new Map(Size);
	}

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_currentlySelected != null)
            {
                _currentlySelected.AddRoad();
            }
        }
    }

    public Vector3 CoordToVector3(int x, int y)
    {
        return new Vector3(x * DeltaX + y * DeltaX / 2, y * DeltaY);
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
