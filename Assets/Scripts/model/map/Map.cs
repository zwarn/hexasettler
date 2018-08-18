using System;
using System.Collections.Generic;
using UnityEngine;

namespace model.map
{
    public class Map
    {
        private static Map Instance { get; set; }
        private Dictionary<TilePosition, Hex> Hexes { get; set; }

        public void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }
        

        public Map(int size)
        {
            Hexes = new Dictionary<TilePosition, Hex>();
            for (var x = -size; x <= size; x++)
            {
                for (var y = -size; y <= +size; y++)
                {
                    if (Mathf.Abs(x + y) > size) continue;
                    var tilePosition = new TilePosition(x, y);
                    Hexes.Add(tilePosition, new Hex(tilePosition));
                }
            }
        }
    }
}