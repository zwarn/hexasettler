﻿using System;
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
                        Debug.Log(e.button);
                        if (e.button == 0)
                        {
                            Grid grid = ((BoardController) target).GetComponent<Grid>();
                            var clickWorldPosition = HandleUtility.GUIPointToWorldRay (e.mousePosition).origin;
                            Vector3Int clickCellPosition = grid.WorldToCell(clickWorldPosition);
                            Vector3 cellCenterWorld = grid.GetCellCenterWorld(clickCellPosition);
                            spawmObject(cellCenterWorld, _terrains[_terrainSelection]);
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

        private void spawmObject(Vector3 position, GameObject objectToSpawn)
        {
            //TODO: spawn under child
            //TODO: undo, redo
//            GameObject map = ((BoardController) target).gameObject;
            Instantiate(objectToSpawn, position, Quaternion.identity);
        }
    }
}