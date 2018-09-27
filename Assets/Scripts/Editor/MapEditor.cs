using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    public class MapEditor : EditorWindow
    {
        private int _layerSelection;
        private string[] _layerOptions = {"nothing", "terrain", "objects"};
        private int _terrainSelection;
        private string[] _terrainOptions = {"gras", "dirt"};
        private static GameObject[] _terrains;


        [MenuItem("Window/MapEditor")]
        private static void Init()
        {
            GetWindow<MapEditor>().Show();
            _terrains = Resources.LoadAll<GameObject>("Terrain");
        }

        private void SceneGUI(SceneView sceneView)
        {
            GameObject map =
                Selection.gameObjects.FirstOrDefault(gameObject => gameObject.GetComponent<BoardController>() != null);
            
            if (map != null && _layerSelection > 0)
            {
                Event e = Event.current;
                int controlId = GUIUtility.GetControlID(FocusType.Passive);
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

        private void OnEnable()
        {
            SceneView.onSceneGUIDelegate += SceneGUI;
        }

        public void OnGUI()
        {
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