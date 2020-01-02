using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World
{
    Tile[,] _tiles;
    int _width;
    int _height;

    public Tile[,] Tiles { get => _tiles; set => _tiles = value; }
    public int Width { get => _width; set => _width = value; }
    public int Height { get => _height; set => _height = value; }

    public World(int width, int height)
    {
        init(width, height);
        GenerateTiles();
    }

    void init(int width, int height) {
        Width = width;
        Height = height;
        Tiles = new Tile[width, height];
    }

    void GenerateTiles() 
    {
        for (int x = 0; x < Width; x++)
        {
            for (int z = 0; z < Height; z++)
            {
                Tile t = new Tile(x, 0, z, this);
                Tiles[x, z] = t;
            }
        }
    }

    public Tile GetTileAt(int x, int z)
    {
        if (Tiles[x, z] == null)
        {
            Debug.LogError("Tile at " + x + ", " + z + " not defined.");
            return null;
        }
        return Tiles[x, z];
    }
}
