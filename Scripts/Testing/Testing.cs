using UnityEngine;
using System.Collections;

public class Testing : MonoBehaviour {
    void Start()
    {
        GenerateWorld();
    }
    public void GenerateWorld()
    {
        MapGenerator.MakeTerrainBase(MapGenerator.CreateBlankGrid(new Vector2(49, 23), 0), MapTypes.NormalLake);
    }
}
