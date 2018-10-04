using System;
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
        private static GameObject[] _terrains;
        
        private void OnSceneGUI()
        {   
            if (_layerSelection > 0)
            {
                int controlId = GUIUtility.GetControlID(FocusType.Passive);
                Event e = Event.current;
                HandleUtility.AddDefaultControl(controlId);

                switch (e.GetTypeForControl(controlId))
                {
                    case EventType.MouseDown:
                        if (e.button == 0)
                        {
                            spawmObject(e.mousePosition, _terrains[_terrainSelection]);
                            e.Use();
                        }
                        break;
                }
            }
        }
        
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            //TODO: auslagern do once
            _terrains = Resources.LoadAll<GameObject>("Terrain");
            _layerSelection = GUILayout.SelectionGrid(_layerSelection, _layerOptions, 3);
            _terrainSelection = GUILayout.SelectionGrid(_terrainSelection, extractTexture(_terrains), 5);
        }

        private Texture[] extractTexture(GameObject[] gameObjects)
        {
            return gameObjects.Select(o => o.GetComponent<SpriteRenderer>()).Where(renderer => renderer != null)
                .Select(renderer => renderer.sprite.texture).ToArray();
        }

        private void spawmObject(Vector3 mousePosition, GameObject objectToSpawn)
        {
            //TODO: spawn under child
            //TODO: undo, redo
            Grid grid = ((BoardController) target).GetComponent<Grid>();
            GameObject map = ((BoardController) target).gameObject;
            Debug.Log(map.name);
            
            var clickWorldPosition = HandleUtility.GUIPointToWorldRay (mousePosition).origin;
            Vector3Int clickCellPosition = grid.WorldToCell(clickWorldPosition);
            Vector3 cellCenterWorld = grid.GetCellCenterWorld(clickCellPosition);

            Transform cellTransform = map.transform.Find(clickCellPosition.ToString());
            if (cellTransform == null)
            {
                GameObject cell = new GameObject(clickCellPosition.ToString());
                cell.transform.parent = map.transform;
                cellTransform = cell.transform;
            }

            GameObject terrain = Instantiate(objectToSpawn, cellCenterWorld, Quaternion.identity);
            terrain.transform.parent = cellTransform;

        }
    }
}