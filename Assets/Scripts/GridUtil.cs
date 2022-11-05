using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GridUtil 
{
    public static Vector2Int LoopIndex(Vector2Int index, Vector2Int gridSize)
    {
        return LoopIndex(index.x, index.y, gridSize);
    }
    public static Vector2Int LoopIndex(int x, int y, Vector2Int gridSize)
    {
        return new Vector2Int(mod(x, gridSize.x), mod(y, gridSize.y));
        int mod(int x, int m)
        {
            int r = x % m;
            return r < 0 ? r + m : r;
        }
    }
}
