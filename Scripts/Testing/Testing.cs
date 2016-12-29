using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Testing : MonoBehaviour {

    Referent referent;
    public BaseUnit selectedUnit;

    private enum KEYMODES { NONE, SPAWN_BASE_UINT, SPAWN_CITY, DELETE_BASE_UNIT, DELETE_CITY }
    private KEYMODES keymode = KEYMODES.NONE;

    void Start()
    {
        referent = GameObject.FindGameObjectWithTag("referent").GetComponent<Referent>();
        referent.KeyDown += (s, c) => { if (c.keycode != KeyCode.None)
            {
                CallMe(c.keycode.ToString());
                HandleKeyPress(c.keycode);
            }};
        referent.KeyDown += (s, c) => { if (c.keycode == KeyCode.None) isKeyDown = false; };
        referent.KeyDown += (s, c) => { if (c.keycode == KeyCode.Escape) KillTheGame(); };
        referent.MouseClicked += (s, p) => { HandleClick(p.position); };
        referent.map = GenerateWorld();
        MapPlotter.PlotBase(referent.map, referent.GOMapParent.transform);
        Debug.Log("Propably done with the world stuff");
    }
    public Map GenerateWorld()
    {
        float seed = Random.Range(-500, 500);
        Debug.Log("Map seed: " + seed);
        //return MapGenerator.MakeTerrainBase(MapGenerator.CreateBlankGrid(new Vector2(49, 23), 0), MapTypes.NormalLake, seed);
        float[,] perlinValues = MapGenerator.GenerateTerrainValues(25, 25, MapTypes.NormalLake, seed);
        Map newMap = new Map(25, 25);
        for(int x = 0; x < 25; x++)
            for(int y = 0; y < 25; y++)
            {
                newMap.tiles[x, y] = new MapTile(perlinValues[x, y], new Vector2(x, y));
                //newMap.tiles[x, y].tileValue = perlinValues[x, y];
            }
        return newMap;
    }
    public void Reload()
    {
        /*referent.map.ClearMap(true);
        referent.map = GenerateWorld();*/
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
        /*Debug.Log("Deleting: " + gridPos);
        Destroy(referent.map.GetTileAtWorld(gridPos));*/
    }
    void HandleClick(Vector2 worldPos)
    {
        switch (keymode)
        {
            case KEYMODES.NONE:
                break;
            case KEYMODES.SPAWN_BASE_UINT:
                break;
            case KEYMODES.SPAWN_CITY:
                break;
            case KEYMODES.DELETE_BASE_UNIT:
                break;
            case KEYMODES.DELETE_CITY:
                break;
            default:
                break;
        }
    }
    bool isKeyDown = false;
    void HandleKeyPress(KeyCode keyCode)
    {
        if (isKeyDown)
            return;
        isKeyDown = true;
        switch (keyCode)
        {
            case KeyCode.Delete:
                break;
            case KeyCode.UpArrow:
                break;
            case KeyCode.DownArrow:
                break;
            case KeyCode.RightArrow:
                break;
            case KeyCode.LeftArrow:
                break;
            case KeyCode.A:
                break;
            case KeyCode.B:
                break;
            case KeyCode.C:
                break;
            case KeyCode.D:
                break;
            case KeyCode.E:
                break;
            case KeyCode.F:
                break;
            case KeyCode.G:
                break;
            case KeyCode.H:
                break;
            case KeyCode.I:
                break;
            case KeyCode.J:
                break;
            case KeyCode.K:
                break;
            case KeyCode.L:
                break;
            case KeyCode.M:
                break;
            case KeyCode.N:
                break;
            case KeyCode.O:
                break;
            case KeyCode.P:
                break;
            case KeyCode.Q:
                break;
            case KeyCode.R:
                break;
            case KeyCode.S:
                break;
            case KeyCode.T:
                break;
            case KeyCode.U:
                break;
            case KeyCode.V:
                break;
            case KeyCode.W:
                break;
            case KeyCode.X:
                break;
            case KeyCode.Y:
                break;
            case KeyCode.Z:
                break;
            default:
                break;
        }
    }
}
