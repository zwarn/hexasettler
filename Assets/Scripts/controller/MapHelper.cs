using System.Collections.Generic;
using System.Linq;
using model.map;
using model.position;

namespace controller
{
    public class MapHelper
    {
        public static IEnumerable<TilePosition> GetNeighbors(TilePosition position)
        {
            return BaseDirection.BaseDirections.Select(baseDir => baseDir + position);
        }

        public static IEnumerable<Hex> GetNeighborHexes(TilePosition position)
        {
            return GetNeighbors(position).Select(pos => Map.Instance.Hex(pos)).Where(hex => hex != null);
        }

        //TODO: rework
//        public static IEnumerable<Road> GetNeighborRoads(TilePosition position)
//        {
//            return GetNeighborHexes(position).Select(hex => hex.Road).Where(road => road != null);
//        }

        public static Dictionary<BaseDirection, Hex> GetNeighborHexDictionary(TilePosition position)
        {
            return BaseDirection.BaseDirections.ToDictionary(dir => dir, dir => Map.Instance.Hex(position + dir));
        }

//        public static Dictionary<BaseDirection, Road> GetNeighborRoadsDictionary(TilePosition position)
//        {
//            return GetNeighborHexDictionary(position).ToDictionary(pair => pair.Key, pair => pair.Value != null ? pair.Value.Road : null);
//        }
    }
}