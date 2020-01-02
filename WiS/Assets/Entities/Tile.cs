using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** 
**  Tile class representents on tile square on data level
**/
public class Tile 
{
    /**
    **  All available tile types
    **/
    public enum TileType
    {
        Empty,
        Earth,
        Grass,
        Mud,
        Sand,
        Stone,
        Water
    }

    int _x;
    int _y;
    int _z;
    World _world;
    TileType _type;

    public int X { get => _x; set => _x = value; }
    public int Y { get => _y; set => _y = value; }
    public int Z { get => _z; set => _z = value; }
    public World World { get => _world; set => _world = value; }
    public TileType Type { get => _type; set => _type = value; }

    public Tile (int x, int y, int z, World world)
    {
        X = x;
        Y = y;
        Z = z;
        World = world;
        Type = DetermineTileType();
    }

    TileType DetermineTileType() {    
        return (TileType) Random.Range(1, 7);
    }

}
