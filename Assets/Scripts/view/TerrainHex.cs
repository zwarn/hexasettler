using model.map;
using UnityEngine;

namespace view
{
    public class TerrainHex : MonoBehaviour {

        private Hex _hex;
        private BoardController _boardController;

        public void Awake()
        {
            _boardController = BoardController.Instance;
        }

        private void OnMouseEnter()
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(0.9f, 0.9f, 0.9f);
            _boardController.SelectedTile(_hex);
        }

        private void OnMouseExit()
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f);
            _boardController.DeselectTile(_hex);
        }

        public void Link(Hex hex)
        {
            _hex = hex;
        }
    }
}
