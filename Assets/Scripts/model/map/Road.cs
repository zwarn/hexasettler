using System.Linq;
using controller;
using UnityEngine;
using view;

namespace model.map
{
    public class Road
    {
        private readonly Hex _hex;
        private readonly GameObject _gameObject;
        private readonly RoadView _roadView;
                
        public Road(Hex hex)
        {
            _hex = hex;
            _gameObject = Spawner.Instance.SpawnRoad(_hex.Position, _hex.GameObject);
            _roadView = _gameObject.GetComponent<RoadView>();
        }

        public void UpdateView()
        {
            _roadView.UpdateView(MapHelper.GetNeighborRoadsDictionary(_hex.Position));
        }
        
    }
}