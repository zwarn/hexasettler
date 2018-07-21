using System;
using System.Collections;
using System.Collections.Generic;

public class TilePosition {

    int x;
    int y;

    public TilePosition(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public override bool Equals(Object obj)
    {
        // Check for null values and compare run-time types.
        if (obj == null || GetType() != obj.GetType())
            return false;

        TilePosition p = (TilePosition)obj;
        return (x == p.x) && (y == p.y);
    }
    public override int GetHashCode()
    {
        return x ^ y;
    }
}
