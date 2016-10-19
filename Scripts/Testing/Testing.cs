using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Testing : MonoBehaviour {
    
    void Start()
    {
        GenerateWorld();
        GameObject.FindGameObjectWithTag("referent").GetComponent<Referent>().KeyDown += (s, c) => { if(c.keycode != KeyCode.None) CallMe(c.keycode.ToString()); };
    }
    public void GenerateWorld()
    {
        MapGenerator.MakeTerrainBase(MapGenerator.CreateBlankGrid(new Vector2(49, 23), 0), MapTypes.NormalLake, Random.Range(-2571f,2571f));
    }
    public void Reload()
    {
        SceneManager.LoadScene(0);
    }
    void CallMe(string message)
    {
        Debug.Log(message);
    }
    void GetHexagonForCoordsScreenSpace(Vector2 coords)
    {

    }
    void GetHexagonForCoordsWorldSpace(Vector2 coords)
    {

    }
}
