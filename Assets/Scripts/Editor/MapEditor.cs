using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    public class MapEditor : EditorWindow
    {
        private int _selection;
        private string[] options = {"gras", "dirt"};


        [MenuItem("Window/MapEditor")]
        private static void Init()
        {
            GetWindow<MapEditor>().Show();
        }

        private void SceneGUI(SceneView sceneView)
        {
            GameObject map =
                Selection.gameObjects.FirstOrDefault(gameObject => gameObject.GetComponent<BoardController>() != null);
            
            if (map != null)
            {
                Event e = Event.current;
                int controlId = GUIUtility.GetControlID(FocusType.Passive);
                HandleUtility.AddDefaultControl(controlId);

                switch (e.GetTypeForControl(controlId))
                {
                    case EventType.MouseDown:
                        Debug.Log("click at " + e.mousePosition + " with " + (e.button == 1 ? "left" : "right"));
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
            _selection = GUILayout.SelectionGrid(_selection, options, 5);
        }
    }
}