using UnityEngine;
using System.Collections;

public class Testing : MonoBehaviour {
    public void GenerateWorld()
    {
        MapGenerator.CreateBlankGrid(new Vector2(40, 15), 0);
    }
}
