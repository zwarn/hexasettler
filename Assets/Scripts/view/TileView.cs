using model.map;
using UnityEngine;

namespace view
{
    public class TileView : MonoBehaviour {

        private Hex _hex;
        private BoardController _boardController;

        public void Awake()
        {
            _boardController = BoardController.Instance;
        }

        private void OnMouseEnter()
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(0.9f, 0.9f, 0.9f);
            _boardController.selectedTile(_hex);
        }

        private void OnMouseExit()
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f);
            _boardController.deselectTile(_hex);
        }

        public void Link(Hex hex)
        {
            _hex = hex;
        }
    }
}
