using UnityEngine;
using System.Collections;

public class Map {

    private GameObject[,] tilesGOs;
    private Vector2[,] positionsWorld;

    public Map(int width, int height)
    {
        tilesGOs = new GameObject[width, height];
        positionsWorld = new Vector2[width, height];
    }

    public void ClearMap(bool removeFromScene)
    {
        if (removeFromScene)
            foreach (GameObject go in tilesGOs)
                GameObject.Destroy(go);
        tilesGOs = new GameObject[tilesGOs.GetLength(0), tilesGOs.GetLength(1)];
        positionsWorld = new Vector2[tilesGOs.GetLength(0), tilesGOs.GetLength(1)];
    }
    public bool AddTile(GameObject tile, Vector2 coordsGrid, Vector2 coordsWorld)
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
    }
}
