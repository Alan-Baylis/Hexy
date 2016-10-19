using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Testing : MonoBehaviour {
    
    void Start()
    {
        Referent referent = GameObject.FindGameObjectWithTag("referent").GetComponent<Referent>();
        referent.KeyDown += (s, c) => { if (c.keycode != KeyCode.None) CallMe(c.keycode.ToString()); };
        referent.map = GenerateWorld();
    }
    public Map GenerateWorld()
    {
        return MapGenerator.MakeTerrainBase(MapGenerator.CreateBlankGrid(new Vector2(49, 23), 0), MapTypes.NormalLake, Random.Range(-2571f,2571f));
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
