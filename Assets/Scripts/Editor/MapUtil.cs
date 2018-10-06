using UnityEditor;
using UnityEngine;

namespace Editor
{
	public static class MapUtil {

		public static void PaintTile(GameObject map, Layer layer, Grid grid, GameObject tile, Vector3Int position)
		{
			
			Vector3 cellCenterWorld = grid.GetCellCenterWorld(position);
			Transform cellTransform = map.transform.Find(position.ToString());
			if (cellTransform == null)
			{
				GameObject cell = new GameObject(position.ToString());
				cell.transform.parent = map.transform;
				cellTransform = cell.transform;
			}

			Transform layerTransform = cellTransform.Find(layer.ToString());
			if (layerTransform == null)
			{
				GameObject layerObject = new GameObject(layer.ToString());
				layerObject.transform.parent = cellTransform;
				layerTransform = layerObject.transform;
			}

			if (layerTransform.childCount > 0)
			{
				// remove and add
				foreach (Transform child in layerTransform)
				{
					Undo.DestroyObjectImmediate(child.gameObject);
				}
			}

			GameObject instance = Object.Instantiate(tile, cellCenterWorld, Quaternion.identity);
			Undo.RegisterCreatedObjectUndo(instance, "create object");
			Undo.SetTransformParent(instance.transform, layerTransform, "set transform");
		}
	}
}
