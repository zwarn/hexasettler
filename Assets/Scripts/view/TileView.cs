using UnityEngine;

namespace view
{
    public class TileView : MonoBehaviour {

        public Tile Tile;
        private BoardController _boardController;

        public void Awake()
        {
            _boardController = BoardController.Instance;
        }

        private void OnMouseEnter()
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(0.9f, 0.9f, 0.9f);
            _boardController.selectedTile(Tile);
        }

        private void OnMouseExit()
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f);
            _boardController.deselectTile(Tile);
        }
    }
}
