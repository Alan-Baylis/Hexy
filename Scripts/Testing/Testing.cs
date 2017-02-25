using UnityEngine;
using System.Collections;
using System.Collections.Generic;
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
    void DeleteTile(Vector2 gridPos)
    {
        /*Debug.Log("Deleting: " + gridPos);
        Destroy(referent.map.GetTileAtWorld(gridPos));*/
    }
    void HandleClick(Vector2 worldPos)
    {
        /*switch (keymode)
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
        }*/

        /*//try to select stuff

        //raycast from top of the world down
        Vector3 raycastFrom = new Vector3(worldPos.x, worldPos.y, -10);
        Vector3 raycastTo = new Vector3(worldPos.x, worldPos.y);
        RaycastHit raycastHit;
        if(Physics.Raycast(raycastFrom, raycastTo, out raycastHit))
        {
            //raycasting found object
            GameObject objectHit = raycastHit.transform.gameObject;
            if(objectHit.GetComponent<Selectable>() != null)
            {
                //object is selectable

            }
        }*/

        MapTile tile = referent.map.GetTileAtWorld(worldPos);
        tile.selected = !tile.selected;
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
