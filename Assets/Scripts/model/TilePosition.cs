using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class TilePosition {
    
    public static TilePosition West = new TilePosition(-1, 0);
    public static TilePosition SouthWest = new TilePosition(0, -1);
    public static TilePosition SouthEast = new TilePosition(1, -1);
    public static TilePosition East = new TilePosition(1, 0);
    public static TilePosition NorthEast = new TilePosition(0, 1);
    public static TilePosition NorthWest = new TilePosition(-1, 1);

    public static List<TilePosition> baseDirections = new List<TilePosition> { West, SouthWest, SouthEast, East, NorthEast, NorthWest };

    int x;
    int y;

    public TilePosition(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public bool isBaseDirection()
    {
        return baseDirections.Contains(this);
    }

    public List<TilePosition> getNeighbors()
    {
        return baseDirections.Select(dir => this + dir).ToList<TilePosition>();
    }

    public static TilePosition operator +(TilePosition p1, TilePosition p2)
    {
        return new TilePosition(p1.x + p2.x, p1.y + p2.y);
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
