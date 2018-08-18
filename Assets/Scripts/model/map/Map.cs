using System;
using System.Collections.Generic;
using model.position;
using UnityEngine;

namespace model.map
{
    public class Map
    {
        private static Map _instance;
        private readonly Dictionary<TilePosition, Hex> _hexes;

        public static Map Instance
        {
            get { return _instance; }
        }

        public Hex Hex(TilePosition position)
        {
            return _hexes.ContainsKey(position) ? _hexes[position] : null;
        } 

        public Map(int size)
        {
            if (_instance == null)
            {
                _instance = this;
            }
            
            _hexes = new Dictionary<TilePosition, Hex>();
            for (var x = -size; x <= size; x++)
            {
                for (var y = -size; y <= +size; y++)
                {
                    if (Mathf.Abs(x + y) > size) continue;
                    var tilePosition = new TilePosition(x, y);
                    _hexes.Add(tilePosition, new Hex(tilePosition));
                }
            }
        }
    }
}