using System;
using System.Collections.Generic;
using UnityEngine;

namespace model.map
{
    public class Map
    {
        private Tilelayer _tilelayer;
        private RoadLayer _roadLayer;

        public Map(int size)
        {
            _tilelayer = new Tilelayer(size);
            _roadLayer = new RoadLayer(size);
        }
    }

    internal abstract class MapLayer<T>
    {
        private Dictionary<TilePosition, T> _layer;
        protected void Initialize(int size, Func<TilePosition, T> creator)
        {
            _layer = new Dictionary<TilePosition, T>();
            for (var x = -size; x <= size; x++)
            {
                for (var y = -size; y <= +size; y++)
                {
                    if (Mathf.Abs(x + y) > size) continue;
                    var tilePosition = new TilePosition(x, y);
                    _layer.Add(tilePosition, creator(tilePosition));
                }
            }
        }
    }

    internal class Tilelayer : MapLayer<Tile>
    {
        public Tilelayer(int size) 
        {
            Initialize(size, position => new Tile(position));
        }
    }
    
    internal class RoadLayer : MapLayer<Road>
    {
        public RoadLayer(int size)
        {
            Initialize(size, position => new Road(position));
        }
    }
}