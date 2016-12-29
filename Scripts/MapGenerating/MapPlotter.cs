using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MapPlotter {

    private static List<GameObject> plotted = new List<GameObject>();

    public static void PlotBase(Map map, Transform holder)
    {
        for(int x = 0; x < map.Size(0); x++)
            for(int y = 0; y < map.Size(1); y++)
            {
                GameObject createdTile = new GameObject("Tile - Base (" + map.tiles[x, y].tileValue + ")");
                float newPosX = x * ReferentStatic.GOPlottingScalarX;
                float newPosY;
                if (x % 2 != 0)
                    newPosY = y * ReferentStatic.GOPlottingScalarY + ReferentStatic.GOPlottingScalarY / 2;
                else
                    newPosY = y * ReferentStatic.GOPlottingScalarY;
                Vector2 newPosition = new Vector2(newPosX, newPosY);
                createdTile.transform.position = newPosition;
                createdTile.transform.SetParent(holder, true);
                map.tiles[x, y].associatedGOBase = createdTile;
                SpriteRenderer renderer = createdTile.AddComponent<SpriteRenderer>();
                renderer.sprite = GetSpriteForValue(map.tiles[x, y].tileValue);

                plotted.Add(createdTile);
            }
        Debug.Log("Propably done plotting map"); //TODO remove and cleanup
    }
    public static void DestroyAll()
    {
        foreach(GameObject toDestroy in plotted)
        {
            GameObject.Destroy(toDestroy);
        }
    }
    private static Sprite GetSpriteForValue(float value)
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
    private static Sprite GetSpriteForType(ReferentStatic.TileTypes_Base type)
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
}
