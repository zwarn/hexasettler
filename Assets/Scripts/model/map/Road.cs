using UnityEngine;

namespace model.map
{
    public class Road
    {
        private Hex _hex;
        private GameObject _gameObject;
        //TODO: roadview
                
        public Road(Hex hex)
        {
            _hex = hex;
            _gameObject = Spawner.Instance.SpawnRoad(_hex.Position, _hex.GameObject);
        }
        
    }
}