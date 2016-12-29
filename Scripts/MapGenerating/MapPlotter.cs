using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MapPlotter {
    
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
                renderer.sprite = ReferentStatic.ReferentDynamic().TexturesBase[0];
            }
        Debug.Log("Propably done plotting map"); //TODO remove and cleanup
    }

}
