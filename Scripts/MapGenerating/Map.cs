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

    public int Size(int dimension)
    {
        if (dimension != 0 && dimension != 1)
            throw new System.Exception("Invalid dimension");
        return tiles.GetLength(dimension);
    }

    [System.Obsolete("Marked for deletion")]
    public GameObject AddCity(int posX, int posY, string name)
    {
        return null;
    }

    private List<GameObject> plottedBase = new List<GameObject>();

    public void PlotBase(Transform holder)
    {
        for(int x = 0; x < Size(0); x++)
            for(int y = 0; y < Size(1); y++)
            {
                //creating the base GO
                GameObject createdTileBase = Object.Instantiate(ReferentStatic.ReferentDynamic().PFHexagonTileBlank);
                createdTileBase.name = "Tile [" + x + "; " + y + "] - Base (" + tiles[x, y].tileValue + ")";
                //positioning the base GO
                float newPosX = x * ReferentStatic.GOPlottingScalarX;
                float newPosY;
                if (x % 2 != 0)
                    newPosY = y * ReferentStatic.GOPlottingScalarY + ReferentStatic.GOPlottingScalarY / 2;
                else
                    newPosY = y * ReferentStatic.GOPlottingScalarY;
                Vector2 newPosition = new Vector2(newPosX, newPosY);
                createdTileBase.transform.position = newPosition;
                createdTileBase.transform.SetParent(holder, true);
                //getting the GOs
                GameObject createdTileSelectionRing = null,
                    createdTileOverlay = null,
                    createdTileTerrainTop = null,
                    createdTileTerrainMid = null,
                    createdTileTerrainBottom = null;
                int children_count = createdTileBase.transform.childCount;
                for(int i = 0; i < children_count; i++)
                {
                    GameObject children = createdTileBase.transform.GetChild(i).gameObject;
                    switch (children.name)
                    {
                        case "SelectionRing":
                            createdTileSelectionRing = children;
                            break;
                        case "Overlay":
                            createdTileOverlay = children;
                            break;
                        case "TerrainTop":
                            createdTileTerrainTop = children;
                            break;
                        case "TerrainMid":
                            createdTileTerrainMid = children;
                            break;
                        case "TerrainBottom":
                            createdTileTerrainBottom = children;
                            break;
                        default:
                            break;
                    }
                }
                //assigning the GOs
                MapTile toAssign = tiles[x, y];
                toAssign.associatedGOBase = createdTileBase;
                toAssign.associatedGOSelectionRing = createdTileSelectionRing;
                toAssign.associatedGOOverlay = createdTileOverlay;
                toAssign.associatedGOTerrainBottom = createdTileTerrainBottom;
                toAssign.associatedGOTerrainMid = createdTileTerrainMid;
                toAssign.associatedGOTerrainTop = createdTileTerrainTop;
                //set tile BG sprite
                SpriteRenderer renderer = createdTileBase.GetComponent<SpriteRenderer>();
                renderer.sprite = GetSpriteForValue(tiles[x, y].tileValue);
                //add base GO to plotted list for future deletion
                plottedBase.Add(createdTileBase);
            }
    }
    public void UnplotAll()
    {
        foreach (GameObject GO in plottedBase)
        {
            Object.Destroy(GO);
        }
    }

    private Sprite GetSpriteForValue(float value)
    {
        Referent referent = ReferentStatic.ReferentDynamic();
        if (value < 0.02f)
            return referent.TexturesBase[0];
        if (value < 0.15f)
            return referent.TexturesBase[1];
        if (value < 0.4f)
            return referent.TexturesBase[2];
        if (value < 0.58f)
            return referent.TexturesBase[3];
        return referent.TexturesBase[4];
    }
    private Sprite GetSpriteForType(ReferentStatic.TileTypes_Base type)
    {
        Referent referent = ReferentStatic.ReferentDynamic();
        switch (type)
        {
            case ReferentStatic.TileTypes_Base.DeepOcean:
                return referent.TexturesBase[0];
            case ReferentStatic.TileTypes_Base.ShallowOcean:
                return referent.TexturesBase[1];
            case ReferentStatic.TileTypes_Base.Shore:
                return referent.TexturesBase[2];
            case ReferentStatic.TileTypes_Base.Beach:
                return referent.TexturesBase[3];
            case ReferentStatic.TileTypes_Base.Ground:
                return referent.TexturesBase[4];
            default:
                return null;
        }
    }

    public MapTile GetTileAtWorld(Vector2 pos)
    {
        MapTile closest = null;
        float closestDelta = float.NaN;
        for (int x = 0; x < Size(0); x++)
            for (int y = 0; y < Size(1); y++)
            {
                MapTile tile = tiles[x, y];
                if (tile.associatedGOBase!= null)
                {
                    float delta = ((Vector2)tile.associatedGOBase.transform.position - pos).magnitude;
                    if (float.IsNaN(closestDelta))
                    {
                        closestDelta = delta;
                        closest = tile;
                    }
                    else if (delta < closestDelta)
                    {
                        closestDelta = delta;
                        closest = tile;
                    }
                }
            }
        return closest;
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
}
