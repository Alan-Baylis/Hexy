using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Testing : MonoBehaviour {

    Referent referent;
    public BaseUnit selectedUnit;

    private enum KEYMODES { NONE, SPAWN_BASE_UINT, SPAWN_CITY, DELETE_BASE_UNIT, DELETE_CITY }
    private KEYMODES keymode = KEYMODES.NONE;
    private enum MouseStates { Down, Held, Released, None}

    void Start()
    {
        referent = GameObject.FindGameObjectWithTag("referent").GetComponent<Referent>();
        referent.KeyDown += (s, c) => { if (c.keycode != KeyCode.None)
            {
                CallMe(c.keycode.ToString());
                HandleKeyPress(c.keycode);
            } };
        referent.KeyDown += (s, c) => { if (c.keycode == KeyCode.None) isKeyDown = false; };
        referent.KeyDown += (s, c) => { if (c.keycode == KeyCode.Escape) KillTheGame(); };
        referent.MouseDown += (s, p) => { HandleClick(p.position, MouseStates.Down); };
        referent.MouseHeld += (s, p) => { HandleClick(p.position, MouseStates.Held); };
        referent.MouseReleased += (s, p) => { HandleClick(p.position, MouseStates.Released); };

        int childCount = referent.GOMapParent.transform.childCount;
        for(int i = 0; i < childCount; i++)
        {
            GameObject child = referent.GOMapParent.transform.GetChild(i).gameObject;
            Destroy(child);
        }

        referent.map = GenerateWorld();
        //SaveHandler.SaveMap(referent.map, @"D:\map_save.fur");

        //referent.map = SaveHandler.LoadMap(@"D:\map_save.fur");

        referent.map.PlotBase(referent.GOMapParent.transform);
        //MapPlotter.PlotBase(referent.map, referent.GOMapParent.transform);
        //Debug.Log("Propably done with the world stuff");
    }
    public Map GenerateWorld()
    {
        int[] mapSize = new int[] { 52, 26 };

        float seed = Random.Range(-500, 500);
        Debug.Log("Map seed: " + seed);
        float[,] perlinValues = MapGenerator.GenerateTerrainValues(mapSize[0], mapSize[1], MapTypes.NormalLake, seed);
        Map newMap = new Map(mapSize[0], mapSize[1]);
        for(int x = 0; x < mapSize[0]; x++)
            for(int y = 0; y < mapSize[1]; y++)
            {
                newMap.tiles[x, y] = new MapTile(perlinValues[x, y], new Vector2(x, y));
            }
        return newMap;
    }

    List<Vector2> citiesPositions = new List<Vector2>();
    public void CreateRandomCity()
    {
        int posX = Random.Range(0, ReferentStatic.ReferentDynamic().map.Size(0));
        int posY = Random.Range(0, ReferentStatic.ReferentDynamic().map.Size(1));


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

    [System.Obsolete("Marked for deletion")]
    void DeleteTile(Vector2 gridPos)
    {
        /*Debug.Log("Deleting: " + gridPos);
        Destroy(referent.map.GetTileAtWorld(gridPos));*/
    }

    Vector2 _pos_initial;
    void HandleClick(Vector2 worldPos, MouseStates state)
    {
        //Debug.Log("Click state: " + state);

        if(state == MouseStates.Down)
        {
            _pos_initial = worldPos;
        }else if(state == MouseStates.Released)
        {
            float distance_traced = (_pos_initial - worldPos).magnitude;
            //Debug.Log("Distance traced: " + distance_traced);

            if(distance_traced < 0.35f)
            {
                Debug.Log("Clicked");
            }else
            {
                Debug.Log("Dragged");
            }
        }

        /*MapTile tile = referent.map.GetTileAtWorld(worldPos);
        tile.selected = !tile.selected;*/
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
