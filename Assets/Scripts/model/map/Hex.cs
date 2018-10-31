using System.Collections.Generic;
using Editor;
using model.position;
using UnityEngine;

namespace model.map
{
    public class Hex
    {
        public TilePosition Position { get; private set; }
        public Dictionary<Layer, GameObject> Layers { get; private set; }

        public Hex(TilePosition tilePosition, Dictionary<Layer, GameObject> layers)
        {
            Position = tilePosition;
            Layers = layers;
        }
    }
}