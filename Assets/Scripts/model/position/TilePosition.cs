using System;
using System.Collections.Generic;
using System.Linq;

namespace model.position
{
    public class TilePosition {

        public int x;
        public int y;

        public TilePosition(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public static TilePosition operator +(TilePosition p1, TilePosition p2)
        {
            return new TilePosition(p1.x + p2.x, p1.y + p2.y);
        }

        public static TilePosition operator -(TilePosition p1, TilePosition p2)
        {
            return new TilePosition(p1.x - p2.x, p1.y - p2.y);
        }

        public override bool Equals(Object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            TilePosition p = (TilePosition)obj;
            return (x == p.x) && (y == p.y);
        }
        public override int GetHashCode()
        {
            return x ^ y;
        }
        public override string ToString()
        {
            return ("(" + x + ":" + y + ")");
        }
    }
}
