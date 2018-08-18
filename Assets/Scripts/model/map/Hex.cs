using UnityEngine;

namespace model.map
{
    public class Hex
    {
        private Road _road;
        public TilePosition Position { get; private set; }
        public GameObject GameObject { get; private set; }

        public Hex(TilePosition tilePosition)
        {
            Position = tilePosition;
            GameObject = Spawner.Instance.SpawnHex(Position.x, Position.y);
        }

        public void AddRoad()
        {
            _road = new Road(this);
        }
    }
}