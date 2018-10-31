using System.Collections.Generic;
using model.position;
using UnityEngine;

namespace model.map
{
    public class Road
    {
        private Dictionary<BaseDirection, Roads> _connections;
        private GameObject _gameObject;

        public Road(GameObject gameObject)
        {
            _connections = new Dictionary<BaseDirection, Roads>();
            _gameObject = gameObject;
        }
        
        //TODO: connect
    }
}