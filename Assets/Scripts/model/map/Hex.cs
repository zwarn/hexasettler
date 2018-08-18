using UnityEngine;
using view;

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
            HexView hexView = GameObject.GetComponent<HexView>();
            hexView.Link(this);
        }

        public void AddRoad()
        {
            _road = new Road(this);
        }
    }
}