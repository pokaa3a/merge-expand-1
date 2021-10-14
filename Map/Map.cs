using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

// uv: Screen space (1170 x 2532)
// xy: World space (2.31*2 x 5*2)
// rc: Row Column

public partial class Map
{
    const int rows = 6;
    const int cols = 6;
    const float step = 0.7f;

    public List<Tile> tiles = new List<Tile>();


}

public partial class Map
{
    // Singleton
    private static Map _instance;
    public static Map Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new Map();
            }
            return _instance;
        }
    }
}


public partial class Map
{
    public void CreateMap()
    {
        for (int r = 0; r < rows; ++r)
        {
            for (int c = 0; c < cols; ++c)
            {
                Tile tile = new Tile(new Vector2Int(r, c));
                tiles.Add(tile);
            }
        }

        // Add some blocks
        GetTile(new Vector2Int(0, 0)).AddBlockToTile(
            BlockColor.Yellow, BlockDirection.Right, 1);
    }

    public Tile GetTile(Vector2Int rc)
    {
        Assert.IsTrue(InsideMap(rc), $"rc({rc}) is not inside the map");
        return tiles[rc.x * cols + rc.y];
    }

    public bool InsideMap(Vector2Int rc)
    {
        return rc.x >= 0 && rc.x < rows && rc.y >= 0 && rc.y < cols;
    }

    public Vector2 RCtoXY(Vector2Int rc)
    {
        Assert.IsTrue(InsideMap(rc), $"rc({rc}) is not inside the map");
        float y = (rc.x - (rows - 1f) / 2f) * -step;
        float x = (rc.y - (cols - 1f) / 2f) * step;
        return new Vector2(x, y);
    }
}