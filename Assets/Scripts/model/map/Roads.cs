using System.Collections.Generic;
using Boo.Lang.Runtime;
using model.position;
using UnityEngine;

namespace model.map
{
    public class Roads
    {
        private static Roads _instance;
        private Dictionary<TilePosition, Road> _roads;

        public static Roads Instance
        {
            get { return _instance; }
        }

        public void Add(TilePosition position, GameObject roadObject)
        {
            _roads.Add(position, new Road(roadObject));
        }

        public Road Road(TilePosition position)
        {
            return _roads[position];
        }

        public Roads()
        {
            if (_instance == null)
            {
                _instance = this;
            }
            else
            {
                throw new RuntimeException("trying to create new Roads object");
            }

            _roads = new Dictionary<TilePosition, Road>();
        }
    }
}