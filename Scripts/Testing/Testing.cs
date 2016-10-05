using UnityEngine;
using System.Collections;

public class Testing : MonoBehaviour {
    void Start()
    {
        GenerateWorld();
    }
    public void GenerateWorld()
    {
        MapGenerator.MakeTerrainBase(MapGenerator.CreateBlankGrid(new Vector2(40, 15), 0), MapTypes.NormalLake);
    }
}
