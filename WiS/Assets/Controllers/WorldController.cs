using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldController : MonoBehaviour
{
    public GameObject Earth;
    public GameObject Grass;
    public GameObject Mud;
    public GameObject Sand;
    public GameObject Stone;
    public GameObject Water;
    public GameObject Empty;

    public static WorldController INSTANCE;
    
    static World _world;
    Dictionary<Tile, GameObject> _worldTileDictionary;

    public static World World { get => _world; set => _world = value; }
    public Dictionary<Tile, GameObject> WorldTileDictionary { get => _worldTileDictionary; set => _worldTileDictionary = value; }

    // Start is called before the first frame update
    void Start()
    {
        INSTANCE = this;
        WorldTileDictionary = new Dictionary<Tile, GameObject>();

        CreateWorld(100, 100);
    }

    void CreateWorld(int w, int h)
    {
        World = new World(w, h);
        CreateGameObjects();
    }

    void CreateGameObjects()
    {
        for (int x = 0; x < World.Width; x++)
        {
            for (int z = 0; z < World.Height; z++)
            {
                Tile t = World.GetTileAt(x, z);
                
                Vector3 position = new Vector3(x, 0, z);
                GameObject gameObject;
 
                switch (t.Type)
                {
                    case Tile.TileType.Earth:
                        gameObject = Instantiate(Earth, position, Quaternion.identity, transform);
                        break;
                    case Tile.TileType.Grass:
                        gameObject = Instantiate(Grass, position, Quaternion.identity, transform);
                        break;
                    case Tile.TileType.Mud:
                        gameObject = Instantiate(Mud, position, Quaternion.identity, transform);
                        break;
                    case Tile.TileType.Sand:
                        gameObject = Instantiate(Sand, position, Quaternion.identity, transform);
                        break;
                    case Tile.TileType.Stone:
                        gameObject = Instantiate(Stone, position, Quaternion.identity, transform);
                        break;
                    case Tile.TileType.Water:
                        gameObject = Instantiate(Water, position, Quaternion.identity, transform);
                        break;
                    default:
                        gameObject = Instantiate(Empty, position, Quaternion.identity, transform);
                        break;
                }

                gameObject.name = x + "|" + z + "\t" + t.Type;
                WorldTileDictionary.Add(t, gameObject);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
