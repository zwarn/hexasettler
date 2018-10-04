using UnityEngine;

namespace Editor
{
	public class MapUtil {

		public static void paintTile(GameObject map, Layer layer, Grid grid, GameObject tile, Vector3Int position)
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

			//TODO: undo support
			if (layerTransform.childCount > 0)
			{
				// remove and add
				foreach (Transform child in layerTransform)
				{
					Object.DestroyImmediate(child.gameObject);
				}
			}

			GameObject terrain = Object.Instantiate(tile, cellCenterWorld, Quaternion.identity);
			terrain.transform.parent = layerTransform;
		}
	}
}
