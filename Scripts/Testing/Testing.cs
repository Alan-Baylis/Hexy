using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Testing : MonoBehaviour {

    Referent referent;

    void Start()
    {
        referent = GameObject.FindGameObjectWithTag("referent").GetComponent<Referent>();
        referent.KeyDown += (s, c) => { if (c.keycode != KeyCode.None) CallMe(c.keycode.ToString()); };
        referent.KeyDown += (s, c) => { if (c.keycode == KeyCode.Escape) KillTheGame(); };
        referent.MouseClicked += (s, p) => { DeleteTile(p.position); };
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
    void KillTheGame()
    {
        Debug.LogWarning("The game is quitting");
        Application.Quit();
    }
    void DeleteTile(Vector2 gridPos)
    {
        Debug.Log("Deleting: " + gridPos);
        Destroy(referent.map.GetTileAtWorld(gridPos));
    }
}
