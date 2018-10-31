using System;
using System.Collections.Generic;
using Boo.Lang.Runtime;
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

        public void AddHex(TilePosition position, Hex hex)
        {
            _hexes.Add(position, hex);
        }

        public Map()
        {
            if (_instance == null)
            {
                _instance = this;
            }
            else
            {
                throw new RuntimeException("trying to create new map");
            }
            
            _hexes = new Dictionary<TilePosition, Hex>();
        }
    }
}