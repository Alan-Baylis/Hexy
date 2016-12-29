using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Map {

    public MapTile[,] tiles;
    private int[] dimensions;

    public Map(int sizeX, int sizeY)
    {
        dimensions = new int[] { sizeX, sizeY };
        tiles = new MapTile[sizeX, sizeY];
    }

    /*public void PopulateBlank()
    {
        for (int x = 0; x < Size(0); x++)
            for (int y = 0; y < Size(1); y++)
            {

            }
    }
    */
    public int Size(int dimension)
    {
        if (dimension != 0 && dimension != 1)
            throw new System.Exception("Invalid dimension");
        return tiles.GetLength(dimension);
    }

    public MapTile GetTileAtWorld(Vector2 pos)
    {
        for (int x = 0; x < Size(0); x++)
            for (int y = 0; y < Size(1); y++)
            {
                MapTile tile = tiles[x, y];
                if (tile.associatedGOBase!= null)
                {
                    Vector2 gridPos = GetGridPosOf(pos);
                    if (gridPos == tile.positionGrid)
                    {
                        return tile;
                    }
                }
            }
        return null;
    }

    public Vector2 GetGridPosOf(Vector2 worldPos)
    {
        float distance = float.MaxValue;
        int foundX = -1;
        int foundY = -1;
        for (int i = 0; i < Size(0); i++)
            for (int j = 0; j < Size(1); j++)
            {
                MapTile tile = tiles[i, j];
                float distanceX = worldPos.x - tile.associatedGOBase.transform.position.x;
                float distanceY = worldPos.y - tile.associatedGOBase.transform.position.y;
                float a = distanceX * distanceX;
                float b = distanceY * distanceY;
                float c = Mathf.Sqrt(a + b);
                if (c < distance)
                {
                    distance = c;
                    foundX = i;
                    foundY = j;
                }
            }
        return new Vector2(foundX, foundY);
    }

    /*private GameObject[,] tilesGOs;
    private Vector2[,] positionsWorld;
    private int width, height;
    public GameObject[,] MapGOs { get
        {
            return tilesGOs;
        }
        set
        {
            Debug.LogWarning("Direct interference with map grid at object Map. This is not recommended!");
            tilesGOs = value;
        }
    }
    public Vector2[,] MapPos
    {
        get
        {
            return positionsWorld;
        }set
        {
            Debug.LogWarning("Direct interference with position grid at object Map. This is not recommended!");
            positionsWorld = value;
        }
    }
    public Dictionary<GameObject, Vector2> Positions
    {
        get
        {
            Debug.LogWarning("Using Positions is not recommended, because it iterates through all tiles with every call");
            Dictionary<GameObject, Vector2> toReturn = new Dictionary<GameObject, Vector2>();
            for (int i = 0; i < tilesGOs.GetLength(0); i++)
                for (int j = 0; j < tilesGOs.GetLength(1); j++)
                    toReturn.Add(tilesGOs[i, j], positionsWorld[i, j]);
            return toReturn;
        }
    }
    public int Width
    {
        get { return width; }
    }
    public int Height
    {
        get { return height; }
    }

    public Map(int width, int height)
    {
        tilesGOs = new GameObject[width, height];
        positionsWorld = new Vector2[width, height];
        this.width = width;
        this.height = height;
    }

    public void ClearMap(bool removeFromScene)
    {
        if (removeFromScene)
            foreach (GameObject go in tilesGOs)
                Object.Destroy(go);
        tilesGOs = new GameObject[tilesGOs.GetLength(0), tilesGOs.GetLength(1)];
        positionsWorld = new Vector2[tilesGOs.GetLength(0), tilesGOs.GetLength(1)];
    }
    public bool AddTile(GameObject tile, Vector2 coordsGrid, Vector2 coordsWorld)
    {
        return ChangeTile(tile, coordsGrid, coordsWorld);
    }
    public bool ChangeTile(GameObject tile, Vector2 coordsGrid, Vector2 coordsWorld)
    {
        if (coordsGrid.x > tilesGOs.GetLength(0) || coordsGrid.y > tilesGOs.GetLength(1))
            return false;
        tilesGOs[(int)coordsGrid.x, (int)coordsGrid.y] = tile;
        positionsWorld[(int)coordsGrid.x, (int)coordsGrid.y] = coordsWorld;
        return true;
    }
    public Vector2 GetWorldPosOf(Vector2 gridCoords)
    {
        return positionsWorld[(int)gridCoords.x, (int)gridCoords.y];
    }
    public Vector2 GetGridPosOf(Vector2 worldPos)
    {
        float distance = float.MaxValue;
        int foundX = -1;
        int foundY = -1;
        for (int i = 0; i < positionsWorld.GetLength(0); i++)
            for (int j = 0; j < positionsWorld.GetLength(1); j++)
            {
                float distanceX = worldPos.x - positionsWorld[i, j].x;
                float distanceY = worldPos.y - positionsWorld[i, j].y;
                float a = distanceX * distanceX;
                float b = distanceY * distanceY;
                float c = Mathf.Sqrt(a + b);
                if (c < distance)
                {
                    distance = c;
                    foundX = i;
                    foundY = j;
                }
            }
        return new Vector2(foundX, foundY);
    }
    public GameObject GetTileAtWorld(Vector2 worldPos)
    {
        Vector2 gridPos = GetGridPosOf(worldPos);
        return tilesGOs[(int)gridPos.x, (int)gridPos.y];
    }
    public GameObject GetTileAtGrid(Vector2 gridPos)
    {
        return tilesGOs[(int)gridPos.x, (int)gridPos.y];
    }*/


}
