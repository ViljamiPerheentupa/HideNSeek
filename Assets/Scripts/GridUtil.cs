using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GridUtil 
{
    public static Vector2Int LoopIndex(Vector2Int index)
    {
        return LoopIndex(index.x, index.y);
    }
    public static Vector2Int LoopIndex(int x, int y)
    {
        return new Vector2Int(mod(x, Generator.instance.gridSize.x), mod(y, Generator.instance.gridSize.y));
        int mod(int x, int m)
        {
            int r = x % m;
            return r < 0 ? r + m : r;
        }
    }
}
