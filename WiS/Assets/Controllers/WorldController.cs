using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldController : MonoBehaviour
{
    private static World _world;

    public static World INSTANCE { get => _world; set => _world = value; }

    // Start is called before the first frame update
    void Start()
    {
        INSTANCE = new World(100, 100);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
