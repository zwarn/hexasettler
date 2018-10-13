using System;
using System.Linq;
using Boo.Lang.Runtime;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    public enum Layer {Terrain, Objects}
    
    [CustomEditor( typeof( BoardController))]
    public class MapEditor : UnityEditor.Editor
    {
        private int _layerSelection;
        private string[] _layerOptions = {"nothing", "Terrain", "Objects"};
        private int _terrainSelection;
        private int _objectSelection;
        private static GameObject[] _terrains;
        private static GameObject[] _objects;
        
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
                            spawmObject(e.mousePosition, selectedTile());
                            e.Use();
                        }
                        break;
                }
            }
        }

        private GameObject selectedTile()
        {
            if (_layerSelection == 1)
            {
                return _terrains[_terrainSelection];
            }

            if (_layerSelection == 2)
            {
                return _objects[_objectSelection];
            }

            return null;
        }

        private Layer getSelectedLayer()
        {
            if (_layerSelection == 1)
            {
                return Layer.Terrain;
            }

            if (_layerSelection == 2)
            {
                return Layer.Objects;
            }

            throw new RuntimeException("unknown selected Layer");
        }
        
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            //TODO: auslagern do once
            _terrains = Resources.LoadAll<GameObject>("Terrain");
            _objects = Resources.LoadAll<GameObject>("Objects");
            _layerSelection = GUILayout.SelectionGrid(_layerSelection, _layerOptions, 3);
            _terrainSelection = GUILayout.SelectionGrid(_terrainSelection, extractTexture(_terrains), 5);
            _objectSelection = GUILayout.SelectionGrid(_objectSelection, extractTexture(_objects), 5);
        }

        private Texture[] extractTexture(GameObject[] gameObjects)
        {
            return gameObjects.Select(o => AssetPreview.GetAssetPreview(o)).ToArray();
        }

        private void spawmObject(Vector3 mousePosition, GameObject objectToSpawn)
        {
            Grid grid = ((BoardController) target).GetComponent<Grid>();
            GameObject map = ((BoardController) target).gameObject;
            
            var clickWorldPosition = HandleUtility.GUIPointToWorldRay (mousePosition).origin;
            clickWorldPosition.z = 0;
            Vector3Int clickCellPosition = grid.WorldToCell(clickWorldPosition);
           
            MapUtil.PaintTile(map, getSelectedLayer(), grid, objectToSpawn, clickCellPosition);
        }
    }
}