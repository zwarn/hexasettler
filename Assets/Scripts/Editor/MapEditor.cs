using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor( typeof( BoardController))]
    public class MapEditor : UnityEditor.Editor
    {
        private int _layerSelection;
        private string[] _layerOptions = {"nothing", "terrain", "objects"};
        private int _terrainSelection;
        private string[] _terrainOptions = {"gras", "dirt"};
        private static GameObject[] _terrains;
        
        private void OnSceneGUI()
        {
            GameObject map =
                Selection.gameObjects.FirstOrDefault(gameObject => gameObject.GetComponent<BoardController>() != null);
            
            if (map != null && _layerSelection > 0)
            {
                int controlId = GUIUtility.GetControlID(FocusType.Passive);
                Event e = Event.current;
                HandleUtility.AddDefaultControl(controlId);

                switch (e.GetTypeForControl(controlId))
                {
                    case EventType.MouseDown:
                        Debug.Log("click at " + e.mousePosition + " with " + (e.button == 0 ? "left" : "right"));
                        e.Use();
                        break;
                }
            }
        }
        
        public override void OnInspectorGUI()
        {
            //TODO: auslagern
            base.OnInspectorGUI();
            _terrains = Resources.LoadAll<GameObject>("Terrain");
            _layerSelection = GUILayout.SelectionGrid(_layerSelection, _layerOptions, 3);
            _terrainSelection = GUILayout.SelectionGrid(_terrainSelection, extractTexture(_terrains), 5);
        }

        private Texture[] extractTexture(GameObject[] gameObjects)
        {
            return gameObjects.Select(o => o.GetComponent<SpriteRenderer>()).Where(renderer => renderer != null)
                .Select(renderer => renderer.sprite.texture).ToArray();
        }
    }
}