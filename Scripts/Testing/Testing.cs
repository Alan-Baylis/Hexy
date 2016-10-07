using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Testing : MonoBehaviour {
    
    void Start()
    {
        GenerateWorld();
    }
    public void GenerateWorld()
    {
        MapGenerator.MakeTerrainBase(MapGenerator.CreateBlankGrid(new Vector2(49, 23), 0), MapTypes.NormalLake, Random.Range(-2571f,2571f));
    }
    public void Reload()
    {
        SceneManager.LoadScene(0);
    }
}
